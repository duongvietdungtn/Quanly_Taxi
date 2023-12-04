﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_Taxi
{
    public partial class QLLuong_chitiet_dialog : Form
    {
        public QLLuong_chitiet_dialog()
        {
            InitializeComponent();
            cbb_nam.Enabled = false;
            cbb_thang.Enabled = false;
            tb_matxe.Enabled = false;
            tb_name.Enabled = false;
            tb_ngaycong.Enabled = false;
            tb_thuong.Enabled = false;
            tb_phat.Enabled = false;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_upanh_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pbx_anhtx.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}