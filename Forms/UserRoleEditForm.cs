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
    public partial class UserRoleEditForm : Form
    {
        private UserRole role;
        private bool isEdit;

        private int archiveHash;
        private bool isUpdate
        {
            get
            {
                int newHash = (textBox1.Text + comboBox1.SelectedIndex.ToString()).GetHashCode();
                return newHash != archiveHash;
            }
        }

        public bool isUpdated = false;

        public UserRoleEditForm(UserRole role, bool isEdit)
        {
            InitializeComponent();

            if (isEdit)
            {
                textBox1.Text = role.Name.ToString();
                comboBox1.SelectedIndex = role.UserRoleId;
            }

            archiveHash = (textBox1.Text + comboBox1.SelectedIndex.ToString()).GetHashCode();
            this.role = role;
            this.isEdit = isEdit;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isUpdated = true;

            if (!isEdit)
            {
                Program.bd.UserRoles.Add(role);
            }

            role.LevelAccess = comboBox1.SelectedIndex;
            role.Name = textBox1.Text;

            Program.bd.SaveChanges();

            Close();
        }

        private void checkUpdate()
        {
            button1.Enabled = isUpdate;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            checkUpdate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkUpdate();
        }
    }
}
