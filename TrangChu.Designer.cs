namespace Nhom5QLHocVienTTTH
{
    partial class TrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quanLyHocVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timKiemHocVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDX = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanLyHocVienToolStripMenuItem,
            this.timKiemHocVienToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quanLyHocVienToolStripMenuItem
            // 
            this.quanLyHocVienToolStripMenuItem.Name = "quanLyHocVienToolStripMenuItem";
            this.quanLyHocVienToolStripMenuItem.Size = new System.Drawing.Size(162, 25);
            this.quanLyHocVienToolStripMenuItem.Text = "Quản Lý Học Viên";
            this.quanLyHocVienToolStripMenuItem.Click += new System.EventHandler(this.quanLyHocVienToolStripMenuItem_Click);
            // 
            // timKiemHocVienToolStripMenuItem
            // 
            this.timKiemHocVienToolStripMenuItem.Name = "timKiemHocVienToolStripMenuItem";
            this.timKiemHocVienToolStripMenuItem.Size = new System.Drawing.Size(173, 25);
            this.timKiemHocVienToolStripMenuItem.Text = "Tìm Kiếm Học Viên";
            this.timKiemHocVienToolStripMenuItem.Click += new System.EventHandler(this.timKiemHocVienToolStripMenuItem_Click);
            // 
            // btnDX
            // 
            this.btnDX.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDX.Location = new System.Drawing.Point(517, 372);
            this.btnDX.Name = "btnDX";
            this.btnDX.Size = new System.Drawing.Size(157, 45);
            this.btnDX.TabIndex = 2;
            this.btnDX.Text = "Đăng Xuất";
            this.btnDX.UseVisualStyleBackColor = false;
            this.btnDX.Click += new System.EventHandler(this.btnDX_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Nhom5QLHocVienTTTH.Properties.Resources.images1;
            this.pictureBox1.Location = new System.Drawing.Point(13, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(661, 318);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // TrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(686, 420);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDX);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TrangChu";
            this.Text = "Trang Chủ";
            this.Load += new System.EventHandler(this.TrangChu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quanLyHocVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timKiemHocVienToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDX;
    }
}