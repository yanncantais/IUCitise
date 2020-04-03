﻿using Ical.Net.DataTypes;
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
using System.Globalization;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using Rectangle = iTextSharp.text.Rectangle;

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
            Title = "Légende",
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

        public ProjetAccueil()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Text = "Gestionnaire CiTiSE - " + Properties.Settings.Default.prenom;
            this.button1.Image = (System.Drawing.Image)(new Bitmap(btn_liensujmmootse.Image, new Size(32, 32)));
            this.button2.Image = (System.Drawing.Image)(new Bitmap(btn_quitter.Image, new Size(32, 32)));
            lbl_bonjour.Text = lbl_bonjour.Text + Properties.Settings.Default.prenom + ", nous sommes le " + DateTime.Now.ToShortDateString();
            webBrowser2.Navigate("https://mootse.telecom-st-etienne.fr/login/index.php");
            webBrowser1.Navigate("https://cas.univ-st-etienne.fr/esup-cas/login?service=https://ent.univ-st-etienne.fr/uPortal/Login");
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser2.ScriptErrorsSuppressed = true;
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
        }

        //--------------FONCTION QUI GERE LES POPUP---------------------s
        void axBrowser_NewWindow(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
        {
            // cancel the PopUp event  
            Processed = true;

            // send the popup URL to the WebBrowser control  
            webBrowser1.Navigate(URL);
        }
        //----------------FIN DE FONCTION--------------------------

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

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

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void listView6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //-----------------------APPUI SUR LE BOUTON SAVE----------------
        private void icalChanged(object sender, EventArgs e)
        {
            setIcalDB(calIUT, calTSE, con, con1, pieChart, chart1, sl);
            GetIcal(listlbCal, con, con1, lv_nextEval);
        }

        private void lbCal5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //-----------------------TIMER POUR RECUPERER LES ELEVES EN LIGNE-----------------
        private void timer_online_Tick(object sender, EventArgs e)
        {
            try
            {
                timer_online.Start();
                if (first == 1)
                {
                    AllMessageLists(txtbox_message, con, sound, vis, 1, txtbox_sendmsg);
                    first = 0;
                }
                else
                {
                    AllMessageLists(txtbox_message, con, sound, vis, 0, txtbox_sendmsg);
                }
                RefreshOnline(con, lb_Online);
            }
            catch
            {
                MessageBox.Show("Veuillez vérifier votre connexion", "Connexion impossible");
                timer_online.Stop();
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
            SHDocVw.WebBrowser_V1 axBrowser = (SHDocVw.WebBrowser_V1)webBrowser1.ActiveXInstance;
            // listen for new windows  
            axBrowser.NewWindow += axBrowser_NewWindow;
            //MarkSystem.cs
            drawDatagrid();
            //---------------------------------DATAGRID AU LANCEMENT DE L'APPLI---------------------------------
            con.Close();
            con.Open();

            //On efface le contenu de moyennes
            cmd = new NpgsqlCommand("delete from moyennes", con);
            cmd.ExecuteNonQuery();

            //On affiche moyennes sur le datagrid
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            da = getOnlineMark(con);
            DataSet ds = new DataSet();
            da.Fill(ds, "moyennes");
            foreach (DataRow myRow in ds.Tables[0].Rows)
            {
                if (myRow["id"].ToString() != "") {
                    comboBox2.Items.Add(myRow["id"].ToString());
                }
                if(myRow["note"].ToString() != "")
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
            con.Close();

            refreshRadarGraph();
            refreshMoyennG();
            //End MarkSystem.cs
            lbl_warningeval.Text = lbl_warningeval.Text + lv_nextEval.Items.Count.ToString() + " évaluation(s) prévue(s) pour les 7 prochains jours";
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
        private void button1_Click(object sender, EventArgs e)
        {


        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

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
                        cmd = new NpgsqlCommand("SELECT MAX(identifiantnote) FROM notes", con);
                        cmd.ExecuteNonQuery();
                        identifiantnote = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                    }

                    setOnlineMark(con, comboBox1.Text, note, coef, identifiantnote);
                    comboBox2.Items.Add(identifiantnote);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter();
                    da = getOnlineMark(con);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "moyennes");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "moyennes";
                    con.Close();
                    refreshRadarGraph();
                    refreshMoyennG();

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
            deleteOnlineMark(con, Convert.ToInt32(comboBox2.Text));
            comboBox2.Items.Remove(comboBox2.Text);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter();
            da = getOnlineMark(con);
            DataSet ds = new DataSet();
            da.Fill(ds, "moyennes");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "moyennes";
            refreshRadarGraph();
            refreshMoyennG();
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
            double moyenneth = calcMoyenneBlocTh(con);
            double moyenneiut = calcMoyenneBlocIUT(con);
            double moyennecom = calcMoyenneBlocCom(con);
            double moyenneprojet = calcMoyenneBlocProjet(con);
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
                    if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Maths") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Thermodynamique") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Interférences"))
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                    if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Anglais") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("Communication"))
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                    if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("RCP30") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("RCP20") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("AT41") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("OS25"))
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkBlue;
                    }
                    if (dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("ER4") || dataGridView1.Rows[rowIndex].Cells["matière"].Value.ToString().Contains("C#"))
                    {
                        dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                }
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
                                if (content.Contains("Maths") || content.Contains("Thermodynamique") || content.Contains("Interférences"))
                                {
                                    style = iTextSharp.text.Font.BOLD;
                                    color = new BaseColor(0, 100, 0);
                                    headermatiere = 1;
                                }
                                if (content.Contains("Anglais") || content.Contains("Communication"))
                                {
                                    style = iTextSharp.text.Font.BOLD;
                                    color = new BaseColor(255, 127, 0);
                                    headermatiere = 1;
                                }
                                if (content.Contains("ER4") || content.Contains("C#"))
                                {
                                    style = iTextSharp.text.Font.BOLD;
                                    color = new BaseColor(139, 0, 0);
                                    headermatiere = 1;
                                }
                                if (content.Contains("AT41") || content.Contains("RCP20") || content.Contains("RCP30") || content.Contains("OS25"))
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
            double moyenneth = calcMoyenneBlocTh(con);
            double moyenneiut = calcMoyenneBlocIUT(con);
            double moyennecom = calcMoyenneBlocCom(con);
            double moyenneprojet = calcMoyenneBlocProjet(con);
            int coefth = 8;
            int coefiut = 5;
            int coefcom = 3;
            int coefprojet = 4;
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
            double moyenne = (moyenneth* coefth + moyenneiut* coefiut + moyennecom* coefcom + moyenneprojet*coefprojet) / (coefprojet + coefcom + coefiut + coefth);
            label_moyg.Text = "Moyenne générale: " + Math.Round(moyenne, 2).ToString();
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
        //---------------------------FIN DU FONCTION-----------------------
    }
}