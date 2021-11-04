using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public EfRentalDal _efRentalDal;
        public EfCarDal _efCarDal;
        public EfBrandDal _efBrandDal;
        public EfColorDal _efColorDal;
        public EfCustomerDal _efCustomerDal;
        public EfUserDal _efUserDal;
        public IRentalDal rentalDal => _efRentalDal ?? new EfRentalDal();

        public ICarDal carDal => _efCarDal ?? new EfCarDal();

        public IBrandDal brandDal => _efBrandDal ?? new EfBrandDal();

        public ICustomerDal customerDal => _efCustomerDal ?? new EfCustomerDal();

        public IColorDal colorDal => _efColorDal ?? new EfColorDal();

        public IUserDal userDal => _efUserDal ?? new EfUserDal();
    }
}
