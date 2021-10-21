using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Training_Application_System.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
    }
}