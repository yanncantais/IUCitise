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

namespace WindowsFormsApp4
{
    
    public partial class inscription : Form
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=87.91.82.229;Port=5432;" + "User Id=yannMax;Password=admin;Database=database1");
        NpgsqlCommand cmd;
        public inscription()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox6_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox5_Click(object sender, EventArgs e)
        {

        }

        private void btn_quitter_Click(object sender, EventArgs e)
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
            con.Open();
            if (txtbx_mdp.Text == txtbx_cmdp.Text)
            {
                cmd = new NpgsqlCommand("insert into citise2 (Nom, Prenom, Password, Groupe, Idetu, Question)" + " values (@Nom, @Prenom, @Password, @Groupe, @Idetu, @Question)", con);
                cmd.Parameters.AddWithValue("@Nom", txtbx_nom.Text);
                cmd.Parameters.AddWithValue("@Prenom", txtbx_prenom.Text);
                cmd.Parameters.AddWithValue("@Password", txtbx_mdp.Text);
                cmd.Parameters.AddWithValue("@Groupe", cb_groupe.SelectedItem);
                cmd.Parameters.AddWithValue("@Idetu", txtbx_numetu.Text);
                cmd.Parameters.AddWithValue("@Question", txtbx_qstn.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Vous avez fini votre inscription avec succès");
                btn_valider_Click(sender, e);
            }
            else
            {
                MessageBox.Show("erreur de confirmation de mot de passe");
            }
            con.Close();
            btn_valider.Enabled = true;
        }
    }
}
