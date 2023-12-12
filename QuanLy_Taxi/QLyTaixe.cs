using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace QuanLy_Taxi
{
    public partial class QLyTaixe : Form
    {
        SqlConnection conn = null;
        string strConn = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
        public QLyTaixe()
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
        public void loaddatagrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Matxe, Hoten, AnhColumn, Ngaysinh, Gioitinh, Diachi, Sdt, Maxe, Linkanh FROM QLTxe", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dt.Columns.Add("Matxe", typeof(string));
                dt.Columns.Add("Hoten", typeof(string));
                dt.Columns.Add("AnhColumn", typeof(byte[])); // Đổi kiểu thành byte[] cho dữ liệu hình ảnh
                da.Fill(dt);

                dtgrid_QLTxe.DataSource = dt;

                // Add this line to create a DataGridViewImageColumn
                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();

                //dtgrid_QLTxe.Columns.Add(imageColumn); //Thừa thêm cột ảnh

                // Giả sử "AnhTxe" là chỉ mục của cột đường dẫn hình ảnh trong DataTable của bạn
                int anhTxeIndex = dt.Columns.IndexOf("Linkanh");

                foreach (DataGridViewRow row in dtgrid_QLTxe.Rows)
                {
                    string duongDanHinhAnh = row.Cells[anhTxeIndex].Value.ToString();

                    // Kiểm tra xem tệp có tồn tại trước khi đặt hình ảnh
                    if (System.IO.File.Exists(duongDanHinhAnh))
                    {
                        byte[] imageData = File.ReadAllBytes(duongDanHinhAnh);
                        row.Cells["AnhColumn"].Value = imageData;
                    }
                    else
                    {
                        // Xử lý trường hợp tệp không tồn tại (tùy chọn)
                        // Bạn có thể đặt một hình ảnh mặc định hoặc để trống
                    }
                }
                dtgrid_QLTxe.CellFormatting += dtgrid_QLTxe_CellFormatting;
                // Ánh xạ tên cột trong DataGridView với tên trường dữ liệu trong DataTable
                dtgrid_QLTxe.Columns[0].HeaderText = "Mã tài xế";
                dtgrid_QLTxe.Columns[1].HeaderText = "Họ và tên";
                dtgrid_QLTxe.Columns[2].HeaderText = "Ảnh";
                dtgrid_QLTxe.Columns[3].HeaderText = "Ngày sinh";
                dtgrid_QLTxe.Columns[4].HeaderText = "Giới tính";
                dtgrid_QLTxe.Columns[5].HeaderText = "Địa chỉ";
                dtgrid_QLTxe.Columns[6].HeaderText = "Số điện thoại";
                dtgrid_QLTxe.Columns[7].HeaderText = "Mã xe";
                dtgrid_QLTxe.Columns["Linkanh"].Visible = false;

                dtgrid_QLTxe.Columns["Matxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLTxe.Columns["AnhColumn"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLTxe.Columns["Ngaysinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLTxe.Columns["Gioitinh"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLTxe.Columns["Diachi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLTxe.Columns["Sdt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgrid_QLTxe.Columns["Maxe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ CSDL: " + ex.Message);
            }
        }
        private void btn_txe_them_Click(object sender, EventArgs e)
        {
            QLTX_them_dialog a1 = new QLTX_them_dialog();
            a1.Owner = this;
            a1.ShowDialog();
        }

        private void btn_txe_sua_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLTxe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất dữ liệu từ dòng được chọn
                string matxe = selectedRow.Cells["Matxe"].Value.ToString();
                string hoten = selectedRow.Cells["Hoten"].Value.ToString();
                DateTime ngaysinh = Convert.ToDateTime(selectedRow.Cells["Ngaysinh"].Value);
                string gioitinh = selectedRow.Cells["Gioitinh"].Value.ToString();
                string diachi = selectedRow.Cells["Diachi"].Value.ToString();
                string sdt = selectedRow.Cells["Sdt"].Value.ToString();
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();
                string linkanh = selectedRow.Cells["Linkanh"].Value.ToString(); // Assume the column name is "Linkanh"

                // Mở form sửa và truyền dữ liệu
                QLTX_sua_dialog editForm = new QLTX_sua_dialog();
                editForm.SetData(matxe, hoten, linkanh, ngaysinh, gioitinh, diachi, sdt, maxe);

                // Load and display the image in the PictureBox
                if (System.IO.File.Exists(linkanh))
                {
                    Image hinhAnh = Image.FromFile(linkanh);
                    editForm.SetImage(hinhAnh);
                }

                editForm.Owner = this;
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để chỉnh sửa.");
            }
        }

        private void btn_txe_chitiet_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLTxe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất dữ liệu từ dòng được chọn
                string matxe = selectedRow.Cells["Matxe"].Value.ToString();
                string hoten = selectedRow.Cells["Hoten"].Value.ToString();
                DateTime ngaysinh = Convert.ToDateTime(selectedRow.Cells["Ngaysinh"].Value);
                string gioitinh = selectedRow.Cells["Gioitinh"].Value.ToString();
                string diachi = selectedRow.Cells["Diachi"].Value.ToString();
                string sdt = selectedRow.Cells["Sdt"].Value.ToString();
                string maxe = selectedRow.Cells["Maxe"].Value.ToString();
                string linkanh = selectedRow.Cells["Linkanh"].Value.ToString();

                // Mở form sửa và truyền dữ liệu
                QLTX_chitiet_dialog viewForm = new QLTX_chitiet_dialog();
                viewForm.SetData(matxe, hoten, ngaysinh, gioitinh, diachi, sdt, maxe);
                // Load and display the image in the PictureBox
                if (System.IO.File.Exists(linkanh))
                {
                    Image hinhAnh = Image.FromFile(linkanh);
                    viewForm.SetImage(hinhAnh);
                }
                viewForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xem thông tin.");
            }
        }
        private void QLyTaixe_Load(object sender, EventArgs e)
        {
            loaddatagrid();
        }
        private void tb_searchtxe_TextChanged(object sender, EventArgs e)
        {
            string connection = "SERVER=DUG_PC\\SQLEXPRESS02; Database=CSDL_QLTaxi; User Id = sa; pwd=123123";
            SqlConnection con = new SqlConnection(connection);
            SqlDataAdapter da1;
            DataTable dt1;
            con.Open();
            da1 = new SqlDataAdapter("SELECT * FROM QLTxe WHERE Matxe LIKE '%" + this.tb_searchtxe.Text + "%' OR Diachi LIKE '%" + this.tb_searchtxe.Text + "%' OR Sdt LIKE '%" + this.tb_searchtxe.Text + "%' OR Maxe LIKE '%" + this.tb_searchtxe.Text + "%'", con);
            dt1 = new DataTable();
            da1.Fill(dt1);

            // Tạo cột ảnh mới cho DataTable dt1
            DataColumn imageColumn = new DataColumn("AnhColumn", typeof(byte[]));

            // Lấy chỉ mục của cột đường dẫn hình ảnh trong DataTable của bạn
            int anhTxeIndex = dt1.Columns.IndexOf("Linkanh");

            foreach (DataRow row in dt1.Rows)
            {
                string duongDanHinhAnh = row["Linkanh"].ToString();

                // Kiểm tra xem tệp có tồn tại trước khi đặt hình ảnh
                if (System.IO.File.Exists(duongDanHinhAnh))
                {
                    byte[] imageData = File.ReadAllBytes(duongDanHinhAnh);
                    row["AnhColumn"] = imageData;
                }
                else
                {
                    // Xử lý trường hợp tệp không tồn tại (tùy chọn)
                    // Bạn có thể đặt một hình ảnh mặc định hoặc để trống
                }
            }

            dtgrid_QLTxe.DataSource = dt1;
            con.Close();
        }

        private void btn_txe_xoa_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn từ DataGridView
            DataGridViewRow selectedRow = dtgrid_QLTxe.SelectedRows.Cast<DataGridViewRow>().FirstOrDefault();

            if (selectedRow != null)
            {
                // Trích xuất giá trị của trường "Matxe" từ dòng được chọn
                string matxe = selectedRow.Cells["Matxe"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Tạo câu lệnh SQL DELETE
                        string sqlDelete = "DELETE FROM QLTxe WHERE Matxe = @Matxe";

                        using (SqlCommand cmd = new SqlCommand(sqlDelete, conn))
                        {
                            // Thêm tham số cho trường "Matxe"
                            cmd.Parameters.AddWithValue("@Matxe", matxe);

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
            loaddatagrid();
        }

        private void dtgrid_QLTxe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dtgrid_QLTxe.Columns[e.ColumnIndex].Name == "AnhColumn" && e.Value != null && e.Value != DBNull.Value)
            {
                try
                {
                    byte[] imageData = (byte[])e.Value;

                    // Chuyển đổi mảng byte thành hình ảnh
                    Image originalImage = ByteArrayToImage(imageData);

                    // Thiết lập kích thước tối đa cho hình ảnh
                    int maxImageWidth = 100; // Thay đổi kích thước tùy thuộc vào yêu cầu của bạn
                    int maxImageHeight = 100; // Thay đổi kích thước tùy thuộc vào yêu cầu của bạn

                    // Tạo một bản sao của hình ảnh để thay đổi kích thước
                    Image resizedImage = ResizeImage(originalImage, maxImageWidth, maxImageHeight);

                    e.Value = resizedImage;
                }
                catch (Exception ex)
                {
                    //// Xử lý nếu có lỗi khi chuyển đổi dữ liệu
                    //MessageBox.Show("Lỗi khi chuyển đổi dữ liệu hình ảnh: " + ex.Message);
                }
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }


        private Image ResizeImage(Image image, int maxWidth, int maxHeight)
        {
            // Tính toán tỉ lệ thu nhỏ
            double ratioX = (double)maxWidth / image.Width;
            double ratioY = (double)maxHeight / image.Height;
            double ratio = Math.Min(ratioX, ratioY);

            // Tính toán kích thước mới
            int newWidth = (int)(image.Width * ratio);
            int newHeight = (int)(image.Height * ratio);

            // Tạo một Bitmap mới với kích thước mới
            Bitmap newImage = new Bitmap(newWidth, newHeight);

            // Sử dụng Graphics để vẽ hình ảnh thu nhỏ vào Bitmap mới
            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        private void btn_xuatexcel_Click(object sender, EventArgs e)
        {
            try
            {
                using (var package = new ExcelPackage())
                {
                    // Tạo một bảng tính mới
                    var worksheet = package.Workbook.Worksheets.Add("Thông tin tài xế");

                    // MergeCells từ A1 đến G1 và đặt tên bảng
                    worksheet.Cells["A1:G1"].Merge = true;
                    worksheet.Cells["A1"].Value = "Thông tin tài xế";

                    // Định dạng tiêu đề bảng
                    var head = worksheet.Cells["A1:G1"];
                    head.Style.Font.Bold = true;
                    head.Style.Font.Name = "Times New Roman";
                    head.Style.Font.Size = 20;
                    head.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    head.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                    // Thêm tiêu đề cho các cột
                    string[] headers = { "Mã tài xế", "Họ tên", "Ngày Sinh", "Giới tính", "Địa chỉ", "Số điện thoại", "Mã xe" };

                    // Đặt độ rộng của các cột theo ý muốn của bạn
                    int[] columnWidths = { 15, 25, 18, 15, 23, 22, 12 };

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

                    // Lấy dữ liệu từ DataGridView
                    for (int i = 0; i < dtgrid_QLTxe.Rows.Count; i++)
                    {
                        // Chỉ lấy các cột cần xuất
                        string[] rowData = {
                    dtgrid_QLTxe.Rows[i].Cells["Matxe"].Value.ToString(),
                    dtgrid_QLTxe.Rows[i].Cells["Hoten"].Value.ToString(),
                    Convert.ToDateTime(dtgrid_QLTxe.Rows[i].Cells["Ngaysinh"].Value).ToShortDateString(),
                    dtgrid_QLTxe.Rows[i].Cells["Gioitinh"].Value.ToString(),
                    dtgrid_QLTxe.Rows[i].Cells["Diachi"].Value.ToString(),
                    dtgrid_QLTxe.Rows[i].Cells["Sdt"].Value.ToString(),
                    dtgrid_QLTxe.Rows[i].Cells["Maxe"].Value.ToString()
                };

                        // Ghi dữ liệu vào Excel
                        for (int j = 0; j < rowData.Length; j++)
                        {
                            var cell = worksheet.Cells[i + 3, j + 1];
                            cell.Value = rowData[j];

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
                    }

                    // Lưu file Excel
                    using (var saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                        saveFileDialog.FileName = "ThongTinTaiXe.xlsx";

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