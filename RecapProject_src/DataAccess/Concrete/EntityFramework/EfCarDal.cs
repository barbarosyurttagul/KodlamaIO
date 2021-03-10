using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join br in context.Brands on c.BrandId equals br.Id into a1
                             from br in a1.DefaultIfEmpty()
                             join co in context.Colors on c.ColorId equals co.Id into b1                            
                             from co in b1.DefaultIfEmpty()
                             select new CarDetailDTO
                             {
                                 CarBrand = br.Name,
                                 Color = co.Name,
                                 Model = c.ModelYear,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
