using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Web.Models.ConnectionTools;

namespace CMS.Web.Services
{
    public interface IAdminService
    {
        bool login(string email, string password);
        bool ChangePassword(string email, string password);
        bool ForgetPassword(string password);
    }

    public class AdminService : IAdminService
    {
        public static CmsContext Context { get; set; }

        public AdminService()
        {
            Context = new CmsContext();
        }

        public bool login(string email, string password)
        {
            // ReSharper disable once ReplaceWithSingleCallToAny
            return Context.Admins
                 .Where(d => d.Email == email && d.Password == password)
                 .Any();
        }

        public bool ChangePassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool ForgetPassword(string password)
        {
            throw new NotImplementedException();
        }
    }

}