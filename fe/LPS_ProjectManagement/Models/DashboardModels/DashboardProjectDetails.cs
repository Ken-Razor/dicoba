using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models.DashboardModels
{
    public class DashboardProjectDetails
    {
        /*Variable Search*/
        public string IDProject { get; set; }

        public string anggaran { get; set; }
        public string realisasi { get; set; }
        public string pencapaian { get; set; }
        public string nama { get; set; }
        public string TypeTransformasi { get; set; }

        public List<GetProjectTaskModel> ListTask { get; set; }
        public List<GetProjectConstraintModel> ListConstraint { get; set; }
        public List<GetStackHolderProject> ListStackHolder { get; set; }
        public List<GetMilestoneProject> ListMilestone { get; set; }
        public List<GetScurve> ListScurve { get; set; }
        public List<Timeline> Times { get; set; }
        public List<GetProgress> Progress { get; set; }
        public List<GetProgressNT> ProgressNT { get; set; }
        public List<GetScurveReal> ListScurveReal { get; set; }
        public List<GetScurveTarget> ListScurveTarget { get; set; }
    }

    public class GetScurve
    {
        public string Periode { get; set; }
        public string Realisasi { get; set; }
        public string Target { get; set; }
    }

    public class GetScurveReal
    {
        public string week { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string y { get; set; }
    }
    public class GetScurveTarget
    {
        public string week { get; set; }
        public string month { get; set; }
        public string year { get; set; }
        public string y { get; set; }
    }
    public class Timeline
    {
        public string TaskName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class GetProgress
    {
        public string Periode { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string W1 { get; set; }
        public string W2 { get; set; }
        public string W3 { get; set; }
        public string W4 { get; set; }
        public string W5 { get; set; }
        public string W6 { get; set; }
    }

    public class GetProgressNT
    {
        public string Year { get; set; }
        public string Januari { get; set; }
        public string Februari { get; set; }
        public string Maret { get; set; }
        public string April { get; set; }
        public string Mei { get; set; }
        public string Juni { get; set; }
        public string July { get; set; }
        public string Agustus { get; set; }
        public string September { get; set; }
        public string Oktober { get; set; }
        public string November { get; set; }
        public string Desember { get; set; }
    }
}