using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.ReportModels
{

    public class MasterSLA
    {
        public long Id { get; set; }
        public long NoUrut { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string StatusSLA { get; set; }
        public string Peraturan { get; set; }
        public string JasaPelayanan { get; set; }
        public string Waktu { get; set; }
        public string DihitungDari { get; set; }
        public string Cuser { get; set; }
        public string Uuser { get; set; }
        public string Updateby { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<StatusSLAModel> ListStatus { get; set; }
        public List<GroupModel> ListGroup { get; set; }
    }

    public class StatusSLAModel
    {
        public string IdStatus { get; set; }

        public string Description { get; set; }

    }

    public class GroupModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

    }
    public class FilterSLAModel
    {
        public string GroupId { get; set; }

        public string StatusSLA { get; set; }
        public string Peraturan { get; set; }

    }

}