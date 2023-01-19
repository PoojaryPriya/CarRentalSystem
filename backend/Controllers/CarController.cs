using backend.Data;
using backend.DTOs;
using backend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    public class CarController : BaseApiController
    {
        private readonly DContext _context;
        public CarController(DContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            var cars= await _context.Cars.ToListAsync();
            var carlist = new List<CarDto>();
            foreach(var car in cars)
            {
                carlist.Add(new CarDto
                {
                    CarId=car.CarId,
                    Brandname=car.BrandName,
                    Description=car.Description,
                    DailyPrice=car.DailyPrice,
                    IsRentable=car.IsRentable

                });
            }
            return carlist;
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<CarsClass>> GetCarById(int id)
        {
            var cars = await _context.Cars.FindAsync(id);
            if (cars != null)
            {
                return cars;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("addcars")]
        public async Task<ActionResult<CarDto>> AddCar(CarDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var car = _context.Cars.FirstOrDefault(x => x.BrandName == model.Brandname);
            if (car != null)
            {
                return Conflict();
            }
            car = new CarsClass();
            car.BrandName=model.Brandname;
            car.Description=model.Description;
            car.DailyPrice=model.DailyPrice;
            car.IsRentable=model.IsRentable;
            _context.Cars.Add(car);
            var result= await _context.SaveChangesAsync();
            model.CarId=car.CarId;
            return model;
        }

        [HttpPost("editcar")]
        public async Task<ActionResult<CarsClass>> UpdateCar(CarDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var car = _context.Cars.FirstOrDefault(x => x.CarId == model.CarId);
            if (car == null)
            {
                return NotFound();
            }

            car.BrandName = model.Brandname;
            car.Description = model.Description;
            car.DailyPrice = model.DailyPrice;
            car.IsRentable = model.IsRentable;
            await _context.SaveChangesAsync();
            return car;
        }
    }
}