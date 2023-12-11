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
    public partial class QLLuong_sua_dialog : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123; MultipleActiveResultSets=true";

        public QLLuong_sua_dialog(string maluong)
        {
            InitializeComponent();
            tb_maluong.Enabled = false;
            cbb_matxe.Enabled = false;
            cbb_nam.Enabled = false;
            cbb_thang.Enabled = false;
            tb_name.Enabled = false;
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


        private void btn_upanh_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pbx_anhtx.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                // Tính giá trị cho cột Tongluong theo công thức ngaycong*300000 + thuong - phat
                int ngaycong = int.Parse(tb_ngaycong.Text);
                int thuong = int.Parse(tb_thuong.Text);
                int phat = int.Parse(tb_phat.Text);
                int tongluong = ngaycong * 300000 + thuong - phat;

                // Tạo câu lệnh SQL UPDATE với các giá trị từ các điều khiển trên form
                string sqlUpdate = "UPDATE QLLuong SET Maluong = @Maluong, Thangluong =@Thang, Namluong = @Nam, Matxe = Matxe, Hoten =@Hoten, Songaycong =@Songaycong, Thuong =@Thuong, Phat =@Phat, Tongluong =@Tongluong WHERE Maluong = @Maluong";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                {
                    // Thay thế các tham số trong câu lệnh SQL bằng giá trị từ các điều khiển trên form
                    cmd.Parameters.AddWithValue("@Maluong", tb_maluong.Text);
                    cmd.Parameters.AddWithValue("@Matxe", cbb_matxe.Text);
                    cmd.Parameters.AddWithValue("@Hoten", tb_name.Text);
                    cmd.Parameters.AddWithValue("@Thang", cbb_thang.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Nam", cbb_nam.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Songaycong", tb_ngaycong.Text);
                    cmd.Parameters.AddWithValue("@Thuong", tb_thuong.Text);
                    cmd.Parameters.AddWithValue("@Phat", tb_phat.Text);
                    cmd.Parameters.AddWithValue("@Tongluong", tongluong);

                    // Thực hiện câu lệnh SQL UPDATE
                    cmd.ExecuteNonQuery();

                    // Thông báo thành công nếu không có lỗi
                    MessageBox.Show("Dữ liệu đã được cập nhật vào CSDL thành công!");
                    ((QlyLuong)this.Owner).RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
