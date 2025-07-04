using LPS_API.Helper;
using LPS_BLL;
using LPS_BLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace LPS_API.Controllers.SystemIntegration
{
    public class IoperaIntegrationController : ApiController
    {
        [HttpPost]
        public List<IoperaIntegrationModel> GetData([FromBody] IoperaIntegrationParamModel param)
        {
            IntegrationSystem I = new IntegrationSystem();
            GlobalFunction gf = new GlobalFunction();
            DataSet ds = I.GetDataIoperaIntegration(param.Year, param.TW);
            List<IoperaIntegrationModel> dt0 = gf.ConvertTo<IoperaIntegrationModel>(ds.Tables[0]);
            List<IoperaIntegrationParentModel> dt1 = gf.ConvertTo<IoperaIntegrationParentModel>(ds.Tables[1]);
            List<IoperaIntegrationChildModel> dt2 = gf.ConvertTo<IoperaIntegrationChildModel>(ds.Tables[2]);
            List<IoperaIntegrationChildModel> dt3 = gf.ConvertTo<IoperaIntegrationChildModel>(ds.Tables[3]);

            foreach (var item in dt0)
            {
                var dat = dt0.Where(x => x.ProjectHeaderId == item.ProjectHeaderId).ToList();
                var datCount = dat.Where(x => x.CompletePercentage2 == 100).Count();
                if (dat.Count() > 1)
                {
                    if (datCount > 1)
                    {
                        item.PlanPercentage = dat.OrderByDescending(x => x.PlanPercentage2).Select(q => q.PlanPercentage2).FirstOrDefault();
                        item.PlanPercentage2 = dat.OrderByDescending(x => x.PlanPercentage2).Select(q => q.PlanPercentage2).FirstOrDefault();
                        item.CapaianProyek = Math.Round(10000 / item.PlanPercentage2);
                    }
                    else
                    {
                        item.PlanPercentage2 = 0;
                        item.CompletePercentage2 = 0;
                        item.CompletePercentage = Math.Round(dat.Average(q => q.CompletePercentage));
                        item.CapaianProyek = Math.Round((item.CompletePercentage / item.PlanPercentage) * 100);
                        foreach (var i in dat)
                        {
                            i.CompletePercentage = item.CompletePercentage;
                        }
                    }
                }
                else
                {
                    if (item.CompletePercentage2 == 100)
                    {
                        item.PlanPercentage = item.PlanPercentage2;
                    }
                }

                if (!(item.Status == "Selesai" || item.Status == "Belum dimulai"))
                {
                    if (item.CapaianProyek >= 110)
                    {
                        item.Status = "Di atas target";
                    }
                    else if (item.CapaianProyek >= 100)
                    {
                        item.Status = "Sesuai target";
                    }
                    else if (item.CapaianProyek >= 100)
                    {
                        item.Status = "Sedikit di bawah target";
                    }
                    else
                    {
                        item.Status = "Jauh di bawah target";
                    }
                }

            }

            var idList = dt0.Where(x => dt0.Where(q => q.ProjectHeaderId == x.ProjectHeaderId).Count() > 1).Select(q => q.ProjectHeaderId).Distinct().ToList();
            foreach (var id in idList)
            {
                var dat = dt0.Where(x => x.ProjectHeaderId == id).FirstOrDefault();
                dt0.Remove(dat);
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
                    if (dr.IsTransformasi)
                    {
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
                            }

                            //if (notesMileStone != null)
                            //{
                            //    builderRealisasi.Append($"({notesMileStone})\n");
                            //}

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
                    else
                    {
                        if (dd1.Notes != null && dd1.CompletePercentage != 100)
                        {
                            builderRealisasi.Append($"({dd1.Notes})\n");
                        }
                        builderTarget.Append($"-{dd1.TaskName} ({dd1.PlanPercentage}%)\n");
                        builderRealisasi.Append($"-{dd1.TaskName} ({dd1.CompletePercentage}%)\n");
                    }
                }
                dr.Deliverable = builderTarget.ToString();
                dr.Realisasi = builderRealisasi.ToString();
            }

            return dt0;
        }
    }
}

