using System;
using System.Collections.Generic;
using BookListService.Service;
using BookSystemLogic;

namespace BookListService
{
    public class BookService : IBookService
    {
        #region private fields

        private List<Book> bookList = new List<Book>();

        #endregion

        #region properties

        public List<Book> BookListProperty
        {
            get => bookList;
        }

        #endregion

        #region class methods

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            try
            {
                bookList.Add(book);
            }
            catch (Exception e)
            {
                throw new ServiceException("Can't add book", e);
            }
        }

        public void AddBook(params Book[] books)
        {
            if (ReferenceEquals(books, null))
            {
                throw new ArgumentNullException(nameof(books));
            }

            try
            {
                foreach (var book in books)
                {
                    if (!ReferenceEquals(book, null))
                    {
                        AddBook(book);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ServiceException("Can't add books", e);
            }
        }

        public Book FindBookByTag(string ISBN)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            try
            {
                bookList.Remove(book);
            }
            catch (Exception e)
            {
                throw new ServiceException("Can't remove book", e);
            }
        }

        public void RemoveBook(string ISBN)
        {
            if (string.IsNullOrWhiteSpace(ISBN))
            {
                throw new ArgumentException(nameof(ISBN));
            }

            try
            {
                for (int i = 0; i < bookList.Count; i++)
                {
                    if (bookList[i].ISBNProperty == ISBN)
                    {
                        bookList.RemoveAt(i);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                throw new ServiceException("Can't remove book  by ISBN", e);
            }
        }

        public List<Book> SortBooksByTag()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
