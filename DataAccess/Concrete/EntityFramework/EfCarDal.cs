using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Entityframework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentcontext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentcontext context = new CarRentcontext()) 
            {
                var result = from c in context.Cars
                             join b in context.Brands on
                             c.BrandId equals b.Id join
                            co in context.Colors on
                            c.ColorId equals co.Id

                             select new CarDetailDto
                             {
                                 CarName=c.Name,
                                 BrandName=b.Name,
                                 DailyPrice=c.DailyPrice,
                                 ColorName=co.Name
                                 

                             };
                return result.ToList();
            
            }
        }
    }
}
