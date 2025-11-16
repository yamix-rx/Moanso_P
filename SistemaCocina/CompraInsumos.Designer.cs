namespace SistemaForms
{
    partial class CompraInsumos
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
            this.btnRegistrarPedido = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtCantidad3 = new System.Windows.Forms.TextBox();
            this.cmbInsumo3 = new System.Windows.Forms.ComboBox();
            this.dtpFecha3 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegistrarPedido
            // 
            this.btnRegistrarPedido.Location = new System.Drawing.Point(215, 182);
            this.btnRegistrarPedido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegistrarPedido.Name = "btnRegistrarPedido";
            this.btnRegistrarPedido.Size = new System.Drawing.Size(289, 35);
            this.btnRegistrarPedido.TabIndex = 27;
            this.btnRegistrarPedido.Text = "Registrar Pedido Insumos";
            this.btnRegistrarPedido.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 261);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(908, 231);
            this.dataGridView1.TabIndex = 26;
            // 
            // txtCantidad3
            // 
            this.txtCantidad3.Location = new System.Drawing.Point(122, 115);
            this.txtCantidad3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCantidad3.Name = "txtCantidad3";
            this.txtCantidad3.Size = new System.Drawing.Size(99, 26);
            this.txtCantidad3.TabIndex = 24;
            // 
            // cmbInsumo3
            // 
            this.cmbInsumo3.FormattingEnabled = true;
            this.cmbInsumo3.Location = new System.Drawing.Point(108, 41);
            this.cmbInsumo3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbInsumo3.Name = "cmbInsumo3";
            this.cmbInsumo3.Size = new System.Drawing.Size(180, 28);
            this.cmbInsumo3.TabIndex = 23;
            // 
            // dtpFecha3
            // 
            this.dtpFecha3.Location = new System.Drawing.Point(415, 39);
            this.dtpFecha3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFecha3.Name = "dtpFecha3";
            this.dtpFecha3.Size = new System.Drawing.Size(298, 26);
            this.dtpFecha3.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Cantidad :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Insumo :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Proveedor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(335, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(428, 107);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(285, 28);
            this.comboBox1.TabIndex = 30;
            // 
            // CompraInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 506);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnRegistrarPedido);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtCantidad3);
            this.Controls.Add(this.cmbInsumo3);
            this.Controls.Add(this.dtpFecha3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "CompraInsumos";
            this.Text = "CompraInsumos";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRegistrarPedido;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCantidad3;
        private System.Windows.Forms.ComboBox cmbInsumo3;
        private System.Windows.Forms.DateTimePicker dtpFecha3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}