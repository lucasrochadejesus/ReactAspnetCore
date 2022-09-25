using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proactivity.Domain.Entities
{
    public class Activity
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime creationDate { get; set; }

        public DateTime conclusionDate { get; set; }

        public Priority Priority { get; set; }
 

        public Activity() => creationDate = DateTime.Now;

        public Activity(int id, string title, string description, DateTime creationDate, DateTime conclusionDate, Priority priority) : this()
        {
            Id = id;
            Title = title;
            Description = description;
            this.creationDate = creationDate;
            this.conclusionDate = conclusionDate;
            Priority = priority;
        }

        public void Conclusion()
        {
            if(conclusionDate == null)
            {
                conclusionDate = DateTime.Now;
            } else
            {
                throw new Exception($"Activity conclusion! {conclusionDate.ToString()}");
            }
        }
    }
}