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
    public class WorkItemData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="WorkItem"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.CLN_Key, t1.CLN_Name, t2.JOB_Key, t2.JOB_Name, t3.WRK_Name,");
            vStringBuilder.AppendLine("       t4.JBT_Key, t4.JBT_Type, t4.JBT_Type, t5.CON_Key as PRIMARYCONTRIBUTORKEY,");
            vStringBuilder.AppendLine("       t5.CON_Name as PRIMARYCONTRIBUTORNAME, t5.CON_Name as PRIMARYCONTRIBUTORSURNAME,");
            vStringBuilder.AppendLine("       t6.CON_Key as PROOFCONTRIBUTORKEY, t6.CON_Name as PROOFCONTRIBUTORNAME, t6.CON_Surname as PROOFCONTRIBUTORSURNAME,");
            vStringBuilder.AppendLine("       t3.CTL_Rating, t3.WRK_ManuscriptSource, t3.WRK_ManuscriptTarget, t3.WRK_SourceWordCount,");
            vStringBuilder.AppendLine("       t3.WRK_DateCreated, t3.WRK_DateStarted, t3.WRK_DateFinished, t3.WRK_DateEdited,");
            vStringBuilder.AppendLine("       t3.WRK_DateDesCompletion, t3.WRK_DateEstCompletion, t3.WRK_DateActCompletion");
            vStringBuilder.AppendLine("from   CLN_Client t1,");
            vStringBuilder.AppendLine("       JOB_Job t2,");
            vStringBuilder.AppendLine("       WRK_WorkItem t3,");
            vStringBuilder.AppendLine("       JBT_JobType t4,");
            vStringBuilder.AppendLine("       CON_Contributor t5,");
            vStringBuilder.AppendLine("       CON_Contributor t6,");
            vStringBuilder.AppendLine("       CTL_ContributorLanguage t7");
            vStringBuilder.AppendLine("where  t1.CLN_Key = t2.CLN_Key");
            vStringBuilder.AppendLine("and    t2.CLN_Key = t3.CLN_Key");
            vStringBuilder.AppendLine("and    t2.JOB_Key = t3.JOB_Key");
            vStringBuilder.AppendLine("and    t3.JBT_Key = t4.JBT_Key");
            //vStringBuilder.AppendLine("and    t3.CON_Key = t5.CON_Key");
            //vStringBuilder.AppendLine("and    t3.CON_KeyProof = t6.CON_Key");
            //vStringBuilder.AppendLine("and    t3.CTL_Rating <= t7.CTL_Rating");
            //vStringBuilder.AppendLine("and    t5.CON_Key = t7.CON_Key");
            //vStringBuilder.AppendLine("and    t6.CON_Key = t7.CON_Key");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="WorkItem"/> object.
        /// </summary>
        /// <param name="aWorkItem">A <see cref="WorkItem"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(WorkItem aWorkItem, SqlDataReader aSqlDataReader)
        {
            aWorkItem.ClnKey = Convert.ToInt32(aSqlDataReader["CLN_Key"]);
            aWorkItem.ClnName = Convert.ToString(aSqlDataReader["CLN_Name"]);
            aWorkItem.JobKey = Convert.ToInt32(aSqlDataReader["JOB_Key"]);
            aWorkItem.WrkName = Convert.ToString(aSqlDataReader["WRK_Name"]);
            aWorkItem.ConKey = Convert.ToInt32(aSqlDataReader["PRIMARYCONTRIBUTORKEY"]);
            aWorkItem.ConName = string.Format("{0} {1}", Convert.ToString(aSqlDataReader["PRIMARYCONTRIBUTORNAME"]), Convert.ToString(aSqlDataReader["PRIMARYCONTRIBUTORSURNAME"]));
            aWorkItem.ConProofKey = Convert.ToInt32(aSqlDataReader["PROOFCONTRIBUTORKEY"]);
            aWorkItem.ConProofName = string.Format("{0} {1}", Convert.ToString(aSqlDataReader["PROOFCONTRIBUTORNAME"]), Convert.ToString(aSqlDataReader["PROOFCONTRIBUTORSURNAME"]));
            aWorkItem.JbtKey = Convert.ToInt32(aSqlDataReader["JBT_Key"]);
            aWorkItem.JbtType = Convert.ToString(aSqlDataReader["WRK_Name"]);
            aWorkItem.CtlRating = Convert.ToInt32(aSqlDataReader["CTL_Rating"]);

            aWorkItem.WrkSource = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["WRK_ManuscriptSource"], null);
            aWorkItem.WrkTarget = CommonUtils.DbValueTo<byte[]>(aSqlDataReader["WRK_ManuscriptTarget"], null);
            aWorkItem.DocWordcount = CommonUtils.DbValueTo<int>(aSqlDataReader["WRK_SourceWordCount"], 0);

            aWorkItem.DateCreated = Convert.ToDateTime(aSqlDataReader["WRK_DateCreated"]);
            aWorkItem.DateStarted = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["WRK_DateStarted"], null);
            aWorkItem.DateFinished = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["WRK_DateFinished"], null);
            aWorkItem.DateEdited = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["WRK_DateEdited"], null);
            aWorkItem.DateDesCompletion = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["WRK_DateDesCompletion"], null);
            aWorkItem.DateEstCompletion = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["WRK_DateEstCompletion"], null);
            aWorkItem.DateActCompletion = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["WRK_DateActCompletion"], null);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="WorkItem"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aWorkItem">A <see cref="WorkItem"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, WorkItem aWorkItem)
        {
            aSqlCommand.Parameters.AddWithValue("@CLNKey", aWorkItem.ClnKey);
            aSqlCommand.Parameters.AddWithValue("@JOBKey", aWorkItem.JobKey);
            aSqlCommand.Parameters.AddWithValue("@JBTKey", aWorkItem.JbtKey);
            aSqlCommand.Parameters.AddWithValue("@WRKName", aWorkItem.WrkKey);
            aSqlCommand.Parameters.AddWithValue("@CTLRating", aWorkItem.CtlRating);
            if (aWorkItem.ConKey < 1)
            {
                aSqlCommand.Parameters.AddWithValue("@CONKey", DBNull.Value);
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@CONKey", aWorkItem.ConKey);
            }
            if (aWorkItem.ConProofKey < 1)
            {
                aSqlCommand.Parameters.AddWithValue("@CONKeyProof", DBNull.Value);
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@CONKeyProof", aWorkItem.ConProofKey);
            }

            //Source document
            if (aWorkItem.WrkSource == null)
            {
                aSqlCommand.Parameters.Add("@WRKManuscriptSource", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKManuscriptSource", aWorkItem.WrkSource);
            }
            //Target document
            if (aWorkItem.WrkTarget == null)
            {
                aSqlCommand.Parameters.Add("@WRKManuscriptTarget", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKManuscriptTarget", aWorkItem.WrkTarget);
            }

            //DateCreated
            if (aWorkItem.DateCreated == null)
            {
                aSqlCommand.Parameters.Add("@WRKDateCreated", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKDateCreated", aWorkItem.DateCreated);
            }
            //DateStarted
            if (aWorkItem.DateStarted == null)
            {
                aSqlCommand.Parameters.Add("@WRKDateStarted", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKDateStarted", aWorkItem.DateStarted);
            }
            //DateFinished
            if (aWorkItem.DateFinished == null)
            {
                aSqlCommand.Parameters.Add("@WRKDateFinished", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKDateFinished", aWorkItem.DateFinished);
            }
            //DateEdited
            if (aWorkItem.DateEdited == null)
            {
                aSqlCommand.Parameters.Add("@WRKDateEdited", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKDateEdited", aWorkItem.DateEdited);
            }
            //DateDesCompletion
            if (aWorkItem.DateDesCompletion == null)
            {
                aSqlCommand.Parameters.Add("@WRKDateDesCompletion", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKDateDesCompletion", aWorkItem.DateDesCompletion);
            }
            //DateEstCompletion
            if (aWorkItem.DateEstCompletion == null)
            {
                aSqlCommand.Parameters.Add("@WRKDateEstCompletion", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKDateEstCompletion", aWorkItem.DateEstCompletion);
            }
            //DateActCompletion
            if (aWorkItem.DateActCompletion == null)
            {
                aSqlCommand.Parameters.Add("@WRKDateActCompletion", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@WRKDateActCompletion", aWorkItem.DateActCompletion);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>WorkItemList</c> property a <see cref="WorkItemCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="WorkItem"/>, filtered by the filter properties of the passed <see cref="WorkItemCollection"/>.
        /// </summary>
        /// <param name="aWorkItemCollection">The <see cref="WorkItemCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="WorkItemCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aWorkItemCollection</c> argument is <c>null</c>.</exception>
        public static void Load(WorkItemCollection aWorkItemCollection)
        {
            if (aWorkItemCollection == null)
            {
                throw new ArgumentNullException("aWorkItemCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aWorkItemCollection.WorkItemFilter.IsFiltered)
                {
                    if (aWorkItemCollection.WorkItemFilter.ClientKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    t1.CLN_Key = @CLNKey");
                        vSqlCommand.Parameters.AddWithValue("@CLNKey", aWorkItemCollection.WorkItemFilter.ClientKeyFilter);
                    }
                    if (aWorkItemCollection.WorkItemFilter.JobKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    t2.JOB_Key = @JOBKey");
                        vSqlCommand.Parameters.AddWithValue("@JOBKey", aWorkItemCollection.WorkItemFilter.JobKeyFilter);
                    }
                }
                vStringBuilder.AppendLine("order by t2.JOB_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vWorkItem = new WorkItem();
                        DataToObject(vWorkItem, vSqlDataReader);
                        aWorkItemCollection.WorkItemList.Add(vWorkItem);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="WorkItem"/>, with keys in the <c>aWorkItem</c> argument.
        /// </summary>
        /// <param name="aWorkItem">A <see cref="WorkItem"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkItem</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(WorkItem aWorkItem)
        {
            if (aWorkItem == null)
            {
                throw new ArgumentNullException("aWorkItem");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                vStringBuilder.AppendLine("and    t1.CLN_Key = @CLNKey");
                vStringBuilder.AppendLine("and    t2.JOB_Key = @JOBKey");
                vStringBuilder.AppendLine("and    t3.WRK_Key = @WRKKey");
                vStringBuilder.AppendLine("and    t4.JBT_Key = @JBTKey");
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aWorkItem.ClnKey);
                vSqlCommand.Parameters.AddWithValue("@JOBKey", aWorkItem.JobKey);
                vSqlCommand.Parameters.AddWithValue("@WRKKey", aWorkItem.WrkKey);
                vSqlCommand.Parameters.AddWithValue("@JBTKey", aWorkItem.JbtKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected WorkItem not found: CLN_Key = {0}, JOB_Key = {1}, WRK_Key = {2}, JBT_Key = {3}", aWorkItem.ClnKey, aWorkItem.JobKey, aWorkItem.WrkKey, aWorkItem.JbtKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aWorkItem, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="WorkItem"/> passed as an argument via Stored Procedure that returns the newly inserted WorkItem Key 
        /// </summary>
        /// <param name="aWorkItem">A <see cref="WorkItem"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkItem</c> argument is <c>null</c>.</exception>
        public static void Insert(WorkItem aWorkItem)
        {
            if (aWorkItem == null)
            {
                throw new ArgumentNullException("aWorkItem");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into WRK_WorkItem");
                vStringBuilder.AppendLine("       (CLN_Key, JOB_Key, JBT_Key, WRK_Name, CON_Key, CON_KeyProof, CTL_Rating,)");
                vStringBuilder.AppendLine("       (WRK_ManuscriptSource, WRK_ManuscriptTarget, WRK_SourceWordCount,)");
                vStringBuilder.AppendLine("       (WRK_DateCreated, WRK_DateStarted, WRK_DateFinished, WRK_DateEdited,)");
                vStringBuilder.AppendLine("       (WRK_DateDesCompletion, WRK_DateEstCompletion, WRK_DateActCompletion)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CLNKey, @JOBKey, @JBTKey, @WRKName, @CONKey, @CONKeyProof, @CTLRating,)");
                vStringBuilder.AppendLine("       (@WRKManuscriptSource, @WRKManuscriptTarget, @WRKSourceWordCount,)");
                vStringBuilder.AppendLine("       (@WRKDateCreated, @WRKDateStarted, @WRKDateFinished, @WRKDateEdited,)");
                vStringBuilder.AppendLine("       (@WRKDateDesCompletion, @WRKDateEstCompletion, @WRKDateActCompletion)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aWorkItem);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aWorkItem.WrkKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="WorkItem"/> passed as an argument .
        /// </summary>
        /// <param name="aWorkItem">A <see cref="WorkItem"/>.</param>
        public static void Update(WorkItem aWorkItem)
        {
            if (aWorkItem == null)
            {
                throw new ArgumentNullException("aWorkItem");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update  WRK_WorkItem");
                vStringBuilder.AppendLine("set     WRK_Name = @WRKName,");
                vStringBuilder.AppendLine("        CON_Key = @CONKey,");
                vStringBuilder.AppendLine("        CON_KeyProof = @CONKeyProof,");
                vStringBuilder.AppendLine("        CTL_Rating = @CTLRating,");
                vStringBuilder.AppendLine("        WRK_ManuscriptSource = @WRKManuscriptSource,");
                vStringBuilder.AppendLine("        WRK_ManuscriptTarget = @WRKManuscriptTarget,");
                vStringBuilder.AppendLine("        WRK_SourceWordCount = @WRKSourceWordCount,");
                vStringBuilder.AppendLine("        WRK_DateCreated = @WRKDateCreated,");
                vStringBuilder.AppendLine("        WRK_DateStarted = @WRKDateStarted,");
                vStringBuilder.AppendLine("        WRK_DateFinished = @WRKDateFinished,");
                vStringBuilder.AppendLine("        WRK_DateEdited = @WRKDateEdited,");
                vStringBuilder.AppendLine("        WRK_DateDesCompletion = @WRKDateDesCompletion,");
                vStringBuilder.AppendLine("        WRK_DateEstCompletion = @WRKDateEstCompletion,");
                vStringBuilder.AppendLine("        WRK_DateActCompletion = @WRKDateActCompletion");
                vStringBuilder.AppendLine("where   CLN_Key = @CLNKey");
                vStringBuilder.AppendLine("and     JOB_Key = @JOBKey");
                vStringBuilder.AppendLine("and     JBT_Key = @JBTKey");
                vStringBuilder.AppendLine("and     WRK_Key = @WRKKey");
                ObjectToData(vSqlCommand, aWorkItem);
                vSqlCommand.Parameters.AddWithValue("@WRKKey", aWorkItem.WrkKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Job"/> object passed as an argument.
        /// </summary>
        /// <param name="aJob">The <see cref="Job"/> object to be deleted.</param>
        /// <exception cref="ArgumentNullException">If <c>aJob</c> argument is <c>null</c>.</exception>
        public static void Delete(WorkItem aWorkItem)
        {
            if (aWorkItem == null)
            {
                throw new ArgumentNullException("aWorkItem");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete WRK_WorkItem");
                vStringBuilder.AppendLine("where  CLN_Key = @CLNKey");
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aWorkItem.ClnKey);
                vStringBuilder.AppendLine("and    JOB_Key = @JOBKey");
                vSqlCommand.Parameters.AddWithValue("@JOBKey", aWorkItem.JobKey);
                vStringBuilder.AppendLine("and    JBT_Key = @JBTKey");
                vSqlCommand.Parameters.AddWithValue("@JBTKey", aWorkItem.JbtKey);
                vStringBuilder.AppendLine("and    WRK_Key = @WRKKey");
                vSqlCommand.Parameters.AddWithValue("@WRKKey", aWorkItem.WrkKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
