using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_Metodologia.UTILS
{
    public static class Backup
    {

        public static void HacerBackupSQLServer()
        {
            string ruta = ConfigurationManager.AppSettings["RutaBackup"];
            string nombreBackup = ConfigurationManager.AppSettings["NombreBackup"];
            string query = $@"
        BACKUP DATABASE [{ConfigurationManager.AppSettings["NombreBD"]}] 
        TO DISK = '{Path.Combine(ruta, nombreBackup)}'
        WITH INIT;
    ";

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Backup realizado correctamente.");
                }
            }
        }
    }
}
