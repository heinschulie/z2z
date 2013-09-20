using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class WorkItem : WorkItemKey
    {
        #region Fields

        private string _clnName;
        private int _conKey;
        private int _conProofKey;
        private string _conName;
        private string _conProofName;
        private int _ctlRating;
        private string _wrkName;
        private string _jbtType;
        private byte[] _wrkSource;
        private byte[] _wrkTarget;
        private int _docWordCount;
        private DateTime _dateCreated;
        private DateTime? _dateStarted;
        private DateTime? _dateFinished;
        private DateTime? _dateEdited;
        private DateTime? _dateDesCompletion;
        private DateTime? _dateEstCompletion;
        private DateTime? _dateActCompletion;

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
            get { return _wrkName; }
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
        ///   Gets or sets the <see cref="Job"/> type.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> type.
        /// </value>
        public string JbtType
        {
            get { return _jbtType; }
            set { _jbtType = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Contributor"/> Key.
        /// </summary>
        /// <value>
        ///   <see cref="Contributor"/> Key.
        /// </value>
        public int ConKey
        {
            get { return _conKey; }
            set { _conKey = value; }
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
        ///   Gets or sets the <see cref="ContributorProof"/> Key.
        /// </summary>
        /// <value>
        ///   <see cref="ContributorProof"/> Key.
        /// </value>
        public int ConProofKey
        {
            get { return _conProofKey; }
            set { _conProofKey = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Contributor"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Contributor"/> name.
        /// </value>
        public string ConProofName
        {
            get { return _conProofName; }
            set { _conProofName = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> name.
        /// </value>
        public string WrkName
        {
            get { return _wrkName; }
            set { _wrkName = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="ContributorLangauageRating"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="ContributorLangauageRating"/> name.
        /// </value>
        public int CtlRating
        {
            get { return _ctlRating; }
            set { _ctlRating = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> source.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> source.
        /// </value>
        public byte[] WrkSource
        {
            get { return _wrkSource; }
            set { _wrkSource = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> target.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> target.
        /// </value>
        public byte[] WrkTarget
        {
            get { return _wrkTarget; }
            set { _wrkTarget = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItemDocument"/> wordcount.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItemDocument"/> wordcount.
        /// </value>
        public int DocWordcount
        {
            get { return _docWordCount; }
            set { _docWordCount = value; }
        }


        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> date created.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> _dateCreated.
        /// </value>
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> date Started.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> _dateStarted.
        /// </value>
        public DateTime? DateStarted
        {
            get { return _dateStarted; }
            set { _dateStarted = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> date Finished.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> _dateFinished.
        /// </value>
        public DateTime? DateFinished
        {
            get { return _dateFinished; }
            set { _dateFinished = value; }
        }


        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> date Edited.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> _dateEdited.
        /// </value>
        public DateTime? DateEdited
        {
            get { return _dateEdited; }
            set { _dateEdited = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> date DesCompletion.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> _dateDesCompletion.
        /// </value>
        public DateTime? DateDesCompletion
        {
            get { return _dateDesCompletion; }
            set { _dateDesCompletion = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> date EstCompletion.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> EstCompletion.
        /// </value>
        public DateTime? DateEstCompletion
        {
            get { return _dateEstCompletion; }
            set { _dateEstCompletion = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="WorkItem"/> date ActCompletion.
        /// </summary>
        /// <value>
        ///   <see cref="WorkItem"/> ActCompletion.
        /// </value>
        public DateTime? DateActCompletion
        {
            get { return _dateActCompletion; }
            set { _dateActCompletion = value; }
        }

        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="WorkItem"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is WorkItem))
            {
                throw new ArgumentException("Invalid Source Argument to WorkItem Assign");
            }
            base.AssignFromSource(aSource);
            _clnName = (aSource as WorkItem)._clnName;
            _conKey = (aSource as WorkItem)._conKey;
            _conName = (aSource as WorkItem)._conName;
            _conProofKey = (aSource as WorkItem)._conProofKey;
            _conProofName = (aSource as WorkItem)._conProofName;
            _ctlRating = (aSource as WorkItem)._ctlRating;
            _jbtType = (aSource as WorkItem)._jbtType;
            _wrkName = (aSource as WorkItem)._wrkName;
            _wrkSource = (aSource as WorkItem)._wrkSource;
            _wrkTarget = (aSource as WorkItem)._wrkTarget;
            _docWordCount = (aSource as WorkItem)._docWordCount;
            _dateCreated = (aSource as WorkItem)._dateCreated;
            _dateStarted = (aSource as WorkItem)._dateStarted;
            _dateFinished = (aSource as WorkItem)._dateFinished;
            _dateEdited = (aSource as WorkItem)._dateEdited;
            _dateDesCompletion = (aSource as WorkItem)._dateDesCompletion;
            _dateEstCompletion = (aSource as WorkItem)._dateEstCompletion;
            _dateActCompletion = (aSource as WorkItem)._dateActCompletion;
        }

        #endregion
    }
}
