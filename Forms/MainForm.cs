using System.Windows.Forms;
using chancellery.Models;
using chancellery.Components;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Runtime.Remoting.Channels;

namespace chancellery.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MinimumSize = Size;

            //Random rnd = new Random();

            //for (int i = 18; i <= 100; i++)
            //{
            //    Product product = new Product
            //    {
            //        Name = $"name{i}",
            //        Description = $"description{i}",
            //        Price = rnd.Next(1, 1000),
            //        Discount = rnd.Next(10, 100),
            //    };

            //    MemoryStream ms1 = new MemoryStream();
            //    OpenFileDialog fileDialog = new OpenFileDialog();
            //    fileDialog.ShowDialog();

            //    Image image = Image.FromFile(fileDialog.FileName);
            //    image.Save(ms1, image.RawFormat);
            //    product.Image = ms1.ToArray();

            //    bd.Products.Add(product);
            //}

            //bd.SaveChanges();

            //User.Auth("admin", "qwerty");
            //List<Product> prods = bd.Products.Where(p => p.Count > 0).ToList();

            //foreach (Product product in prods)
            //{
            //    Program.cart.Add(product);
            //}
            initAuth();
            checkCart();
        }

        public void chechAuth()
        {
            bool isAuth = User.authUser != null;

            logoutButton.Visible = isAuth;
            logingButton.Visible = !isAuth;


            logoutButton.Text = isAuth ? "Выйти" : "Войти";

            loginLable.Text = isAuth ? "Логин: " + User.authUser.Login : "Вы еще не вошли";
            acessLabel.Visible = isAuth;
            acessLabel.Text = isAuth ? "Роль: " + User.authUser.UserRole.Name : "";

            makeForm();

        }

        public void initAuth()
        {

            chechAuth();
            logingButton.Click += (o, e) =>
            {
                AuthForm form = new AuthForm();
                form.FormClosed += (s, e2) =>
                {
                    if (form.isAuthed)
                    {
                        chechAuth();
                    }
                };

                form.ShowDialog();
            };

            logoutButton.Click += (o, e) =>
            {
                User.Logout();
                chechAuth();
            };

        }

        public void checkCart()
        {
            cartShowButton.Enabled = Program.cart.isSet();
        }

        public ContextMenuStrip getStripMenuItemByLevelAccess(int levelAccess, Product product)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            List<ToolStripMenuProduct> toolStripMenuItems = new List<ToolStripMenuProduct>();

            ToolStripMenuProduct addToCart = new ToolStripMenuProduct("Добавить в корзину", product);
            addToCart.Click += addToCartMenuItem_Click;
            toolStripMenuItems.Add(addToCart);

            ToolStripMenuProduct openProduct = new ToolStripMenuProduct("Открыть", product);
            openProduct.Click += openProductMenuItem_Click;
            toolStripMenuItems.Add(openProduct);

            if (levelAccess >= 3)
            {
                ToolStripMenuProduct editMenuItem = new ToolStripMenuProduct("Редактировать", product);
                editMenuItem.Click += editProductMenuItem_Click;
                toolStripMenuItems.Add(editMenuItem);


                ToolStripMenuProduct deleteMenuItem = new ToolStripMenuProduct("Удалить", product);
                deleteMenuItem.Click += deleteMenuItem_Click;
                toolStripMenuItems.Add(deleteMenuItem);
            }


            menu.Items.AddRange(toolStripMenuItems.ToArray());

            return menu;
        }

        public void makeMainMenu(int levelAccess)
        {
            Menu = null;

            MainMenu mainMenu = new MainMenu();

            if (levelAccess >= 3)
            {
                MenuItem tablesMenuItems = new MenuItem("Таблицы");
                mainMenu.MenuItems.Add(tablesMenuItems);

                MenuItem tablesUserRolesMenuItem = new MenuItem("Статусы сотрудников");
                tablesUserRolesMenuItem.Click += tablesUserRolesMenuItem_CLick;
                tablesMenuItems.MenuItems.Add(tablesUserRolesMenuItem);

                MenuItem referencesMenuItems = new MenuItem("Справочники");
                mainMenu.MenuItems.Add(referencesMenuItems);

                MenuItem referenceOrderStatuses = new MenuItem("Статусы заказов");
                referenceOrderStatuses.Click += referenceOrderStatuses_Click;
                referencesMenuItems.MenuItems.Add(referenceOrderStatuses);
            }

            Menu = mainMenu;
        }

        private void referenceOrderStatuses_Click(object sender, EventArgs e)
        {
            OrdersStatusesShowForm from = new OrdersStatusesShowForm();
            from.ShowDialog();
        }

        private void tablesUserRolesMenuItem_CLick(object sender, EventArgs e)
        {
            UserRolesShowForm form = new UserRolesShowForm();
            form.ShowDialog();
        }

        private void openProductMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuProduct toolStripMenuItem = sender as ToolStripMenuProduct;
            Product product = toolStripMenuItem.Product;
            ProducForm form = new ProducForm(product, false, false);
            form.ShowDialog();
        }

        private void addToCartMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuProduct toolStripMenuItem = sender as ToolStripMenuProduct;
            Product product = toolStripMenuItem.Product;

            bool isOk = Program.cart.Add(product);

            if (!isOk)
            {
                MessageBox.Show("Достигнуто максимальное значение продукции на складе",
                                $"Ошибка. Нельзя добавить продукт \"{product.Name}\"", MessageBoxButtons.OK);
                return;
            }

            checkCart();
        }

        private void editProductMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuProduct toolStripMenuItem = sender as ToolStripMenuProduct;
            Product product = toolStripMenuItem.Product;
            ProducForm form = new ProducForm(product, true, false);
            form.FormClosed += (s, __) =>
            {
                if (form.isSaved)
                {
                    makeForm();
                }       
            };
            form.ShowDialog();
        }

        private void deleteMenuItem_Click(object sender,  EventArgs e)
        {
            ToolStripMenuProduct toolStripMenuItem = sender as ToolStripMenuProduct;
            Product product = toolStripMenuItem.Product;

            bool productIsInOrderDetails = Program.bd.OrdersDetail
                                           .Where(od => od.ProductId == product.ProductId)
                                           .ToList()
                                           .Count() > 0;

            if (productIsInOrderDetails)
            {
                MessageBox.Show($"Нельзя удалить запись товара \"{product.Name}\". Она связана с деталями заказа.", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            else if (MessageBox.Show($"Вы точно хотите удалить запись товара \"{product.Name}\"", "Удаление продукта", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Program.cart.DeletePosition(product.ProductId);
                checkCart();

                Program.bd.Products.Remove(product);
                Program.bd.SaveChanges();

                makeProductsTable(User.getLevelAccess());
            }
        }

        public void makeProductsTable(int levelAccess)
        {
            List<Product> products = Program.bd.Products.Where(p => p.Count > 0).ToList();
            int x = 5; int y = 5;
            productsTable.Controls.Clear();

            foreach (Product product in products)
            {
                ProductPanel productPanel = new ProductPanel(new Point(x, y), product);
                productPanel.ContextMenuStrip = getStripMenuItemByLevelAccess(levelAccess, product);

                productsTable.Controls.Add(productPanel);

                x += 135;

                if (productsTable.Size.Width < x + 135)
                {
                    x = 5;
                    y += 190;
                }
            }
        }

        public void makeForm()
        {
            int levelAccess = User.getLevelAccess();

            makeMainMenu(levelAccess);
            makeProductsTable(levelAccess);
        }

        private void cartShowButton_Click(object sender, EventArgs e)
        {
            CartShowForm cartShowForm = new CartShowForm();

            cartShowForm.FormClosed += (_, __) =>
            {
                checkCart();
            };
            cartShowForm.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
