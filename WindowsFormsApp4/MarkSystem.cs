using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    class MarkSystem
    {
        /// <summary>
        /// Ajoute une note dans la base de donnée.
        /// </summary>
        public static void setOnlineMark(NpgsqlConnection con, string matière, double note, double coef, int id)
        {
            try
            {
                con.Close();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("insert into notes (numetu, matière,note, coefficient,matièree, identifiantnote)" + " values (@numetu, @matière, @note, @coefficient, null, @identifiantnote)", con);
                cmd.Parameters.AddWithValue("@numetu", Properties.Settings.Default.idetu);
                cmd.Parameters.AddWithValue("@matière", matière);
                cmd.Parameters.AddWithValue("@note", note);
                cmd.Parameters.AddWithValue("@coefficient", coef);
                cmd.Parameters.AddWithValue("@identifiantnote", id);
                cmd.ExecuteNonQuery();
                cmd = new NpgsqlCommand("delete from moyennes", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
        }
        /// <summary>
        /// Supprime une note en fonction de son id dans la base de donnée.
        /// </summary>
        public static void deleteOnlineMark(NpgsqlConnection con, int id)
        {
            try
            {
                con.Close();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM notes WHERE identifiantnote = @Idnote AND numetu = @numetu", con);
                cmd.Parameters.AddWithValue("@Idnote", id);
                cmd.Parameters.AddWithValue("@numetu", Properties.Settings.Default.idetu);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new NpgsqlCommand("delete from moyennes", con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
        }
        /// <summary>
        /// Supprime une note en fonction de son id dans la base de donnée.
        /// </summary>
        public static void deleteAllOnlineMark(NpgsqlConnection con)
        {
            try
            {
                con.Close();
                con.Open();
                NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM notes WHERE numetu = @numetu", con);
                cmd.Parameters.AddWithValue("@numetu", Properties.Settings.Default.idetu);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = new NpgsqlCommand("delete from moyennes", con);
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
        }
        /// <summary>
        /// Retourn un DataAdapter contenant les données du relevé de notes.
        /// </summary>
        public static NpgsqlDataAdapter getOnlineMark(NpgsqlConnection con, int semestre)
        {
            NpgsqlDataAdapter da = null;
            try
            {
                con.Close();
                con.Open();
                if (semestre == 1)
                {
                    buildBulletin(con, "Mathématiques");
                    buildBulletin(con, "Mécanique du point");
                    buildBulletin(con, "Optique géométrique");
                    buildBulletin(con, "Anglais");
                    buildBulletin(con, "LV2");
                    buildBulletin(con, "Communication");
                    buildBulletin(con, "Projet scientifique");
                    buildBulletin(con, "ATC");
                    buildBulletin(con, "ER1");
                    buildBulletin(con, "SE1");
                    buildBulletin(con, "ENER1");
                    buildBulletin(con, "INFO1");
                    buildBulletin(con, "SIN1");
                }
                else if (semestre == 2)
                {
                    buildBulletin(con, "Mathématiques");
                    buildBulletin(con, "Électrostatique");
                    buildBulletin(con, "Magnétostatique");
                    buildBulletin(con, "Anglais");
                    buildBulletin(con, "LV2");
                    buildBulletin(con, "Communication");
                    buildBulletin(con, "Projet de physique");
                    buildBulletin(con, "ER2");
                    buildBulletin(con, "SE2");
                    buildBulletin(con, "ENER2");
                    buildBulletin(con, "INFO2");
                    buildBulletin(con, "AUTO2");
                }
                else if (semestre == 3)
                {
                    buildBulletin(con, "Mathématiques");
                    buildBulletin(con, "Induction");
                    buildBulletin(con, "Ondes et propagation");
                    buildBulletin(con, "Anglais");
                    buildBulletin(con, "LV2");
                    buildBulletin(con, "Entreprises et communication");
                    buildBulletin(con, "Projet TIPE");
                    buildBulletin(con, "SE3");
                    buildBulletin(con, "ENER3");
                    buildBulletin(con, "POO");
                    buildBulletin(con, "AUTO3");
                    buildBulletin(con, "AT33");
                    buildBulletin(con, "RES3");
                    buildBulletin(con, "Capteurs & Vision");
                }
                else if (semestre == 4)
                {
                    buildBulletin(con, "Mathématiques");
                    buildBulletin(con, "Thermodynamique");
                    buildBulletin(con, "Interférences");
                    buildBulletin(con, "Anglais");
                    buildBulletin(con, "Connaissance des entreprises");
                    buildBulletin(con, "ER4");
                    buildBulletin(con, "C#");
                    buildBulletin(con, "AT41");
                    buildBulletin(con, "RCP20");
                    buildBulletin(con, "RCP30");
                    buildBulletin(con, "OS25");
                    buildBulletin(con, "Stage");
                }

                da = new NpgsqlDataAdapter("select * from moyennes ", con);

                con.Close();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
            return da;
        }
        /// <summary>
        /// Construit la forme du bulletin dans une base de donnée tampon.
        /// </summary>
        private static void buildBulletin(NpgsqlConnection con, string matière)
        {
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into moyennes (select matière, (sum(note*coefficient))/sum(coefficient) as résultats from notes where numetu =  '" + Properties.Settings.Default.idetu.ToString() + "' and matière ='" + matière + "' group by matière)", con);
                cmd.ExecuteNonQuery();
                cmd = new NpgsqlCommand("insert into moyennes (select matièree as matière, note as résultats, coefficient, identifiantnote as id from notes where numetu =  '" + Properties.Settings.Default.idetu.ToString() + "' and matière ='" + matière + "')", con);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
        }
        /// <summary>
        /// Retourne la moyenne générale d'une matière
        /// </summary>
        public static double getMoyenne(NpgsqlConnection con, string matière)
        {
            double moyenne = 0;
            try
            {
                con.Close();
                con.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("select note from moyennes where matière = '" + matière + "'", con);
                moyenne = Convert.ToDouble(cmd.ExecuteScalar());
            }
            catch
            {
                MessageBox.Show("Vérifier la connexion internet", "Connexion impossible");
            }
            moyenne = Math.Round(moyenne, 2);
            return moyenne;
        }
        /// <summary>
        /// Renvoie la moyenne générale du bloc théorique.
        /// </summary>
        public static double calcMoyenneBlocTh(NpgsqlConnection con, int semestre)
        {
            double moyenne = 0,math = 0, inter = 0, thermo = 0, coefmath = 0, coefinter = 0, coefthermo = 0;
            math = getMoyenne(con, "Mathématiques");

            if (semestre == 1)
            {
                inter = getMoyenne(con, "Mécanique du point");
                thermo = getMoyenne(con, "Optique géométrique");
                coefmath = 0.51;
                coefthermo = 0.24;
                coefinter = 0.25;
            }
            else if (semestre == 2)
            {
                inter = getMoyenne(con, "Électrostatique");
                thermo = getMoyenne(con, "Magnétostatique");
                coefmath = 0.48;
                coefthermo = 0.26;
                coefinter = 0.26;
            }
            else if (semestre == 3)
            {
                inter = getMoyenne(con, "Induction");
                thermo = getMoyenne(con, "Ondes et propagation");
                coefmath = 0.6;
                coefthermo = 0.22;
                coefinter = 0.18;
            }
            else if (semestre == 4)
            {
                inter = getMoyenne(con, "Interférences");
                thermo = getMoyenne(con, "Thermodynamique");
                coefmath = 0.53;
                coefthermo = 0.17;
                coefinter = 0.30;
            }
            if (math == 0)
            {
                coefmath = 0;
            }
            if (inter == 0)
            {
                coefinter = 0;
            }
            if (thermo == 0)
            {
                coefthermo = 0;
            }
            if (math == 0 && inter == 0 && thermo == 0)
            {
                moyenne = 0;
            }
            else
            {
                moyenne = (math * coefmath + inter * coefinter + thermo * coefthermo) / (coefmath + coefinter + coefthermo);
            }
            moyenne = Math.Round(moyenne, 2);
            return moyenne;
        }
        /// <summary>
        /// Renvoie la moyenne générale du bloc IUT.
        /// </summary>
        public static double calcMoyenneBlocIUT(NpgsqlConnection con)
        {
            double moyenne, os25, at41, rcp20, rcp30, coefos25, coefat41, coefrcp20, coefrcp30;
            os25 = getMoyenne(con, "OS25");
            at41 = getMoyenne(con, "AT41");
            rcp20 = getMoyenne(con, "RCP20");
            rcp30 = getMoyenne(con, "RCP30");
            coefos25 = 0.23;
            coefat41 = 0.27;
            coefrcp20 = 0.24;
            coefrcp30 = 0.26;
            if (os25 == 0)
            {
                coefos25 = 0;
            }
            if (at41 == 0)
            {
                coefat41 = 0;
            }
            if (rcp20 == 0)
            {
                coefrcp20 = 0;
            }
            if(rcp30 == 0)
            {
                coefrcp30 = 0;
            }
            if (os25 == 0 && at41 == 0 && rcp30 == 0 && rcp20  == 0)
            {
                moyenne = 0;
            }
            else
            {
                moyenne = (os25 * coefos25 + at41 * coefat41 + rcp20 * coefrcp20 + rcp30*coefrcp30) / (coefos25 + coefat41 + coefrcp20 + coefrcp30);
            }
            moyenne = Math.Round(moyenne, 2);
            return moyenne;
        }
        /// <summary>
        /// Renvoie la moyenne générale du bloc communication.
        /// </summary>
        public static double calcMoyenneBlocCom(NpgsqlConnection con)
        {
            double moyenne, anglais, com, coefanglais, coefcom;
            anglais = getMoyenne(con, "Anglais");
            com = getMoyenne(con, "Communication");
            coefanglais = 0.67;
            coefcom = 0.33;
            if (anglais == 0)
            {
                coefanglais = 0;
            }
            if (com == 0)
            {
                coefcom = 0;
            }
            if (anglais == 0 && com == 0)
            {
                moyenne = 0;
            }
            else
            {
                moyenne = (anglais * coefanglais + com * coefcom) / (coefanglais + coefcom);
            }
            moyenne = Math.Round(moyenne, 2);
            return moyenne;
        }
        /// <summary>
        /// Renvoie la moyenne générale du bloc projet.
        /// </summary>
        public static double calcMoyenneBlocProjet(NpgsqlConnection con)
        {
            double moyenne, er4, c, coefer4, coefc;
            er4 = getMoyenne(con, "ER4");
            c = getMoyenne(con, "C#");
            coefer4 = 0.67;
            coefc = 0.33;
            if (er4 == 0)
            {
                coefer4 = 0;
            }
            if (c == 0)
            {
                coefc = 0;
            }
            if (er4 == 0 && c == 0)
            {
                moyenne = 0;
            }
            else
            {
                moyenne = (er4 * coefer4 + c * coefc) / (coefer4 + coefc);
            }
            moyenne = Math.Round(moyenne, 2);
            return moyenne;
        }
    }
}
