using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.TV.UIControls.Forms;

namespace Tizen.TV.Extension.UIControls.Forms
{
    public enum DRMType
    {
        Playready,
        //Verimatrix,
        //WidevineModular
    }

    public class DRMMediaSource : MediaSource
    {

        public DRMType DRMType { get; set; }
        public Dictionary<string, object> Extradata { get; set; }
        public string licenseUrl { get; set; }

        public string url { get; set; }

        public void AddProperty(string propertyName, object propertyValue)
        {
            Extradata.Add(propertyName, propertyValue);
        }
        public DRMMediaSource()
        {
            Extradata = new Dictionary<string, object>();
        }
    }

}
