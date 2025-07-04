using LPS_API.Helper;
using LPS_API.Models.ReportModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace LPS_API.Controllers.ReportController
{
    public class LaporanGptfController : ApiController
    {
        public List<LaporanGptfModel> Post([FromBody] LaporanGptfParamModel param)
        {
            GlobalFunction gf = new GlobalFunction();
            Report r = new Report();
            List<LaporanGptfModel> listLaporanGptf = new List<LaporanGptfModel>();
            DataSet ds = r.Get_ReportGptf(param.Month, param.Year);
            List<LaporanGptfModel> dt0 = gf.ConvertTo<LaporanGptfModel>(ds.Tables[0]);
            List<LaporanGptfParentModel> dt1 = gf.ConvertTo<LaporanGptfParentModel>(ds.Tables[1]);
            List<LaporanGptfChildModel> dt2 = gf.ConvertTo<LaporanGptfChildModel>(ds.Tables[2]);
            List<LaporanGptfChildModel> dt3 = gf.ConvertTo<LaporanGptfChildModel>(ds.Tables[3]);

            var listChild = dt0.Where(x => x.Parent != null).ToList();

            foreach (var item in listChild)
            {
                var parentModel = dt0.Where(x => x.IDProject == item.Parent).FirstOrDefault();
                if (parentModel != null)
                {
                    if (parentModel.IDProjectStatusLast == 13)
                    {
                        dt0.Remove(parentModel);
                    }
                    else
                    {
                        dt0.Remove(item);
                    }
                }
            }

            foreach (var dr in dt0)
            {
                var builderTarget = new StringBuilder();
                var builderRealisasi = new StringBuilder();
                var d1 = dt1.Where(x => x.ProjectHeaderId == dr.ProjectHeaderId).ToList();
                foreach (var dd1 in d1)
                {
                    var i = dd1.OutlineNumber.Substring(2, 1);
                    var taskId = dd1.TaskId;
                    var d2 = dt2.Where(x => x.ProjectHeaderId == dd1.ProjectHeaderId && x.ParentId == taskId).ToList();

                    foreach (var dd2 in d2)
                    {
                        var notesMileStone = dd2.Notes;
                        if (dd2.PlanPercentage == 100)
                        {
                            builderTarget.Append($"{dd2.TaskName}\n ");
                        }
                        else
                        {
                            builderTarget.Append($"Milestone {i}:\n ");
                        }

                        if (dd2.CompletePercentage == 100)
                        {
                            builderRealisasi.Append($"{dd2.TaskName}\n");
                        }
                        else
                        {
                            builderRealisasi.Append($"Milestone {i}:\n ");
                            //if (notesMileStone != null)
                            //{
                            //    builderRealisasi.Append($"({notesMileStone})\n");
                            //}
                        }


                        var parentId = dd2.ParentId;
                        var d3 = dt3.Where(x => x.ProjectHeaderId == dr.ProjectHeaderId && x.ParentId == parentId).ToList();
                        foreach (var dd3 in d3)
                        {
                            var notes = dd3.Notes;
                            if (dd2.PlanPercentage != 100)
                            {
                                builderTarget.Append($"-{dd3.TaskName} ({dd3.PlanPercentage}%)\n");
                            }
                            if (dd2.CompletePercentage != 100)
                            {
                                if (notes != null && dd3.CompletePercentage != 100)
                                {
                                    builderRealisasi.Append($"({notes})\n");
                                }
                                builderRealisasi.Append($"-{dd3.TaskName} ({dd3.CompletePercentage}%)\n");
                            }
                        }
                    }
                }
                dr.TargetBulanan = builderTarget.ToString();
                dr.RealisasiBulanan = builderRealisasi.ToString();
            }

            return dt0;
        }
    }
}
