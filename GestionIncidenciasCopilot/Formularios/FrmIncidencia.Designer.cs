namespace GestionIncidenciasCopilot.Formularios
{
    partial class FrmIncidencia
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label labelEncabezado;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textTitulo;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label labelPrioridad;
        private System.Windows.Forms.ComboBox comboPrioridad;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.TextBox textEstado;
        private System.Windows.Forms.Label labelFechaCreacion;
        private System.Windows.Forms.TextBox textFechaCreacion;
        private System.Windows.Forms.Label labelFechaActualizacion;
        private System.Windows.Forms.TextBox textFechaActualizacion;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button botonCancelar;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.ErrorProvider errorProvider;

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
            this.components = new System.ComponentModel.Container();
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.labelEncabezado = new System.Windows.Forms.Label();
            this.labelSubtitulo = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.textTitulo = new System.Windows.Forms.TextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.labelPrioridad = new System.Windows.Forms.Label();
            this.comboPrioridad = new System.Windows.Forms.ComboBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.textEstado = new System.Windows.Forms.TextBox();
            this.labelFechaCreacion = new System.Windows.Forms.Label();
            this.textFechaCreacion = new System.Windows.Forms.TextBox();
            this.labelFechaActualizacion = new System.Windows.Forms.Label();
            this.textFechaActualizacion = new System.Windows.Forms.TextBox();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.botonCancelar = new System.Windows.Forms.Button();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelEncabezado.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(31, 52, 77);
            this.panelEncabezado.Controls.Add(this.labelSubtitulo);
            this.panelEncabezado.Controls.Add(this.labelEncabezado);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Padding = new System.Windows.Forms.Padding(30, 22, 30, 18);
            this.panelEncabezado.Size = new System.Drawing.Size(780, 112);
            this.panelEncabezado.TabIndex = 0;
            // 
            // labelEncabezado
            // 
            this.labelEncabezado.AutoSize = true;
            this.labelEncabezado.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Bold);
            this.labelEncabezado.ForeColor = System.Drawing.Color.White;
            this.labelEncabezado.Location = new System.Drawing.Point(27, 17);
            this.labelEncabezado.Name = "labelEncabezado";
            this.labelEncabezado.Size = new System.Drawing.Size(236, 36);
            this.labelEncabezado.TabIndex = 0;
            this.labelEncabezado.Text = "Registrar incidencia";
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelSubtitulo.ForeColor = System.Drawing.Color.FromArgb(220, 230, 241);
            this.labelSubtitulo.Location = new System.Drawing.Point(31, 67);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(302, 17);
            this.labelSubtitulo.TabIndex = 1;
            this.labelSubtitulo.Text = "Describe el problema y define su prioridad.";
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.labelTitulo);
            this.panelContenido.Controls.Add(this.textTitulo);
            this.panelContenido.Controls.Add(this.labelDescripcion);
            this.panelContenido.Controls.Add(this.textDescripcion);
            this.panelContenido.Controls.Add(this.labelPrioridad);
            this.panelContenido.Controls.Add(this.comboPrioridad);
            this.panelContenido.Controls.Add(this.labelEstado);
            this.panelContenido.Controls.Add(this.textEstado);
            this.panelContenido.Controls.Add(this.labelFechaCreacion);
            this.panelContenido.Controls.Add(this.textFechaCreacion);
            this.panelContenido.Controls.Add(this.labelFechaActualizacion);
            this.panelContenido.Controls.Add(this.textFechaActualizacion);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 112);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(32, 24, 32, 18);
            this.panelContenido.Size = new System.Drawing.Size(780, 463);
            this.panelContenido.TabIndex = 1;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.labelTitulo.Location = new System.Drawing.Point(34, 24);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(47, 19);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Título";
            // 
            // textTitulo
            // 
            this.textTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textTitulo.Location = new System.Drawing.Point(38, 49);
            this.textTitulo.MaxLength = 120;
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.Size = new System.Drawing.Size(704, 25);
            this.textTitulo.TabIndex = 1;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelDescripcion.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.labelDescripcion.Location = new System.Drawing.Point(34, 91);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(80, 19);
            this.labelDescripcion.TabIndex = 2;
            this.labelDescripcion.Text = "Descripción";
            // 
            // textDescripcion
            // 
            this.textDescripcion.AcceptsReturn = true;
            this.textDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textDescripcion.Location = new System.Drawing.Point(38, 116);
            this.textDescripcion.MaxLength = 2000;
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDescripcion.Size = new System.Drawing.Size(704, 111);
            this.textDescripcion.TabIndex = 3;
            // 
            // labelPrioridad
            // 
            this.labelPrioridad.AutoSize = true;
            this.labelPrioridad.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelPrioridad.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.labelPrioridad.Location = new System.Drawing.Point(34, 244);
            this.labelPrioridad.Name = "labelPrioridad";
            this.labelPrioridad.Size = new System.Drawing.Size(61, 19);
            this.labelPrioridad.TabIndex = 4;
            this.labelPrioridad.Text = "Prioridad";
            // 
            // comboPrioridad
            // 
            this.comboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPrioridad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboPrioridad.FormattingEnabled = true;
            this.comboPrioridad.Location = new System.Drawing.Point(38, 269);
            this.comboPrioridad.Name = "comboPrioridad";
            this.comboPrioridad.Size = new System.Drawing.Size(220, 25);
            this.comboPrioridad.TabIndex = 5;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.labelEstado.Location = new System.Drawing.Point(34, 313);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(50, 19);
            this.labelEstado.TabIndex = 6;
            this.labelEstado.Text = "Estado";
            // 
            // textEstado
            // 
            this.textEstado.BackColor = System.Drawing.Color.FromArgb(243, 246, 249);
            this.textEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textEstado.Location = new System.Drawing.Point(38, 338);
            this.textEstado.Name = "textEstado";
            this.textEstado.ReadOnly = true;
            this.textEstado.Size = new System.Drawing.Size(220, 24);
            this.textEstado.TabIndex = 7;
            this.textEstado.TabStop = false;
            // 
            // labelFechaCreacion
            // 
            this.labelFechaCreacion.AutoSize = true;
            this.labelFechaCreacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelFechaCreacion.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.labelFechaCreacion.Location = new System.Drawing.Point(288, 313);
            this.labelFechaCreacion.Name = "labelFechaCreacion";
            this.labelFechaCreacion.Size = new System.Drawing.Size(104, 19);
            this.labelFechaCreacion.TabIndex = 8;
            this.labelFechaCreacion.Text = "Fecha creación";
            // 
            // textFechaCreacion
            // 
            this.textFechaCreacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textFechaCreacion.BackColor = System.Drawing.Color.FromArgb(243, 246, 249);
            this.textFechaCreacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textFechaCreacion.Location = new System.Drawing.Point(292, 338);
            this.textFechaCreacion.Name = "textFechaCreacion";
            this.textFechaCreacion.ReadOnly = true;
            this.textFechaCreacion.Size = new System.Drawing.Size(220, 24);
            this.textFechaCreacion.TabIndex = 9;
            this.textFechaCreacion.TabStop = false;
            // 
            // labelFechaActualizacion
            // 
            this.labelFechaActualizacion.AutoSize = true;
            this.labelFechaActualizacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelFechaActualizacion.ForeColor = System.Drawing.Color.FromArgb(45, 55, 72);
            this.labelFechaActualizacion.Location = new System.Drawing.Point(542, 313);
            this.labelFechaActualizacion.Name = "labelFechaActualizacion";
            this.labelFechaActualizacion.Size = new System.Drawing.Size(143, 19);
            this.labelFechaActualizacion.TabIndex = 10;
            this.labelFechaActualizacion.Text = "Fecha actualización";
            // 
            // textFechaActualizacion
            // 
            this.textFechaActualizacion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.textFechaActualizacion.BackColor = System.Drawing.Color.FromArgb(243, 246, 249);
            this.textFechaActualizacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textFechaActualizacion.Location = new System.Drawing.Point(546, 338);
            this.textFechaActualizacion.Name = "textFechaActualizacion";
            this.textFechaActualizacion.ReadOnly = true;
            this.textFechaActualizacion.Size = new System.Drawing.Size(196, 24);
            this.textFechaActualizacion.TabIndex = 11;
            this.textFechaActualizacion.TabStop = false;
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.panelBotones.Controls.Add(this.botonCancelar);
            this.panelBotones.Controls.Add(this.botonGuardar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 575);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(24, 13, 30, 13);
            this.panelBotones.Size = new System.Drawing.Size(780, 72);
            this.panelBotones.TabIndex = 2;
            // 
            // botonCancelar
            // 
            this.botonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.botonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCancelar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.botonCancelar.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.botonCancelar.Location = new System.Drawing.Point(530, 15);
            this.botonCancelar.Name = "botonCancelar";
            this.botonCancelar.Size = new System.Drawing.Size(100, 40);
            this.botonCancelar.TabIndex = 0;
            this.botonCancelar.Text = "Cancelar";
            this.botonCancelar.UseVisualStyleBackColor = true;
            // 
            // botonGuardar
            // 
            this.botonGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonGuardar.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.botonGuardar.FlatAppearance.BorderSize = 0;
            this.botonGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.botonGuardar.ForeColor = System.Drawing.Color.White;
            this.botonGuardar.Location = new System.Drawing.Point(642, 15);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(100, 40);
            this.botonGuardar.TabIndex = 1;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = false;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // FrmIncidencia
            // 
            this.AcceptButton = this.botonGuardar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonCancelar;
            this.ClientSize = new System.Drawing.Size(780, 647);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(796, 686);
            this.Name = "FrmIncidencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva incidencia";
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
