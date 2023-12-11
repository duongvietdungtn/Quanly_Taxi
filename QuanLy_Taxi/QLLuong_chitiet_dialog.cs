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

namespace QuanLy_Taxi
{
    public partial class QLLuong_chitiet_dialog : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123; MultipleActiveResultSets=true";

        public QLLuong_chitiet_dialog(String maluong)
        {
            InitializeComponent();
            tb_maluong.Enabled = false;
            cbb_nam.Enabled = false;
            cbb_thang.Enabled = false;
            cbb_matxe.Enabled = false;
            tb_name.Enabled = false;
            tb_ngaycong.Enabled = false;
            tb_thuong.Enabled = false;
            tb_phat.Enabled = false;
            tb_tongluong.Enabled = false;
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                // Gọi hàm để load dữ liệu vào ComboBox cbb_matxe
                LoadMatxeData();

                // Gọi hàm để load dữ liệu vào ComboBox cbb_thang
                LoadThangData();

                // Gọi hàm để load dữ liệu vào ComboBox cbb_nam
                LoadNamData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Lấy dữ liệu từ SQL và đặt nó trong các ô văn bản
            SetDataFromSQL(maluong);
        }

        private void LoadMatxeData()
        {
            try
            {
                // Thực hiện truy vấn để lấy danh sách giá trị từ cột Matxe của bảng QLTxe
                string query = "SELECT Matxe FROM QLTxe";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Đọc từng giá trị và thêm vào ComboBox cbb_matxe
                while (reader.Read())
                {
                    cbb_matxe.Items.Add(reader["Matxe"].ToString());
                }

                // Đóng đối tượng SqlDataReader
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu cho ComboBox Matxe: " + ex.Message);
            }
        }

        private string GetImagePathForMatxe(string matxe)
        {
            try
            {
                string query = "SELECT Linkanh FROM QLTxe WHERE Matxe = @Matxe";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Matxe", matxe);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return reader["Linkanh"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đường dẫn ảnh từ CSDL: " + ex.Message);
            }

            return null;
        }

        private void SetDataFromSQL(string maluong)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM QLLuong WHERE Maluong = @Maluong", conn);
                cmd.Parameters.AddWithValue("@Maluong", maluong);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    tb_maluong.Text = reader["Maluong"].ToString();
                    cbb_thang.SelectedItem = reader["Thangluong"].ToString();
                    cbb_nam.SelectedItem = reader["Namluong"].ToString();
                    cbb_matxe.SelectedItem = reader["Matxe"].ToString();
                    tb_name.Text = reader["Hoten"].ToString();
                    tb_ngaycong.Text = reader["Songaycong"].ToString();
                    tb_thuong.Text = reader["Thuong"].ToString();
                    tb_phat.Text = reader["Phat"].ToString();
                    tb_tongluong.Text = reader["Tongluong"].ToString();

                    // Lấy đường dẫn ảnh từ QLTxe và hiển thị lên PictureBox
                    string imagePath = GetImagePathForMatxe(reader["Matxe"].ToString());
                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        pbx_anhtx.Image = Image.FromFile(imagePath);
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ CSDL: " + ex.Message);
            }
        }

        private void LoadThangData()
        {
            try
            {
                // Thực hiện truy vấn để lấy danh sách giá trị từ cột Thangluong của bảng QLLuong
                string query = "SELECT DISTINCT Thangluong FROM QLLuong";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Đọc từng giá trị và thêm vào ComboBox cbb_thang
                while (reader.Read())
                {
                    cbb_thang.Items.Add(reader["Thangluong"].ToString());
                }

                // Đóng đối tượng SqlDataReader
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu cho ComboBox Thangluong: " + ex.Message);
            }
        }

        private void LoadNamData()
        {
            try
            {
                // Thực hiện truy vấn để lấy danh sách giá trị từ cột Namluong của bảng QLLuong
                string query = "SELECT DISTINCT Namluong FROM QLLuong";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Đọc từng giá trị và thêm vào ComboBox cbb_nam
                while (reader.Read())
                {
                    cbb_nam.Items.Add(reader["Namluong"].ToString());
                }

                // Đóng đối tượng SqlDataReader
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu cho ComboBox Namluong: " + ex.Message);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
