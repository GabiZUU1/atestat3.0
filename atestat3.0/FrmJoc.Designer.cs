namespace atestat3._0
{
    partial class FrmJoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJoc));
            this.btnMinimise = new System.Windows.Forms.Button();
            this.btnInchide = new System.Windows.Forms.Button();
            this.lblTitlu = new System.Windows.Forms.Label();
            this.pnlStanga = new System.Windows.Forms.Panel();
            this.pnlDreapta = new System.Windows.Forms.Panel();
            this.pnlJos = new System.Windows.Forms.Panel();
            this.pnlSus = new System.Windows.Forms.Panel();
            this.pnl = new System.Windows.Forms.Panel();
            this.lblTimer = new System.Windows.Forms.Label();
            this.grDef = new System.Windows.Forms.GroupBox();
            this.btnOrizontal = new System.Windows.Forms.Button();
            this.btnVertical = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.nrLinie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Definitie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlJoc = new System.Windows.Forms.Panel();
            this.btnSetari = new System.Windows.Forms.Button();
            this.btnAdministrare = new System.Windows.Forms.Button();
            this.btnRebus = new System.Windows.Forms.Button();
            this.pnl.SuspendLayout();
            this.grDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinimise
            // 
            this.btnMinimise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimise.FlatAppearance.BorderSize = 0;
            this.btnMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimise.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimise.Location = new System.Drawing.Point(1268, 3);
            this.btnMinimise.Name = "btnMinimise";
            this.btnMinimise.Size = new System.Drawing.Size(45, 45);
            this.btnMinimise.TabIndex = 13;
            this.btnMinimise.Text = " —";
            this.btnMinimise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinimise.UseVisualStyleBackColor = true;
            this.btnMinimise.Click += new System.EventHandler(this.btnMinimise_Click);
            // 
            // btnInchide
            // 
            this.btnInchide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInchide.FlatAppearance.BorderSize = 0;
            this.btnInchide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInchide.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInchide.Location = new System.Drawing.Point(1312, 3);
            this.btnInchide.Name = "btnInchide";
            this.btnInchide.Size = new System.Drawing.Size(45, 45);
            this.btnInchide.TabIndex = 12;
            this.btnInchide.Text = "X";
            this.btnInchide.UseVisualStyleBackColor = true;
            this.btnInchide.Click += new System.EventHandler(this.btnInchide_Click);
            // 
            // lblTitlu
            // 
            this.lblTitlu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitlu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitlu.Location = new System.Drawing.Point(3, 3);
            this.lblTitlu.Name = "lblTitlu";
            this.lblTitlu.Size = new System.Drawing.Size(1354, 45);
            this.lblTitlu.TabIndex = 11;
            this.lblTitlu.Text = "Pentru a incepe apasa pe butonul \"Rebus\"!";
            this.lblTitlu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitlu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitlu_MouseDown);
            this.lblTitlu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitlu_MouseMove);
            this.lblTitlu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitlu_MouseUp);
            // 
            // pnlStanga
            // 
            this.pnlStanga.BackColor = System.Drawing.Color.Black;
            this.pnlStanga.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlStanga.Location = new System.Drawing.Point(0, 3);
            this.pnlStanga.Name = "pnlStanga";
            this.pnlStanga.Size = new System.Drawing.Size(3, 707);
            this.pnlStanga.TabIndex = 10;
            // 
            // pnlDreapta
            // 
            this.pnlDreapta.BackColor = System.Drawing.Color.Black;
            this.pnlDreapta.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDreapta.Location = new System.Drawing.Point(1357, 3);
            this.pnlDreapta.Name = "pnlDreapta";
            this.pnlDreapta.Size = new System.Drawing.Size(3, 707);
            this.pnlDreapta.TabIndex = 9;
            // 
            // pnlJos
            // 
            this.pnlJos.BackColor = System.Drawing.Color.Black;
            this.pnlJos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlJos.Location = new System.Drawing.Point(0, 710);
            this.pnlJos.Name = "pnlJos";
            this.pnlJos.Size = new System.Drawing.Size(1360, 3);
            this.pnlJos.TabIndex = 8;
            // 
            // pnlSus
            // 
            this.pnlSus.BackColor = System.Drawing.Color.Black;
            this.pnlSus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSus.Location = new System.Drawing.Point(0, 0);
            this.pnlSus.Name = "pnlSus";
            this.pnlSus.Size = new System.Drawing.Size(1360, 3);
            this.pnlSus.TabIndex = 7;
            // 
            // pnl
            // 
            this.pnl.Controls.Add(this.lblTimer);
            this.pnl.Controls.Add(this.grDef);
            this.pnl.Controls.Add(this.pnlJoc);
            this.pnl.Controls.Add(this.btnSetari);
            this.pnl.Controls.Add(this.btnAdministrare);
            this.pnl.Controls.Add(this.btnRebus);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(3, 48);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(1354, 662);
            this.pnl.TabIndex = 14;
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(615, 620);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(214, 29);
            this.lblTimer.TabIndex = 7;
            this.lblTimer.Text = "Timp scurs: 00:00:00";
            this.lblTimer.Visible = false;
            // 
            // grDef
            // 
            this.grDef.Controls.Add(this.btnOrizontal);
            this.grDef.Controls.Add(this.btnVertical);
            this.grDef.Controls.Add(this.dgv);
            this.grDef.Enabled = false;
            this.grDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grDef.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grDef.Location = new System.Drawing.Point(615, 6);
            this.grDef.Name = "grDef";
            this.grDef.Size = new System.Drawing.Size(730, 602);
            this.grDef.TabIndex = 6;
            this.grDef.TabStop = false;
            this.grDef.Text = "Definitii";
            // 
            // btnOrizontal
            // 
            this.btnOrizontal.BackColor = System.Drawing.Color.LightGray;
            this.btnOrizontal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrizontal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrizontal.Location = new System.Drawing.Point(6, 33);
            this.btnOrizontal.Name = "btnOrizontal";
            this.btnOrizontal.Size = new System.Drawing.Size(190, 46);
            this.btnOrizontal.TabIndex = 8;
            this.btnOrizontal.TabStop = false;
            this.btnOrizontal.Text = "Orizontal";
            this.btnOrizontal.UseVisualStyleBackColor = false;
            this.btnOrizontal.Click += new System.EventHandler(this.btnOrizontal_Click);
            // 
            // btnVertical
            // 
            this.btnVertical.BackColor = System.Drawing.Color.LightGray;
            this.btnVertical.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVertical.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVertical.Location = new System.Drawing.Point(202, 33);
            this.btnVertical.Name = "btnVertical";
            this.btnVertical.Size = new System.Drawing.Size(190, 46);
            this.btnVertical.TabIndex = 7;
            this.btnVertical.TabStop = false;
            this.btnVertical.Text = "Verical";
            this.btnVertical.UseVisualStyleBackColor = false;
            this.btnVertical.Click += new System.EventHandler(this.btnVertical_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ColumnHeadersVisible = false;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrLinie,
            this.Definitie});
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Location = new System.Drawing.Point(6, 85);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(720, 511);
            this.dgv.TabIndex = 4;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // nrLinie
            // 
            this.nrLinie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nrLinie.FillWeight = 30F;
            this.nrLinie.HeaderText = "#";
            this.nrLinie.MinimumWidth = 6;
            this.nrLinie.Name = "nrLinie";
            this.nrLinie.ReadOnly = true;
            // 
            // Definitie
            // 
            this.Definitie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Definitie.HeaderText = "Definitie";
            this.Definitie.MinimumWidth = 6;
            this.Definitie.Name = "Definitie";
            this.Definitie.ReadOnly = true;
            // 
            // pnlJoc
            // 
            this.pnlJoc.Location = new System.Drawing.Point(9, 55);
            this.pnlJoc.Name = "pnlJoc";
            this.pnlJoc.Size = new System.Drawing.Size(600, 600);
            this.pnlJoc.TabIndex = 4;
            // 
            // btnSetari
            // 
            this.btnSetari.BackColor = System.Drawing.Color.LightGray;
            this.btnSetari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetari.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetari.Location = new System.Drawing.Point(387, 3);
            this.btnSetari.Name = "btnSetari";
            this.btnSetari.Size = new System.Drawing.Size(183, 46);
            this.btnSetari.TabIndex = 3;
            this.btnSetari.TabStop = false;
            this.btnSetari.Text = "Setari";
            this.btnSetari.UseVisualStyleBackColor = false;
            this.btnSetari.Click += new System.EventHandler(this.btnSetari_Click);
            // 
            // btnAdministrare
            // 
            this.btnAdministrare.BackColor = System.Drawing.Color.LightGray;
            this.btnAdministrare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrare.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdministrare.Location = new System.Drawing.Point(198, 3);
            this.btnAdministrare.Name = "btnAdministrare";
            this.btnAdministrare.Size = new System.Drawing.Size(183, 46);
            this.btnAdministrare.TabIndex = 2;
            this.btnAdministrare.TabStop = false;
            this.btnAdministrare.Text = "Administrare";
            this.btnAdministrare.UseVisualStyleBackColor = false;
            this.btnAdministrare.Click += new System.EventHandler(this.btnAdministrare_Click);
            // 
            // btnRebus
            // 
            this.btnRebus.BackColor = System.Drawing.Color.LightGray;
            this.btnRebus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRebus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRebus.Location = new System.Drawing.Point(9, 3);
            this.btnRebus.Name = "btnRebus";
            this.btnRebus.Size = new System.Drawing.Size(183, 46);
            this.btnRebus.TabIndex = 1;
            this.btnRebus.TabStop = false;
            this.btnRebus.Text = "Rebus";
            this.btnRebus.UseVisualStyleBackColor = false;
            this.btnRebus.Click += new System.EventHandler(this.btnRebus_Click);
            // 
            // FrmJoc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1360, 713);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.btnMinimise);
            this.Controls.Add(this.btnInchide);
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.pnlStanga);
            this.Controls.Add(this.pnlDreapta);
            this.Controls.Add(this.pnlJos);
            this.Controls.Add(this.pnlSus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmJoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmJoc";
            this.Load += new System.EventHandler(this.FrmJoc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmJoc_KeyDown);
            this.pnl.ResumeLayout(false);
            this.grDef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMinimise;
        private System.Windows.Forms.Button btnInchide;
        private System.Windows.Forms.Label lblTitlu;
        public System.Windows.Forms.Panel pnlStanga;
        public System.Windows.Forms.Panel pnlDreapta;
        public System.Windows.Forms.Panel pnlJos;
        public System.Windows.Forms.Panel pnlSus;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Button btnSetari;
        private System.Windows.Forms.Button btnAdministrare;
        private System.Windows.Forms.GroupBox grDef;
        private System.Windows.Forms.Button btnOrizontal;
        private System.Windows.Forms.Button btnVertical;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Panel pnlJoc;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn nrLinie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Definitie;
        public System.Windows.Forms.Button btnRebus;
    }
}