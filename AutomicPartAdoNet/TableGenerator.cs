using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AutomicPartAdoNet
{
    internal static class TableGenerator
    {
        public static DataTable CreateTable<T>(string tableName, T obj)
        {
            var columns = GetColumnsFromClass(obj);
            DataTable table = new DataTable(tableName);
            foreach(DataColumn column in columns)
            {
                table.Columns.Add(column);
                if(column.ColumnName.ToLower() == "id")
                {
                    column.AutoIncrement = true;
                    column.AutoIncrementSeed = 1;
                    column.AutoIncrementStep = 1;
                    table.Constraints.Add(new UniqueConstraint(column, true));
                }
            }

            return table;
        }

        public static string ShowDataInfo<T>(T obj)
        {
            string data = "";

            Type type = typeof(T);
            data += $"Class name: {type.Name}\nParent class: {type.BaseType}\n";
            foreach(var prop in type.GetProperties())
            {
                data += $"Prop Name: {prop.Name}, Type: {prop.PropertyType}, Value: {prop.GetValue(obj, null)}\n";
            }
            foreach(var prop in type.GetFields())
            {
                data += $"Field Name: {prop.Name}, Type: {prop.FieldType}, Value: {prop.GetValue(obj)}\n";
            }
            foreach(var method in type.GetMethods())
            {
                data += $"Method Name: {method.Name}, Return: {method.ReturnType}, IsPublic: {method.IsPublic}\n";
            }

            return data;
        }

        public static DataColumn[] GetColumnsFromClass<T>(T obj)
        {
            Type type = typeof(T);
            List<DataColumn> list = new List<DataColumn>();

            foreach(var prop in type.GetProperties())
            {
                DataColumn column = new DataColumn(prop.Name, prop.PropertyType);
                list.Add(column);
            }

            return list.ToArray();
        }

        public static void AddRow<T>(DataTable table, T obj)
        {
            DataRow row = table.NewRow();
            Type type = typeof(T);

            foreach (var prop in type.GetProperties())
            {
                row[prop.Name] = prop.GetValue(obj, null);
            }

            table.Rows.Add(row);
        }

        public static void LoadToTable(DataTable table, string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"select * from {table.TableName}", connection);
                        sqlDataAdapter.Fill(table);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
