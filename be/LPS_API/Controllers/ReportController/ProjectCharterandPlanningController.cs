using LPS_API.Helper;
using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class ProjectCharterandPlanningController : ApiController
    {
        GlobalFunction GF = new GlobalFunction();
        Report R = new Report();
        public ProjectCharterandPlanningModel Get(int ProjectHeaderID)
        {
            try
            {
                ProjectCharterandPlanningModel PCPM = new ProjectCharterandPlanningModel();

                List<ProjectCharter> Charter = new List<ProjectCharter>();
                List<ProjectTimeline> Timeline = new List<ProjectTimeline>();
                List<ProjectStakeHolder> Stakeholder = new List<ProjectStakeHolder>();
                List<ProjectMilestone> Milestone = new List<ProjectMilestone>();
                List<ProjectApproach> Approach = new List<ProjectApproach>();
                List<ProjectSponsor> ProSpo = new List<ProjectSponsor>();
                List<ProjectOwner> ProOwn = new List<ProjectOwner>();
                List<HeadofPMO> HoPMO = new List<HeadofPMO>();
                List<ProjectManager> ProMan = new List<ProjectManager>();
                List<ProgramManager> PMO = new List<ProgramManager>();


        DataSet DS = R.Get_Report_ProjectCharter(ProjectHeaderID);

                Charter = GF.ConvertTo<ProjectCharter>(DS.Tables[0]);
                Stakeholder = GF.ConvertTo<ProjectStakeHolder>(DS.Tables[1]);
                Timeline = GF.ConvertTo<ProjectTimeline>(DS.Tables[2]);
                Milestone = GF.ConvertTo<ProjectMilestone>(DS.Tables[3]);
                Approach = GF.ConvertTo<ProjectApproach>(DS.Tables[4]);
                ProSpo = GF.ConvertTo<ProjectSponsor>(DS.Tables[5]);
                ProOwn = GF.ConvertTo<ProjectOwner>(DS.Tables[6]);
                HoPMO = GF.ConvertTo<HeadofPMO>(DS.Tables[7]);
                ProMan = GF.ConvertTo<ProjectManager>(DS.Tables[8]);
                PMO = GF.ConvertTo<ProgramManager>(DS.Tables[9]);

                PCPM.Charter = Charter;
                PCPM.Stakeholder = Stakeholder;
                PCPM.Timeline = Timeline;
                PCPM.Milestone = Milestone;
                PCPM.Approach = Approach;
                PCPM.ProSpo = ProSpo;
                PCPM.ProOwn = ProOwn;
                PCPM.HoPMO = HoPMO;
                PCPM.ProMan = ProMan;
                PCPM.PMO = PMO;
                return PCPM;
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
