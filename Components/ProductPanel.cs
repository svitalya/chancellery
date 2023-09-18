using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using chancellery.Models;
using System.IO;

namespace chancellery.Components
{
    public class ProductPanel : Panel
    {
        public Product product;

        public ProductPanel(Point point, Product product)
        {
            Location = point;
            this.product = product;
            BackColor = Color.White;
            Size = new Size(130, 185);
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Location = new Point(5, 5);
            pictureBox.ClientSize = new Size(120, 100);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            MemoryStream ms = new MemoryStream(product.Image);
            pictureBox.Image = Image.FromStream(ms);
            ms.Dispose();
            Controls.Add(pictureBox);

            Label label = new Label();
            label.Size = new Size(120, 15);
            label.Text = "Название: " + product.Name;
            label.Location = new Point(5, 105);
            Controls.Add(label);

            Label label2 = new Label();
            label2.Size = new Size(120, 15);
            label2.Text = "Цена: " + product.priceWithDiscountString;
            label2.Location = new Point(5, 125);
            Controls.Add(label2);

            Label label3 = new Label();
            label3.Size = new Size(120, 15);
            label3.Text = $"Скидка: {product.discountStrign}";
            label3.Location = new Point(5, 145);
            Controls.Add(label3);
     
            Label label4 = new Label();
            label4.Size = new Size(120, 15);
            label4.Text = "На складе: " + product.Count.ToString();
            label4.Location = new Point(5, 165);
            Controls.Add(label4);
        }
    }
}
