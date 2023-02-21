using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {          
            PlateauManager productManager = new PlateauManager(new InMemoryPlateauDal()) ;
            IDataResult<PlateauDetailDto>  result = productManager.WhereIsNow();
            //Robot's update dimension
            Console.WriteLine(result.Data.DimensionX + " , " + result.Data.DimensionY + " , " + result.Data.Direction);
        }
    }
}
