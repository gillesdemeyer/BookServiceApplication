using BookService.Lib.DTO;

namespace BookService.MVC.ViewModels
{
    public class BookDetailExtraViewModel
    {
        public BookDetail BookDetail { get; set; }
        public string AuthorJoke { get; set; }
        public string BookSummary { get; set; }
    }
}
