using backend.Entities;

namespace backend.interfaces
{
    public interface ICarRepository
    {
        void Update(CarsClass cars);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<CarsClass>> GetCarsAsync();
        Task<CarsClass> GetCarById(int carid);
        Task<CarsClass> GetCarByCarName(string brandname);
    }
}