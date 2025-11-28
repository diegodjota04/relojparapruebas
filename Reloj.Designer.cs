namespace Reloj_para_pruebas
{
    partial class Reloj
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reloj));
            this.HoraActualNombre = new System.Windows.Forms.Label();
            this.HoraInicioNombre = new System.Windows.Forms.Label();
            this.HoraFinalizacionNombre = new System.Windows.Forms.Label();
            this.HoraActual = new System.Windows.Forms.Label();
            this.hora = new System.Windows.Forms.Timer(this.components);
            this.HoraDeInicio = new System.Windows.Forms.TextBox();
            this.HoraFinalizacionRegular = new System.Windows.Forms.TextBox();
            this.HoraFinalizacionApoyos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IniciarPrueba = new System.Windows.Forms.Button();
            this.AsignaturaNombre = new System.Windows.Forms.Label();
            this.comboBoxAsignaturas = new System.Windows.Forms.ComboBox();
            this.ImagenCalasanzSecundaria = new System.Windows.Forms.PictureBox();
            this.grupoApp = new System.Windows.Forms.GroupBox();
            this.RadioButtonPrueba2 = new System.Windows.Forms.RadioButton();
            this.RadioButtonPrueba1 = new System.Windows.Forms.RadioButton();
            this.BotonFinalizar = new System.Windows.Forms.Button();
            this.BotonReinicio = new System.Windows.Forms.Button();
            this.horaActualGrupo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenCalasanzSecundaria)).BeginInit();
            this.grupoApp.SuspendLayout();
            this.horaActualGrupo.SuspendLayout();
            this.SuspendLayout();
            // 
            // HoraActualNombre
            // 
            resources.ApplyResources(this.HoraActualNombre, "HoraActualNombre");
            this.HoraActualNombre.Name = "HoraActualNombre";
            // 
            // HoraInicioNombre
            // 
            resources.ApplyResources(this.HoraInicioNombre, "HoraInicioNombre");
            this.HoraInicioNombre.Name = "HoraInicioNombre";
            // 
            // HoraFinalizacionNombre
            // 
            resources.ApplyResources(this.HoraFinalizacionNombre, "HoraFinalizacionNombre");
            this.HoraFinalizacionNombre.Name = "HoraFinalizacionNombre";
            // 
            // HoraActual
            // 
            resources.ApplyResources(this.HoraActual, "HoraActual");
            this.HoraActual.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HoraActual.Name = "HoraActual";
            // 
            // hora
            // 
            this.hora.Enabled = true;
            this.hora.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // HoraDeInicio
            // 
            resources.ApplyResources(this.HoraDeInicio, "HoraDeInicio");
            this.HoraDeInicio.ForeColor = System.Drawing.SystemColors.Highlight;
            this.HoraDeInicio.Name = "HoraDeInicio";
            this.HoraDeInicio.ReadOnly = true;
            // 
            // HoraFinalizacionRegular
            // 
            resources.ApplyResources(this.HoraFinalizacionRegular, "HoraFinalizacionRegular");
            this.HoraFinalizacionRegular.ForeColor = System.Drawing.Color.Red;
            this.HoraFinalizacionRegular.Name = "HoraFinalizacionRegular";
            this.HoraFinalizacionRegular.ReadOnly = true;
            // 
            // HoraFinalizacionApoyos
            // 
            resources.ApplyResources(this.HoraFinalizacionApoyos, "HoraFinalizacionApoyos");
            this.HoraFinalizacionApoyos.ForeColor = System.Drawing.Color.Red;
            this.HoraFinalizacionApoyos.Name = "HoraFinalizacionApoyos";
            this.HoraFinalizacionApoyos.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // IniciarPrueba
            // 
            this.IniciarPrueba.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.IniciarPrueba, "IniciarPrueba");
            this.IniciarPrueba.Name = "IniciarPrueba";
            this.IniciarPrueba.UseVisualStyleBackColor = false;
            this.IniciarPrueba.Click += new System.EventHandler(this.IniciarPrueba_Click);
            // 
            // AsignaturaNombre
            // 
            resources.ApplyResources(this.AsignaturaNombre, "AsignaturaNombre");
            this.AsignaturaNombre.Name = "AsignaturaNombre";
            // 
            // comboBoxAsignaturas
            // 
            resources.ApplyResources(this.comboBoxAsignaturas, "comboBoxAsignaturas");
            this.comboBoxAsignaturas.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBoxAsignaturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAsignaturas.ForeColor = System.Drawing.SystemColors.MenuText;
            this.comboBoxAsignaturas.Items.AddRange(new object[] {
            resources.GetString("comboBoxAsignaturas.Items"),
            resources.GetString("comboBoxAsignaturas.Items1"),
            resources.GetString("comboBoxAsignaturas.Items2"),
            resources.GetString("comboBoxAsignaturas.Items3"),
            resources.GetString("comboBoxAsignaturas.Items4"),
            resources.GetString("comboBoxAsignaturas.Items5"),
            resources.GetString("comboBoxAsignaturas.Items6"),
            resources.GetString("comboBoxAsignaturas.Items7"),
            resources.GetString("comboBoxAsignaturas.Items8"),
            resources.GetString("comboBoxAsignaturas.Items9"),
            resources.GetString("comboBoxAsignaturas.Items10")});
            this.comboBoxAsignaturas.Name = "comboBoxAsignaturas";
            // 
            // ImagenCalasanzSecundaria
            // 
            resources.ApplyResources(this.ImagenCalasanzSecundaria, "ImagenCalasanzSecundaria");
            this.ImagenCalasanzSecundaria.Image = global::Reloj_para_pruebas.Properties.Resources.logo;
            this.ImagenCalasanzSecundaria.Name = "ImagenCalasanzSecundaria";
            this.ImagenCalasanzSecundaria.TabStop = false;
            // 
            // grupoApp
            // 
            this.grupoApp.Controls.Add(this.RadioButtonPrueba2);
            this.grupoApp.Controls.Add(this.RadioButtonPrueba1);
            this.grupoApp.Controls.Add(this.BotonFinalizar);
            this.grupoApp.Controls.Add(this.BotonReinicio);
            this.grupoApp.Controls.Add(this.horaActualGrupo);
            this.grupoApp.Controls.Add(this.comboBoxAsignaturas);
            this.grupoApp.Controls.Add(this.AsignaturaNombre);
            this.grupoApp.Controls.Add(this.IniciarPrueba);
            this.grupoApp.Controls.Add(this.HoraFinalizacionApoyos);
            this.grupoApp.Controls.Add(this.label1);
            this.grupoApp.Controls.Add(this.HoraFinalizacionRegular);
            this.grupoApp.Controls.Add(this.HoraDeInicio);
            this.grupoApp.Controls.Add(this.HoraFinalizacionNombre);
            this.grupoApp.Controls.Add(this.HoraInicioNombre);
            this.grupoApp.Controls.Add(this.ImagenCalasanzSecundaria);
            resources.ApplyResources(this.grupoApp, "grupoApp");
            this.grupoApp.Name = "grupoApp";
            this.grupoApp.TabStop = false;
            // 
            // RadioButtonPrueba2
            // 
            resources.ApplyResources(this.RadioButtonPrueba2, "RadioButtonPrueba2");
            this.RadioButtonPrueba2.Name = "RadioButtonPrueba2";
            this.RadioButtonPrueba2.UseVisualStyleBackColor = true;
            this.RadioButtonPrueba2.CheckedChanged += new System.EventHandler(this.RadioButtonPrueba2_CheckedChanged);
            // 
            // RadioButtonPrueba1
            // 
            resources.ApplyResources(this.RadioButtonPrueba1, "RadioButtonPrueba1");
            this.RadioButtonPrueba1.Checked = true;
            this.RadioButtonPrueba1.Name = "RadioButtonPrueba1";
            this.RadioButtonPrueba1.TabStop = true;
            this.RadioButtonPrueba1.UseVisualStyleBackColor = true;
            this.RadioButtonPrueba1.CheckedChanged += new System.EventHandler(this.RadioButtonPrueba1_CheckedChanged);
            // 
            // BotonFinalizar
            // 
            this.BotonFinalizar.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.BotonFinalizar, "BotonFinalizar");
            this.BotonFinalizar.Name = "BotonFinalizar";
            this.BotonFinalizar.UseVisualStyleBackColor = false;
            this.BotonFinalizar.Click += new System.EventHandler(this.BotonFinalizar_Click);
            // 
            // BotonReinicio
            // 
            this.BotonReinicio.BackColor = System.Drawing.Color.Gainsboro;
            resources.ApplyResources(this.BotonReinicio, "BotonReinicio");
            this.BotonReinicio.Name = "BotonReinicio";
            this.BotonReinicio.UseVisualStyleBackColor = false;
            this.BotonReinicio.Click += new System.EventHandler(this.BotonReinicio_Click);
            // 
            // horaActualGrupo
            // 
            resources.ApplyResources(this.horaActualGrupo, "horaActualGrupo");
            this.horaActualGrupo.Controls.Add(this.HoraActual);
            this.horaActualGrupo.Controls.Add(this.HoraActualNombre);
            this.horaActualGrupo.Name = "horaActualGrupo";
            this.horaActualGrupo.TabStop = false;
            // 
            // Reloj
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grupoApp);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Reloj";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            ((System.ComponentModel.ISupportInitialize)(this.ImagenCalasanzSecundaria)).EndInit();
            this.grupoApp.ResumeLayout(false);
            this.grupoApp.PerformLayout();
            this.horaActualGrupo.ResumeLayout(false);
            this.horaActualGrupo.PerformLayout();
            this.ResumeLayout(false);

        }

       #endregion

        private System.Windows.Forms.PictureBox ImagenCalasanzSecundaria;
        private System.Windows.Forms.Label HoraActualNombre;
        private System.Windows.Forms.Label HoraInicioNombre;
        private System.Windows.Forms.Label HoraFinalizacionNombre;
        private System.Windows.Forms.Label HoraActual;
        private System.Windows.Forms.Timer hora;
        private System.Windows.Forms.TextBox HoraDeInicio;
        private System.Windows.Forms.TextBox HoraFinalizacionRegular;
        private System.Windows.Forms.TextBox HoraFinalizacionApoyos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button IniciarPrueba;
        private System.Windows.Forms.Label AsignaturaNombre;
        private System.Windows.Forms.ComboBox comboBoxAsignaturas;
        private System.Windows.Forms.GroupBox grupoApp;
        private System.Windows.Forms.GroupBox horaActualGrupo;
        private System.Windows.Forms.Button BotonFinalizar;
        private System.Windows.Forms.Button BotonReinicio;
        private System.Windows.Forms.RadioButton RadioButtonPrueba2;
        private System.Windows.Forms.RadioButton RadioButtonPrueba1;
    }
}

