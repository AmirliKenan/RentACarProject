using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
  public  interface ICarService
    {

        public IDataResult<List<Car>> GetAll();
        public IResult Add(Car car);
        public IResult Update(Car car);
        public IResult Delete(Car car);
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        public IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByDailyPrice(int min,int max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int carId);
    }
}
