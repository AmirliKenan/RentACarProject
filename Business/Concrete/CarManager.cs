using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
 public   class CarManager:ICarService
    {
       private IUnitOfWork _unitOfWork;


        public CarManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0 && car.Name.Length > 2)
            {
                _unitOfWork.carDal.Add(car);
                return new SuccessResult("Car added succesfully");
            }
            else 
            {
                return new ErrorResult("Something went wrong");
            }
        }

        public IResult Delete(Car car)
        {
            var delCar = _unitOfWork.carDal.Get(c => c.Id == car.Id);

            _unitOfWork.carDal.Delete(delCar);
            return new SuccessResult("Car deleted successfully");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_unitOfWork.carDal.GetAll(), "All cars listed");
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_unitOfWork.carDal.Get(c => c.Id == carId),"Car getted");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_unitOfWork.carDal.GetCarDetails(),"All special cars listed");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
         return new SuccessDataResult<List<Car>>(_unitOfWork.carDal.GetAll(c => c.BrandId == brandId),"Cars getted with brands");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_unitOfWork.carDal.GetAll(c => c.ColorId == colorId),"Cars getted with colors");
        }
        public IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_unitOfWork.carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max),"All cars listed with price");
        }

        public IResult Update(Car car)
        {
            var delCar = _unitOfWork.carDal.Get(c => c.Id == car.Id);
            delCar.BrandId = car.BrandId;
            delCar.ColorId = car.ColorId;
            delCar.DailyPrice = car.DailyPrice;
            delCar.Description = car.Description;
            delCar.ModelYear = car.ModelYear;
            delCar.Name = car.Name;
            _unitOfWork.carDal.Update(delCar);
            return new SuccessResult("Car updated");

        }
    }
}
