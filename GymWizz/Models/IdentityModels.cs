using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GymWizz.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FirstName", this.FirstName));
            userIdentity.AddClaim(new Claim("LastName", this.LastName));
            userIdentity.AddClaim(new Claim("IsGoing", this.IsGoing ? "true" : "false"));
            userIdentity.AddClaim(new Claim("GoingTime", this.GoingTime.ToString()));
            userIdentity.AddClaim(new Claim("LeavingTime", this.LeavingTime.ToString()));
            userIdentity.AddClaim(new Claim("GymId", this.GymId.ToString()));
            return userIdentity;
        }
        // Extened property
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsGoing { get; set; }
        public int GoingTime { get; set; }
        public int LeavingTime { get; set; }
        public int GymId { get; set; }
        public bool GetAlarm { get; set; }
        
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}