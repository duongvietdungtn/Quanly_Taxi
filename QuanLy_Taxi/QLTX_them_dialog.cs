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
                // Tạo câu lệnh SQL INSERT với các giá trị từ các điều khiển trên form
                string sqlInsert = "INSERT INTO QLTxe (Matxe, Hoten, Ngaysinh, Gioitinh, Diachi, Sdt) " +
                                   "VALUES (@Matxe, @Name, @Ngaysinh, @Gioitinh, @Diachi, @Sdt)";

                using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
                {
                    // Thay thế các tham số trong câu lệnh SQL bằng giá trị từ các điều khiển trên form
                    cmd.Parameters.AddWithValue("@Matxe", tb_matx.Text);
                    cmd.Parameters.AddWithValue("@Name", tb_name.Text);
                    cmd.Parameters.AddWithValue("@Ngaysinh", dtpk_ngaysinh.Value);
                    cmd.Parameters.AddWithValue("@Gioitinh", cbb_gioitinh.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Diachi", tb_dchi.Text);
                    cmd.Parameters.AddWithValue("@Sdt", tb_sdt.Text);

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
