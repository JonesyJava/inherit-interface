using System;
using System.Collections.Generic;
using vacay.Models;
using vacay.Repositories;

namespace vacay.Services
{
    public class TripsServices
    {
        private readonly TripRepository _repo;

        public TripsServices(TripRepository repo)
        {
            _repo = repo;
        }
        internal IEnumerable<Trip> Get()
        {
            return _repo.Get();
        }
        internal Trip Get(int id)
        {
            Trip trip = _repo.Get(id);
            if (trip == null)
            {
                throw new Exception("invalid id");
            }
            return trip;
        }
        internal Trip Create(Trip newTrip)
        {
            return _repo.Create(newTrip);
        }
        internal Trip Edit(Trip editTrip)
        {
            Trip original = Get(editTrip.Id);
            original.Description = editTrip.Description != null ? editTrip.Description : original.Description;
            original.Destination = editTrip.Destination != null ? editTrip.Destination : original.Destination;

            original.Price = editTrip.Price != null ? editTrip.Price : original.Price;
            return _repo.Edit(original);
        }
        internal Trip Delete(int id)
        {
            Trip original = Get(id);
            _repo.Delete(id);
            return original;
        }
    }
}