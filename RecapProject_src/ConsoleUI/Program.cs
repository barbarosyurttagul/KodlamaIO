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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine($"Car ID:{car.Id}, Brand ID: {car.BrandId}, Color ID: {car.ColorId}, Model Year: {car.ModelYear}, Daily Price: {car.DailyPrice}, Description: {car.Description}");
            //}

            brandManager.Add(new Brand { Name = "ab" }); //Id'yi SQLServer otomatik atıyor, hata vermeden eklendi
            brandManager.Add(new Brand { Name = "a" });  // 2 karakterden az olduğu için hata mesajı verdi.
        }
    }
}
