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
    public partial class QLXe_chitiet_dialog : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLXe_chitiet_dialog(string maxe)
        {
            InitializeComponent();
            tb_bienxe.Enabled = false;
            tb_maxe.Enabled = false;
            tb_hangxe.Enabled = false;
            tb_tenxe.Enabled = false;
            tb_soghe.Enabled = false;
            tb_namsx.Enabled = false;
            tb_sokhung.Enabled = false;
            tb_matxe.Enabled = false;
            tb_name.Enabled = false;
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Lấy dữ liệu từ SQL và đặt nó trong các ô văn bản
            SetDataFromSQL(maxe);
        }

        private void SetDataFromSQL(string maxe)
        {
            try
            {
                // Sử dụng SqlCommand để lấy dữ liệu từ SQL dựa trên Maxe
                SqlCommand cmd = new SqlCommand("SELECT * FROM QLXe WHERE Maxe = @Maxe", conn);
                cmd.Parameters.AddWithValue("@Maxe", maxe);

                SqlDataReader reader = cmd.ExecuteReader();

                // Nếu có dữ liệu, đặt giá trị trong các ô văn bản
                if (reader.Read())
                {
                    tb_maxe.Text = reader["Maxe"].ToString();
                    tb_bienxe.Text = reader["Bienxe"].ToString();
                    tb_hangxe.Text = reader["Hangxe"].ToString();
                    tb_tenxe.Text = reader["Tenxe"].ToString();
                    tb_matxe.Text = reader["Matxe"].ToString();
                    tb_soghe.Text = reader["Soghe"].ToString();
                    tb_namsx.Text = reader["Namsx"].ToString();
                    tb_sokhung.Text = reader["Sokhung"].ToString();
                    tb_name.Text = reader["Hoten"].ToString();
                    string linkanh1 = reader["Linkanh"].ToString();

                    // Hiển thị hình ảnh từ đường dẫn
                    if (!string.IsNullOrEmpty(linkanh1))
                    {
                        pbx_anhxe.Image = Image.FromFile(linkanh1);
                    }
                    else
                    {
                        // Xử lý trường hợp không có đường dẫn ảnh
                        pbx_anhxe.Image = null; // hoặc đặt một hình ảnh mặc định khác
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ CSDL: " + ex.Message);
            }
        }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
