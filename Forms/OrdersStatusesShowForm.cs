using chancellery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chancellery.Forms
{
    public partial class OrdersStatusesShowForm : Form
    {
        public OrdersStatusesShowForm()
        {
            InitializeComponent();
        }

        private void OrdersStatusesShowForm_Load(object sender, EventArgs e)
        {
            makeTable();
        }

        private void makeTable()
        {
            List<OrderStatus> ordersStatuses = Program.bd.OrderStatuses.ToList();

            dataGridView1.Rows.Clear();

            foreach (OrderStatus status in ordersStatuses)
            {
                dataGridView1.Rows.Add(new string[] {status.OrderStatusId.ToString(), status.Name.ToString()});
            }
        }
    }
}
