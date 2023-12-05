using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;

namespace QuanLy_Taxi
{
    public partial class QLyTaixe : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLyTaixe()
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
        private void btn_txe_them_Click(object sender, EventArgs e)
        {
            QLTX_them_dialog a1 = new QLTX_them_dialog();
            a1.Owner = this;
            a1.ShowDialog();
        }

        private void btn_txe_sua_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLTxe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất dữ liệu từ dòng được chọn
                string matxe = selectedRow.Cells["Matxe"].Value.ToString();
                string hoten = selectedRow.Cells["Hoten"].Value.ToString();
                DateTime ngaysinh = Convert.ToDateTime(selectedRow.Cells["Ngaysinh"].Value);
                string gioitinh = selectedRow.Cells["Gioitinh"].Value.ToString();
                string diachi = selectedRow.Cells["Diachi"].Value.ToString();
                string sdt = selectedRow.Cells["Sdt"].Value.ToString();
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();

                // Mở form sửa và truyền dữ liệu
                QLTX_sua_dialog editForm = new QLTX_sua_dialog();
                editForm.SetData(matxe, hoten, ngaysinh, gioitinh, diachi, sdt, maxe);
                editForm.Owner = this;
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void btn_txe_chitiet_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLTxe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất dữ liệu từ dòng được chọn
                string matxe = selectedRow.Cells["Matxe"].Value.ToString();
                string hoten = selectedRow.Cells["Hoten"].Value.ToString();
                DateTime ngaysinh = Convert.ToDateTime(selectedRow.Cells["Ngaysinh"].Value);
                string gioitinh = selectedRow.Cells["Gioitinh"].Value.ToString();
                string diachi = selectedRow.Cells["Diachi"].Value.ToString();
                string sdt = selectedRow.Cells["Sdt"].Value.ToString();
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();

                // Mở form sửa và truyền dữ liệu
                QLTX_chitiet_dialog viewForm = new QLTX_chitiet_dialog();
                viewForm.SetData(matxe, hoten, ngaysinh, gioitinh, diachi, sdt, maxe);
                viewForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xem thông tin.");
            }
        }
        private void QLyTaixe_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Matxe, Hoten, AnhTxe, Ngaysinh, Gioitinh, Diachi, Sdt, Maxe FROM QLTxe", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgrid_QLTxe.DataSource = dt;

                // Ánh xạ tên cột trong DataGridView với tên trường dữ liệu trong DataTable
                dtgrid_QLTxe.Columns[0].HeaderText = "Mã tài xế";
                dtgrid_QLTxe.Columns[1].HeaderText = "Họ và tên";
                dtgrid_QLTxe.Columns[2].HeaderText = "Ảnh";
                dtgrid_QLTxe.Columns[3].HeaderText = "Ngày sinh";
                dtgrid_QLTxe.Columns[4].HeaderText = "Giới tính";
                dtgrid_QLTxe.Columns[5].HeaderText = "Địa chỉ";
                dtgrid_QLTxe.Columns[6].HeaderText = "Số điện thoại";
                dtgrid_QLTxe.Columns[7].HeaderText = "Mã xe";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
            }
        }

        private void tb_searchtxe_TextChanged(object sender, EventArgs e)
        {
            string connection = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter da1;
            DataTable dt1;
            con.Open();
            da1 = new SqlDataAdapter("SELECT * FROM QLTxe WHERE Hoten LIKE'%" + this.tb_searchtxe.Text + "%' OR Matxe LIKE '%" + this.tb_searchtxe.Text + "%' OR Diachi LIKE '%" + this.tb_searchtxe.Text + "%' OR Sdt LIKE '%" + this.tb_searchtxe.Text + "%' OR Maxe LIKE '%" + this.tb_searchtxe.Text + "%'", con);
            dt1 = new DataTable();
            da1.Fill(dt1);
            dtgrid_QLTxe.DataSource = dt1;
            con.Close();
        }

        private void btn_txe_xoa_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLTxe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất giá trị của trường "Matxe" từ dòng được chọn
                string matxe = selectedRow.Cells["Matxe"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tạo câu lệnh SQL DELETE
                        string sqlDelete = "DELETE FROM QLTxe WHERE Matxe = @Matxe";

                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            // Thêm tham số cho trường "Matxe"
                            cmd.Parameters.AddWithValue("@Matxe", matxe);

                            // Thực hiện câu lệnh SQL DELETE
                            cmd.ExecuteNonQuery();

                            // Thông báo thành công nếu không có lỗi
                            //MessageBox.Show("Dữ liệu đã được xóa khỏi CSDL thành công!");
                        }

                        // Refresh DataGridView to reflect the changes
                        RefreshDataGridView();
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

        public void RefreshDataGridView()
        {
            // Refresh the DataGridView after adding a new record
            try
            {
                SqlCommand cmd = new SqlCommand("Select Matxe, Hoten, AnhTxe, Ngaysinh, Gioitinh, Diachi, Sdt, Maxe FROM QLTxe", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgrid_QLTxe.Columns.Clear();
                dtgrid_QLTxe.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
            }
        }
    }
}