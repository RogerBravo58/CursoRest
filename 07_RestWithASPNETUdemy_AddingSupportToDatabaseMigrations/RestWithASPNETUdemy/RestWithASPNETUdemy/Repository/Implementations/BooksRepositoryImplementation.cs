using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations {
    public class BooksRepositoryImplementation : IBooksRepository {

        private MySQLContext _context;

        public BooksRepositoryImplementation(MySQLContext context) {
            _context = context;
        }

        // Method responsible for returning all people,
        public List<Books> FindAll() {
            return _context.Books.ToList();
        }

        // Method responsible for returning one books by ID
        public Books FindByID(long id) {
            return _context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        // Method responsible to crete one new books
        public Books Create(Books books) {
            try {
                _context.Add(books);
                _context.SaveChanges();
            } catch (Exception) {
                throw;
            }
            return books;
        }

        // Method responsible for updating one books
        public Books Update(Books books) {
            // We check if the books exists in the database
            // If it doesn't exist we return an empty books instance
            if (!Exists(books.Id)) return null;

            // Get the current status of the record in the database
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(books.Id));
            if (result != null) {
                try {
                    // set changes and save
                    _context.Entry(result).CurrentValues.SetValues(books);
                    _context.SaveChanges();
                } catch (Exception) {
                    throw;
                }
            }
            return books;
        }

        // Method responsible for deleting a books from an ID
        public void Delete(long id) {
            var result = _context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null) {
                try {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                } catch (Exception) {
                    throw;
                }
            }
        }
        public bool Exists(long id) {
            return _context.Books.Any(p => p.Id.Equals(id));
        }
    }
}
