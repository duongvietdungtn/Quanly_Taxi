using System;
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
    public partial class QLTX_chitiet_dialog : Form
    {
        public QLTX_chitiet_dialog()
        {
            InitializeComponent();
            tb_matx.Enabled = false;
            tb_hoten.Enabled = false;
            tb_dchi.Enabled = false;
            tb_sdt.Enabled = false;
            tb_maxe.Enabled = false;
            dtpk_ngaysinh.Enabled = false;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_matx_TextChanged(object sender, EventArgs e)
        {
            tb_matx.Enabled = false;
        }

        private void btn_upanh_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pbx_anhtx.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }
    }
}
