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
    public class ColorManager : IColorService
    {

        private IUnitOfWork _unitOfWork;

        public ColorManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IResult Add(Color color)
        {
            _unitOfWork.colorDal.Add(color);
            return new SuccessResult("Color added sucessfully");
        }

        public IResult Delete(Color color)
        {
            var deletedColor = _unitOfWork.colorDal.Get(c => c.Id == color.Id);
            _unitOfWork.colorDal.Delete(deletedColor);
            return new SuccessResult("Color deleted successfully");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_unitOfWork.colorDal.GetAll(), "All colors fetched");
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_unitOfWork.colorDal.Get(c => c.Id == id),"Color getted");
        }

        public IResult Update(Color color)
        {
            var updatedColor = _unitOfWork.colorDal.Get(c => c.Id == color.Id);
            updatedColor.Name = color.Name;
            _unitOfWork.colorDal.Update(updatedColor);
            return new SuccessResult("Color updated successfully");
        }
    }
}
