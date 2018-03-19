using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWizz.Utils
{
    public class GoingTime
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<GoingTime> GoingTimes = new List<GoingTime> {
                new GoingTime{Id = 0, Name = "12PM"},
                new GoingTime{Id = 1, Name = "1PM"},
                new GoingTime{Id = 2, Name = "2PM"},
                new GoingTime{Id = 3, Name = "3PM"}
            };
    }
}