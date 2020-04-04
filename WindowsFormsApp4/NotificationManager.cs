using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace WindowsFormsApp4
{
    class NotificationManager
    {
        /// <summary>
        /// Joue le son de la notification.
        /// </summary>
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
        /// <summary>
        /// Fait apparaître une notification sur le bord droit de l'écran et redonne le focus à la textbox
        /// </summary>
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
