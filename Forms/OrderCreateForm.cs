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
    public partial class OrderCreateForm : Form
    {

        private bool _isCreated = false;
        public bool isCreated {
            get
            {
                return _isCreated;
            }        
        }

        public OrderCreateForm()
        {
            InitializeComponent();
        }
    }
}
