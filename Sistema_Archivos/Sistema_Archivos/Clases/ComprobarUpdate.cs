using System.Deployment.Application;
using System.Threading;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public class ComprobarUpdate
    {
        public void BuscarActualizacion(string desde)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                if (desde == "arranque")
                {
                    try
                    {
                        if (Application.OpenForms["frmInicio"] is frmInicio i)
                        {
                            i.Hide();
                        }
                        Thread hilo = new Thread(new ThreadStart(AbrirFormulario));
                        hilo.Start();
                        Thread.Sleep(2000);
                        ApplicationDeployment.CurrentDeployment.Update();
                        var version = ApplicationDeployment.CurrentDeployment.UpdatedVersion;
                        MessageBox.Show("Actualización descargada e instalada. La nueva versión es " + version + "", "REINICIAR APLICACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (hilo.IsAlive)
                        {
                            if (Application.OpenForms["frmAvisoActualizar"] is frmAvisoActualizar ac)
                            {
                                ac.Close();
                            }
                            hilo.Join();
                            hilo.Abort();
                        }
                        Application.Restart();
                    }
                    catch (System.Exception)
                    {
                        Application.ExitThread();
                    }
                }
                else if (desde == "link")
                {
                    DialogResult message = MessageBox.Show("Se ha encontrado una nueva versión de la aplicación. ¿Le gustaría actualizar ahora?", "NUEVA ACTUALIZACIÓN",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                    if (message == DialogResult.Yes)
                    {
                        try
                        {
                            Thread hilo = new Thread(new ThreadStart(AbrirFormulario));
                            hilo.Start();
                            Thread.Sleep(2000);
                            ApplicationDeployment.CurrentDeployment.Update();
                            var version = ApplicationDeployment.CurrentDeployment.UpdatedVersion;
                            MessageBox.Show("Actualización descargada e instalada. La nueva versión es " + version + "", "REINICIAR APLICACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            if (hilo.IsAlive)
                            {
                                if (Application.OpenForms["frmAvisoActualizar"] is frmAvisoActualizar ac)
                                {
                                    ac.Close();
                                }
                                hilo.Join();
                                hilo.Abort();
                            }
                            Application.Restart();
                        }
                        catch (System.Exception)
                        {
                            Application.ExitThread();
                        }
                    }
                }
            }
        }

        public void AbrirFormulario()
        {
            Application.Run(new frmAvisoActualizar());
        }
    }
}