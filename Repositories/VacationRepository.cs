using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay.Models;

namespace vacay.Repositories
{
    public class VacationRepository
    {
        private readonly IDbConnection _db;
        public VacationRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Vacation> GetAll()
        {
            string sql = @"SELECT
            trip.description,
            trip.destination,
            trip.price,
            trip.id FROM trip
            UNION SELECT
            cruise.description,
            cruise.destination,
            cruise.price,
            cruise.id FROM cruise;";
            return _db.Query<Vacation>(sql);
        }
    }
}