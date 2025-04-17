using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using wfsimtp2.Model;
using wfsimtp2.Model.Entities;

namespace wfsimtp2
{
    public partial class FrmGrilla : Form
    {
        public FrmGrilla(List<IntervaloFrecuencia> intervalos)
        {
            InitializeComponent();
            InicializarGrilla();
            CargarDatosDesdeLista(intervalos);
        }

        private void InicializarGrilla()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Intervalo",
                HeaderText = "N° Intervalo",
                DataPropertyName = "Numero"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Desde",
                HeaderText = "Desde",
                DataPropertyName = "Desde"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Hasta",
                HeaderText = "Hasta",
                DataPropertyName = "Hasta"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Frecuencia",
                HeaderText = "Frecuencia Observada",
                DataPropertyName = "Frecuencia"
            });
        }

        private void CargarDatosDesdeLista(List<IntervaloFrecuencia> intervalos)
        {
            var listaGrilla = new List<GrillaItem>();

            for (int i = 0; i < intervalos.Count; i++)
            {
                var it = intervalos[i];
                listaGrilla.Add(new GrillaItem
                {
                    Numero = i + 1,
                    Desde = Math.Round(it.LimiteInferior, 2),
                    Hasta = Math.Round(it.LimiteSuperior, 2),
                    Frecuencia = (int)it.FrecuenciaObservada
                });
            }

            dataGridView1.DataSource = listaGrilla;
        }

        private void FrmGrilla_Load(object sender, EventArgs e)
        {
            // Ajustar automáticamente el tamaño de las columnas según su contenido
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // Calcular el ancho total de las columnas visibles (si lo deseas para ajustar la ventana)
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                totalColumnWidth += column.Width;
            }

            // Ajustar el tamaño de la ventana al contenido de la grilla
            int width = totalColumnWidth + 40;  // Añadir algo de margen
            int height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height + 50; // Ajustar alto

            this.ClientSize = new Size(width, height);
        }
    }
}
