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
using OfficeOpenXml.Style;
using OfficeOpenXml;

namespace QuanLy_Taxi
{
    public partial class QLyXe : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLyXe()
        {
            InitializeComponent();
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();
                OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void loaddataxe()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Maxe, Bienxe, Hangxe, Tenxe, Matxe FROM QLXe", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dtgrid_QLXe.DataSource = dt;

                // Ánh xạ tên cột trong DataGridView với tên trường dữ liệu trong DataTable
                dtgrid_QLXe.Columns[0].HeaderText = "Mã Xe";
                dtgrid_QLXe.Columns[1].HeaderText = "Biển số xe";
                //dtgrid_QLXe.Columns[2].HeaderText = "Ảnh xe";
                dtgrid_QLXe.Columns[2].HeaderText = "Hãng xe";
                dtgrid_QLXe.Columns[3].HeaderText = "Tên xe";
                dtgrid_QLXe.Columns[4].HeaderText = "Mã tài xế";

                dtgrid_QLXe.Columns["Maxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLXe.Columns["Bienxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dtgrid_QLXe.Columns["Anhxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLXe.Columns["Hangxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLXe.Columns["Tenxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLXe.Columns["Matxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
            }
        }

        private void btn_xe_them_Click(object sender, EventArgs e)
        {
            QLXe_them_dialog c1 = new QLXe_them_dialog();
            c1.Owner = this;
            c1.ShowDialog();
        }

        private void btn_xe_sua_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dtgrid_QLXe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();

                QLXe_sua_dialog editForm = new QLXe_sua_dialog(maxe);
                editForm.Owner = this;
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void btn_xe_chitiet_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dtgrid_QLXe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();

                QLXe_chitiet_dialog viewForm = new QLXe_chitiet_dialog(maxe);
                viewForm.Owner = this;
                viewForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void QLyXe_Load(object sender, EventArgs e)
        {
            loaddataxe();
        }

        private void btn_xe_xoa_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLXe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất giá trị của trường "Matxe" từ dòng được chọn
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tạo câu lệnh SQL DELETE
                        string sqlDelete = "DELETE FROM QLXe WHERE Maxe = @Maxe";

                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            // Thêm tham số cho trường "Maxe"
                            cmd.Parameters.AddWithValue("@Maxe", maxe);

                            // Thực hiện câu lệnh SQL DELETE
                            cmd.ExecuteNonQuery();

                            // Thông báo thành công nếu không có lỗi
                            //MessageBox.Show("Dữ liệu đã được xóa khỏi CSDL thành công!");
                        }

                        // Refresh DataGridView to reflect the changes
                        RefreshDataGridView();
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }
        public void RefreshDataGridView()
        {
            // Refresh the DataGridView after adding a new record
            loaddataxe();
        }

        private void tb_search_TextChanged(object sender, EventArgs e)
        {
            string connection = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter da1;
            DataTable dt1;
            con.Open();
            da1 = new SqlDataAdapter("SELECT Maxe, Bienxe,Hangxe, Tenxe, Matxe FROM QLXe WHERE Maxe LIKE'%" + this.tb_search.Text + "%' OR Bienxe LIKE '%" + this.tb_search.Text + "%' OR Hangxe LIKE '%" + this.tb_search.Text + "%' OR Matxe LIKE '%" + this.tb_search.Text + "%'", con);
            dt1 = new DataTable();
            da1.Fill(dt1);

            dtgrid_QLXe.DataSource = dt1;
            con.Close();
        }

        private void btn_xuatexcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    // Tạo một bảng tính mới
                    var worksheet = package.Workbook.Worksheets.Add("Thông tin tài xế");

                    // MergeCells từ A1 đến I1 và đặt tên bảng
                    worksheet.Cells["A1:I1"].Merge = true;
                    worksheet.Cells["A1"].Value = "Quản lý thông tin xe";

                    // Định dạng tiêu đề bảng
                    var head = worksheet.Cells["A1:I1"];
                    head.Style.Font.Bold = true;
                    head.Style.Font.Name = "Times New Roman";
                    head.Style.Font.Size = 20;
                    head.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    head.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    // Thêm tiêu đề cho các cột
                    string[] headers = { "Mã xe", "Biển số xe", "Hãng xe", "Tên xe", "Số ghế", "Năm sản xuất", "Số khung", "Mã tài xế", "Tên tài xế" };

                    // Đặt độ rộng của các cột theo ý muốn của bạn
                    int[] columnWidths = { 12, 25, 18, 15, 12, 21, 25, 18, 25 };

                    for (int i = 0; i < headers.Length; i++)
                    {
                        var cell = worksheet.Cells[2, i + 1];
                        cell.Value = headers[i];

                        // Định dạng ô cột
                        cell.Style.Font.Bold = true;
                        cell.Style.Font.Name = "Times New Roman";
                        cell.Style.Font.Size = 16;
                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        // Thêm đường kẻ viền cho ô cột
                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        // Đặt kích thước của các cột
                        worksheet.Column(i + 1).Width = columnWidths[i];
                    }

                    // Lấy dữ liệu từ Database
                    using (SqlConnection connection = new SqlConnection("SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id=sa; pwd=123123"))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("SELECT Maxe, Bienxe, Hangxe, Tenxe, Soghe, Namsx, Sokhung, Matxe, Hoten FROM QLXe", connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                int rowIndex = 3; // Bắt đầu từ dòng 3 để bỏ qua hàng tiêu đề
                                while (reader.Read())
                                {
                                    for (int i = 0; i < headers.Length; i++)
                                    {
                                        var cell = worksheet.Cells[rowIndex, i + 1];
                                        cell.Value = reader[i].ToString(); // Dữ liệu từ cột tương ứng

                                        // Định dạng ô dữ liệu
                                        cell.Style.Font.Name = "Times New Roman";
                                        cell.Style.Font.Size = 14;
                                        cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                        cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                        // Thêm đường kẻ viền cho ô dữ liệu
                                        cell.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                                        cell.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                                        cell.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                                        cell.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                                    }

                                    rowIndex++;
                                }
                            }
                        }
                    }

                    // Lưu file Excel
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                        saveFileDialog.FileName = "Thongtinxe.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            var file = new System.IO.FileInfo(saveFileDialog.FileName);
                            package.SaveAs(file);
                            MessageBox.Show("Xuất Excel thành công!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }
        }
    }
}
