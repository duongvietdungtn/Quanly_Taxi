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
    public partial class QLyXe : Form
    {
        public QLyXe()
        {
            InitializeComponent();
        }

        private void btn_xe_them_Click(object sender, EventArgs e)
        {
            QLXe_them_dialog c1 = new QLXe_them_dialog();
            c1.ShowDialog();
        }

        private void btn_xe_sua_Click(object sender, EventArgs e)
        {
            QLXe_sua_dialog c2 = new QLXe_sua_dialog();
            c2.ShowDialog();
        }

        private void btn_xe_chitiet_Click(object sender, EventArgs e)
        {
            QLXe_chitiet_dialog c3 = new QLXe_chitiet_dialog();
            c3.ShowDialog();
        }
    }
}
