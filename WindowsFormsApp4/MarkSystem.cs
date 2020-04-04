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
        /// Retourn un DataAdapter contenant les données du relevé de notes.
        /// </summary>
        public static NpgsqlDataAdapter getOnlineMark(NpgsqlConnection con)
        {
            NpgsqlDataAdapter da = null;
            try
            {
                con.Close();
                con.Open();
                buildBulletin(con, "Maths");
                buildBulletin(con, "Thermodynamique");
                buildBulletin(con, "Interférences");
                buildBulletin(con, "Anglais");
                buildBulletin(con, "Communication");
                buildBulletin(con, "ER4");
                buildBulletin(con, "C#");
                buildBulletin(con, "AT41");
                buildBulletin(con, "RCP20");
                buildBulletin(con, "RCP30");
                buildBulletin(con, "OS25");
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
        public static double calcMoyenneBlocTh(NpgsqlConnection con)
        {
            double moyenne, math, inter, thermo, coefmath, coefinter, coefthermo;
            math = getMoyenne(con, "Maths");
            inter = getMoyenne(con, "Interférences");
            thermo = getMoyenne(con, "Thermodynamique");
            coefmath = 0.53;
            coefthermo = 0.17;
            coefinter = 0.30;
            if (math == 0)
            {
                coefmath = 0;
            }
            if(inter == 0)
            {
                coefinter = 0;
            }
            if(thermo == 0)
            {
                coefthermo = 0;
            }
            if(math == 0 && inter == 0 && thermo == 0)
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
