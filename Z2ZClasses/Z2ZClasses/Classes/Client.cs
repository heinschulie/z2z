using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class Client : ClientKey
    {
        #region Fields

        private string _clnName;
        private string _clnPassword;
        private string _clnContact;
        private string _clnEmail;
        private byte[] _clnAvatar;

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
            get { return _clnName; }
            set { _clnName = value; }
        }

        public int value
        {
            get { return _value; }
            set { _value = value; }
        }


        //*************************************

        /// <summary>
        ///   Gets or sets the <see cref="Client"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Client"/> name.
        /// </value>
        public string ClnName
        {
            get { return _clnName; }
            set { _clnName = value; }
        }
        /// <summary>
        ///   Gets or sets the <see cref="Client"/> password.
        /// </summary>
        /// <value>
        ///   <see cref="Client"/> password.
        /// </value>
        public string ClnPassword
        {
            get { return _clnPassword; }
            set { _clnPassword = value; }
        }
        /// <summary>
        ///   Gets or sets the Contact property;
        /// </summary>
        /// <value>
        ///   The Contact;
        /// </value>
        public string ClnContact
        {
            get { return _clnContact; }
            set { _clnContact = value; }
        }
        /// <summary>
        ///   Gets or sets the Email property;
        /// </summary>
        /// <value>
        ///   The Email;
        /// </value>
        public string ClnEmail
        {
            get { return _clnEmail; }
            set { _clnEmail = value; }
        }
        /// <summary>
        ///   Gets or sets the Avatar property;
        /// </summary>
        /// <value>
        ///   The Avatar;
        /// </value>
        public byte[] ClnAvatar
        {
            get { return _clnAvatar; }
            set { _clnAvatar = value; }
        }
        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Client"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Client))
            {
                throw new ArgumentException("Invalid Source Argument to Client Assign");
            }
            base.AssignFromSource(aSource);
            _clnName = (aSource as Client)._clnName;
            _clnPassword = (aSource as Client)._clnPassword;
            _clnContact = (aSource as Client)._clnContact;
            _clnEmail = (aSource as Client)._clnEmail;
            _clnAvatar = (aSource as Client)._clnAvatar;
        }

        #endregion
    }
}
