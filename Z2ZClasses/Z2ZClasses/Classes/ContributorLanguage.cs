using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2Z
{
    public class ContributorLanguage : ContributorLanguageKey
    {
        #region Fields

        private LanguageLevelRating _rating;
        private string _contributorName;
        private string _languageName;
        private string _languageEnglishName; 

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets the <see cref="ContributorLanguage"/> Rating.
        /// </summary>
        /// <value>
        ///   <see cref="ContributorLanguage"/> Rating.
        /// </value>
        public LanguageLevelRating Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
        /// <summary>
        ///   Gets or sets the <see cref="Contributor"/> ContributorName.
        /// </summary>
        /// <value>
        ///   <see cref="Contributor"/> ContributorName.
        /// </value>
        public string ContributorName
        {
            get { return _contributorName; }
            set { _contributorName = value; }
        }
        /// <summary>
        ///   Gets or sets the LanguageName property;
        /// </summary>
        /// <value>
        ///   The LanguageName;
        /// </value>
        public string LanguageName
        {
            get { return _languageName; }
            set { _languageName = value; }
        }
        /// <summary>
        ///   Gets or sets the LanguageEnglishName property;
        /// </summary>
        /// <value>
        ///   The LanguageEnglishName;
        /// </value>
        public string LanguageEnglishName
        {
            get { return _languageEnglishName; }
            set { _languageEnglishName = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="ContributorLanguage"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ContributorLanguage))
            {
                throw new ArgumentException("Invalid Source Argument to ContributorLanguage Assign");
            }
            base.AssignFromSource(aSource);
            _rating = (aSource as ContributorLanguage)._rating;
            _contributorName = (aSource as ContributorLanguage)._contributorName;
            _languageName = (aSource as ContributorLanguage)._languageName;
            _languageEnglishName = (aSource as ContributorLanguage)._languageEnglishName;
        }

        #endregion
    }
}
