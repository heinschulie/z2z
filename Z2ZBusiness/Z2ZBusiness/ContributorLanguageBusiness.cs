using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class ContributorLanguageBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="ContributorLanguageCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributorLanguageCollection">A <see cref="ContributorLanguageCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguageCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, ContributorLanguageCollection aContributorLanguageCollection)
        {
            if (aContributorLanguageCollection == null)
            {
                throw new ArgumentNullException("Load ContributorLanguage Business");
            }

            //if (!UserFunctionAccessData.HasModeAccess(aUserKey, "ContributorLanguage", AccessMode.List))
            //{
            //    throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "ContributorLanguage");
            //}

            ContributorLanguageData.Load(aContributorLanguageCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="ContributorLanguage"/> object, with keys in <c>aContributorLanguage</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguage</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, ContributorLanguage aContributorLanguage)
        {
            if (aContributorLanguage == null)
            {
                throw new ArgumentNullException("Load ContributorLanguage Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "ContributorLanguage", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "ContributorLanguage");
            }

            ContributorLanguageData.Load(aContributorLanguage);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="ContributorLanguage"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>ContributorLanguage Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguage</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, ContributorLanguage aContributorLanguage)
        {
            if (aContributorLanguage == null)
            {
                throw new ArgumentNullException("Insert ContributorLanguage Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "ContributorLanguage", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "ContributorLanguage");
            }

            ContributorLanguageData.Insert(aContributorLanguage);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="ContributorLanguage"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguage</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, ContributorLanguage aContributorLanguage)
        {
            if (aContributorLanguage == null)
            {
                throw new ArgumentNullException("Update ContributorLanguage Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "ContributorLanguage", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "ContributorLanguage");
            }

            ContributorLanguageData.Update(aContributorLanguage);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="ContributorLanguage"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aContributorLanguage">A <see cref="ContributorLanguage"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aContributorLanguage</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, ContributorLanguage aContributorLanguage)
        {
            if (aContributorLanguage == null)
            {
                throw new ArgumentNullException("Delete ContributorLanguage Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "ContributorLanguage", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "ContributorLanguage");
            }

            ContributorLanguageData.Delete(aContributorLanguage);
        }

        #endregion
    }
}
