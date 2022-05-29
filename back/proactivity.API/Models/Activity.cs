using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proactivity.API.Models
{
    public class Activity
    {

        public Activity(int id, string title, string description, string priority) 
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string Priority { get; private set; }
    }
}