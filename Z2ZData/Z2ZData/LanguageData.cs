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
    public class LanguageData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Language"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.LAN_Key, t1.LAN_Name, t1.LAN_EnglishName");
            vStringBuilder.AppendLine("from   LAN_Language t1");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Language"/> object.
        /// </summary>
        /// <param name="aLanguage">A <see cref="Language"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Language aLanguage, SqlDataReader aSqlDataReader)
        {
            aLanguage.LanKey = Convert.ToInt32(aSqlDataReader["LAN_Key"]);
            aLanguage.LanName = Convert.ToString(aSqlDataReader["LAN_Name"]);
            aLanguage.LanEnglishName = Convert.ToString(aSqlDataReader["LAN_EnglishName"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Language"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aLanguage">A <see cref="Language"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Language aLanguage)
        {
            aSqlCommand.Parameters.AddWithValue("@LANName", aLanguage.LanName);
            aSqlCommand.Parameters.AddWithValue("@LANEnglishName", aLanguage.LanEnglishName);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>LanguageList</c> property a <see cref="LanguageCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Language"/>, filtered by the filter properties of the passed <see cref="LanguageCollection"/>.
        /// </summary>
        /// <param name="aLanguageCollection">The <see cref="LanguageCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="LanguageCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aLanguageCollection</c> argument is <c>null</c>.</exception>
        public static void Load(LanguageCollection aLanguageCollection)
        {
            if (aLanguageCollection == null)
            {
                throw new ArgumentNullException("aLanguageCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();

                vStringBuilder.AppendLine("order by t1.LAN_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vLanguage = new Language();
                        DataToObject(vLanguage, vSqlDataReader);
                        aLanguageCollection.LanguageList.Add(vLanguage);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Language"/>, with keys in the <c>aLanguage</c> argument.
        /// </summary>
        /// <param name="aLanguage">A <see cref="Language"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aLanguage</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Language aLanguage)
        {
            if (aLanguage == null)
            {
                throw new ArgumentNullException("aLanguage");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("where    t1.LAN_Key = @LANKey");
                vSqlCommand.Parameters.AddWithValue("@LANKey", aLanguage.LanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Language not found: LAN_Key = {0}", aLanguage.LanKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aLanguage, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Language"/> passed as an argument via Stored Procedure that returns the newly inserted Language Key 
        /// </summary>
        /// <param name="aLanguage">A <see cref="Language"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aLanguage</c> argument is <c>null</c>.</exception>
        public static void Insert(Language aLanguage)
        {
            if (aLanguage == null)
            {
                throw new ArgumentNullException("aLanguage");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into LAN_Language");
                vStringBuilder.AppendLine("       (LAN_Name, LAN_EnglishName)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@LANName, @LANEnglishName)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aLanguage);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aLanguage.LanKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Language"/> passed as an argument .
        /// </summary>
        /// <param name="aLanguage">A <see cref="Language"/>.</param>
        public static void Update(Language aLanguage)
        {
            if (aLanguage == null)
            {
                throw new ArgumentNullException("aLanguage");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update   LAN_Language");
                vStringBuilder.AppendLine("set      LAN_Name = @LANName,");
                vStringBuilder.AppendLine("         LAN_EnglishName = @LANEnglishName");
                vStringBuilder.AppendLine("where    LAN_Key = @LANKey");
                ObjectToData(vSqlCommand, aLanguage);
                vSqlCommand.Parameters.AddWithValue("@LANKey", aLanguage.LanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Language"/> object passed as an argument.
        /// </summary>
        /// <param name="aLanguage">The <see cref="Language"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aLanguage</c> argument is <c>null</c>.</exception>
        public static void Delete(Language aLanguage)
        {
            if (aLanguage == null)
            {
                throw new ArgumentNullException("aLanguage");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete LAN_Language");
                vStringBuilder.AppendLine("where  LAN_Key = @LANKey");
                vSqlCommand.Parameters.AddWithValue("@LANKey", aLanguage.LanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
