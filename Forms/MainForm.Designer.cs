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
            this.cartShowButton = new System.Windows.Forms.Button();
            this.logoutButton = new System.Windows.Forms.Button();
            this.acessLabel = new System.Windows.Forms.Label();
            this.loginLable = new System.Windows.Forms.Label();
            this.logingButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // productsTable
            // 
            this.productsTable.AutoScroll = true;
            this.productsTable.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.productsTable.Location = new System.Drawing.Point(12, 12);
            this.productsTable.Name = "productsTable";
            this.productsTable.Size = new System.Drawing.Size(830, 452);
            this.productsTable.TabIndex = 0;
            // 
            // logingPanel
            // 
            this.logingPanel.Controls.Add(this.cartShowButton);
            this.logingPanel.Controls.Add(this.logoutButton);
            this.logingPanel.Controls.Add(this.acessLabel);
            this.logingPanel.Controls.Add(this.loginLable);
            this.logingPanel.Controls.Add(this.logingButton);
            this.logingPanel.Location = new System.Drawing.Point(855, 12);
            this.logingPanel.Name = "logingPanel";
            this.logingPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logingPanel.Size = new System.Drawing.Size(134, 136);
            this.logingPanel.TabIndex = 1;
            // 
            // cartShowButton
            // 
            this.cartShowButton.Location = new System.Drawing.Point(16, 97);
            this.cartShowButton.Name = "cartShowButton";
            this.cartShowButton.Size = new System.Drawing.Size(75, 25);
            this.cartShowButton.TabIndex = 2;
            this.cartShowButton.Text = "Корзина";
            this.cartShowButton.UseVisualStyleBackColor = true;
            this.cartShowButton.Click += new System.EventHandler(this.cartShowButton_Click);
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(16, 66);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 25);
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
            this.logingButton.Size = new System.Drawing.Size(75, 25);
            this.logingButton.TabIndex = 0;
            this.logingButton.Text = "Войти";
            this.logingButton.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 470);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 519);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logingPanel);
            this.Controls.Add(this.productsTable);
            this.Name = "MainForm";
            this.Text = "Канцелярский рай";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.Button button1;
    }
}

