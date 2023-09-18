using chancellery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chancellery.Forms
{
    public partial class ProducForm : Form
    {
        private Product product;
        
        private bool isEdit;
        private bool isAddingProduct;
        private int archiveStrHash;

        public bool isSaved = false;

        public bool isEdited {
            get {
                string imageStr = "";
                if (pictureBox1.Image != null)
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] bytes = ms.ToArray();
                    ms.Dispose();
                    imageStr = System.Text.Encoding.UTF8.GetString(bytes);
                }



                int newStr = (textBox1.Text
                                + textBox2.Text
                                + textBox3.Text
                                + textBox4.Text
                                + textBox5.Text
                                + imageStr).GetHashCode();

                return archiveStrHash != newStr;

            }
        }

        public ProducForm(Product product, bool isEdit = true, bool isAddingProduct = true)
        {
            InitializeComponent();

            MinimumSize = Size;

            if (isAddingProduct)
            {
                Text = "Новый товар";
            }
            else
            {
                Text = isEdit ? $"Редактирование товара - \"{product.Name}\"" : $"Товар: \"{product.Name}\"";
            }

            this.product = product;
            this.isEdit = isEdit;
            this.isAddingProduct = isAddingProduct;

            string productNameArchive = !isAddingProduct ? product.Name : "";
            string productDescriptionArchive = !isAddingProduct ? product.Description : "";
            string productDiscountArchive = !isAddingProduct
                ? (product.Discount == null || product.Discount == 0 ? "" : product.Discount.ToString())
                : "";
            string productPriceArchive = !isAddingProduct ? product.Price.ToString() : "";
            string productCountArchive = !isAddingProduct ? product.Count.ToString() : "";
            string productImageArchive = !isAddingProduct ?
                System.Text.Encoding.UTF8.GetString(product.Image)
                : "";

            archiveStrHash = (productNameArchive
                + productDescriptionArchive
                + productPriceArchive
                + productDiscountArchive
                + productCountArchive
                + productImageArchive).GetHashCode();

            button2.Enabled = false;
        }

        private void ProducForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = !isAddingProduct ? product.Name : "";
            textBox2.Text = !isAddingProduct ? product.Description : "";
            textBox3.Text = !isAddingProduct ? product.Price.ToString() : "";
            textBox4.Text = !isAddingProduct ? product.Discount.ToString() : "";
            textBox5.Text = !isAddingProduct ? product.Count.ToString() : "";

            if (!isAddingProduct)
            {
                MemoryStream ms = new MemoryStream(product.Image);
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
            }

            button1.Visible = isEdit;
            button2.Visible = isEdit;
            textBox1.ReadOnly = !isEdit;
            textBox2.ReadOnly = !isEdit;
            textBox3.ReadOnly = !isEdit;
            textBox4.ReadOnly = !isEdit;
            textBox5.ReadOnly = !isEdit;

            textBox1.TextChanged += textBox1_TextChanged;
            textBox2.TextChanged += textBox1_TextChanged;
            textBox3.TextChanged += textBox1_TextChanged;
            textBox4.TextChanged += textBox1_TextChanged;
            textBox5.TextChanged += textBox1_TextChanged;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkChange()
        {
            button2.Enabled = isEdited && checkInput(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(fileDialog.FileName);
                checkChange();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkChange();
        }

        public bool checkInput(bool showMessage = true)
        {  

            if (textBox1.Text.Length == 0 || textBox1.Text.Length > 64)
            {
                if (showMessage) MessageBox.Show("Название продукта не может быть пустым или содержать в себе больше 64 символов");
                return false;
            }

            if (textBox2.Text.Length == 0 || textBox2.Text.Length > 256)
            {
                if (showMessage) MessageBox.Show("Описание продукта не может быть пустым или содержать в себе больше 256 символов");
                return false;
            }

            double priceCheck;
            if (textBox3.Text.Length == 0 || !double.TryParse(textBox3.Text, out priceCheck) || priceCheck <= 0)
            {
                if (showMessage) MessageBox.Show("Цена продукта не может быть нулевой или отрицательной");
                return false;
            }

            double discountCheck;
            if
            (
                textBox4.Text != ""
                && (!double.TryParse(textBox4.Text, out discountCheck) || discountCheck < 0 || discountCheck > 100)
            )
            {
                if (showMessage) MessageBox.Show("Скидка на продукт не может быть отрицательной или больше 100%");
                return false;
            }


            int countCheck;

            if (textBox5.Text.Length == 0 || !int.TryParse(textBox5.Text, out countCheck) || countCheck < 0)
            {
                if (showMessage) MessageBox.Show("Введите количество");
                return false;
            }


            if(pictureBox1.Image == null)
            {
                if (showMessage) MessageBox.Show("Загрузите изображение");
                return false;
            }


            return true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkInput()) return;

            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            byte[] bytes = ms.ToArray();
            ms.Dispose();

            if(isAddingProduct)
            {
                Program.bd.Products.Add(product);
            }
            product.Image = bytes;
            product.Name = textBox1.Text;
            product.Description = textBox2.Text;
            product.Price = Math.Round(double.Parse(textBox3.Text), 2);
            product.Discount = textBox4.Text != "" ? Math.Round(double.Parse(textBox4.Text), 2) : 0;
            product.Count = int.Parse(textBox5.Text);

            Program.bd.SaveChanges();
            isSaved = true;
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (c == 8 || (c >= 'А' && c <= 'я')) return;
            e.Handled = true;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if
            (
                c == 8
                || ".,\" \n\t\r".IndexOf(c) != -1
                || (c >= 'А' && c <= 'я')
            ) return;
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if
            (
                c == 8
            ) return;

            string resultStr = (sender as TextBox).Text;
            resultStr = resultStr.Insert((sender as TextBox).SelectionStart, c.ToString());
            double check;
            e.Handled = !double.TryParse(resultStr, out check) || check < 0;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if
            (
                c == 8
            ) return;

            string resultStr = (sender as TextBox).Text;
            resultStr = resultStr.Insert((sender as TextBox).SelectionStart, c.ToString());
            double check;
            e.Handled = !double.TryParse(resultStr, out check) || check < 0 || check > 100;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if
            (
                c == 8
            ) return;

            string resultStr = (sender as TextBox).Text;
            resultStr = resultStr.Insert((sender as TextBox).SelectionStart, c.ToString());
            int check;
            e.Handled = !int.TryParse(resultStr, out check) || check < 0;
        }
    }
}
