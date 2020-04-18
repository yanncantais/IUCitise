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
        //On ouvre une connexion au serveur sur lequel est hebergée la base de donnée.
        public NpgsqlConnection con = new NpgsqlConnection("Server=87.91.82.229;Port=5432;" + "User Id=yannMax;Password=admin;Database=database1");
        public NpgsqlDataReader dr;
        bool start = false;
        public accueil()
        {
            InitializeComponent();
            CefSettings settings = new CefSettings();
            settings.Locale = "fr";
            settings.DisableGpuAcceleration(); //Affichage des chromebrowser sans décalage
            Cef.Initialize(settings); //Initialiser les settings cefsharp
            Properties.Settings.Default.version = "1.3.0";
            try
            {
                con.Open();
                //Requête sql 
                NpgsqlCommand cmd = new NpgsqlCommand("select * from version", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr["version"].ToString() != Properties.Settings.Default.version)
                    {
                        //Requete pour proposer une maj si l'utilisateur est sur un ancien setup
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
        //bouton inscription
        private void button1_Click(object sender, EventArgs e)
        {
            
            //On ouvre une nouvelle form
            inscription n = new inscription();
            n.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        //Bouton pour quitter l'application
        private void btn_quitter_Click(object sender, EventArgs e)
        {
            this.Close();
            Cef.Shutdown();
            Application.Exit();
        }
        //bouton connexion
        private void btn_connexion_Click(object sender, EventArgs e)
        {
            connexion n = new connexion();//Nouvelle form connexion
            n.Show();
            this.Hide();//On masque cette form
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
