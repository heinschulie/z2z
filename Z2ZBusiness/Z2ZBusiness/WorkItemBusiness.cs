using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class WorkItemBusiness
    {
        #region Load Collection

        /// <summary>
        ///   The overloaded Load method that will return a <see cref="WorkItemCollection"/>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aWorkItemCollection">A <see cref="WorkItemCollection"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkItemCollection</c> argument is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, WorkItemCollection aWorkItemCollection)
        {
            if (aWorkItemCollection == null)
            {
                throw new ArgumentNullException("Load WorkItem Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "WorkItem", AccessMode.List))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.List, "WorkItem");
            }

            WorkItemData.Load(aWorkItemCollection);
        }

        #endregion

        #region Load

        /// <summary>
        ///   The overloaded Load method that will return a specific <see cref="WorkItem"/> object, with keys in <c>aWorkItem</c>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aWorkItem">A <see cref="WorkItem"/>.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkItem</c> is <c>null</c>.</exception>
        public static void Load(UserKey aUserKey, WorkItem aWorkItem)
        {
            if (aWorkItem == null)
            {
                throw new ArgumentNullException("Load WorkItem Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "WorkItem", AccessMode.Read))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Read, "WorkItem");
            }

            WorkItemData.Load(aWorkItem);
        }

        #endregion

        #region Insert

        /// <summary>
        ///   Insert a <see cref="WorkItem"/> object passed as an argument via Stored Procedure that returns the newly inserted <i>WorkItem Key</i>.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aWorkItem">A <see cref="WorkItem"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkItem</c> argument is <c>null</c>.</exception>
        public static void Insert(UserKey aUserKey, WorkItem aWorkItem)
        {
            if (aWorkItem == null)
            {
                throw new ArgumentNullException("Insert WorkItem Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "WorkItem", AccessMode.Create))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Create, "WorkItem");
            }

            WorkItemData.Insert(aWorkItem);
        }

        #endregion

        #region Update

        /// <summary>
        ///   Update a <see cref="WorkItem"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aWorkItem">A <see cref="WorkItem"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkItem</c> argument is <c>null</c>.</exception>
        public static void Update(UserKey aUserKey, WorkItem aWorkItem)
        {
            if (aWorkItem == null)
            {
                throw new ArgumentNullException("Update WorkItem Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "WorkItem", AccessMode.Update))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Update, "WorkItem");
            }

            WorkItemData.Update(aWorkItem);
        }

        #endregion

        #region Delete

        /// <summary>
        ///   Delete a <see cref="WorkItem"/> object passed as an argument.
        /// </summary>
        /// <param name="aUserKey">A <see cref="UserKey"/> object.</param>
        /// <param name="aWorkItem">A <see cref="WorkItem"/> object.</param>
        /// <exception cref="ArgumentNullException">If <c>aWorkItem</c> argument is <c>null</c>.</exception>
        public static void Delete(UserKey aUserKey, WorkItem aWorkItem)
        {
            if (aWorkItem == null)
            {
                throw new ArgumentNullException("Delete WorkItem Business");
            }

            if (!UserFunctionAccessData.HasModeAccess(aUserKey, "WorkItem", AccessMode.Delete))
            {
                throw new ZpAccessException("Access Denied", String.Format("{0}", aUserKey.UsrKey), AccessMode.Delete, "WorkItem");
            }

            WorkItemData.Delete(aWorkItem);
        }

        #endregion
    }
}
