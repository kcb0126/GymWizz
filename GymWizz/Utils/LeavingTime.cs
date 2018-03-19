using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWizz.Utils
{
    public class LeavingTime
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<LeavingTime> LeavingTimes = new List<LeavingTime> {
                new LeavingTime{Id = 0, Name = "12PM"},
                new LeavingTime{Id = 1, Name = "1PM"},
                new LeavingTime{Id = 2, Name = "2PM"},
                new LeavingTime{Id = 3, Name = "3PM"},
                new LeavingTime{Id = 4, Name = "4PM"},
                new LeavingTime{Id = 5, Name = "5PM"},
                new LeavingTime{Id = 6, Name = "6PM"}
            };
    }
}