using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LPS_API.Models.EksekusiModels
{
    public class CheckBeforePeriodeModel
    {
        public string Result { get; set; }
        public int IDProjectHeader { get; set; }
        public string Periode { get; set; }
    }
}