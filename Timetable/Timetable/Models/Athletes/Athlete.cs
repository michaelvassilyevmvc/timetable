using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Models.Athletes
{
    public class Athlete
    {
        public int Id { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string FullName { get { return $"{LName} {FName}"; } }

    }
}
