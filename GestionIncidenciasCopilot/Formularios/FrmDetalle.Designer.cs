namespace GestionIncidenciasCopilot.Formularios
{
    partial class FrmDetalle
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label labelEncabezado;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox textTitulo;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.TextBox textDescripcion;
        private System.Windows.Forms.Label labelPrioridad;
        private System.Windows.Forms.TextBox textPrioridad;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.TextBox textEstado;
        private System.Windows.Forms.Label labelFechaCreacion;
        private System.Windows.Forms.TextBox textFechaCreacion;
        private System.Windows.Forms.Label labelFechaActualizacion;
        private System.Windows.Forms.TextBox textFechaActualizacion;
        private System.Windows.Forms.GroupBox grupoEstado;
        private System.Windows.Forms.Label labelDestino;
        private System.Windows.Forms.ComboBox comboDestino;
        private System.Windows.Forms.Button botonCambiarEstado;
        private System.Windows.Forms.Panel panelBotones;
        private System.Windows.Forms.Button botonCerrar;
        private System.Windows.Forms.Button botonEditar;

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
            this.panelEncabezado = new System.Windows.Forms.Panel();
            this.labelSubtitulo = new System.Windows.Forms.Label();
            this.labelEncabezado = new System.Windows.Forms.Label();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.labelId = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.textTitulo = new System.Windows.Forms.TextBox();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.textDescripcion = new System.Windows.Forms.TextBox();
            this.labelPrioridad = new System.Windows.Forms.Label();
            this.textPrioridad = new System.Windows.Forms.TextBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.textEstado = new System.Windows.Forms.TextBox();
            this.labelFechaCreacion = new System.Windows.Forms.Label();
            this.textFechaCreacion = new System.Windows.Forms.TextBox();
            this.labelFechaActualizacion = new System.Windows.Forms.Label();
            this.textFechaActualizacion = new System.Windows.Forms.TextBox();
            this.grupoEstado = new System.Windows.Forms.GroupBox();
            this.labelDestino = new System.Windows.Forms.Label();
            this.comboDestino = new System.Windows.Forms.ComboBox();
            this.botonCambiarEstado = new System.Windows.Forms.Button();
            this.panelBotones = new System.Windows.Forms.Panel();
            this.botonCerrar = new System.Windows.Forms.Button();
            this.botonEditar = new System.Windows.Forms.Button();
            this.panelEncabezado.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.grupoEstado.SuspendLayout();
            this.panelBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(52)))), ((int)(((byte)(77)))));
            this.panelEncabezado.Controls.Add(this.labelSubtitulo);
            this.panelEncabezado.Controls.Add(this.labelEncabezado);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Padding = new System.Windows.Forms.Padding(30, 22, 30, 18);
            this.panelEncabezado.Size = new System.Drawing.Size(780, 112);
            this.panelEncabezado.TabIndex = 0;
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(241)))));
            this.labelSubtitulo.Location = new System.Drawing.Point(31, 67);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(389, 25);
            this.labelSubtitulo.TabIndex = 1;
            this.labelSubtitulo.Text = "Consulta la información y gestiona el estado.";
            // 
            // labelEncabezado
            // 
            this.labelEncabezado.AutoSize = true;
            this.labelEncabezado.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Bold);
            this.labelEncabezado.ForeColor = System.Drawing.Color.White;
            this.labelEncabezado.Location = new System.Drawing.Point(27, 17);
            this.labelEncabezado.Name = "labelEncabezado";
            this.labelEncabezado.Size = new System.Drawing.Size(379, 51);
            this.labelEncabezado.TabIndex = 0;
            this.labelEncabezado.Text = "Detalle de incidencia";
            // 
            // panelContenido
            // 
            this.panelContenido.AutoScroll = true;
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Controls.Add(this.labelId);
            this.panelContenido.Controls.Add(this.textId);
            this.panelContenido.Controls.Add(this.labelTitulo);
            this.panelContenido.Controls.Add(this.textTitulo);
            this.panelContenido.Controls.Add(this.labelDescripcion);
            this.panelContenido.Controls.Add(this.textDescripcion);
            this.panelContenido.Controls.Add(this.labelPrioridad);
            this.panelContenido.Controls.Add(this.textPrioridad);
            this.panelContenido.Controls.Add(this.labelEstado);
            this.panelContenido.Controls.Add(this.textEstado);
            this.panelContenido.Controls.Add(this.labelFechaCreacion);
            this.panelContenido.Controls.Add(this.textFechaCreacion);
            this.panelContenido.Controls.Add(this.labelFechaActualizacion);
            this.panelContenido.Controls.Add(this.textFechaActualizacion);
            this.panelContenido.Controls.Add(this.grupoEstado);
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(0, 112);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Padding = new System.Windows.Forms.Padding(32, 24, 32, 18);
            this.panelContenido.Size = new System.Drawing.Size(780, 476);
            this.panelContenido.TabIndex = 1;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelId.Location = new System.Drawing.Point(34, 19);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(32, 28);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "ID";
            // 
            // textId
            // 
            this.textId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.textId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textId.Location = new System.Drawing.Point(38, 43);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(704, 33);
            this.textId.TabIndex = 1;
            this.textId.TabStop = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelTitulo.Location = new System.Drawing.Point(34, 78);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(64, 28);
            this.labelTitulo.TabIndex = 2;
            this.labelTitulo.Text = "Título";
            // 
            // textTitulo
            // 
            this.textTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.textTitulo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textTitulo.Location = new System.Drawing.Point(38, 102);
            this.textTitulo.Name = "textTitulo";
            this.textTitulo.ReadOnly = true;
            this.textTitulo.Size = new System.Drawing.Size(704, 34);
            this.textTitulo.TabIndex = 3;
            this.textTitulo.TabStop = false;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelDescripcion.Location = new System.Drawing.Point(34, 138);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(117, 28);
            this.labelDescripcion.TabIndex = 4;
            this.labelDescripcion.Text = "Descripción";
            // 
            // textDescripcion
            // 
            this.textDescripcion.AcceptsReturn = true;
            this.textDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.textDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textDescripcion.Location = new System.Drawing.Point(38, 162);
            this.textDescripcion.Multiline = true;
            this.textDescripcion.Name = "textDescripcion";
            this.textDescripcion.ReadOnly = true;
            this.textDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDescripcion.Size = new System.Drawing.Size(704, 88);
            this.textDescripcion.TabIndex = 5;
            this.textDescripcion.TabStop = false;
            // 
            // labelPrioridad
            // 
            this.labelPrioridad.AutoSize = true;
            this.labelPrioridad.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelPrioridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelPrioridad.Location = new System.Drawing.Point(34, 261);
            this.labelPrioridad.Name = "labelPrioridad";
            this.labelPrioridad.Size = new System.Drawing.Size(94, 28);
            this.labelPrioridad.TabIndex = 6;
            this.labelPrioridad.Text = "Prioridad";
            // 
            // textPrioridad
            // 
            this.textPrioridad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.textPrioridad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textPrioridad.Location = new System.Drawing.Point(38, 285);
            this.textPrioridad.Name = "textPrioridad";
            this.textPrioridad.ReadOnly = true;
            this.textPrioridad.Size = new System.Drawing.Size(190, 33);
            this.textPrioridad.TabIndex = 7;
            this.textPrioridad.TabStop = false;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelEstado.Location = new System.Drawing.Point(270, 261);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(72, 28);
            this.labelEstado.TabIndex = 8;
            this.labelEstado.Text = "Estado";
            // 
            // textEstado
            // 
            this.textEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.textEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textEstado.Location = new System.Drawing.Point(274, 285);
            this.textEstado.Name = "textEstado";
            this.textEstado.ReadOnly = true;
            this.textEstado.Size = new System.Drawing.Size(190, 33);
            this.textEstado.TabIndex = 9;
            this.textEstado.TabStop = false;
            // 
            // labelFechaCreacion
            // 
            this.labelFechaCreacion.AutoSize = true;
            this.labelFechaCreacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelFechaCreacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelFechaCreacion.Location = new System.Drawing.Point(34, 324);
            this.labelFechaCreacion.Name = "labelFechaCreacion";
            this.labelFechaCreacion.Size = new System.Drawing.Size(145, 28);
            this.labelFechaCreacion.TabIndex = 10;
            this.labelFechaCreacion.Text = "Fecha creación";
            // 
            // textFechaCreacion
            // 
            this.textFechaCreacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.textFechaCreacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textFechaCreacion.Location = new System.Drawing.Point(38, 348);
            this.textFechaCreacion.Name = "textFechaCreacion";
            this.textFechaCreacion.ReadOnly = true;
            this.textFechaCreacion.Size = new System.Drawing.Size(300, 33);
            this.textFechaCreacion.TabIndex = 11;
            this.textFechaCreacion.TabStop = false;
            // 
            // labelFechaActualizacion
            // 
            this.labelFechaActualizacion.AutoSize = true;
            this.labelFechaActualizacion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.labelFechaActualizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.labelFechaActualizacion.Location = new System.Drawing.Point(370, 324);
            this.labelFechaActualizacion.Name = "labelFechaActualizacion";
            this.labelFechaActualizacion.Size = new System.Drawing.Size(185, 28);
            this.labelFechaActualizacion.TabIndex = 12;
            this.labelFechaActualizacion.Text = "Fecha actualización";
            // 
            // textFechaActualizacion
            // 
            this.textFechaActualizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.textFechaActualizacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.textFechaActualizacion.Location = new System.Drawing.Point(374, 348);
            this.textFechaActualizacion.Name = "textFechaActualizacion";
            this.textFechaActualizacion.ReadOnly = true;
            this.textFechaActualizacion.Size = new System.Drawing.Size(368, 33);
            this.textFechaActualizacion.TabIndex = 13;
            this.textFechaActualizacion.TabStop = false;
            // 
            // grupoEstado
            // 
            this.grupoEstado.Controls.Add(this.labelDestino);
            this.grupoEstado.Controls.Add(this.comboDestino);
            this.grupoEstado.Controls.Add(this.botonCambiarEstado);
            this.grupoEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.grupoEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.grupoEstado.Location = new System.Drawing.Point(38, 388);
            this.grupoEstado.Name = "grupoEstado";
            this.grupoEstado.Padding = new System.Windows.Forms.Padding(14, 10, 14, 12);
            this.grupoEstado.Size = new System.Drawing.Size(704, 83);
            this.grupoEstado.TabIndex = 14;
            this.grupoEstado.TabStop = false;
            this.grupoEstado.Text = "Cambiar estado";
            // 
            // labelDestino
            // 
            this.labelDestino.AutoSize = true;
            this.labelDestino.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelDestino.Location = new System.Drawing.Point(15, 34);
            this.labelDestino.Name = "labelDestino";
            this.labelDestino.Size = new System.Drawing.Size(123, 25);
            this.labelDestino.TabIndex = 0;
            this.labelDestino.Text = "Nuevo estado";
            // 
            // comboDestino
            // 
            this.comboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDestino.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.comboDestino.FormattingEnabled = true;
            this.comboDestino.Location = new System.Drawing.Point(100, 30);
            this.comboDestino.Name = "comboDestino";
            this.comboDestino.Size = new System.Drawing.Size(220, 33);
            this.comboDestino.TabIndex = 1;
            // 
            // botonCambiarEstado
            // 
            this.botonCambiarEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.botonCambiarEstado.FlatAppearance.BorderSize = 0;
            this.botonCambiarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonCambiarEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.botonCambiarEstado.ForeColor = System.Drawing.Color.White;
            this.botonCambiarEstado.Location = new System.Drawing.Point(486, 24);
            this.botonCambiarEstado.Name = "botonCambiarEstado";
            this.botonCambiarEstado.Size = new System.Drawing.Size(190, 36);
            this.botonCambiarEstado.TabIndex = 2;
            this.botonCambiarEstado.Text = "Cambiar estado";
            this.botonCambiarEstado.UseVisualStyleBackColor = false;
            this.botonCambiarEstado.Click += new System.EventHandler(this.botonCambiarEstado_Click);
            // 
            // panelBotones
            // 
            this.panelBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.panelBotones.Controls.Add(this.botonCerrar);
            this.panelBotones.Controls.Add(this.botonEditar);
            this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBotones.Location = new System.Drawing.Point(0, 588);
            this.panelBotones.Name = "panelBotones";
            this.panelBotones.Padding = new System.Windows.Forms.Padding(24, 13, 30, 13);
            this.panelBotones.Size = new System.Drawing.Size(780, 72);
            this.panelBotones.TabIndex = 2;
            // 
            // botonCerrar
            // 
            this.botonCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botonCerrar.Location = new System.Drawing.Point(642, 15);
            this.botonCerrar.Name = "botonCerrar";
            this.botonCerrar.Size = new System.Drawing.Size(100, 40);
            this.botonCerrar.TabIndex = 0;
            this.botonCerrar.Text = "Cerrar";
            this.botonCerrar.UseVisualStyleBackColor = true;
            this.botonCerrar.Click += new System.EventHandler(this.botonCerrar_Click);
            // 
            // botonEditar
            // 
            this.botonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.botonEditar.FlatAppearance.BorderSize = 0;
            this.botonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonEditar.ForeColor = System.Drawing.Color.White;
            this.botonEditar.Location = new System.Drawing.Point(518, 15);
            this.botonEditar.Name = "botonEditar";
            this.botonEditar.Size = new System.Drawing.Size(108, 40);
            this.botonEditar.TabIndex = 1;
            this.botonEditar.Text = "Editar";
            this.botonEditar.UseVisualStyleBackColor = false;
            this.botonEditar.Click += new System.EventHandler(this.botonEditar_Click);
            // 
            // FrmDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.botonCerrar;
            this.ClientSize = new System.Drawing.Size(780, 660);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelBotones);
            this.Controls.Add(this.panelEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(796, 699);
            this.Name = "FrmDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalle de incidencia";
            this.Load += new System.EventHandler(this.FrmDetalle_Load);
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelContenido.PerformLayout();
            this.grupoEstado.ResumeLayout(false);
            this.grupoEstado.PerformLayout();
            this.panelBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
