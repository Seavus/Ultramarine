using System.Collections.Generic;
using System.Composition;
using System.Data;
using Ultramarine.Generators.Tasks.Library.Contracts;
using System.Data.SqlClient;
using System.Collections;

namespace Ultramarine.Generators.Tasks
{
    /// <summary>
    /// Executes a SQL command or a query
    /// </summary>
    [Export(typeof(Task))]
    public class SqlCommand : Task
    {
        private string _connectionString;
        private string _statement;

        /// <summary>
        /// SQL connection string
        /// <para>This property supports Variables</para>
        /// </summary>
        public string ConnectionString { get => TryGetSettingValue(_connectionString) as string; set => _connectionString = value; }
        
        /// <summary>
        /// Statement to execute
        /// <para>This property supports Variables</para>
        /// </summary>
        public string Statement { get => TryGetSettingValue(_statement) as string; set => _statement = value; }

        /// <summary>
        /// Command type
        /// <seealso cref="System.Data.CommandType"/>
        /// <para>Defaults to Text</para>
        /// </summary>
        public CommandType CommandType { get; set; } = CommandType.Text;
        
        /// <summary>
        /// Query type - shapes the type of a result
        /// </summary>
        public QueryType QueryType { get; set; } = QueryType.Reader;

        protected override ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                return new ValidationResult(nameof(ConnectionString), "Connection string has not been specified.");
            if (string.IsNullOrWhiteSpace(Statement) && Input == null)
                return new ValidationResult(nameof(Statement), "SQL statement has not been specified.");
            return base.Validate();
        }

        protected override object OnExecute()
        {
            return ExecuteCommand(ConnectionString, Statement, CommandType, QueryType);
        }

        private object ExecuteCommand(string connectionString, string statement, CommandType commandType, QueryType queryType)
        {
            object data = null;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new System.Data.SqlClient.SqlCommand(statement, connection))
                {
                    command.CommandType = commandType;
                    connection.Open();
                    switch (queryType)
                    {
                        case QueryType.NonQuery:
                            data = command.ExecuteNonQuery();
                            break;
                        case QueryType.Scalar:
                            data = command.ExecuteScalar();
                            break;
                        default:
                            var reader = command.ExecuteReader();
                            data = ExtractResult(reader);
                            break;

                    }
                    connection.Close();
                    return data;
                }
            }
        }

        private object ExtractResult(SqlDataReader reader)
        {
            var resultArray = new ArrayList();
            do
            {
                var table = new List<List<object>>();
                var count = reader.FieldCount;
                while (reader.Read())
                {
                    var row = new List<object>();
                    for (var i = 0; i < count; i++)
                    {
                        var cell = new
                        {
                            Name = reader.GetName(i),
                            Value = reader.GetValue(i),
                            Type = reader.GetFieldType(i)
                        };
                        row.Add(cell);
                    }
                    table.Add(row);

                }
                if (table.Count > 0)
                    resultArray.Add(table);

            } while (reader.NextResult());

            return resultArray;
        }

    }

    public enum QueryType
    {
        Reader,
        NonQuery,
        Scalar
    }

}
