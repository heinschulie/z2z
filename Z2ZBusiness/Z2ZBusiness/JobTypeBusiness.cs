using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class JobTypeBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="JobTypeCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJobTypeCollection">A <see cref="JobTypeCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobTypeCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, JobTypeCollection aJobTypeCollection)
        {
            if (aJobTypeCollection == null)
            {
                throw new ArgumentNullException("Load JobType Business");
            }

            //if (!UserFunctionAccessData.HasModeAccess(aUserKey, "JobType", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "JobType");
            //}

            JobTypeData.Load(aJobTypeCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="JobType"/> object, with keys in <c>aJobType</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJobType">A <see cref="JobType"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobType</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, JobType aJobType)
        {
            if (aJobType == null)
            {
                throw new ArgumentNullException("Load JobType Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "JobType", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "JobType");
            }

            JobTypeData.Load(aJobType);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="JobType"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>JobType Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJobType">A <see cref="JobType"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobType</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, JobType aJobType)
        {
            if (aJobType == null)
            {
                throw new ArgumentNullException("Insert JobType Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "JobType", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "JobType");
            }

            JobTypeData.Insert(aJobType);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="JobType"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJobType">A <see cref="JobType"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobType</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, JobType aJobType)
        {
            if (aJobType == null)
            {
                throw new ArgumentNullException("Update JobType Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "JobType", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "JobType");
            }

            JobTypeData.Update(aJobType);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="JobType"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aJobType">A <see cref="JobType"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aJobType</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, JobType aJobType)
        {
            if (aJobType == null)
            {
                throw new ArgumentNullException("Delete JobType Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "JobType", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "JobType");
            }

            JobTypeData.Delete(aJobType);
        }

        #endregion
    }
}
