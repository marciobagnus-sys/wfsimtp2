using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wfsimtp2
{
    partial class Menu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox groupBoxDistribucion;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbExponencial;
        private System.Windows.Forms.RadioButton rbUniforme;

        private System.Windows.Forms.GroupBox groupBoxParametros;
        private System.Windows.Forms.Label lblParametro1;
        private System.Windows.Forms.TextBox txtParametro1;
        private System.Windows.Forms.Label lblParametro2;
        private System.Windows.Forms.TextBox txtParametro2;

        private System.Windows.Forms.GroupBox groupBoxGenerales;
        private System.Windows.Forms.Label lblTamanioMuestra;
        private System.Windows.Forms.TextBox txtTamanioMuestra;
        private System.Windows.Forms.Label lblCantidadIntervalos;
        private System.Windows.Forms.Button btnCalcular;

        private System.Windows.Forms.Panel panelResultados;
        private System.Windows.Forms.Button btnVerHistograma;
        private System.Windows.Forms.Button btnVerGrilla;
        private System.Windows.Forms.Button btnVerVariables;

        private System.Windows.Forms.Label lblDescripcion;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBoxDistribucion = new System.Windows.Forms.GroupBox();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbExponencial = new System.Windows.Forms.RadioButton();
            this.rbUniforme = new System.Windows.Forms.RadioButton();
            this.groupBoxParametros = new System.Windows.Forms.GroupBox();
            this.lblParametro1 = new System.Windows.Forms.Label();
            this.txtParametro1 = new System.Windows.Forms.TextBox();
            this.lblParametro2 = new System.Windows.Forms.Label();
            this.txtParametro2 = new System.Windows.Forms.TextBox();
            this.groupBoxGenerales = new System.Windows.Forms.GroupBox();
            this.cmbIntervalos = new System.Windows.Forms.ComboBox();
            this.lblTamanioMuestra = new System.Windows.Forms.Label();
            this.txtTamanioMuestra = new System.Windows.Forms.TextBox();
            this.lblCantidadIntervalos = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.panelResultados = new System.Windows.Forms.Panel();
            this.btnVerHistograma = new System.Windows.Forms.Button();
            this.btnVerGrilla = new System.Windows.Forms.Button();
            this.btnVerVariables = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.groupBoxDistribucion.SuspendLayout();
            this.groupBoxParametros.SuspendLayout();
            this.groupBoxGenerales.SuspendLayout();
            this.panelResultados.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDistribucion
            // 
            this.groupBoxDistribucion.Controls.Add(this.rbNormal);
            this.groupBoxDistribucion.Controls.Add(this.rbExponencial);
            this.groupBoxDistribucion.Controls.Add(this.rbUniforme);
            this.groupBoxDistribucion.Location = new System.Drawing.Point(20, 60);
            this.groupBoxDistribucion.Name = "groupBoxDistribucion";
            this.groupBoxDistribucion.Size = new System.Drawing.Size(300, 150);
            this.groupBoxDistribucion.TabIndex = 1;
            this.groupBoxDistribucion.TabStop = false;
            this.groupBoxDistribucion.Text = "Distribución";
            // 
            // rbNormal
            // 
            this.rbNormal.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.rbNormal.Location = new System.Drawing.Point(10, 30);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(104, 34);
            this.rbNormal.TabIndex = 0;
            this.rbNormal.Text = "Normal";
            this.rbNormal.CheckedChanged += new System.EventHandler(this.RbDistribucion_CheckedChanged);
            // 
            // rbExponencial
            // 
            this.rbExponencial.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.rbExponencial.Location = new System.Drawing.Point(10, 70);
            this.rbExponencial.Name = "rbExponencial";
            this.rbExponencial.Size = new System.Drawing.Size(162, 34);
            this.rbExponencial.TabIndex = 1;
            this.rbExponencial.Text = "Exponencial";
            this.rbExponencial.CheckedChanged += new System.EventHandler(this.RbDistribucion_CheckedChanged);
            // 
            // rbUniforme
            // 
            this.rbUniforme.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.rbUniforme.Location = new System.Drawing.Point(10, 110);
            this.rbUniforme.Name = "rbUniforme";
            this.rbUniforme.Size = new System.Drawing.Size(149, 34);
            this.rbUniforme.TabIndex = 2;
            this.rbUniforme.Text = "Uniforme";
            this.rbUniforme.CheckedChanged += new System.EventHandler(this.RbDistribucion_CheckedChanged);
            // 
            // groupBoxParametros
            // 
            this.groupBoxParametros.Controls.Add(this.lblParametro1);
            this.groupBoxParametros.Controls.Add(this.txtParametro1);
            this.groupBoxParametros.Controls.Add(this.lblParametro2);
            this.groupBoxParametros.Controls.Add(this.txtParametro2);
            this.groupBoxParametros.Location = new System.Drawing.Point(350, 60);
            this.groupBoxParametros.Name = "groupBoxParametros";
            this.groupBoxParametros.Size = new System.Drawing.Size(300, 150);
            this.groupBoxParametros.TabIndex = 2;
            this.groupBoxParametros.TabStop = false;
            this.groupBoxParametros.Text = "Parámetros";
            // 
            // lblParametro1
            // 
            this.lblParametro1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblParametro1.Location = new System.Drawing.Point(10, 30);
            this.lblParametro1.Name = "lblParametro1";
            this.lblParametro1.Size = new System.Drawing.Size(104, 32);
            this.lblParametro1.TabIndex = 0;
            this.lblParametro1.Visible = false;
            // 
            // txtParametro1
            // 
            this.txtParametro1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtParametro1.Location = new System.Drawing.Point(123, 30);
            this.txtParametro1.Name = "txtParametro1";
            this.txtParametro1.Size = new System.Drawing.Size(150, 32);
            this.txtParametro1.TabIndex = 1;
            this.txtParametro1.Visible = false;
            // 
            // lblParametro2
            // 
            this.lblParametro2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblParametro2.Location = new System.Drawing.Point(10, 70);
            this.lblParametro2.Name = "lblParametro2";
            this.lblParametro2.Size = new System.Drawing.Size(104, 32);
            this.lblParametro2.TabIndex = 2;
            this.lblParametro2.Visible = false;
            // 
            // txtParametro2
            // 
            this.txtParametro2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtParametro2.Location = new System.Drawing.Point(123, 70);
            this.txtParametro2.Name = "txtParametro2";
            this.txtParametro2.Size = new System.Drawing.Size(150, 32);
            this.txtParametro2.TabIndex = 3;
            this.txtParametro2.Visible = false;
            // 
            // groupBoxGenerales
            // 
            this.groupBoxGenerales.Controls.Add(this.cmbIntervalos);
            this.groupBoxGenerales.Controls.Add(this.lblTamanioMuestra);
            this.groupBoxGenerales.Controls.Add(this.txtTamanioMuestra);
            this.groupBoxGenerales.Controls.Add(this.lblCantidadIntervalos);
            this.groupBoxGenerales.Location = new System.Drawing.Point(20, 230);
            this.groupBoxGenerales.Name = "groupBoxGenerales";
            this.groupBoxGenerales.Size = new System.Drawing.Size(630, 120);
            this.groupBoxGenerales.TabIndex = 3;
            this.groupBoxGenerales.TabStop = false;
            this.groupBoxGenerales.Text = "Parámetros Generales";
            // 
            // cmbIntervalos
            // 
            this.cmbIntervalos.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbIntervalos.FormattingEnabled = true;
            this.cmbIntervalos.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "30"});
            this.cmbIntervalos.Location = new System.Drawing.Point(522, 49);
            this.cmbIntervalos.Name = "cmbIntervalos";
            this.cmbIntervalos.Size = new System.Drawing.Size(81, 29);
            this.cmbIntervalos.TabIndex = 3;
            // 
            // lblTamanioMuestra
            // 
            this.lblTamanioMuestra.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTamanioMuestra.Location = new System.Drawing.Point(10, 49);
            this.lblTamanioMuestra.Name = "lblTamanioMuestra";
            this.lblTamanioMuestra.Size = new System.Drawing.Size(184, 23);
            this.lblTamanioMuestra.TabIndex = 0;
            this.lblTamanioMuestra.Text = "Tamaño de muestra:";
            // 
            // txtTamanioMuestra
            // 
            this.txtTamanioMuestra.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtTamanioMuestra.Location = new System.Drawing.Point(200, 46);
            this.txtTamanioMuestra.Name = "txtTamanioMuestra";
            this.txtTamanioMuestra.Size = new System.Drawing.Size(150, 32);
            this.txtTamanioMuestra.TabIndex = 1;
            // 
            // lblCantidadIntervalos
            // 
            this.lblCantidadIntervalos.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblCantidadIntervalos.Location = new System.Drawing.Point(370, 49);
            this.lblCantidadIntervalos.Name = "lblCantidadIntervalos";
            this.lblCantidadIntervalos.Size = new System.Drawing.Size(146, 23);
            this.lblCantidadIntervalos.TabIndex = 2;
            this.lblCantidadIntervalos.Text = "Cant. intervalos:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCalcular.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(232, 375);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(180, 60);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.BtnCalcular_Click);
            // 
            // panelResultados
            // 
            this.panelResultados.Controls.Add(this.btnVerHistograma);
            this.panelResultados.Controls.Add(this.btnVerGrilla);
            this.panelResultados.Controls.Add(this.btnVerVariables);
            this.panelResultados.Location = new System.Drawing.Point(20, 463);
            this.panelResultados.Name = "panelResultados";
            this.panelResultados.Size = new System.Drawing.Size(630, 125);
            this.panelResultados.TabIndex = 5;
            this.panelResultados.Visible = false;
            // 
            // btnVerHistograma
            // 
            this.btnVerHistograma.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnVerHistograma.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnVerHistograma.ForeColor = System.Drawing.Color.White;
            this.btnVerHistograma.Location = new System.Drawing.Point(10, 34);
            this.btnVerHistograma.Name = "btnVerHistograma";
            this.btnVerHistograma.Size = new System.Drawing.Size(162, 57);
            this.btnVerHistograma.TabIndex = 0;
            this.btnVerHistograma.Text = "Ver Histograma";
            this.btnVerHistograma.UseVisualStyleBackColor = false;
            this.btnVerHistograma.Click += new System.EventHandler(this.btnVerHistograma_Click);
            // 
            // btnVerGrilla
            // 
            this.btnVerGrilla.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnVerGrilla.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnVerGrilla.ForeColor = System.Drawing.Color.White;
            this.btnVerGrilla.Location = new System.Drawing.Point(230, 34);
            this.btnVerGrilla.Name = "btnVerGrilla";
            this.btnVerGrilla.Size = new System.Drawing.Size(162, 57);
            this.btnVerGrilla.TabIndex = 1;
            this.btnVerGrilla.Text = "Ver Grilla";
            this.btnVerGrilla.UseVisualStyleBackColor = false;
            this.btnVerGrilla.Click += new System.EventHandler(this.btnVerGrilla_Click);
            // 
            // btnVerVariables
            // 
            this.btnVerVariables.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnVerVariables.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnVerVariables.ForeColor = System.Drawing.Color.White;
            this.btnVerVariables.Location = new System.Drawing.Point(443, 34);
            this.btnVerVariables.Name = "btnVerVariables";
            this.btnVerVariables.Size = new System.Drawing.Size(157, 57);
            this.btnVerVariables.TabIndex = 2;
            this.btnVerVariables.Text = "Ver Variables";
            this.btnVerVariables.UseVisualStyleBackColor = false;
            this.btnVerVariables.Click += new System.EventHandler(this.btnVerVariables_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.Location = new System.Drawing.Point(20, 10);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(630, 40);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Ingrese los parámetros para simular la distribución seleccionada";
            this.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(663, 616);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.groupBoxDistribucion);
            this.Controls.Add(this.groupBoxParametros);
            this.Controls.Add(this.groupBoxGenerales);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.panelResultados);
            this.Name = "Menu";
            this.Text = "Simulador de Distribuciones Aleatorias";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBoxDistribucion.ResumeLayout(false);
            this.groupBoxParametros.ResumeLayout(false);
            this.groupBoxParametros.PerformLayout();
            this.groupBoxGenerales.ResumeLayout(false);
            this.groupBoxGenerales.PerformLayout();
            this.panelResultados.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private ComboBox cmbIntervalos;
    }
}
