using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using Tizen.TV.UIControls.Forms;
using TVM = Tizen.TV.Multimedia;

namespace Tizen.TV.Extension.UIControls.Forms
{
    public interface ITVMediaPlayer : IPlatformMediaPlayer
    {

    }
    public static class TVPlayerExtensions
    {
        public static TVM.DRMType ToDRMType(this DRMType mode)
        {
            TVM.DRMType ret = TVM.DRMType.Playready;
            switch (mode)
            {
                case DRMType.Playready:
                    ret = TVM.DRMType.Playready;
                    break;
            }
            return ret;
        }
    }
}
