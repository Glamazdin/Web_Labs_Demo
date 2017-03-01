using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;

namespace WebLabs_V2.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            userIdentity.AddClaim(new Claim("nick", this.NickName));
            return userIdentity;
            
        }

        public string NickName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IdentityConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            var context=new ApplicationDbContext();
            CheckRoles(context);

            return context;
        }

        static  void CheckRoles(ApplicationDbContext context)
        {
            // Создаем менеджеры ролей и пользователей
            RoleManager<IdentityRole> roleManager = 
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager = 
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            IdentityRole roleAdmin, roleUser = null;
            ApplicationUser userAdmin = null;

            // поиск роли admin
            roleAdmin =  roleManager.FindByName("admin");
            if (roleAdmin == null)
            {
                // создаем, если на нашли
                roleAdmin = new IdentityRole { Name = "admin" };
                var result = roleManager.Create(roleAdmin);
            }

            // поиск роли user
            roleUser = roleManager.FindByName("user");
            if (roleUser == null)
            {
                // создаем, если на нашли
                roleUser = new IdentityRole { Name = "user" };
                var result = roleManager.Create(roleUser);
            }

            // поиск пользователя admin@mail.ru
            userAdmin = userManager.FindByEmail("admin@mail.ru");
            if (userAdmin == null)
            {
                // создаем, если на нашли
                userAdmin = new ApplicationUser { NickName = "admin", Email = "admin@mail.ru",UserName= "admin@mail.ru" };
                userManager.Create(userAdmin, "123456");
                // добавляем к роли admin
                userManager.AddToRole(userAdmin.Id, "admin");
            }
        }
    }
}