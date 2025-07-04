using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models
{
    public class EmailModel
    {
       public string Type               {get;set;}
       public string IDProjectHeader    {get;set;}
       public string Periode            { get; set; }
    }

    public class StatusEmail
    {
        public string Status { get; set; }
    }

    public class Reciever
    {
        public string username { get; set; }
        public int isTransformasi { get; set; }
    }
}