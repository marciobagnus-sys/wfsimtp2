using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using wfsimtp2.Controller;

namespace wfsimtp2
{
    public partial class Menu : Form
    {
        private NormalController normalController = new NormalController();
        private ExponentialController exponentialController = new ExponentialController();
        private UniformController uniformController = new UniformController();

        private int tamMuestra;
        private int cantidadIntervalos;
        private double media;
        private double desviacion;
        private double lambda;
        private double minimo;
        private double maximo;

        public Menu()
        {
            InitializeComponent();
            rbNormal.CheckedChanged += RbDistribucion_CheckedChanged;
            rbExponencial.CheckedChanged += RbDistribucion_CheckedChanged;
            rbUniforme.CheckedChanged += RbDistribucion_CheckedChanged;

            this.Load += Menu_Load;
        }

        private void RbDistribucion_CheckedChanged(object sender, EventArgs e)
        {
            this.lblParametro1.Visible = true;
            this.txtParametro1.Visible = true;

            if (rbNormal.Checked)
            {
                lblParametro1.Text = "Media:";
                lblParametro2.Text = "Desviación estándar:";
                lblParametro2.Visible = true;
                txtParametro2.Visible = true;
            }
            else if (rbExponencial.Checked)
            {
                lblParametro1.Text = "Lambda:";
                lblParametro2.Visible = false;
                txtParametro2.Visible = false;
            }
            else if (rbUniforme.Checked)
            {
                lblParametro1.Text = "Mínimo:";
                lblParametro2.Text = "Máximo:";
                lblParametro2.Visible = true;
                txtParametro2.Visible = true;
            }

            bool haySeleccion = rbNormal.Checked || rbExponencial.Checked || rbUniforme.Checked;

            txtTamanioMuestra.Enabled = haySeleccion;
            cmbIntervalos.Enabled = haySeleccion;
            btnCalcular.Enabled = haySeleccion;

            // Limpiar los parámetros cuando cambia la distribución
            txtParametro1.Text = string.Empty;
            txtParametro2.Text = string.Empty;
        }

        private async void BtnCalcular_Click(object sender, EventArgs e)
        {
            if (!ValidarYLeerParametros())
                return;

            btnVerHistograma.Enabled = false;
            btnVerGrilla.Enabled = false;
            btnVerVariables.Enabled = false;
            panelResultados.Visible = false;

            try
            {
                if (rbNormal.Checked)
                {
                    await Task.Run(() => normalController.CalcularAsync(tamMuestra, cantidadIntervalos, media, desviacion));
                }
                else if (rbExponencial.Checked)
                {
                    await Task.Run(() => exponentialController.CalcularAsync(tamMuestra, cantidadIntervalos, lambda));
                }
                else if (rbUniforme.Checked)
                {
                    await Task.Run(() => uniformController.CalcularAsync(tamMuestra, cantidadIntervalos, minimo, maximo));
                }

                panelResultados.Visible = true;
                btnVerHistograma.Enabled = true;
                btnVerGrilla.Enabled = true;
                btnVerVariables.Enabled = true;
                MessageBox.Show("Cálculo finalizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el cálculo: {ex.Message}");
            }
        }

        private void btnVerGrilla_Click(object sender, EventArgs e)
        {
            FrmGrilla form;
            if (rbNormal.Checked)
                form = new FrmGrilla(normalController.GetIntervalos());
            else if (rbExponencial.Checked)
                form = new FrmGrilla(exponentialController.GetIntervalos());
            else
                form = new FrmGrilla(uniformController.GetIntervalos());

            form.Show();
        }

        private void btnVerVariables_Click(object sender, EventArgs e)
        {
            FrmVariablesAleatorias form;
            if (rbNormal.Checked)
                form = new FrmVariablesAleatorias(normalController.GetVariables());
            else if (rbExponencial.Checked)
                form = new FrmVariablesAleatorias(exponentialController.GetVariables());
            else
                form = new FrmVariablesAleatorias(uniformController.GetVariables());

            form.Show();
        }

        private void btnVerHistograma_Click(object sender, EventArgs e)
        {
            FrmHistograma form;
            if (rbNormal.Checked)
                form = new FrmHistograma(normalController.GetIntervalos());
            else if (rbExponencial.Checked)
                form = new FrmHistograma(exponentialController.GetIntervalos());
            else
                form = new FrmHistograma(uniformController.GetIntervalos());

            form.Show();
        }

        private bool ValidarYLeerParametros()
        {

            if (txtParametro1.Text.Contains(",") || txtParametro2.Text.Contains(","))
            {
                MessageBox.Show("Usá punto (.) en lugar de coma (,) para los decimales.\nEjemplo: 2.5 en vez de 2,5.");
                return false;
            }

            // Validación de la cantidad de intervalos
            if (cmbIntervalos.SelectedItem == null ||
                !int.TryParse(cmbIntervalos.SelectedItem.ToString(), out cantidadIntervalos) ||
                (cantidadIntervalos != 10 && cantidadIntervalos != 15 && cantidadIntervalos != 20 && cantidadIntervalos != 30))
            {
                MessageBox.Show("Por favor, selecciona una cantidad de intervalos válida (10, 15, 20, 30).");
                return false;
            }

            // Validación del tamaño de la muestra
            if (!int.TryParse(txtTamanioMuestra.Text, out tamMuestra) || tamMuestra <= 0 || tamMuestra > 1000000)
            {
                MessageBox.Show("El tamaño de la muestra debe ser un número entre 1 y 1,000,000.");
                return false;
            }

            // Validación para distribución normal
            if (rbNormal.Checked)
            {
                if (!double.TryParse(txtParametro1.Text, out media) || media < -1000 || media > 1000)
                {
                    MessageBox.Show("La media debe ser un número decimal entre -1000 y 1000.");
                    return false;
                }

                if (!double.TryParse(txtParametro2.Text, out desviacion) || desviacion <= 0 || desviacion > 1000)
                {
                    MessageBox.Show("La desviación estándar debe ser un número decimal mayor que 0 y menor o igual a 1000.");
                    return false;
                }
            }
            // Validación para distribución exponencial
            else if (rbExponencial.Checked)
            {
                if (!double.TryParse(txtParametro1.Text, out lambda) || lambda <= 0)
                {
                    MessageBox.Show("Lambda debe ser un número decimal mayor que 0.");
                    return false;
                }
            }
            // Validación para distribución uniforme
            else if (rbUniforme.Checked)
            {
                if (!double.TryParse(txtParametro1.Text, out minimo) ||
                    !double.TryParse(txtParametro2.Text, out maximo) ||
                    minimo >= maximo)
                {
                    MessageBox.Show("El mínimo debe ser menor que el máximo para la distribución uniforme.");
                    return false;
                }
            }

            return true;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Desactiva los controles
            txtTamanioMuestra.Enabled = false;
            cmbIntervalos.Enabled = false;
            btnCalcular.Enabled = false;
            this.cmbIntervalos.Click += new System.EventHandler(this.cmbIntervalos_Click);
        }

        private void cmbIntervalos_Click(object sender, EventArgs e)
        {
            // Forzamos que se despliegue el ComboBox
            cmbIntervalos.DroppedDown = true;
        }
    }
}
