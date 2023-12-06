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

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_upanh_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                pbx_anhxe.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbx_anhtx_Click(object sender, EventArgs e)
        {

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo câu lệnh SQL INSERT với các giá trị từ các điều khiển trên form
                string sqlInsert = "INSERT INTO QLXe (Maxe, Bienxe, Hangxe, Tenxe, Soghe, Namsx, Sokhung, Matxe, Hoten) " +
                                   "VALUES (@Maxe, @Bienxe, @Hangxe, @Tenxe, @Soghe, @Namsx, @Sokhung, @Matxe, @Hoten)";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                {
                    // Thay thế các tham số trong câu lệnh SQL bằng giá trị từ các điều khiển trên form
                    cmd.Parameters.AddWithValue("@Maxe", tb_maxe.Text);
                    cmd.Parameters.AddWithValue("@Bienxe", tb_bienxe.Text);
                    cmd.Parameters.AddWithValue("@Hangxe", tb_hangxe.Text);
                    cmd.Parameters.AddWithValue("@Tenxe", tb_tenxe.Text);
                    cmd.Parameters.AddWithValue("@Soghe", tb_soghe.Text);
                    cmd.Parameters.AddWithValue("@Namsx", tb_namsx.Text);
                    cmd.Parameters.AddWithValue("@Sokhung", tb_sokhung.Text);
                    cmd.Parameters.AddWithValue("@Matxe", tb_matxe.Text);
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
