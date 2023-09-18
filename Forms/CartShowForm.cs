using chancellery.Models;
using chancellery.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySqlX.XDevAPI.Relational;

namespace chancellery.Forms
{
    public partial class CartShowForm : Form
    {
        CartPosition selectedPosition;

        public CartShowForm()
        {
            InitializeComponent();
            MinimumSize = Size;
            
        }

        private void CartShowForm_Load(object sender, EventArgs e)
        {
            initDataGrid();
        }

        private void initDataGrid(int selectedRow = 0)
        {
            Program.cart.DataGridFill(ref dataGridView1);
            if (dataGridView1.Rows.Count == 0)
            {
                Close();
                return;
            }

            dataGridView1.Rows[Math.Min(selectedRow, dataGridView1.Rows.Count-1)].Selected = true;
        }

        private void makeCount()
        {
            textBox4.Text = String.Format("{0:C2}", selectedPosition.resultPrice);
            textBox6.Text = $"{selectedPosition.count}";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int productId = int.Parse(row.Cells["productId"].Value.ToString());
            selectedPosition = Program.cart.getPosition(productId);

            Product product = selectedPosition.product;

            textBox1.Text = product.Name;
            textBox2.Text = product.Description;

            makeCount();

            MemoryStream ms = new MemoryStream(product.Image);
            pictureBox1.Image = Image.FromStream(ms);


            ms.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            if
            (
                MessageBox.Show("Удалить позицию из корзины?", "Предупреждение", MessageBoxButtons.YesNo) != DialogResult.Yes
            )
            {
                return;
            }

            Program.cart.DeletePosition(selectedPosition.product.ProductId);
            initDataGrid(row.Index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if
            (
                selectedPosition.count == 1
                && MessageBox.Show("Удалить позицию из корзины?", "Предупреждение", MessageBoxButtons.YesNo) != DialogResult.Yes
            )
            {
                return;
            }
            
            Program.cart.DeleteProduct(selectedPosition.product.ProductId);
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            initDataGrid(row.Index);
            makeCount();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            bool result = Program.cart.Add(selectedPosition.product);

            if (!result)
            {
                MessageBox.Show("Достигнуто максимальное значение продукции на складе",
                    $"Ошибка. Нельзя добавить продукт \"{selectedPosition.product.Name}\"", MessageBoxButtons.OK);
                return;
            }

            initDataGrid(row.Index);
            makeCount();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != 8
                && !int.TryParse(((TextBox)sender).Text.Insert(((TextBox)sender).SelectionStart, e.KeyChar.ToString()), out _);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int newCount = textBox6.Text != "" ? int.Parse(textBox6.Text) : 0;

            if
            (
                newCount == 0
                && MessageBox.Show("Удалить товар из корзины?", "Предупреждение", MessageBoxButtons.YesNo) != DialogResult.Yes
            )
            {
                textBox6.Text = selectedPosition.count.ToString();
                return;
            }

            bool result = Program.cart.SetCount(selectedPosition.product, newCount);

            if (!result)
            {
                MessageBox.Show("Введено значение больше максимального",
                    $"Ошибка", MessageBoxButtons.OK);
                textBox6.Text = selectedPosition.count.ToString();
                return;
            }


            initDataGrid(row.Index);
            makeCount();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OrderCreateForm form = new OrderCreateForm();
            form.FormClosed += (_, __) =>
            {
                if (form.isCreated)
                {
                    Program.cart.clearCart();
                    Close();
                }
            };
            form.ShowDialog();
        }
    }
}
