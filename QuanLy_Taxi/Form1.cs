namespace QuanLy_Taxi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void OpenChildForm(Form childform)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childform);
            panel_body.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }


        private void btn_trangchu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new trangchu());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //label_datetime.Text = DateTime.Now.ToLongTimeString();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_datetime.Text = "Thời gian: " + DateTime.Now.ToString("HH:mm:ss") + "  Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            btn_trangchu.Checked = false;
            btn_qltxe.Checked = false;
            btn_qlluong.Checked = false;
            btn_qlxe.Checked = false;
            btn_qlcdi.Checked = false;
            btn_qltkhoan.Checked = false;
            btn_thongke.Checked = false;
        }
    }
}