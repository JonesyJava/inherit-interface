using System.Collections.Generic;
using vacay.Interface;
using vacay.Repositories;

namespace vacay.Services
{
    public class VacationServices
    {
        private readonly VacationRepository _repo;

        public VacationServices(VacationRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<IPurchasable> getAll()
        {
            return _repo.GetAll();
        }
    }
}