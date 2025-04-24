using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Proyecto_Metodologia.UTILS
{
    public static class Backup
    {

        public static void HacerBackupSQLServer()
        {
            string query = $@"
        BACKUP DATABASE [{ConfigurationManager.AppSettings["NombreBD"]}] 
        TO DISK = '{ConfigurationManager.AppSettings["rutaBackup"]}'
        WITH INIT;
    ";

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
