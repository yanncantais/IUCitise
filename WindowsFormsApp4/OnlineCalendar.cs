using Ical.Net.DataTypes;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp4
{
    public class OnlineCalendar
    {
        /// <summary>
        /// Récupère l'agenda de  la semaine et l'affiche sur 7 ListView représentant  les 7 jours de la semaine.
        /// </summary>
        public static void GetIcal(ListView[] listlbCal, NpgsqlConnection conEdt, NpgsqlConnection conEdt1, ListView nextEval)
        {
            try
            {
                nextEval.Items.Clear();
                conEdt.Open();
                conEdt1.Open();

                for (int i = 0; i < 7; i++)
                {
                    listlbCal[i].Columns.Clear();
                    listlbCal[i].Items.Clear();
                    listlbCal[i].Scrollable = true;
                    listlbCal[i].View = View.Details;
                    string jour = DateTime.Today.AddDays(i).Date.ToString("dddd", new System.Globalization.CultureInfo("fr-FR"));
                    ColumnHeader header = new ColumnHeader();
                    header.Text = char.ToUpper(jour[0]) + jour.Substring(1) + " " + DateTime.Today.AddDays(i).Date.ToShortDateString();
                    header.Name = "Date";
                    listlbCal[i].Columns.Add(header);
                    listlbCal[i].Columns["Date"].Width = 322;
                }
                for (int i = 0; i < 7; i++)
                {
                    conEdt.Close();
                    conEdt.Open();
                    conEdt1.Close();
                    conEdt1.Open();
                    NpgsqlCommand cmdIUT = new NpgsqlCommand("SELECT * FROM edt where idetu = @Idetu AND date = @Date AND etablissement = @Etablissement ORDER BY hdebut ASC", conEdt);
                    cmdIUT.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                    cmdIUT.Parameters.AddWithValue("@Date", DateTime.Today.AddDays(i).ToShortDateString());
                    cmdIUT.Parameters.AddWithValue("@Etablissement", "IUT");
                    NpgsqlDataReader drEdt = cmdIUT.ExecuteReader();
                    if (drEdt.HasRows)
                    {
                        while (drEdt.Read())
                        {
                            if (drEdt["matiere"].ToString().Contains("Contrôle") || drEdt["matiere"].ToString().Contains("EXAMEN") || drEdt["matiere"].ToString().Contains("QCM"))
                            {
                                listlbCal[i].Items.Add(drEdt["matiere"] + " " + drEdt["salle"] + " " + drEdt["hdebut"] + " - " + drEdt["hfin"]).ForeColor = Color.Red;
                                nextEval.Items.Add(drEdt["matiere"].ToString()).ForeColor = Color.Red;
                            }
                            else
                            {
                                listlbCal[i].Items.Add(drEdt["matiere"] + " " + drEdt["salle"] + " " + drEdt["hdebut"] + " - " + drEdt["hfin"]).ForeColor = Color.Blue;
                            }
                        }
                    }
                    cmdIUT.Dispose();
                    NpgsqlCommand cmdTSE = new NpgsqlCommand("SELECT * FROM edt where idetu = @Idetu AND date = @Date AND etablissement = @Etablissement ORDER BY hdebut ASC", conEdt1);
                    cmdTSE.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                    cmdTSE.Parameters.AddWithValue("@Date", DateTime.Today.AddDays(i).ToShortDateString());
                    cmdTSE.Parameters.AddWithValue("@Etablissement", "TSE");
                    NpgsqlDataReader drEdt1 = cmdTSE.ExecuteReader();
                    if (drEdt1.HasRows)
                    {
                        while (drEdt1.Read())
                        {
                            if ((drEdt1["matiere"].ToString().Contains("Examen") || drEdt1["matiere"].ToString().Contains("EXAMEN") || drEdt1["matiere"].ToString().Contains("COLLE") || drEdt1["matiere"].ToString().Contains("Colle")) && drEdt1["matiere"].ToString().Contains("1/3") == false)
                            {
                                listlbCal[i].Items.Add(drEdt1["matiere"] + " " + drEdt1["salle"] + " " + drEdt1["hdebut"] + " - " + drEdt1["hfin"]).ForeColor = Color.Red;
                                nextEval.Items.Add(drEdt1["matiere"].ToString()).ForeColor = Color.Red;
                            }
                            else
                            {
                                listlbCal[i].Items.Add(drEdt1["matiere"] + " " + drEdt1["salle"] + " " + drEdt1["hdebut"] + " - " + drEdt1["hfin"]).ForeColor = Color.Green;
                            }
                        }
                    }
                    if (listlbCal[i].Items.Count != 0)
                    {
                        listlbCal[i].Columns[0].Width = -1;
                    }
                    if (nextEval.Items.Count != 0)
                    {
                        nextEval.Columns[0].Width = -1;
                    }
                    cmdTSE.Dispose();
                }
                conEdt.Close();
                conEdt1.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
        }
        /// <summary>
        /// Récupère l'agenda à partir de l'adresse http et la sauvegarde sur la base de donnée en  ligne. La fonction compare  l'agenda officiel avec celui stocké dans la base de donnée et  averti l'utilisateur d'un éventuel changement.
        /// </summary>
        public static void setIcalDB(string caliut, string caltse, NpgsqlConnection conEdt, NpgsqlConnection conEdtAdd, Chart pieChart, Chart barChart, Series sl)
        {
            try {
                DataTable volHoraire = new DataTable();
                volHoraire.Columns.Add("TD Math", typeof(double));
                volHoraire.Columns.Add("CM Math", typeof(double));

                volHoraire.Columns.Add("TD Interference", typeof(double));
                volHoraire.Columns.Add("CM Interference", typeof(double));

                volHoraire.Columns.Add("TD Thermodynamique", typeof(double));
                volHoraire.Columns.Add("CM Thermodynamique", typeof(double));

                volHoraire.Columns.Add("Anglais", typeof(double));
                volHoraire.Columns.Add("Communication", typeof(double));

                volHoraire.Columns.Add("RCP20", typeof(double));
                volHoraire.Columns.Add("RCP30", typeof(double));
                volHoraire.Columns.Add("OS25", typeof(double));
                volHoraire.Columns.Add("AT41", typeof(double));
                volHoraire.Columns.Add("Projet C#", typeof(double));

                volHoraire.Rows.Add(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                DataTable volHoraireTot = new DataTable();
                volHoraireTot.Columns.Add("Lundi", typeof(double));
                volHoraireTot.Columns.Add("Mardi", typeof(double));
                volHoraireTot.Columns.Add("Mercredi", typeof(double));
                volHoraireTot.Columns.Add("Jeudi", typeof(double));
                volHoraireTot.Columns.Add("Vendredi", typeof(double));

                volHoraireTot.Rows.Add(0, 0, 0, 0, 0);

                string debutjeudi = null;

                //Tableau temporaire pour stocker les evt 
                DataTable coursDel = new DataTable();
                DataTable coursDelIUT = new DataTable();
                NpgsqlCommand cmd;
                //Lecture du fichier Ical
                Uri calIUT = new Uri(caliut);
                Uri calTSE = new Uri(caltse);
                HttpWebRequest myRequestIUT = (HttpWebRequest)WebRequest.Create(calIUT);
                myRequestIUT.Method = "GET";
                WebResponse myResponseIUT = myRequestIUT.GetResponse();
                StreamReader srIUT = new StreamReader(myResponseIUT.GetResponseStream(), System.Text.Encoding.UTF8);
                string resultIUT = srIUT.ReadToEnd();
                srIUT.Close();
                myResponseIUT.Close();

                HttpWebRequest myRequestTSE = (HttpWebRequest)WebRequest.Create(calTSE);
                myRequestIUT.Method = "GET";
                WebResponse myResponseTSE = myRequestTSE.GetResponse();
                StreamReader srTSE = new StreamReader(myResponseTSE.GetResponseStream(), System.Text.Encoding.UTF8);
                string resultTSE = srTSE.ReadToEnd();
                srTSE.Close();
                myResponseTSE.Close();

                Ical.Net.Calendar calendarIUT = Ical.Net.Calendar.Load(resultIUT);

                Ical.Net.Calendar calendarTSE = Ical.Net.Calendar.Load(resultTSE);
                //============================================BOUCLE IUT=======================================================================
                conEdt.Close();
                conEdtAdd.Close();
                conEdt.Open();
                conEdtAdd.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT COUNT(*) FROM edt  where idetu = @Idetu AND etablissement = @Etablissement", conEdt);
                com.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                com.Parameters.AddWithValue("@Etablissement", "TSE");
                int id = System.Convert.ToInt32(com.ExecuteScalar());
                NpgsqlCommand cmdCout = new NpgsqlCommand("SELECT * FROM edt where idetu = @Idetu AND etablissement = @Etablissement", conEdt);
                cmdCout.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                cmdCout.Parameters.AddWithValue("@Etablissement", "IUT");
                NpgsqlDataReader drEdtAdd1 = cmdCout.ExecuteReader();
                coursDelIUT.Load(drEdtAdd1);
                //AJOUT DES EVT A LA BDD
                foreach (var cal in calendarIUT.Events)
                {
                    int isHere = 0;
                    int noNotif = 0;
                    foreach (Occurrence occurence in cal.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(7)))
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            if (cal.Start.Date == DateTime.Today.AddDays(i))
                            {
                                DataRow dr1 = volHoraire.Rows[0];
                                DataRow dr = volHoraireTot.Rows[0];

                                switch (cal.Start.Date.DayOfWeek)
                                {
                                    case DayOfWeek.Monday:
                                        dr["Lundi"] = Convert.ToDouble(dr["Lundi"]) + cal.Duration.TotalHours;
                                        break;
                                    case DayOfWeek.Tuesday:
                                        dr["Mardi"] = Convert.ToDouble(dr["Mardi"]) + cal.Duration.TotalHours;
                                        break;
                                    case DayOfWeek.Wednesday:
                                        dr["Mercredi"] = Convert.ToDouble(dr["Mercredi"]) + cal.Duration.TotalHours;
                                        break;
                                    case DayOfWeek.Thursday:
                                        dr["Jeudi"] = Convert.ToDouble(dr["Jeudi"]) + cal.Duration.TotalHours;
                                        debutjeudi = cal.Start.AsSystemLocal.ToShortTimeString();
                                        break;
                                    case DayOfWeek.Friday:
                                        dr["Vendredi"] = Convert.ToDouble(dr["Vendredi"]) + cal.Duration.TotalHours;
                                        break;
                                }
                                if (cal.Summary.Contains("RCP30"))
                                {
                                    dr1["RCP30"] = Convert.ToDouble(dr1["RCP30"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("RCP20"))
                                {
                                    dr1["RCP20"] = Convert.ToDouble(dr1["RCP20"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("OS25"))
                                {
                                    dr1["OS25"] = Convert.ToDouble(dr1["OS25"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("AT41"))
                                {
                                    dr1["AT41"] = Convert.ToDouble(dr1["AT41"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("Projet Tut"))
                                {
                                    dr1["Projet C#"] = Convert.ToDouble(dr1["Projet C#"]) + cal.Duration.TotalHours;
                                }
                                if (id == 0)
                                {
                                    conEdtAdd.Close();
                                    conEdtAdd.Open();
                                    cmd = new NpgsqlCommand("insert into edt (idetu, date, hdebut, hfin, salle, etablissement, matiere, duree)" + " values (@Idetu, @Date, @Hdebut, @Hfin, @Salle, @Etablissement, @Matiere, @Duree)", conEdtAdd);
                                    cmd.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                                    cmd.Parameters.AddWithValue("@Date", cal.Start.Date.ToShortDateString());
                                    cmd.Parameters.AddWithValue("@Hdebut", cal.Start.AsSystemLocal.ToShortTimeString());
                                    cmd.Parameters.AddWithValue("@Hfin", cal.End.AsSystemLocal.ToShortTimeString());
                                    cmd.Parameters.AddWithValue("@Salle", cal.Location);
                                    cmd.Parameters.AddWithValue("@Etablissement", "IUT");
                                    cmd.Parameters.AddWithValue("@Matiere", cal.Summary);
                                    cmd.Parameters.AddWithValue("@Duree", cal.Duration.TotalHours);
                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();
                                    isHere = 1;
                                    noNotif = 1;

                                }
                                else
                                {
                                    isHere = 0;
                                    if (coursDelIUT != null)
                                    {
                                        foreach (DataRow drow in coursDelIUT.Rows)
                                        {
                                            if (drow["date"].ToString() == cal.Start.Date.ToShortDateString())
                                            {
                                                if (drow["matiere"].ToString() == cal.Summary)
                                                {
                                                    if (drow["hdebut"].ToString() == cal.Start.AsSystemLocal.ToShortTimeString())
                                                    {
                                                        if (drow["hfin"].ToString() == cal.End.AsSystemLocal.ToShortTimeString())
                                                        {
                                                            if (drow["salle"].ToString() == cal.Location)
                                                            {
                                                                isHere = 1;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                conEdt.Close();
                                conEdtAdd.Close();
                            }
                        }
                    }

                    if (isHere == 0)
                    {
                        for (int i = 0; i < 7; i++)
                        {

                            if (cal.Start.Date == DateTime.Today.AddDays(i))
                            {
                                conEdtAdd.Close();
                                conEdtAdd.Open();
                                if (cal.Start.Date != DateTime.Today.AddDays(6) && noNotif == 0)
                                {//Alerte ajout d'un cours si ce n'est pas une création normale
                                    MessageBox.Show("Le cours " + cal.Summary + " à été ajouté le " + cal.Start.Date.ToShortDateString() + " de " + cal.Start.AsSystemLocal.ToShortTimeString() + " à " + cal.End.AsSystemLocal.ToShortTimeString() + " en salle " + cal.Location, "Modification dans l'emploi du temps - Changement de salle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                cmd = new NpgsqlCommand("insert into edt (idetu, date, hdebut, hfin, salle, etablissement, matiere, duree)" + " values (@Idetu, @Date, @Hdebut, @Hfin, @Salle, @Etablissement, @Matiere, @Duree)", conEdtAdd);
                                cmd.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                                cmd.Parameters.AddWithValue("@Date", cal.Start.Date.ToShortDateString());
                                cmd.Parameters.AddWithValue("@Hdebut", cal.Start.AsSystemLocal.ToShortTimeString());
                                cmd.Parameters.AddWithValue("@Hfin", cal.End.AsSystemLocal.ToShortTimeString());
                                cmd.Parameters.AddWithValue("@Salle", cal.Location);
                                cmd.Parameters.AddWithValue("@Etablissement", "IUT");
                                cmd.Parameters.AddWithValue("@Matiere", cal.Summary);
                                cmd.Parameters.AddWithValue("@Duree", cal.Duration.TotalHours);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                conEdtAdd.Close();
                            }
                        }
                    }
                }
                conEdt.Open();
                conEdtAdd.Open();
                NpgsqlCommand comm1 = new NpgsqlCommand("SELECT COUNT(*) FROM edt", conEdt);
                comm1.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                int id1 = System.Convert.ToInt32(comm1.ExecuteScalar());
                NpgsqlCommand cmdCount1 = new NpgsqlCommand("SELECT * FROM edt where idetu = @Idetu", conEdt);
                cmdCount1.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                NpgsqlCommand cmd1 = new NpgsqlCommand("SELECT * FROM edt where idetu = @Idetu", conEdt);
                cmd1.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                //VERIF COURS CHANGE
                if (id1 != 0)
                {
                    if (coursDelIUT != null)
                    {
                        foreach (DataRow drow in coursDelIUT.Rows)
                        {
                            string changement = "";
                            int isHere = 0;
                            foreach (var cal in calendarIUT.Events)
                            {
                                foreach (Occurrence occurence in cal.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(7)))
                                {
                                    for (int i = 0; i < 7; i++)
                                    {
                                        if (cal.Start.Date == DateTime.Today.AddDays(i))
                                        {
                                            if (drow["date"].ToString() == cal.Start.Date.ToShortDateString())
                                            {
                                                if (drow["matiere"].ToString() == cal.Summary)
                                                {
                                                    if (drow["hdebut"].ToString() == cal.Start.AsSystemLocal.ToShortTimeString())
                                                    {
                                                        if (drow["hfin"].ToString() == cal.End.AsSystemLocal.ToShortTimeString())
                                                        {
                                                            if (drow["salle"].ToString() == cal.Location)
                                                            {
                                                                isHere = 1;
                                                            }
                                                            else
                                                            {
                                                                //Changement de salle
                                                                changement = "salle";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //Changement Heure de fin
                                                            changement = "heure";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Changement heure de debut
                                                        changement = "heure";
                                                    }
                                                }
                                                else
                                                {
                                                    //Matière supprimée
                                                    changement = "suppr";
                                                }
                                            }
                                            else
                                            {
                                                //Matière supprimée
                                                changement = "suppr";
                                            }
                                        }
                                    }
                                }
                            }
                            if (isHere == 0)
                            {
                                if (DateTime.Parse(drow["date"].ToString()) >= DateTime.Today)
                                {//Pas d'alerte si on supprime les cours de la veille (normal)
                                    switch (changement)
                                    {
                                        case "salle":
                                            MessageBox.Show("Le cours " + drow["matiere"] + " du " + drow["date"] + " de " + drow["hdebut"] + " à " + drow["hfin"] + " en salle " + drow["salle"] + " a changé de salle", "Modification dans l'emploi du temps - Changement de salle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            break;
                                        case "heure":
                                            MessageBox.Show("Le cours " + drow["matiere"] + " du " + drow["date"] + " de " + drow["hdebut"] + " à " + drow["hfin"] + " en salle " + drow["salle"] + " a changé d'heure", "Modification dans l'emploi du temps - Changement d'heure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            break;
                                        case "suppr":
                                            MessageBox.Show("Le cours " + drow["matiere"] + " du " + drow["date"] + " de " + drow["hdebut"] + " à " + drow["hfin"] + " en salle " + drow["salle"] + " a été annulé ou déplacé", "Modification dans l'emploi du temps", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            break;
                                    }
                                }
                                NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM edt WHERE idetu = @Idetu AND date = @Date AND matiere = @Matiere AND hdebut = @Hdebut AND hfin = @Hfin AND salle = @Salle AND etablissement = @Etablissement", conEdtAdd);
                                cmdDel.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                                cmdDel.Parameters.AddWithValue("@Date", drow["date"]);
                                cmdDel.Parameters.AddWithValue("@Matiere", drow["matiere"]);
                                cmdDel.Parameters.AddWithValue("@Hdebut", drow["hdebut"]);
                                cmdDel.Parameters.AddWithValue("@Hfin", drow["hfin"]);
                                cmdDel.Parameters.AddWithValue("@Salle", drow["salle"]);
                                cmdDel.Parameters.AddWithValue("@Etablissement", "IUT");
                                cmdDel.ExecuteNonQuery();
                                cmdDel.Dispose();
                            }
                        }
                    }
                }
                cmd1.Dispose();
                conEdt.Close();
                conEdtAdd.Close();

                //==========================================BOUCLE TSE====================================
                conEdt.Close();
                conEdtAdd.Close();
                conEdt.Open();
                conEdtAdd.Open();
                NpgsqlCommand comm = new NpgsqlCommand("SELECT COUNT(*) FROM edt  where idetu = @Idetu AND etablissement = @Etablissement", conEdt);
                comm.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                comm.Parameters.AddWithValue("@Etablissement", "TSE");
                int id3 = System.Convert.ToInt32(comm.ExecuteScalar());
                NpgsqlCommand cmdCount = new NpgsqlCommand("SELECT * FROM edt where idetu = @Idetu AND etablissement = @Etablissement", conEdt);
                cmdCount.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                cmdCount.Parameters.AddWithValue("@Etablissement", "TSE");
                NpgsqlDataReader drEdtAdd = cmdCount.ExecuteReader();
                coursDel.Load(drEdtAdd);
                //AJOUT COURS A LA BDD
                foreach (var cal in calendarTSE.Events)
                {
                    int isHere = 0;
                    int noNotif = 0;
                    foreach (Occurrence occurence in cal.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(7)))
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            if (cal.Start.Date == DateTime.Today.AddDays(i))
                            {
                                DataRow dr1 = volHoraire.Rows[0];
                                DataRow dr = volHoraireTot.Rows[0];

                                switch (cal.Start.Date.DayOfWeek)
                                {
                                    case DayOfWeek.Monday:
                                        dr["Lundi"] = Convert.ToDouble(dr["Lundi"]) + cal.Duration.TotalHours;
                                        break;
                                    case DayOfWeek.Tuesday:
                                        dr["Mardi"] = Convert.ToDouble(dr["Mardi"]) + cal.Duration.TotalHours;
                                        break;
                                    case DayOfWeek.Wednesday:
                                        dr["Mercredi"] = Convert.ToDouble(dr["Mercredi"]) + cal.Duration.TotalHours;
                                        break;
                                    case DayOfWeek.Thursday:
                                        if (cal.Start.AsSystemLocal.ToShortTimeString() != debutjeudi)
                                        {
                                            dr["Jeudi"] = Convert.ToDouble(dr["Jeudi"]) + cal.Duration.TotalHours;
                                        }
                                        break;
                                    case DayOfWeek.Friday:
                                        dr["Vendredi"] = Convert.ToDouble(dr["Vendredi"]) + cal.Duration.TotalHours;
                                        break;
                                }
                                if (cal.Summary.Contains("TD MATH"))
                                {
                                    dr1["TD Math"] = Convert.ToDouble(dr1["TD Math"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("CM MATH"))
                                {
                                    dr1["CM Math"] = Convert.ToDouble(dr1["CM Math"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("TD INTERFERENCE"))
                                {
                                    dr1["TD Interference"] = Convert.ToDouble(dr1["TD Interference"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("CM INTERFERENCES"))
                                {
                                    dr1["CM Interference"] = Convert.ToDouble(dr1["CM Interference"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("TD PRINCIPES DE LA THERMODYNAMIQUE"))
                                {
                                    dr1["TD Thermodynamique"] = Convert.ToDouble(dr1["TD Thermodynamique"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("CM PRINCIPES DE LA THERMODYNAMIQUE"))
                                {
                                    dr1["CM Thermodynamique"] = Convert.ToDouble(dr1["CM Thermodynamique"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("ANGLAIS"))
                                {
                                    dr1["Anglais"] = Convert.ToDouble(dr1["Anglais"]) + cal.Duration.TotalHours;
                                }
                                if (cal.Summary.Contains("ENTREPRISES"))
                                {
                                    dr1["Communication"] = Convert.ToDouble(dr1["Communication"]) + cal.Duration.TotalHours;
                                }
                                if (id3 == 0)
                                {
                                    conEdtAdd.Close();
                                    conEdtAdd.Open();
                                    cmd = new NpgsqlCommand("insert into edt (idetu, date, hdebut, hfin, salle, etablissement, matiere, duree)" + " values (@Idetu, @Date, @Hdebut, @Hfin, @Salle, @Etablissement, @Matiere, @Duree)", conEdtAdd);
                                    cmd.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                                    cmd.Parameters.AddWithValue("@Date", cal.Start.Date.ToShortDateString());
                                    cmd.Parameters.AddWithValue("@Hdebut", cal.Start.AsSystemLocal.ToShortTimeString());
                                    cmd.Parameters.AddWithValue("@Hfin", cal.End.AsSystemLocal.ToShortTimeString());
                                    cmd.Parameters.AddWithValue("@Salle", cal.Location);
                                    cmd.Parameters.AddWithValue("@Etablissement", "TSE");
                                    cmd.Parameters.AddWithValue("@Matiere", cal.Summary);
                                    cmd.Parameters.AddWithValue("@Duree", cal.Duration.TotalHours);
                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();
                                    isHere = 1;
                                    noNotif = 1;

                                }
                                else
                                {
                                    isHere = 0;
                                    if (coursDel != null)
                                    {
                                        foreach (DataRow drow in coursDel.Rows)
                                        {
                                            if (drow["date"].ToString() == cal.Start.Date.ToShortDateString())
                                            {
                                                if (drow["matiere"].ToString() == cal.Summary)
                                                {
                                                    if (drow["hdebut"].ToString() == cal.Start.AsSystemLocal.ToShortTimeString())
                                                    {
                                                        if (drow["hfin"].ToString() == cal.End.AsSystemLocal.ToShortTimeString())
                                                        {
                                                            if (drow["salle"].ToString() == cal.Location)
                                                            {
                                                                isHere = 1;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                                drEdtAdd.DisposeAsync();
                                conEdt.Close();
                                conEdtAdd.Close();
                            }
                        }
                    }

                    if (isHere == 0)
                    {
                        for (int i = 0; i < 7; i++)
                        {

                            if (cal.Start.Date == DateTime.Today.AddDays(i))
                            {
                                conEdtAdd.Close();
                                conEdtAdd.Open();
                                if (cal.Start.Date != DateTime.Today.AddDays(6) && noNotif == 0)
                                {//Alerte ajout d'un cours si ce n'est pas une création normale
                                    MessageBox.Show("Le cours " + cal.Summary + " à été ajouté le " + cal.Start.Date.ToShortDateString() + " de " + cal.Start.AsSystemLocal.ToShortTimeString() + " à " + cal.End.AsSystemLocal.ToShortTimeString() + " en salle " + cal.Location, "Modification dans l'emploi du temps - Changement de salle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                cmd = new NpgsqlCommand("insert into edt (idetu, date, hdebut, hfin, salle, etablissement, matiere, duree)" + " values (@Idetu, @Date, @Hdebut, @Hfin, @Salle, @Etablissement, @Matiere, @Duree)", conEdtAdd);
                                cmd.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                                cmd.Parameters.AddWithValue("@Date", cal.Start.Date.ToShortDateString());
                                cmd.Parameters.AddWithValue("@Hdebut", cal.Start.AsSystemLocal.ToShortTimeString());
                                cmd.Parameters.AddWithValue("@Hfin", cal.End.AsSystemLocal.ToShortTimeString());
                                cmd.Parameters.AddWithValue("@Salle", cal.Location);
                                cmd.Parameters.AddWithValue("@Etablissement", "TSE");
                                cmd.Parameters.AddWithValue("@Matiere", cal.Summary);
                                cmd.Parameters.AddWithValue("@Duree", cal.Duration.TotalHours);
                                cmd.ExecuteNonQuery();
                                cmd.Dispose();
                                conEdtAdd.Close();
                            }
                        }
                    }
                }
                conEdt.Open();
                conEdtAdd.Open();
                NpgsqlCommand comm2 = new NpgsqlCommand("SELECT COUNT(*) FROM edt where idetu = @Idetu", conEdt);
                comm2.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                int id2 = System.Convert.ToInt32(comm2.ExecuteScalar());
                NpgsqlCommand cmdCount2 = new NpgsqlCommand("SELECT * FROM edt where idetu = @Idetu", conEdt);
                cmdCount2.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                NpgsqlCommand cmd2 = new NpgsqlCommand("SELECT * FROM edt where idetu = @Idetu", conEdt);
                cmd2.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                //VERIF COURS CHANGE
                if (id2 != 0)
                {
                    if (coursDel != null)
                    {
                        foreach (DataRow drow in coursDel.Rows)
                        {
                            string changement = "";
                            int isHere = 0;
                            foreach (var cal in calendarTSE.Events)
                            {
                                foreach (Occurrence occurence in cal.GetOccurrences(DateTime.Today, DateTime.Today.AddDays(7)))
                                {
                                    for (int i = 0; i < 7; i++)
                                    {
                                        if (cal.Start.Date == DateTime.Today.AddDays(i))
                                        {
                                            if (drow["date"].ToString() == cal.Start.Date.ToShortDateString())
                                            {
                                                if (drow["matiere"].ToString() == cal.Summary)
                                                {
                                                    if (drow["hdebut"].ToString() == cal.Start.AsSystemLocal.ToShortTimeString())
                                                    {
                                                        if (drow["hfin"].ToString() == cal.End.AsSystemLocal.ToShortTimeString())
                                                        {
                                                            if (drow["salle"].ToString() == cal.Location)
                                                            {
                                                                isHere = 1;
                                                            }
                                                            else
                                                            {
                                                                //Changement de salle
                                                                changement = "salle";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //Changement Heure de fin
                                                            changement = "heure";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Changement heure de debut
                                                        changement = "heure";
                                                    }
                                                }
                                                else
                                                {
                                                    //Matière supprimée
                                                    changement = "suppr";
                                                }
                                            }
                                            else
                                            {
                                                //Matière supprimée
                                                changement = "suppr";
                                            }
                                        }
                                    }
                                }
                            }
                            if (isHere == 0)
                            {
                                if (DateTime.Parse(drow["date"].ToString()) >= DateTime.Today) {//Pas d'alerte si on supprime les cours de la veille (normal)
                                    switch (changement)
                                    {
                                        case "salle":
                                            MessageBox.Show("Le cours " + drow["matiere"] + " du " + drow["date"] + " de " + drow["hdebut"] + " à " + drow["hfin"] + " en salle " + drow["salle"] + " a changé de salle", "Modification dans l'emploi du temps - Changement de salle", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            break;
                                        case "heure":
                                            MessageBox.Show("Le cours " + drow["matiere"] + " du " + drow["date"] + " de " + drow["hdebut"] + " à " + drow["hfin"] + " en salle " + drow["salle"] + " a changé d'heure", "Modification dans l'emploi du temps - Changement d'heure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            break;
                                        default:
                                            MessageBox.Show("Le cours " + drow["matiere"] + " du " + drow["date"] + " de " + drow["hdebut"] + " à " + drow["hfin"] + " en salle " + drow["salle"] + " a été annulé ou déplacé", "Modification dans l'emploi du temps", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            break;
                                    }
                                }
                                NpgsqlCommand cmdDel = new NpgsqlCommand("DELETE FROM edt WHERE idetu = @Idetu AND date = @Date AND matiere = @Matiere AND hdebut = @Hdebut AND hfin = @Hfin AND salle = @Salle AND etablissement = @Etablissement", conEdtAdd);
                                cmdDel.Parameters.AddWithValue("@Idetu", Properties.Settings.Default.idetu);
                                cmdDel.Parameters.AddWithValue("@Date", drow["date"]);
                                cmdDel.Parameters.AddWithValue("@Matiere", drow["matiere"]);
                                cmdDel.Parameters.AddWithValue("@Hdebut", drow["hdebut"]);
                                cmdDel.Parameters.AddWithValue("@Hfin", drow["hfin"]);
                                cmdDel.Parameters.AddWithValue("@Salle", drow["salle"]);
                                cmdDel.Parameters.AddWithValue("@Etablissement", "TSE");
                                cmdDel.ExecuteNonQuery();
                                cmdDel.Dispose();
                            }
                        }
                    }
                }
                cmd1.Dispose();
                conEdt.Close();
                conEdtAdd.Close();


                foreach (var series in pieChart.Series)
                {
                    series.Points.Clear();
                }
                pieChart.Palette = ChartColorPalette.BrightPastel;
                pieChart.BackColor = Color.Transparent;
                pieChart.ChartAreas[0].BackColor = Color.Transparent;

                foreach (DataRow dtRow in volHoraire.Rows)
                {
                    // On all tables' columns
                    foreach (DataColumn dc in volHoraire.Columns)
                    {
                        if (Convert.ToDouble(dtRow[dc]) != 0)
                        {
                            DataPoint p = new DataPoint(0, Convert.ToDouble(dtRow[dc]));
                            p.AxisLabel = dtRow[dc].ToString() + " h";
                            p.LegendText = dc.ColumnName.ToString();
                            sl.Points.Add(p);
                        }
                    }
                }
                foreach (var series in barChart.Series)
                {
                    series.Points.Clear();
                }
                barChart.Palette = ChartColorPalette.BrightPastel;
                barChart.BackColor = Color.Transparent;
                barChart.ChartAreas[0].BackColor = Color.Transparent;
                barChart.Series["Series1"].Color = Color.DarkCyan;

                foreach (DataRow dtRow in volHoraireTot.Rows)
                {
                    // On all tables' columns
                    foreach (DataColumn dc in volHoraireTot.Columns)
                    {
                        if (Convert.ToDouble(dtRow[dc]) != 0)
                        {
                            barChart.Series["Series1"].Points.AddXY(dc.ColumnName.ToString(), Convert.ToDouble(dtRow[dc]));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
        }

       
    }

   
}

