using LPS_API.Models.TransaksiDataModels;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class ViewMPPController : ApiController
    {
        TransaksiInitiation TI = new TransaksiInitiation();
        public List<object> Push([FromBody]MPPModel Data)
        {

            DataTable dtResources = new DataTable();
            DataTable dtTask = new DataTable();
            DataTable dtResourceAssigment = new DataTable();
            DataTable dtResourceLink = new DataTable();

            if (Data.MPPResource != null)
            {
                dtResources = DataTableResource(Data.MPPResource);
            }
            else
            {
                dtResources.Columns.Add("ResourceName");
                dtResources.Columns.Add("ResourceID");
                dtResources.Columns.Add("Email");
            }
            if (Data.MPPTasks != null)
            {
                dtTask = DataTableTask(Data.MPPTasks);
            }
            else
            {
                dtTask.Columns.Add("taskID");
                dtTask.Columns.Add("taskName");
                dtTask.Columns.Add("taskGUID");
                dtTask.Columns.Add("taskStart");
                dtTask.Columns.Add("taskEnd");
                dtTask.Columns.Add("taskCompleted");
                dtTask.Columns.Add("taskDuration");
                dtTask.Columns.Add("taskParent");
                dtTask.Columns.Add("taskOutlineNumber");
                dtTask.Columns.Add("taskOutlineLevel");
                dtTask.Columns.Add("taskPredecessor");
                dtTask.Columns.Add("taskSuccessor");
                dtTask.Columns.Add("taskNotes");
            }

            if (Data.MPPResourceAssigment != null)
            {
                dtResourceAssigment = DataTableResourceAssigment(Data.MPPResourceAssigment);
            }
            else
            {
                dtResourceAssigment.Columns.Add("ResourceID");
                dtResourceAssigment.Columns.Add("TaskID");
                dtResourceAssigment.Columns.Add("ResourceEmail");
                dtResourceAssigment.Columns.Add("Unit");
            }

            if (Data.MPPLink != null)
            {
                dtResourceLink = DataTableResourceLink(Data.MPPLink);
            }
            else
            {
                dtResourceLink.Columns.Add("id");
                dtResourceLink.Columns.Add("source");
                dtResourceLink.Columns.Add("target");
                dtResourceLink.Columns.Add("type");
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dtTask);
            ds.Tables.Add(dtResources);
            ds.Tables.Add(dtResourceAssigment);
            ds.Tables.Add(dtResourceLink);

            var status = TI.GetPlanningPercentage(ds);

            return null;

        }

        public static DataTable DataTableResource(List<MPPResources> source)
        {
            var table = new DataTable();
            int index = 0;
            var properties = new List<PropertyInfo>();
            foreach (var obj in source)
            {
                if (index == 0)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            continue;
                        }
                        properties.Add(property);
                        table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                    }
                }
                object[] values = new object[properties.Count];
                for (int i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(obj);
                }
                table.Rows.Add(values);
                index++;
            }
            return table;
        }
        public static DataTable DataTableTask(List<MPPTask> source)
        {
            var table = new DataTable();
            int index = 0;
            var properties = new List<PropertyInfo>();
            foreach (var obj in source)
            {
                if (index == 0)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            continue;
                        }
                        properties.Add(property);
                        table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                    }
                }
                object[] values = new object[properties.Count];
                for (int i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(obj);
                }
                table.Rows.Add(values);
                index++;
            }
            return table;
        }
        public static DataTable DataTableResourceAssigment(List<MPPResourcesAssigment> source)
        {
            var table = new DataTable();
            int index = 0;
            var properties = new List<PropertyInfo>();
            foreach (var obj in source)
            {
                if (index == 0)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            continue;
                        }
                        properties.Add(property);
                        table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                    }
                }
                object[] values = new object[properties.Count];
                for (int i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(obj);
                }
                table.Rows.Add(values);
                index++;
            }
            return table;
        }
        public static DataTable DataTableResourceLink(List<MPPTaskDHTMLXLink> source)
        {
            var table = new DataTable();
            int index = 0;
            var properties = new List<PropertyInfo>();
            foreach (var obj in source)
            {
                if (index == 0)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            continue;
                        }
                        properties.Add(property);
                        table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                    }
                }
                object[] values = new object[properties.Count];
                for (int i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(obj);
                }
                table.Rows.Add(values);
                index++;
            }
            return table;
        }

    }
}
