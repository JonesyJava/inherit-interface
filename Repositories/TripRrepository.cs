using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay.Models;

namespace vacay.Repositories
{
    public class TripRepository
    {
        public readonly IDbConnection _db;

        public TripRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Trip> Get()
        {
            string sql = "SELECT * FROM trip;";
            return _db.Query<Trip>(sql);
        }

        internal Trip Get(int Id)
        {
            string sql = "SELECT * FROM trip WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Trip>(sql, new { Id });
        }
        internal Trip Create(Trip newTrip)
        {
            string sql = @"
        INSERT INTO trip
        (description, destination, price)
        VALUES
        (@Description, @Destination, @Price);
        SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newTrip);
            newTrip.Id = id;
            return newTrip;
        }
        internal Trip Edit(Trip tripToEdit)
        {
            string sql = @"
        UPDATE trip
        SET
            description = @Description,
            destination = @Destination,
            price = @Price
        WHERE id = @Id;
        SELECT * FROM trip WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Trip>(sql, tripToEdit);
        }
        internal void Delete(int id)
        {
            string sql = "DELETE FROM trip WHERE id = @Id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}