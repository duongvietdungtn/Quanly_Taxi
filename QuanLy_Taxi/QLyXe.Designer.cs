namespace QuanLy_Taxi
{
    partial class QLyXe
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            btn_xe_them = new Guna.UI2.WinForms.Guna2Button();
            btn_xe_sua = new Guna.UI2.WinForms.Guna2Button();
            btn_xe_xoa = new Guna.UI2.WinForms.Guna2Button();
            btn_xe_chitiet = new Guna.UI2.WinForms.Guna2Button();
            dtgrid_QLXe = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dtgrid_QLXe).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(412, 9);
            label1.Name = "label1";
            label1.Size = new Size(224, 41);
            label1.TabIndex = 0;
            label1.Text = "THÔNG TIN XE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_xe_them
            // 
            btn_xe_them.BorderRadius = 6;
            btn_xe_them.CustomizableEdges = customizableEdges9;
            btn_xe_them.DisabledState.BorderColor = Color.DarkGray;
            btn_xe_them.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_xe_them.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_xe_them.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_xe_them.FillColor = Color.FromArgb(0, 192, 0);
            btn_xe_them.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_xe_them.ForeColor = Color.White;
            btn_xe_them.Location = new Point(23, 168);
            btn_xe_them.Name = "btn_xe_them";
            btn_xe_them.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btn_xe_them.Size = new Size(101, 45);
            btn_xe_them.TabIndex = 2;
            btn_xe_them.Text = "Thêm mới";
            btn_xe_them.Click += btn_xe_them_Click;
            // 
            // btn_xe_sua
            // 
            btn_xe_sua.BorderRadius = 6;
            btn_xe_sua.CustomizableEdges = customizableEdges11;
            btn_xe_sua.DisabledState.BorderColor = Color.DarkGray;
            btn_xe_sua.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_xe_sua.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_xe_sua.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_xe_sua.FillColor = Color.FromArgb(192, 192, 0);
            btn_xe_sua.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_xe_sua.ForeColor = Color.White;
            btn_xe_sua.Location = new Point(140, 168);
            btn_xe_sua.Name = "btn_xe_sua";
            btn_xe_sua.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btn_xe_sua.Size = new Size(91, 45);
            btn_xe_sua.TabIndex = 2;
            btn_xe_sua.Text = "Sửa";
            btn_xe_sua.Click += btn_xe_sua_Click;
            // 
            // btn_xe_xoa
            // 
            btn_xe_xoa.BorderRadius = 6;
            btn_xe_xoa.CustomizableEdges = customizableEdges13;
            btn_xe_xoa.DisabledState.BorderColor = Color.DarkGray;
            btn_xe_xoa.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_xe_xoa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_xe_xoa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_xe_xoa.FillColor = Color.Red;
            btn_xe_xoa.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_xe_xoa.ForeColor = Color.White;
            btn_xe_xoa.Location = new Point(248, 168);
            btn_xe_xoa.Name = "btn_xe_xoa";
            btn_xe_xoa.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btn_xe_xoa.Size = new Size(88, 45);
            btn_xe_xoa.TabIndex = 2;
            btn_xe_xoa.Text = "Xóa";
            // 
            // btn_xe_chitiet
            // 
            btn_xe_chitiet.BorderRadius = 6;
            btn_xe_chitiet.CustomizableEdges = customizableEdges15;
            btn_xe_chitiet.DisabledState.BorderColor = Color.DarkGray;
            btn_xe_chitiet.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_xe_chitiet.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_xe_chitiet.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_xe_chitiet.FillColor = Color.FromArgb(0, 192, 0);
            btn_xe_chitiet.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_xe_chitiet.ForeColor = Color.White;
            btn_xe_chitiet.Location = new Point(355, 168);
            btn_xe_chitiet.Name = "btn_xe_chitiet";
            btn_xe_chitiet.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btn_xe_chitiet.Size = new Size(84, 45);
            btn_xe_chitiet.TabIndex = 2;
            btn_xe_chitiet.Text = "Chi tiết";
            btn_xe_chitiet.Click += btn_xe_chitiet_Click;
            // 
            // dtgrid_QLXe
            // 
            dtgrid_QLXe.AllowUserToAddRows = false;
            dtgrid_QLXe.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dtgrid_QLXe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgrid_QLXe.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 12.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dtgrid_QLXe.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dtgrid_QLXe.ColumnHeadersHeight = 30;
            dtgrid_QLXe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dtgrid_QLXe.DefaultCellStyle = dataGridViewCellStyle4;
            dtgrid_QLXe.Location = new Point(24, 230);
            dtgrid_QLXe.MultiSelect = false;
            dtgrid_QLXe.Name = "dtgrid_QLXe";
            dtgrid_QLXe.ReadOnly = true;
            dtgrid_QLXe.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dtgrid_QLXe.RowTemplate.Height = 25;
            dtgrid_QLXe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgrid_QLXe.Size = new Size(940, 492);
            dtgrid_QLXe.TabIndex = 3;
            dtgrid_QLXe.CellContentClick += dtgrid_QLXe_CellContentClick;
            // 
            // QLyXe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(989, 745);
            Controls.Add(dtgrid_QLXe);
            Controls.Add(btn_xe_chitiet);
            Controls.Add(btn_xe_xoa);
            Controls.Add(btn_xe_sua);
            Controls.Add(btn_xe_them);
            Controls.Add(label1);
            Name = "QLyXe";
            StartPosition = FormStartPosition.Manual;
            Text = "QLyXe";
            Load += QLyXe_Load;
            ((System.ComponentModel.ISupportInitialize)dtgrid_QLXe).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btn_xe_them;
        private Guna.UI2.WinForms.Guna2Button btn_xe_sua;
        private Guna.UI2.WinForms.Guna2Button btn_xe_xoa;
        private Guna.UI2.WinForms.Guna2Button btn_xe_chitiet;
        private DataGridView dtgrid_QLXe;
    }
}