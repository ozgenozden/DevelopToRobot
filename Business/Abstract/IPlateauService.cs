using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPlateauService
    {
        IDataResult<PlateauDetailDto> WhereIsNow();
        IDataResult<List<Plateau>> GetAll();
        IDataResult<Plateau> GetById(int plateauId);
        IResult Add(Plateau plateau);
        IResult Update(Plateau plateau);
    }
}
