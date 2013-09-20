using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class ContributorBusiness
    {

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="ContributorCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributorCollection">A <see cref="ContributorCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, ContributorCollection aContributorCollection)
        {
            if (aContributorCollection == null)
            {
                throw new ArgumentNullException("Load Contributor Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Contributor", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "Contributor");
            }

            ContributorData.Load(aContributorCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Contributor"/> object, with keys in <c>aContributor</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributor">A <see cref="Contributor"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributor</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, Contributor aContributor)
        {
            if (aContributor == null)
            {
                throw new ArgumentNullException("Load Contributor Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Contributor", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "Contributor");
            }

            ContributorData.Load(aContributor);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Contributor"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Contributor Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributor">A <see cref="Contributor"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributor</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, Contributor aContributor)
        {
            if (aContributor == null)
            {
                throw new ArgumentNullException("Insert Contributor Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Contributor", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "Contributor");
            }

            ContributorData.Insert(aContributor);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Contributor"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributor">A <see cref="Contributor"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributor</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, Contributor aContributor)
        {
            if (aContributor == null)
            {
                throw new ArgumentNullException("Update Contributor Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Contributor", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "Contributor");
            }

            ContributorData.Update(aContributor);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Contributor"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributor">A <see cref="Contributor"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributor</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, Contributor aContributor)
        {
            if (aContributor == null)
            {
                throw new ArgumentNullException("Delete Contributor Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Contributor", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "Contributor");
            }

            ContributorData.Delete(aContributor);
        }

        #endregion
    }
}
