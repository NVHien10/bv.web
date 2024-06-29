using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using Hospital.Models;


namespace Hospital.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }
            catch(Exception) 
            {
                throw;
            }
            if (!_roleManager.RoleExistsAsync(WebSiteRoles.Website_Admin).GetAwaiter().GetResult())
            {

                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Website_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Website_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebSiteRoles.Website_Doctor)).GetAwaiter().GetResult();

                _userManager.CreateAsync(new ApplicationUser
                {
                    UserName = "Hien",
                    Email = "hien@gmail.com"
                }, "Hien@123").GetAwaiter().GetResult();

                var Appuser = _context.ApplicationUsers.FirstOrDefault(x => x.Email == "hien@gmail.com");
                if (Appuser != null)
                {
                    _userManager.AddToRoleAsync(Appuser, WebSiteRoles.Website_Admin).GetAwaiter().GetResult();
                }
            }
      }
    }
}

