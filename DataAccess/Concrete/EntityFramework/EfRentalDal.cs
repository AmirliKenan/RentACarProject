using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Entityframework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfRentalDal: EfEntityRepositoryBase<Rental, CarRentcontext>, IRentalDal
    {
    }
}
