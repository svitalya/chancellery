using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using chancellery.Models;
using chancellery.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace chancellery
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        public static ApplicationContext bd;
        internal static CartService cart;

        [STAThread]
        static void Main()
        {
            bd = new ApplicationContext();
            cart = new CartService();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.MainForm());  
        } 
    }

    public class ApplicationContext : DbContext
    {
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PointDelivery> PointsDelivery { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrdersDetail { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;User=root;Password=;Database=chancellery");
        }
    }
}
