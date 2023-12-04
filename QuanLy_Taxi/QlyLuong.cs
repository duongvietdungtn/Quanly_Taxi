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
    public partial class QlyLuong : Form
    {
        public QlyLuong()
        {
            InitializeComponent();
        }

        private void btn_luong_them_Click(object sender, EventArgs e)
        {
            QLLuong_them_dialog b1 = new QLLuong_them_dialog();
            b1.ShowDialog();
        }

        private void btn_luong_sua_Click(object sender, EventArgs e)
        {
            QLLuong_sua_dialog b2 = new QLLuong_sua_dialog();
            b2.ShowDialog();
        }

        private void btn_luong_chitiet_Click(object sender, EventArgs e)
        {
            QLLuong_chitiet_dialog b3 = new QLLuong_chitiet_dialog();
            b3.ShowDialog();
        }
    }
}
