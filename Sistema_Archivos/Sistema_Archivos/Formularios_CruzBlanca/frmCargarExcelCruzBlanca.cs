using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace Sistema_Archivos
{
    public partial class frmCargarExcelCruzBlanca : Form
    {
        public frmCargarExcelCruzBlanca()
        {
            InitializeComponent();
        }

        public void Formato_dgv()
        {
            dgvDatosExcel.RowsDefaultCellStyle.BackColor = Color.White;
            dgvDatosExcel.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(204, 201, 201);
            dgvDatosExcel.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(95, 135, 14);
            dgvDatosExcel.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn Col in dgvDatosExcel.Columns)
            {
                Col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = "Archivos Excel|*.xls;",//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx|
                    Multiselect = false,        //not allow multiline selection at the file selection level
                    Title = "Cargar Archivo Excel",   //define the name of openfileDialog
                    InitialDirectory = "C:\\Users\\" + Environment.UserName + "\\Desktop\\" //define the initial directory
                };  //create openfileDialog Object
                if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
                {
                    txtNombreArchivo.Text = openFileDialog1.FileName;
                    string name = "";
                    string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + openFileDialog1.FileName + ";Extended Properties='Excel 8.0;HDR=YES;';";
                    OleDbConnection con = new OleDbConnection(constr);
                    con.Open();
                    DataTable tabla = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    foreach (DataRow item in tabla.Rows)
                    {
                        name = item["TABLE_NAME"].ToString();
                    }
                    OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "]", con);
                    OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                    DataTable data = new DataTable();
                    sda.Fill(data);
                    dgvDatosExcel.DataSource = data;
                    Formato_dgv();
                    lblCantidad.Text = dgvDatosExcel.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar y leer el archivo Excel. Detalles: " + ex.Message, "ERROR AL LEER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCargarInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDatosExcel.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para ingresar.", "SIN DATOS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Ingresar_datos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar la información. Detalles: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
        }

        public void Ingresar_datos()
        {
            int cantidad_ingreso = 0, remesa = 0;
            int notificador = 1; //NOTIFICADOR POR DEFECTO
            int motivo = 1; //motivo por defecto
            int rechazo = 1; //estado rechazo por defecto
            string Isapre, NroNomina, FolioFun, TipoFun, FechaFun, RutEmp, DvEmp,
                RegionEmpresa, CiudadEmpresa, ComunaEmpresa, DireccionEmpresa, FonoEmpresa,
                FechaEntrega, RutProveedor, CorrelativoEntrega, Entregado,
                RutCompleto, RazonSocial,
                FechaIngreso = DateTime.Now.ToString("dd-MM-yyyy");

            if (txtNombreArchivo.Text.Contains("MASIVO"))
            {
                //PROCESO MASIVO
                remesa = 1;
            }
            else
            {
                string withoutExtension = System.IO.Path.GetFileNameWithoutExtension(txtNombreArchivo.Text);
                string[] parts = withoutExtension.Split('_');
                remesa = Convert.ToInt32(parts[parts.Length - 1]);
            }

            foreach (DataGridViewRow row in dgvDatosExcel.Rows)
            {
                Isapre = Convert.ToString(row.Cells[0].Value);
                NroNomina = Convert.ToString(row.Cells[1].Value);
                FolioFun = Convert.ToString(row.Cells[2].Value);
                TipoFun = Convert.ToString(row.Cells[3].Value);
                FechaFun = Convert.ToString(row.Cells[4].Value);
                RutEmp = Convert.ToString(row.Cells[5].Value);
                DvEmp = Convert.ToString(row.Cells[6].Value);
                RazonSocial = Convert.ToString(row.Cells[7].Value);
                RegionEmpresa = Convert.ToString(row.Cells[8].Value);
                CiudadEmpresa = Convert.ToString(row.Cells[9].Value);
                ComunaEmpresa = Convert.ToString(row.Cells[10].Value);
                DireccionEmpresa = Convert.ToString(row.Cells[11].Value);
                FonoEmpresa = Convert.ToString(row.Cells[12].Value);
                FechaEntrega = Convert.ToString(row.Cells[13].Value);
                RutProveedor = Convert.ToString(row.Cells[14].Value);
                CorrelativoEntrega = Convert.ToString(row.Cells[15].Value);
                Entregado = Convert.ToString(row.Cells[16].Value);

                RutCompleto = string.Concat(RutEmp, DvEmp);
                FechaFun = FechaFun.Substring(0, 10);
                FechaFun = FechaFun.Replace("/", "-");

                int ingreso_masivo = new ArchivoCruzBlanca().IngresoArchivoExcel(FolioFun, "1", RutCompleto, RazonSocial, DireccionEmpresa, ComunaEmpresa, motivo, rechazo, FechaIngreso, FechaFun, 
                    notificador, Sesion.IdUsuario, remesa);
                cantidad_ingreso += 1;
            }

            MessageBox.Show("Datos desde planilla Excel ingresados correctamente. Se insertaron " + cantidad_ingreso + ".", "INGRESO CORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Limpiar();
        }

        public void Limpiar()
        {
            dgvDatosExcel.DataSource = null;
            txtNombreArchivo.Text = "";
            lblCantidad.Text = "0";
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}