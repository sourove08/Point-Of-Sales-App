using System.Data.Entity;
using POS.Models;
using POS.Models.Database;
using POS.Models.Interfaces;

namespace POS.DAL
{
    public class StockRepository:CommonRepository<StockHeader>,IStockRepository
    {
        public StockRepository() : base(new PosDbContext())
        {
        }

        public StockRepository(DbContext db) : base(db)
        {
            
        }
    }
}