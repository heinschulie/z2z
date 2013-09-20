using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class WorkItemCollection : Zephob
    {
        #region Fields

        private WorkItemFilter _workItemFilter = new WorkItemFilter();
        private List<WorkItem> _workItemList = new List<WorkItem>();

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the WorkItem filter.
        /// </summary>
        /// <value>
        /// The WorkItem filter.
        /// </value>
        public WorkItemFilter WorkItemFilter
        {
            get { return _workItemFilter; }
            set { _workItemFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="WorkItem"/> list.
        /// </summary>
        /// <value>
        /// The WorkItem list.
        /// </value>
        public List<WorkItem> WorkItemList
        {
            get { return _workItemList; }
            set { _workItemList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="ProviderCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is WorkItemCollection))
            {
                throw new ArgumentException("Invalid assignment source", "WorkItemCollection");
            }

            _workItemFilter.AssignFromSource((aSource as WorkItemCollection)._workItemFilter);
            _workItemList.Clear();
            (aSource as WorkItemCollection)._workItemList.ForEach(vWorkItemSource =>
            {
                WorkItem vWorkItemTarget = new WorkItem();
                vWorkItemTarget.AssignFromSource(vWorkItemSource);
                _workItemList.Add(vWorkItemTarget);
            });
        }

        #endregion
    }
}
