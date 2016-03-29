using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Elexim.Employee
{
    /// <summary>
    /// Logique d'interaction pour EmployeeCrud.xaml
    /// </summary>
    public partial class EmployeeCrud : Window
    {
        public EmployeeCrud()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {

            AppSettingsReader reader = new AppSettingsReader();
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder()
            {
                Database = (string)reader.GetValue("MYSQL_DATABASE", typeof(string)),
                Password = (string)reader.GetValue("MYSQL_PASS", typeof(string)),
                UserID = (string)reader.GetValue("MYSQL_USER", typeof(string)),
                Server = (string)reader.GetValue("MYSQL_SERVER", typeof(string)),
            };

            using(MySqlConnection con = new MySqlConnection(builder.ConnectionString))
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                adapter.SelectCommand = new MySqlCommand("SELECT * FROM employee", con);

                adapter.Fill(table);

                employeeGrid.DataContext = table.DefaultView;

      
            }


        }
    }
}
