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
    public partial class QLXe_them_dialog : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLXe_them_dialog()
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

        private string GetHotenByMatxe(string matxe)
        {
            string hoten = string.Empty;
            try
            {
                // Thực hiện truy vấn để lấy Hoten từ bảng QLTxe theo Matxe
                string query = "SELECT Hoten FROM QLTxe WHERE Matxe = @Matxe";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Matxe", matxe);
                SqlDataReader reader = cmd.ExecuteReader();

                // Đọc giá trị Hoten từ SqlDataReader
                if (reader.Read())
                {
                    hoten = reader["Hoten"].ToString();
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
                string hoten = GetHotenByMatxe(selectedMatxe);
                tb_name.Text = hoten;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tên từ QLTxe: " + ex.Message);
            }
        }

        private void btn_upanh_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Hiển thị hình ảnh trên PictureBox
                pbx_anhxe.Image = Image.FromFile(openFileDialog1.FileName);

                // Lưu đường dẫn của hình ảnh vào TextBox hoặc biến khác (tùy thuộc vào cách bạn muốn sử dụng)
                tb_link.Text = openFileDialog1.FileName;
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
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                // Lấy tên tệp ảnh từ đường dẫn đã chọn
                string imagePath = openFileDialog1.FileName;
                string imageFileName = $"image_{timestamp}.jpg"; // Thay đổi phần mở rộng tệp tùy thuộc vào loại tệp của bạn

                // Kết hợp đường dẫn và tên tệp mới
                string newImagePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(imagePath), imageFileName);

                // Lưu ảnh với tên tệp mới
                System.IO.File.Copy(imagePath, newImagePath);
                // Tạo câu lệnh SQL INSERT với các giá trị từ các điều khiển trên form
                string sqlInsert = "INSERT INTO QLXe (Maxe, Bienxe,Linkanh, Hangxe, Tenxe, Soghe, Namsx, Sokhung, Matxe, Hoten) " +
                                   "VALUES (@Maxe, @Bienxe, @Linkanh, @Hangxe, @Tenxe, @Soghe, @Namsx, @Sokhung, @Matxe, @Hoten)";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                {
                    // Thay thế các tham số trong câu lệnh SQL bằng giá trị từ các điều khiển trên form
                    cmd.Parameters.AddWithValue("@Maxe", tb_maxe.Text);
                    cmd.Parameters.AddWithValue("@Bienxe", tb_bienxe.Text);
                    cmd.Parameters.AddWithValue("@Linkanh", newImagePath);
                    cmd.Parameters.AddWithValue("@Hangxe", tb_hangxe.Text);
                    cmd.Parameters.AddWithValue("@Tenxe", tb_tenxe.Text);
                    cmd.Parameters.AddWithValue("@Soghe", tb_soghe.Text);
                    cmd.Parameters.AddWithValue("@Namsx", tb_namsx.Text);
                    cmd.Parameters.AddWithValue("@Sokhung", tb_sokhung.Text);
                    cmd.Parameters.AddWithValue("@Matxe", cbb_matxe.Text);
                    cmd.Parameters.AddWithValue("@Hoten", tb_name.Text);

                    // Thực hiện câu lệnh SQL INSERT
                    cmd.ExecuteNonQuery();

                    // Thông báo thành công nếu không có lỗi
                    MessageBox.Show("Dữ liệu đã được thêm vào CSDL thành công!");
                    ((QLyXe)this.Owner).RefreshDataGridView();
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
