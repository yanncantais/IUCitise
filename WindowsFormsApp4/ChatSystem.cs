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
        /// Récupère  les messages par ordre d'envoi dans la base de donnée en ligne. Les messages sont affichés dans la RichTextBox.
        /// </summary>
        public static void AllMessageLists(RichTextBox txtbox_message, NpgsqlConnection conMsg, bool sound,bool vis, int first, TextBox t)
        {
            DataTable dt = new DataTable();
            try
            {
                conMsg.Close();
                conMsg.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM message ORDER BY id ASC", conMsg);
                NpgsqlCommand comm = new NpgsqlCommand("SELECT COUNT(*) FROM message", conMsg);
                int id = System.Convert.ToInt32(comm.ExecuteScalar());//Nombre de messages dans la base de donnée
                cmd.ExecuteNonQuery();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                if (id != 0)
                {
                    if (txtbox_message.Lines.Length == 2)//On demande si le chat local est vide. Si oui, on recup tous les messages de la bdd
                    {
                        if (dt.Rows != null)
                        {
                            foreach (DataRow drow in dt.Rows)
                            {
                                txtbox_message.Text += "\n" + "(" + drow["time"].ToString() + " / " + drow["idetu"].ToString() + ") :  " + drow["msg"].ToString();
                            }
                            txtbox_message.SelectionStart = txtbox_message.TextLength;
                            txtbox_message.ScrollToCaret();
                            if (sound == true && dt.Rows[id - 1]["idetu"].ToString() != Properties.Settings.Default.idetu && first == 0)
                            {
                                PlayNotificationSound();
                            }
                            if (vis == true && dt.Rows[id - 1]["idetu"].ToString() != Properties.Settings.Default.idetu && first == 0)
                            {
                                NotifyPopup("Nouveau message de " + dt.Rows[id - 1]["idetu"].ToString(), dt.Rows[id - 1]["msg"].ToString(), t);
                            }
                        }
                    }
                    else if (id > txtbox_message.Lines.Length - 2)//Si le chat local est deja rempli, on regarde si il y a un nouveau message dans la bdd 
                    {
                        txtbox_message.Text += "\n" + "(" + dt.Rows[id - 1]["time"].ToString() + " / " + dt.Rows[id - 1]["idetu"].ToString() + ") :  " + dt.Rows[id - 1]["msg"].ToString();
                        txtbox_message.SelectionStart = txtbox_message.TextLength;
                        txtbox_message.ScrollToCaret();
                        if (sound == true && dt.Rows[id - 1]["idetu"].ToString() != Properties.Settings.Default.idetu && first == 0)
                        {
                            PlayNotificationSound();
                        }
                        if (vis == true && dt.Rows[id - 1]["idetu"].ToString() != Properties.Settings.Default.idetu && first == 0)
                        {
                            NotifyPopup("Nouveau message de " + dt.Rows[id - 1]["idetu"].ToString(), dt.Rows[id - 1]["msg"].ToString(), t);
                        }
                    }
                }
                else//Si la base de donnée est vide
                {
                    txtbox_message.Text = "Bienvenue dans le chat..." + "\n";
                }
                conMsg.Close();
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
        /// Rafraîchit la ListBox passée en paramètre en affichant les élèves connectés.
        /// </summary>
        public static void RefreshOnline(NpgsqlConnection con, ListBox lb_Online)
        {
            try
            {
                DataTable dtOn = new DataTable();
                DataTable dtOff = new DataTable();
                con.Close();
                con.Open();
                NpgsqlCommand cmdOnline = new NpgsqlCommand("SELECT * FROM citise2 where isonline = @IsOnline", con);
                cmdOnline.Parameters.AddWithValue("@IsOnline", 1);
                NpgsqlDataReader dr = cmdOnline.ExecuteReader();
                dtOn.Load(dr);
                if (dtOn.Rows != null)
                {
                    foreach (DataRow drow in dtOn.Rows)
                    {
                        if (lb_Online.Items.Count == 0)
                        {
                            lb_Online.Items.Add(drow["prenom"].ToString() + " " + drow["nom"].ToString());
                        }
                        else
                        {
                            if (lb_Online.Items.Contains(drow["prenom"].ToString() + " " + drow["nom"].ToString()) == false)
                            {
                                lb_Online.Items.Add(drow["prenom"].ToString() + " " + drow["nom"].ToString());
                            }
                        }
                    }
                }
                NpgsqlCommand cmdOffline = new NpgsqlCommand("SELECT * FROM citise2 where isonline = @IsOnline", con);
                cmdOffline.Parameters.AddWithValue("@IsOnline", 0);
                NpgsqlDataReader droff = cmdOffline.ExecuteReader();
                dtOff.Load(droff);
                if (dtOff.Rows != null)
                {
                    foreach (DataRow drow in dtOff.Rows)
                    {
                        if (lb_Online.Items.Contains(drow["prenom"].ToString() + " " + drow["nom"].ToString()))
                        {
                            int off = lb_Online.Items.IndexOf(drow["prenom"].ToString() + " " + drow["nom"].ToString());
                            lb_Online.Items.RemoveAt(off);

                        }
                    }
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
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
