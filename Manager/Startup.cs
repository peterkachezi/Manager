using Manager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Manager.Startup))]
namespace Manager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            createRolesandUsers();
        }


        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Administrator"))
            {
                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";
                user.PhoneNumber = "0704509484";
                user.FirstName = "Mr";
                user.LastName = "Admin";
                user.EmailConfirmed = true;

                string userPWD = "Admin@2021";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Administrator");

                }

            }

            // creating Creating Manager role     
            if (!roleManager.RoleExists("Receptionist"))
            {
                var role = new IdentityRole();
                role.Name = "Receptionist";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                user.UserName = "receptionist@gmail.com";
                user.Email = "receptionist@gmail.com";
                user.PhoneNumber = "0704509484";
                user.FirstName = "Mr";
                user.LastName = "Receptionist";
                user.EmailConfirmed = true;

                string userPWD = "Admin@2021";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Receptionist");

                }

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Librarian"))
            {
                var role = new IdentityRole();
                role.Name = "Librarian";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                {
                    user.UserName = "librarian@gmail.com";
                    user.Email = "librarian@gmail.com";
                    user.PhoneNumber = "0704509484";
                    user.FirstName = "Mr";
                    user.LastName = "Librarian";
                    user.EmailConfirmed = true;
                }

                string userPWD = "Admin@2021";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Librarian");

                }

            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Teacher"))
            {
                var role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);

                var user = new ApplicationUser();
                {
                    user.UserName = "teacher@gmail.com";
                    user.Email = "teacher@gmail.com";
                    user.PhoneNumber = "0704509484";
                    user.FirstName = "Mr";
                    user.LastName = "Teacher";
                    user.EmailConfirmed = true;
                }

                string userPWD = "Admin@2021";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Teacher");

                }



            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Accountant"))
            {
                var role = new IdentityRole();
                role.Name = "Accountant";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                   

                var user = new ApplicationUser();
                {
                    user.UserName = "accountant@gmail.com";
                    user.Email = "accountant@gmail.com";
                    user.PhoneNumber = "0704509484";
                    user.FirstName = "Mr";
                    user.LastName = "Accountant";
                    user.EmailConfirmed = true;
                }

                string userPWD = "Admin@2021";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Accountant");

                }


            }

            // creating Creating Employee role     
            if (!roleManager.RoleExists("Parent"))
            {
                var role = new IdentityRole();
                role.Name = "Parent";
                roleManager.Create(role);

                var user = new ApplicationUser();
                {
                    user.UserName = "parent@gmail.com";
                    user.Email = "parent@gmail.com";
                    user.PhoneNumber = "0704509484";
                    user.FirstName = "Mr";
                    user.LastName = "Parent";
                    user.EmailConfirmed = true;
                }

                string userPWD = "Admin@2021";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Parent");

                }

            }


        }
    }
}
