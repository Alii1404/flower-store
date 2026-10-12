using System;
using System.Globalization;
using System.Windows.Forms;

namespace flower_store
{
    public partial class Form1 : Form
    {
        private decimal totalIncome = 0;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(
                "colFlower", "Gül növü (gül adı)");

            dataGridView1.Columns.Add(
                "colCount", "Satış sayı");

            dataGridView1.Columns.Add(
                "colPrice", "Qiyməti");

            dataGridView1.Columns.Add(
                "colResult", "Yekun qiyməti");

            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            errorProvider1.ContainerControl = this;
            errorProvider2.ContainerControl = this;
            errorProvider3.ContainerControl = this;

            label4.Text = "Toplam gəlir: 0.00";
        }

        private void dataGridView1_CellContentClick_1(
            object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
            errorProvider2.SetError(textBox2, "");
            errorProvider3.SetError(textBox3, "");

            bool xeta = false;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(
                    textBox1, "Gül növünü daxil edin!");
                xeta = true;
            }

            int count = 0;

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider2.SetError(
                    textBox2, "Satış sayını daxil edin!");
                xeta = true;
            }
            else if (!int.TryParse(
                textBox2.Text.Trim(), out count))
            {
                errorProvider2.SetError(
                    textBox2,
                    "Say yalnız müsbət tam ədəd olmalıdır!");
                xeta = true;
            }
            else if (count <= 0)
            {
                errorProvider2.SetError(
                    textBox2,
                    "Say sıfırdan böyük olmalıdır!");
                xeta = true;
            }

            decimal price = 0;

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider3.SetError(
                    textBox3, "Qiyməti daxil edin!");
                xeta = true;
            }
            else
            {
                string priceText =
                    textBox3.Text.Trim().Replace(',', '.');

                if (!decimal.TryParse(
                    priceText,
                    NumberStyles.AllowDecimalPoint,
                    CultureInfo.InvariantCulture,
                    out price))
                {
                    errorProvider3.SetError(
                        textBox3,
                        "Qiymət düzgün ədəd olmalıdır!");
                    xeta = true;
                }
                else if (price <= 0)
                {
                    errorProvider3.SetError(
                        textBox3,
                        "Qiymət sıfırdan böyük olmalıdır!");
                    xeta = true;
                }
            }

            if (xeta)
            {
                return;
            }

            decimal result = count * price;

            dataGridView1.Rows.Add(
                textBox1.Text.Trim(),
                count.ToString(),
                price.ToString("F2",
                    CultureInfo.InvariantCulture),
                result.ToString("F2",
                    CultureInfo.InvariantCulture)
            );

            totalIncome += result;

            label4.Text = "Toplam gəlir: " +
                totalIncome.ToString(
                    "F2", CultureInfo.InvariantCulture);

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            errorProvider1.SetError(textBox1, "");
            errorProvider2.SetError(textBox2, "");
            errorProvider3.SetError(textBox3, "");

            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show(
                "Çıxış edilsinmi?",
                "Təsdiq",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cavab == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}