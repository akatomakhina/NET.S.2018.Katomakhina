using System.Collections.Generic;
using BookSystemLogic;

namespace BookListService
{
    interface IBookService
    {
        void AddBook(Book book);
        void AddBook(params Book[] books);
        void RemoveBook(Book book);
        void RemoveBook(string ISBN);
        Book FindBookByTag(string ISBN);
        List<Book> SortBooksByTag();
    }
}
