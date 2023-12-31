﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
    public class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }

        public Book[] GetAllByQuery(string query)
        {
            if (Book.IsIsbn(query))
                return _bookRepository.GetAllByIsbn(query);

            return _bookRepository.GetAllByTitleOrAuthor(query);
        }
    }
}
