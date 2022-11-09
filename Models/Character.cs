using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_prac.Models
{
    public class Character
    {
        public static int idNum = 0;
        public int id { get; set; } = idNum;
        public string Name { get; set; } = "Fredo";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Knight;

        public Character(string aName)
        {
            Name = aName;
            idNum++;
        }

    }
}