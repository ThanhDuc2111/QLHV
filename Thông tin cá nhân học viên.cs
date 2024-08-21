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

namespace Nhom5QLHocVienTTTH
{
    public partial class Thông_tin_cá_nhân_học_viên : Form
    {
        private string taikhoan;
        public string TaiKhoan
        {
            get { return taikhoan; }
            set { taikhoan = value; }
        }
        public Thông_tin_cá_nhân_học_viên()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
        }

        

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private void LoadHocVienInfoToTextBoxes(string taiKhoan)
        {
            // Thực hiện truy vấn để lấy thông tin học viên từ cơ sở dữ liệu.
            //// Sử dụng truy vấn SELECT với điều kiện WHERE TaiKhoan = @TaiKhoan.

            //string connectionString = "your_connection_string";
            string query = "SELECT * FROM HocVien WHERE TaiKhoan = @TaiKhoan";

            using (SqlConnection connection = new SqlConnection(@"Data Source= MINHQUOC\SA;Initial Catalog=QLHVTTTH;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Hiển thị thông tin từ cơ sở dữ liệu lên các TextBox.
                            txtID.Text = reader["IDHocVien"].ToString();
                            txtTen.Text = reader["HoTen"].ToString();
                            txtNS.Text = ((DateTime)reader["NgaySinh"]).ToString("dd/MM/yyyy");
                            txtGT.Text = reader["GioiTinh"].ToString();
                            txtMail.Text = reader["Email"].ToString();
                            txtDT.Text = reader["DienThoai"].ToString();
                        }
                        else
                        {
                            // Hiển thị thông báo nếu không tìm thấy thông tin học viên.
                            MessageBox.Show("Không tìm thấy thông tin học viên.");
                        }
                    }

                }
                string getIdHocVienQuery = "SELECT IDHocVien FROM HocVien WHERE TaiKhoan = @TaiKhoan";
                string idHocVien = ""; // Change the data type to string

                using (SqlCommand getIdHocVienCommand = new SqlCommand(getIdHocVienQuery, connection))
                {
                    getIdHocVienCommand.Parameters.AddWithValue("@TaiKhoan", taiKhoan);

                    using (SqlDataReader idHocVienReader = getIdHocVienCommand.ExecuteReader())
                    {
                        if (idHocVienReader.Read())
                        {
                            idHocVien = idHocVienReader["IDHocVien"].ToString(); // Convert to string
                        }
                    }
                }

                // Bước 2: Lấy thông tin khóa học từ bảng KhoaHoc dựa vào IDHocVien
                string khoaHocQuery = "SELECT KhoaHoc.TenKhoaHoc, KhoaHoc.Description FROM KhoaHoc " +
                                      "JOIN DangKiKhoaHoc ON KhoaHoc.IDKhoaHoc = DangKiKhoaHoc.IDKhoaHoc " +
                                      "WHERE DangKiKhoaHoc.IDHocVien = @IDHocVien";

                using (SqlCommand khoaHocCommand = new SqlCommand(khoaHocQuery, connection))
                {
                    khoaHocCommand.Parameters.AddWithValue("@IDHocVien", idHocVien);

                    using (SqlDataReader khoaHocReader = khoaHocCommand.ExecuteReader())
                    {
                        if (khoaHocReader.Read())
                        {
                            // Bước 3: Hiển thị thông tin khóa học lên text box
                            txtKH.Text = khoaHocReader["TenKhoaHoc"].ToString();
                        }
                    }
                }
                //Lấy thông tin lịch học từ bảng LichHoc dựa vào IDHocVien
                string lichHocQuery = "SELECT LichHoc.DayOfWeek, LichHoc.ThoiGianBD, LichHoc.ThoiGianKT FROM LichHoc " +
                                  "JOIN KhoaHoc ON LichHoc.IDKhoaHoc = KhoaHoc.IDKhoaHoc " +
                                  "JOIN DangKiKhoaHoc ON KhoaHoc.IDKhoaHoc = DangKiKhoaHoc.IDKhoaHoc " +
                                  "WHERE DangKiKhoaHoc.IDHocVien = @IDHocVien";

                using (SqlCommand lichHocCommand = new SqlCommand(lichHocQuery, connection))
                {
                    lichHocCommand.Parameters.AddWithValue("@IDHocVien", idHocVien);

                    using (SqlDataReader lichHocReader = lichHocCommand.ExecuteReader())
                    {
                        //  Hiển thị thông tin lịch học lên text box
                        while (lichHocReader.Read())
                        {
                            string thoiGianBD = lichHocReader["ThoiGianBD"].ToString();
                            string thoiGianKT = lichHocReader["ThoiGianKT"].ToString();

                            // Assuming you have text boxes named dayOfWeekTextBox, thoiGianBDTextBox, thoiGianKTTextBox
                            txtTGBD.Text += thoiGianBD + Environment.NewLine;
                            txtTGKT.Text += thoiGianKT + Environment.NewLine;
                        }
                    }
                }
                string diemQuery = "SELECT Diem.NgayThi, Diem.DiemThi FROM Diem " +
                   "WHERE Diem.IDHocVien = @IDHocVien";

                using (SqlCommand diemCommand = new SqlCommand(diemQuery, connection))
                {
                    diemCommand.Parameters.AddWithValue("@IDHocVien", idHocVien);

                    using (SqlDataReader diemReader = diemCommand.ExecuteReader())
                    {
                        // Bước 3: Hiển thị thông tin điểm lên text box
                        while (diemReader.Read())
                        {
                            string ngayThi = diemReader["NgayThi"].ToString();
                            string diemThi = diemReader["DiemThi"].ToString();

                            // Assuming you have text boxes named ngayThiTextBox, diemThiTextBox
                            txtNgaythi.Text += ngayThi + Environment.NewLine;
                            txtDiem.Text += diemThi + Environment.NewLine;
                        }
                    }
                }
            }

            
            

        }
        private void Thông_tin_cá_nhân_học_viên_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            label5.BackColor = System.Drawing.Color.Transparent;
            label6.BackColor = System.Drawing.Color.Transparent;
            label7.BackColor = System.Drawing.Color.Transparent;
            label8.BackColor = System.Drawing.Color.Transparent;
            label9.BackColor = System.Drawing.Color.Transparent;
            label10.BackColor = System.Drawing.Color.Transparent;
            label11.BackColor = System.Drawing.Color.Transparent;
            label12.BackColor = System.Drawing.Color.Transparent;
            LoadHocVienInfoToTextBoxes(TaiKhoan);
        }

        

       

        private void Thông_tin_cá_nhân_học_viên_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát!!!!!!!!!", "Thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
