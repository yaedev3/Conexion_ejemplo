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
        private string connectionstring, server, database;
        private OleDbCommand command;//Comando sql
        private OleDbDataAdapter adapter;//Adapta la estructura al manejador
        private DataTable table;
        private int id;

        public Form1()
        {
            InitializeComponent();
            server = @"DESKTOP-Q77ELOA\SQLEXPRESS";
            connectionstring = @"Provider=SQLNCLI11;Server=DESKTOP-Q77ELOA\SQLEXPRESS;Database=universidad;Trusted_Connection=yes";
            connection = new OleDbConnection(connectionstring);
            this.UpdateGrid();
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            string name = comboBoxNames.SelectedItem.ToString();
            string location = textBoxLocation.Text;
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return;

            command = new OleDbCommand("UPDATE Informacion_universidad.Zona SET nombre='" + name + "',ubicacion='" + location + "' WHERE id_zona=" + id.ToString(), connection);
            command.ExecuteNonQuery();
            connection.Close();
            this.UpdateGrid();
            comboBoxNames.Text = textBoxLocation.Text = "";
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string name = comboBoxNames.SelectedItem.ToString();
            string location = textBoxLocation.Text;
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return;

            command = new OleDbCommand("DELETE FROM Informacion_universidad.Zona WHERE id_zona=" + id.ToString(), connection);
            command.ExecuteNonQuery();
            connection.Close();
            this.UpdateGrid();
            comboBoxNames.Text = textBoxLocation.Text = "";
        }

        private void dataGridViewData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridViewData.SelectedRows[0].Cells[0].Value.ToString());
            comboBoxNames.Text = dataGridViewData.SelectedRows[0].Cells[1].Value.ToString();
            textBoxLocation.Text = dataGridViewData.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = comboBoxNames.SelectedItem.ToString();
            string location = textBoxLocation.Text;
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return;

            command = new OleDbCommand("INSERT INTO Informacion_universidad.Zona (nombre, ubicacion) VALUES ('" + name + "','" + location + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();
            this.UpdateGrid();
            comboBoxNames.Text = textBoxLocation.Text = "";
        }

        private void UpdateGrid()
        {
            connection.Open();

            if (connection.State != ConnectionState.Open)
                return;

            command = new OleDbCommand("SELECT * FROM Informacion_universidad.Zona", connection);
            adapter = new OleDbDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridViewData.DataSource = table;
            connection.Close();
            //foreach(DataGridViewRow row in dataGridViewData.Rows)
                

        }
    }
}
