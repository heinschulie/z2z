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
    public class DocumentData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Document"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.CLN_Key, t1.CLN_Name, t2.DOC_Key, t2.DOC_Name");
            vStringBuilder.AppendLine("from   CLN_Client t1,");
            vStringBuilder.AppendLine("       DOC_Document t2");
            vStringBuilder.AppendLine("where  t1.CLN_Key = t2.CLN_Key");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Document"/> object.
        /// </summary>
        /// <param name="aDocument">A <see cref="Document"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Document aDocument, SqlDataReader aSqlDataReader)
        {
            aDocument.ClnKey = Convert.ToInt32(aSqlDataReader["CLN_Key"]);
            aDocument.ClnName = Convert.ToString(aSqlDataReader["CLN_Name"]);
            aDocument.DocKey = Convert.ToInt32(aSqlDataReader["DOC_Key"]);
            aDocument.DocName = Convert.ToString(aSqlDataReader["DOC_Name"]);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Document"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aDocument">A <see cref="Document"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Document aDocument)
        {
            aSqlCommand.Parameters.AddWithValue("@CLNKey", aDocument.ClnKey);
            aSqlCommand.Parameters.AddWithValue("@DOCName", aDocument.DocName);
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>DocumentList</c> property a <see cref="DocumentCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Document"/>, filtered by the filter properties of the passed <see cref="DocumentCollection"/>.
        /// </summary>
        /// <param name="aDocumentCollection">The <see cref="DocumentCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="DocumentCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aDocumentCollection</c> argument is <c>null</c>.</exception>
        public static void Load(DocumentCollection aDocumentCollection)
        {
            if (aDocumentCollection == null)
            {
                throw new ArgumentNullException("aDocumentCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aDocumentCollection.DocumentFilter.IsFiltered)
                {
                    if (aDocumentCollection.DocumentFilter.DocumentClientKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    t1.CLN_Key = @CLNKey");
                        vSqlCommand.Parameters.AddWithValue("@CLNKey", aDocumentCollection.DocumentFilter.DocumentClientKeyFilter);
                    }
                }
                vStringBuilder.AppendLine("order by t2.DOC_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vDocument = new Document();
                        DataToObject(vDocument, vSqlDataReader);
                        aDocumentCollection.DocumentList.Add(vDocument);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Document"/>, with keys in the <c>aDocument</c> argument.
        /// </summary>
        /// <param name="aDocument">A <see cref="Document"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aDocument</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Document aDocument)
        {
            if (aDocument == null)
            {
                throw new ArgumentNullException("aDocument");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and    t1.CLN_Key = @CLNKey");
                vStringBuilder.AppendLine("and    t2.DOC_Key = @DOCKey");
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aDocument.ClnKey);
                vSqlCommand.Parameters.AddWithValue("@DOCKey", aDocument.DocKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Document not found: CLN_Key = {0}, DOC_Key = {1}", aDocument.ClnKey, aDocument.DocKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aDocument, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Document"/> passed as an argument via Stored Procedure that returns the newly inserted Document Key 
        /// </summary>
        /// <param name="aDocument">A <see cref="Document"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aDocument</c> argument is <c>null</c>.</exception>
        public static void Insert(Document aDocument)
        {
            if (aDocument == null)
            {
                throw new ArgumentNullException("aDocument");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into DOC_Document");
                vStringBuilder.AppendLine("       (CLN_Key, DOC_Name)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CLNKey, @DOCName)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aDocument);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aDocument.DocKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Document"/> passed as an argument .
        /// </summary>
        /// <param name="aDocument">A <see cref="Document"/>.</param>
        public static void Update(Document aDocument)
        {
            if (aDocument == null)
            {
                throw new ArgumentNullException("aDocument");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update DOC_Document");
                vStringBuilder.AppendLine("set    DOC_Name = @DOCName");
                vStringBuilder.AppendLine("where  CLN_Key = @CLNKey");
                vStringBuilder.AppendLine("and    DOC_Key = @DOCKey");
                ObjectToData(vSqlCommand, aDocument);
                vSqlCommand.Parameters.AddWithValue("@DOCKey", aDocument.DocKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Document"/> object passed as an argument.
        /// </summary>
        /// <param name="aDocument">The <see cref="Document"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aDocument</c> argument is <c>null</c>.</exception>
        public static void Delete(Document aDocument)
        {
            if (aDocument == null)
            {
                throw new ArgumentNullException("aDocument");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete DOC_Document");
                vStringBuilder.AppendLine("where  CLN_Key = @CLNKey");
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aDocument.ClnKey);
                vStringBuilder.AppendLine("and    DOC_Key = @DOCKey");
                vSqlCommand.Parameters.AddWithValue("@DOCKey", aDocument.DocKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
