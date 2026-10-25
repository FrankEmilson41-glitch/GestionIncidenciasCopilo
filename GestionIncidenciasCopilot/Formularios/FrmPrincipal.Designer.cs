namespace GestionIncidenciasCopilot.Formularios
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelEncabezado;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelSubtitulo;
        private System.Windows.Forms.Button botonNueva;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label labelBuscar;
        private System.Windows.Forms.TextBox textBuscar;
        private System.Windows.Forms.Label labelPrioridad;
        private System.Windows.Forms.ComboBox comboPrioridad;
        private System.Windows.Forms.Label labelEstado;
        private System.Windows.Forms.ComboBox comboEstado;
        private System.Windows.Forms.DataGridView dataGridIncidencias;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaPrioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaFechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnaFechaActualizacion;
        private System.Windows.Forms.Panel panelPie;
        private System.Windows.Forms.Label labelContador;
        private System.Windows.Forms.Button botonDetalle;
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelSubtitulo = new System.Windows.Forms.Label();
            this.botonNueva = new System.Windows.Forms.Button();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.labelBuscar = new System.Windows.Forms.Label();
            this.textBuscar = new System.Windows.Forms.TextBox();
            this.labelPrioridad = new System.Windows.Forms.Label();
            this.comboPrioridad = new System.Windows.Forms.ComboBox();
            this.labelEstado = new System.Windows.Forms.Label();
            this.comboEstado = new System.Windows.Forms.ComboBox();
            this.dataGridIncidencias = new System.Windows.Forms.DataGridView();
            this.columnaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaPrioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaFechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnaFechaActualizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPie = new System.Windows.Forms.Panel();
            this.labelContador = new System.Windows.Forms.Label();
            this.botonDetalle = new System.Windows.Forms.Button();
            this.botonEditar = new System.Windows.Forms.Button();
            this.panelEncabezado.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIncidencias)).BeginInit();
            this.panelPie.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEncabezado
            // 
            this.panelEncabezado.BackColor = System.Drawing.Color.FromArgb(31, 52, 77);
            this.panelEncabezado.Controls.Add(this.labelTitulo);
            this.panelEncabezado.Controls.Add(this.labelSubtitulo);
            this.panelEncabezado.Controls.Add(this.botonNueva);
            this.panelEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEncabezado.Location = new System.Drawing.Point(0, 0);
            this.panelEncabezado.Name = "panelEncabezado";
            this.panelEncabezado.Padding = new System.Windows.Forms.Padding(28, 22, 28, 18);
            this.panelEncabezado.Size = new System.Drawing.Size(1180, 116);
            this.panelEncabezado.TabIndex = 0;
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 21F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.White;
            this.labelTitulo.Location = new System.Drawing.Point(27, 17);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(316, 38);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "Gestor de incidencias";
            // 
            // labelSubtitulo
            // 
            this.labelSubtitulo.AutoSize = true;
            this.labelSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.labelSubtitulo.ForeColor = System.Drawing.Color.FromArgb(220, 230, 241);
            this.labelSubtitulo.Location = new System.Drawing.Point(32, 70);
            this.labelSubtitulo.Name = "labelSubtitulo";
            this.labelSubtitulo.Size = new System.Drawing.Size(290, 17);
            this.labelSubtitulo.TabIndex = 1;
            this.labelSubtitulo.Text = "Organiza, consulta y da seguimiento a tus incidencias.";
            // 
            // botonNueva
            // 
            this.botonNueva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonNueva.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.botonNueva.FlatAppearance.BorderSize = 0;
            this.botonNueva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonNueva.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.botonNueva.ForeColor = System.Drawing.Color.White;
            this.botonNueva.Location = new System.Drawing.Point(1004, 34);
            this.botonNueva.Name = "botonNueva";
            this.botonNueva.Size = new System.Drawing.Size(145, 44);
            this.botonNueva.TabIndex = 2;
            this.botonNueva.Text = "+ Nueva incidencia";
            this.botonNueva.UseVisualStyleBackColor = false;
            this.botonNueva.Click += new System.EventHandler(this.botonNueva_Click);
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.Controls.Add(this.labelBuscar);
            this.panelFiltros.Controls.Add(this.textBuscar);
            this.panelFiltros.Controls.Add(this.labelPrioridad);
            this.panelFiltros.Controls.Add(this.comboPrioridad);
            this.panelFiltros.Controls.Add(this.labelEstado);
            this.panelFiltros.Controls.Add(this.comboEstado);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 116);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Padding = new System.Windows.Forms.Padding(28, 17, 28, 17);
            this.panelFiltros.Size = new System.Drawing.Size(1180, 86);
            this.panelFiltros.TabIndex = 1;
            // 
            // labelBuscar
            // 
            this.labelBuscar.AutoSize = true;
            this.labelBuscar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelBuscar.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.labelBuscar.Location = new System.Drawing.Point(31, 10);
            this.labelBuscar.Name = "labelBuscar";
            this.labelBuscar.Size = new System.Drawing.Size(45, 15);
            this.labelBuscar.TabIndex = 0;
            this.labelBuscar.Text = "Buscar";
            // 
            // textBuscar
            // 
            this.textBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.textBuscar.Location = new System.Drawing.Point(34, 34);
            this.textBuscar.Name = "textBuscar";
            this.textBuscar.Size = new System.Drawing.Size(490, 25);
            this.textBuscar.TabIndex = 1;
            // 
            // labelPrioridad
            // 
            this.labelPrioridad.AutoSize = true;
            this.labelPrioridad.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelPrioridad.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.labelPrioridad.Location = new System.Drawing.Point(552, 10);
            this.labelPrioridad.Name = "labelPrioridad";
            this.labelPrioridad.Size = new System.Drawing.Size(55, 15);
            this.labelPrioridad.TabIndex = 2;
            this.labelPrioridad.Text = "Prioridad";
            // 
            // comboPrioridad
            // 
            this.comboPrioridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPrioridad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.comboPrioridad.FormattingEnabled = true;
            this.comboPrioridad.Location = new System.Drawing.Point(555, 34);
            this.comboPrioridad.Name = "comboPrioridad";
            this.comboPrioridad.Size = new System.Drawing.Size(190, 25);
            this.comboPrioridad.TabIndex = 3;
            // 
            // labelEstado
            // 
            this.labelEstado.AutoSize = true;
            this.labelEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelEstado.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.labelEstado.Location = new System.Drawing.Point(777, 10);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(43, 15);
            this.labelEstado.TabIndex = 4;
            this.labelEstado.Text = "Estado";
            // 
            // comboEstado
            // 
            this.comboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.comboEstado.FormattingEnabled = true;
            this.comboEstado.Location = new System.Drawing.Point(780, 34);
            this.comboEstado.Name = "comboEstado";
            this.comboEstado.Size = new System.Drawing.Size(190, 25);
            this.comboEstado.TabIndex = 5;
            // 
            // dataGridIncidencias
            // 
            this.dataGridIncidencias.AllowUserToAddRows = false;
            this.dataGridIncidencias.AllowUserToDeleteRows = false;
            this.dataGridIncidencias.AllowUserToResizeRows = false;
            this.dataGridIncidencias.AutoGenerateColumns = false;
            this.dataGridIncidencias.BackgroundColor = System.Drawing.Color.White;
            this.dataGridIncidencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridIncidencias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridIncidencias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridIncidencias.ColumnHeadersHeight = 42;
            this.dataGridIncidencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnaId,
            this.columnaTitulo,
            this.columnaPrioridad,
            this.columnaEstado,
            this.columnaFechaCreacion,
            this.columnaFechaActualizacion});
            this.dataGridIncidencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridIncidencias.EnableHeadersVisualStyles = false;
            this.dataGridIncidencias.GridColor = System.Drawing.Color.FromArgb(229, 234, 240);
            this.dataGridIncidencias.Location = new System.Drawing.Point(0, 202);
            this.dataGridIncidencias.MultiSelect = false;
            this.dataGridIncidencias.Name = "dataGridIncidencias";
            this.dataGridIncidencias.ReadOnly = true;
            this.dataGridIncidencias.RowHeadersVisible = false;
            this.dataGridIncidencias.RowTemplate.Height = 38;
            this.dataGridIncidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridIncidencias.Size = new System.Drawing.Size(1180, 426);
            this.dataGridIncidencias.TabIndex = 2;
            // 
            // columnaId
            // 
            this.columnaId.HeaderText = "ID";
            this.columnaId.Name = "columnaId";
            this.columnaId.ReadOnly = true;
            this.columnaId.Width = 240;
            // 
            // columnaTitulo
            // 
            this.columnaTitulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnaTitulo.HeaderText = "Título";
            this.columnaTitulo.MinimumWidth = 160;
            this.columnaTitulo.Name = "columnaTitulo";
            this.columnaTitulo.ReadOnly = true;
            // 
            // columnaPrioridad
            // 
            this.columnaPrioridad.HeaderText = "Prioridad";
            this.columnaPrioridad.Name = "columnaPrioridad";
            this.columnaPrioridad.ReadOnly = true;
            this.columnaPrioridad.Width = 105;
            // 
            // columnaEstado
            // 
            this.columnaEstado.HeaderText = "Estado";
            this.columnaEstado.Name = "columnaEstado";
            this.columnaEstado.ReadOnly = true;
            this.columnaEstado.Width = 125;
            // 
            // columnaFechaCreacion
            // 
            this.columnaFechaCreacion.HeaderText = "Creada (UTC)";
            this.columnaFechaCreacion.Name = "columnaFechaCreacion";
            this.columnaFechaCreacion.ReadOnly = true;
            this.columnaFechaCreacion.Width = 155;
            // 
            // columnaFechaActualizacion
            // 
            this.columnaFechaActualizacion.HeaderText = "Actualizada (UTC)";
            this.columnaFechaActualizacion.Name = "columnaFechaActualizacion";
            this.columnaFechaActualizacion.ReadOnly = true;
            this.columnaFechaActualizacion.Width = 165;
            // 
            // panelPie
            // 
            this.panelPie.BackColor = System.Drawing.Color.FromArgb(247, 249, 252);
            this.panelPie.Controls.Add(this.labelContador);
            this.panelPie.Controls.Add(this.botonDetalle);
            this.panelPie.Controls.Add(this.botonEditar);
            this.panelPie.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPie.Location = new System.Drawing.Point(0, 628);
            this.panelPie.Name = "panelPie";
            this.panelPie.Padding = new System.Windows.Forms.Padding(24, 12, 28, 12);
            this.panelPie.Size = new System.Drawing.Size(1180, 72);
            this.panelPie.TabIndex = 3;
            // 
            // labelContador
            // 
            this.labelContador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.labelContador.AutoSize = true;
            this.labelContador.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.labelContador.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.labelContador.Location = new System.Drawing.Point(31, 27);
            this.labelContador.Name = "labelContador";
            this.labelContador.Size = new System.Drawing.Size(91, 17);
            this.labelContador.TabIndex = 0;
            this.labelContador.Text = "0 incidencias";
            // 
            // botonDetalle
            // 
            this.botonDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonDetalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.botonDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonDetalle.Location = new System.Drawing.Point(1022, 15);
            this.botonDetalle.Name = "botonDetalle";
            this.botonDetalle.Size = new System.Drawing.Size(120, 40);
            this.botonDetalle.TabIndex = 1;
            this.botonDetalle.Text = "Ver detalle";
            this.botonDetalle.UseVisualStyleBackColor = true;
            this.botonDetalle.Click += new System.EventHandler(this.botonDetalle_Click);
            // 
            // botonEditar
            // 
            this.botonEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonEditar.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.botonEditar.FlatAppearance.BorderSize = 0;
            this.botonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonEditar.ForeColor = System.Drawing.Color.White;
            this.botonEditar.Location = new System.Drawing.Point(886, 15);
            this.botonEditar.Name = "botonEditar";
            this.botonEditar.Size = new System.Drawing.Size(120, 40);
            this.botonEditar.TabIndex = 2;
            this.botonEditar.Text = "Editar";
            this.botonEditar.UseVisualStyleBackColor = false;
            this.botonEditar.Click += new System.EventHandler(this.botonEditar_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.dataGridIncidencias);
            this.Controls.Add(this.panelPie);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelEncabezado);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 620);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestor de incidencias";
            this.panelEncabezado.ResumeLayout(false);
            this.panelEncabezado.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridIncidencias)).EndInit();
            this.panelPie.ResumeLayout(false);
            this.panelPie.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
