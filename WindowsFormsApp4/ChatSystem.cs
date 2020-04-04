using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static WindowsFormsApp4.NotificationManager;

namespace WindowsFormsApp4
{
    public class ChatSystem
    {
        /// <summary>
        /// Nettoie le chat.
        /// </summary>
        public static void cleanChat(NpgsqlConnection con)
        {
            try
            {
                con.Close();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM message", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
        }
        /// <summary>
        /// Envoie la chaîne de caractères passée en paramètre dans la base de donnée en ligne.
        /// </summary>
        public static void SendMessage(String mssg, NpgsqlConnection conMsg)
        {
            if (mssg != "")
            {
                try
                {
                    conMsg.Close();
                    conMsg.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand("insert into message (idetu, msg, time)" + " values (@Idetu, @Msg, @Time)", conMsg);
                    cmd.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                    cmd.Parameters.AddWithValue("@msg", mssg);
                    cmd.Parameters.AddWithValue("@Time", DateTime.Now.ToShortTimeString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conMsg.Close();

                }
                catch
                {
                    MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
                }
            }        
        }

        /// <summary>
        /// Actualise l'état de connexion dans la base de donnée.
        /// </summary>
        public static void UpdateOnlineState(NpgsqlConnection con, int state)
        {
            try
            {
                con.Close();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE citise2 SET isonline = @IsOnline where Idetu = @Idetu", con);
                cmd.Parameters.AddWithValue("@IsOnline", state);
                cmd.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
        }
    }
}
