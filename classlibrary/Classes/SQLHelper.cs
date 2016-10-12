/*
 * This class is to remove the strain from the SQL database and have one place to everything SQL related. 
 * Queries will also be built dynamically to avoid re-using to much code.
 */

using System;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary.Classes
{
    public class SQLHelper
    {
        #region Variables

        private static string _serverName;
        private static string _databaseName;
        private static string _userName;
        private static string _password;

        public static string[] _queryFields;
        public static string[] _queryInsertFields;
        public static string _fromTable;
        public static string[] _queryjoinTables;
        public static string[] _queryWhereCondition;
        public static string[] _queryOrderBy;
        public static string[] _queryGroupBy;

        #endregion Variables

        #region Constructor

        // string serverName: The name of the server to connect in SQL
        // string databaseName: The name of the database to connect in SQL
        // string userName: The username to connect to SQL
        // string password: The password to connect to SQL
        public SQLHelper(string userName, string password, string serverName, string databaseName)
        {
            _serverName = serverName;
            _databaseName = databaseName;
            _userName = userName;
            _password = password;
        }

        #endregion Constructor

        #region SQL Connections

        // Function that creates the connection to the SQL database
        private static SqlConnection SQLConnect()
        {
            return new SqlConnection("Data Source=" + _serverName + ";Initial Catalog=" +
                                                    _databaseName + ";User ID=" + _userName + ";Password=" + _password);
        }

        private static SqlCommand SQLCommand(string query)
        {
            return new SqlCommand(query, SQLConnect());
        }

        #endregion SQL Connections

        #region SQL Database Calls

        // Function that retrieves a list of data from the database and returns this information in a datatable
        public static DataTable GetList(string query)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(SQLCommand(query)))
                dataAdapter.Fill(dt);

            return dt;
        }

        #endregion SQL Database Calls

        #region SQL Queries

        // A function that creates the different types of queries and returns the string
        public static string CreateQuery(string queryType)
        {
            string query = "";

            switch (queryType)
            {
                case "Select":
                    query = "SELECT " + SelectInsertUpdateFieldsCreate() +
                            "FROM " + _fromTable +
                            JoinsCreate() +
                            WhereCreate() +
                            OrderByCreate() +
                            GroupByCreate();
                    break;

                case "Insert":
                    query = "INSERT INTO (" +
                            SelectInsertUpdateFieldsCreate() +
                            ") VALUES (" +
                            InsertValuesCreate() +
                            WhereCreate();
                    break;

                case "Update":
                    query = "UPDATE " + _fromTable +
                            "SET " + SelectInsertUpdateFieldsCreate() +
                            WhereCreate();
                    break;

                case "Delete":
                    query = "DELETE FROM " + _fromTable +
                            WhereCreate();
                    break;
            }

            return query;
        }

        // SELECT <fields>: Comma seperated string (field1, field2, field3)
        // INSERT INTO (<fields>): Comma seperated string (field1, field2, field3)
        // UPDATE <table> SET <fields> = <values>: Comma seperated string with values (field1 = value1, field2 = value2, field3 = value3)
        private static string SelectInsertUpdateFieldsCreate()
        {
            string query = "";
            for (int i = 0; i <= _queryFields.Length - 1; i++)
            {
                if (i == _queryFields.Length - 1)
                {
                    query = query + _queryFields[i];
                }
                else
                {
                    query = query + _queryFields[i] + ",";
                }
            }
            return query + Environment.NewLine;
        }

        // INSERT INTO <fields> VALUES <values>: Comma seperated string with values (value1, value2, value3)
        private static string InsertValuesCreate()
        {
            string query = "";
            for (int i = 0; i <= _queryInsertFields.Length - 1; i++)
            {
                if (i == _queryInsertFields.Length - 1)
                {
                    query = query + _queryInsertFields[i];
                }
                else
                {
                    query = query + _queryInsertFields[i] + ",";
                }
            }
            return query + Environment.NewLine;
        }

        // Creates all the different types of JOINS from an array into a string
        // INNER JOIN <table> ON <field1> = <field2> / LEFT INNER JOIN <table> ON <field1> = <field2> / RIGHT INNER JOIN <table> ON <field1> = <field2>
        // OUTER JOIN <table> ON <field1> = <field2> / LEFT OUTER JOIN <table> ON <field1> = <field2> / RIGHT OUTER JOIN <table> ON <field1> = <field2>
        private static string JoinsCreate()
        {
            string query = "";

            // Tables with different join types
            if (_queryjoinTables != null)
            {
                for (int i = 0; i <= _queryjoinTables.Length - 1; i++)
                {
                    query = query + " " + _queryjoinTables[i] + Environment.NewLine;
                }
            }

            return query;
        }

        // Creates the different WHERE conditions from an array into a string
        // WHERE <field> = <text> AND <field> = <number>
        private static string WhereCreate()
        {
            string query = "";

            if (_queryWhereCondition != null)
            {
                query = "WHERE ";
                for (int i = 0; i <= _queryWhereCondition.Length - 1; i++)
                {
                    query = query + _queryWhereCondition[i];
                }
            }

            return query + Environment.NewLine;
        }

        // ORDER BY <fields>: Comma seperated string (field1, field2, field3)
        private static string OrderByCreate()
        {
            string query = "";

            if (_queryOrderBy != null)
            {
                query = "ORDER BY ";
                for (int i = 0; i <= _queryOrderBy.Length - 1; i++)
                {
                    if (i == _queryOrderBy.Length - 1)
                    {
                        query = query + _queryOrderBy[i] + Environment.NewLine;
                    }
                    else
                    {
                        query = query + _queryOrderBy[i] + ",";
                    }
                }
            }

            return query;
        }

        // GROUP BY <fields>: Comma seperated string (field1, field2, field3)
        private static string GroupByCreate()
        {
            string query = "";

            // ORDER BY condition
            if (_queryGroupBy != null)
            {
                query = "GROUP BY ";
                for (int i = 0; i <= _queryGroupBy.Length - 1; i++)
                {
                    if (i == _queryGroupBy.Length - 1)
                    {
                        query = query + _queryGroupBy[i] + Environment.NewLine;
                    }
                    else
                    {
                        query = query + _queryGroupBy[i] + ",";
                    }
                }
            }

            return query;
        }

        #endregion SQL Queries
    }
}