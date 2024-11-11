using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNDAI.MODELS.SLAVE
{
    public class AlarmHistorySlaveModel
    {
        public int? ID { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public string AlarmName { get; set; }
    }
}
