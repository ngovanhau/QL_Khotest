using System.Xml.Linq;

namespace Buoi4
{
    public partial class QL_Kho : Form
    {
        public QL_Kho()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(txtName.Text) || lstNames.Items.Contains(txtName.Text)))
                lstNames.Items.Add(txtName.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}