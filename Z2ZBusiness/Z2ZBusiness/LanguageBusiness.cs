using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class LanguageBusiness
    {

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="LanguageCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aLanguageCollection">A <see cref="LanguageCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aLanguageCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, LanguageCollection aLanguageCollection)
        {
            if (aLanguageCollection == null)
            {
                throw new ArgumentNullException("Load Language Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Language", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "Language");
            }

            LanguageData.Load(aLanguageCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Language"/> object, with keys in <c>aLanguage</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aLanguage">A <see cref="Language"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aLanguage</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, Language aLanguage)
        {
            if (aLanguage == null)
            {
                throw new ArgumentNullException("Load Language Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Language", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "Language");
            }

            LanguageData.Load(aLanguage);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Language"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Language Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aLanguage">A <see cref="Language"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aLanguage</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, Language aLanguage)
        {
            if (aLanguage == null)
            {
                throw new ArgumentNullException("Insert Language Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Language", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "Language");
            }

            LanguageData.Insert(aLanguage);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Language"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aLanguage">A <see cref="Language"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aLanguage</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, Language aLanguage)
        {
            if (aLanguage == null)
            {
                throw new ArgumentNullException("Update Language Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Language", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "Language");
            }

            LanguageData.Update(aLanguage);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Language"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aLanguage">A <see cref="Language"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aLanguage</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, Language aLanguage)
        {
            if (aLanguage == null)
            {
                throw new ArgumentNullException("Delete Language Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Language", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "Language");
            }

            LanguageData.Delete(aLanguage);
        }

        #endregion
    }
}
