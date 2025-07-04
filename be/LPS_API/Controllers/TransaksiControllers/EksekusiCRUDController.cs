using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LPS_API.Models.EksekusiModels;
using LPS_BLL;
using LPS_API.Helper;
using LPS_API.Models;
using LPS_API.Models.TransaksiDataModels;
using LPS_API.Models.MasterDataModels;
using LPS_API.Models.SAPModels;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class EksekusiCRUDController : ApiController
    {
        GlobalFunction GF = new GlobalFunction();
        TransaksiEksekusi TE = new TransaksiEksekusi();
        public EksekusiModel Get(int ProjectID, string Periode, string Persnum)
        {
            DataSet ds = TE.GetDetailEksekusi(ProjectID, Periode, Persnum);

            DataTable milestone = ds.Tables[0];
            DataTable constrain = ds.Tables[1];
            DataTable status = ds.Tables[2];
            DataTable approval = ds.Tables[3];
            DataTable isApproval = ds.Tables[4];
            DataTable rolegroup = ds.Tables[5];
            DataTable revisidesc = ds.Tables[6];
            DataTable History = ds.Tables[7];
            DataTable roleuser = ds.Tables[8];
            DataTable Sysrole = ds.Tables[9];
            DataTable Status = ds.Tables[10];
            DataTable StatusProject = ds.Tables[12];
            DataTable dt14 = ds.Tables[14];

            EksekusiModel EK = new EksekusiModel();

            List<Milestone> Miles = new List<Milestone>();
            List<Constrain> Conss = new List<Constrain>();
            List<ProjectInitApprovalRoleModel> App = new List<ProjectInitApprovalRoleModel>();
            List<RoleGroupModel> RGM = new List<RoleGroupModel>();
            List<execHistory> His = new List<execHistory>();
            List<Approver> Appm = new List<Approver>();
            List<Roleproj> Rp = new List<Roleproj>();

            if (isApproval.Rows.Count > 0)
            {
                var isappr = isApproval.Rows[0][0].ToString();
                EK.isApproval = GF.ConvertTo<Approver>(isApproval);
                //if (isappr == "0")
                //{
                //    EK.isApproval = "0";
                //}
                //else
                //{
                //    EK.isApproval = "1";
                //}
            } else
            {
                Approver Apps = new Approver();

                Apps.Approval = "0";

                Appm.Add(Apps);
                EK.isApproval = Appm;
                //EK.isApproval = null;
            }
            //} else
            //{
            //    EK.isApproval = null;
            //}
         
            EK.Nama = status.Rows[0]["Nama"].ToString();
            EK.Periode = status.Rows[0]["Periode"].ToString();
            EK.Tanggal = status.Rows[0]["Tanggal"].ToString();
            if (revisidesc.Rows.Count > 0)
            {
                EK.RevisiBy = revisidesc.Rows[0]["Dari"].ToString();
                EK.RevisiDesc = revisidesc.Rows[0]["Description"].ToString();
            }
            if (roleuser.Rows.Count > 0)
            {
                EK.Role = GF.ConvertTo<Roleproj>(roleuser);
            }
            else
            {
                Roleproj Apps = new Roleproj();

                Apps.Roles = "0";

                Rp.Add(Apps);
                EK.Role = Rp;
            }

            if (Sysrole.Rows.Count > 0)
            {
                EK.Sysrole = Sysrole.Rows[0]["Sysrole"].ToString();
            }
            if (Status.Rows.Count > 0)
            {
                EK.Status = Status.Rows[0]["Status"].ToString();
            }

            Miles = GF.ConvertTo<Milestone>(milestone);
            Conss = GF.ConvertTo<Constrain>(constrain);
            App = GF.ConvertTo<ProjectInitApprovalRoleModel>(approval);
            RGM = GF.ConvertTo<RoleGroupModel>(rolegroup);
            His = GF.ConvertTo<execHistory>(History);

            EK.ml = Miles;
            EK.cons = Conss;
            EK.apps = App;
            EK.rgp = RGM;
            EK.history = His;
            
            #region Insert yearly document into model
            DataTable YearlyDocument = ds.Tables[13];
            List<YearlyDocument> ListYearlyDocumentModel = new List<YearlyDocument>();

            foreach (DataRow dr in YearlyDocument.Rows)
            {
                YearlyDocument YearlyDocumentModel = new YearlyDocument();

                YearlyDocumentModel.IDDocument = dr["IDDocument"].ToString();
                YearlyDocumentModel.IDDocPhase = dr["IDDocPhase"].ToString();
                YearlyDocumentModel.IDDocType = dr["IDDocType"].ToString();
                YearlyDocumentModel.IDProjectHeader = dr["IDProjectHeader"].ToString();
                YearlyDocumentModel.DocumentName = dr["DocumentName"].ToString();
                YearlyDocumentModel.TaskID = dr["TaskID"].ToString();
                YearlyDocumentModel.CreatedDate = dr["CreatedDate"].ToString();
                YearlyDocumentModel.CreatedBy = dr["CreatedBy"].ToString();
                YearlyDocumentModel.UpdatedDate = dr["UpdatedDate"].ToString();
                YearlyDocumentModel.UpdatedBy = dr["UpdatedBy"].ToString();
                YearlyDocumentModel.IsActive = dr["IsActive"].ToString();
                YearlyDocumentModel.StringCreatedDate = dr["StringCreatedDate"].ToString();

                ListYearlyDocumentModel.Add(YearlyDocumentModel);
            }

            EK.ListYearlyDocument = ListYearlyDocumentModel;
            #endregion


            #region Table SAP RKAT
            List<RKATModel> ListRKAT = new List<RKATModel>();
            foreach (DataRow data in dt14.Rows)
            {
                RKATModel RKAT = new RKATModel();
                RKAT.IDSAP = data["IDSAP"].ToString();
                ListRKAT.Add(RKAT);
            }
            EK.ListRKAT = ListRKAT;
            #endregion


            // Return to model
            return EK;
        }

        public MPPDHTMLXEksekusi Push([FromBody]MultiPorpose ProjectHeaderID)
        {
            try
            {
                var param = ProjectHeaderID.ID.Split('|');

                DataSet ds = TE.GetMPPProject(Convert.ToInt32(param[0]), param[1]);

                DataTable dtResources = ds.Tables[0];
                DataTable dtLink = ds.Tables[1];

                MPPDHTMLXEksekusi _DHTMLX = new MPPDHTMLXEksekusi();
                List<MPPTaskDHTMLXEksekusi> _MPPTaskDHTMLX = new List<MPPTaskDHTMLXEksekusi>();
                List<MPPTaskDHTMLXLink> _MPPTaskDHTMLXLink = new List<MPPTaskDHTMLXLink>();

                if (dtResources.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtResources.Rows)
                    {
                        MPPTaskDHTMLXEksekusi _DHTMLXTask = new MPPTaskDHTMLXEksekusi();


                        _DHTMLXTask.id = dr["id"].ToString();
                        _DHTMLXTask.text = dr["text"].ToString();
                        _DHTMLXTask.start_date = Convert.ToDateTime(dr["start_date"]).ToString("dd-MM-yyyy");//Convert.ToDateTime(dr["start_date"]).ToString("dd-MM-yyyy HH:mm:ss");
                        _DHTMLXTask.durasi = Convert.ToDouble(dr["durasi"]);
                        _DHTMLXTask.parent = dr["parent"].ToString();
                        _DHTMLXTask.plant = dr["PlaningPercentage"].ToString(); // This Percentage
                        _DHTMLXTask.resources = dr["OutlineNumber"].ToString(); // This OutlineNumber
                        _DHTMLXTask.no = dr["idMPP"].ToString(); // This idMPP
                        _DHTMLXTask.notes = dr["notes"].ToString();
                        _DHTMLXTask.end_date = Convert.ToDateTime(dr["end_date"]).ToString("dd-MM-yyyy"); //Convert.ToDateTime(dr["end_date"]).ToString("dd-MM-yyyy HH:mm:ss");
                        _DHTMLXTask.progress = (Convert.ToDouble(dr["percentcomplate"]) / 100);
                        _DHTMLXTask.type = dr["type"].ToString();
                        _DHTMLXTask.actual_start = dr["actual_start"].ToString();
                        _DHTMLXTask.actual_end = dr["actual_end"].ToString();
                        _MPPTaskDHTMLX.Add(_DHTMLXTask);
                    }
                }

                if (dtLink.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtLink.Rows)
                    {
                        MPPTaskDHTMLXLink _DHTMLXTaskLink = new MPPTaskDHTMLXLink();
                        _DHTMLXTaskLink.id = Convert.ToInt32(dr["id"]);
                        _DHTMLXTaskLink.source = Convert.ToInt32(dr["source"]);
                        _DHTMLXTaskLink.target = Convert.ToInt32(dr["target"]);
                        _DHTMLXTaskLink.type = dr["type"].ToString();
                        _MPPTaskDHTMLXLink.Add(_DHTMLXTaskLink);
                    }
                }

                _DHTMLX.GanttChart = _MPPTaskDHTMLX;
                _DHTMLX.GanttChartLink = _MPPTaskDHTMLXLink;

                return _DHTMLX;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }
    
    }
}
