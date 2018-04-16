using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GymWizz.Extensions;
using GymWizz.Models;
using GymWizz.Utils;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace GymWizz.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Main()
        {
            var email = User.Identity.Name;
            var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(store);
            var currentUser = manager.FindByEmail(User.Identity.Name);

            ViewBag.FirstName = currentUser.FirstName;
            ViewBag.LastName = currentUser.LastName;
            ViewBag.IsGoing = currentUser.IsGoing ? "true" : "false";
            ViewBag.GetAlarm = currentUser.GetAlarm ? "true" : "false";
            ViewBag.GoingTime = currentUser.GoingTime;
            ViewBag.LeavingTime = currentUser.LeavingTime;
            ViewBag.GymName = Gym.Gyms[currentUser.GymId].Name;

            ViewBag.GoingTimes = new SelectList(GoingTime.GoingTimes, "Id", "Name");
            ViewBag.LeavingTimes = new SelectList(LeavingTime.LeavingTimes, "Id", "Name");

            //var db = new ApplicationUserManager
            ApplicationDbContext context = new ApplicationDbContext();
            var users = context.Users.ToList();
            var count = 0;
            var sameCount = 0;
            var userCountInTime = new int[12];
            for (int i = 0; i < 12; i++) userCountInTime[i] = 0;
            foreach (var user in users)
            {
                if (user.IsGoing && user.GymId == currentUser.GymId)
                {
                    // people in the gym current time
                    var hour = DateTime.Now.Hour;
                    if(user.GoingTime + 12 <= hour && hour < user.LeavingTime + 12)
                    {
                        count++;
                    }
                    // people who have same plan
                    if(user.GoingTime == currentUser.GoingTime && user.LeavingTime == currentUser.LeavingTime)
                    {
                        sameCount++;
                    }
                    // people in every landmark of time
                    for (int i = user.GoingTime; i < user.LeavingTime; i++)
                    {
                        userCountInTime[i]++;
                    }
                }
            }
            var listOfTimesOfAlarm = new List<int>();
            for (int i = 0; i < 12; i++)
            {
                if(userCountInTime[i] >= 5)
                {
                    listOfTimesOfAlarm.Add(i + 12);
                }
            }

            ViewBag.NumberOfPeople = count;
            ViewBag.NumberWithSamePlan = sameCount;
            ViewBag.AlarmTimes = listOfTimesOfAlarm;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Main(MainViewModel model)
        {
            if(ModelState.IsValid)
            {
                var email = User.Identity.Name;
                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(store);
                var currentUser = manager.FindByEmail(User.Identity.Name);
                currentUser.IsGoing = model.IsGoing;
                currentUser.GoingTime = model.GoingTime;
                currentUser.LeavingTime = model.LeavingTime;
                currentUser.GetAlarm = model.GetAlarm;

                await manager.UpdateAsync(currentUser);
                var ctx = store.Context;
                ctx.SaveChanges();

                return RedirectToAction("Main");

                //ViewBag.FirstName = currentUser.FirstName;
                //ViewBag.LastName = currentUser.LastName;
                //ViewBag.IsGoing = currentUser.IsGoing;
                //ViewBag.GoingTime = currentUser.GoingTime;
                //ViewBag.LeavingTime = currentUser.LeavingTime;
                //ViewBag.GymName = User.Identity.GetGymName();

                //ViewBag.GoingTimes = new SelectList(GoingTime.GoingTimes, "Id", "Name");
                //ViewBag.LeavingTimes = new SelectList(LeavingTime.LeavingTimes, "Id", "Name");

                ////var db = new ApplicationUserManager
                //ApplicationDbContext context = new ApplicationDbContext();
                //var users = context.Users.ToList();
                //var count = 0;
                //foreach (var user in users)
                //{
                //    if (user.IsGoing && user.GymId == User.Identity.GetGymId())
                //    {
                //        var hour = DateTime.Now.Hour;
                //        if (user.GoingTime + 12 <= hour && hour <= user.LeavingTime + 12)
                //        {
                //            count++;
                //        }
                //    }
                //}
                //ViewBag.NumberOfPeople = count;
            }
            return View(model);
        }
    }
}