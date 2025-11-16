namespace Yenci_parte
{
    partial class Venta
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPedidosRealizados = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvPedidoCliente = new System.Windows.Forms.DataGridView();
            this.btnQuitarPedido = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtApellidosCliente = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservacionPlato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCantidadBebida = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbBebidas = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbTipoVenta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidadPlato = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPlatos = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMontoRecibido = new System.Windows.Forms.TextBox();
            this.lblVuelto = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAgregarPedido = new System.Windows.Forms.Button();
            this.txtDniBuscar = new System.Windows.Forms.TextBox();
            this.txtBuscarCliente = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosRealizados)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoCliente)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(322, 672);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Anular Venta ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.dgvPedidosRealizados);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(1303, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 741);
            this.panel1.TabIndex = 20;
            // 
            // dgvPedidosRealizados
            // 
            this.dgvPedidosRealizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosRealizados.Location = new System.Drawing.Point(21, 21);
            this.dgvPedidosRealizados.Name = "dgvPedidosRealizados";
            this.dgvPedidosRealizados.RowHeadersWidth = 62;
            this.dgvPedidosRealizados.RowTemplate.Height = 28;
            this.dgvPedidosRealizados.Size = new System.Drawing.Size(700, 639);
            this.dgvPedidosRealizados.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.dgvPedidoCliente);
            this.panel2.Controls.Add(this.btnQuitarPedido);
            this.panel2.Controls.Add(this.btnRegistrar);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.txtObservacionPlato);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btnAgregarPedido);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1265, 782);
            this.panel2.TabIndex = 21;
            // 
            // dgvPedidoCliente
            // 
            this.dgvPedidoCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoCliente.Location = new System.Drawing.Point(21, 21);
            this.dgvPedidoCliente.Name = "dgvPedidoCliente";
            this.dgvPedidoCliente.RowHeadersWidth = 62;
            this.dgvPedidoCliente.RowTemplate.Height = 28;
            this.dgvPedidoCliente.Size = new System.Drawing.Size(663, 323);
            this.dgvPedidoCliente.TabIndex = 35;
            // 
            // btnQuitarPedido
            // 
            this.btnQuitarPedido.Location = new System.Drawing.Point(243, 350);
            this.btnQuitarPedido.Name = "btnQuitarPedido";
            this.btnQuitarPedido.Size = new System.Drawing.Size(211, 40);
            this.btnQuitarPedido.TabIndex = 34;
            this.btnQuitarPedido.Text = "Quitar del pedido";
            this.btnQuitarPedido.UseVisualStyleBackColor = true;
            this.btnQuitarPedido.Click += new System.EventHandler(this.btnQuitarPedido_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(563, 730);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(152, 40);
            this.btnRegistrar.TabIndex = 33;
            this.btnRegistrar.Text = "Registrar Venta ";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.button3_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Aquamarine;
            this.label12.Location = new System.Drawing.Point(1152, 745);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 25);
            this.label12.TabIndex = 30;
            this.label12.Text = "Regresar";
            this.label12.Click += new System.EventHandler(this.label12_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBuscarCliente);
            this.groupBox3.Controls.Add(this.txtDniBuscar);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.txtApellidosCliente);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtNombreCliente);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(715, 445);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 282);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos Cliente";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 190);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 25);
            this.label14.TabIndex = 4;
            this.label14.Text = "DNI:";
            // 
            // txtApellidosCliente
            // 
            this.txtApellidosCliente.Location = new System.Drawing.Point(35, 154);
            this.txtApellidosCliente.Name = "txtApellidosCliente";
            this.txtApellidosCliente.ReadOnly = true;
            this.txtApellidosCliente.Size = new System.Drawing.Size(331, 30);
            this.txtApellidosCliente.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "Apellidos:";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(35, 77);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(331, 30);
            this.txtNombreCliente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre:";
            // 
            // txtObservacionPlato
            // 
            this.txtObservacionPlato.Location = new System.Drawing.Point(262, 434);
            this.txtObservacionPlato.Multiline = true;
            this.txtObservacionPlato.Name = "txtObservacionPlato";
            this.txtObservacionPlato.Size = new System.Drawing.Size(422, 239);
            this.txtObservacionPlato.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(403, 398);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 25;
            this.label3.Text = "Observacion:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCantidadBebida);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cmbBebidas);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cmbTipoVenta);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCantidadPlato);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbPlatos);
            this.groupBox2.Location = new System.Drawing.Point(715, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 378);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Pedidos";
            // 
            // txtCantidadBebida
            // 
            this.txtCantidadBebida.Location = new System.Drawing.Point(309, 265);
            this.txtCantidadBebida.Name = "txtCantidadBebida";
            this.txtCantidadBebida.Size = new System.Drawing.Size(113, 30);
            this.txtCantidadBebida.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(325, 237);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 25);
            this.label16.TabIndex = 34;
            this.label16.Text = "Cantidad:";
            // 
            // cmbBebidas
            // 
            this.cmbBebidas.FormattingEnabled = true;
            this.cmbBebidas.Location = new System.Drawing.Point(234, 201);
            this.cmbBebidas.Name = "cmbBebidas";
            this.cmbBebidas.Size = new System.Drawing.Size(259, 33);
            this.cmbBebidas.TabIndex = 32;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(325, 173);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 25);
            this.label15.TabIndex = 31;
            this.label15.Text = "Bebida:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(18, 325);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(348, 30);
            this.dateTimePicker1.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 297);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 25);
            this.label13.TabIndex = 29;
            this.label13.Text = "Fecha:";
            // 
            // cmbTipoVenta
            // 
            this.cmbTipoVenta.FormattingEnabled = true;
            this.cmbTipoVenta.Items.AddRange(new object[] {
            "Presencial",
            "Llevar "});
            this.cmbTipoVenta.Location = new System.Drawing.Point(146, 54);
            this.cmbTipoVenta.Name = "cmbTipoVenta";
            this.cmbTipoVenta.Size = new System.Drawing.Size(239, 33);
            this.cmbTipoVenta.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Platos:";
            // 
            // txtCantidadPlato
            // 
            this.txtCantidadPlato.Location = new System.Drawing.Point(35, 204);
            this.txtCantidadPlato.Name = "txtCantidadPlato";
            this.txtCantidadPlato.Size = new System.Drawing.Size(113, 30);
            this.txtCantidadPlato.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Cantidad:";
            // 
            // cmbPlatos
            // 
            this.cmbPlatos.FormattingEnabled = true;
            this.cmbPlatos.Location = new System.Drawing.Point(35, 118);
            this.cmbPlatos.Name = "cmbPlatos";
            this.cmbPlatos.Size = new System.Drawing.Size(408, 33);
            this.cmbPlatos.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMontoRecibido);
            this.groupBox1.Controls.Add(this.lblVuelto);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtTotalPagar);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(21, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 278);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resumen Pago";
            // 
            // txtMontoRecibido
            // 
            this.txtMontoRecibido.Location = new System.Drawing.Point(29, 166);
            this.txtMontoRecibido.Name = "txtMontoRecibido";
            this.txtMontoRecibido.Size = new System.Drawing.Size(164, 30);
            this.txtMontoRecibido.TabIndex = 6;
            this.txtMontoRecibido.TextChanged += new System.EventHandler(this.txtMontoRecibido_TextChanged);
            // 
            // lblVuelto
            // 
            this.lblVuelto.AutoSize = true;
            this.lblVuelto.Location = new System.Drawing.Point(68, 229);
            this.lblVuelto.Name = "lblVuelto";
            this.lblVuelto.Size = new System.Drawing.Size(75, 25);
            this.lblVuelto.TabIndex = 5;
            this.lblVuelto.Text = "label11";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 25);
            this.label10.TabIndex = 4;
            this.label10.Text = "Vuelto:";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(25, 79);
            this.txtTotalPagar.Multiline = true;
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(168, 33);
            this.txtTotalPagar.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Monto Recibido:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total a pagar:";
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.Location = new System.Drawing.Point(330, 679);
            this.btnAgregarPedido.Name = "btnAgregarPedido";
            this.btnAgregarPedido.Size = new System.Drawing.Size(311, 40);
            this.btnAgregarPedido.TabIndex = 21;
            this.btnAgregarPedido.Text = "Agregar a Pedido de cliente ";
            this.btnAgregarPedido.UseVisualStyleBackColor = true;
            this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // txtDniBuscar
            // 
            this.txtDniBuscar.Location = new System.Drawing.Point(35, 227);
            this.txtDniBuscar.Name = "txtDniBuscar";
            this.txtDniBuscar.Size = new System.Drawing.Size(331, 30);
            this.txtDniBuscar.TabIndex = 5;
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Location = new System.Drawing.Point(387, 224);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(121, 37);
            this.txtBuscarCliente.TabIndex = 6;
            this.txtBuscarCliente.Text = "Buscar";
            this.txtBuscarCliente.UseVisualStyleBackColor = true;
            this.txtBuscarCliente.Click += new System.EventHandler(this.txtBuscarCliente_Click);
            // 
            // Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(2055, 804);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Venta";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Venta_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosRealizados)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoCliente)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantidadPlato;
        private System.Windows.Forms.TextBox txtObservacionPlato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPlatos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbTipoVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblVuelto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregarPedido;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellidosCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbBebidas;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCantidadBebida;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnQuitarPedido;
        private System.Windows.Forms.DataGridView dgvPedidoCliente;
        private System.Windows.Forms.DataGridView dgvPedidosRealizados;
        private System.Windows.Forms.TextBox txtMontoRecibido;
        private System.Windows.Forms.Button txtBuscarCliente;
        private System.Windows.Forms.TextBox txtDniBuscar;
    }
}

