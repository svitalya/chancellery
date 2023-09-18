using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using chancellery.Models;

namespace chancellery.Forms
{
    public partial class AuthForm : Form
    {

        public bool isAuthed = false;

        public AuthForm()
        {
            InitializeComponent();
            MinimumSize = Size;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = (sender as CheckBox).Checked ? '\0' : '*';
        }

        private void  button1_Click(object sender, EventArgs e)
        {
            bool result = User.Auth(textBox1.Text, textBox2.Text);
            if (!result)
            {
                MessageBox.Show("Неправильные пароль или логин");
                return;
            }

            MessageBox.Show("Вход выполнен");
            isAuthed = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {

        }
    }
}
