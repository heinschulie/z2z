using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class Language : LanguageKey
    {
        #region Fields

        private string _lanName;
        private string _lanEnglishName;

        //Experimental Properties to assist in graphical representation of data hierarchy on front end 
        private List<Zephob> _children = new List<Zephob>();
        private int _value;

        #endregion

        #region Properties

        //Experimental Properties to assist in graphical representation of data hierarchy on front end 

        public List<Zephob> children
        {
            get { return _children; }
            set { _children = value; }
        }

        public string name
        {
            get { return _lanName; }
        }

        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Language"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Language"/> name.
        /// </value>
        public string LanName
        {
            get { return _lanName; }
            set { _lanName = value; }
        }
        /// <summary>
        ///   Gets or sets the <see cref="Language"/> English Name.
        /// </summary>
        /// <value>
        ///   <see cref="Language"/> English Name.
        /// </value>
        public string LanEnglishName
        {
            get { return _lanEnglishName; }
            set { _lanEnglishName = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Language"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Language))
            {
                throw new ArgumentException("Invalid Source Argument to Language Assign");
            }
            base.AssignFromSource(aSource);
            _lanName = (aSource as Language)._lanName;
            _lanEnglishName = (aSource as Language)._lanEnglishName;
        }

        #endregion
    }
}
