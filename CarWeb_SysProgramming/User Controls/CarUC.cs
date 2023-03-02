using CarWeb_SysProgramming.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWeb_SysProgramming.User_Controls
{
    public partial class CarUC : UserControl
    {
        public CarUC(Car? car)
        {
            InitializeComponent();

            label1.Text = car?.Make;
            label2.Text = car?.Model;
            label3.Text = car?.Year.ToString();
        }

        private void CarUC_Load(object sender, EventArgs e)
        {

        }
    }
}
