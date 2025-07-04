using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.TransaksiDataModels
{
    public class MPPModel
    {
        public List<MPPTask> MPPTasks { get; set; }
        public List<MPPResources> MPPResource { get; set; }
        public List<MPPResourcesAssigment> MPPResourceAssigment { get; set; }
        public List<MPPTaskDHTMLXLink> MPPLink { get; set; }
        public string ProjectHeaderID { get; set; }
        public string PersonNumber { get; set; }
    }

    public class MPPTask
    {
        public string taskID { get; set; }
        public string taskName { get; set; }
        public string taskGUID { get; set; }
        public DateTime taskStart { get; set; }
        public DateTime taskEnd { get; set; }
        public float taskCompleted { get; set; }
        public string taskDuration { get; set; }
        public string taskParent { get; set; }
        public string taskOutlineNumber { get; set; }
        public string taskOutlineLevel { get; set; }
        public string taskPredecessor { get; set; }
        public string taskSuccessor { get; set; }
        public string taskNotes { get; set; }
        public string taskType { get; set; }
    }

    public class MPPTaskNew
    {
        public string IDMPP { get; set; }
        public string taskID { get; set; }
        public string taskName { get; set; }
        public string taskGUID { get; set; }
        public DateTime taskStart { get; set; }
        public DateTime taskEnd { get; set; }
        public float taskCompleted { get; set; }
        public string taskDuration { get; set; }
        public string taskParent { get; set; }
        public string taskOutlineNumber { get; set; }
        public string taskOutlineLevel { get; set; }
        public string taskPredecessor { get; set; }
        public string taskSuccessor { get; set; }
        public string taskNotes { get; set; }
        public string taskType { get; set; }
        public string taskaActual_start { get; set; }
        public string taskActual_end { get; set; }
    }
    public class MPPTaskDHTMLXLink
    {
        public int id { get; set; }
        public int source { get; set; }
        public int target { get; set; }
        public string type { get; set; }
    }

    public class MPPResources
    {
        public string ResourceName { get; set; }
        public string ResourceID { get; set; }
        public string Email { get; set; }
    }

    public class MPPResourcesAssigment
    {
        public string ResourceID { get; set; }
        public string TaskID { get; set; }
        public string ResourceEmail { get; set; }
        public float Unit { get; set; }
    }

    public class MPPTaskDHTMLX
    {
        public string id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public double durasi { get; set; }
        public string parent { get; set; }
        public string predecessor { get; set; }
        public string no { get; set; }
        public string resources { get; set; }
        public string notes { get; set; }
        public string end_date { get; set; }
        public string percentcomplate { get; set; }
        public string type { get; set; }
        public bool isMilestone { get; set; }
    }

    public class MPPDHTMLX
    {
        public List<MPPTaskDHTMLX> GanttChart { get; set; }
        public List<MPPTaskDHTMLXLink> GanttChartLink { get; set; }
    }

    public class MPPDHTMLXEksekusi
    {
        public List<MPPTaskDHTMLXEksekusi> GanttChart { get; set; }
        public List<MPPTaskDHTMLXLink> GanttChartLink { get; set; }
    }
    public class MPPTaskDHTMLXEksekusi
    {
        public string id { get; set; }
        public string text { get; set; }
        public string start_date { get; set; }
        public double durasi { get; set; }
        public string parent { get; set; }
        public string plant { get; set; }
        public string no { get; set; }
        public string resources { get; set; }
        public string notes { get; set; }
        public string end_date { get; set; }
        public double progress { get; set; }
        public string type { get; set; }
        public bool isMilestone { get; set; }
        public string actual_start { get; set; }
        public string actual_end { get; set; }
        public string kpi { get; set; }
    }

}