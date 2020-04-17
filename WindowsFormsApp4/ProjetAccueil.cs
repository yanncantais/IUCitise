using Ical.Net.DataTypes;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using static WindowsFormsApp4.ChatSystem;
using static WindowsFormsApp4.OnlineCalendar;
using static WindowsFormsApp4.MarkSystem;
using static WindowsFormsApp4.NotificationManager;
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using Rectangle = iTextSharp.text.Rectangle;
using System.Threading;
using CefSharp;
using CefSharp.WinForms;
using static WindowsFormsApp4.PopupSystem;
using static WindowsFormsApp4.DownloadSystem;

namespace WindowsFormsApp4
{
    public partial class ProjetAccueil : Form
    {
        public NpgsqlConnection con = new NpgsqlConnection("Server=87.91.82.229;Port=5432;" + "User Id=yannMax;Password=admin;Database=database1");
        public NpgsqlConnection con1 = new NpgsqlConnection("Server=87.91.82.229;Port=5432;" + "User Id=yannMax;Password=admin;Database=database1");
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        bool scrolled = false;
        int first = 1;
        int semestre = 0;
        Thread chatThread;
        bool sound = true;
        bool vis = true;
        public Parametres parametres;
        Point pointChat;
        string calIUT, calTSE;
        ListView[] listlbCal;
        Chart pieChart = new Chart();
        Legend l = new Legend()
        {
            Name = "L1",
            BackColor = Color.Transparent,
            ForeColor = Color.Black,
            Title = "Légend",
            TitleForeColor = Color.Black,
            Docking = Docking.Bottom
        };
        Series sl = new Series()
        {
            Name = "sl",
            IsVisibleInLegend = true,
            Color = Color.Transparent,
            BorderColor = Color.White,
            ChartType = SeriesChartType.Pie
        };
        int identifiantnote = 0;
        public ChromiumWebBrowser chromeBrowser;
        public ChromiumWebBrowser chromeBrowser1;
        public ChromiumWebBrowser chromeBrowser2;

        public ProjetAccueil()
        {
            InitializeComponent();
            this.CenterToScreen();
            chatThread = new Thread(new ThreadStart(ThreadLoop));
            this.Text = "Gestionnaire CiTiSE - " + Properties.Settings.Default.prenom;
            this.button1.Image = (System.Drawing.Image)(new Bitmap(btn_liensujmmootse.Image, new Size(32, 32)));
            this.button2.Image = (System.Drawing.Image)(new Bitmap(btn_quitter.Image, new Size(32, 32)));
            lbl_bonjour.Text = lbl_bonjour.Text + Properties.Settings.Default.prenom + ", nous sommes le " + DateTime.Now.ToShortDateString();
          /*  webBrowser2.Navigate("https://mootse.telecom-st-etienne.fr/login/index.php");
            webBrowser1.Navigate("https://cas.univ-st-etienne.fr/esup-cas/login?service=https://ent.univ-st-etienne.fr/uPortal/Login");
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;*/
            txtbox_message.Text = "Bienvenue dans le chat..." + "\n";
            listlbCal = new ListView[7] { lbCal0,
                         lbCal1,
                         lbCal2,
                         lbCal3,
                         lbCal4,
                         lbCal5,
                         lbCal6,
                    };
            for (int i = 0; i < 7; i++)
            {
                listlbCal[i].ItemSelectionChanged += lbCal_ItemSelectionChanged;
                listlbCal[i].ColumnWidthChanging += lbCal_ColumnWidthChanging;
            }

            pieChart.Size = new Size(375, 375);
            pieChart.Location = new Point(0, 225);
            ChartArea area = new ChartArea("Volume horaire");
            area.BorderWidth = 600;
            pieChart.ChartAreas.Add(area);
            pieChart.Legends.Add(l);
            pieChart.Series.Add(sl);
            tabPage2.Controls.Add(pieChart);

            if (Properties.Settings.Default.idetu == "cantais.yann" || Properties.Settings.Default.idetu == "perrin.maxime")
            {
                btn_cleanchat.Visible = true;
            }
            lb_Online.DrawMode = DrawMode.OwnerDrawFixed;
            lb_Online.DrawItem += new DrawItemEventHandler(listBox_DrawItem);
            lb_Online.Enabled = false;

            lv_nextEval.Columns.Clear();
            lv_nextEval.Items.Clear();
            lv_nextEval.Scrollable = true;
            lv_nextEval.View = View.Details;
            ColumnHeader header = new ColumnHeader();
            header.Text = "Matière";
            header.Name = "Matière";
            lv_nextEval.Columns.Add(header);
            lv_nextEval.Columns[0].Width = 412;
            lv_nextEval.ItemSelectionChanged += lbCal_ItemSelectionChanged;
            lv_nextEval.ColumnWidthChanging += lbCal_ColumnWidthChanging;
            label_releve.Text += Properties.Settings.Default.prenom + " " + Properties.Settings.Default.nom;
            InitializeChromium();

        }
        public void InitializeChromium()
        {
            this.CenterToScreen();

            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://drive.google.com/drive/folders/1s_ZxJ0EDVw3Zs5Htzj0UJ4rZgEYiydTJ?usp=sharing");
            chromeBrowser.DownloadHandler = new DownloadHandler();
            panelweb.Controls.Add(chromeBrowser);

            chromeBrowser.Dock = DockStyle.Fill;
            chromeBrowser.Size = panelweb.Size;

            chromeBrowser.Anchor = panelweb.Anchor;
            chromeBrowser1 = new ChromiumWebBrowser("https://mootse.telecom-st-etienne.fr/login/index.php");
            chromeBrowser1.DownloadHandler = new DownloadHandler();
            metroTabPage1.Controls.Add(chromeBrowser1);
            this.CenterToParent();
            chromeBrowser1.Size = metroTabPage1.Size;

            chromeBrowser2 = new ChromiumWebBrowser("https://cas.univ-st-etienne.fr/esup-cas/login?service=https://ent.univ-st-etienne.fr/uPortal/Login");
            chromeBrowser2.DownloadHandler = new DownloadHandler();
            metroTabPage2.Controls.Add(chromeBrowser2);
            LifespanHandler life = new LifespanHandler();
            chromeBrowser2.LifeSpanHandler = life;
            life.popup_request += life_popup_request;
            this.CenterToParent();
            chromeBrowser2.Size = metroTabPage2.Size;
        }
        private void carregar_popup_new_browser(string url)
        {
            chromeBrowser2 = new ChromiumWebBrowser(url);
            this.Invoke((MethodInvoker)delegate ()
            {
                this.metroTabPage2.Controls.Clear();
                this.metroTabPage2.Controls.Add(chromeBrowser2);
            });
            chromeBrowser2.Dock = DockStyle.Fill;
        }
        private void life_popup_request(string obj)
        {
            this.carregar_popup_new_browser(obj);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (scrolled)
            {
                this.Left = e.X + this.Left - (pointChat.X);
                this.Top = e.Y + this.Top - (pointChat.Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            scrolled = true;
            this.Cursor = Cursors.SizeAll;
            pointChat = e.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            scrolled = false;
            this.Cursor = Cursors.Default;
        }

        private void btn_inscription_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }
        //---------------APPUI SUR LE BOUTON FERMER-------------
        private void btn_quitter_Click(object sender, EventArgs e)
        {
            UpdateOnlineState(con, 0);
            this.Close();
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "accueil")
                {
                    form.Show();
                }
            }
        }
        //-----------------CONTROLE DE LA BARRE DE SELECTION--------------
        private void btn_emploidutemps_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void btn_relevédenotes_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void btn_chat_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void btn_ressourcespartagées_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void btn_liensujmmootse_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage6;
        }
        //----------------FIN DU CONTROLE DE LA BARRE DE SELECTION-------------

        private void lbCal5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //-----------------------THREAD POUR RECUPERER LES ELEVES EN LIGNE-----------------
        private void ThreadLoop()
        {
            while (true)
            {
                try
                {
                    this.Invoke(new MethodInvoker(delegate { AllMessageLists(); }));
                    this.Invoke(new MethodInvoker(delegate { RefreshOnline(); }));
                    Console.WriteLine("OK");
                    Thread.Sleep(200);
                }
                catch
                {
                    Console.WriteLine("Stop");
                    break;
                }
            }
        }
        //--------------------CHARGEMENT DU PANEL PRINCIPAL---------------------
        private void ProjetAccueil_Load(object sender, EventArgs e)
        {
            calTSE = "https://www.telecom-st-etienne.fr/intranet/icsbyuid.php?uid=" + Properties.Settings.Default.idetu;
            string groupe = Properties.Settings.Default.groupe;
            switch (groupe)
            {
                case "A1":
                    calIUT = "https://planning.univ-st-etienne.fr/jsp/custom/modules/plannings/anonymous_cal.jsp?resources=4620&projectId=3&calType=ical&firstDate=2019-08-20&lastDate=2020-08-19";
                    break;
                case "A2":
                    calIUT = "https://planning.univ-st-etienne.fr/jsp/custom/modules/plannings/anonymous_cal.jsp?resources=4619&projectId=3&calType=ical&firstDate=2019-08-20&lastDate=2020-08-19";
                    break;
                case "B1":
                    calIUT = "https://planning.univ-st-etienne.fr/jsp/custom/modules/plannings/anonymous_cal.jsp?resources=5426&projectId=3&calType=ical&firstDate=2019-08-20&lastDate=2020-08-19";
                    break;
                case "B2":
                    calIUT = "https://planning.univ-st-etienne.fr/jsp/custom/modules/plannings/anonymous_cal.jsp?resources=5425&projectId=3&calType=ical&firstDate=2019-08-20&lastDate=2020-08-19";
                    break;
            }
            setIcalDB(calIUT, calTSE, con, con1, pieChart, chart1, sl);
            GetIcal(listlbCal, con, con1, lv_nextEval);
           // SHDocVw.WebBrowser_V1 axBrowser = (SHDocVw.WebBrowser_V1)chromeBrowser1.ActiveXInstance;
            // listen for new windows  
           // axBrowser.NewWindow += axBrowser_NewWindow;
            //MarkSystem.cs
            drawDatagrid();
            //---------------------------------DATAGRID AU LANCEMENT DE L'APPLI---------------------------------
            con.Close();
            con.Open();

            //On efface le contenu de moyennes
            cmd = new NpgsqlCommand("delete from moyennes", con);
            cmd.ExecuteNonQuery();

            //On affiche moyennes sur le datagrid
            refreshDataGrid();
            con.Close();

            refreshRadarGraph();
            refreshMoyennG();
            //End MarkSystem.cs
            lbl_warningeval.Text = lbl_warningeval.Text + lv_nextEval.Items.Count.ToString() + " évaluation(s) prévue(s) pour les 7 prochains jours";
            radioS1.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            radioS2.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            radioS3.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            radioS4.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

            chatThread.Start();
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (radioS1.Checked)
            {
                semestre = 1;
                string[] matière = new string[13] { "Mathématiques 1", "Mécanique du point", "Optique géométrique", "SE1", "ENER1", "INFO1", "SIN1", "Anglais 1", "LV2 1", "Communication", "ATC", "Projet scientifique", "ER1" };
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(matière);
            }
            else if (radioS2.Checked)
            {
                semestre = 2;
                string[] matière = new string[12] { "Mathématiques 2", "Électrostatique", "Magnétostatique", "SE2", "ENER2", "INFO2", "AUTO2", "Anglais 2", "LV2 2", "Communication", "Projet de physique", "ER2" };
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(matière);
            }
            else if (radioS3.Checked)
            {
                semestre = 3;
                string[] matière = new string[14] { "Mathématiques 3", "Induction", "Ondes et propagation", "SE3", "ENER3", "POO", "AUTO3", "AT33", "RES3", "Capteurs & Vision", "Anglais 3", "LV2 3", "Entreprises et communication", "Projet TIPE" };
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(matière);
            }
            else if (radioS4.Checked)
            {
                semestre = 4;
                string[] matière = new string[12] { "Mathématiques 4", "Interférences", "Thermodynamique", "OS25", "AT41", "RCP30", "RCP20", "Anglais 4","ER4","C#", "Connaissance des entreprises", "Stage" };
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(matière);
            }
            refreshDataGrid();
            refreshRadarGraph();
            refreshMoyennG();
            dataGridView1.Rows[0].Cells[0].Selected = false;
        }

        //------------------------EMPECHE L'UTILISATEUR DE REDIMENSIONNER LA COLONNE DES LISTVIEW-------------
        private void lbCal_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = -1;
        }
        private void lbCal_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                e.Item.Selected = false;
        }
        private void btn_envoyer_Click(object sender, EventArgs e)
        {
            btn_envoyer.Enabled = false;
            SendMessage(txtbox_sendmsg.Text, con);
            txtbox_sendmsg.Text = "";
            btn_envoyer.Enabled = true;
        }
        private void txtbox_sendmsg_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_envoyer_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btn_cleanchat_Click(object sender, EventArgs e)
        {
            btn_cleanchat.Enabled = false;
            cleanChat(con);
            btn_cleanchat.Enabled = true;
        }

        private void btn_refreshedt_Click(object sender, EventArgs e)
        {
            setIcalDB(calIUT, calTSE, con, con1, pieChart, chart1, sl);
            GetIcal(listlbCal, con, con1, lv_nextEval);
        }

        private void btn_parametres_Click(object sender, EventArgs e)
        {
            bool present = false;
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == "Parametres")
                {
                    form.Focus();
                    present = true;
                }
            }
            if (present == false)
            {
                Parametres param = new Parametres(this);
                param.TextBoxIcalTSEValue = calTSE;
                param.TextBoxIcalIUTValue = calIUT;
                param.Show();
            }
        }
        public string TextBoxIcalTSEValue
        {
            set
            {
                calTSE = value;
            }
        }
        public string TextBoxIcalIUTValue
        {
            set
            {
                calIUT = value;
            }
        }
        public bool CheckBoxNotifSound
        {
            set
            {
                sound = value;
            }
            get
            {
                return sound;
            }
        }
        public bool CheckBoxNotifVis
        {
            set
            {
                vis = value;
            }
            get
            {
                return vis;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            button1.Enabled = false;
            bool worked = false;
            double coef = 0;
            double note = 0;
            try
            {
                note = Convert.ToDouble(textBox1.Text);
                coef = Convert.ToDouble(textBox2.Text);
                if (note <= 20 && note >= 0)
                {
                    worked = true;
                }
                else
                {
                    MessageBox.Show("Veuillez renseigner une note entre 0 et 20", "Erreur de saisie");
                }
            }
            catch
            {
                if(textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Veuillez renseigner une note et coefficient", "Erreur de saisie");
                }
                else
                {
                    MessageBox.Show("Veuillez renseigner une note et un coefficient valide ! Exemple note avec virugle: 13,4 et non 13.4", "Erreur de saisie");
                }
            }
            if (worked)
            {
                try
                {
                    con.Close();
                    con.Open();
                    NpgsqlCommand comm = new NpgsqlCommand("SELECT COUNT(*) FROM notes where numetu = '" + Properties.Settings.Default.idetu + "'", con);
                    int id = System.Convert.ToInt32(comm.ExecuteScalar());//Nombre de messages dans la base de donnée
                    if (id != 0)
                    {
                        cmd = new NpgsqlCommand("SELECT MAX(identifiantnote) FROM notes where numetu ='" + Properties.Settings.Default.idetu +"'", con);
                        cmd.ExecuteNonQuery();
                        identifiantnote = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    }
                    
                    setOnlineMark(con, comboBox1.Text, note, coef, identifiantnote);
                    comboBox2.Items.Add(identifiantnote);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                    da = getOnlineMark(con, semestre);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "moyennes");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "moyennes";
                    con.Close();
                    refreshRadarGraph();
                    refreshMoyennG();
                    dataGridView1.Rows[0].Cells[0].Selected = false;

                }
                catch
                {
                    MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
                }
            }
            button1.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Veuillez sélectionner un id correspondant à une note", "Erreur de saisie");
            }
            else
            {
                deleteOnlineMark(con, Convert.ToInt32(comboBox2.Text));
                comboBox2.Items.Remove(comboBox2.Text);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da = getOnlineMark(con, semestre);
                DataSet ds = new DataSet();
                da.Fill(ds, "moyennes");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "moyennes";
                refreshRadarGraph();
                refreshMoyennG();
                dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            button2.Enabled = true;
        }

        void listBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox list = (ListBox)sender;
            if (e.Index > -1)
            {
                object item = list.Items[e.Index];
                e.DrawBackground();
                e.DrawFocusRectangle();
                Brush brush = new SolidBrush(e.ForeColor);
                SizeF size = e.Graphics.MeasureString(item.ToString(), e.Font);
                e.Graphics.DrawString(item.ToString(), e.Font, brush, e.Bounds.Left + (e.Bounds.Width / 2 - size.Width / 2), e.Bounds.Top + (e.Bounds.Height / 2 - size.Height / 2));
            }
        }
        void refreshRadarGraph()
        {
            double moyenneth = calcMoyenneBlocTh(con, semestre);
            double moyenneiut = calcMoyenneBlocIUT(con, semestre);
            double moyennecom = calcMoyenneBlocCom(con, semestre);
            double moyenneprojet = calcMoyenneBlocProjet(con, semestre);
            chart2.Series[0].Points.Clear();
            chart2.Series[0].Points.AddY(moyenneth);
            chart2.Series[0].Points.AddY(moyenneiut);
            chart2.Series[0].Points.AddY(moyennecom);
            chart2.Series[0].Points.AddY(moyenneprojet);
            for (int i = 0; i < 4; i++)
            {
                chart2.Series[0].Points[i].MarkerSize = 7;
                chart2.Series[0].Points[i].MarkerStyle = MarkerStyle.Circle;
                chart2.Series[0].Points[i].MarkerColor = Color.Green;
            }
            label_moyth.Text = "| " + moyenneth.ToString();
            label_moyiut.Text = "| " + moyenneiut.ToString();
            label_moycom.Text = "| " + moyennecom.ToString();
            label_moyprojet.Text = "| " + moyenneprojet.ToString();
        }
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int rowIndex = 0; rowIndex < dataGridView1.Rows.Count; rowIndex++)
            {
                if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString() != "")
                {
                    dataGridView1.Rows[rowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12, FontStyle.Bold);
                    if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Mathématiques") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Thermodynamique") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Interférences") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Induction") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Ondes et propagation") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Électrostatique") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Magnétostatique") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Mécanique du point") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Optique géométrique"))
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                    if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Anglais") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Communication") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("LV2") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Entreprises et communication") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Connaissance des entreprises") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("ATC"))
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                    if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("RCP") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("AT") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Capteurs") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("ENER") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("OS25") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("AUTO") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("INFO") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("POO") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("SE") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("SIN") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("RES"))
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                    if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString() =="ER1" || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString() == "ER2" || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString() == "ER3" || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString() == "ER4" || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("C#") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Projet"))
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
            }
        }
        void refreshDataGrid()
        {
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            da = getOnlineMark(con, semestre);
            DataSet ds = new DataSet();
            da.Fill(ds, "moyennes");
            comboBox2.Items.Clear();
            foreach (DataRow myRow in ds.Tables[0].Rows)
            {
                if (myRow["id"].ToString() != "")
                {
                    comboBox2.Items.Add(myRow["id"].ToString());
                }
                if (myRow["note"].ToString() != "")
                {
                    myRow["note"] = Math.Round(Convert.ToDouble(myRow["note"]), 2).ToString();
                }
            }
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "moyennes";
            dataGridView1.Columns["id"].Width = 30;
            dataGridView1.Columns["coefficient"].Width = 80;
            dataGridView1.Columns["matière"].Width = 148;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        void drawDatagrid()
        {
            //design du datagrid
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.FromArgb(240, 240, 240);
            dataGridView1.ForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            //dataGridView1.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }
        private void btn_savepdf_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Relevé de notes " + (Properties.Settings.Default.nom).ToUpper() +".pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Impossible de créer le fichier" + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView1.Columns.Count - 1);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dataGridView1.Columns)
                            {
                                if(column.Name == "id")
                                {
                                    continue;
                                }
                                string header = column.HeaderText;
                                string headercap = char.ToUpper(header[0]) + header.Substring(1);
                                PdfPCell cell = new PdfPCell(new Phrase(headercap));
                                switch (column.HeaderText)
                                {
                                    case "matière":
                                        cell.DisableBorderSide(Rectangle.RIGHT_BORDER);
                                        cell.DisableBorderSide(Rectangle.BOTTOM_BORDER);
                                        break;
                                    case "note":
                                        cell.DisableBorderSide(Rectangle.BOTTOM_BORDER);
                                        cell.DisableBorderSide(Rectangle.LEFT_BORDER);
                                        cell.DisableBorderSide(Rectangle.RIGHT_BORDER);
                                        break;
                                    case "coefficient":
                                        cell.DisableBorderSide(Rectangle.LEFT_BORDER);
                                        cell.DisableBorderSide(Rectangle.BOTTOM_BORDER);
                                        break;
                                }
                                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                BaseColor color = null;
                                int style = 0;
                                int headermatiere = 0;
                                int lastline = 0;
                                string content = row.Cells["matière"].Value.ToString();
                                if(row.Index == dataGridView1.Rows.Count - 1)
                                {
                                    lastline = 1;
                                }
                                if (content.Contains("Mathématiques") || content.Contains("Thermodynamique") || content.Contains("Interférences") || content.Contains("Mécanique du point") || content.Contains("Optique géométrique") || content.Contains("Électrostatique") || content.Contains("Magnétostatique") || content.Contains("Induction") || content.Contains("Ondes et propagation"))
                                {
                                    style = iTextSharp.text.Font.BOLD;
                                    color = new BaseColor(0, 100, 0);
                                    headermatiere = 1;
                                }
                                if (content.Contains("Anglais") || content.Contains("Communication") || content.Contains("Entreprises") || content.Contains("LV2"))
                                {
                                    style = iTextSharp.text.Font.BOLD;
                                    color = new BaseColor(255, 127, 0);
                                    headermatiere = 1;
                                }
                                if (content == "ER4" || content == "ER3" || content == "ER2" || content == "ER1" || content.Contains("C#") || content.Contains("Projet"))
                                {
                                    style = iTextSharp.text.Font.BOLD;
                                    color = new BaseColor(139, 0, 0);
                                    headermatiere = 1;
                                }
                                if (content.Contains("AT") || content.Contains("RCP") || content.Contains("SE") || content.Contains("RES") || content.Contains("OS25") || content.Contains("ENER") || content.Contains("INFO") || content.Contains("SIN") || content.Contains("AUTO") || content.Contains("POO") || content.Contains("Capteurs"))
                                {
                                    style = iTextSharp.text.Font.BOLD;
                                    color = new BaseColor(0, 0, 139);
                                    headermatiere = 1;
                                }
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if(cell.ColumnIndex == dataGridView1.Columns["id"].DisplayIndex)
                                    {
                                        continue;
                                    }
                                    var Calibri8 = FontFactory.GetFont("Microsoft Sans Serif", 12, style, color);
                                    var titleChunk = new Chunk(cell.Value.ToString(), Calibri8);
                                    var phrase = new Phrase(titleChunk);
                                    PdfPCell cell1 = new PdfPCell(phrase);
                                    if (headermatiere == 1)
                                    {
                                        cell1.BackgroundColor = new BaseColor(211, 211, 211);
                                    }
                                    if(cell.ColumnIndex == dataGridView1.Columns["matière"].DisplayIndex)
                                    {
                                        cell1.DisableBorderSide(Rectangle.RIGHT_BORDER);
                                        cell1.DisableBorderSide(Rectangle.TOP_BORDER);
                                        cell1.DisableBorderSide(Rectangle.BOTTOM_BORDER);
                                    }
                                    if (cell.ColumnIndex == dataGridView1.Columns["coefficient"].DisplayIndex)
                                    {
                                        cell1.DisableBorderSide(Rectangle.LEFT_BORDER);
                                        cell1.DisableBorderSide(Rectangle.TOP_BORDER);
                                        cell1.DisableBorderSide(Rectangle.BOTTOM_BORDER);
                                    }
                                    if(cell.ColumnIndex == dataGridView1.Columns["note"].DisplayIndex)
                                    {
                                        cell1.DisableBorderSide(Rectangle.RIGHT_BORDER);
                                        cell1.DisableBorderSide(Rectangle.LEFT_BORDER);
                                        cell1.DisableBorderSide(Rectangle.TOP_BORDER);
                                        cell1.DisableBorderSide(Rectangle.BOTTOM_BORDER);
                                    }
                                    if(lastline == 1)
                                    {
                                        cell1.EnableBorderSide(Rectangle.BOTTOM_BORDER);
                                    }
                                    pdfTable.AddCell(cell1);
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                var logo = iTextSharp.text.Image.GetInstance(getLogoBuffer());
                                logo.ScalePercent(5f);
                                logo.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;
                                pdfDoc.Add(logo);
                                pdfDoc.Add(new Paragraph("Relevé de notes de " + Properties.Settings.Default.prenom + " " + Properties.Settings.Default.nom + " le " + DateTime.Now.ToShortDateString(), FontFactory.GetFont("Microsoft Sans Serif", 12, 1)));
                                pdfTable.SpacingBefore = 6f;
                                float[] width = new float[] { 2f, 1.5f, 1f };
                                pdfTable.SetWidths(width);
                                pdfDoc.Add(pdfTable);
                                var image = iTextSharp.text.Image.GetInstance(getChartBuffer());
                                image.ScalePercent(75f);
                                image.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
                                image.IndentationLeft = 20f;
                                pdfDoc.Add(image);
                                pdfDoc.Close();
                                stream.Close();
                            }
                            MessageBox.Show("Fichier créé !", "Succès");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erreur :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucune donnée à exporter", "Erreur");
            }
        }
        void refreshMoyennG()
        {
            double moyenneth = calcMoyenneBlocTh(con, semestre);
            double moyenneiut = calcMoyenneBlocIUT(con, semestre);
            double moyennecom = calcMoyenneBlocCom(con, semestre);
            double moyenneprojet = calcMoyenneBlocProjet(con, semestre);
            double moyennestage = getMoyenne(con, "Stage");
            double coefth = 0, coefiut = 0, coefcom = 0, coefprojet = 0, coefstage = 0;
            double moyenneg = 0;
            if (semestre == 1)
            {
                coefth = 10;
                coefiut = 11;
                coefcom = 5;
                coefprojet = 4;
            }
            else if (semestre == 2)
            {
                coefth = 12;
                coefiut = 10;
                coefcom = 3;
                coefprojet = 5;
            }
            else if (semestre == 3)
            {
                coefth = 11;
                coefiut = 10;
                coefcom = 4;
                coefprojet = 5;
            }
            else if (semestre == 4)
            {
                coefth = 8;
                coefiut = 5;
                coefcom = 3;
                coefprojet = 4;
                coefstage = 10;
            }
            if (moyenneth == 0)
            {
                coefth = 0;
            }
            if(moyennecom == 0)
            {
                coefcom = 0;
            }
            if(moyenneiut == 0)
            {
                coefiut = 0;
            }
            if(moyenneprojet == 0)
            {
                coefprojet = 0;
            }
            if (moyennestage == 0)
            {
                coefstage = 0;
            }
            moyenneg = (moyenneth* coefth + moyenneiut* coefiut + moyennecom* coefcom + moyenneprojet*coefprojet +moyennestage*coefstage) / (coefprojet + coefcom + coefiut + coefth + coefstage);
            label_moyg.Text = "Moyenne générale: " + Math.Round(moyenneg, 2).ToString();
        }
        private Byte[] getChartBuffer()
        {
            using (var ms = new MemoryStream())
            {
                //chart2.SaveImage(chartimage, ChartImageFormat.Png);
                //return chartimage.GetBuffer();
                Bitmap bmp = new Bitmap(panel_imagepdf.Width, panel_imagepdf.Height);
                panel_imagepdf.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, panel_imagepdf.Width, panel_imagepdf.Height));
                bmp.MakeTransparent();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png); //you could ave in BPM, PNG  etc format.
                byte[] Pic_arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(Pic_arr, 0, Pic_arr.Length);
                ms.Close();

                return ms.ToArray();
            }
        }
        private Byte[] getLogoBuffer()
        {
            using (var ms = new MemoryStream())
            {
                Bitmap bmp = new Bitmap(Properties.Resources.networking);
                bmp.MakeTransparent();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png); //you could ave in BPM, PNG  etc format.
                byte[] Pic_arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(Pic_arr, 0, Pic_arr.Length);
                ms.Close();

                return ms.ToArray();
            }
        }
        private void btn_supprallnotes_Click(object sender, EventArgs e)
        {
            btn_supprallnotes.Enabled = false;
            if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer toutes les notes ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                deleteAllOnlineMark(con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                da = getOnlineMark(con, semestre);
                DataSet ds = new DataSet();
                da.Fill(ds, "moyennes");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "moyennes";
                con.Close();
                refreshRadarGraph();
                refreshMoyennG();
            }
            btn_supprallnotes.Enabled = true;
        }

        //========ChatSystem utilisé dans le thread================//
        /// <summary>
        /// Récupère  les messages par ordre d'envoi dans la base de donnée en ligne. Les messages sont affichés dans la RichTextBox.
        /// </summary>
        public void AllMessageLists()
        {
            DataTable dt = new DataTable();
            try
            {
                con.Close();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM message ORDER BY id ASC", con);
                NpgsqlCommand comm = new NpgsqlCommand("SELECT COUNT(*) FROM message", con);
                int id = System.Convert.ToInt32(comm.ExecuteScalar());//Nombre de messages dans la base de donnée
                cmd.ExecuteNonQuery();
                NpgsqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                if (id != 0)
                {
                    if (txtbox_message.Lines.Length == 2)//On demande si le chat local est vide. Si oui, on recup tous les messages de la bdd
                    {
                        if (dt.Rows != null)
                        {
                            foreach (DataRow drow in dt.Rows)
                            {
                                txtbox_message.Text += "\n" + "(" + drow["time"].ToString() + " / " + drow["idetu"].ToString() + ") :  " + drow["msg"].ToString();
                            }
                            txtbox_message.SelectionStart = txtbox_message.TextLength;
                            txtbox_message.ScrollToCaret();
                            if (sound == true && dt.Rows[id - 1]["idetu"].ToString() != Properties.Settings.Default.idetu && first == 0)
                            {
                                PlayNotificationSound();
                            }
                            if (vis == true && dt.Rows[id - 1]["idetu"].ToString() != Properties.Settings.Default.idetu && first == 0)
                            {
                                NotifyPopup("Nouveau message de " + dt.Rows[id - 1]["idetu"].ToString(), dt.Rows[id - 1]["msg"].ToString(), txtbox_sendmsg);
                            }
                        }
                    }
                    else if (id > txtbox_message.Lines.Length - 2)//Si le chat local est deja rempli, on regarde si il y a un nouveau message dans la bdd 
                    {
                        txtbox_message.Text += "\n" + "(" + dt.Rows[id - 1]["time"].ToString() + " / " + dt.Rows[id - 1]["idetu"].ToString() + ") :  " + dt.Rows[id - 1]["msg"].ToString();
                        txtbox_message.SelectionStart = txtbox_message.TextLength;
                        txtbox_message.ScrollToCaret();
                        if (sound == true && dt.Rows[id - 1]["idetu"].ToString() != Properties.Settings.Default.idetu && first == 0)
                        {
                            PlayNotificationSound();
                        }
                        if (vis == true && dt.Rows[id - 1]["idetu"].ToString() != Properties.Settings.Default.idetu && first == 0)
                        {
                            NotifyPopup("Nouveau message de " + dt.Rows[id - 1]["idetu"].ToString(), dt.Rows[id - 1]["msg"].ToString(), txtbox_sendmsg);
                        }
                    }
                }
                else//Si la base de donnée est vide
                {
                    txtbox_message.Text = "Bienvenue dans le chat..." + "\n";
                }
                con.Close();
            }
            catch
            {

            }
            con.Close();
        }

        /// <summary>
        /// Rafraîchit la ListBox passée en paramètre en affichant les élèves connectés.
        /// </summary>
        public void RefreshOnline()
        {
            try
            {
                DataTable dtOn = new DataTable();
                DataTable dtOff = new DataTable();
                con.Close();
                con.Open();
                NpgsqlCommand cmdOnline = new NpgsqlCommand("SELECT * FROM citise2 where isonline = @IsOnline", con);
                cmdOnline.Parameters.AddWithValue("@IsOnline", 1);
                NpgsqlDataReader dr = cmdOnline.ExecuteReader();
                dtOn.Load(dr);
                if (dtOn.Rows != null)
                {
                    foreach (DataRow drow in dtOn.Rows)
                    {
                        if (lb_Online.Items.Count == 0)
                        {
                            lb_Online.Items.Add(drow["prenom"].ToString() + " " + drow["nom"].ToString());
                        }
                        else
                        {
                            if (lb_Online.Items.Contains(drow["prenom"].ToString() + " " + drow["nom"].ToString()) == false)
                            {
                                lb_Online.Items.Add(drow["prenom"].ToString() + " " + drow["nom"].ToString());
                            }
                        }
                    }
                }
                NpgsqlCommand cmdOffline = new NpgsqlCommand("SELECT * FROM citise2 where isonline = @IsOnline", con);
                cmdOffline.Parameters.AddWithValue("@IsOnline", 0);
                NpgsqlDataReader droff = cmdOffline.ExecuteReader();
                dtOff.Load(droff);
                if (dtOff.Rows != null)
                {
                    foreach (DataRow drow in dtOff.Rows)
                    {
                        if (lb_Online.Items.Contains(drow["prenom"].ToString() + " " + drow["nom"].ToString()))
                        {
                            int off = lb_Online.Items.IndexOf(drow["prenom"].ToString() + " " + drow["nom"].ToString());
                            lb_Online.Items.RemoveAt(off);

                        }
                    }
                }
                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
            con.Close();
        }
        //---------------------------FIN DU FONCTION-----------------------
    }
}
