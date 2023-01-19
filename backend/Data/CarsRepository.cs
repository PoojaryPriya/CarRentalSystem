using System.Data.Entity;
using backend.Entities;
using backend.interfaces;

namespace backend.Data
{
    public class CarsRepository : ICarRepository
    {
        private readonly DContext _context;
        public CarsRepository(DContext context)
        {
            _context = context;
            
        }
        public async Task<CarsClass> GetCarByCarName(string brandname)
        {
            return await _context.Cars.SingleOrDefaultAsync(x=>x.BrandName==brandname);
        }

        public async Task<CarsClass> GetCarById(int carid)
        {
            return await _context.Cars.FindAsync(carid);
        }

        public Task<IEnumerable<CarsClass>> GetCarsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(CarsClass cars)
        {
            throw new NotImplementedException();
        }
    }
}