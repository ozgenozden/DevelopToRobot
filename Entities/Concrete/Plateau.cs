using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Plateau:IEntity
    {
        public int PlateauId { get; set; }
        public string Command { get; set; }
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
    }
}
