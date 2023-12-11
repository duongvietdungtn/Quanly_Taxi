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
    public partial class QLTX_sua_dialog : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLTX_sua_dialog()
        {
            InitializeComponent();
            cbb_gioitinh.Items.Add("Nam");
            cbb_gioitinh.Items.Add("Nữ");
            tb_matx.Enabled = false;

            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
                LoadMaxeData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadMaxeData()
        {
            try
            {
                // Thực hiện truy vấn để lấy danh sách giá trị từ cột Matxe của bảng QLTxe
                string query = "SELECT Maxe FROM QLXe";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Đọc từng giá trị và thêm vào ComboBox cbb_matxe
                while (reader.Read())
                {
                    cbb_Maxe.Items.Add(reader["Maxe"].ToString());
                }

                // Đóng đối tượng SqlDataReader
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu cho ComboBox Maxe: " + ex.Message);
            }
        }

        public void SetImage(Image image)
        {
            pbx_anhtx.Image = image;
        }

        private void btn_upanh_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Hiển thị hình ảnh trên PictureBox
                pbx_anhtx.Image = Image.FromFile(openFileDialog1.FileName);

                // Lưu đường dẫn của hình ảnh vào TextBox hoặc biến khác (tùy thuộc vào cách bạn muốn sử dụng)
                tb_link.Text = openFileDialog1.FileName;
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Phương thức để thiết lập dữ liệu trong form
        public void SetData(string matxe, string hoten, string link, DateTime ngaysinh, string gioitinh, string diachi, string sdt, string maxe)
        {
            tb_matx.Text = matxe;
            tb_name.Text = hoten;
            tb_link.Text = link;
            dtpk_ngaysinh.Value = ngaysinh;
            cbb_gioitinh.Text = gioitinh;
            tb_dchi.Text = diachi;
            tb_sdt.Text = sdt;
            cbb_Maxe.Text = maxe;
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");

                // Lấy tên tệp ảnh từ đường dẫn đã chọn
                string imagePath = tb_link.Text;
                string imageFileName = $"image_{timestamp}.jpg"; // Thay đổi phần mở rộng tệp tùy thuộc vào loại tệp của bạn

                // Kết hợp đường dẫn và tên tệp mới
                string newImagePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(imagePath), imageFileName);

                // Lưu ảnh với tên tệp mới
                System.IO.File.Copy(imagePath, newImagePath);

                // Tạo câu lệnh SQL UPDATE với các giá trị từ các điều khiển trên form
                string sqlUpdate = "UPDATE QLTxe SET Matxe = @Matxe, Hoten = @Name, Linkanh = @Linkanh, Ngaysinh = @Ngaysinh, Gioitinh = @Gioitinh, " +
                                   "Diachi = @Diachi, Sdt = @Sdt, Maxe =@Maxe WHERE Matxe = @Matxe";

                using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
                {
                    // Thay thế các tham số trong câu lệnh SQL bằng giá trị từ các điều khiển trên form
                    cmd.Parameters.AddWithValue("@Matxe", tb_matx.Text);
                    cmd.Parameters.AddWithValue("@Name", tb_name.Text);
                    cmd.Parameters.AddWithValue("@Linkanh", newImagePath);
                    cmd.Parameters.AddWithValue("@Ngaysinh", dtpk_ngaysinh.Value);
                    cmd.Parameters.AddWithValue("@Gioitinh", cbb_gioitinh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Diachi", tb_dchi.Text);
                    cmd.Parameters.AddWithValue("@Sdt", tb_sdt.Text);
                    cmd.Parameters.AddWithValue("@Maxe", cbb_Maxe.Text);

                    // Thực hiện câu lệnh SQL UPDATE
                    cmd.ExecuteNonQuery();

                    // Thông báo thành công nếu không có lỗi
                    MessageBox.Show("Dữ liệu đã được cập nhật vào CSDL thành công!");
                    ((QLyTaixe)this.Owner).RefreshDataGridView();
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
