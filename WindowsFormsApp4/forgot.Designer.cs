namespace WindowsFormsApp4
{
    partial class forgot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forgot));
            this.btn_quitter = new System.Windows.Forms.Button();
            this.label_forgot = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pan_logquest = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbx_quest = new MetroFramework.Controls.MetroTextBox();
            this.txtbx_numetuforgot = new MetroFramework.Controls.MetroTextBox();
            this.label_numetu = new System.Windows.Forms.Label();
            this.btn_validerlogforgot = new System.Windows.Forms.Button();
            this.pan_resetpass = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_confpass = new MetroFramework.Controls.MetroTextBox();
            this.txtbx_newpass = new MetroFramework.Controls.MetroTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pan_logquest.SuspendLayout();
            this.pan_resetpass.SuspendLayout();
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
            this.btn_quitter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(93, 96);
            this.btn_quitter.TabIndex = 17;
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
            // 
            // label_forgot
            // 
            this.label_forgot.AutoSize = true;
            this.label_forgot.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_forgot.ForeColor = System.Drawing.Color.Black;
            this.label_forgot.Location = new System.Drawing.Point(18, 13);
            this.label_forgot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_forgot.Name = "label_forgot";
            this.label_forgot.Size = new System.Drawing.Size(231, 29);
            this.label_forgot.TabIndex = 27;
            this.label_forgot.Text = "Mot de passe oublié";
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
            this.label1.TabIndex = 28;
            this.label1.Text = "Veuillez renseigner vos informations.";
            // 
            // pan_logquest
            // 
            this.pan_logquest.Controls.Add(this.label2);
            this.pan_logquest.Controls.Add(this.txtbx_quest);
            this.pan_logquest.Controls.Add(this.txtbx_numetuforgot);
            this.pan_logquest.Controls.Add(this.label_numetu);
            this.pan_logquest.Location = new System.Drawing.Point(23, 170);
            this.pan_logquest.Name = "pan_logquest";
            this.pan_logquest.Size = new System.Drawing.Size(348, 198);
            this.pan_logquest.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 40);
            this.label2.TabIndex = 34;
            this.label2.Text = "Quel est le nom de votre premier animal \r\nde compagnie ?";
            // 
            // txtbx_quest
            // 
            // 
            // 
            // 
            this.txtbx_quest.CustomButton.Image = null;
            this.txtbx_quest.CustomButton.Location = new System.Drawing.Point(207, 1);
            this.txtbx_quest.CustomButton.Name = "";
            this.txtbx_quest.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtbx_quest.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_quest.CustomButton.TabIndex = 1;
            this.txtbx_quest.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_quest.CustomButton.UseSelectable = true;
            this.txtbx_quest.CustomButton.Visible = false;
            this.txtbx_quest.ForeColor = System.Drawing.Color.Black;
            this.txtbx_quest.Lines = new string[0];
            this.txtbx_quest.Location = new System.Drawing.Point(22, 142);
            this.txtbx_quest.MaxLength = 32767;
            this.txtbx_quest.Name = "txtbx_quest";
            this.txtbx_quest.PasswordChar = '●';
            this.txtbx_quest.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_quest.SelectedText = "";
            this.txtbx_quest.SelectionLength = 0;
            this.txtbx_quest.SelectionStart = 0;
            this.txtbx_quest.ShortcutsEnabled = true;
            this.txtbx_quest.Size = new System.Drawing.Size(298, 23);
            this.txtbx_quest.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_quest.TabIndex = 33;
            this.txtbx_quest.UseCustomBackColor = true;
            this.txtbx_quest.UseCustomForeColor = true;
            this.txtbx_quest.UseSelectable = true;
            this.txtbx_quest.UseStyleColors = true;
            this.txtbx_quest.UseSystemPasswordChar = true;
            this.txtbx_quest.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_quest.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_quest.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbx_quest_KeyDown);
            // 
            // txtbx_numetuforgot
            // 
            // 
            // 
            // 
            this.txtbx_numetuforgot.CustomButton.Image = null;
            this.txtbx_numetuforgot.CustomButton.Location = new System.Drawing.Point(207, 1);
            this.txtbx_numetuforgot.CustomButton.Name = "";
            this.txtbx_numetuforgot.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtbx_numetuforgot.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_numetuforgot.CustomButton.TabIndex = 1;
            this.txtbx_numetuforgot.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_numetuforgot.CustomButton.UseSelectable = true;
            this.txtbx_numetuforgot.CustomButton.Visible = false;
            this.txtbx_numetuforgot.ForeColor = System.Drawing.Color.Black;
            this.txtbx_numetuforgot.Lines = new string[0];
            this.txtbx_numetuforgot.Location = new System.Drawing.Point(22, 50);
            this.txtbx_numetuforgot.MaxLength = 32767;
            this.txtbx_numetuforgot.Name = "txtbx_numetuforgot";
            this.txtbx_numetuforgot.PasswordChar = '\0';
            this.txtbx_numetuforgot.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_numetuforgot.SelectedText = "";
            this.txtbx_numetuforgot.SelectionLength = 0;
            this.txtbx_numetuforgot.SelectionStart = 0;
            this.txtbx_numetuforgot.ShortcutsEnabled = true;
            this.txtbx_numetuforgot.Size = new System.Drawing.Size(298, 23);
            this.txtbx_numetuforgot.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_numetuforgot.TabIndex = 32;
            this.txtbx_numetuforgot.UseCustomBackColor = true;
            this.txtbx_numetuforgot.UseCustomForeColor = true;
            this.txtbx_numetuforgot.UseSelectable = true;
            this.txtbx_numetuforgot.UseStyleColors = true;
            this.txtbx_numetuforgot.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_numetuforgot.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label_numetu
            // 
            this.label_numetu.AutoSize = true;
            this.label_numetu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_numetu.ForeColor = System.Drawing.Color.Black;
            this.label_numetu.Location = new System.Drawing.Point(18, 27);
            this.label_numetu.Name = "label_numetu";
            this.label_numetu.Size = new System.Drawing.Size(87, 20);
            this.label_numetu.TabIndex = 29;
            this.label_numetu.Text = "Id Etudiant";
            // 
            // btn_validerlogforgot
            // 
            this.btn_validerlogforgot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_validerlogforgot.CausesValidation = false;
            this.btn_validerlogforgot.FlatAppearance.BorderSize = 0;
            this.btn_validerlogforgot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_validerlogforgot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_validerlogforgot.ForeColor = System.Drawing.Color.Black;
            this.btn_validerlogforgot.Image = ((System.Drawing.Image)(resources.GetObject("btn_validerlogforgot.Image")));
            this.btn_validerlogforgot.Location = new System.Drawing.Point(105, 430);
            this.btn_validerlogforgot.Name = "btn_validerlogforgot";
            this.btn_validerlogforgot.Size = new System.Drawing.Size(167, 67);
            this.btn_validerlogforgot.TabIndex = 31;
            this.btn_validerlogforgot.Text = "Valider";
            this.btn_validerlogforgot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_validerlogforgot.UseVisualStyleBackColor = true;
            this.btn_validerlogforgot.Click += new System.EventHandler(this.btn_validerlogforgot_Click);
            // 
            // pan_resetpass
            // 
            this.pan_resetpass.Controls.Add(this.label3);
            this.pan_resetpass.Controls.Add(this.txtbox_confpass);
            this.pan_resetpass.Controls.Add(this.txtbx_newpass);
            this.pan_resetpass.Controls.Add(this.label4);
            this.pan_resetpass.Location = new System.Drawing.Point(23, 173);
            this.pan_resetpass.Name = "pan_resetpass";
            this.pan_resetpass.Size = new System.Drawing.Size(348, 198);
            this.pan_resetpass.TabIndex = 35;
            this.pan_resetpass.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(18, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "Confirmer le mot de passe";
            // 
            // txtbox_confpass
            // 
            // 
            // 
            // 
            this.txtbox_confpass.CustomButton.Image = null;
            this.txtbox_confpass.CustomButton.Location = new System.Drawing.Point(207, 1);
            this.txtbox_confpass.CustomButton.Name = "";
            this.txtbox_confpass.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtbox_confpass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbox_confpass.CustomButton.TabIndex = 1;
            this.txtbox_confpass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbox_confpass.CustomButton.UseSelectable = true;
            this.txtbox_confpass.CustomButton.Visible = false;
            this.txtbox_confpass.ForeColor = System.Drawing.Color.Black;
            this.txtbox_confpass.Lines = new string[0];
            this.txtbox_confpass.Location = new System.Drawing.Point(22, 142);
            this.txtbox_confpass.MaxLength = 32767;
            this.txtbox_confpass.Name = "txtbox_confpass";
            this.txtbox_confpass.PasswordChar = '●';
            this.txtbox_confpass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbox_confpass.SelectedText = "";
            this.txtbox_confpass.SelectionLength = 0;
            this.txtbox_confpass.SelectionStart = 0;
            this.txtbox_confpass.ShortcutsEnabled = true;
            this.txtbox_confpass.Size = new System.Drawing.Size(298, 23);
            this.txtbox_confpass.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbox_confpass.TabIndex = 33;
            this.txtbox_confpass.UseCustomBackColor = true;
            this.txtbox_confpass.UseCustomForeColor = true;
            this.txtbox_confpass.UseSelectable = true;
            this.txtbox_confpass.UseStyleColors = true;
            this.txtbox_confpass.UseSystemPasswordChar = true;
            this.txtbox_confpass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbox_confpass.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_confpass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbox_confpass_KeyDown);
            // 
            // txtbx_newpass
            // 
            // 
            // 
            // 
            this.txtbx_newpass.CustomButton.Image = null;
            this.txtbx_newpass.CustomButton.Location = new System.Drawing.Point(207, 1);
            this.txtbx_newpass.CustomButton.Name = "";
            this.txtbx_newpass.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.txtbx_newpass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtbx_newpass.CustomButton.TabIndex = 1;
            this.txtbx_newpass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtbx_newpass.CustomButton.UseSelectable = true;
            this.txtbx_newpass.CustomButton.Visible = false;
            this.txtbx_newpass.ForeColor = System.Drawing.Color.Black;
            this.txtbx_newpass.Lines = new string[0];
            this.txtbx_newpass.Location = new System.Drawing.Point(22, 50);
            this.txtbx_newpass.MaxLength = 32767;
            this.txtbx_newpass.Name = "txtbx_newpass";
            this.txtbx_newpass.PasswordChar = '●';
            this.txtbx_newpass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtbx_newpass.SelectedText = "";
            this.txtbx_newpass.SelectionLength = 0;
            this.txtbx_newpass.SelectionStart = 0;
            this.txtbx_newpass.ShortcutsEnabled = true;
            this.txtbx_newpass.Size = new System.Drawing.Size(298, 23);
            this.txtbx_newpass.Style = MetroFramework.MetroColorStyle.Black;
            this.txtbx_newpass.TabIndex = 32;
            this.txtbx_newpass.UseCustomBackColor = true;
            this.txtbx_newpass.UseCustomForeColor = true;
            this.txtbx_newpass.UseSelectable = true;
            this.txtbx_newpass.UseStyleColors = true;
            this.txtbx_newpass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtbx_newpass.WaterMarkFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Nouveau mot de passe";
            // 
            // forgot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(400, 550);
            this.Controls.Add(this.btn_validerlogforgot);
            this.Controls.Add(this.pan_resetpass);
            this.Controls.Add(this.pan_logquest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_forgot);
            this.Controls.Add(this.btn_quitter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "forgot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forgot";
            this.Load += new System.EventHandler(this.forgot_Load);
            this.pan_logquest.ResumeLayout(false);
            this.pan_logquest.PerformLayout();
            this.pan_resetpass.ResumeLayout(false);
            this.pan_resetpass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_quitter;
        private System.Windows.Forms.Label label_forgot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pan_logquest;
        private System.Windows.Forms.Label label_numetu;
        private MetroFramework.Controls.MetroTextBox txtbx_numetuforgot;
        private MetroFramework.Controls.MetroTextBox txtbx_quest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_validerlogforgot;
        private System.Windows.Forms.Panel pan_resetpass;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroTextBox txtbox_confpass;
        private MetroFramework.Controls.MetroTextBox txtbx_newpass;
        private System.Windows.Forms.Label label4;
    }
}