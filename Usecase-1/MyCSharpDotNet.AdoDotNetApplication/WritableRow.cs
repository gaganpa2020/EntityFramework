using System;
using System.Data.SqlClient;

namespace MyCSharpDotNet.AdoDotNetApplication
{
    class WritableRow
    {
        Guid id;
        DateTime dateTime;
        string text;
        string nickname;

        // Private constructor can be used only from within the class
        // It is used by the public constructor as well as by the static method
        // to load the data from the database
        private WritableRow(
            Guid id,
            DateTime dateTime,
            string text,
            string nickname)
        {
            this.id = id;
            this.dateTime = dateTime;
            this.text = text;
            this.nickname = nickname;
        }

        public WritableRow(
            string text,
            string nickname)
            : this(Guid.NewGuid(), DateTime.Now, text, nickname)
        {
        }

        public void Save()
        {
            string queryString =
                "INSERT " +
                    "INTO WritableRows " +
                    "VALUES (@WritableRowID, @DateTime, @Text, @Nickname)";

            using (SqlConnection sqlConnection =
                new SqlConnection(Tools.ConnectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand(queryString, sqlConnection);

                SqlParameter writableRowIDSqlParameter =
                    sqlCommand.CreateParameter();
                writableRowIDSqlParameter.ParameterName = "WritableRowID";
                writableRowIDSqlParameter.Value = id;
                sqlCommand.Parameters.Add(writableRowIDSqlParameter);

                SqlParameter dateTimeSqlParameter =
                    sqlCommand.CreateParameter();
                dateTimeSqlParameter.ParameterName = "DateTime";
                dateTimeSqlParameter.Value = dateTime;
                sqlCommand.Parameters.Add(dateTimeSqlParameter);

                SqlParameter textSqlParameter =
                    sqlCommand.CreateParameter();
                textSqlParameter.ParameterName = "Text";
                textSqlParameter.Value = text;
                sqlCommand.Parameters.Add(textSqlParameter);

                SqlParameter nicknameSqlParameter =
                    sqlCommand.CreateParameter();
                nicknameSqlParameter.ParameterName = "Nickname";
                nicknameSqlParameter.Value = nickname;
                sqlCommand.Parameters.Add(nicknameSqlParameter);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            string queryString =
                "DELETE " +
                    "FROM WritableRows " +
                    "WHERE WritableRowID = @WritableRowID";

            using (SqlConnection sqlConnection =
                new SqlConnection(Tools.ConnectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand(queryString, sqlConnection);

                SqlParameter writableRowIDSqlParameter =
                    sqlCommand.CreateParameter();
                writableRowIDSqlParameter.ParameterName = "WritableRowID";
                writableRowIDSqlParameter.Value = id;
                sqlCommand.Parameters.Add(writableRowIDSqlParameter);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();
            }
        }

        public override string ToString()
        {
            string cr = Environment.NewLine;

            return
                "WritableRowID : " + id + cr +
                "DateTime      : " + dateTime + cr +
                "Text          : " + text + cr +
                "Nickname      : " + nickname;
        }

        public static WritableRow GetMostRecent()
        {
            WritableRow writableRowResult = null;

            string queryString =
                "SELECT TOP 1 * " +
                    "FROM WritableRows " +
                    "ORDER BY DateTime DESC";

            using (SqlConnection sqlConnection =
                new SqlConnection(Tools.ConnectionString))
            {
                SqlCommand sqlCommand =
                    new SqlCommand(queryString, sqlConnection);

                sqlConnection.Open();

                EnhancedSqlDataReader enhancedSqlDataReader =
                    new EnhancedSqlDataReader(sqlCommand.ExecuteReader());

                if (enhancedSqlDataReader.Read())
                {
                    writableRowResult = new WritableRow(
                        enhancedSqlDataReader.GetGuid("WritableRowID"),
                        enhancedSqlDataReader.GetDateTime("DateTime"),
                        enhancedSqlDataReader.GetString("Text"),
                        enhancedSqlDataReader.GetString("Nickname")
                        );
                }

                enhancedSqlDataReader.Close();
            }

            return writableRowResult;
        }
    }
}
