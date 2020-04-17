using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    class DownloadSystem
    {
        public class DownloadHandler : IDownloadHandler
        {
            public event EventHandler<DownloadItem> OnBeforeDownloadFired;

            public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

            void IDownloadHandler.OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
            {
                var handler = OnBeforeDownloadFired;

                if (handler != null)
                {
                    handler(this, downloadItem);
                }

                if (!callback.IsDisposed)
                {
                    using (callback)
                    {
                        callback.Continue(@"C:\Users\" +
                                System.Security.Principal.WindowsIdentity.GetCurrent().Name +
                                @"\Downloads\" +
                                downloadItem.SuggestedFileName,
                            showDialog: true);
                    }
                }
            }

            void IDownloadHandler.OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
            {
                var handler = OnDownloadUpdatedFired;
                if (handler != null)
                {
                    handler(this, downloadItem);
                }
            }
        }
    }
}
