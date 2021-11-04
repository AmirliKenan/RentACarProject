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

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IUnitOfWork _unitOfWork;

        public BrandManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IResult Add(Brand brand)
        {
            if (brand.Name.Length > 2)
            {
               _unitOfWork.brandDal.Add(brand);
                return new SuccessResult("Brand added successfully");
            }
            else {
                return new ErrorResult(message: "Minimum length is 2");
            }
        }

        public IResult Delete(Brand brand)
        {
            var deletedBrand =_unitOfWork.brandDal.Get(b => b.Id == brand.Id);
            _unitOfWork.brandDal.Delete(deletedBrand);
            return new SuccessResult("Brand deleted");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_unitOfWork.brandDal.GetAll(), "Brands listed");
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var brand = _unitOfWork.brandDal.Get(b => b.Id == brandId);
            return new SuccessDataResult<Brand>(brand, "Brand getted");
        }

        public IResult Update(Brand brand)
        {
            var updatedBrand = _unitOfWork.brandDal.Get(b => b.Id == brand.Id);
            updatedBrand.Name = brand.Name;
            _unitOfWork.brandDal.Update(updatedBrand);
            return new SuccessResult("Brand updated");
        }
    }
}
