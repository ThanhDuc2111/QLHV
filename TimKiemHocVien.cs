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
    public partial class TimKiemHocVien : Form
    {
        public TimKiemHocVien()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string idhv = txtID.Text;
            string tenHocVien = txtTenHocVien.Text; // Assuming txtTenHocVien is your TextBox for the name search

            DBConnect db = new DBConnect();

            try
            {
                db.OpenConnection();

                string query = @"SELECT HocVien.IDHocVien, HocVien.HoTen, HocVien.NgaySinh, 
                       HocVien.GioiTinh, HocVien.Email, HocVien.DienThoai, 
                       KhoaHoc.TenKhoaHoc, LichHoc.DayOfWeek, LichHoc.ThoiGianBD, LichHoc.ThoiGianKT 
                       FROM HocVien 
                       JOIN LichHoc ON HocVien.IDHocVien = LichHoc.IDHocVien 
                       JOIN KhoaHoc ON LichHoc.IDKhoaHoc = KhoaHoc.IDKhoaHoc 
                       WHERE (HocVien.IDHocVien = @IDHocVien OR @IDHocVien IS NULL)
                       AND (HocVien.HoTen LIKE @TenHocVien OR @TenHocVien IS NULL)";

                using (SqlCommand command = new SqlCommand(query, db.Connection))
                {
                    command.Parameters.AddWithValue("@IDHocVien", idhv);
                    command.Parameters.AddWithValue("@TenHocVien", string.IsNullOrEmpty(tenHocVien) ? (object)DBNull.Value : "%" + tenHocVien + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dtTimKiem.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy học viên có ID là " + idhv + " và tên là " + tenHocVien);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }


        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TimKiemHocVien_Load(object sender, EventArgs e)
        {

        }

        
    }
}
