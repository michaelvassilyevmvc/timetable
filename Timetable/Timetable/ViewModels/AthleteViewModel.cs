using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.Athletes;

namespace Timetable.ViewModels
{
    public class AthleteViewModel
    {
        public Athlete Athlete { get; set; }

        public AthleteViewModel(Athlete athlete)
        {
            this.Athlete = athlete;
        }
    }
}
