using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace Z2Z
{
    public class ClientBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="ClientCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aClientCollection">A <see cref="ClientCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aClientCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, ClientCollection aClientCollection)
        {
            if (aClientCollection == null)
            {
                throw new ArgumentNullException("Load Client Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Client", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "Client");
            }

            ClientData.Load(aClientCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="Client"/> object, with keys in <c>aClient</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aClient">A <see cref="Client"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aClient</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, Client aClient)
        {
            if (aClient == null)
            {
                throw new ArgumentNullException("Load Client Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Client", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "Client");
            }

            ClientData.Load(aClient);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="Client"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>Client Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aClient">A <see cref="Client"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aClient</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, Client aClient)
        {
            if (aClient == null)
            {
                throw new ArgumentNullException("Insert Client Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Client", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "Client");
            }

            ClientData.Insert(aClient);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="Client"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aClient">A <see cref="Client"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aClient</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, Client aClient)
        {
            if (aClient == null)
            {
                throw new ArgumentNullException("Update Client Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Client", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "Client");
            }

            ClientData.Update(aClient);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="Client"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aClient">A <see cref="Client"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aClient</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, Client aClient)
        {
            if (aClient == null)
            {
                throw new ArgumentNullException("Delete Client Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "Client", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "Client");
            }

            ClientData.Delete(aClient);
        }

        #endregion
    }
}
