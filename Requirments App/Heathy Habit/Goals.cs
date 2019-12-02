using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heathy_Habit
{
    public class Goals
    {
        //Properties
        public string GoalName { get; set; }
        public string GoalDescription { get; set; }

        //Constructors
        public Goals(string goalName, string goalDescsription)
        {
            GoalName = goalName;
            GoalDescription = goalDescsription;
        }
        public Goals()
        {
      
        }
        public override string ToString()
        {
            return $"{GoalName} -  {GoalDescription}";
        }


    }

}
