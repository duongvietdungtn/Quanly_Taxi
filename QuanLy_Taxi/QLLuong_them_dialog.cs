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
    public partial class QLLuong_them_dialog : Form
    {
        public QLLuong_them_dialog()
        {
            InitializeComponent();
            tb_name.Enabled = false;
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

        private void cbb_nam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}