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
    public partial class QLTX_them_dialog : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLTX_them_dialog()
        {
            InitializeComponent();
            // Thêm lựa chọn cho ComboBox gioitinh
            cbb_gioitinh.Items.Add("Nam");
            cbb_gioitinh.Items.Add("Nữ");
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
                string sqlInsert = "INSERT INTO QLTxe (Matxe, Hoten, Linkanh, Ngaysinh, Gioitinh, Diachi, Sdt, Maxe) " +
                                   "VALUES (@Matxe, @Name, @Linkanh, @Ngaysinh, @Gioitinh, @Diachi, @Sdt, @Maxe)";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
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

                    // Thực hiện câu lệnh SQL INSERT
                    cmd.ExecuteNonQuery();

                    // Thông báo thành công nếu không có lỗi
                    MessageBox.Show("Dữ liệu đã được thêm vào CSDL thành công!");
                    ((QLyTaixe)this.Owner).RefreshDataGridView();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void cbb_gioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
