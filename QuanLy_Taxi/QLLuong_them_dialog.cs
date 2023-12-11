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
using Guna.UI2.WinForms.Enums;

namespace QuanLy_Taxi
{
    public partial class QLLuong_them_dialog : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLLuong_them_dialog()
        {
            InitializeComponent();
            tb_name.Enabled = false;
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                // Gọi hàm để load dữ liệu vào ComboBox cbb_matxe
                LoadMatxeData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cbb_matxe.SelectedIndexChanged += cbb_matxe_SelectedIndexChanged;
        }
        private void LoadMatxeData()
        {
            try
            {
                // Đặt giá trị mặc định cho ComboBox tháng
                cbb_thang.SelectedItem = DateTime.Now.Month.ToString();

                // Đặt giá trị mặc định cho ComboBox năm
                cbb_nam.SelectedItem = DateTime.Now.Year.ToString();

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

        private string GetHotenLinkanhByMatxe(string matxe)
        {
            string hoten = string.Empty;
            string linkanh1 = string.Empty;
            try
            {
                // Thực hiện truy vấn để lấy Hoten từ bảng QLTxe theo Matxe
                string query = "SELECT Hoten, Linkanh FROM QLTxe WHERE Matxe = @Matxe";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Matxe", matxe);
                SqlDataReader reader = cmd.ExecuteReader();

                // Đọc giá trị Hoten từ SqlDataReader
                if (reader.Read())
                {
                    hoten = reader["Hoten"].ToString();
                    linkanh1 = reader["Linkanh"].ToString();
                    if (!string.IsNullOrEmpty(linkanh1))
                    {
                        pbx_anhtx.Image = Image.FromFile(linkanh1);
                    }
                    else
                    {
                        // Xử lý trường hợp không có đường dẫn ảnh
                        pbx_anhtx.Image = null; // hoặc đặt một hình ảnh mặc định khác
                    }
                }

                // Đóng đối tượng SqlDataReader
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy Hoten từ QLTxe: " + ex.Message);
            }

            return hoten;
        }
        private void cbb_matxe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // MessageBox.Show("SelectedIndexChanged"); // Thêm dòng này để kiểm tra xem sự kiện có được kích hoạt không
                // Khi giá trị trong ComboBox cbb_matxe thay đổi, lấy Hoten tương ứng và gán vào tb_name
                string selectedMatxe = cbb_matxe.SelectedItem.ToString();
                string hoten = GetHotenLinkanhByMatxe(selectedMatxe);
                string linkanh1 = GetHotenLinkanhByMatxe(selectedMatxe);
                tb_name.Text = hoten;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tên từ QLTxe: " + ex.Message);
            }
        }
        private string GenerateRandomMaLuong()
        {
            // Tạo một số ngẫu nhiên trong khoảng từ 10000 đến 99999
            Random random = new Random();
            int randomNumber = random.Next(10000, 100000);

            // Chuyển số ngẫu nhiên thành chuỗi và trả về
            return randomNumber.ToString();
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

                string maLuong = GenerateRandomMaLuong();

                // Tạo câu lệnh SQL INSERT với các giá trị từ các điều khiển trên form
                string sqlInsert = "INSERT INTO QLLuong (Maluong, Matxe, Hoten, Thangluong, Namluong, Songaycong, Thuong, Phat, Tongluong) " +
                                   "VALUES (@Maluong, @Matxe, @Hoten, @Thangluong, @Namluong, @Songaycong, @Thuong, @Phat, @Tongluong)";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                {
                    // Thay thế các tham số trong câu lệnh SQL bằng giá trị từ các điều khiển trên form
                    cmd.Parameters.AddWithValue("@Maluong", maLuong);
                    cmd.Parameters.AddWithValue("@Matxe", cbb_matxe.Text);
                    cmd.Parameters.AddWithValue("@Hoten", tb_name.Text);
                    cmd.Parameters.AddWithValue("@Thangluong", cbb_thang.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Namluong", cbb_nam.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Songaycong", tb_ngaycong.Text);
                    cmd.Parameters.AddWithValue("@Thuong", tb_thuong.Text);
                    cmd.Parameters.AddWithValue("@Phat", tb_phat.Text);
                    cmd.Parameters.AddWithValue("@Tongluong", tongluong);

                    // Thực hiện câu lệnh SQL INSERT
                    cmd.ExecuteNonQuery();

                    // Thông báo thành công nếu không có lỗi
                    MessageBox.Show("Dữ liệu đã được thêm vào CSDL thành công!");
                    ((QlyLuong)this.Owner).RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
