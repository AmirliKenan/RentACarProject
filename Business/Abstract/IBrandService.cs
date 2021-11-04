using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
  public  interface IBrandService
    {
        public IDataResult<List<Brand>> GetAll();
        public IDataResult<Brand> GetById(int brandId);
        public IResult Add(Brand brand);
        public IResult Update(Brand brand);
        public IResult Delete(Brand brand);



    }
}
