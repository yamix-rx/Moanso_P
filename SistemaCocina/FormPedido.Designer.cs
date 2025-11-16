namespace Yenci_parte
{
    partial class FormPedido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnActualizarPedidos = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlatoSeleccionado = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnListo = new System.Windows.Forms.Button();
            this.btnPreparar = new System.Windows.Forms.Button();
            this.dgvReceta = new System.Windows.Forms.DataGridView();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActualizarPedidos
            // 
            this.btnActualizarPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarPedidos.Location = new System.Drawing.Point(466, 394);
            this.btnActualizarPedidos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnActualizarPedidos.Name = "btnActualizarPedidos";
            this.btnActualizarPedidos.Size = new System.Drawing.Size(140, 76);
            this.btnActualizarPedidos.TabIndex = 17;
            this.btnActualizarPedidos.Text = "Actualizar";
            this.btnActualizarPedidos.UseVisualStyleBackColor = true;
            this.btnActualizarPedidos.Click += new System.EventHandler(this.btnActualizarPedidos_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 834);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Plato Seleccionado:";
            // 
            // lblPlatoSeleccionado
            // 
            this.lblPlatoSeleccionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlatoSeleccionado.Location = new System.Drawing.Point(222, 834);
            this.lblPlatoSeleccionado.Name = "lblPlatoSeleccionado";
            this.lblPlatoSeleccionado.Size = new System.Drawing.Size(194, 25);
            this.lblPlatoSeleccionado.TabIndex = 15;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(802, 892);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 76);
            this.btnSalir.TabIndex = 14;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnListo
            // 
            this.btnListo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListo.Location = new System.Drawing.Point(466, 892);
            this.btnListo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnListo.Name = "btnListo";
            this.btnListo.Size = new System.Drawing.Size(140, 76);
            this.btnListo.TabIndex = 13;
            this.btnListo.Text = "Notificar Mozo";
            this.btnListo.UseVisualStyleBackColor = true;
            this.btnListo.Click += new System.EventHandler(this.btnListo_Click);
            // 
            // btnPreparar
            // 
            this.btnPreparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreparar.Location = new System.Drawing.Point(76, 892);
            this.btnPreparar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPreparar.Name = "btnPreparar";
            this.btnPreparar.Size = new System.Drawing.Size(140, 76);
            this.btnPreparar.TabIndex = 12;
            this.btnPreparar.Text = "Descontar Stock";
            this.btnPreparar.UseVisualStyleBackColor = true;
            this.btnPreparar.Click += new System.EventHandler(this.btnPreparar_Click);
            // 
            // dgvReceta
            // 
            this.dgvReceta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceta.Location = new System.Drawing.Point(43, 529);
            this.dgvReceta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvReceta.Name = "dgvReceta";
            this.dgvReceta.RowHeadersWidth = 51;
            this.dgvReceta.RowTemplate.Height = 24;
            this.dgvReceta.Size = new System.Drawing.Size(989, 280);
            this.dgvReceta.TabIndex = 11;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(43, 90);
            this.dgvPedidos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.RowTemplate.Height = 24;
            this.dgvPedidos.Size = new System.Drawing.Size(989, 280);
            this.dgvPedidos.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(657, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "COCINA - PREPARACIÓN DE PEDIDOS";
            // 
            // FormPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 988);
            this.Controls.Add(this.btnActualizarPedidos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPlatoSeleccionado);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnListo);
            this.Controls.Add(this.btnPreparar);
            this.Controls.Add(this.dgvReceta);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.label1);
            this.Name = "FormPedido";
            this.Text = "FormPedido";
            this.Load += new System.EventHandler(this.FormPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizarPedidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPlatoSeleccionado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnListo;
        private System.Windows.Forms.Button btnPreparar;
        private System.Windows.Forms.DataGridView dgvReceta;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Label label1;
    }
}