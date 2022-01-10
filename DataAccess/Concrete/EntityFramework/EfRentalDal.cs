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
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                var result = from c in context.Users
                             join r in context.Rentals
                             on c.ID equals r.CustomerID
                             select new RentalDetailDto {RentalId=r.ID,UserId=c.ID, CarID=r.CarID, FirstName=c.FirstName, LastName=c.LastName, RentDate=r.RentDate,ReturnDate=r.ReturnDate };
                return result.ToList();
            }
        }
        public RentalDetailDto GetRentalDetailById(int userId)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                var result = from c in context.Users
                             join r in context.Rentals
                             on c.ID equals r.CustomerID
                             select new RentalDetailDto { RentalId = r.ID, UserId = c.ID, CarID = r.CarID, FirstName = c.FirstName, LastName = c.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };
                return result.SingleOrDefault(r=> r.UserId==userId);
            }
        }


    }
}
