using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lic_man
{
    public partial class main_form : Form
    {
        general general;
        public main_form()
        {
            InitializeComponent();

            general = new general();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file = "info_product.json";
            general.save_product(file);
            general.load_product(file);
        }
    }
}
