using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNDAI.MODELS.SLAVE
{
    public class StationDBPageModelSlave
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Elevation { get; set; }
        public string PoleLength { get; set; }
        public string InstallationOrientation { get; set; }
        public string SlaveIPAddress { get; set; }
        public string SlaveAntennaIPAddress { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}