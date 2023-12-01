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
    public partial class QLyTaixe : Form
    {
        public QLyTaixe()
        {
            InitializeComponent();
        }

        private void btn_txe_them_Click(object sender, EventArgs e)
        {
            QLTX_them_dialog a1 = new QLTX_them_dialog();
            a1.ShowDialog();
        }

        private void btn_txe_sua_Click(object sender, EventArgs e)
        {
            QLTX_sua_dialog a2 = new QLTX_sua_dialog();
            a2.ShowDialog();
        }

        private void btn_txe_chitiet_Click(object sender, EventArgs e)
        {
            QLTX_chitiet_dialog a3 = new QLTX_chitiet_dialog();
            a3.ShowDialog();
        }
    }
}
