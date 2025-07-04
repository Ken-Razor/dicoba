using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models
{
    public class NotificationModel
    {
        public int IDProject { get; set; }

        public string ProjectName { get; set; }

        public string Category { get; set; }

        public string Phase { get; set; }

        public string Keys { get; set; }
    }
}