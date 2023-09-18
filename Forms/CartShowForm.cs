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

namespace chancellery.Forms
{
    public partial class CartShowForm : Form
    {
        CartPosition selectedPosition;

        public CartShowForm()
        {
            InitializeComponent();
            
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
            Product product = selectedPosition.product;
            double discount = product.Discount ?? 0;
            double priceWithDiscount = product.Price - product.Price * discount / 100;
            int count = selectedPosition.count;
            double resultPrice = Math.Round(priceWithDiscount * count);
            priceProductLable.Text = $"Итоговая стоимость: {resultPrice}р";
            countLable.Text = $"Количество: {count}";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            DataGridViewRow row = dataGridView1.SelectedRows[0];

            int productId = int.Parse(row.Cells["productId"].Value.ToString());
            selectedPosition = Program.cart.getPosition(productId);

            Product product = selectedPosition.product;

            productNameLable.Text = product.Name;
            productDescriptionLable.Text = product.Description;

            makeCount();

            MemoryStream ms = new MemoryStream(product.Image);
            pictureBox1.Image = System.Drawing.Image.FromStream(ms);


            ms.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            Program.cart.DeletePosition(selectedPosition.product.ProductId);
            initDataGrid(row.Index);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.cart.DeleteProduct(selectedPosition.product.ProductId);
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            initDataGrid(row.Index);
            makeCount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];

            Program.cart.Add(selectedPosition.product);
            initDataGrid(row.Index);
            makeCount();
        }
    }
}
