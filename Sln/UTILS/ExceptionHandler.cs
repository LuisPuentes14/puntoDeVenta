using System;
using System.Windows.Forms;

namespace Proyecto_Metodologia
{
    public class ExceptionHandler
    {
        public static void Register()
        {
            // Captura excepciones no controladas de UI (WinForms)
            Application.ThreadException += (sender, e) =>
            {
                ShowExceptionDialog(e.Exception, "Excepción no controlada en la interfaz gráfica");
            };

            // Captura excepciones no controladas fuera del hilo principal (por ejemplo: tareas en background)
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = e.ExceptionObject as Exception;
                ShowExceptionDialog(ex, "Excepción no controlada en la aplicación");
            };
        }

        private static void ShowExceptionDialog(Exception ex, string titulo)
        {
            string mensaje = $"Ha ocurrido un error inesperado:\n\n{ex.Message}\n\n" +
                             $"Detalles:\n{ex.StackTrace}";

            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
