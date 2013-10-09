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
    public class JobData
    {
        #region BuildSQL

        /// <summary>
        ///   A standard SQL Statement that will return all <see cref="Job"/>, unfiltered and unsorted.
        /// </summary>
        /// <returns>A <see cref="StringBuilder"/></returns>
        private static StringBuilder BuildSQL()
        {
            var vStringBuilder = new StringBuilder();
            vStringBuilder.AppendLine("select t1.CLN_Key, t1.CLN_Name, t2.JOB_Key, t2.JOB_Name, t3.DOC_Key, t3.DOC_Name,");
            vStringBuilder.AppendLine("       t4.LAN_Key as SOURCEKEY, t4.LAN_Name as SOURCENAME, t4.LAN_EnglishName as SOURCEENGLISHNAME,");
            vStringBuilder.AppendLine("       t5.LAN_Key as TARGETKEY, t5.LAN_Name as TARGETNAME, t5.LAN_EnglishName as TARGETENGLISHNAME,");
            vStringBuilder.AppendLine("       t3.DOC_SourceWordCount, t2.JOB_DateCreated, t2.JOB_DateStarted, t2.JOB_DateFinished, t2.JOB_DateEdited,");
            vStringBuilder.AppendLine("       t2.JOB_DateDesCompletion, t2.JOB_DateEstCompletion, t2.JOB_DateActCompletion");
            vStringBuilder.AppendLine("from   CLN_Client t1,");
            vStringBuilder.AppendLine("       JOB_Job t2,");
            vStringBuilder.AppendLine("       DOC_Document t3,");
            vStringBuilder.AppendLine("       LAN_Language t4,");
            vStringBuilder.AppendLine("       LAN_Language t5");
            vStringBuilder.AppendLine("where  t1.CLN_Key = t2.CLN_Key");
            vStringBuilder.AppendLine("and    t2.CLN_Key = t3.CLN_Key");
            vStringBuilder.AppendLine("and    t2.DOC_Key = t3.DOC_Key");
            vStringBuilder.AppendLine("and    t2.LAN_KeySource = t4.LAN_Key");
            vStringBuilder.AppendLine("and    t2.LAN_KeyTarget = t5.LAN_Key");
            return vStringBuilder;
        }

        #endregion

        #region DataToObject

        /// <summary>
        ///   Load a <see cref="SqlDataReader"/> into a <see cref="Job"/> object.
        /// </summary>
        /// <param name="aJob">A <see cref="Job"/> argument.</param>
        /// <param name="aSqlDataReader">A <see cref="SqlDataReader"/> argument.</param>
        public static void DataToObject(Job aJob, SqlDataReader aSqlDataReader)
        {
            aJob.ClnKey = Convert.ToInt32(aSqlDataReader["CLN_Key"]);
            aJob.ClnName = Convert.ToString(aSqlDataReader["CLN_Name"]);
            aJob.JobbKey = Convert.ToInt32(aSqlDataReader["JOB_Key"]);
            aJob.JobName = Convert.ToString(aSqlDataReader["JOB_Name"]);
            aJob.DocKey = Convert.ToInt32(aSqlDataReader["DOC_Key"]);
            aJob.DocName = Convert.ToString(aSqlDataReader["DOC_Name"]);
            aJob.LanSourceKey = Convert.ToInt32(aSqlDataReader["SOURCEKEY"]);
            aJob.LanTargetKey = Convert.ToInt32(aSqlDataReader["TARGETKEY"]);
            aJob.LanguageSourceNames = string.Format("{0} ({1})", Convert.ToString(aSqlDataReader["SOURCEENGLISHNAME"]), Convert.ToString(aSqlDataReader["SOURCENAME"]));
            aJob.LanguageTargetNames = string.Format("{0} ({1})", Convert.ToString(aSqlDataReader["TARGETENGLISHNAME"]), Convert.ToString(aSqlDataReader["TARGETNAME"]));

            aJob.DocWordcount = CommonUtils.DbValueTo<int>(aSqlDataReader["DOC_SourceWordCount"], 0); 
            aJob.DateCreated = Convert.ToDateTime(aSqlDataReader["JOB_DateCreated"]);
            aJob.DateStarted = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["JOB_DateStarted"], null);
            aJob.DateFinished = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["JOB_DateFinished"], null);
            aJob.DateEdited = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["JOB_DateEdited"], null);
            aJob.DateDesCompletion = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["JOB_DateDesCompletion"], null);
            aJob.DateEstCompletion = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["JOB_DateEstCompletion"], null);
            aJob.DateActCompletion = CommonUtils.DbValueTo<DateTime?>(aSqlDataReader["JOB_DateActCompletion"], null);
        }

        #endregion

        #region ObjectToData

        /// <summary>
        ///   Loads the <see cref="SqlCommand"/> parameters with values from an <see cref="Job"/>.
        /// </summary>
        /// <param name="aSqlCommand">A <see cref="SqlDataReader"/> argument.</param>
        /// <param name="aJob">A <see cref="Job"/> argument.</param>
        public static void ObjectToData(SqlCommand aSqlCommand, Job aJob)
        {
            aSqlCommand.Parameters.AddWithValue("@CLNKey", aJob.ClnKey);
            aSqlCommand.Parameters.AddWithValue("@JOBName", aJob.JobName);
            aSqlCommand.Parameters.AddWithValue("@DOCKey", aJob.DocKey);
            aSqlCommand.Parameters.AddWithValue("@LANKeySource", aJob.LanSourceKey);
            aSqlCommand.Parameters.AddWithValue("@LANKeyTarget", aJob.LanTargetKey);

            //DateCreated
            if (aJob.DateCreated == null)
            {
                aSqlCommand.Parameters.Add("@JOBDateCreated", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@JOBDateCreated", aJob.DateCreated);
            }
            //DateStarted
            if (aJob.DateStarted == null)
            {
                aSqlCommand.Parameters.Add("@JOBDateStarted", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@JOBDateStarted", aJob.DateStarted);
            }
            //DateFinished
            if (aJob.DateFinished == null)
            {
                aSqlCommand.Parameters.Add("@JOBDateFinished", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@JOBDateFinished", aJob.DateFinished);
            }
            //DateEdited
            if (aJob.DateEdited == null)
            {
                aSqlCommand.Parameters.Add("@JOBDateEdited", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@JOBDateEdited", aJob.DateEdited);
            }
            //DateDesCompletion
            if (aJob.DateDesCompletion == null)
            {
                aSqlCommand.Parameters.Add("@JOBDateDesCompletion", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@JOBDateDesCompletion", aJob.DateDesCompletion);
            }
            //DateEstCompletion
            if (aJob.DateEstCompletion == null)
            {
                aSqlCommand.Parameters.Add("@JOBDateEstCompletion", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@JOBDateEstCompletion", aJob.DateEstCompletion);
            }
            //DateActCompletion
            if (aJob.DateActCompletion == null)
            {
                aSqlCommand.Parameters.Add("@JOBDateActCompletion", SqlDbType.Image).Value = DBNull.Value;
            }
            else
            {
                aSqlCommand.Parameters.AddWithValue("@JOBDateActCompletion", aJob.DateActCompletion);
            }
        }

        #endregion

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will fill the <c>JobList</c> property a <see cref="JobCollection"/> object as an
        ///   ordered <c>List</c> of <see cref="Job"/>, filtered by the filter properties of the passed <see cref="JobCollection"/>.
        /// </summary>
        /// <param name="aJobCollection">The <see cref="JobCollection"/> object that must be filled.</param>
        /// <remarks>
        ///   The filter properties of the <see cref="JobCollection"/> must be correctly completed by the calling application.
        /// </remarks>
        /// <exception cref="ArgumentNullException">If <c>aJobCollection</c> argument is <c>null</c>.</exception>
        public static void Load(JobCollection aJobCollection)
        {
            if (aJobCollection == null)
            {
                throw new ArgumentNullException("aJobCollection");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = BuildSQL();
                if (aJobCollection.JobFilter.IsFiltered)
                {
                    if (aJobCollection.JobFilter.ClientKeyFilter > 0)
                    {
                        vStringBuilder.AppendLine("and    t1.CLN_Key = @CLNKey");
                        vSqlCommand.Parameters.AddWithValue("@CLNKey", aJobCollection.JobFilter.ClientKeyFilter);
                    }
                }
                vStringBuilder.AppendLine("order by t2.JOB_Name");
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    while (vSqlDataReader.Read())
                    {
                        var vJob = new Job();
                        DataToObject(vJob, vSqlDataReader);
                        aJobCollection.JobList.Add(vJob);
                    }
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Job"/>, with keys in the <c>aJob</c> argument.
        /// </summary>
        /// <param name="aJob">A <see cref="Job"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aJob</c> argument is <c>null</c>.</exception>
        /// <exception cref="Exception">If no record is found.</exception>
        public static void Load(Job aJob)
        {
            if (aJob == null)
            {
                throw new ArgumentNullException("aJob");
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
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aJob.ClnKey);
                vSqlCommand.Parameters.AddWithValue("@JOBKey", aJob.JobbKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                using (SqlDataReader vSqlDataReader = vSqlCommand.ExecuteReader())
                {
                    if (!vSqlDataReader.HasRows)
                    {
                        throw new Exception(String.Format("Expected Job not found: CLN_Key = {0}, JOB_Key = {1}", aJob.ClnKey, aJob.JobbKey));
                    }
                    vSqlDataReader.Read();
                    DataToObject(aJob, vSqlDataReader);
                    vSqlDataReader.Close();
                }
                vSqlCommand.Connection.Close();
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Job"/> passed as an argument via Stored Procedure that returns the newly inserted Job Key 
        /// </summary>
        /// <param name="aJob">A <see cref="Job"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aJob</c> argument is <c>null</c>.</exception>
        public static void Insert(Job aJob)
        {
            if (aJob == null)
            {
                throw new ArgumentNullException("aJob");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("insert into JOB_Job");
                vStringBuilder.AppendLine("       (CLN_Key, JOB_Name, DOC_Key, LAN_KeySource, LAN_KeyTarget,)");
                vStringBuilder.AppendLine("       (JOB_DateCreated, JOB_DateStarted, JOB_DateFinished, JOB_DateDesCompletion, JOB_DateEstCompletion,)");
                vStringBuilder.AppendLine("       (JOB_DateDesCompletion, JOB_DateActCompletion)");
                vStringBuilder.AppendLine("values");
                vStringBuilder.AppendLine("       (@CLNKey, @JOBName, @DOCKey, @JOBDateCreated, @JOBDateStarted, @JOBDateFinished,)");
                vStringBuilder.AppendLine("       (@JOBDateEdited, @JOBDateDesCompletion, @JOBDateEstCompletion, @JOBDateActCompletion)");
                vStringBuilder.AppendLine(";");
                vStringBuilder.AppendLine("select SCOPE_IDENTITY()");
                ObjectToData(vSqlCommand, aJob);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                aJob.JobbKey = Convert.ToInt32(vSqlCommand.ExecuteScalar());
                vSqlCommand.Connection.Close();

            }
        }

        

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Job"/> passed as an argument .
        /// </summary>
        /// <param name="aJob">A <see cref="Job"/>.</param>
        public static void Update(Job aJob)
        {
            if (aJob == null)
            {
                throw new ArgumentNullException("aJob");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("update JOB_Job");
                vStringBuilder.AppendLine("set     JOB_Name = @JOBName,");
                vStringBuilder.AppendLine("        DOC_Key =  @DOCKey,");
                vStringBuilder.AppendLine("        LAN_KeySource = @LANKeySource,");
                vStringBuilder.AppendLine("        LAN_KeyTarget = @LANKeyTarget,");
                vStringBuilder.AppendLine("        JOB_DateCreated = @JOBDateCreated");
                vStringBuilder.AppendLine("        JOB_DateStarted = @JOBDateStarted,");
                vStringBuilder.AppendLine("        JOB_DateFinished = @JOBDateFinished,");
                vStringBuilder.AppendLine("        JOB_DateEdited = @JOBDateEdited,");
                vStringBuilder.AppendLine("        JOB_DateEstCompletion = @JOBDateEstCompletion,");
                vStringBuilder.AppendLine("        JOB_DateDesCompletion = @JOBDateDesCompletion,");
                vStringBuilder.AppendLine("        JOB_DateActCompletion = @JOBDateActCompletion");
                vStringBuilder.AppendLine("where   CLN_Key = @CLNKey");
                vStringBuilder.AppendLine("and     JOB_Key = @JOBKey");
                ObjectToData(vSqlCommand, aJob);
                vSqlCommand.Parameters.AddWithValue("@JOBKey", aJob.JobbKey);
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
        public static void Delete(Job aJob)
        {
            if (aJob == null)
            {
                throw new ArgumentNullException("aJob");
            }
            using (var vSqlCommand = new SqlCommand()
            {
                CommandType = CommandType.Text,
                Connection = new SqlConnection(Connection.Instance.SqlConnectionString)
            })
            {
                var vStringBuilder = new StringBuilder();
                vStringBuilder.AppendLine("delete JOB_Job");
                vStringBuilder.AppendLine("where  CLN_Key = @CLNKey");
                vSqlCommand.Parameters.AddWithValue("@CLNKey", aJob.ClnKey);
                vStringBuilder.AppendLine("and    JOB_Key = @JOBKey");
                vSqlCommand.Parameters.AddWithValue("@JOBKey", aJob.JobbKey);
                vSqlCommand.CommandText = vStringBuilder.ToString();
                vSqlCommand.Connection.Open();
                vSqlCommand.ExecuteNonQuery();
                vSqlCommand.Connection.Close();
            }
        }

        #endregion
    }
}
