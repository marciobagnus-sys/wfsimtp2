using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace wfsimtp2
{
    public partial class FrmVariablesAleatorias : Form
    {
        private List<double> _variables;
        public FrmVariablesAleatorias(List<double> variables)
        {
            InitializeComponent();
            _variables = variables;
        }

        private void FrmVariablesAleatorias_Load(object sender, EventArgs e)
        {
            CargarVariablesAleatorias();
        }

        private void CargarVariablesAleatorias()
        {

            List<VariableAleatoria> datosParaGrilla = new List<VariableAleatoria>();
            for (int i = 0; i < _variables.Count; i++)
            {
                datosParaGrilla.Add(new VariableAleatoria
                {
                    Numero = i + 1,
                    Valor = _variables[i]
                });
            }

            dataGridView1.DataSource = datosParaGrilla;

            dataGridView1.Columns[0].HeaderText = "N°";
            dataGridView1.Columns[1].HeaderText = "Valor";
            dataGridView1.Columns[1].DefaultCellStyle.Format = "N4";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }

    public class VariableAleatoria
    {
        public int Numero { get; set; }
        public double Valor { get; set; }
    }
}
