namespace wfsimtp2
{
    partial class FrmHistograma
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartHistograma;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.chartHistograma = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartHistograma)).BeginInit();
            this.SuspendLayout();

            // chartHistograma
            this.chartHistograma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartHistograma.Location = new System.Drawing.Point(0, 0);
            this.chartHistograma.Name = "chartHistograma";
            this.chartHistograma.Size = new System.Drawing.Size(800, 600);
            this.chartHistograma.TabIndex = 0;
            this.chartHistograma.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());

            // FrmHistograma
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.chartHistograma);
            this.Name = "FrmHistograma";
            this.Text = "Histograma";

            ((System.ComponentModel.ISupportInitialize)(this.chartHistograma)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
