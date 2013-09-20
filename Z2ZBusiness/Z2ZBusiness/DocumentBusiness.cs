using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class DocumentBusiness
    {

        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="DocumentCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aDocumentCollection">A <see cref="DocumentCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aDocumentCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, DocumentCollection aDocumentCollection)
        {
            if (aDocumentCollection == null)
            {
                throw new ArgumentNullException("Load Document Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Document", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "Document");
            }

            DocumentData.Load(aDocumentCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Document"/> object, with keys in <c>aDocument</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aDocument">A <see cref="Document"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aDocument</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, Document aDocument)
        {
            if (aDocument == null)
            {
                throw new ArgumentNullException("Load Document Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Document", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "Document");
            }

            DocumentData.Load(aDocument);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Document"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Document Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aDocument">A <see cref="Document"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aDocument</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, Document aDocument)
        {
            if (aDocument == null)
            {
                throw new ArgumentNullException("Insert Document Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Document", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "Document");
            }

            DocumentData.Insert(aDocument);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Document"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aDocument">A <see cref="Document"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aDocument</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, Document aDocument)
        {
            if (aDocument == null)
            {
                throw new ArgumentNullException("Update Document Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Document", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "Document");
            }

            DocumentData.Update(aDocument);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Document"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aDocument">A <see cref="Document"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aDocument</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, Document aDocument)
        {
            if (aDocument == null)
            {
                throw new ArgumentNullException("Delete Document Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Document", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "Document");
            }

            DocumentData.Delete(aDocument);
        }

        #endregion
    }
}
