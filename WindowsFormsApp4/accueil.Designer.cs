namespace WindowsFormsApp4
{
    partial class accueil
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(accueil));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_inscription = new System.Windows.Forms.Button();
            this.btn_connexion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_quitter = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label_version = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(307, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 78);
            this.label1.TabIndex = 1;
            this.label1.Text = "IUCitise";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseCompatibleTextRendering = true;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btn_inscription
            // 
            this.btn_inscription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_inscription.FlatAppearance.BorderSize = 0;
            this.btn_inscription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_inscription.ForeColor = System.Drawing.Color.Black;
            this.btn_inscription.Image = ((System.Drawing.Image)(resources.GetObject("btn_inscription.Image")));
            this.btn_inscription.Location = new System.Drawing.Point(149, 248);
            this.btn_inscription.Name = "btn_inscription";
            this.btn_inscription.Size = new System.Drawing.Size(197, 90);
            this.btn_inscription.TabIndex = 0;
            this.btn_inscription.Text = "Inscription";
            this.btn_inscription.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_inscription.UseVisualStyleBackColor = true;
            this.btn_inscription.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_connexion
            // 
            this.btn_connexion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_connexion.FlatAppearance.BorderSize = 0;
            this.btn_connexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_connexion.ForeColor = System.Drawing.Color.Black;
            this.btn_connexion.Image = ((System.Drawing.Image)(resources.GetObject("btn_connexion.Image")));
            this.btn_connexion.Location = new System.Drawing.Point(391, 248);
            this.btn_connexion.Name = "btn_connexion";
            this.btn_connexion.Size = new System.Drawing.Size(197, 90);
            this.btn_connexion.TabIndex = 1;
            this.btn_connexion.Text = "Connexion";
            this.btn_connexion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_connexion.UseVisualStyleBackColor = true;
            this.btn_connexion.Click += new System.EventHandler(this.btn_connexion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(105, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1065, 185);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bienvenue sur le logiciel de gestion de Citise.\r\n\r\nCette plateforme a pour but de" +
    " réunir les ressources de l\'iut et de télécom.\r\n\r\nIdentifiez vous pour commencer" +
    "";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_quitter);
            this.panel1.Location = new System.Drawing.Point(665, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(84, 90);
            this.panel1.TabIndex = 3;
            // 
            // btn_quitter
            // 
            this.btn_quitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_quitter.CausesValidation = false;
            this.btn_quitter.FlatAppearance.BorderSize = 0;
            this.btn_quitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quitter.Image = ((System.Drawing.Image)(resources.GetObject("btn_quitter.Image")));
            this.btn_quitter.Location = new System.Drawing.Point(17, 3);
            this.btn_quitter.Name = "btn_quitter";
            this.btn_quitter.Size = new System.Drawing.Size(62, 67);
            this.btn_quitter.TabIndex = 0;
            this.btn_quitter.UseVisualStyleBackColor = true;
            this.btn_quitter.Click += new System.EventHandler(this.btn_quitter_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(199, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(738, 37);
            this.label3.TabIndex = 4;
            this.label3.Text = "Développé par Yann CANTAIS et Maxime PERRIN";
            // 
            // label_version
            // 
            this.label_version.AutoSize = true;
            this.label_version.ForeColor = System.Drawing.Color.Gray;
            this.label_version.Location = new System.Drawing.Point(3, 373);
            this.label_version.Name = "label_version";
            this.label_version.Size = new System.Drawing.Size(126, 37);
            this.label_version.TabIndex = 5;
            this.label_version.Text = "Version";
            // 
            // accueil
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(750, 400);
            this.Controls.Add(this.label_version);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_connexion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_inscription);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "accueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestionnaire CiTiSE";
            this.Load += new System.EventHandler(this.accueil_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_inscription;
        private System.Windows.Forms.Button btn_connexion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_quitter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_version;
    }
}

