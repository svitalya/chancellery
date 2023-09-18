namespace chancellery.Forms
{
    partial class CartShowForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.productNameLable = new System.Windows.Forms.Label();
            this.productDescriptionLable = new System.Windows.Forms.Label();
            this.countLable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.priceProductLable = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productPriceWithDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(715, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // productNameLable
            // 
            this.productNameLable.AutoSize = true;
            this.productNameLable.Location = new System.Drawing.Point(869, 12);
            this.productNameLable.Name = "productNameLable";
            this.productNameLable.Size = new System.Drawing.Size(35, 13);
            this.productNameLable.TabIndex = 3;
            this.productNameLable.Text = "label1";
            // 
            // productDescriptionLable
            // 
            this.productDescriptionLable.AutoSize = true;
            this.productDescriptionLable.Location = new System.Drawing.Point(869, 38);
            this.productDescriptionLable.Name = "productDescriptionLable";
            this.productDescriptionLable.Size = new System.Drawing.Size(35, 13);
            this.productDescriptionLable.TabIndex = 4;
            this.productDescriptionLable.Text = "label1";
            // 
            // countLable
            // 
            this.countLable.AutoSize = true;
            this.countLable.Location = new System.Drawing.Point(874, 119);
            this.countLable.Name = "countLable";
            this.countLable.Size = new System.Drawing.Size(22, 13);
            this.countLable.TabIndex = 5;
            this.countLable.Text = "cfg";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(871, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "<";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(902, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(715, 150);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 24);
            this.button3.TabIndex = 9;
            this.button3.Text = "Удалить позицию";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // priceProductLable
            // 
            this.priceProductLable.AutoSize = true;
            this.priceProductLable.Location = new System.Drawing.Point(869, 69);
            this.priceProductLable.Name = "priceProductLable";
            this.priceProductLable.Size = new System.Drawing.Size(35, 13);
            this.priceProductLable.TabIndex = 10;
            this.priceProductLable.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productId,
            this.productName,
            this.productPrice,
            this.discount,
            this.productPriceWithDiscount,
            this.count,
            this.sumPrice});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowCellErrors = false;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(671, 329);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // productId
            // 
            this.productId.HeaderText = "НЕТ";
            this.productId.Name = "productId";
            this.productId.ReadOnly = true;
            this.productId.Visible = false;
            // 
            // productName
            // 
            this.productName.HeaderText = "Имя товара";
            this.productName.Name = "productName";
            this.productName.ReadOnly = true;
            // 
            // productPrice
            // 
            this.productPrice.HeaderText = "Цена";
            this.productPrice.Name = "productPrice";
            this.productPrice.ReadOnly = true;
            // 
            // discount
            // 
            this.discount.HeaderText = "Скидка (%)";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            // 
            // productPriceWithDiscount
            // 
            this.productPriceWithDiscount.HeaderText = "Цена с учетом скидки";
            this.productPriceWithDiscount.Name = "productPriceWithDiscount";
            this.productPriceWithDiscount.ReadOnly = true;
            // 
            // count
            // 
            this.count.HeaderText = "Количество товара";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // sumPrice
            // 
            this.sumPrice.HeaderText = "Итоговая стоимость";
            this.sumPrice.Name = "sumPrice";
            this.sumPrice.ReadOnly = true;
            // 
            // CartShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.priceProductLable);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.countLable);
            this.Controls.Add(this.productDescriptionLable);
            this.Controls.Add(this.productNameLable);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CartShowForm";
            this.Text = "CartShowForm";
            this.Load += new System.EventHandler(this.CartShowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label productNameLable;
        private System.Windows.Forms.Label productDescriptionLable;
        private System.Windows.Forms.Label countLable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label priceProductLable;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn productName;
        private System.Windows.Forms.DataGridViewTextBoxColumn productPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn productPriceWithDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumPrice;
    }
}