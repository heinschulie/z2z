using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class JobBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="JobCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJobCollection">A <see cref="JobCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, JobCollection aJobCollection)
        {
            if (aJobCollection == null)
            {
                throw new ArgumentNullException("Load Job Business");
            }

            //if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Job", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "Job");
            //}

            JobData.Load(aJobCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Job"/> object, with keys in <c>aJob</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJob">A <see cref="Job"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aJob</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, Job aJob)
        {
            if (aJob == null)
            {
                throw new ArgumentNullException("Load Job Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Job", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "Job");
            }

            JobData.Load(aJob);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Job"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Job Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJob">A <see cref="Job"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aJob</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, Job aJob)
        {
            if (aJob == null)
            {
                throw new ArgumentNullException("Insert Job Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Job", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "Job");
            }

            JobData.Insert(aJob);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Job"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJob">A <see cref="Job"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aJob</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, Job aJob)
        {
            if (aJob == null)
            {
                throw new ArgumentNullException("Update Job Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Job", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "Job");
            }

            JobData.Update(aJob);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Job"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJob">A <see cref="Job"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aJob</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, Job aJob)
        {
            if (aJob == null)
            {
                throw new ArgumentNullException("Delete Job Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Job", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "Job");
            }

            JobData.Delete(aJob);
        }

        #endregion
    }
}
