using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPS_BLL.Models.BerandaModels
{
    public class BerandaModel
    {
    }

    public class DashboardProjectHeaderModel
    {
        public string Year { get; set; }

        public int? Month { get; set; }

        public int? Day { get; set; }

        public int Week { get; set; }

        public int JumlahWeek { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}
