using System.Data;
using System.Data.Common;
using System.IO;
using System.Text;
using kkkkkkaaaaaa.Data.Common;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.Data.Repositories;
using kkkkkkaaaaaa.VisualStudio.TextTemplating.DomainModels;
using Xunit;

namespace kkkkkkaaaaaa.VisualStudio.TextTemplating.Xunit
{
    public class Db3Facts : TextTemplatingFacts
    {
        [Fact()]
        public void TablesFact()
        {
            var connection = this.Factory.CreateConnection();
            var reader = default(DbDataReader);

            try
            {
                connection.Open();
                reader = this.Factory.CreateReader(connection);

                var schema = new SchemaRepository();
                var tables = schema.GetTablesSchema(connection);
                
                var builder = new StringBuilder();
                builder.AppendLine(@"|:---|");
                foreach (var table in tables)
                {
                    builder.AppendLine($@"|{table.TableName}|");
                }

                var stream = default(TextWriter);
                try
                {
                    var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
                    Directory.CreateDirectory(output);
                    stream = new StreamWriter(Path.Combine(output, @"tables.txt"), false, new UTF8Encoding(true, true));
                    stream.Write(builder.ToString());
                    stream.Flush();
                    
                    TextTemplatingProcess.StartExplorer(output);
                }
                finally
                {
                    if (stream != null) { stream.Close(); }
                }
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }

        [Fact()]
        public void TableFact()
        {
            var output = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var connection = this.Factory.CreateConnection();
            var reader = default(KandaDbDataReader);

            try
            {
                connection.Open();
                reader = this.Factory.CreateReader(connection);

                var schema = new SchemaRepository();
                var tables = schema.GetTablesSchema(connection);

                foreach (var table in tables)
                {
                    var builder = new StringBuilder();
                    var columns = schema.GetColumnsSchema(table.TableName, connection);
                    
                    foreach (var column in columns)
                    {
                        builder.Append($@"|{column.ColumnName}");
                    }
                    builder.AppendLine(@"|");

                    reader.CommandText = $@"SELECT * FROM {table.TableName} WHERE 1 = 1";
                    reader.CommandType = CommandType.Text;
                    reader.ExecuteReader();

                    while (reader.Read())
                    {
                        foreach (var column in columns)
                        {
                            builder.Append($@"|{reader[column.ColumnName]}");
                        }
                        builder.AppendLine(@"|");
                    }
                    reader.Close();

                    var stream = default(TextWriter);
                    try
                    {
                        Directory.CreateDirectory(output);
                        stream = new StreamWriter(Path.Combine(output, $@"{table.TableName}.txt"), false, new UTF8Encoding(true, true));
                        stream.Write(builder.ToString());
                        stream.Flush();
                    }
                    finally
                    {
                        if (stream != null) { stream.Close(); }
                    }
                }
                TextTemplatingProcess.StartExplorer(output);
            }
            finally
            {
                if (reader != null) { reader.Close(); }
                if (connection != null) { connection.Close(); }
            }
        }
    }
}
