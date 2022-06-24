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

namespace design_CSLT2
{
    public partial class frmbaocaosach : Form
    {
        DataTable bcao;
        public frmbaocaosach()
        {
            Functions.Connect();
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmbaocaosach_Load(object sender, EventArgs e)
        {
            btnboqua.Enabled = false;
            btninbaocao.Enabled = false;

            ResetValues();

        }
        private void ResetValues()
        {
            txtnam.Text = "";
            txtthang.Text = "";
            txtthang.Focus();
            txtthang.Enabled = true;
            txtnam.Enabled = true;



        }

        private void btnbaocao_Click(object sender, EventArgs e)
        {
            if (txtthang.Text == "")
            {
                MessageBox.Show("Hãy nhập 1 tháng cụ thể .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtthang.Focus();
                return;

            }
            if (txtnam.Text == "")
            {
                MessageBox.Show("Hãy nhập 1 năm cụ thể.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtnam.Focus();
                return;
            }
            string sql;
            sql = "SELECT a.Masach,Tensach,b.tinhtrang,c.ngaymuon,a.TenTG,a.manxb, a.NamXB, a.KhoSach,a.GiaSach, a.LanTaiBan,a.matheloai,a.mangonngu, a.Sotrang, a.TomTatND, a.Soluong,a.DonGiaThue FROM DMSach a join chitiethsm b on a.Masach=b.Masach JOIN hosomuon c on c.Mahsm=b.Mahsm" +
                   " WHERE b.tinhtrang like N'Chưa trả' and " +
                "  Year(c.Ngaymuon)='" + txtnam.Text + "' And Month(c.Ngaymuon)='" + txtthang.Text + "'";
            bcao = Functions.GetDataToTable(sql);
            if (bcao.Rows.Count == 0)
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Có " + bcao.Rows.Count + " bản ghi thỏa mãn điều kiện", "Thông báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            dataGridViewbcsach.DataSource = bcao;
            txtthang.Enabled = false;
            txtnam.Enabled = false;
            btnbaocao.Enabled = false;
            btnboqua.Enabled = true;
            btninbaocao.Enabled = true;

        }

        private void btnboqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            txtthang.Enabled = true;
            txtnam.Enabled = true;
            btnboqua.Enabled = false;
            btninbaocao.Enabled = false;
            btnbaocao.Enabled = true;

        }

        private void btnthoát_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(" Bạn có chắc chắn muốn đóng không  ?",
                  "Cảnh báo !", MessageBoxButtons.OKCancel) == DialogResult.OK) ;
            this.Close();


        }

        private void btninbaocao_Click(object sender, EventArgs e)
        {
            if ((txtthang.Text == "") || (txtnam.Text == ""))
            {
                MessageBox.Show("Hãy chọn 1 tháng hoặc năm cụ thể ",
                "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
    }
}
