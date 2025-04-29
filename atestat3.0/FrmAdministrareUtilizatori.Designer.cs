namespace atestat3._0
{
    partial class FrmAdministrareUtilizatori
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
            this.btnMinimise = new System.Windows.Forms.Button();
            this.btnInchide = new System.Windows.Forms.Button();
            this.lblTitlu = new System.Windows.Forms.Label();
            this.pnlStanga = new System.Windows.Forms.Panel();
            this.pnlDreapta = new System.Windows.Forms.Panel();
            this.pnlJos = new System.Windows.Forms.Panel();
            this.pnlSus = new System.Windows.Forms.Panel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.idUtilizator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeUtilizator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailUtilizator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.temaAleasaUtilizator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adminUtilizator = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNume = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbTeme = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbTip = new System.Windows.Forms.ComboBox();
            this.btnModifica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMinimise
            // 
            this.btnMinimise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimise.FlatAppearance.BorderSize = 0;
            this.btnMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimise.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimise.Location = new System.Drawing.Point(1075, 3);
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
            this.btnInchide.Location = new System.Drawing.Point(1119, 3);
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
            this.lblTitlu.Size = new System.Drawing.Size(1161, 45);
            this.lblTitlu.TabIndex = 11;
            this.lblTitlu.Text = "Administreaza utilizatorii";
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
            this.pnlStanga.Size = new System.Drawing.Size(3, 533);
            this.pnlStanga.TabIndex = 10;
            // 
            // pnlDreapta
            // 
            this.pnlDreapta.BackColor = System.Drawing.Color.Black;
            this.pnlDreapta.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDreapta.Location = new System.Drawing.Point(1164, 3);
            this.pnlDreapta.Name = "pnlDreapta";
            this.pnlDreapta.Size = new System.Drawing.Size(3, 533);
            this.pnlDreapta.TabIndex = 9;
            // 
            // pnlJos
            // 
            this.pnlJos.BackColor = System.Drawing.Color.Black;
            this.pnlJos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlJos.Location = new System.Drawing.Point(0, 536);
            this.pnlJos.Name = "pnlJos";
            this.pnlJos.Size = new System.Drawing.Size(1167, 3);
            this.pnlJos.TabIndex = 8;
            // 
            // pnlSus
            // 
            this.pnlSus.BackColor = System.Drawing.Color.Black;
            this.pnlSus.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSus.Location = new System.Drawing.Point(0, 0);
            this.pnlSus.Name = "pnlSus";
            this.pnlSus.Size = new System.Drawing.Size(1167, 3);
            this.pnlSus.TabIndex = 7;
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
            this.idUtilizator,
            this.numeUtilizator,
            this.emailUtilizator,
            this.temaAleasaUtilizator,
            this.adminUtilizator});
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.Location = new System.Drawing.Point(18, 106);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(567, 421);
            this.dgv.TabIndex = 14;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Utilizatori";
            // 
            // idUtilizator
            // 
            this.idUtilizator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idUtilizator.FillWeight = 20F;
            this.idUtilizator.HeaderText = "ID";
            this.idUtilizator.Name = "idUtilizator";
            this.idUtilizator.ReadOnly = true;
            // 
            // numeUtilizator
            // 
            this.numeUtilizator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numeUtilizator.FillWeight = 80F;
            this.numeUtilizator.HeaderText = "Nume utilizator";
            this.numeUtilizator.Name = "numeUtilizator";
            this.numeUtilizator.ReadOnly = true;
            // 
            // emailUtilizator
            // 
            this.emailUtilizator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.emailUtilizator.HeaderText = "Email";
            this.emailUtilizator.Name = "emailUtilizator";
            this.emailUtilizator.ReadOnly = true;
            // 
            // temaAleasaUtilizator
            // 
            this.temaAleasaUtilizator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.temaAleasaUtilizator.FillWeight = 30F;
            this.temaAleasaUtilizator.HeaderText = "Tema aleasa";
            this.temaAleasaUtilizator.Name = "temaAleasaUtilizator";
            this.temaAleasaUtilizator.ReadOnly = true;
            // 
            // adminUtilizator
            // 
            this.adminUtilizator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.adminUtilizator.FillWeight = 30F;
            this.adminUtilizator.HeaderText = "Administrator";
            this.adminUtilizator.Name = "adminUtilizator";
            this.adminUtilizator.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(65, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nume utilizator";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(239, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(453, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tema";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(520, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Admin";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(848, 174);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(272, 36);
            this.txtEmail.TabIndex = 25;
            // 
            // txtNume
            // 
            this.txtNume.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNume.Location = new System.Drawing.Point(848, 106);
            this.txtNume.Name = "txtNume";
            this.txtNume.Size = new System.Drawing.Size(272, 36);
            this.txtNume.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(601, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 30);
            this.label8.TabIndex = 22;
            this.label8.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(601, 109);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 30);
            this.label9.TabIndex = 21;
            this.label9.Text = "Nume utilizator:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(601, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 30);
            this.label10.TabIndex = 27;
            this.label10.Text = "Tema:";
            // 
            // cmbTeme
            // 
            this.cmbTeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTeme.FormattingEnabled = true;
            this.cmbTeme.Location = new System.Drawing.Point(848, 239);
            this.cmbTeme.Name = "cmbTeme";
            this.cmbTeme.Size = new System.Drawing.Size(272, 37);
            this.cmbTeme.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(601, 304);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 30);
            this.label11.TabIndex = 29;
            this.label11.Text = "Tip:";
            // 
            // cmbTip
            // 
            this.cmbTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTip.FormattingEnabled = true;
            this.cmbTip.Items.AddRange(new object[] {
            "Utilizator",
            "Admin"});
            this.cmbTip.Location = new System.Drawing.Point(848, 301);
            this.cmbTip.Name = "cmbTip";
            this.cmbTip.Size = new System.Drawing.Size(272, 37);
            this.cmbTip.TabIndex = 30;
            // 
            // btnModifica
            // 
            this.btnModifica.BackColor = System.Drawing.Color.LightGray;
            this.btnModifica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifica.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifica.Location = new System.Drawing.Point(637, 436);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(183, 46);
            this.btnModifica.TabIndex = 31;
            this.btnModifica.TabStop = false;
            this.btnModifica.Text = "Modifica Date";
            this.btnModifica.UseVisualStyleBackColor = false;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // FrmAdministrareUtilizatori
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1167, 539);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.cmbTip);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cmbTeme);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtNume);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btnMinimise);
            this.Controls.Add(this.btnInchide);
            this.Controls.Add(this.lblTitlu);
            this.Controls.Add(this.pnlStanga);
            this.Controls.Add(this.pnlDreapta);
            this.Controls.Add(this.pnlJos);
            this.Controls.Add(this.pnlSus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmAdministrareUtilizatori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdministrareUtilizatori";
            this.Load += new System.EventHandler(this.FrmAdministrareUtilizatori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMinimise;
        private System.Windows.Forms.Button btnInchide;
        private System.Windows.Forms.Label lblTitlu;
        public System.Windows.Forms.Panel pnlStanga;
        public System.Windows.Forms.Panel pnlDreapta;
        public System.Windows.Forms.Panel pnlJos;
        public System.Windows.Forms.Panel pnlSus;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUtilizator;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeUtilizator;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailUtilizator;
        private System.Windows.Forms.DataGridViewTextBoxColumn temaAleasaUtilizator;
        private System.Windows.Forms.DataGridViewCheckBoxColumn adminUtilizator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNume;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbTeme;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbTip;
        private System.Windows.Forms.Button btnModifica;
    }
}