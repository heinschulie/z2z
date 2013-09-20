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
    public class JobTypeData
    {

        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="JobType"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL(bool aIncludeAvatar)
        {
            string vAvatar = aIncludeAvatar ? ", JBT_Avatar" : String.Empty;
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendFormat("select JBT_Key, JBT_Type", vAvatar).AppendLine();
            vStringBuilder.AppendLine("from   JBT_JobType");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="JobType"/> object.
        /// </summary>
        /// <param name="aJobType">A <see cref="JobType"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(JobType aJobType, SqlDataReader aSqlDataReader, bool aIncludeAvatar)
        {
            aJobType.JbtKey = Convert.ToInt32(aSqlDataReader["JBT_Key"]);
            aJobType.JbtType = Convert.ToString(aSqlDataReader["JBT_Type"]);
            if (aIncludeAvatar)
            {
                aJobType.JbtAvatar = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["JBT_Avatar"], null);
            }
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="JobType"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aJobType">A <see cref="JobType"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, JobType aJobType)
        {

            aSqlCommand.Parameters.AddWithValue("@JBTType", aJobType.JbtType);
            if (aJobType.JbtAvatar == null)
            {
                aSqlCommand.Parameters.Add("@JBTAvatar", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@JBTAvatar", aJobType.JbtAvatar);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>JobTypeList</c> property a <see cref="JobTypeCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="JobType"/>, filtered by the filter properties of the passed <see cref="JobTypeCollection"/>.
        /// </summary>
        /// <param name="aJobTypeCollection">The <see cref="JobTypeCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="JobTypeCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aJobTypeCollection</c> argument is <c>null</c>.</exception>
        public static void Load(JobTypeCollection aJobTypeCollection)
        {
            if (aJobTypeCollection == null)
            {
                throw new ArgumentNullException("aJobTypeCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(false);
                vStringBuilder.AppendLine("order by JBT_Type");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vJobType = new JobType();
                        DataToObject(vJobType, vSqlDataReader, false);
                        aJobTypeCollection.JobTypeList.Add(vJobType);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="JobType"/>, with keys in the <c>aJobType</c> argument.
        /// </summary>
        /// <param name="aJobType">A <see cref="JobType"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobType</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(JobType aJobType)
        {
            if (aJobType == null)
            {
                throw new ArgumentNullException("aJobType");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL(true);
                vStringBuilder.AppendLine("where JBT_Key = @JBTKey");
                vSqlCommand.Parameters.AddWithValue("@JBTKey", aJobType.JbtKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected JobType not found: JBT_Key = {0}", aJobType.JbtKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aJobType, vSqlDataReader, true);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="JobType"/> passed as an argument via Stored Procedure that returns the newly inserted JobType Key 
        /// </summary>
        /// <param name="aJobType">A <see cref="JobType"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobType</c> argument is <c>null</c>.</exception>
        public static void Insert(JobType aJobType)
        {
            if (aJobType == null)
            {
                throw new ArgumentNullException("aJobType");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into JBT_JobType");
                vStringBuilder.AppendLine("       (JBT_Type, JBT_Avatar)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@JBTType, @JBTAvatar)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aJobType);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aJobType.JbtKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="JobType"/> passed as an argument .
        /// </summary>
        /// <param name="aJobType">A <see cref="JobType"/>.</param>
        public static void Update(JobType aJobType)
        {
            if (aJobType == null)
            {
                throw new ArgumentNullException("aJobType");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update JBT_JobType");
                vStringBuilder.AppendLine("set    JBT_Type = @JBTType,");
                vStringBuilder.AppendLine("       JBT_Code = @JBTCode,");
                vStringBuilder.AppendLine("       JBT_Avatar = @JBTAvatar");
                vStringBuilder.AppendLine("where  JBT_Key = @JBTKey");
                ObjectToData(vSqlCommand, aJobType);
                vSqlCommand.Parameters.AddWithValue("@JBTKey", aJobType.JbtKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="JobType"/> object passed as an argument.
        /// </summary>
        /// <param name="aJobType">The <see cref="JobType"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobType</c> argument is <c>null</c>.</exception>
        public static void Delete(JobType aJobType)
        {
            if (aJobType == null)
            {
                throw new ArgumentNullException("aJobType");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete JBT_JobType");
                vStringBuilder.AppendLine("where  JBT_Key = @JBTKey");
                vSqlCommand.Parameters.AddWithValue("@JBTKey", aJobType.JbtKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                try
                {
                    vSqlCommand.Connection.Open();
                    vSqlCommand.ExecuteNonQuery();
                    vSqlCommand.Connection.Close();
                }
                catch (SqlException sx)
                {
                    if (sx.Class == 16)
                    {
                        TransactionStatus vTransactionStatus = new TransactionStatus();
                        vTransactionStatus.TransactionResult = TransactionResult.SqlException;
                        vTransactionStatus.SourceAssembly = SourceAssembly.Data;
                        vTransactionStatus.Message = "One does not simply delete this item...";
                        vTransactionStatus.InnerMessage = "In order to delete this item please ensure all its dependancies are deleted first.";
                        TransactionStatusException vX = new TransactionStatusException(vTransactionStatus);
                        throw vX;
                    }
                    else
                    {
                        throw sx;
                    }
                }
            }
        }

        #endregion
    }
}
