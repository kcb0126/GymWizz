using GymWizz.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace GymWizz.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetFirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FirstName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetLastName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("LastName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static bool GetIsGoing(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("IsGoing");
            return (claim != null) ? (claim.Value == "true") : false;
        }

        public static int GetGoingTime(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("GoingTime");
            return (claim != null) ? (int.Parse(claim.Value)) : 0;
        }
        public static int GetLeavingTime(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("LeavingTime");
            return (claim != null) ? (int.Parse(claim.Value)) : 0;
        }

        public static int GetGymId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("GymId");
            return (claim != null) ? (int.Parse(claim.Value)) : 0;
        }

        public static string GetGymName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("GymId");
            int gymId = (claim != null) ? (int.Parse(claim.Value)) : 0;
            return Gym.Gyms[gymId].Name;
        }
    }
}