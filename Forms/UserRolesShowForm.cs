using System;
using System.Collections.Generic;
using System.Linq;
using chancellery.Models;
using System.Windows.Forms;

namespace chancellery.Forms
{
    public partial class UserRolesShowForm : Form
    {
        public UserRolesShowForm()
        {
            InitializeComponent();
        }

        private void UserRolesShowForm_Load(object sender, EventArgs e)
        {
            makeTable();
        }

        private void makeTable()
        {
            List<UserRole> userRoles = Program.bd.UserRoles.ToList();
            dataGridView1.Rows.Clear();

            foreach (UserRole userRole in userRoles)
            {
                dataGridView1.Rows.Add(new string[]
                {
                    userRole.UserRoleId.ToString(),
                    userRole.Name.ToString(),
                    userRole.LevelAccess.ToString(),
                });
            }

            if(dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            int userRoleId = int.Parse(dataGridView1
                                        .SelectedRows[0]
                                        .Cells["ID"]
                                        .Value
                                        .ToString());

            UserRole userRole = Program.bd.UserRoles.Find(userRoleId);

            bool isRecInUsersTable = Program.bd.Users
                                        .Where(u => u.UserRoleID == userRoleId)
                                        .ToList()
                                        .Count() > 0;

            if (isRecInUsersTable)
            {
                MessageBox.Show($"Нельзя удалить запись роли пользователя \"{userRole.Name}\". Она связана с пользователями",
                                "Ошибка",
                                MessageBoxButtons.OK);
                return;
            }

            if
            (
                MessageBox.Show($"Вы точно хотите удалить запись роли пользователя \"{userRole.Name}\"?",
                                "Удаление записи", 
                                MessageBoxButtons.YesNo) == DialogResult.Yes
            )
            {
                Program.bd.UserRoles.Remove(userRole);
                Program.bd.SaveChanges();
                makeTable();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRole userRole = new UserRole();

            UserRoleEditForm form = new UserRoleEditForm(userRole, false);

            form.FormClosed += (s, ev) => {
                makeTable();
            };

            form.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;

            int userRoleId = int.Parse(dataGridView1
                            .SelectedRows[0]
                            .Cells["ID"]
                            .Value
                            .ToString());

            UserRole userRole = Program.bd.UserRoles.Find(userRoleId);

            UserRoleEditForm form = new UserRoleEditForm(userRole, true);

            form.FormClosed += (s, ev) => {
                if(form.isUpdated) makeTable();
            };

            form.ShowDialog();

        }
    }
}
