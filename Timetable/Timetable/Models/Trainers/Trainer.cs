using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Models.LearningGroups;

namespace Timetable.Models.Trainers
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string FullName { get { return $"{LName} {FName}"; } }
        public int LearningGroupId { get; set; }
        public LearningGroup LearningGroup { get; set; }
    }
}
