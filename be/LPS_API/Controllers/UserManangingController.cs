using LPS_API.Models;
using LPS_BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LPS_API.Controllers
{
    public class UserManangingController : ApiController
    {

        UserManagement UM = new UserManagement(); 

        public MultiPorpose Push([FromBody]InsertDataUser Data)
        {
            DataTable dtRoles = new DataTable();
            dtRoles.Columns.Add("Program", typeof(Int32));
            dtRoles.Columns.Add("Project", typeof(Int32));
            dtRoles.Columns.Add("Role", typeof(Int32));

            foreach (var item in Data.RolesGroup)
            {
                string[] Roles = item.IDRoles.Split('|');
                foreach (string Role in Roles)
                {
                    dtRoles.Rows.Add(item.IDProgram, item.IDProject, Convert.ToInt32(Role));
                }
            }

            string InsertData = UM.insertNewUser(Data.PersonNumber, Data.CreateBy, dtRoles);


            MultiPorpose _status = new MultiPorpose();


            _status.ID = InsertData;
          

            return _status;
        }

        public string Delete(string PersonalNumber, string Username)
        {
            try
            {
               var result = UM.DeleteNewUser(PersonalNumber, Username);
               return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Get(string PersonNumber)
        {
            var result = UM.GetUserSystemRole(PersonNumber);
            return result;
        }

        public MultiPorpose Put([FromBody]InsertDataUser Data)
        {
            DataTable dtRoles = new DataTable();
            dtRoles.Columns.Add("Program", typeof(Int32));
            dtRoles.Columns.Add("Project", typeof(Int32));
            dtRoles.Columns.Add("Role", typeof(Int32));
          
            foreach (var item in Data.RolesGroup)
            {

                string[] Roles = item.IDRoles.Split('|');
                if (Roles.Length > 1)
                {
                    var result = Roles.Take(Roles.Length - 1);
                    foreach (string Role in result)
                    {
                        dtRoles.Rows.Add(item.IDProgram, item.IDProject, Convert.ToInt32(Role));
                    }
                }
                else
                {
                    foreach (string Role in Roles)
                    {
                        dtRoles.Rows.Add(item.IDProgram, item.IDProject, Convert.ToInt32(Role));
                    }
                }
               
            }

            string InsertData = UM.UpdateNewUser(Data.PersonNumber, Data.CreateBy, dtRoles);


            MultiPorpose _status = new MultiPorpose();


            _status.ID = InsertData;


            return _status;
        }

    }
}
