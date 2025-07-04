using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_ProjectManagement.Models
{
    public class GlobalModel
    {
        public List<DropDownProject> Projects { get; set; }
        public List<DropDownProgram> Programs { get; set; }
        public List<DropDownRole> Roles { get; set; }
    }

    public class DropDownProjectRoles
    {
        public List<DropDownProgram> Programs { get; set; }
        public List<DropDownRole> Roles { get; set; }
    }


    public class DropDownUserManagementModel
    {
        public List<DropDownProject> Projects { get; set; }
        public List<DropDownProgram> Programs { get; set; }
        public List<DropDownRole> Roles { get; set; }
    }

    public class DropDownProject
    {
        public int IDProject { get; set; }
        public string ProjectName { get; set; }
    }

    public class DropDownProgram
    {
        public int IDProgram { get; set; }
        public string ProgramName { get; set; }
    }

    public class DropDownRole
    {
        public int IDRoleGroup { get; set; }
        public string RoleGroupName { get; set; }
    }

    public class DropDownMonth
    {
        public int Month { get; set; }

        public string Description { get; set; }
    }

    public class DropDownForecastMethod
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }

    public class DropDownCategorySeriesCapaiantMethod
    {
        public string Id { get; set; }

        public string Description { get; set; }
    }


    public class ProjectCharterandPlanningModel
    {
        public List<ProjectCharter> Charter { get; set; }
        public List<ProjectTimeline> Timeline { get; set; }
        public List<ProjectStakeHolder> Stakeholder { get; set; }
        public List<ProjectMilestone> Milestone { get; set; }
        public List<ProjectApproach> Approach { get; set; }
        public List<ProjectSponsor> ProSpo { get; set; }
        public List<ProjectOwner> ProOwn { get; set; }
        public List<HeadofPMO> HoPMO { get; set; }
        public List<ProjectManager> ProMan { get; set; }
        public List<ProgramManager> PMO { get; set; }
    }

    public class ProjectCharter
    {
        public string Nama { get; set; }
        public string Nomor { get; set; }
        public string Mulai { get; set; }
        public string Selesai { get; set; }
        public string LatarBelakang { get; set; }
        public string TujuanProject { get; set; }
        public string RuangLingkup { get; set; }
        public string Budget { get; set; }
        public string Tanggal { get; set; }
        public int TotalBulan { get; set; }
    }

    public class ProjectTimeline
    {
        public string No { get; set; }
        public string Aktivitas { get; set; }
        public string Durasi { get; set; }
        public string Mulai { get; set; }
        public string Selesai { get; set; }
        public string BGColor { get; set; }
        public string FontColor { get; set; }
        public string FontWeight { get; set; }
    }

    public class ProjectStakeHolder
    {
        public string RoleName { get; set; }
        public string Position { get; set; }
        public string StakeHolder { get; set; }
    }

    public class ProjectMilestone
    {
        public string No { get; set; }
        public string Aktivitas { get; set; }
        public string Selesai { get; set; }
        public string BGColor { get; set; }
        public string FontColor { get; set; }
        public string FontWeight { get; set; }
    }

    public class ProjectApproach
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class ProjectSponsor
    {
        public string RoleName { get; set; }
        public string Position { get; set; }
        public string StakeHolder { get; set; }
    }

    public class ProjectOwner
    {
        public string RoleName { get; set; }
        public string Position { get; set; }
        public string StakeHolder { get; set; }
    }

    public class HeadofPMO
    {
        public string RoleName { get; set; }
        public string Position { get; set; }
        public string StakeHolder { get; set; }
    }

    public class ProjectManager
    {
        public string RoleName { get; set; }
        public string Position { get; set; }
        public string StakeHolder { get; set; }
    }

    public class ProgramManager
    {
        public string RoleName { get; set; }
        public string Position { get; set; }
        public string StakeHolder { get; set; }
    }

}