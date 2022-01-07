using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ECommerceContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail(int rentalId)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                var result = from c in context.Users
                             join r in context.Rentals
                             on c.ID equals r.CustomerID
                             where r.ID == rentalId
                             select new RentalDetailDto {CarID=r.CarID, FirstName=c.FirstName, LastName=c.LastName, RentDate=r.RentDate,ReturnDate=r.ReturnDate };
                return result.ToList();
            }
        }
    }
}
