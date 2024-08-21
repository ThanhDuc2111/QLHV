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

namespace Nhom5QLHocVienTTTH
{
    public partial class DangKy : Form
    {
        public DangKy()
        {
            InitializeComponent();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.ShowDialog();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            string newUsername = txtnewtk.Text;
            string newPassword = txtnewmk.Text;
            string confirmPassword = txtmkm.Text;
            string email = txtEmail.Text;

            if (IsValidRegistrationData(newUsername, newPassword, confirmPassword, email))
            {
                DBConnect db = new DBConnect(); // Assuming your DBConnect class has a default constructor

                if (RegisterNewUser(db, newUsername, newPassword, email))
                {
                    MessageBox.Show("Đăng ký thành công!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đăng ký không thành công. Thử lại sau.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản, mật khẩu, xác nhận mật khẩu, và email hợp lệ.");
            }
        }

        private bool IsValidRegistrationData(string username, string password, string confirmPassword, string email)
        {
            return !string.IsNullOrWhiteSpace(username) &&
                   !string.IsNullOrWhiteSpace(password) &&
                   !string.IsNullOrWhiteSpace(confirmPassword) &&
                   !string.IsNullOrWhiteSpace(email) &&
                   password == confirmPassword;
        }

        private bool RegisterNewUser(DBConnect db, string username, string password, string email)
        {
            try
            {
                db.OpenConnection();

                string str = "INSERT INTO NguoiDung (TaiKhoan, MatKhau, Email) VALUES ('" + username + "', '" + password + "', '" + email + "')";

                using (SqlCommand cmd = new SqlCommand(str, db.Connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi Kết Nối SQL: " + ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định: " + ex.Message);
                return false;
            }

        }
    }

}
