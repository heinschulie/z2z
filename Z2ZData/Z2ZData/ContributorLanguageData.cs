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
    public class ContributorLanguageData
    {

        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="ContributorLanguage"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select contributor.CON_Key, contributor.CON_Name, lang.LAN_Key,");
            vStringBuilder.AppendLine("       lang.LAN_Name, lang.LAN_EnglishName, contributorlanguage.CTL_Rating");
            vStringBuilder.AppendLine("from   CON_Contributor contributor,");
            vStringBuilder.AppendLine("       CTL_ContributorLanguage contributorlanguage,");
            vStringBuilder.AppendLine("       LAN_Language lang");
            vStringBuilder.AppendLine("where  contributor.CON_Key = contributorlanguage.CON_Key");
            vStringBuilder.AppendLine("and    contributorlanguage.LAN_Key = lang.LAN_Key");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="ContributorLanguage"/> object.
        /// </summary>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(ContributorLanguage aContributorLanguage, SqlDataReader aSqlDataReader)
        {
            aContributorLanguage.ConKey = Convert.ToInt32(aSqlDataReader["CON_Key"]);
            aContributorLanguage.LanKey = Convert.ToInt32(aSqlDataReader["LAN_Key"]);
            aContributorLanguage.Rating = (LanguageLevelRating)(Convert.ToInt32(aSqlDataReader["CTL_Rating"]));
            aContributorLanguage.LanguageName = Convert.ToString(aSqlDataReader["LAN_Name"]);
            aContributorLanguage.LanguageName = Convert.ToString(aSqlDataReader["LAN_EnglishName"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="ContributorLanguage"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, ContributorLanguage aContributorLanguage)
        {
            aSqlCommand.Parameters.AddWithValue("@CTLRating", aContributorLanguage.Rating);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>ContributorLanguageList</c> property a <see cref="ContributorLanguageCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="ContributorLanguage"/>, filtered by the filter properties of the passed <see cref="ContributorLanguageCollection"/>.
        /// </summary>
        /// <param name="aContributorLanguageCollection">The <see cref="ContributorLanguageCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="ContributorLanguageCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguageCollection</c> argument is <c>null</c>.</exception>
        public static void Load(ContributorLanguageCollection aContributorLanguageCollection)
        {
            if (aContributorLanguageCollection == null)
            {
                throw new ArgumentNullException("aContributorLanguageCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aContributorLanguageCollection.ContributorLanguageFilter.IsFiltered)
                {
                    if (aContributorLanguageCollection.ContributorLanguageFilter.ContributorKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    contributorlanguage.CON_Key = @CONKey");
                        vSqlCommand.Parameters.AddWithValue("@CONKey", aContributorLanguageCollection.ContributorLanguageFilter.ContributorKeyFilter);
                    }
                    if (aContributorLanguageCollection.ContributorLanguageFilter.ContributorKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    contributorlanguage.LAN_Key = @LANKey");
                        vSqlCommand.Parameters.AddWithValue("@LANKey", aContributorLanguageCollection.ContributorLanguageFilter.LanguageKeyFilter);
                    }
                }

                vStringBuilder.AppendLine("order by LAN_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vContributorLanguage = new ContributorLanguage();
                        DataToObject(vContributorLanguage, vSqlDataReader);
                        aContributorLanguageCollection.ContributorLanguageList.Add(vContributorLanguage);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="ContributorLanguage"/>, with keys in the <c>aContributorLanguage</c> argument.
        /// </summary>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguage</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(ContributorLanguage aContributorLanguage)
        {
            if (aContributorLanguage == null)
            {
                throw new ArgumentNullException("aContributorLanguage");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and    contributor.CON_Key = @CONKey");
                vStringBuilder.AppendLine("and    contributorlanguage.LAN_Key = @LANKey");
                vSqlCommand.Parameters.AddWithValue("@CONKey", aContributorLanguage.ConKey);
                vSqlCommand.Parameters.AddWithValue("@LANKey", aContributorLanguage.LanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected ContributorLanguage not found: CON_Key = {0}, LAN_Key = {1}", aContributorLanguage.ConKey, aContributorLanguage.LanKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aContributorLanguage, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="ContributorLanguage"/> passed as an argument via Stored Procedure that returns the newly inserted ContributorLanguage Key 
        /// </summary>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguage</c> argument is <c>null</c>.</exception>
        public static void Insert(ContributorLanguage aContributorLanguage)
        {
            if (aContributorLanguage == null)
            {
                throw new ArgumentNullException("aContributorLanguage");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into CTL_ContributorLanguage");
                vStringBuilder.AppendLine("       (CON_Key, LAN_Key, CTL_Rating)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CONKey, @LANKey, @CTLRating)");
                ObjectToData(vSqlCommand, aContributorLanguage);
                vSqlCommand.Parameters.AddWithValue("@CONKey", aContributorLanguage.ConKey);
                vSqlCommand.Parameters.AddWithValue("@LANKey", aContributorLanguage.LanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="ContributorLanguage"/> passed as an argument .
        /// </summary>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/>.</param>
        public static void Update(ContributorLanguage aContributorLanguage)
        {
            if (aContributorLanguage == null)
            {
                throw new ArgumentNullException("aContributorLanguage");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update CTL_ContributorLanguage");
                vStringBuilder.AppendLine("set    CTL_Rating = @CTLRating");
                vStringBuilder.AppendLine("where  CON_Key = @CONKey");
                vStringBuilder.AppendLine("and    LAN_Key = @LANKey");
                ObjectToData(vSqlCommand, aContributorLanguage);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="ContributorLanguage"/> object passed as an argument.
        /// </summary>
        /// <param name="aContributorLanguage">The <see cref="ContributorLanguage"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguage</c> argument is <c>null</c>.</exception>
        public static void Delete(ContributorLanguage aContributorLanguage)
        {
            if (aContributorLanguage == null)
            {
                throw new ArgumentNullException("aContributorLanguage");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete CTL_ContributorLanguage");
                vStringBuilder.AppendLine("where  CON_Key = @CONKey");
                vStringBuilder.AppendLine("and    LAN_Key = @LANKey");
                vSqlCommand.Parameters.AddWithValue("@CONKey", aContributorLanguage.ConKey);
                vSqlCommand.Parameters.AddWithValue("@LANKey", aContributorLanguage.LanKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
