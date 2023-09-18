using chancellery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chancellery.Components
{
    public class ToolStripMenuProduct : ToolStripMenuItem
    {
        private Product _product;

        public ToolStripMenuProduct(string text, Product product) : base(text)
        {
            this._product = product;
        }

        public Product Product { get => _product; }
    }
}
