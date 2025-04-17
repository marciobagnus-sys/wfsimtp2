
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using wfsimtp2.Model.Entities;
using wfsimtp2.Models;

namespace wfsimtp2
{
    public partial class FrmVariablesAleatorias : Form
    {
        private List<double> _variables;
        public FrmVariablesAleatorias(List<double> variables)
        {
            InitializeComponent();
            _variables = variables;

            // Configuración inicial para mejorar rendimiento
            dataGridView1.RowHeadersVisible = false; // Oculta los encabezados de fila
            dataGridView1.AllowUserToResizeColumns = false; // Evita redimensionamiento manual
        }

        private void FrmVariablesAleatorias_Load(object sender, EventArgs e)
        {
            CargarVariablesAleatorias();

        }

        private void CargarVariablesAleatorias()
        {

            var datos = _variables.Select(v => new VariableAleatoria { Valor = v }).ToList();
            dataGridView1.DataSource = datos;
            dataGridView1.Columns[0].HeaderText = "Valor";
            dataGridView1.Columns[0].DefaultCellStyle.Format = "N4";


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Calcula el ancho necesario
            int anchoColumna = CalcularAnchoColumna();
            dataGridView1.Columns[0].Width = anchoColumna;

            // Ajusta el tamaño del formulario al DataGridView
            this.ClientSize = new Size(dataGridView1.Columns[0].Width + 40, dataGridView1.RowTemplate.Height * _variables.Count + dataGridView1.ColumnHeadersHeight + 40);
        }
        private int CalcularAnchoColumna()
        {
            // Fuente usada en el DataGridView (asume la misma que la celda)
            Font fuente = dataGridView1.DefaultCellStyle.Font ?? new Font("Segoe UI", 8);

            // Ancho del encabezado
            int anchoEncabezado = TextRenderer.MeasureText(
                dataGridView1.Columns[0].HeaderText,
                dataGridView1.ColumnHeadersDefaultCellStyle.Font
            ).Width;

            // Ancho máximo de los datos (ejemplo con el valor más largo posible, ej: 1234.5678)
            string ejemploValor = (-9999.9999).ToString("N4"); // Valor con signo y 4 decimales
            int anchoDatos = TextRenderer.MeasureText(ejemploValor, fuente).Width;

            // Margen adicional para bordes y padding (ajusta según necesidad)
            int margen = 20;

            return Math.Max(anchoEncabezado, anchoDatos) + margen;
        }
    }
}