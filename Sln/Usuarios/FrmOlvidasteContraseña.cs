using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace Proyecto_Metodologia
{
    public partial class FrmOlvidasteContraseña : Form
    {
        public FrmOlvidasteContraseña()
        {
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
                using (SqlConnection conexion = new SqlConnection(cnn))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * from TUsuarios  WHERE TUsuarios.Correo='" + txtCorreo.Text +  "'", conexion))
                    {
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            EnviarCorreo(dr["Correo"].ToString(), dr["contraseña"].ToString());
                            MessageBox.Show("Contraseña enviada a su correo", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            Close();
                        }
                        else
                        {
                            MessageBox.Show("No te encuentras en los usuarios que puedan usar el sistema");
                            txtCorreo.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



        }




        public void EnviarCorreo(string correoUsuario, string contrasenia) 
        {
            // Configuración del correo
            string smtpServer = "smtp.gmail.com";
            int port = 587; // o 465 si usas SSL
            string fromEmail = "puntodeventa940@gmail.com";
            string toEmail = correoUsuario;
            string subject = "Recuperación de contraseña.";
            string body = getBodyHtml().Replace("model.clave", contrasenia);
            string password = "ypdw lqyw ewof sqjv";

            // Crear el cliente SMTP
            using (SmtpClient client = new SmtpClient(smtpServer, port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(fromEmail, password);

                // Crear el mensaje
                MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);
                mail.IsBodyHtml = true;

                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }





        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string getBodyHtml()
            => @"<!DOCTYPE html>
<html lang=""es"">
<head>
  <meta charset=""UTF-8"" />
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0""/>
  <title>Recuperación de contraseña</title>
  <style>
    body {
      background-color: #f4f4f7;
      font-family: 'Segoe UI', sans-serif;
      margin: 0;
      padding: 0;
      color: #333333;
    }

    .container {
      max-width: 600px;
      margin: 40px auto;
      background-color: #ffffff;
      border-radius: 10px;
      padding: 40px;
      box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    }

    h2 {
      text-align: center;
      color: #1a73e8;
    }

    p {
      font-size: 16px;
      line-height: 1.6;
    }

    .code-box {
      background-color: #f1f1f1;
      border: 2px dashed #888;
      padding: 20px;
      text-align: center;
      font-size: 24px;
      font-weight: bold;
      letter-spacing: 2px;
      margin: 30px 0;
      border-radius: 8px;
      color: #222;
    }

    .button {
      display: inline-block;
      padding: 12px 24px;
      background-color: #1a73e8;
      color: #ffffff;
      text-decoration: none;
      border-radius: 6px;
      font-weight: bold;
      transition: background-color 0.3s ease;
      text-align: center;
    }

    .button:hover {
      background-color: #0f5fcc;
    }

    .footer {
      text-align: center;
      font-size: 12px;
      color: #888;
      margin-top: 30px;
    }
  </style>
</head>
<body>
  <div class=""container"">
    <h2>Recuperación de Contraseña</h2>
    <p>Hola,</p>
    <p>Recibiste este correo porque olvidaste tu contraseña. Tu contraseña es la siguiente:</p>
    <div class=""code-box"">model.clave</div>
    <p>Tu cuenta está segura.</p>

    <div class=""footer"">
      Este es un correo automático. Por favor, no respondas a este mensaje.
    </div>
  </div>
</body>
</html>";
    }
}
