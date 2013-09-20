using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class Document : DocumentKey
    {
        #region Fields

        private string _docName;
        private string _clnName;
        private byte[] _docSource;
        private byte[] _docTarget;
        private int _docSourceWordCount;
        private int _docTargetWordCount;

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
            get { return _docName; }
            set { _docName = value; }
        }

        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        //*************************************

        /// <summary>
        ///   Gets or sets the <see cref="Document"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> name.
        /// </value>
        public string ClnName
        {
            get { return _clnName; }
            set { _clnName = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Document"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> name.
        /// </value>
        public string DocName
        {
            get { return _docName; }
            set { _docName = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Document"/> source.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> source.
        /// </value>
        public byte[] DocSource
        {
            get { return _docSource; }
            set { _docSource = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Document"/> target.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> target.
        /// </value>
        public byte[] DocTarget
        {
            get { return _docTarget; }
            set { _docTarget = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Document"/> sourcewordcount.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> sourcewordcount.
        /// </value>
        public int DocSourceWordCount
        {
            get { return _docSourceWordCount; }
            set { _docSourceWordCount = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Document"/> targetWordCount.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> targetWordCount.
        /// </value>
        public int DocTargetWordCount
        {
            get { return _docTargetWordCount; }
            set { _docTargetWordCount = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Document"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Document))
            {
                throw new ArgumentException("Invalid Source Argument to Document Assign");
            }
            base.AssignFromSource(aSource);
            _docName = (aSource as Document)._docName;
            _clnName = (aSource as Document)._clnName;
            _docSource = (aSource as Document)._docSource;
            _docTarget = (aSource as Document)._docTarget;
            _docSourceWordCount = (aSource as Document)._docSourceWordCount;
            _docTargetWordCount = (aSource as Document)._docTargetWordCount;
        }

        #endregion
    }
}
