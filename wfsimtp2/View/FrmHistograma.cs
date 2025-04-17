using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using wfsimtp2.Model;

namespace wfsimtp2
{
    public partial class FrmHistograma : Form
    {
        public FrmHistograma(List<IntervaloFrecuencia> intervalos)
        {
            InitializeComponent();
            GenerarHistograma(intervalos);
        }

        private void GenerarHistograma(List<IntervaloFrecuencia> intervalos)
        {
            chartHistograma.Series.Clear();
            chartHistograma.ChartAreas.Clear();
            chartHistograma.Legends.Clear();

            // Área del gráfico
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartArea.AxisX.Title = "Intervalos";
            chartArea.AxisY.Title = "Frecuencia Observada";
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 12, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 10);
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            chartHistograma.ChartAreas.Add(chartArea);

            // Leyenda al costado
            Legend legend = new Legend("Legend1");
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            chartHistograma.Legends.Add(legend);

            // Serie
            Series serie = new Series("Frecuencia");
            serie.ChartArea = "ChartArea1";
            serie.Legend = "Legend1";
            serie.ChartType = SeriesChartType.Column;
            serie.Color = Color.SteelBlue;
            serie["PointWidth"] = "1.0";

            foreach (var intervalo in intervalos)
            {
                string etiqueta = $"{intervalo.LimiteInferior.ToString("0.00")} – {intervalo.LimiteSuperior.ToString("0.00")}";
                double frecuencia = intervalo.FrecuenciaObservada;
                serie.Points.AddXY(etiqueta, frecuencia);
            }

            chartHistograma.Series.Add(serie);
        }
    }
}
