namespace CapaAplicacion
{
    partial class FrmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.pnlBarraTitulo = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlModificarContrasenia = new System.Windows.Forms.Panel();
            this.pnlSalir = new System.Windows.Forms.Panel();
            this.pnlModificarUsuario = new System.Windows.Forms.Panel();
            this.btnModificarContrasenia = new System.Windows.Forms.Button();
            this.pnlTratamiento = new System.Windows.Forms.Panel();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.pnlPlanTratamiento = new System.Windows.Forms.Panel();
            this.pnlHistoriaClinica = new System.Windows.Forms.Panel();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblSegundos = new System.Windows.Forms.Label();
            this.cpbReloj = new CircularProgressBar.CircularProgressBar();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnTratamiento = new System.Windows.Forms.Button();
            this.btnPlanTratamiento = new System.Windows.Forms.Button();
            this.btnHistoriaClinica = new System.Windows.Forms.Button();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.tmrFechaHora = new System.Windows.Forms.Timer(this.components);
            this.pnlBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBarraTitulo
            // 
            this.pnlBarraTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.pnlBarraTitulo.Controls.Add(this.btnConfiguracion);
            this.pnlBarraTitulo.Controls.Add(this.btnPacientes);
            this.pnlBarraTitulo.Controls.Add(this.pictureBox1);
            this.pnlBarraTitulo.Controls.Add(this.btnMinimizar);
            this.pnlBarraTitulo.Controls.Add(this.btnCerrar);
            this.pnlBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraTitulo.Name = "pnlBarraTitulo";
            this.pnlBarraTitulo.Size = new System.Drawing.Size(1180, 35);
            this.pnlBarraTitulo.TabIndex = 1;
            this.pnlBarraTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlBarraTitulo_MouseDown);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.Image = ((System.Drawing.Image)(resources.GetObject("btnConfiguracion.Image")));
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.Location = new System.Drawing.Point(307, 1);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Size = new System.Drawing.Size(168, 33);
            this.btnConfiguracion.TabIndex = 4;
            this.btnConfiguracion.Text = "Modificar Acceso";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPacientes.Image = ((System.Drawing.Image)(resources.GetObject("btnPacientes.Image")));
            this.btnPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPacientes.Location = new System.Drawing.Point(179, 1);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(126, 33);
            this.btnPacientes.TabIndex = 3;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.FlatAppearance.BorderSize = 0;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1116, 1);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(32, 33);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.UseVisualStyleBackColor = true;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            this.btnMinimizar.MouseLeave += new System.EventHandler(this.btnMinimizar_MouseLeave);
            this.btnMinimizar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMinimizar_MouseMove);
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1147, 1);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 33);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            this.btnCerrar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCerrar_MouseMove);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(239)))));
            this.pnlMenu.Controls.Add(this.pnlModificarContrasenia);
            this.pnlMenu.Controls.Add(this.pnlSalir);
            this.pnlMenu.Controls.Add(this.pnlModificarUsuario);
            this.pnlMenu.Controls.Add(this.btnModificarContrasenia);
            this.pnlMenu.Controls.Add(this.pnlTratamiento);
            this.pnlMenu.Controls.Add(this.btnModificarUsuario);
            this.pnlMenu.Controls.Add(this.pnlPlanTratamiento);
            this.pnlMenu.Controls.Add(this.pnlHistoriaClinica);
            this.pnlMenu.Controls.Add(this.lblAnio);
            this.pnlMenu.Controls.Add(this.lblFecha);
            this.pnlMenu.Controls.Add(this.lblHora);
            this.pnlMenu.Controls.Add(this.lblSegundos);
            this.pnlMenu.Controls.Add(this.cpbReloj);
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.btnTratamiento);
            this.pnlMenu.Controls.Add(this.btnPlanTratamiento);
            this.pnlMenu.Controls.Add(this.btnHistoriaClinica);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 35);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(180, 665);
            this.pnlMenu.TabIndex = 2;
            // 
            // pnlModificarContrasenia
            // 
            this.pnlModificarContrasenia.BackColor = System.Drawing.Color.Maroon;
            this.pnlModificarContrasenia.Location = new System.Drawing.Point(0, 291);
            this.pnlModificarContrasenia.Name = "pnlModificarContrasenia";
            this.pnlModificarContrasenia.Size = new System.Drawing.Size(6, 40);
            this.pnlModificarContrasenia.TabIndex = 18;
            this.pnlModificarContrasenia.Visible = false;
            // 
            // pnlSalir
            // 
            this.pnlSalir.BackColor = System.Drawing.Color.Maroon;
            this.pnlSalir.Location = new System.Drawing.Point(0, 207);
            this.pnlSalir.Name = "pnlSalir";
            this.pnlSalir.Size = new System.Drawing.Size(6, 39);
            this.pnlSalir.TabIndex = 15;
            this.pnlSalir.Visible = false;
            // 
            // pnlModificarUsuario
            // 
            this.pnlModificarUsuario.BackColor = System.Drawing.Color.Maroon;
            this.pnlModificarUsuario.Location = new System.Drawing.Point(0, 252);
            this.pnlModificarUsuario.Name = "pnlModificarUsuario";
            this.pnlModificarUsuario.Size = new System.Drawing.Size(6, 39);
            this.pnlModificarUsuario.TabIndex = 17;
            this.pnlModificarUsuario.Visible = false;
            // 
            // btnModificarContrasenia
            // 
            this.btnModificarContrasenia.FlatAppearance.BorderSize = 0;
            this.btnModificarContrasenia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnModificarContrasenia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnModificarContrasenia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarContrasenia.Font = new System.Drawing.Font("Baskerville Old Face", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarContrasenia.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarContrasenia.Image")));
            this.btnModificarContrasenia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarContrasenia.Location = new System.Drawing.Point(6, 291);
            this.btnModificarContrasenia.Name = "btnModificarContrasenia";
            this.btnModificarContrasenia.Size = new System.Drawing.Size(174, 40);
            this.btnModificarContrasenia.TabIndex = 16;
            this.btnModificarContrasenia.Text = "Modificar Contraseña";
            this.btnModificarContrasenia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarContrasenia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificarContrasenia.UseVisualStyleBackColor = true;
            this.btnModificarContrasenia.Visible = false;
            this.btnModificarContrasenia.Click += new System.EventHandler(this.btnModificarContrasenia_Click);
            // 
            // pnlTratamiento
            // 
            this.pnlTratamiento.BackColor = System.Drawing.Color.Maroon;
            this.pnlTratamiento.Location = new System.Drawing.Point(0, 168);
            this.pnlTratamiento.Name = "pnlTratamiento";
            this.pnlTratamiento.Size = new System.Drawing.Size(6, 39);
            this.pnlTratamiento.TabIndex = 14;
            this.pnlTratamiento.Visible = false;
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.FlatAppearance.BorderSize = 0;
            this.btnModificarUsuario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnModificarUsuario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnModificarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarUsuario.Font = new System.Drawing.Font("Baskerville Old Face", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarUsuario.Image")));
            this.btnModificarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarUsuario.Location = new System.Drawing.Point(6, 252);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(174, 40);
            this.btnModificarUsuario.TabIndex = 15;
            this.btnModificarUsuario.Text = "Modificar Nombre de Usuario";
            this.btnModificarUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificarUsuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            this.btnModificarUsuario.Visible = false;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // pnlPlanTratamiento
            // 
            this.pnlPlanTratamiento.BackColor = System.Drawing.Color.Maroon;
            this.pnlPlanTratamiento.Location = new System.Drawing.Point(0, 128);
            this.pnlPlanTratamiento.Name = "pnlPlanTratamiento";
            this.pnlPlanTratamiento.Size = new System.Drawing.Size(6, 40);
            this.pnlPlanTratamiento.TabIndex = 14;
            this.pnlPlanTratamiento.Visible = false;
            // 
            // pnlHistoriaClinica
            // 
            this.pnlHistoriaClinica.BackColor = System.Drawing.Color.Maroon;
            this.pnlHistoriaClinica.Location = new System.Drawing.Point(0, 89);
            this.pnlHistoriaClinica.Name = "pnlHistoriaClinica";
            this.pnlHistoriaClinica.Size = new System.Drawing.Size(6, 39);
            this.pnlHistoriaClinica.TabIndex = 13;
            this.pnlHistoriaClinica.Visible = false;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblAnio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblAnio.Location = new System.Drawing.Point(67, 631);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(41, 19);
            this.lblAnio.TabIndex = 12;
            this.lblAnio.Text = "2019";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblFecha.Location = new System.Drawing.Point(2, 607);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(178, 19);
            this.lblFecha.TabIndex = 11;
            this.lblFecha.Text = "miércoles, 01 septiembre";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.lblHora.ForeColor = System.Drawing.Color.White;
            this.lblHora.Location = new System.Drawing.Point(51, 505);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(82, 33);
            this.lblHora.TabIndex = 10;
            this.lblHora.Text = "00:00";
            // 
            // lblSegundos
            // 
            this.lblSegundos.AutoSize = true;
            this.lblSegundos.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.lblSegundos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.lblSegundos.Location = new System.Drawing.Point(70, 471);
            this.lblSegundos.Name = "lblSegundos";
            this.lblSegundos.Size = new System.Drawing.Size(45, 33);
            this.lblSegundos.TabIndex = 9;
            this.lblSegundos.Text = "00";
            // 
            // cpbReloj
            // 
            this.cpbReloj.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cpbReloj.AnimationSpeed = 1000;
            this.cpbReloj.BackColor = System.Drawing.Color.Transparent;
            this.cpbReloj.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold);
            this.cpbReloj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cpbReloj.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(216)))), ((int)(((byte)(239)))));
            this.cpbReloj.InnerMargin = 2;
            this.cpbReloj.InnerWidth = -1;
            this.cpbReloj.Location = new System.Drawing.Point(15, 436);
            this.cpbReloj.MarqueeAnimationSpeed = 1000;
            this.cpbReloj.Name = "cpbReloj";
            this.cpbReloj.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(247)))), ((int)(((byte)(56)))));
            this.cpbReloj.OuterMargin = -30;
            this.cpbReloj.OuterWidth = 30;
            this.cpbReloj.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.cpbReloj.ProgressWidth = 10;
            this.cpbReloj.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cpbReloj.Size = new System.Drawing.Size(150, 150);
            this.cpbReloj.StartAngle = 270;
            this.cpbReloj.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cpbReloj.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cpbReloj.SubscriptText = ".23";
            this.cpbReloj.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.cpbReloj.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cpbReloj.SuperscriptText = "°C";
            this.cpbReloj.TabIndex = 0;
            this.cpbReloj.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.cpbReloj.Value = 68;
            // 
            // btnSalir
            // 
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Baskerville Old Face", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(6, 206);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(174, 40);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Visible = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnTratamiento
            // 
            this.btnTratamiento.FlatAppearance.BorderSize = 0;
            this.btnTratamiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnTratamiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnTratamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTratamiento.Font = new System.Drawing.Font("Baskerville Old Face", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTratamiento.Image = ((System.Drawing.Image)(resources.GetObject("btnTratamiento.Image")));
            this.btnTratamiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTratamiento.Location = new System.Drawing.Point(6, 167);
            this.btnTratamiento.Name = "btnTratamiento";
            this.btnTratamiento.Size = new System.Drawing.Size(174, 40);
            this.btnTratamiento.TabIndex = 7;
            this.btnTratamiento.Text = "Detalle de Tratamiento";
            this.btnTratamiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTratamiento.UseVisualStyleBackColor = true;
            this.btnTratamiento.Visible = false;
            this.btnTratamiento.Click += new System.EventHandler(this.btnTratamiento_Click);
            // 
            // btnPlanTratamiento
            // 
            this.btnPlanTratamiento.FlatAppearance.BorderSize = 0;
            this.btnPlanTratamiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnPlanTratamiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnPlanTratamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlanTratamiento.Font = new System.Drawing.Font("Baskerville Old Face", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlanTratamiento.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanTratamiento.Image")));
            this.btnPlanTratamiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlanTratamiento.Location = new System.Drawing.Point(6, 128);
            this.btnPlanTratamiento.Name = "btnPlanTratamiento";
            this.btnPlanTratamiento.Size = new System.Drawing.Size(174, 40);
            this.btnPlanTratamiento.TabIndex = 6;
            this.btnPlanTratamiento.Text = "Plan de Tratamiento";
            this.btnPlanTratamiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPlanTratamiento.UseVisualStyleBackColor = true;
            this.btnPlanTratamiento.Visible = false;
            this.btnPlanTratamiento.Click += new System.EventHandler(this.btnPlanTratamiento_Click);
            // 
            // btnHistoriaClinica
            // 
            this.btnHistoriaClinica.FlatAppearance.BorderSize = 0;
            this.btnHistoriaClinica.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnHistoriaClinica.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnHistoriaClinica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoriaClinica.Font = new System.Drawing.Font("Baskerville Old Face", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistoriaClinica.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoriaClinica.Image")));
            this.btnHistoriaClinica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoriaClinica.Location = new System.Drawing.Point(6, 89);
            this.btnHistoriaClinica.Name = "btnHistoriaClinica";
            this.btnHistoriaClinica.Size = new System.Drawing.Size(174, 40);
            this.btnHistoriaClinica.TabIndex = 5;
            this.btnHistoriaClinica.Text = "Historia Clínica";
            this.btnHistoriaClinica.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHistoriaClinica.UseVisualStyleBackColor = true;
            this.btnHistoriaClinica.Visible = false;
            this.btnHistoriaClinica.Click += new System.EventHandler(this.btnHistoriaClinica_Click);
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(180, 35);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1000, 665);
            this.pnlContenedor.TabIndex = 3;
            // 
            // tmrFechaHora
            // 
            this.tmrFechaHora.Enabled = true;
            this.tmrFechaHora.Interval = 1000;
            this.tmrFechaHora.Tick += new System.EventHandler(this.tmrFechaHora_Tick);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1180, 700);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlBarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.pnlBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarraTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnHistoriaClinica;
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnTratamiento;
        private System.Windows.Forms.Button btnPlanTratamiento;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblSegundos;
        private CircularProgressBar.CircularProgressBar cpbReloj;
        private System.Windows.Forms.Timer tmrFechaHora;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Panel pnlSalir;
        private System.Windows.Forms.Panel pnlTratamiento;
        private System.Windows.Forms.Panel pnlPlanTratamiento;
        private System.Windows.Forms.Panel pnlHistoriaClinica;
        private System.Windows.Forms.Panel pnlModificarContrasenia;
        private System.Windows.Forms.Panel pnlModificarUsuario;
        private System.Windows.Forms.Button btnModificarContrasenia;
        private System.Windows.Forms.Button btnModificarUsuario;
    }
}