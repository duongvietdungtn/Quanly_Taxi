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
    public partial class QLXe_chitiet_dialog : Form
    {
        public QLXe_chitiet_dialog()
        {
            InitializeComponent();
            tb_bienxe.Enabled = false;
            tb_maxe.Enabled = false;
            tb_hangxe.Enabled = false;
            tb_tenxe.Enabled = false;
            tb_soghe.Enabled = false;
            tb_namsx.Enabled = false;
            tb_sokhung.Enabled = false;
            tb_matxe.Enabled = false;
            tb_tentxe.Enabled = false;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_upanh_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pbx_anhxe.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbx_anhtx_Click(object sender, EventArgs e)
        {

        }
    }
}
