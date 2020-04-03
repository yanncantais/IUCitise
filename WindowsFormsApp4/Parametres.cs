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
    public partial class Parametres : Form
    {
        ProjetAccueil proj;
        public Parametres(ProjetAccueil projet)
        {
            InitializeComponent();
            proj = projet;
            txtbox_prenom.Text = Properties.Settings.Default.prenom;
            txtbox_nom.Text = Properties.Settings.Default.nom;
            txtbox_idetu.Text = Properties.Settings.Default.idetu;
            cb_groupe.Text = Properties.Settings.Default.groupe;
            checkBox_notifsound.Checked = proj.CheckBoxNotifSound;
            checkBox_notifvis.Checked = proj.CheckBoxNotifVis;
        }

        private void btn_quitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            proj.TextBoxIcalIUTValue = txtbx_icalIUT.Text;
            proj.TextBoxIcalTSEValue = txtbox_icalTSE.Text;
            proj.CheckBoxNotifVis = checkBox_notifvis.Checked;
            proj.CheckBoxNotifSound = checkBox_notifsound.Checked;
            this.Close();
        }
        public string TextBoxIcalTSEValue
        {
            get
            {
                return txtbox_icalTSE.Text;
            }
            set
            {
                txtbox_icalTSE.Text = value;
            }
        }
        public string TextBoxIcalIUTValue
        {
            get
            {
                return txtbx_icalIUT.Text;
            }
            set
            {
                txtbx_icalIUT.Text = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            forgot changePass = new forgot(0);
            changePass.Show();
        }
    }
}
