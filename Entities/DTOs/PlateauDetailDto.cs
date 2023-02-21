using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PlateauDetailDto : IDto
    { 
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public string Direction { get; set; }
     
    }
}
