using System;
using Xunit;
using Business.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using DataAccess.Concrete.InMemory;

namespace DevelopToRobot
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            PlateauManager productManager = new PlateauManager(new InMemoryPlateauDal());
            IDataResult<PlateauDetailDto> result = productManager.WhereIsNow();

            Assert.Equal("", productManager.WhereIsNow().Data.DimensionX+","+ productManager.WhereIsNow().Data.DimensionY + ","
                        + productManager.WhereIsNow().Data.Direction);
        }
    }
}
