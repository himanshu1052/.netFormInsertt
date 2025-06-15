using DAL;
using BOL;

namespace BLL
{
    public class UserBLL
    {
        UserDAL dal = new UserDAL();

        public void AddUser(BOL.User user)
        {
            // Create a DAL.User and map BOL.User properties
            DAL.User newUser = new DAL.User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobileNo = user.MobileNo,
                DOB = user.DOB,
                AddressLine1 = user.AdressLine1,
                AddressLine2 = user.AdressLine2,
                PinCode = user.PinCode,
                Country = user.Country,
                State = user.State,
                District = user.District,
                City = user.City,
                Area = user.Area,
                AadharNo = user.AdharNo,
                Qualification = user.Qualification,
                PhotoPath = user.PhotoPath
            };

            dal.Insertuser(newUser);
        }

    }
}
