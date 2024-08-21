using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nhom5QLHocVienTTTH
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void quanLyHocVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyHocVien ql = new QuanLyHocVien();
            ql.ShowDialog();
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            DangNhap DN = new DangNhap();
            DN.ShowDialog();
            this.Hide();
        }

        private void btnDX_Click(object sender, EventArgs e)
        {
            DangNhap DN = new DangNhap();
            DN.ShowDialog();
            this.Close();
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void timKiemHocVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemHocVien tk = new TimKiemHocVien();
            tk.ShowDialog();
        }

        private void thongTinHocVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thông_tin_cá_nhân_học_viên tt = new Thông_tin_cá_nhân_học_viên();
            tt.Show();
        }
    }
}
