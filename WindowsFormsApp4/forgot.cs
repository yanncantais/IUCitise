using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class forgot : Form
    {
        public NpgsqlConnection con = new NpgsqlConnection("Server=87.91.82.229;Port=5432;" + "User Id=yannMax;Password=admin;Database=database1");
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        string idetu;
        int step = 0;
        int start1 = 1;
        public forgot(int start = 1)
        {
            InitializeComponent();
            start1 = start;
            if(start == 0)
            {
                pan_logquest.Visible = false;
                pan_resetpass.Visible = true;
            }
        }

        private void btn_validerlogforgot_Click(object sender, EventArgs e)
        {
            btn_validerlogforgot.Enabled = false;
            if (start1 == 1)
            {
                if (step == 0)
                {
                    try
                    {
                        con.Open();
                        if (txtbx_numetuforgot.Text != "" && txtbx_quest.Text != "")
                        {

                            cmd = new NpgsqlCommand("SELECT * FROM citise2 where Idetu = @Idetu and Question = @Question", con);
                            cmd.Parameters.AddWithValue("@Idetu", txtbx_numetuforgot.Text);
                            cmd.Parameters.AddWithValue("@Question", txtbx_quest.Text);
                            dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                if (txtbx_numetuforgot.Text == dr["Idetu"].ToString())
                                {
                                    if (txtbx_quest.Text == dr["Question"].ToString())
                                    {
                                        idetu = dr["Idetu"].ToString();
                                        pan_logquest.Visible = false;
                                        pan_resetpass.Visible = true;
                                        step = 1;
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
                }
                else
                {
                    if (txtbx_newpass.Text == txtbox_confpass.Text)
                    {
                        try
                        {
                            var commandText = "UPDATE citise2 SET Password = @Password where Idetu = @Idetu";
                            NpgsqlCommand cmdOnline = new NpgsqlCommand(commandText, con);
                            dr.DisposeAsync();
                            cmdOnline.Parameters.AddWithValue("@Password", txtbx_newpass.Text);
                            cmdOnline.Parameters.AddWithValue("@Idetu", idetu);
                            cmdOnline.ExecuteNonQuery();
                            MessageBox.Show("Mot de passe modifié avec succès");
                        }
                        catch
                        {
                            MessageBox.Show("Erreur lors de la modification du mot de passe");
                        }
                        btn_quitter_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Mots de passe différents");
                    }
                }
            }
            else
            {
                if (txtbx_newpass.Text == txtbox_confpass.Text)
                {
                    con.Close();
                    con.Open();
                    try
                    {
                        var commandText = "UPDATE citise2 SET Password = @Password where Idetu = @Idetu";
                        NpgsqlCommand cmdOnline = new NpgsqlCommand(commandText, con);
                        cmdOnline.Parameters.AddWithValue("@Password", txtbx_newpass.Text);
                        cmdOnline.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                        cmdOnline.ExecuteNonQuery();
                        MessageBox.Show("Mot de passe modifié avec succès");
                    }
                    catch {
                        MessageBox.Show("Erreur lors de la modification du mot de passe");
                    }
                    btn_quitter_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Mots de passe différents");
                }


            }
            btn_validerlogforgot.Enabled = true;

        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            Form accueil = null;
            bool present = false;
            this.Close();
            foreach (Form form in Application.OpenForms)
            {
                if(form.Name == "ProjetAccueil")
                {
                    form.Show();
                    present = true;
                    break;
                }
                else if (form.Name == "accueil")
                {
                    accueil = form;
                }
            }
            if(present == false && accueil != null)
            {
                accueil.Show();
            }

        }

        private void txtbx_quest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_validerlogforgot_Click(sender, e);
        }

        private void txtbox_confpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_validerlogforgot_Click(sender, e);
        }

        private void forgot_Load(object sender, EventArgs e)
        {

        }
    }
}
