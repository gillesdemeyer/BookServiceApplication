﻿using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerCrudBase<Reader, ReaderRepository>
    {
        public ReadersController(ReaderRepository readerRepository) : base(readerRepository)
        {
        }
    }
}