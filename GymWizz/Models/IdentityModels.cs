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

        // Abs workouts
        public bool LegRaises { get; set; }
        public bool SitUps { get; set; }
        public bool AbBikes { get; set; }
        public bool SitUpTouchingKnees { get; set; }
        public bool PlankFromKnees { get; set; }

        // Arms workouts
        public bool BarbellCurls { get; set; }
        public bool CloseGripBarbellBenchPress { get; set; }
        public bool MachinePreacherCurls { get; set; }

        // Leg workouts
        public bool LegExtension { get; set; }
        public bool DumbellWalkingLunge { get; set; }
        public bool StandingCalfRaises { get; set; }
        public bool Squat { get; set; }

        // Chest workouts
        public bool InclineDumbbell { get; set; }
        public bool BenchPress { get; set; }
        public bool Flying { get; set; }

        // total body
        public bool TotalBody { get; set; }
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