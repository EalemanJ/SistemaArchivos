using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmAcercaDe : Form
    {
        public frmAcercaDe()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.alemaninformatica.com");
        }
    }
}