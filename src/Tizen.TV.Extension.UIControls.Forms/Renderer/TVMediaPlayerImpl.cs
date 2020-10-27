using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.TV.UIControls.Forms.Renderer;
using Tizen.TV.Extension.UIControls.Forms.Renderer;
using Tizen.TV.Multimedia;
using TM = Tizen.Multimedia;
using TVM = Tizen.TV.Multimedia;
using System.Net;
using System.IO;
using Tizen.Multimedia;

[assembly: Xamarin.Forms.Dependency(typeof(TVMediaPlayerImpl))]
namespace Tizen.TV.Extension.UIControls.Forms.Renderer
{
    class TVMediaPlayerImpl : MediaPlayerImpl, ITVMediaPlayer
    {
        public TVMediaPlayerImpl()
        {

        }

        protected override TM.Player CreateMediaPlayer()
        {
            return new TVM.Player();
        }
    }
}
