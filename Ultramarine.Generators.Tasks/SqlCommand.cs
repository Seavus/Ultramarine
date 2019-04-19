using System;
using System.Collections.Generic;
using System.Composition;
using System.Data;
using System.Data.Common;
using Ultramarine.Generators.Tasks.Library.Contracts;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Ultramarine.Generators.Tasks
{
    [Export(typeof(Task))]
    public class SqlCommand : Task
    {
        public string ConnectionString { get; set; }
        public SqlStatement Statement { get; set; }

        protected override object OnExecute()
        {
            var command = Convert.ToString(Input);

            if (string.IsNullOrEmpty(command))
                throw new Exception("No command");
            
            return ExecuteCommand(ConnectionString, command);
        }

        private object ExecuteCommand(string connectionString, string command /*, CommandType commandType*/)
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString) || string.IsNullOrEmpty(command))
                    return 0;

                using (var connection = new SqlConnection(connectionString))
                {
                    using (var cmd = new System.Data.SqlClient.SqlCommand(command, connection))
                    {
                        //cmd.CommandType = commandType;
                        connection.Open();

                        if (Statement == SqlStatement.Select)
                        {
                            var dataSet = new DataSet();
                            var da = new SqlDataAdapter(cmd);
                            da.Fill(dataSet);

                            var list = new List<List<object>>();
                            foreach (DataTable table in dataSet.Tables)
                            {
                                var t = new List<object>();
                                foreach (DataRow row in table.Rows)
                                {
                                    t.Add(row.ItemArray);
                                }
                                list.Add(t);
                            }

                            return list;
                        }
                        else
                        {
                            return cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //private void SqlCommandText(string query)
        //{
        //    try
        //    {
        //        using (var connection = new SqlConnection(ConnectionString))
        //        using (var command = new System.Data.SqlClient.SqlCommand(query, connection))
        //        {
        //            command.CommandType = System.Data.CommandType.Text;
        //            connection.Open();

        //            if (Statement == SqlStatement.Select)
        //            {
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        //TODO...
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //private void SqlCommandStoredProcedure(List<Parameter> parameters)
        //{
        //    try
        //    {
        //        using (var connection = new SqlConnection(ConnectionString))
        //        using (var command = new System.Data.SqlClient.SqlCommand(StoredProcedureName, connection))
        //        {
        //            command.CommandType = System.Data.CommandType.StoredProcedure;

        //            foreach (var p in parameters)
        //            {
        //                command.Parameters.AddWithValue(p.Name, p.Value);
        //            }

        //            connection.Open();
        //            if (Statement == SqlStatement.Select)
        //            {
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        //TODO...
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //private void SqlCommandTableDirect()
        //{
        //    try
        //    {
        //        using (var connection = new OleDbConnection(ConnectionString))
        //        using (var command = new System.Data.SqlClient.SqlCommand(StoredProcedureName, connection))
        //        {
        //            command.CommandType = System.Data.CommandType.TableDirect;
        //            command.CommandText = "Sales.Store";

        //            //foreach (var p in parameters)
        //            //{
        //            //    command.Parameters.AddWithValue(p.Name, p.Value);
        //            //}

        //            connection.Open();
        //            if (Statement == SqlStatement.Select)
        //            {
        //                SqlDataReader reader = command.ExecuteReader();
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        //TODO...
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                command.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
    
    public enum SqlStatement
    {
        Select,
        Update,
        Delete
    }
}
