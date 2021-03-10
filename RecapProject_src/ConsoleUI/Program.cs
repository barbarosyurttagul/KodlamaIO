using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarBrand + item.Color + item.Model + item.Description);
            }
            //CarCRUDOps(carManager);
            //BrandCRUDOps();
        }

        private static void BrandCRUDOps()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Idsi 2 olan markayı getir
            var brandId2 = brandManager.GetById(2);
            Console.WriteLine(brandId2.Id + "-" + brandId2.Name);

            brandManager.Add(new Brand { Name = "Fiat" });
            brandManager.Update(new Brand { Id = 1, Name = "Hyundai" });
            var brandtoDelete = brandManager.GetById(3);
            brandManager.Delete(brandtoDelete);
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + brand.Name);
            }
        }

        private static void CarCRUDOps(CarManager carManager)
        {
            //Idsi 2 olan arabayı getir
            var carId2 = carManager.GetById(2);
            Console.WriteLine(carId2.BrandId + "-" + carId2.DailyPrice);

            carManager.Add(new Car { BrandId = 3, ColorId = 2, ModelYear = 1999, DailyPrice = 2000, Description = "beles" });
            carManager.Update(new Car { Id = 1, BrandId = 2 });
            var cartoDelete = carManager.GetById(4);
            carManager.Delete(cartoDelete);
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + "-" + car.BrandId + "-" + car.ColorId + "-" + car.ModelYear + "-" + car.DailyPrice + "-" + car.Description);
            }
        }
    }
}
