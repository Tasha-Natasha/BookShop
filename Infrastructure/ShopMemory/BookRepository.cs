using BookShop;

namespace ShopMemory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book (1, "ISBN 11111-11111", "D.Knuth",  "Art of programming"),
            new Book (2, "ISBN 22222-22222", "M.Fowler",  "Refactoring"),
            new Book (3, "ISBN 33333-33333", "B.Kernighan, D.Ritchi", "C programming language")

        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string titlePart)
        {
            return books.Where(book => book.Author.Contains(titlePart) 
            || book.Title.Contains(titlePart)).ToArray();
        }
    }
}