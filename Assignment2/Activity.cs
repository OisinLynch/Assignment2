using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public enum ActivityType { Air, Water, Land }
    class Activity : IComparable
    {
        //Properties
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public decimal Cost { get; set; }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public ActivityType TypeOfActivity { get; internal set; }

        //Constructors

        public Activity ()
        {

        }

        public Activity(string name, DateTime activityDate, decimal cost, string description)
        {
            Name = name;
            ActivityDate = activityDate;
            Cost = cost;
            Description = description;
        }

        //Methods
        public int CompareTo(object obj)
        {
            Activity that = (Activity)obj;

            //Compare one Activity Date to another 
            return this.ActivityDate.CompareTo(that.ActivityDate);
        }

        public override string ToString()
        {
            return $"{Name} - {ActivityDate.ToShortDateString()}";
        }

    }
}
