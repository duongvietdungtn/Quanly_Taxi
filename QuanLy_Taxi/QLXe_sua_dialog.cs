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
    public partial class QLXe_sua_dialog : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLXe_sua_dialog()
        {
            InitializeComponent();
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Phương thức để thiết lập dữ liệu trong form
        public void SetData(string maxe, string bienxe, string hangxe, string tenxe, string soghe, string namsx, string sokhung, string matxe, string hoten)
        {
            tb_maxe.Text = maxe;
            tb_bienxe.Text = bienxe;
            tb_hangxe.Text = hangxe;
            tb_tenxe.Text = tenxe;
            tb_soghe.Text = soghe;
            tb_namsx.Text = namsx;
            tb_sokhung.Text = sokhung;
            tb_matxe.Text = matxe;
            tb_name.Text = hoten;
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
            //try
            //{
            //    // Tạo câu lệnh SQL UPDATE với các giá trị từ các điều khiển trên form
            //    string sqlUpdate = "UPDATE QLXe SET Matxe = @Matxe, Hoten = @Name, Ngaysinh = @Ngaysinh, Gioitinh = @Gioitinh, " +
            //                       "Diachi = @Diachi, Sdt = @Sdt, Maxe =@Maxe WHERE Matxe = @Matxe";

            //    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
            //    {
            //        // Thay thế các tham số trong câu lệnh SQL bằng giá trị từ các điều khiển trên form
            //        cmd.Parameters.AddWithValue("@Matxe", tb_matx.Text);
            //        cmd.Parameters.AddWithValue("@Name", tb_name.Text);
            //        cmd.Parameters.AddWithValue("@Ngaysinh", dtpk_ngaysinh.Value);
            //        cmd.Parameters.AddWithValue("@Gioitinh", cbb_gioitinh.SelectedItem.ToString());
            //        cmd.Parameters.AddWithValue("@Diachi", tb_dchi.Text);
            //        cmd.Parameters.AddWithValue("@Sdt", tb_sdt.Text);
            //        cmd.Parameters.AddWithValue("@Maxe", tb_maxe.Text);

            //        // Thực hiện câu lệnh SQL UPDATE
            //        cmd.ExecuteNonQuery();

            //        // Thông báo thành công nếu không có lỗi
            //        MessageBox.Show("Dữ liệu đã được cập nhật vào CSDL thành công!");
            //        ((QLyTaixe)this.Owner).RefreshDataGridView();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Hiển thị thông báo lỗi nếu có lỗi xảy ra
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}            //try
            //{
            //    // Tạo câu lệnh SQL UPDATE với các giá trị từ các điều khiển trên form
            //    string sqlUpdate = "UPDATE QLXe SET Matxe = @Matxe, Hoten = @Name, Ngaysinh = @Ngaysinh, Gioitinh = @Gioitinh, " +
            //                       "Diachi = @Diachi, Sdt = @Sdt, Maxe =@Maxe WHERE Matxe = @Matxe";

            //    using (SqlCommand cmd = new SqlCommand(sqlUpdate, conn))
            //    {
            //        // Thay thế các tham số trong câu lệnh SQL bằng giá trị từ các điều khiển trên form
            //        cmd.Parameters.AddWithValue("@Matxe", tb_matx.Text);
            //        cmd.Parameters.AddWithValue("@Name", tb_name.Text);
            //        cmd.Parameters.AddWithValue("@Ngaysinh", dtpk_ngaysinh.Value);
            //        cmd.Parameters.AddWithValue("@Gioitinh", cbb_gioitinh.SelectedItem.ToString());
            //        cmd.Parameters.AddWithValue("@Diachi", tb_dchi.Text);
            //        cmd.Parameters.AddWithValue("@Sdt", tb_sdt.Text);
            //        cmd.Parameters.AddWithValue("@Maxe", tb_maxe.Text);

            //        // Thực hiện câu lệnh SQL UPDATE
            //        cmd.ExecuteNonQuery();

            //        // Thông báo thành công nếu không có lỗi
            //        MessageBox.Show("Dữ liệu đã được cập nhật vào CSDL thành công!");
            //        ((QLyTaixe)this.Owner).RefreshDataGridView();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Hiển thị thông báo lỗi nếu có lỗi xảy ra
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}
        }
    }
}
