using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.Multimedia;
using TM = Tizen.Multimedia;
using Tizen.TV.Multimedia;
using TVM = Tizen.TV.Multimedia;
using Tizen.TV.Extension.UIControls.Forms;
using Tizen.TV.Extension.UIControls.Forms.Renderer;
using Tizen.TV.UIControls.Forms.Renderer;
using Xamarin.Forms;

[assembly: ExportHandler(typeof(DRMMediaSource), typeof(DRMMediaSourceHandler))]
namespace Tizen.TV.Extension.UIControls.Forms.Renderer
{
    public sealed class DRMMediaSourceHandler : IMediaSourceHandler
    {
        public Task<bool> SetSource(TM.Player player, TV.UIControls.Forms.MediaSource source)
        {
            TVM.Player tvPlayer = player as TVM.Player;
            if (source is DRMMediaSource uriSource)
            {
                var platformDrmMgr = TVM.DRMManager.CreateDRMManager(uriSource.DRMType.ToDRMType());
                var appId = Tizen.Applications.Application.Current.ApplicationInfo.ApplicationId;

                platformDrmMgr.Init(appId);
                platformDrmMgr.AddProperty("LicenseServer", uriSource.licenseUrl);
                if (uriSource.Extradata.Count != 0)
                {
                    foreach (KeyValuePair<string, object> pair in uriSource.Extradata)
                    {
                        platformDrmMgr.RemoveProperty(pair.Key);
                        platformDrmMgr.AddProperty(pair.Key, pair.Value);
                    }
                }
                platformDrmMgr.Url = uriSource.url;

                platformDrmMgr.Open();
                tvPlayer.SetDrm(platformDrmMgr);

                tvPlayer.SetSource(new MediaUriSource(uriSource.url));
            }
            return Task.FromResult<bool>(true);
        }


    }



}
