using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using FastMarket.Data;
using FastMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FastMarketTestData
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly FastMarketDBContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new FastMarketDBContext(
                new DbContextOptionsBuilder<FastMarketDBContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }
        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }

    }
}