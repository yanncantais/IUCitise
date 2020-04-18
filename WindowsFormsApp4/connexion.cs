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
        //On ouvre la connexion au serveur
        public NpgsqlConnection con = new NpgsqlConnection("Server=87.91.82.229;Port=5432;" + "User Id=yannMax;Password=admin;Database=database1");
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        public connexion()
        {
            InitializeComponent();
        }
        //Bouton pour fermer la form
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            //Pour chaque form si c'est l'accueil, on l'ouvre, on revient donc à l'accueil
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "accueil")
                {
                    form.Show();
                }
            }
        }
        //Valider la connexion
        private void btn_valider_Click(object sender, EventArgs e)
        {
            btn_valider.Enabled = false;
            try
            {
                con.Open();
                if (txtbx_numetucon.Text != "" && txtbx_mdpcon.Text != "")
                {
                    #region On vérifie que les informations renseignées correspondent à un profil puis on ouvre l'application
                    //Verification de la personne
                    cmd = new NpgsqlCommand("SELECT * FROM citise2 where Idetu = @Idetu and Password = @Password", con);//Sélectionne la ligne ou l'id et le mdp correspondent
                    cmd.Parameters.AddWithValue("@Idetu", txtbx_numetucon.Text);
                    cmd.Parameters.AddWithValue("@Password", txtbx_mdpcon.Text);
                    dr = cmd.ExecuteReader();
                   
                    if (dr.Read())
                    {
                        if (txtbx_numetucon.Text == dr["Idetu"].ToString())//vérification de l'idetu
                        {
                            if (txtbx_mdpcon.Text == dr["Password"].ToString())//vérification du mot de passe
                            {
                                Properties.Settings.Default.idetu = dr["idetu"].ToString(); //si authentification réussie, les différents paramètres
                                Properties.Settings.Default.nom = dr["nom"].ToString();//de l'utilisateur sont attribués à des variables pour 
                                Properties.Settings.Default.prenom = dr["prenom"].ToString();// les messages personnalisés et tout ce qui touche aux bases de données
                                Properties.Settings.Default.groupe = dr["groupe"].ToString();//une fois dans le ProjetAccueil ( l'appli)
                                Properties.Settings.Default.Save(); //On sauve ces informations
                                dr.DisposeAsync();
                                UpdateOnlineState(con, 1);
                                ProjetAccueil n = new ProjetAccueil();//On ouvre le ProjetAccueil, le coeur de l'application
                                n.Show();
                                this.Close();//On ferme le form de connexion

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Identifiants incorrects");
                    }
                    #endregion
                }
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet");
            }
            con.Close();
            btn_valider.Enabled = true;
        }
        //lien en cas de mdp oublié, on ouvre le form forgot
        private void lb_forgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgot n = new forgot();
            n.Show();
            this.Close();
        }

        //Commande pour pouvoir appuyer sur entrée pour valider le bouton de connexion
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
