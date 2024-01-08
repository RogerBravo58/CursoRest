using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.Business.Implementations {
    public class BooksBusinessImplementation : IBooksBusiness {

        private readonly IBooksRepository _repository;

        public BooksBusinessImplementation(IBooksRepository repository) {
            _repository = repository;
        }

        // Method responsible for returning all people,
        public List<Books> FindAll() {
            return _repository.FindAll();
        }

        // Method responsible for returning one books by ID
        public Books FindByID(long id) {
            return _repository.FindByID(id);
        }

        // Method responsible to crete one new books
        public Books Create(Books books) {
             
            return _repository.Create(books); 

        }

        // Method responsible for updating one books
        public Books Update(Books books) {
       
            return _repository.Update(books);
        }

        // Method responsible for deleting a books from an ID
        public void Delete(long id) {
            _repository.Delete(id);
        }

    }
}
