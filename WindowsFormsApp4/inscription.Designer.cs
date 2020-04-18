namespace WindowsFormsApp4
{
    partial class inscription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(inscription));
            this.label1 = new System.Windows.Forms.Label();
            this.label_nom = new System.Windows.Forms.Label();
            this.label_prenom = new System.Windows.Forms.Label();
            this.label_numetu = new System.Windows.Forms.Label();
            this.label_groupe = new System.Windows.Forms.Label();
            this.label_cmdp = new System.Windows.Forms.Label();
            this.label_mdp = new System.Windows.Forms.Label();
            this.btn_quitter = new System.Windows.Forms.Button();
            this.btn_valider = new System.Windows.Forms.Button();
            this.txtbx_nom = new MetroFramework.Controls.MetroTextBox();
            this.txtbx_prenom = new MetroFramework.Controls.MetroTextBox();
            this.txtbx_numetu = new MetroFramework.Controls.MetroTextBox();
            this.txtbx_mdp = new MetroFramework.Controls.MetroTextBox();
            this.txtbx_cmdp = new MetroFramework.Controls.MetroTextBox();
            this.label_qstn = new System.Windows.Forms.Label();
            this.txtbx_qstn = new MetroFramework.Controls.MetroTextBox();
            this.cb_groupe = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inscription";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_nom
            // 
            this.label_nom.AutoSize = true;
            this.label_nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nom.ForeColor = System.Drawing.Color.Black;
            this.label_nom.Location = new System.Drawing.Point(61, 60);
            this.label_nom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_nom.Name = "label_nom";
            this.label_nom.Size = new System.Drawing.Size(86, 37);
            this.label_nom.TabIndex = 3;
            this.label_nom.Text = "Nom";
            // 
            // label_prenom
            // 
            this.label_prenom.AutoSize = true;
            this.label_prenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_prenom.ForeColor = System.Drawing.Color.Black;
            this.label_prenom.Location = new System.Drawing.Point(61, 135);
            this.label_prenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_prenom.Name = "label_prenom";
            this.label_prenom.Size = new System.Drawing.Size(129, 37);
            this.label_prenom.TabIndex = 5;
            this.label_prenom.Text = "Prénom";
            this.label_prenom.Click += new System.EventHandler(this.label3_Click);
            // 
            // label_numetu
            // 
            this.label_numetu.AutoSize = true;
            this.label_numetu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numetu.ForeColor = System.Drawing.Color.Black;
            this.label_numetu.Location = new System.Drawing.Point(61, 207);
            this.label_numetu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_numetu.Name = "label_numetu";
            this.label_numetu.Size = new System.Drawing.Size(378, 37);
            this.label_numetu.TabIndex = 7;
            this.label_numetu.Text = "Id étudiant (nom.prenom)";
            // 
            // label_groupe
            // 
            this.label_groupe.AutoSize = true;
            this.label_groupe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_groupe.ForeColor = System.Drawing.Color.Black;
            this.label_groupe.Location = new System.Drawing.Point(61, 278);
            this.label_groupe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_groupe.Name = "label_groupe";
            this.label_groupe.Size = new System.Drawing.Size(124, 37);
            this.label_groupe.TabIndex = 9;
            this.label_groupe.Text = "Groupe";
            // 
            // label_cmdp
            // 
            this.label_cmdp.AutoSize = true;
            this.label_cmdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_cmdp.ForeColor = System.Drawing.Color.Black;
            this.label_cmdp.Location = new System.Drawing.Point(61, 425);
            this.label_cmdp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_cmdp.Name = "label_cmdp";
            this.label_cmdp.Size = new System.Drawing.Size(446, 37);
            this.label_cmdp.TabIndex = 13;
            this.label_cmdp.Text = "Confirmation du mot de passe";
            this.label_cmdp.Click += new System.EventHandler(this.label6_Click);
            // 
            // label_mdp
            // 
            this.label_mdp.AutoSize = true;
            this.label_mdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mdp.ForeColor = System.Drawing.Color.Black;
            this.label_mdp.Location = new System.Drawing.Point(61, 350);
            this.label_mdp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_mdp.Name = "label_mdp";
            this.label_mdp.Size = new System.Drawing.Size(208, 37);
            this.label_mdp.TabIndex = 11;
            this.label_mdp.Text = "Mot de passe";
            this.label_mdp.Click += new System.EventHandler(this.label7_Click);
            // 
            // btn_quitter
            // 
            this.btn_quitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_quitter.CausesValidation = false;
            this.btn_quitter.FlatAppearance.BorderSize = 0;
            this.btn_quitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quitter.Image = ((System.Drawing.Image)(resources.GetObject("btn_quitter.Image")));
            this.btn_quitter.Location = new System.Drawing.Point(447, 2);
            this.btn_quitter.Margin = new System.Windows.Forms.Padding(4);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(83, 82);
            this.btn_quitter.TabIndex = 15;
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
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
            this.btn_valider.Location = new System.Drawing.Point(169, 566);
            this.btn_valider.Margin = new System.Windows.Forms.Padding(4);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(195, 82);
            this.btn_valider.TabIndex = 16;
            this.btn_valider.Text = "Valider";
            this.btn_valider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // txtbx_nom
            // 
            // 
            // 
            // 
            this.txtbx_nom.CustomButton.Image = null;
            this.txtbx_nom.CustomButton.Location = new System.Drawing.Point(375, 1);
            this.txtbx_nom.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_nom.CustomButton.Name = "";
            this.txtbx_nom.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbx_nom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_nom.CustomButton.TabIndex = 1;
            this.txtbx_nom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_nom.CustomButton.UseSelectable = true;
            this.txtbx_nom.CustomButton.Visible = false;
            this.txtbx_nom.ForeColor = System.Drawing.Color.Black;
            this.txtbx_nom.Lines = new string[0];
            this.txtbx_nom.Location = new System.Drawing.Point(67, 92);
            this.txtbx_nom.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_nom.MaxLength = 32767;
            this.txtbx_nom.Name = "txtbx_nom";
            this.txtbx_nom.PasswordChar = '\0';
            this.txtbx_nom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_nom.SelectedText = "";
            this.txtbx_nom.SelectionLength = 0;
            this.txtbx_nom.SelectionStart = 0;
            this.txtbx_nom.ShortcutsEnabled = true;
            this.txtbx_nom.Size = new System.Drawing.Size(397, 23);
            this.txtbx_nom.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_nom.TabIndex = 17;
            this.txtbx_nom.UseCustomBackColor = true;
            this.txtbx_nom.UseCustomForeColor = true;
            this.txtbx_nom.UseSelectable = true;
            this.txtbx_nom.UseStyleColors = true;
            this.txtbx_nom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_nom.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtbx_prenom
            // 
            // 
            // 
            // 
            this.txtbx_prenom.CustomButton.Image = null;
            this.txtbx_prenom.CustomButton.Location = new System.Drawing.Point(375, 1);
            this.txtbx_prenom.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_prenom.CustomButton.Name = "";
            this.txtbx_prenom.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbx_prenom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_prenom.CustomButton.TabIndex = 1;
            this.txtbx_prenom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_prenom.CustomButton.UseSelectable = true;
            this.txtbx_prenom.CustomButton.Visible = false;
            this.txtbx_prenom.ForeColor = System.Drawing.Color.Black;
            this.txtbx_prenom.Lines = new string[0];
            this.txtbx_prenom.Location = new System.Drawing.Point(67, 164);
            this.txtbx_prenom.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_prenom.MaxLength = 32767;
            this.txtbx_prenom.Name = "txtbx_prenom";
            this.txtbx_prenom.PasswordChar = '\0';
            this.txtbx_prenom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_prenom.SelectedText = "";
            this.txtbx_prenom.SelectionLength = 0;
            this.txtbx_prenom.SelectionStart = 0;
            this.txtbx_prenom.ShortcutsEnabled = true;
            this.txtbx_prenom.Size = new System.Drawing.Size(397, 23);
            this.txtbx_prenom.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_prenom.TabIndex = 18;
            this.txtbx_prenom.UseCustomBackColor = true;
            this.txtbx_prenom.UseCustomForeColor = true;
            this.txtbx_prenom.UseSelectable = true;
            this.txtbx_prenom.UseStyleColors = true;
            this.txtbx_prenom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_prenom.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtbx_numetu
            // 
            // 
            // 
            // 
            this.txtbx_numetu.CustomButton.Image = null;
            this.txtbx_numetu.CustomButton.Location = new System.Drawing.Point(375, 1);
            this.txtbx_numetu.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_numetu.CustomButton.Name = "";
            this.txtbx_numetu.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbx_numetu.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_numetu.CustomButton.TabIndex = 1;
            this.txtbx_numetu.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_numetu.CustomButton.UseSelectable = true;
            this.txtbx_numetu.CustomButton.Visible = false;
            this.txtbx_numetu.ForeColor = System.Drawing.Color.Black;
            this.txtbx_numetu.Lines = new string[0];
            this.txtbx_numetu.Location = new System.Drawing.Point(67, 235);
            this.txtbx_numetu.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_numetu.MaxLength = 32767;
            this.txtbx_numetu.Name = "txtbx_numetu";
            this.txtbx_numetu.PasswordChar = '\0';
            this.txtbx_numetu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_numetu.SelectedText = "";
            this.txtbx_numetu.SelectionLength = 0;
            this.txtbx_numetu.SelectionStart = 0;
            this.txtbx_numetu.ShortcutsEnabled = true;
            this.txtbx_numetu.Size = new System.Drawing.Size(397, 23);
            this.txtbx_numetu.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_numetu.TabIndex = 19;
            this.txtbx_numetu.UseCustomBackColor = true;
            this.txtbx_numetu.UseCustomForeColor = true;
            this.txtbx_numetu.UseSelectable = true;
            this.txtbx_numetu.UseStyleColors = true;
            this.txtbx_numetu.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_numetu.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtbx_mdp
            // 
            // 
            // 
            // 
            this.txtbx_mdp.CustomButton.Image = null;
            this.txtbx_mdp.CustomButton.Location = new System.Drawing.Point(375, 1);
            this.txtbx_mdp.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_mdp.CustomButton.Name = "";
            this.txtbx_mdp.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbx_mdp.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_mdp.CustomButton.TabIndex = 1;
            this.txtbx_mdp.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_mdp.CustomButton.UseSelectable = true;
            this.txtbx_mdp.CustomButton.Visible = false;
            this.txtbx_mdp.ForeColor = System.Drawing.Color.Black;
            this.txtbx_mdp.Lines = new string[0];
            this.txtbx_mdp.Location = new System.Drawing.Point(67, 379);
            this.txtbx_mdp.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_mdp.MaxLength = 32767;
            this.txtbx_mdp.Name = "txtbx_mdp";
            this.txtbx_mdp.PasswordChar = '●';
            this.txtbx_mdp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_mdp.SelectedText = "";
            this.txtbx_mdp.SelectionLength = 0;
            this.txtbx_mdp.SelectionStart = 0;
            this.txtbx_mdp.ShortcutsEnabled = true;
            this.txtbx_mdp.Size = new System.Drawing.Size(397, 23);
            this.txtbx_mdp.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_mdp.TabIndex = 21;
            this.txtbx_mdp.UseCustomBackColor = true;
            this.txtbx_mdp.UseCustomForeColor = true;
            this.txtbx_mdp.UseSelectable = true;
            this.txtbx_mdp.UseStyleColors = true;
            this.txtbx_mdp.UseSystemPasswordChar = true;
            this.txtbx_mdp.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_mdp.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtbx_cmdp
            // 
            // 
            // 
            // 
            this.txtbx_cmdp.CustomButton.Image = null;
            this.txtbx_cmdp.CustomButton.Location = new System.Drawing.Point(375, 1);
            this.txtbx_cmdp.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_cmdp.CustomButton.Name = "";
            this.txtbx_cmdp.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbx_cmdp.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_cmdp.CustomButton.TabIndex = 1;
            this.txtbx_cmdp.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_cmdp.CustomButton.UseSelectable = true;
            this.txtbx_cmdp.CustomButton.Visible = false;
            this.txtbx_cmdp.ForeColor = System.Drawing.Color.Black;
            this.txtbx_cmdp.Lines = new string[0];
            this.txtbx_cmdp.Location = new System.Drawing.Point(67, 453);
            this.txtbx_cmdp.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_cmdp.MaxLength = 32767;
            this.txtbx_cmdp.Name = "txtbx_cmdp";
            this.txtbx_cmdp.PasswordChar = '●';
            this.txtbx_cmdp.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_cmdp.SelectedText = "";
            this.txtbx_cmdp.SelectionLength = 0;
            this.txtbx_cmdp.SelectionStart = 0;
            this.txtbx_cmdp.ShortcutsEnabled = true;
            this.txtbx_cmdp.Size = new System.Drawing.Size(397, 23);
            this.txtbx_cmdp.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_cmdp.TabIndex = 22;
            this.txtbx_cmdp.UseCustomBackColor = true;
            this.txtbx_cmdp.UseCustomForeColor = true;
            this.txtbx_cmdp.UseSelectable = true;
            this.txtbx_cmdp.UseStyleColors = true;
            this.txtbx_cmdp.UseSystemPasswordChar = true;
            this.txtbx_cmdp.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_cmdp.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label_qstn
            // 
            this.label_qstn.AutoSize = true;
            this.label_qstn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_qstn.ForeColor = System.Drawing.Color.Black;
            this.label_qstn.Location = new System.Drawing.Point(61, 486);
            this.label_qstn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_qstn.Name = "label_qstn";
            this.label_qstn.Size = new System.Drawing.Size(593, 74);
            this.label_qstn.TabIndex = 23;
            this.label_qstn.Text = "Quel est le nom de votre premier animal \r\nde compagnie ?\r\n";
            // 
            // txtbx_qstn
            // 
            // 
            // 
            // 
            this.txtbx_qstn.CustomButton.Image = null;
            this.txtbx_qstn.CustomButton.Location = new System.Drawing.Point(375, 1);
            this.txtbx_qstn.CustomButton.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_qstn.CustomButton.Name = "";
            this.txtbx_qstn.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbx_qstn.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_qstn.CustomButton.TabIndex = 1;
            this.txtbx_qstn.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_qstn.CustomButton.UseSelectable = true;
            this.txtbx_qstn.CustomButton.Visible = false;
            this.txtbx_qstn.ForeColor = System.Drawing.Color.Black;
            this.txtbx_qstn.Lines = new string[0];
            this.txtbx_qstn.Location = new System.Drawing.Point(67, 539);
            this.txtbx_qstn.Margin = new System.Windows.Forms.Padding(4);
            this.txtbx_qstn.MaxLength = 32767;
            this.txtbx_qstn.Name = "txtbx_qstn";
            this.txtbx_qstn.PasswordChar = '●';
            this.txtbx_qstn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_qstn.SelectedText = "";
            this.txtbx_qstn.SelectionLength = 0;
            this.txtbx_qstn.SelectionStart = 0;
            this.txtbx_qstn.ShortcutsEnabled = true;
            this.txtbx_qstn.Size = new System.Drawing.Size(397, 23);
            this.txtbx_qstn.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_qstn.TabIndex = 24;
            this.txtbx_qstn.UseCustomBackColor = true;
            this.txtbx_qstn.UseCustomForeColor = true;
            this.txtbx_qstn.UseSelectable = true;
            this.txtbx_qstn.UseStyleColors = true;
            this.txtbx_qstn.UseSystemPasswordChar = true;
            this.txtbx_qstn.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_qstn.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // cb_groupe
            // 
            this.cb_groupe.BackColor = System.Drawing.SystemColors.Control;
            this.cb_groupe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_groupe.DropDownWidth = 396;
            this.cb_groupe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_groupe.ForeColor = System.Drawing.Color.Black;
            this.cb_groupe.FormattingEnabled = true;
            this.cb_groupe.IntegralHeight = false;
            this.cb_groupe.Items.AddRange(new object[] {
            "A1",
            "A2",
            "B1",
            "B2"});
            this.cb_groupe.Location = new System.Drawing.Point(67, 306);
            this.cb_groupe.Margin = new System.Windows.Forms.Padding(4);
            this.cb_groupe.Name = "cb_groupe";
            this.cb_groupe.Size = new System.Drawing.Size(396, 33);
            this.cb_groupe.TabIndex = 25;
            // 
            // inscription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(533, 677);
            this.Controls.Add(this.cb_groupe);
            this.Controls.Add(this.txtbx_qstn);
            this.Controls.Add(this.label_qstn);
            this.Controls.Add(this.txtbx_cmdp);
            this.Controls.Add(this.txtbx_mdp);
            this.Controls.Add(this.txtbx_numetu);
            this.Controls.Add(this.txtbx_prenom);
            this.Controls.Add(this.txtbx_nom);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.btn_quitter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_cmdp);
            this.Controls.Add(this.label_mdp);
            this.Controls.Add(this.label_groupe);
            this.Controls.Add(this.label_numetu);
            this.Controls.Add(this.label_prenom);
            this.Controls.Add(this.label_nom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "inscription";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_nom;
        private System.Windows.Forms.Label label_prenom;
        private System.Windows.Forms.Label label_numetu;
        private System.Windows.Forms.Label label_groupe;
        private System.Windows.Forms.Label label_cmdp;
        private System.Windows.Forms.Label label_mdp;
        private System.Windows.Forms.Button btn_quitter;
        private System.Windows.Forms.Button btn_valider;
        private MetroFramework.Controls.MetroTextBox txtbx_nom;
        private MetroFramework.Controls.MetroTextBox txtbx_prenom;
        private MetroFramework.Controls.MetroTextBox txtbx_numetu;
        private MetroFramework.Controls.MetroTextBox txtbx_mdp;
        private MetroFramework.Controls.MetroTextBox txtbx_cmdp;
        private System.Windows.Forms.Label label_qstn;
        private MetroFramework.Controls.MetroTextBox txtbx_qstn;
        private System.Windows.Forms.ComboBox cb_groupe;
    }
}