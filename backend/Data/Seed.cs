using System.Text.Json;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class Seed
    {
        public static async Task SeedCars(DContext context)
        {
            if(await context.Cars.AnyAsync()) return;
            var cardata= await File.ReadAllTextAsync("Data/cardetails.json");
            var options=new JsonSerializerOptions{PropertyNameCaseInsensitive=true};

            var cars=JsonSerializer.Deserialize<List<CarsClass>>(cardata);

            // foreach (var user in cars)
            // {
            //     user.BrandName=user.BrandName.ToLower();
            //     context.Cars.Add(user);
            // }
            await context.SaveChangesAsync();
        }
    }
}