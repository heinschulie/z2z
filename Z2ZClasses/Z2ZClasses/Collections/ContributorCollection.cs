using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace Z2Z
{
    public class ContributorCollection : Zephob
    {
        #region Fields

        private ContributorFilter _contributorFilter = new ContributorFilter();
        private List<Contributor> _contributorList = new List<Contributor>();

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the provider filter.
        /// </summary>
        /// <value>
        /// The provider filter.
        /// </value>
        public ContributorFilter ContributorFilter
        {
            get { return _contributorFilter; }
            set { _contributorFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="Provider"/> list.
        /// </summary>
        /// <value>
        /// The Provider list.
        /// </value>
        public List<Contributor> ContributorList
        {
            get { return _contributorList; }
            set { _contributorList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="ContributorCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ContributorCollection))
            {
                throw new ArgumentException("Invalid assignment source", "ContributorCollection");
            }

            _contributorFilter.AssignFromSource((aSource as ContributorCollection)._contributorFilter);
            _contributorList.Clear();
            (aSource as ContributorCollection)._contributorList.ForEach(vContributorSource =>
            {
                Contributor vContributorTarget = new Contributor();
                vContributorTarget.AssignFromSource(vContributorSource);
                _contributorList.Add(vContributorTarget);
            });
        }

        #endregion
    }
}
