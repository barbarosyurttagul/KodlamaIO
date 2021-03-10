using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDTO : IDto
    {
        //CarName, BrandName, ColorName, DailyPrice

        public string CarBrand { get; set; }
        public string Color { get; set; }
        public int Model { get; set; }
        public string Description { get; set; }

    }
}
