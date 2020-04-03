using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static WindowsFormsApp4.ChatSystem;

namespace WindowsFormsApp4
{

    public partial class connexion : Form
    {
        public NpgsqlConnection con = new NpgsqlConnection("Server=87.91.82.229;Port=5432;" + "User Id=yannMax;Password=admin;Database=database1");
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        public connexion()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "accueil")
                {
                    form.Show();
                }
            }
        }
        private void btn_valider_Click(object sender, EventArgs e)
        {
            btn_valider.Enabled = false;
            try
            {
                con.Open();
                if (txtbx_numetucon.Text != "" && txtbx_mdpcon.Text != "")
                {

                    cmd = new NpgsqlCommand("SELECT * FROM citise2 where Idetu = @Idetu and Password = @Password", con);
                    cmd.Parameters.AddWithValue("@Idetu", txtbx_numetucon.Text);
                    cmd.Parameters.AddWithValue("@Password", txtbx_mdpcon.Text);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (txtbx_numetucon.Text == dr["Idetu"].ToString())
                        {
                            if (txtbx_mdpcon.Text == dr["Password"].ToString())
                            {
                                Properties.Settings.Default.idetu = dr["idetu"].ToString();
                                Properties.Settings.Default.nom = dr["nom"].ToString();
                                Properties.Settings.Default.prenom = dr["prenom"].ToString();
                                Properties.Settings.Default.groupe = dr["groupe"].ToString();
                                Properties.Settings.Default.Save();
                                dr.DisposeAsync();
                                UpdateOnlineState(con, 1);
                                ProjetAccueil n = new ProjetAccueil();
                                n.Show();
                                this.Close();

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Identifiants incorrects");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet");
            }
            con.Close();
            btn_valider.Enabled = true;
        }

        private void lb_forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgot n = new forgot();
            n.Show();
            this.Close();
        }
        private void txtbox_mdpcon_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_valider_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }

}
