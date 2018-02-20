using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Conexion_ejemplo
{
    public partial class Form1 : Form
    {
        private OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection = new OleDbConnection(@"Provider=SQLNCLI11;Server=DESKTOP-Q77ELOA\SQLEXPRESS;Database=universidad; Trusted_Connection = yes;");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                this.button1_Click(null, null);
        }
    }
}
