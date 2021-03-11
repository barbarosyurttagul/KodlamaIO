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
            AddRentalCar();
            
            CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.GetCarDetails();

            //if (result.Success)
            //{
            //    foreach (var item in result.Data)
            //    {
            //        Console.WriteLine(item.CarBrand + item.Color + item.Model + item.Description);
            //    }
            //}


            //CarCRUDOps(carManager);
            //BrandCRUDOps();

            //AddCustomer();
            
        }

        private static void AddRentalCar()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            var result = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = null });
            Console.WriteLine(result.Message);
        }

        private static void AddCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(new Customer { UserId = 1, CompanyName = "ADESE" });
            Console.WriteLine(result.Message);
        }

        private static void BrandCRUDOps()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //Idsi 2 olan markayı getir


        }

        private static void CarCRUDOps(CarManager carManager)
        {
            var result = carManager.GetAll();

            if (result.Success)
            {
                Console.WriteLine(result.Message);
                foreach (var car in result.Data)
                {
                    Console.WriteLine($"Id: {car.Id}  BrandId: {car.BrandId}  ColorId: {car.ColorId}" +
                        $" Günlük Fiyat: {car.DailyPrice} Açıklama: {car.Description}");
                }
            }

        }
    }
}
