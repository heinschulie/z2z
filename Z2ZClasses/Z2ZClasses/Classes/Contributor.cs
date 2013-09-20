using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class Contributor : ContributorKey
    {
        #region Fields

        private string _conName;
        private string _conSurname;
        private string _conPassword;
        private string _conContact;
        private string _conEmail;
        private byte[] _conAvatar;

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
            get { return _conName; }
        }

        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Contributor"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Contributor"/> name.
        /// </value>
        public string ConName
        {
            get { return _conName; }
            set { _conName = value; }
        }


        /// <summary>
        ///   Gets or sets the <see cref="Contributor"/> surname.
        /// </summary>
        /// <value>
        ///   <see cref="Contributor"/> surname.
        /// </value>
        public string ConSurname
        {
            get { return _conSurname; }
            set { _conSurname = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Contributor"/> password.
        /// </summary>
        /// <value>
        ///   <see cref="Contributor"/> password.
        /// </value>
        public string ConPassword
        {
            get { return _conPassword; }
            set { _conPassword = value; }
        }
        /// <summary>
        ///   Gets or sets the Contact property;
        /// </summary>
        /// <value>
        ///   The Contact;
        /// </value>
        public string ConContact
        {
            get { return _conContact; }
            set { _conContact = value; }
        }
        /// <summary>
        ///   Gets or sets the Email property;
        /// </summary>
        /// <value>
        ///   The Email;
        /// </value>
        public string ConEmail
        {
            get { return _conEmail; }
            set { _conEmail = value; }
        }
        /// <summary>
        ///   Gets or sets the Avatar property;
        /// </summary>
        /// <value>
        ///   The Avatar;
        /// </value>
        public byte[] ConAvatar
        {
            get { return _conAvatar; }
            set { _conAvatar = value; }
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Contributor"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Contributor))
            {
                throw new ArgumentException("Invalid Source Argument to Contributor Assign");
            }
            base.AssignFromSource(aSource);
            _conName = (aSource as Contributor)._conName;
            _conSurname = (aSource as Contributor)._conSurname;
            _conPassword = (aSource as Contributor)._conPassword;
            _conContact = (aSource as Contributor)._conContact;
            _conEmail = (aSource as Contributor)._conEmail;
            _conAvatar = (aSource as Contributor)._conAvatar;
        }

        #endregion
    }
}
