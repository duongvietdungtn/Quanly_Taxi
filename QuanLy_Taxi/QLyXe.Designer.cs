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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            listView1 = new ListView();
            btn_xe_them = new Guna.UI2.WinForms.Guna2Button();
            btn_xe_sua = new Guna.UI2.WinForms.Guna2Button();
            btn_xe_xoa = new Guna.UI2.WinForms.Guna2Button();
            btn_xe_chitiet = new Guna.UI2.WinForms.Guna2Button();
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
            // listView1
            // 
            listView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listView1.Location = new Point(24, 230);
            listView1.Name = "listView1";
            listView1.Size = new Size(940, 492);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btn_xe_them
            // 
            btn_xe_them.BorderRadius = 6;
            btn_xe_them.CustomizableEdges = customizableEdges1;
            btn_xe_them.DisabledState.BorderColor = Color.DarkGray;
            btn_xe_them.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_xe_them.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_xe_them.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_xe_them.FillColor = Color.FromArgb(0, 192, 0);
            btn_xe_them.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_xe_them.ForeColor = Color.White;
            btn_xe_them.Location = new Point(23, 168);
            btn_xe_them.Name = "btn_xe_them";
            btn_xe_them.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btn_xe_them.Size = new Size(101, 45);
            btn_xe_them.TabIndex = 2;
            btn_xe_them.Text = "Thêm mới";
            btn_xe_them.Click += btn_xe_them_Click;
            // 
            // btn_xe_sua
            // 
            btn_xe_sua.BorderRadius = 6;
            btn_xe_sua.CustomizableEdges = customizableEdges3;
            btn_xe_sua.DisabledState.BorderColor = Color.DarkGray;
            btn_xe_sua.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_xe_sua.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_xe_sua.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_xe_sua.FillColor = Color.FromArgb(192, 192, 0);
            btn_xe_sua.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_xe_sua.ForeColor = Color.White;
            btn_xe_sua.Location = new Point(140, 168);
            btn_xe_sua.Name = "btn_xe_sua";
            btn_xe_sua.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btn_xe_sua.Size = new Size(91, 45);
            btn_xe_sua.TabIndex = 2;
            btn_xe_sua.Text = "Sửa";
            btn_xe_sua.Click += btn_xe_sua_Click;
            // 
            // btn_xe_xoa
            // 
            btn_xe_xoa.BorderRadius = 6;
            btn_xe_xoa.CustomizableEdges = customizableEdges5;
            btn_xe_xoa.DisabledState.BorderColor = Color.DarkGray;
            btn_xe_xoa.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_xe_xoa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_xe_xoa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_xe_xoa.FillColor = Color.Red;
            btn_xe_xoa.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_xe_xoa.ForeColor = Color.White;
            btn_xe_xoa.Location = new Point(248, 168);
            btn_xe_xoa.Name = "btn_xe_xoa";
            btn_xe_xoa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btn_xe_xoa.Size = new Size(88, 45);
            btn_xe_xoa.TabIndex = 2;
            btn_xe_xoa.Text = "Xóa";
            // 
            // btn_xe_chitiet
            // 
            btn_xe_chitiet.BorderRadius = 6;
            btn_xe_chitiet.CustomizableEdges = customizableEdges7;
            btn_xe_chitiet.DisabledState.BorderColor = Color.DarkGray;
            btn_xe_chitiet.DisabledState.CustomBorderColor = Color.DarkGray;
            btn_xe_chitiet.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btn_xe_chitiet.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btn_xe_chitiet.FillColor = Color.FromArgb(0, 192, 0);
            btn_xe_chitiet.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btn_xe_chitiet.ForeColor = Color.White;
            btn_xe_chitiet.Location = new Point(355, 168);
            btn_xe_chitiet.Name = "btn_xe_chitiet";
            btn_xe_chitiet.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btn_xe_chitiet.Size = new Size(84, 45);
            btn_xe_chitiet.TabIndex = 2;
            btn_xe_chitiet.Text = "Chi tiết";
            btn_xe_chitiet.Click += btn_xe_chitiet_Click;
            // 
            // QLyXe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(989, 745);
            Controls.Add(btn_xe_chitiet);
            Controls.Add(btn_xe_xoa);
            Controls.Add(btn_xe_sua);
            Controls.Add(btn_xe_them);
            Controls.Add(listView1);
            Controls.Add(label1);
            Name = "QLyXe";
            StartPosition = FormStartPosition.Manual;
            Text = "QLyXe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView listView1;
        private Guna.UI2.WinForms.Guna2Button btn_xe_them;
        private Guna.UI2.WinForms.Guna2Button btn_xe_sua;
        private Guna.UI2.WinForms.Guna2Button btn_xe_xoa;
        private Guna.UI2.WinForms.Guna2Button btn_xe_chitiet;
    }
}