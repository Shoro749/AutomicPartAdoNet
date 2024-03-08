using AutomicPartAdoNet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomicPartAdoNet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //DataTable dataTable = new DataTable(nameof(BankAccount));

                //DataColumn idColumn = new DataColumn("Id", typeof(int))
                //{
                //    AutoIncrement = true,
                //    AutoIncrementSeed = 1,
                //    AutoIncrementStep = 1,
                //};
                //DataColumn nameColumn = new DataColumn("Name", typeof(string));
                //DataColumn cardColumn = new DataColumn("Card", typeof(string));
                //DataColumn moneyColumn = new DataColumn("Balance", typeof(int));

                //dataTable.Columns.Add(idColumn);
                //dataTable.Constraints.Add(new UniqueConstraint(idColumn, true));
                //dataTable.Columns.Add(nameColumn);
                //dataTable.Columns.Add(cardColumn);
                //dataTable.Columns.Add(moneyColumn);


                //DataTable dataTable = TableGenerator.CreateTable(nameof(BankAccount), new BankAccount());

                //DataRow row = dataTable.NewRow();
                //row["Name"] = "John";
                //row["Card"] = "1234-3423-6567-3434";
                //row[3] = 1000;

                //dataTable.Rows.Add(row);

                //DataRow row1 = dataTable.NewRow();
                //row1["Name"] = "Mark";
                //row1["Card"] = "4354-3423-6567-3434";
                //row1[3] = 2000;

                //dataTable.Rows.Add(row1);

                //dataGrid.ItemsSource = dataTable.DefaultView;

                DataTable dataTable = TableGenerator.CreateTable(nameof(User), new User());

                //DataRow row = dataTable.NewRow();
                //row["Name"] = "John";
                //row["Login"] = "john@gmail.com";
                //row["Password"] = "qwerty";

                //dataTable.Rows.Add(row);

                //DataRow row1 = dataTable.NewRow();
                //row1["Name"] = "Marc";
                //row1["Login"] = "marc@gmail.com";
                //row1["Password"] = "1234";

                //dataTable.Rows.Add(row1);
                TableGenerator.LoadToTable(dataTable, connectionString);

                dataGrid.ItemsSource = dataTable.DefaultView;

                //BankAccount bankAccount = new BankAccount()
                //{
                //    Id = 1,
                //    Name = "Jhon",
                //    Card = "2432-4324-3243-2434",
                //    Balance = 5000,
                //};
                //string data = TableGenerator.ShowDataInfo(bankAccount);
                //tbData.Text = data;
            }
        }
    }
}
