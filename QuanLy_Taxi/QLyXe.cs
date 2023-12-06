using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLy_Taxi
{
    public partial class QLyXe : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLyXe()
        {
            InitializeComponent();
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open(); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_xe_them_Click(object sender, EventArgs e)
        {
            QLXe_them_dialog c1 = new QLXe_them_dialog();
            c1.Owner = this;
            c1.ShowDialog();
        }

        private void btn_xe_sua_Click(object sender, EventArgs e)
        {
            //QLXe_sua_dialog c2 = new QLXe_sua_dialog();
            //c2.ShowDialog();
            //// Lấy dòng được chọn từ DataGridView
            //DataGridViewRow selectedRow = dtgrid_QLXe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            //if (selectedRow != null)
            //{
            //    // Trích xuất dữ liệu từ dòng được chọn
            //    string maxe = selectedRow.Cells["Maxe"].Value.ToString();
            //    string bienxe = selectedRow.Cells["Bienxe"].Value.ToString();
            //    string hangxe = selectedRow.Cells["Hangxe"].Value.ToString();
            //    string tenxe = selectedRow.Cells["Tenxe"].Value.ToString();
            //    string matxe = selectedRow.Cells["Matxe"].Value.ToString();

            //    // Mở form sửa và truyền dữ liệu
            //    QLTX_sua_dialog editForm = new QLTX_sua_dialog();
            //    editForm.SetData(maxe, bienxe, hangxe, tenxe, matxe);
            //    editForm.Owner = this;
            //    editForm.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            //}
        }

        private void btn_xe_chitiet_Click(object sender, EventArgs e)
        {
            QLXe_chitiet_dialog c3 = new QLXe_chitiet_dialog();
            c3.ShowDialog();
        }

        private void dtgrid_QLXe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QLyXe_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Maxe, Bienxe, Anhxe, Hangxe, Tenxe, Matxe FROM QLXe", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgrid_QLXe.DataSource = dt;

                // Ánh xạ tên cột trong DataGridView với tên trường dữ liệu trong DataTable
                dtgrid_QLXe.Columns[0].HeaderText = "Mã Xe";
                dtgrid_QLXe.Columns[1].HeaderText = "Biển số xe";
                dtgrid_QLXe.Columns[2].HeaderText = "Ảnh xe";
                dtgrid_QLXe.Columns[3].HeaderText = "Hãng xe";
                dtgrid_QLXe.Columns[4].HeaderText = "Tên xe";
                dtgrid_QLXe.Columns[5].HeaderText = "Mã tài xế";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
            }
        }
        public void RefreshDataGridView()
        {
            // Refresh the DataGridView after adding a new record
            try
            {
                SqlCommand cmd = new SqlCommand("Select Maxe, Bienxe, Hangxe, Tenxe, Soghe, Namsx, Sokhung, Matxe, Hoten FROM QLXe", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgrid_QLXe.Columns.Clear();
                dtgrid_QLXe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
            }
        }
    }
}
