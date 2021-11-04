using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
  public  interface IUnitOfWork
    {
        public IRentalDal rentalDal { get; }
        public ICarDal carDal { get; }
        public IBrandDal brandDal { get; }
        public ICustomerDal customerDal { get; }
        public IColorDal colorDal { get; }
        public IUserDal userDal { get; }
    }
}
