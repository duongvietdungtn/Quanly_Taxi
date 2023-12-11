﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_Taxi
{
    public partial class QlyLuong : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QlyLuong()
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

        public void loaddataluong()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Maluong, Matxe, Hoten, Thangluong, Namluong, Songaycong, Thuong, Phat, Tongluong FROM QLLuong", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgrid_QLLuong.DataSource = dt;

                // Ánh xạ tên cột trong DataGridView với tên trường dữ liệu trong DataTable
                dtgrid_QLLuong.Columns[0].HeaderText = "Mã Lương";
                dtgrid_QLLuong.Columns[1].HeaderText = "Mã tài xế";
                dtgrid_QLLuong.Columns[2].HeaderText = "Họ và tên";
                dtgrid_QLLuong.Columns[3].HeaderText = "Tháng";
                dtgrid_QLLuong.Columns[4].HeaderText = "Năm";
                dtgrid_QLLuong.Columns[5].HeaderText = "Số ngày công";
                dtgrid_QLLuong.Columns[6].HeaderText = "Thưởng";
                dtgrid_QLLuong.Columns[7].HeaderText = "Phạt";
                dtgrid_QLLuong.Columns[8].HeaderText = "Tổng Lương";

                dtgrid_QLLuong.Columns["Maluong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLLuong.Columns["Matxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLLuong.Columns["Thangluong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLLuong.Columns["Namluong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLLuong.Columns["Songaycong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLLuong.Columns["Thuong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLLuong.Columns["Phat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLLuong.Columns["Tongluong"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
            }
        }

        private void btn_luong_them_Click(object sender, EventArgs e)
        {
            QLLuong_them_dialog b1 = new QLLuong_them_dialog();
            b1.Owner = this;
            b1.ShowDialog();
        }

        private void btn_luong_sua_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dtgrid_QLLuong.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                string maluong = selectedRow.Cells["Maluong"].Value.ToString();

                QLLuong_sua_dialog editForm = new QLLuong_sua_dialog(maluong);
                editForm.Owner = this;
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void btn_luong_chitiet_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dtgrid_QLLuong.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                string maluong = selectedRow.Cells["Maluong"].Value.ToString();

                QLLuong_chitiet_dialog viewForm = new QLLuong_chitiet_dialog(maluong);
                viewForm.Owner = this;
                viewForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void QlyLuong_Load(object sender, EventArgs e)
        {
            loaddataluong();
            // Đặt giá trị mặc định cho ComboBox tháng
            cbb_locthang.SelectedItem = DateTime.Now.Month.ToString();

            // Đặt giá trị mặc định cho ComboBox năm
            cbb_locnam.SelectedItem = DateTime.Now.Year.ToString();
        }

        private void btn_luong_xoa_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLLuong.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất giá trị của trường "Maluong" từ dòng được chọn
                string maluong = selectedRow.Cells["Maluong"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tạo câu lệnh SQL DELETE
                        string sqlDelete = "DELETE FROM QLLuong WHERE Maluong = @Maluong";

                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            // Thêm tham số cho trường "Maluong"
                            cmd.Parameters.AddWithValue("@Maluong", maluong);

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
            loaddataluong();
        }

        private void tb_search_TextChanged_1(object sender, EventArgs e)
        {
            string connection = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter da1;
            DataTable dt1;
            con.Open();
            da1 = new SqlDataAdapter("SELECT Maluong, Matxe, Hoten, Thangluong, NamLuong, Songaycong, Thuong, Phat, Tongluong FROM QLLuong WHERE OR Matxe LIKE'%" + this.tb_search.Text + "%' OR Maluong LIKE '%" + this.tb_search.Text + "%'", con);
            dt1 = new DataTable();
            da1.Fill(dt1);

            dtgrid_QLLuong.DataSource = dt1;
            con.Close();
        }

        private void btn_loc_Click(object sender, EventArgs e)
        {
            string connection = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter da1;
            DataTable dt1;
            con.Open();
            String locthang = cbb_locthang.SelectedItem.ToString();
            String locnam = cbb_locnam.SelectedItem.ToString();
            da1 = new SqlDataAdapter("SELECT Maluong, Matxe, Hoten, Thangluong, NamLuong, Songaycong, Thuong, Phat, Tongluong FROM QLLuong WHERE Thangluong LIKE'%" + locthang + "%' OR Namluong LIKE'%" + locnam + "%'", con);
            dt1 = new DataTable();
            da1.Fill(dt1);

            dtgrid_QLLuong.DataSource = dt1;
            con.Close();
        }

        private void btn_huyloc_Click(object sender, EventArgs e)
        {
            loaddataluong();
        }

        private void btn_xuatexcel_Click(object sender, EventArgs e)
        {

        }
    }
}
