using BookShop;

namespace ShopMemory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book (1, "ISBN 11111-11111", "D.Knuth",  "Art of programming", 
                "This volume begins with basic concept and technology", 7.19m),
            new Book (2, "ISBN 22222-22222", "M.Fowler",  "Refactoring", "As the " +
                "application of object technology--particulary Java...", 12.45m),
            new Book (3, "ISBN 33333-33333", "B.Kernighan, D.Ritchi", "C programming language", 
                "Known as the bible of C, this classic bestseller introduce ...", 14.98m)

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

        public Book GetById(int id)
        {
            return books.Single(book => book.Id == id);
        }

        public Book[] GetAllByIds(IEnumerable<int> bookIds)
        {
            var foundBooks = from book in books
                             join bookId in bookIds on book.Id equals bookId 
                             select book;   
            return foundBooks.ToArray();
        }
    }
}