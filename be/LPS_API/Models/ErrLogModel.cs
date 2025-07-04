using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models
{
    public class ErrLogModel
    {
       public string Modul               {get;set;}
       public string Code    {get;set;}
       public string Description            { get; set; }
       public string CreateUser { get; set; }
    }

}