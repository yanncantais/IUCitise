namespace WindowsFormsApp4
{
    partial class connexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(connexion));
            this.btn_quitter = new System.Windows.Forms.Button();
            this.label_connexion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbx_mdpcon = new MetroFramework.Controls.MetroTextBox();
            this.txtbx_numetucon = new MetroFramework.Controls.MetroTextBox();
            this.btn_valider = new System.Windows.Forms.Button();
            this.label_mdp = new System.Windows.Forms.Label();
            this.label_numetu = new System.Windows.Forms.Label();
            this.lb_forgot = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btn_quitter
            // 
            this.btn_quitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_quitter.CausesValidation = false;
            this.btn_quitter.FlatAppearance.BorderSize = 0;
            this.btn_quitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quitter.Image = ((System.Drawing.Image)(resources.GetObject("btn_quitter.Image")));
            this.btn_quitter.Location = new System.Drawing.Point(304, 2);
            this.btn_quitter.Margin = new System.Windows.Forms.Padding(4);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(93, 96);
            this.btn_quitter.TabIndex = 16;
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_connexion
            // 
            this.label_connexion.AutoSize = true;
            this.label_connexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_connexion.ForeColor = System.Drawing.Color.Black;
            this.label_connexion.Location = new System.Drawing.Point(18, 13);
            this.label_connexion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_connexion.Name = "label_connexion";
            this.label_connexion.Size = new System.Drawing.Size(128, 29);
            this.label_connexion.TabIndex = 26;
            this.label_connexion.Text = "Connexion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(266, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Veuillez renseigner vos informations.";
            // 
            // txtbx_mdpcon
            // 
            // 
            // 
            // 
            this.txtbx_mdpcon.CustomButton.Image = null;
            this.txtbx_mdpcon.CustomButton.Location = new System.Drawing.Point(276, 1);
            this.txtbx_mdpcon.CustomButton.Name = "";
            this.txtbx_mdpcon.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbx_mdpcon.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_mdpcon.CustomButton.TabIndex = 1;
            this.txtbx_mdpcon.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_mdpcon.CustomButton.UseSelectable = true;
            this.txtbx_mdpcon.CustomButton.Visible = false;
            this.txtbx_mdpcon.ForeColor = System.Drawing.Color.Black;
            this.txtbx_mdpcon.Lines = new string[0];
            this.txtbx_mdpcon.Location = new System.Drawing.Point(47, 289);
            this.txtbx_mdpcon.MaxLength = 32767;
            this.txtbx_mdpcon.Name = "txtbx_mdpcon";
            this.txtbx_mdpcon.PasswordChar = '●';
            this.txtbx_mdpcon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_mdpcon.SelectedText = "";
            this.txtbx_mdpcon.SelectionLength = 0;
            this.txtbx_mdpcon.SelectionStart = 0;
            this.txtbx_mdpcon.ShortcutsEnabled = true;
            this.txtbx_mdpcon.Size = new System.Drawing.Size(298, 23);
            this.txtbx_mdpcon.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_mdpcon.TabIndex = 32;
            this.txtbx_mdpcon.UseCustomBackColor = true;
            this.txtbx_mdpcon.UseCustomForeColor = true;
            this.txtbx_mdpcon.UseSelectable = true;
            this.txtbx_mdpcon.UseStyleColors = true;
            this.txtbx_mdpcon.UseSystemPasswordChar = true;
            this.txtbx_mdpcon.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_mdpcon.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_mdpcon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbox_mdpcon_KeyPress);
            // 
            // txtbx_numetucon
            // 
            // 
            // 
            // 
            this.txtbx_numetucon.CustomButton.Image = null;
            this.txtbx_numetucon.CustomButton.Location = new System.Drawing.Point(276, 1);
            this.txtbx_numetucon.CustomButton.Name = "";
            this.txtbx_numetucon.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtbx_numetucon.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_numetucon.CustomButton.TabIndex = 1;
            this.txtbx_numetucon.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_numetucon.CustomButton.UseSelectable = true;
            this.txtbx_numetucon.CustomButton.Visible = false;
            this.txtbx_numetucon.ForeColor = System.Drawing.Color.Black;
            this.txtbx_numetucon.Lines = new string[0];
            this.txtbx_numetucon.Location = new System.Drawing.Point(47, 219);
            this.txtbx_numetucon.MaxLength = 32767;
            this.txtbx_numetucon.Name = "txtbx_numetucon";
            this.txtbx_numetucon.PasswordChar = '\0';
            this.txtbx_numetucon.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_numetucon.SelectedText = "";
            this.txtbx_numetucon.SelectionLength = 0;
            this.txtbx_numetucon.SelectionStart = 0;
            this.txtbx_numetucon.ShortcutsEnabled = true;
            this.txtbx_numetucon.Size = new System.Drawing.Size(298, 23);
            this.txtbx_numetucon.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_numetucon.TabIndex = 31;
            this.txtbx_numetucon.UseCustomBackColor = true;
            this.txtbx_numetucon.UseCustomForeColor = true;
            this.txtbx_numetucon.UseSelectable = true;
            this.txtbx_numetucon.UseStyleColors = true;
            this.txtbx_numetucon.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_numetucon.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btn_valider.Location = new System.Drawing.Point(105, 430);
            this.btn_valider.Name = "btn_valider";
            this.btn_valider.Size = new System.Drawing.Size(167, 67);
            this.btn_valider.TabIndex = 30;
            this.btn_valider.Text = "Valider";
            this.btn_valider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_valider.UseVisualStyleBackColor = true;
            this.btn_valider.Click += new System.EventHandler(this.btn_valider_Click);
            // 
            // label_mdp
            // 
            this.label_mdp.AutoSize = true;
            this.label_mdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mdp.ForeColor = System.Drawing.Color.Black;
            this.label_mdp.Location = new System.Drawing.Point(43, 266);
            this.label_mdp.Name = "label_mdp";
            this.label_mdp.Size = new System.Drawing.Size(105, 20);
            this.label_mdp.TabIndex = 29;
            this.label_mdp.Text = "Mot de passe";
            // 
            // label_numetu
            // 
            this.label_numetu.AutoSize = true;
            this.label_numetu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numetu.ForeColor = System.Drawing.Color.Black;
            this.label_numetu.Location = new System.Drawing.Point(43, 196);
            this.label_numetu.Name = "label_numetu";
            this.label_numetu.Size = new System.Drawing.Size(188, 20);
            this.label_numetu.TabIndex = 28;
            this.label_numetu.Text = "Id étudiant (nom.prenom)";
            // 
            // lb_forgot
            // 
            this.lb_forgot.ActiveLinkColor = System.Drawing.Color.White;
            this.lb_forgot.AutoSize = true;
            this.lb_forgot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_forgot.ForeColor = System.Drawing.Color.Black;
            this.lb_forgot.LinkColor = System.Drawing.Color.Black;
            this.lb_forgot.Location = new System.Drawing.Point(107, 363);
            this.lb_forgot.Name = "lb_forgot";
            this.lb_forgot.Size = new System.Drawing.Size(164, 20);
            this.lb_forgot.TabIndex = 33;
            this.lb_forgot.TabStop = true;
            this.lb_forgot.Text = "Mot de passe oublié ?";
            this.lb_forgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_forgot_LinkClicked);
            // 
            // connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(400, 550);
            this.Controls.Add(this.lb_forgot);
            this.Controls.Add(this.txtbx_mdpcon);
            this.Controls.Add(this.txtbx_numetucon);
            this.Controls.Add(this.btn_valider);
            this.Controls.Add(this.label_mdp);
            this.Controls.Add(this.label_numetu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_connexion);
            this.Controls.Add(this.btn_quitter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "connexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_quitter;
        private System.Windows.Forms.Label label_connexion;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroTextBox txtbx_mdpcon;
        private MetroFramework.Controls.MetroTextBox txtbx_numetucon;
        private System.Windows.Forms.Button btn_valider;
        private System.Windows.Forms.Label label_mdp;
        private System.Windows.Forms.Label label_numetu;
        private System.Windows.Forms.LinkLabel lb_forgot;
    }
}