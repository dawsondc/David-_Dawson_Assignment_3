﻿using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    public class DbGameRepository : IGameRepository
    {
        private readonly GameDbContext _db;

        public DbGameRepository(GameDbContext db)
        {
            _db = db;
        }
        public Game? Read(int ID)
        {
            return _db.Game
           .Include(x => x.PersonRating)
              .ThenInclude(y => y.Person)
           .FirstOrDefault(x => x.gameID == ID);
        }

        public ICollection<Game> ReadAll()
        {
            return _db.Game
           .Include(x => x.PersonRating)
              .ThenInclude(y => y.Person)
              .ToList();
        }
    }
}
