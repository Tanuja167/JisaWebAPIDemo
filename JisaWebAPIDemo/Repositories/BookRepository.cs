using JisaWebAPIDemo.Data;
using JisaWebAPIDemo.Models;

using JisaWebAPIDemo.Models;

namespace JisaWebAPIDemo.Repositories
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext db;

        public BookRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int AddBook(Book book)
        {
             db.Books.Add(book);
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteBook(int id)
        {
            int res = 0;
            var result = db.Books.Where(x => x.Id == id).FirstOrDefault();
            if(result != null)
            {
                db.Books.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }

        public Book GetBookById(int id)
        {
            var result = db.Books.Where(x => x.Id == id).SingleOrDefault();
            return result;
        }

        public IEnumerable<Book> GetBooks()
        {
            var result = from b in db.Books
                         select b;
            return result;
        }

        public int UpdateBook(Book book)
        {
            int res = 0;
            var result = db.Books.Where(x => x.Id == book.Id).FirstOrDefault();

            if (result != null)
            {
                result.Name = book.Name; // book contains new data, result contains old data
                result.Author = book.Author;
                result.Price = book.Price;

                res = db.SaveChanges();// update those changes in DB
            }

            return res;
        }
    }
}
