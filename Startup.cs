using Job_search.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Job_search.Startup))]
namespace Job_search
{

    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }
        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
            }
            ApplicationUser user = new ApplicationUser();
            user.UserName = "Bilal";
            user.Email = "belal1993@gmail.com";
            var check = userManager.Create(user, "Zxc1234@");
            if (check.Succeeded)
            {
                userManager.AddToRole(user.Id, "Admins");
            }
        }
    }
}

