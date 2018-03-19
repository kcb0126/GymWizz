using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymWizz.Utils
{
    public class Gym
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Gym> Gyms = new List<Gym> {
                new Gym{Id = 0, Name = "pure gym"},
                new Gym{Id = 1, Name = "Fitness First"},
                new Gym{Id = 2, Name = "Titatic"}
            };
    }
}