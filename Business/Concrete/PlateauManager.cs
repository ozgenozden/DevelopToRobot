using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PlateauManager : IPlateauService
    {
        IPlateauDal _plateauDal;
        public PlateauManager(IPlateauDal plateauDal)
        {
            _plateauDal = plateauDal;

        }
        public IResult Add(Plateau plateau)
        {
            _plateauDal.Add(plateau);
            return new SuccessResult("Success");
        }
        public IDataResult<List<Plateau>> GetAll()
        {
            return new DataResult<List<Plateau>>(null, true, "Plateau returned back");
        }
        public IDataResult<Plateau> GetById(int plateauId)
        {
            throw new NotImplementedException();
        }
        public IResult Update(Plateau plateau)
        {
            _plateauDal.Update(plateau);
            return new SuccessResult("Plateau updated");
        }
        public IDataResult<PlateauDetailDto> WhereIsNow()
        {
            //North => N  , South => S  , East => E  ' West => W
            int lineX = 1; //start dimensionX and update dimensionX
            int lineY = 1; //start dimensionY and update dimensionY
            string direction = "N"; //start direction
            

            var result = _plateauDal.GetAll(x=>x.PlateauId == 0).FirstOrDefault();
            var commandArray = result.Command.AsQueryable();

            for (int i = 0; i < commandArray.Count(); i++)
            {
                if (commandArray.ElementAt(i) == 'F')
                {
                     if (direction == "N")
                    {
                        if(result.DimensionY > lineY)
                        {
                            lineY = lineY + 1;
                        }
                    }
                     if (direction == "S")
                    {
                        if (lineY > 1)
                        {
                            lineY = lineY - 1;
                        }
                    }
                     if (direction == "E")
                    {
                        if (result.DimensionX > lineX)
                        {
                            lineX = lineX + 1;
                        }
                    }
                     if (direction == "W")
                    {
                        if (lineX > 1)
                        {
                            lineX = lineX - 1;
                        }
                    }
                }
                if (commandArray.ElementAt(i) != 'F')
                {
                    if(direction == "N")
                    {
                        if(commandArray.ElementAt(i) == 'R')
                            direction = "E";
                        if (commandArray.ElementAt(i) == 'L')
                            direction = "W";
                    }
                    else if (direction == "S")
                    {
                        if (commandArray.ElementAt(i) == 'R')
                            direction = "W";
                        if (commandArray.ElementAt(i) == 'L')
                            direction = "E";
                    }
                    else if (direction == "E")
                    {
                        if (commandArray.ElementAt(i) == 'R')
                            direction = "S";
                        if (commandArray.ElementAt(i) == 'L')
                            direction = "N";
                    }
                    else //(direction == "W")
                    {
                        if (commandArray.ElementAt(i) == 'R')
                            direction = "N";
                        if (commandArray.ElementAt(i) == 'L')
                            direction = "S";
                    }
                }
            
            }
            return new SuccessDataResult<PlateauDetailDto>(new PlateauDetailDto
            {
                DimensionX = lineX,
                DimensionY = lineY,
                Direction = direction
            });
           
        }
    }
}
