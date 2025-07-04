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
    public class RegisteredDetailUserController : ApiController
    {
        UserManagement UM = new UserManagement();
        public List<RegisteredUserDetail> Post([FromBody]MultiPorpose Name)
        {
            List<RegisteredUserDetail> _Result = new List<RegisteredUserDetail>();

            var dt = UM.ListEmployeByName(Name.ID);

            foreach (DataRow item in dt.Rows)
            {
                RegisteredUserDetail _Detail = new RegisteredUserDetail();

                _Detail.Nama = item["Nama"].ToString();
                _Detail.PersonalNumber = item["PersonalNumber"].ToString();
                _Detail.Posisi = item["Posisi"].ToString();

                _Result.Add(_Detail);
            }


            return _Result;
        }

        public MultiPorpose Delete(string Persnum, string Username)
        {
           MultiPorpose _Result = new MultiPorpose();

            string  Delete = UM.DeleteNewUser(Persnum , Username);

            _Result.ID = Delete;
            

            return _Result;
        }

        public List<RegisteredUserDetail> Put([FromBody]MultiPorpose Name)
        {
            List<RegisteredUserDetail> _Result = new List<RegisteredUserDetail>();

            var dt = UM.ListEmployeByNameNew(Name.ID);

            foreach (DataRow item in dt.Rows)
            {
                RegisteredUserDetail _Detail = new RegisteredUserDetail();

                _Detail.Nama = item["Nama"].ToString();
                _Detail.PersonalNumber = item["PersonalNumber"].ToString();
                _Detail.Posisi = item["Posisi"].ToString();

                _Result.Add(_Detail);
            }


            return _Result;
        }
        //public List<RegisteredUserDetail> Put([FromBody]MultiPorpose Name)
        //{
        //    List<RegisteredUserDetail> _Result = new List<RegisteredUserDetail>();

        //    string dt = UM.ListEmployeByName(Name.ID);




        //    return _Result;
        //}


    }
}
