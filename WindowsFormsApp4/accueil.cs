using CefSharp;
using CefSharp.WinForms;
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
    public partial class accueil : Form
    {
        public NpgsqlConnection con = new NpgsqlConnection("Server=87.91.82.229;Port=5432;" + "User Id=yannMax;Password=admin;Database=database1");
        public NpgsqlDataReader dr;
        bool start = false;
        public accueil()
        {
            InitializeComponent();
            CefSettings settings = new CefSettings();
            settings.DisableGpuAcceleration();
            Cef.Initialize(settings);
            Properties.Settings.Default.version = "1.2.2";
            try
            {
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("select * from version", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["version"].ToString() != Properties.Settings.Default.version)
                    {
                        if(MessageBox.Show("La version " + dr["version"].ToString() + " est disponible, veuillez faire la mise à jour", "Mise à jour disponible") == DialogResult.OK){
                            System.Diagnostics.Process.Start("https://drive.google.com/drive/folders/1DQb-ndSJ6zoYu8sr2Ze9H4HHJ8zNrDaw?usp=sharing");
                            start = true;
                        }
                    }
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
                start = true;
            }
            label_version.Text = "V" + Properties.Settings.Default.version;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            inscription n = new inscription();
            n.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            this.Close();
            Cef.Shutdown();
            Application.Exit();
        }

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            connexion n = new connexion();
            n.Show();
            this.Hide();
        }

        private void accueil_Load(object sender, EventArgs e)
        {
            if (start)
            {
                this.Close();
                Application.Exit();
            }
        }
    }
}
