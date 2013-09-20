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
    public class ContributorData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Contributor"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.CON_Key, t1.CON_Name, t1.CON_Surname, t1.CON_Contact, t1.CON_Email, t1.CON_Password");
            vStringBuilder.AppendLine("from   CON_Contributor t1");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Contributor"/> object.
        /// </summary>
        /// <param name="aContributor">A <see cref="Contributor"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Contributor aContributor, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aContributor.ConKey = Convert.ToInt32(aSqlDataReader["CON_Key"]);
            aContributor.ConName = Convert.ToString(aSqlDataReader["CON_Name"]);
            aContributor.ConSurname = Convert.ToString(aSqlDataReader["CON_Surname"]);
            aContributor.ConEmail = Convert.ToString(aSqlDataReader["CON_Email"]);
            aContributor.ConPassword = Convert.ToString(aSqlDataReader["CON_Password"]);
            aContributor.ConContact = Convert.ToString(aSqlDataReader["CON_Contact"]);
            if (aIncludeAvatar)
            {
                aContributor.ConAvatar = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["CON_Avatar"], null);
            }            
        }

        #endregion


        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>ContributorList</c> property a <see cref="ContributorCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Contributor"/>, filtered by the filter properties of the passed <see cref="ContributorCollection"/>.
        /// </summary>
        /// <param name="aContributorCollection">The <see cref="ContributorCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="ContributorCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aContributorCollection</c> argument is <c>null</c>.</exception>
        public static void Load(ContributorCollection aContributorCollection)
        {
            if (aContributorCollection == null)
            {
                throw new ArgumentNullException("aContributorCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aContributorCollection.ContributorFilter.IsFiltered)
                {
                    vStringBuilder.AppendLine("     , CTL_ContributorLanguage t2");
                    vStringBuilder.AppendLine("where  t1.CON_Key = t2.CON_Key");
                    vStringBuilder.AppendLine("and    t2.LAN_Key = @LANKEY");
                    vStringBuilder.AppendLine("and    t2.CTL_Rating >= @CTLRating");
                    vSqlCommand.Parameters.AddWithValue("@LANKEY", aContributorCollection.ContributorFilter.LanguageFilter);
                    vSqlCommand.Parameters.AddWithValue("@CTLRating", aContributorCollection.ContributorFilter.RatingFilter);
                    vStringBuilder.AppendLine("order by t2.CTL_Rating");
                }
                else
                {
                    vStringBuilder.AppendLine("order by t1.CON_Surname");
                }
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vContributor = new Contributor();
                        DataToObject(vContributor, vSqlDataReader, false);
                        aContributorCollection.ContributorList.Add(vContributor);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion


        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Contributor"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aContributor">A <see cref="Contributor"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Contributor aContributor)
        {            
            aSqlCommand.Parameters.AddWithValue("@CONName", aContributor.ConName);
            aSqlCommand.Parameters.AddWithValue("@CONSurname", aContributor.ConSurname);
            aSqlCommand.Parameters.AddWithValue("@CONEmail", aContributor.ConEmail);
            aSqlCommand.Parameters.AddWithValue("@CONContact", aContributor.ConContact);
            aSqlCommand.Parameters.AddWithValue("@CONPassword", aContributor.ConPassword);
            if (aContributor.ConAvatar == null)
            {
                aSqlCommand.Parameters.Add("@CONAvatar", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@CONAvatar", aContributor.ConAvatar);
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Contributor"/>, with keys in the <c>aContributor</c> argument.
        /// </summary>
        /// <param name="aContributor">A <see cref="Contributor"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributor</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Contributor aContributor)
        {
            if (aContributor == null)
            {
                throw new ArgumentNullException("aContributor");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("where    t1.CON_Key = @CONKey");
                vSqlCommand.Parameters.AddWithValue("@CONKey", aContributor.ConKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Contributor not found: CON_Key = {0}", aContributor.ConKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aContributor, vSqlDataReader, false);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Contributor"/> passed as an argument via Stored Procedure that returns the newly inserted Contributor Key 
        /// </summary>
        /// <param name="aContributor">A <see cref="Contributor"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributor</c> argument is <c>null</c>.</exception>
        public static void Insert(Contributor aContributor)
        {
            if (aContributor == null)
            {
                throw new ArgumentNullException("aContributor");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into CON_Contributor");
                vStringBuilder.AppendLine("       (CON_Name, CON_Surname, CON_Contact, CON_Email, CON_Avatar, CON_Password)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CONName, @CONSurname, @CONContact, @CONEmail, @CONAvatar, @CONPassword)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aContributor);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aContributor.ConKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Contributor"/> passed as an argument .
        /// </summary>
        /// <param name="aContributor">A <see cref="Contributor"/>.</param>
        public static void Update(Contributor aContributor)
        {
            if (aContributor == null)
            {
                throw new ArgumentNullException("aContributor");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update CON_Contributor");
                vStringBuilder.AppendLine("set    CON_Name = @CONName,");
                vStringBuilder.AppendLine("       CON_Surname = @CONSurname,");
                vStringBuilder.AppendLine("       CON_Contact = @CONContact,");
                vStringBuilder.AppendLine("       CON_Email = @CONEmail");
                vStringBuilder.AppendLine("where  CON_Key = @CONKey");
                ObjectToData(vSqlCommand, aContributor);
                vSqlCommand.Parameters.AddWithValue("@CONKey", aContributor.ConKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Advertiser"/> object passed as an argument.
        /// </summary>
        /// <param name="aAdvertiser">The <see cref="Advertiser"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aAdvertiser</c> argument is <c>null</c>.</exception>
        public static void Delete(Contributor aContributor)
        {
            if (aContributor == null)
            {
                throw new ArgumentNullException("aContributor");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete CON_Contributor");
                vStringBuilder.AppendLine("where  CON_Key = @CONKey");
                vSqlCommand.Parameters.AddWithValue("@CONKey", aContributor.ConKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }
        #endregion
    }
}
