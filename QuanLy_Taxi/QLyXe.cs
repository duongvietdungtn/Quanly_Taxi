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
        public void loaddataxe()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Maxe, Bienxe, Hangxe, Tenxe, Matxe FROM QLXe", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgrid_QLXe.DataSource = dt;

                // Ánh xạ tên cột trong DataGridView với tên trường dữ liệu trong DataTable
                dtgrid_QLXe.Columns[0].HeaderText = "Mã Xe";
                dtgrid_QLXe.Columns[1].HeaderText = "Biển số xe";
                //dtgrid_QLXe.Columns[2].HeaderText = "Ảnh xe";
                dtgrid_QLXe.Columns[2].HeaderText = "Hãng xe";
                dtgrid_QLXe.Columns[3].HeaderText = "Tên xe";
                dtgrid_QLXe.Columns[4].HeaderText = "Mã tài xế";

                dtgrid_QLXe.Columns["Maxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLXe.Columns["Bienxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dtgrid_QLXe.Columns["Anhxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLXe.Columns["Hangxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLXe.Columns["Tenxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLXe.Columns["Matxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
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
            DataGridViewRow selectedRow = dtgrid_QLXe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();

                QLXe_sua_dialog editForm = new QLXe_sua_dialog(maxe);
                editForm.Owner = this;
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void btn_xe_chitiet_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dtgrid_QLXe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();

                QLXe_chitiet_dialog viewForm = new QLXe_chitiet_dialog(maxe);
                viewForm.Owner = this;
                viewForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void QLyXe_Load(object sender, EventArgs e)
        {
            loaddataxe();
        }

        private void btn_xe_xoa_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLXe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất giá trị của trường "Matxe" từ dòng được chọn
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tạo câu lệnh SQL DELETE
                        string sqlDelete = "DELETE FROM QLXe WHERE Maxe = @Maxe";

                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            // Thêm tham số cho trường "Maxe"
                            cmd.Parameters.AddWithValue("@Maxe", maxe);

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
            loaddataxe();
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            string connection = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter da1;
            DataTable dt1;
            con.Open();
            da1 = new SqlDataAdapter("SELECT Maxe, Bienxe,Hangxe, Tenxe, Matxe FROM QLXe WHERE Maxe LIKE'%" + this.tb_search.Text + "%' OR Bienxe LIKE '%" + this.tb_search.Text + "%' OR Hangxe LIKE '%" + this.tb_search.Text + "%' OR Matxe LIKE '%" + this.tb_search.Text + "%'", con);
            dt1 = new DataTable();
            da1.Fill(dt1);

            dtgrid_QLXe.DataSource = dt1;
            con.Close();
        }
    }
}
