using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WindowsFormsApp4
{
    class NotificationManager
    {
        public static void PlayNotificationSound()
        {
            try
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(Application.StartupPath.ToString() + "/notif.wav");
                player.Play();
            }
            catch
            {

            }
        }
        public static void NotifyPopup(string title, string content, TextBox t)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.TitleText = title;
            popup.Image = Properties.Resources.btn_chat_Image;
            popup.ContentText = content;
            popup.Popup();
            t.Focus();
        }
    }
}
