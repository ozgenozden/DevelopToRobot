using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{


    public class InMemoryPlateauDal : IPlateauDal
        {
            List<Plateau> _plateaus;
            public InMemoryPlateauDal()
            {
               _plateaus = new List<Plateau>
               {
                new Plateau{PlateauId=0,DimensionX=5,DimensionY=5,Command="FFRFLFLF" },
                //new Plateau{PlateauId=0,DimensionX=5,DimensionY=5,Command="FFLFFLFFF" },            
               };
            }

            public void Add(Plateau product)
            {
            _plateaus.Add(product);
            }

            public void Delete(Plateau product)
            {

            _plateaus.Remove(_plateaus.SingleOrDefault(x => x.PlateauId.Equals(product.PlateauId)));
            }
            public void Update(Plateau plateau)
            {

            var updatePlateau = _plateaus.SingleOrDefault(x => x.PlateauId.Equals(plateau.PlateauId));
            updatePlateau.DimensionX = plateau.DimensionX;
            updatePlateau.DimensionY = plateau.DimensionY;
            updatePlateau.Command = plateau.Command;
             
            } 
            public List<Plateau> GetAll(Expression<Func<Plateau, bool>> filter = null)
            {

                return _plateaus.Where(filter.Compile()).ToList();
            }

            public Plateau Get(Expression<Func<Plateau, bool>> filter)
            {
                throw new NotImplementedException();
            }

            
        }
    }

