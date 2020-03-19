using FieldGroupProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FieldGroupProject.Startup))]
namespace FieldGroupProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        public void CreateRolesandUsers()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
           

            if (!roleManager.RoleExists("Admin"))
            {
                //Admin row in Database
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@delivery.com",
                    PasswordHash = "Admin123$"
                };

                var usr = userManager.Create(user);

                if (usr.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);               
            }//end Admin row

            //Restaurant User Role
            
            if (!roleManager.RoleExists("Restaurant"))
            {
                var role = new IdentityRole();
                role.Name = "Restaurant";
                roleManager.Create(role);

                var ruser = new ApplicationUser
                {
                    UserName = "restaurant1",
                    Email = "restaurant@delivery.com",
                    PasswordHash = "Restaurant123$"
            };

              

                var rusr = userManager.Create(ruser);

                if (rusr.Succeeded)
                {
                    var result = userManager.AddToRole(ruser.Id, "Restaurant");
                }

            }


            if (!roleManager.RoleExists("Rider"))
            {

                var role = new IdentityRole();
                role.Name = "Rider";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);

            }
        }
    }
}
