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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FindGym()
        {
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
            ViewBag.IsGoing = currentUser.IsGoing;
            ViewBag.GoingTime = currentUser.GoingTime;
            ViewBag.LeavingTime = currentUser.LeavingTime;
            ViewBag.GymName = Gym.Gyms[currentUser.GymId].Name;

            ViewBag.GoingTimes = new SelectList(GoingTime.GoingTimes, "Id", "Name");
            ViewBag.LeavingTimes = new SelectList(LeavingTime.LeavingTimes, "Id", "Name");

            //var db = new ApplicationUserManager
            ApplicationDbContext context = new ApplicationDbContext();
            var users = context.Users.ToList();
            var count = 0;
            foreach(var user in users)
            {
                if (user.IsGoing && user.GymId == currentUser.GymId)
                {
                    var hour = DateTime.Now.Hour;
                    if(user.GoingTime + 12 <= hour && hour <= user.LeavingTime + 12)
                    {
                        count++;
                    }
                }
            }
            ViewBag.NumberOfPeople = count;
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