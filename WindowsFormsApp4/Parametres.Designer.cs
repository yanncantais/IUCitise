namespace WindowsFormsApp4
{
    partial class Parametres
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Parametres));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_quitter = new System.Windows.Forms.Button();
            this.label_nom = new System.Windows.Forms.Label();
            this.txtbx_icalIUT = new MetroFramework.Controls.MetroTextBox();
            this.txtbox_icalTSE = new MetroFramework.Controls.MetroTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_valider = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_notifsound = new System.Windows.Forms.CheckBox();
            this.checkBox_notifvis = new System.Windows.Forms.CheckBox();
            this.txtbox_idetu = new MetroFramework.Controls.MetroTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_groupe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbox_prenom = new MetroFramework.Controls.MetroTextBox();
            this.txtbox_nom = new MetroFramework.Controls.MetroTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Paramètres";
            // 
            // btn_quitter
            // 
            this.btn_quitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_quitter.CausesValidation = false;
            this.btn_quitter.FlatAppearance.BorderSize = 0;
            this.btn_quitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quitter.Image = ((System.Drawing.Image)(resources.GetObject("btn_quitter.Image")));
            this.btn_quitter.Location = new System.Drawing.Point(452, -1);
            this.btn_quitter.Margin = new System.Windows.Forms.Padding(4);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(83, 82);
            this.btn_quitter.TabIndex = 16;
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
            // 
            // label_nom
            // 
            this.label_nom.AutoSize = true;
            this.label_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nom.ForeColor = System.Drawing.Color.Black;
            this.label_nom.Location = new System.Drawing.Point(54, 269);
            this.label_nom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(96, 20);
            this.label_nom.TabIndex = 17;
            this.label_nom.Text = "Lien ical IUT";
            // 
            // txtbx_icalIUT
            // 
            // 
            // 
            // 
            this.txtbx_icalIUT.CustomButton.Image = null;
            this.txtbx_icalIUT.CustomButton.Location = new System.Drawing.Point(371, 2);
            this.txtbx_icalIUT.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_icalIUT.CustomButton.Name = "";
            this.txtbx_icalIUT.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtbx_icalIUT.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_icalIUT.CustomButton.TabIndex = 1;
            this.txtbx_icalIUT.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_icalIUT.CustomButton.UseSelectable = true;
            this.txtbx_icalIUT.CustomButton.Visible = false;
            this.txtbx_icalIUT.ForeColor = System.Drawing.Color.Black;
            this.txtbx_icalIUT.Lines = new string[0];
            this.txtbx_icalIUT.Location = new System.Drawing.Point(58, 298);
            this.txtbx_icalIUT.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_icalIUT.MaxLength = 32767;
            this.txtbx_icalIUT.Name = "txtbx_icalIUT";
            this.txtbx_icalIUT.PasswordChar = '\0';
            this.txtbx_icalIUT.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_icalIUT.SelectedText = "";
            this.txtbx_icalIUT.SelectionLength = 0;
            this.txtbx_icalIUT.SelectionStart = 0;
            this.txtbx_icalIUT.ShortcutsEnabled = true;
            this.txtbx_icalIUT.Size = new System.Drawing.Size(397, 28);
            this.txtbx_icalIUT.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_icalIUT.TabIndex = 18;
            this.txtbx_icalIUT.UseCustomBackColor = true;
            this.txtbx_icalIUT.UseCustomForeColor = true;
            this.txtbx_icalIUT.UseSelectable = true;
            this.txtbx_icalIUT.UseStyleColors = true;
            this.txtbx_icalIUT.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_icalIUT.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtbox_icalTSE
            // 
            // 
            // 
            // 
            this.txtbox_icalTSE.CustomButton.Image = null;
            this.txtbox_icalTSE.CustomButton.Location = new System.Drawing.Point(371, 2);
            this.txtbox_icalTSE.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_icalTSE.CustomButton.Name = "";
            this.txtbox_icalTSE.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtbox_icalTSE.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_icalTSE.CustomButton.TabIndex = 1;
            this.txtbox_icalTSE.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_icalTSE.CustomButton.UseSelectable = true;
            this.txtbox_icalTSE.CustomButton.Visible = false;
            this.txtbox_icalTSE.ForeColor = System.Drawing.Color.Black;
            this.txtbox_icalTSE.Lines = new string[0];
            this.txtbox_icalTSE.Location = new System.Drawing.Point(58, 372);
            this.txtbox_icalTSE.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_icalTSE.MaxLength = 32767;
            this.txtbox_icalTSE.Name = "txtbox_icalTSE";
            this.txtbox_icalTSE.PasswordChar = '\0';
            this.txtbox_icalTSE.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_icalTSE.SelectedText = "";
            this.txtbox_icalTSE.SelectionLength = 0;
            this.txtbox_icalTSE.SelectionStart = 0;
            this.txtbox_icalTSE.ShortcutsEnabled = true;
            this.txtbox_icalTSE.Size = new System.Drawing.Size(397, 28);
            this.txtbox_icalTSE.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbox_icalTSE.TabIndex = 20;
            this.txtbox_icalTSE.UseCustomBackColor = true;
            this.txtbox_icalTSE.UseCustomForeColor = true;
            this.txtbox_icalTSE.UseSelectable = true;
            this.txtbox_icalTSE.UseStyleColors = true;
            this.txtbox_icalTSE.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_icalTSE.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(54, 343);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Lien ical TSE";
            // 
            // btn_valider
            // 
            this.btn_valider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_valider.CausesValidation = false;
            this.btn_valider.FlatAppearance.BorderSize = 0;
            this.btn_valider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_valider.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_valider.ForeColor = System.Drawing.Color.Black;
            this.btn_valider.Image = ((System.Drawing.Image)(resources.GetObject("btn_valider.Image")));
            this.btn_valider.Location = new System.Drawing.Point(193, 572);
            this.btn_valider.Margin = new System.Windows.Forms.Padding(4);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(144, 82);
            this.btn_valider.TabIndex = 21;
            this.btn_valider.Text = "Valider";
            this.btn_valider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(397, 26);
            this.button1.TabIndex = 22;
            this.button1.Text = "Modifier le mot de passe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_notifsound
            // 
            this.checkBox_notifsound.AutoSize = true;
            this.checkBox_notifsound.Checked = true;
            this.checkBox_notifsound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_notifsound.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_notifsound.Location = new System.Drawing.Point(58, 493);
            this.checkBox_notifsound.Name = "checkBox_notifsound";
            this.checkBox_notifsound.Size = new System.Drawing.Size(201, 19);
            this.checkBox_notifsound.TabIndex = 23;
            this.checkBox_notifsound.Text = "Autoriser le son des notifications";
            this.checkBox_notifsound.UseVisualStyleBackColor = true;
            // 
            // checkBox_notifvis
            // 
            this.checkBox_notifvis.AutoSize = true;
            this.checkBox_notifvis.Checked = true;
            this.checkBox_notifvis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_notifvis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_notifvis.Location = new System.Drawing.Point(265, 493);
            this.checkBox_notifvis.Name = "checkBox_notifvis";
            this.checkBox_notifvis.Size = new System.Drawing.Size(211, 19);
            this.checkBox_notifvis.TabIndex = 24;
            this.checkBox_notifvis.Text = "Autoriser les notifications visuelles";
            this.checkBox_notifvis.UseVisualStyleBackColor = true;
            // 
            // txtbox_idetu
            // 
            // 
            // 
            // 
            this.txtbox_idetu.CustomButton.Image = null;
            this.txtbox_idetu.CustomButton.Location = new System.Drawing.Point(151, 2);
            this.txtbox_idetu.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_idetu.CustomButton.Name = "";
            this.txtbox_idetu.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtbox_idetu.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_idetu.CustomButton.TabIndex = 1;
            this.txtbox_idetu.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_idetu.CustomButton.UseSelectable = true;
            this.txtbox_idetu.CustomButton.Visible = false;
            this.txtbox_idetu.Enabled = false;
            this.txtbox_idetu.ForeColor = System.Drawing.Color.Black;
            this.txtbox_idetu.Lines = new string[0];
            this.txtbox_idetu.Location = new System.Drawing.Point(58, 232);
            this.txtbox_idetu.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_idetu.MaxLength = 32767;
            this.txtbox_idetu.Name = "txtbox_idetu";
            this.txtbox_idetu.PasswordChar = '\0';
            this.txtbox_idetu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_idetu.SelectedText = "";
            this.txtbox_idetu.SelectionLength = 0;
            this.txtbox_idetu.SelectionStart = 0;
            this.txtbox_idetu.ShortcutsEnabled = true;
            this.txtbox_idetu.Size = new System.Drawing.Size(177, 28);
            this.txtbox_idetu.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbox_idetu.TabIndex = 26;
            this.txtbox_idetu.UseCustomBackColor = true;
            this.txtbox_idetu.UseCustomForeColor = true;
            this.txtbox_idetu.UseSelectable = true;
            this.txtbox_idetu.UseStyleColors = true;
            this.txtbox_idetu.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_idetu.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(54, 203);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Id étudiant";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(274, 203);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Groupe";
            // 
            // cb_groupe
            // 
            this.cb_groupe.BackColor = System.Drawing.SystemColors.Control;
            this.cb_groupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_groupe.DropDownWidth = 396;
            this.cb_groupe.Enabled = false;
            this.cb_groupe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_groupe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_groupe.ForeColor = System.Drawing.Color.Black;
            this.cb_groupe.FormattingEnabled = true;
            this.cb_groupe.IntegralHeight = false;
            this.cb_groupe.Items.AddRange(new object[] {
            "A1",
            "A2",
            "B1",
            "B2"});
            this.cb_groupe.Location = new System.Drawing.Point(278, 232);
            this.cb_groupe.Margin = new System.Windows.Forms.Padding(4);
            this.cb_groupe.Name = "cb_groupe";
            this.cb_groupe.Size = new System.Drawing.Size(177, 28);
            this.cb_groupe.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(54, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 29;
            this.label5.Text = "Prénom";
            // 
            // txtbox_prenom
            // 
            // 
            // 
            // 
            this.txtbox_prenom.CustomButton.Image = null;
            this.txtbox_prenom.CustomButton.Location = new System.Drawing.Point(371, 2);
            this.txtbox_prenom.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_prenom.CustomButton.Name = "";
            this.txtbox_prenom.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtbox_prenom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_prenom.CustomButton.TabIndex = 1;
            this.txtbox_prenom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_prenom.CustomButton.UseSelectable = true;
            this.txtbox_prenom.CustomButton.Visible = false;
            this.txtbox_prenom.Enabled = false;
            this.txtbox_prenom.ForeColor = System.Drawing.Color.Black;
            this.txtbox_prenom.Lines = new string[0];
            this.txtbox_prenom.Location = new System.Drawing.Point(58, 90);
            this.txtbox_prenom.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_prenom.MaxLength = 32767;
            this.txtbox_prenom.Name = "txtbox_prenom";
            this.txtbox_prenom.PasswordChar = '\0';
            this.txtbox_prenom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_prenom.SelectedText = "";
            this.txtbox_prenom.SelectionLength = 0;
            this.txtbox_prenom.SelectionStart = 0;
            this.txtbox_prenom.ShortcutsEnabled = true;
            this.txtbox_prenom.Size = new System.Drawing.Size(397, 28);
            this.txtbox_prenom.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbox_prenom.TabIndex = 30;
            this.txtbox_prenom.UseCustomBackColor = true;
            this.txtbox_prenom.UseCustomForeColor = true;
            this.txtbox_prenom.UseSelectable = true;
            this.txtbox_prenom.UseStyleColors = true;
            this.txtbox_prenom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_prenom.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtbox_nom
            // 
            // 
            // 
            // 
            this.txtbox_nom.CustomButton.Image = null;
            this.txtbox_nom.CustomButton.Location = new System.Drawing.Point(371, 2);
            this.txtbox_nom.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_nom.CustomButton.Name = "";
            this.txtbox_nom.CustomButton.Size = new System.Drawing.Size(23, 23);
            this.txtbox_nom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_nom.CustomButton.TabIndex = 1;
            this.txtbox_nom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_nom.CustomButton.UseSelectable = true;
            this.txtbox_nom.CustomButton.Visible = false;
            this.txtbox_nom.Enabled = false;
            this.txtbox_nom.ForeColor = System.Drawing.Color.Black;
            this.txtbox_nom.Lines = new string[0];
            this.txtbox_nom.Location = new System.Drawing.Point(58, 160);
            this.txtbox_nom.Margin = new System.Windows.Forms.Padding(4);
            this.txtbox_nom.MaxLength = 32767;
            this.txtbox_nom.Name = "txtbox_nom";
            this.txtbox_nom.PasswordChar = '\0';
            this.txtbox_nom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_nom.SelectedText = "";
            this.txtbox_nom.SelectionLength = 0;
            this.txtbox_nom.SelectionStart = 0;
            this.txtbox_nom.ShortcutsEnabled = true;
            this.txtbox_nom.Size = new System.Drawing.Size(397, 28);
            this.txtbox_nom.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbox_nom.TabIndex = 32;
            this.txtbox_nom.UseCustomBackColor = true;
            this.txtbox_nom.UseCustomForeColor = true;
            this.txtbox_nom.UseSelectable = true;
            this.txtbox_nom.UseStyleColors = true;
            this.txtbox_nom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_nom.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(54, 131);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Nom";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 534);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(407, 18);
            this.label7.TabIndex = 33;
            this.label7.Text = "Pour les champs en gris, veuillez contacter un administrateur";
            // 
            // Parametres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(533, 667);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtbox_nom);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtbox_prenom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cb_groupe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbox_idetu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox_notifvis);
            this.Controls.Add(this.checkBox_notifsound);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.txtbox_icalTSE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbx_icalIUT);
            this.Controls.Add(this.label_nom);
            this.Controls.Add(this.btn_quitter);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Parametres";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametres";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_quitter;
        private System.Windows.Forms.Label label_nom;
        private MetroFramework.Controls.MetroTextBox txtbx_icalIUT;
        private MetroFramework.Controls.MetroTextBox txtbox_icalTSE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_valider;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_notifsound;
        private System.Windows.Forms.CheckBox checkBox_notifvis;
        private MetroFramework.Controls.MetroTextBox txtbox_idetu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_groupe;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox txtbox_prenom;
        private MetroFramework.Controls.MetroTextBox txtbox_nom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}