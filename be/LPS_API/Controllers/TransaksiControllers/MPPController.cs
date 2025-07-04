using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using LPS_API.Models.TransaksiDataModels;
using LPS_BLL;

namespace LPS_API.Controllers.TransaksiControllers
{
    public class MPPController : ApiController
    {
        TransaksiInitiation TI = new TransaksiInitiation();
        public string Push([FromBody]MPPModel Data)
        {
            DataTable dtResources = new DataTable();
            DataTable dtTask = new DataTable();
            DataTable dtResourceAssigment = new DataTable();
            DataTable dtResourceLink = new DataTable();

        if (Data.MPPResource != null )
        {
                if (Data.MPPResource.Count == 1)
                {
                    foreach (var item in Data.MPPResource)
                    {
                        if (item.ResourceName == " " || item.ResourceName == "" || item.ResourceName == null && item.Email == " " || item.Email == "" || item.Email == null)
                        {
                            dtResources.Columns.Add("ResourceName");
                            dtResources.Columns.Add("ResourceID");
                            dtResources.Columns.Add("Email");
                            break;
                        }
                        else
                        {
                            dtResources = DataTableResource(Data.MPPResource);
                            break;
                        }
                    }                   
                }
                else
                {
                    dtResources = DataTableResource(Data.MPPResource);
                }

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

        if (Data.MPPResourceAssigment != null && Data.MPPResourceAssigment.Count > 0)
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
        
        if (Data.MPPLink != null && Data.MPPLink.Count > 0)
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
        
        string status = TI.InsertDataMPP(ds, Data.ProjectHeaderID, Data.PersonNumber);
        
        return status;
        }

        public MPPDHTMLX Get(string HeaderID)
        {
            DataSet ds = TI.GetDataMPPPlaning(HeaderID);

            DataTable dtResources = ds.Tables[0];
            DataTable dtLink = ds.Tables[1];

            MPPDHTMLX _DHTMLX = new MPPDHTMLX();
            List<MPPTaskDHTMLX> _MPPTaskDHTMLX = new List<MPPTaskDHTMLX>();
            List<MPPTaskDHTMLXLink> _MPPTaskDHTMLXLink = new List<MPPTaskDHTMLXLink>();

            if (dtResources.Rows.Count > 0)
            {
                foreach (DataRow dr in dtResources.Rows)
                {
                    MPPTaskDHTMLX _DHTMLXTask = new MPPTaskDHTMLX();

                    _DHTMLXTask.id = dr["id"].ToString();
                    _DHTMLXTask.text = dr["text"].ToString();
                    _DHTMLXTask.start_date = Convert.ToDateTime(dr["start_date"]).ToString("dd-MM-yyyy HH:mm:ss");
                    _DHTMLXTask.durasi = Convert.ToDouble(dr["durasi"]);
                    _DHTMLXTask.parent = dr["parent"].ToString();
                    _DHTMLXTask.predecessor = dr["predecessor"].ToString(); //this PercentPlan 
                    _DHTMLXTask.no = dr["no"].ToString();
                    _DHTMLXTask.resources = dr["resources"].ToString(); // this Outline Number
                    _DHTMLXTask.notes = dr["notes"].ToString();
                    _DHTMLXTask.end_date = Convert.ToDateTime(dr["end_date"]).ToString("dd-MM-yyyy HH:mm:ss");
                    _DHTMLXTask.percentcomplate = dr["percentcomplate"].ToString();
                    if (dr["milestone"].ToString() == "1")
                    {
                        _DHTMLXTask.type = "milestone";
                    }
                    else if (dr["IsParent"].ToString() == "1")
                    {
                        _DHTMLXTask.type = "project";
                    }
                    else
                    {
                        _DHTMLXTask.type = "task";
                    }
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

        public string Put([FromBody]MPPModel Data)
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

            string status = TI.UpdateDataMPP(ds, Data.ProjectHeaderID, Data.PersonNumber);

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

        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
}
