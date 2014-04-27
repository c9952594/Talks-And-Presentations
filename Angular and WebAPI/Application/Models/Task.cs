using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Models {
    /* Contains properties common to tasks */
    public class Task {
        public int Id { get; set; }

        public string Text { get; set; }
        public string Tag { get; set; }

        public int TimeSpent { get; set; }
        public int TimeToComplete { get; set; }

        public bool Completed { get; set; }
    }
}