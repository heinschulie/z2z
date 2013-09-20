using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class JobType : JobTypeKey
    {
        #region Fields

        private string _jbtType;
        private byte[] _jbtAvatar;

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
            get { return _jbtType; }
        }

        public int value
        {
            get { return _value; }
            set { _value = value; }
        }
        /// <summary>
        ///   Gets or sets the <see cref="JobType"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="JobType"/> name.
        /// </value>
        public string JbtType
        {
            get { return _jbtType; }
            set { _jbtType = value; }
        }
        /// <summary>
        ///   Gets or sets the Avatar property;
        /// </summary>
        /// <value>
        ///   The Avatar;
        /// </value>
        public byte[] JbtAvatar
        {
            get { return _jbtAvatar; }
            set { _jbtAvatar = value; }
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="JobType"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is JobType))
            {
                throw new ArgumentException("Invalid Source Argument to JobType Assign");
            }
            base.AssignFromSource(aSource);
            _jbtType = (aSource as JobType)._jbtType;
        }

        #endregion
    }
}
