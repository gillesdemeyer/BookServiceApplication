
var apiURL = 'https://localhost:44338/api/';

var app = new Vue({
    el: '#app',
    data: {
        message: 'Loading books...',
        books: null,
        authors: null,
        currentBook: null,
        isReadOnly: true,
        isEdit: false
    },
    created: function () {
        var self = this;
        self.fetchBooks();
        self.fetchAuthors();
        self.fetchPublishers();
    },
    methods: {
        fetchBooks: function () {
            self = this;
            fetch(`${apiURL}Books/Basic`)
                .then(res => res.json())
                .then(function (books) {
                    books.forEach(function (book, i) {
                        book.isActive = false;
                    });
                    self.books = books;
                    self.message = 'Overview';
                    if (self.books.length > 0) {
                        self.fetchBookDetails(self.books[0]);
                    }
                })
                .catch(err => console.error('Fout: ' + err));
        },
        fetchBookDetails: function (book) {
            self = this;
            if (!self.isReadOnly) return;
            fetch(`${apiURL}Books/${book.id}`)
                .then(res => res.json())
                .then(function (res) {
                    self.currentBook = res;
                    self.makeBookActive(book.id);
                })
                .catch(err => console.error('Fout: ' + err));
        },
        makeBookActive: function (bookid) {
            self.books.forEach(function (book) {
                book.isActive = book.id === bookid ? true : false;
            });
        },

        getBookClass: function (book) {
            if (book.isActive) return 'list-group-item active';
            return 'list-group-item';
        },
        fetchAuthors: function () {
            self = this;
            fetch(`${apiURL}Authors`)
                .then(res => res.json())
                .then(function (res) {
                    self.authors = res;
                })
                .catch(err => console.error('Fout: ' + err));
        },
        fetchPublishers: function () {
            self = this;
            fetch(`${apiURL}Publishers`)
                .then(res => res.json())
                .then(function (res) {
                    self.publishers = res;
                })
                .catch(err => console.error('Fout: ' + err));
        },
        toEditMode: function (isEdit) {
            self = this;
            self.isReadOnly = false;
            self.isEdit = isEdit;
            if (!isEdit) {
                self.currentBook = { "title": "", "isbn": "", "year": 0, "price": 0, "numberOfPages": 0, "authorId": 0, "author": { "firstName": "", "lastName": "", "birthDate": "", "id": 0, "created": "" }, "publisherId": 0, "publisher": { "name": "", "": "", "id": 0, "created": "" }, "fileName": "", "ratings": null, "id": 0, "created": "" };
            }
        },
        save: function () {
            var self = this;

            // de properties authorId en publisherId van het Book zijn nog leeg
            // de vue.js databinding vult enkel de compositeproperties author en publisher
            self.currentBook.authorId = self.currentBook.author.id;
            self.currentBook.publisherId = self.currentBook.publisher.id;

            // opslaan - ajax configuratie
            var ajaxHeaders = new Headers();
            ajaxHeaders.append("Content-Type", "application/json");
            var ajaxConfig = {
                method: 'PUT',
                body: JSON.stringify(self.currentBook),
                headers: ajaxHeaders
            };

            if (self.isEdit) {
                let myRequest = new Request(`${apiURL}Books/${self.currentBook.id}`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.updateBookList(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            else {
                ajaxConfig.method = 'POST';
                let myRequest = new Request(`${apiURL}Books/`, ajaxConfig);
                fetch(myRequest)
                    .then(res => res.json())
                    .then(res => {
                        self.addBookToList(res);
                    })
                    .catch(err => console.error('Fout: ' + err));
            }
            self.isEdit = false;
            self.isReadOnly = true;
        },
        addBookToList: function (book) {

            self.currentBook.id = book.id;
            self.books.push(book);
            self.fetchBookDetails(self.books[self.books.length - 1]);
        },
        updateBookList: function (book) {
            // het geupdate boek uit de boekenlijst ophalen (dit is een lijst van BookBasic-elementen)
            var updatedBook = self.books.filter(b => b.id === book.id)[0];
            // gegevens aanpassen
            updatedBook.title = book.title;
        },
        cancel: function () {
            var self = this;
            self.isReadOnly = true;
            self.isEdit = false;
            if (self.isEdit) {
                self.fetchBookDetails(self.currentBook);
            } else {
                self.fetchBookDetails(self.books[0]);
            }
        },
        deleteBook: function () {
            self = this;
            fetch(`${apiURL}Books/${self.currentBook.id}`, { method: 'DELETE' })
                .then(res => res.json())
                .then(function (res) {
                    // boek verwijderen uit de lijst
                    self.books.forEach(function (book, i) {
                        if (book.id === self.currentBook.id) {
                            self.books.splice(i, 1);
                            return;
                        }
                    });
                    // eerste boek selecteren
                    if (self.books.length > 0)
                        self.fetchBookDetails(self.books[0]);
                })
                .catch(err => console.error('Fout: ' + err));
        },
    }
});