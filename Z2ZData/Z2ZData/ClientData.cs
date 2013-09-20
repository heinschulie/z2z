using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Zephry;

namespace Z2Z
{
    public class ClientData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Client"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL(bool aIncludeAvatar)
        {
            string vAvatar = aIncludeAvatar ? ", t1.CLN_Avatar" : String.Empty;
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.CLN_Key, t1.CLN_Password, t1.CLN_Name, t1.CLN_Email,");
            vStringBuilder.AppendFormat("       t1.CLN_Contact{0}", vAvatar).AppendLine();
            vStringBuilder.AppendLine("from   CLN_Client t1");

            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Client"/> object.
        /// </summary>
        /// <param name="aClient">A <see cref="Client"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Client aClient, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aClient.ClnKey = Convert.ToInt32(aSqlDataReader["CLN_Key"]);
            aClient.ClnPassword = Convert.ToString(aSqlDataReader["CLN_Password"]);
            aClient.ClnName = Convert.ToString(aSqlDataReader["CLN_Name"]);
            aClient.ClnEmail = Convert.ToString(aSqlDataReader["CLN_Email"]);
            if (aIncludeAvatar)
            {
                aClient.ClnAvatar = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["CLN_Avatar"], null);
            }
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Client"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aClient">A <see cref="Client"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Client aClient)
        {

            aSqlCommand.Parameters.AddWithValue("@CLNPassword", aClient.ClnPassword);
            aSqlCommand.Parameters.AddWithValue("@CLNName", aClient.ClnName);
            aSqlCommand.Parameters.AddWithValue("@CLNEmail", aClient.ClnEmail);
            aSqlCommand.Parameters.AddWithValue("@CLNContact", aClient.ClnContact);

            if (aClient.ClnAvatar == null)
            {
                aSqlCommand.Parameters.Add("@CLNAvatar", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@CLNAvatar", aClient.ClnAvatar);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>ClientList</c> property a <see cref="ClientCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Client"/>, filtered by the filter properties of the passed <see cref="ClientCollection"/>.
        /// </summary>
        /// <param name="aClientCollection">The <see cref="ClientCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="ClientCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aClientCollection</c> argument is <c>null</c>.</exception>
        public static void Load(ClientCollection aClientCollection)
        {
            if (aClientCollection == null)
            {
                throw new ArgumentNullException("aClientCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(false);
                vStringBuilder.AppendLine("order by t1.CLN_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vClient = new Client();
                        DataToObject(vClient, vSqlDataReader, false);
                        aClientCollection.ClientList.Add(vClient);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load by Key

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Client"/>, with keys in the <c>aClient</c> argument.
        /// </summary>
        /// <param name="aClient">A <see cref="Client"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aClient</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Client aClient)
        {
            if (aClient == null)
            {
                throw new ArgumentNullException("aClient");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(true);
                vStringBuilder.AppendLine("where t1.CLN_Key = @CLNKey");
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aClient.ClnKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Client not found: CLN_Key = {0}", aClient.ClnKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aClient, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Client"/> passed as an argument via Stored Procedure that returns the newly inserted Client Key 
        /// </summary>
        /// <param name="aClient">A <see cref="Client"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aClient</c> argument is <c>null</c>.</exception>
        public static void Insert(Client aClient)
        {
            if (aClient == null)
            {
                throw new ArgumentNullException("aClient");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into CLN_Client");
                vStringBuilder.AppendLine("       (CLN_Password, CLN_Name, CLN_Email,");
                vStringBuilder.AppendLine("        CLN_Contact, CLN_Avatar)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CLNPassword, @CLNName, @CLNEmail,");
                vStringBuilder.AppendLine("        @CLNContact, @CLNAvatar)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aClient);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aClient.ClnKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Client"/> passed as an argument .
        /// </summary>
        /// <param name="aClient">A <see cref="Client"/>.</param>
        public static void Update(Client aClient)
        {
            if (aClient == null)
            {
                throw new ArgumentNullException("aClient");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update CLN_Client");
                vStringBuilder.AppendLine("set    CLN_Password = @CLNPassword,");
                vStringBuilder.AppendLine("       CLN_Name = @CLNName,");
                vStringBuilder.AppendLine("       CLN_Email = @CLNEmail,");
                vStringBuilder.AppendLine("       CLN_Contact = @CLNContact,");
                vStringBuilder.AppendLine("       CLN_Avatar = @CLNAvatar");
                vStringBuilder.AppendLine("where  CLN_Key = @CLNKey");
                ObjectToData(vSqlCommand, aClient);
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aClient.ClnKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Client"/> object passed as an argument.
        /// </summary>
        /// <param name="aClient">The <see cref="Client"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aClient</c> argument is <c>null</c>.</exception>
        public static void Delete(Client aClient)
        {
            if (aClient == null)
            {
                throw new ArgumentNullException("aClient");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete CLN_Client");
                vStringBuilder.AppendLine("where  CLN_Key = @CLNKey");
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aClient.ClnKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
