namespace chancellery.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.productsTable = new System.Windows.Forms.Panel();
            this.logingPanel = new System.Windows.Forms.Panel();
            this.logoutButton = new System.Windows.Forms.Button();
            this.acessLabel = new System.Windows.Forms.Label();
            this.loginLable = new System.Windows.Forms.Label();
            this.logingButton = new System.Windows.Forms.Button();
            this.cartShowButton = new System.Windows.Forms.Button();
            this.logingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // productsTable
            // 
            this.productsTable.AutoScroll = true;
            this.productsTable.Location = new System.Drawing.Point(12, 12);
            this.productsTable.Name = "productsTable";
            this.productsTable.Size = new System.Drawing.Size(830, 516);
            this.productsTable.TabIndex = 0;
            // 
            // logingPanel
            // 
            this.logingPanel.Controls.Add(this.logoutButton);
            this.logingPanel.Controls.Add(this.acessLabel);
            this.logingPanel.Controls.Add(this.loginLable);
            this.logingPanel.Controls.Add(this.logingButton);
            this.logingPanel.Location = new System.Drawing.Point(855, 12);
            this.logingPanel.Name = "logingPanel";
            this.logingPanel.Size = new System.Drawing.Size(134, 104);
            this.logingPanel.TabIndex = 1;
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(16, 66);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(62, 25);
            this.logoutButton.TabIndex = 2;
            this.logoutButton.Text = "Войти";
            this.logoutButton.UseVisualStyleBackColor = true;
            // 
            // acessLabel
            // 
            this.acessLabel.AutoSize = true;
            this.acessLabel.Location = new System.Drawing.Point(13, 37);
            this.acessLabel.Name = "acessLabel";
            this.acessLabel.Size = new System.Drawing.Size(35, 13);
            this.acessLabel.TabIndex = 2;
            this.acessLabel.Text = "label2";
            this.acessLabel.Visible = false;
            // 
            // loginLable
            // 
            this.loginLable.AutoSize = true;
            this.loginLable.Location = new System.Drawing.Point(13, 12);
            this.loginLable.Name = "loginLable";
            this.loginLable.Size = new System.Drawing.Size(96, 13);
            this.loginLable.TabIndex = 1;
            this.loginLable.Text = "Вы еще не вошли";
            // 
            // logingButton
            // 
            this.logingButton.Location = new System.Drawing.Point(16, 66);
            this.logingButton.Name = "logingButton";
            this.logingButton.Size = new System.Drawing.Size(62, 25);
            this.logingButton.TabIndex = 0;
            this.logingButton.Text = "Войти";
            this.logingButton.UseVisualStyleBackColor = true;
            // 
            // cartShowButton
            // 
            this.cartShowButton.Location = new System.Drawing.Point(858, 135);
            this.cartShowButton.Name = "cartShowButton";
            this.cartShowButton.Size = new System.Drawing.Size(75, 23);
            this.cartShowButton.TabIndex = 2;
            this.cartShowButton.Text = "Корзина";
            this.cartShowButton.UseVisualStyleBackColor = true;
            this.cartShowButton.Click += new System.EventHandler(this.cartShowButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 540);
            this.Controls.Add(this.cartShowButton);
            this.Controls.Add(this.logingPanel);
            this.Controls.Add(this.productsTable);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.logingPanel.ResumeLayout(false);
            this.logingPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel productsTable;
        private System.Windows.Forms.Panel logingPanel;
        private System.Windows.Forms.Label acessLabel;
        private System.Windows.Forms.Label loginLable;
        private System.Windows.Forms.Button logingButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Button cartShowButton;
    }
}

