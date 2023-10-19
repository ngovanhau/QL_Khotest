using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Collections;

namespace Quanlikho
{
    public partial class SRM_kho : Form
    {
        SqlConnection conn = new SqlConnection("server=DESKTOP-9EO7H7L\\SQLEXPRESS;Initial Catalog =QL_Kho; uid=sa; pwd=123");

        public SRM_kho()
        {
            InitializeComponent();
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(text_makho.Text)) || (string.IsNullOrEmpty(text_tenkho.Text)) || (string.IsNullOrEmpty(text_diachi.Text)))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_Kho values (N'" + text_makho.Text + "',N'" + text_tenkho.Text + "', N'" + text_diachi.Text + "') ", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                text_makho.Clear();
                text_tenkho.Clear();
                text_diachi.Clear();
                text_makho.Focus();
                button_load_Click(sender, e);
                conn.Close();
            }
        }

        private void lst_xem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Bạn muốn xóa", "canh bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dl == DialogResult.Yes)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete tbl_Kho where Ma_kho = '" + text_makho.Text + "'", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                text_makho.Clear();
                text_tenkho.Clear();
                text_diachi.Clear();
                text_makho.Focus();

                conn.Close();

            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update tbl_Kho set Ten_Kho = N'" + text_tenkho.Text + "', Dia_Chi = N'" + text_diachi.Text + "' where Ma_Kho = '" + text_makho.Text + "' ", conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            text_makho.Clear();
            text_tenkho.Clear();
            text_diachi.Clear();
            text_makho.Focus();
            button_load_Click(sender, e);
            conn.Close();

        }

        private void button_load_Click(object sender, EventArgs e)
        {
            
            lst_xem.Items.Clear();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from tbl_Kho", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                    lv.SubItems.Add(reader.GetString(1));
                    lv.SubItems.Add(reader.GetString(2));
                    lst_xem.Items.Add(lv);
                }
                conn.Close();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Lỗi kết nối");
            }

        }

        private void button_luu_Click(object sender, EventArgs e)
        {

        }

        private void lst_xem_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            text_makho.Text = lst_xem.SelectedItems[0].SubItems[0].Text;
            text_tenkho.Text = lst_xem.SelectedItems[0].SubItems[1].Text;
            text_diachi.Text = lst_xem.SelectedItems[0].SubItems[2].Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lst_xem.Items.Clear();
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select * from tbl_Kho where Ma_Kho = '" + text_makho.Text + "'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ListViewItem lv = new ListViewItem(reader.GetString(0).ToString());
                    lv.SubItems.Add(reader.GetString(1));
                    lv.SubItems.Add(reader.GetString(2));
                    lst_xem.Items.Add(lv);
                }


                conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
