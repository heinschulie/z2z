using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace Z2Z
{
    public class LanguageCollection : Zephob
    {

        #region Fields

        private List<Language> _languageList = new List<Language>();

        #endregion

        #region  Properties


        /// <summary>
        /// Gets or sets the <see cref="Language"/> list.
        /// </summary>
        /// <value>
        /// The Language list.
        /// </value>
        public List<Language> LanguageList
        {
            get { return _languageList; }
            set { _languageList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="LanguageCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is LanguageCollection))
            {
                throw new ArgumentException("Invalid assignment source", "LanguageCollection");
            }

            _languageList.Clear();
            (aSource as LanguageCollection)._languageList.ForEach(vLanguageSource =>
            {
                Language vLanguageTarget = new Language();
                vLanguageTarget.AssignFromSource(vLanguageSource);
                _languageList.Add(vLanguageTarget);
            });
        }

        #endregion
    }
}
