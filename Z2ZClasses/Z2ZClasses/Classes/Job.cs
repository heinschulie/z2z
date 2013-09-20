using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class Job : JobKey
    {
        #region Fields

        private string _clnName;
        private string _jobName;
        private int _docKey; 
        private string _docName;
        private int _docWordCount;
        private int _lanSourceKey;
        private string _lanSourceNames;
        private int _lanTargetKey;
        private string _lanTargetNames;
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
            get { return _jobName; }
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
        ///   Gets or sets the <see cref="Job"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> name.
        /// </value>
        public string JobName
        {
            get { return _jobName; }
            set { _jobName = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Document"/> Key.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> Key.
        /// </value>
        public int DocKey
        {
            get { return _docKey; }
            set { _docKey = value; }
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
        ///   Gets or sets the <see cref="Document"/> wordcount.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> wordcount.
        /// </value>
        public int DocWordcount
        {
            get { return _docWordCount; }
            set { _docWordCount = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="languageSource"/> Key.
        /// </summary>
        /// <value>
        ///   <see cref="languageSource"/> Key.
        /// </value>
        public int LanSourceKey
        {
            get { return _lanSourceKey; }
            set { _lanSourceKey = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Document"/> name.
        /// </summary>
        /// <value>
        ///   <see cref="Document"/> name.
        /// </value>
        public string LanguageSourceNames
        {
            get { return _lanSourceNames; }
            set { _lanSourceNames = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="lanTargetKey"/> Key.
        /// </summary>
        /// <value>
        ///   <see cref="lanTargetKey"/> Key.
        /// </value>
        public int LanTargetKey
        {
            get { return _lanTargetKey; }
            set { _lanTargetKey = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="LanguageTarget"/> names.
        /// </summary>
        /// <value>
        ///   <see cref="LanguageTarget"/> names.
        /// </value>
        public string LanguageTargetNames
        {
            get { return _lanTargetNames; }
            set { _lanTargetNames = value; }
        }


        /// <summary>
        ///   Gets or sets the <see cref="Job"/> date created.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> _dateCreated.
        /// </value>
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Job"/> date Started.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> _dateStarted.
        /// </value>
        public DateTime? DateStarted
        {
            get { return _dateStarted; }
            set { _dateStarted = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Job"/> date Finished.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> _dateFinished.
        /// </value>
        public DateTime? DateFinished
        {
            get { return _dateFinished; }
            set { _dateFinished = value; }
        }


        /// <summary>
        ///   Gets or sets the <see cref="Job"/> date Edited.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> _dateEdited.
        /// </value>
        public DateTime? DateEdited
        {
            get { return _dateEdited; }
            set { _dateEdited = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Job"/> date DesCompletion.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> _dateDesCompletion.
        /// </value>
        public DateTime? DateDesCompletion
        {
            get { return _dateDesCompletion; }
            set { _dateDesCompletion = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Job"/> date EstCompletion.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> EstCompletion.
        /// </value>
        public DateTime? DateEstCompletion
        {
            get { return _dateEstCompletion; }
            set { _dateEstCompletion = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="Job"/> date ActCompletion.
        /// </summary>
        /// <value>
        ///   <see cref="Job"/> ActCompletion.
        /// </value>
        public DateTime? DateActCompletion
        {
            get { return _dateActCompletion; }
            set { _dateActCompletion = value; }
        }


        #endregion

        #region AssignFromSource

        /// <summary>
        ///   Assigns all <c>aSource</c> object's values to this instance of <see cref="Job"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is Job))
            {
                throw new ArgumentException("Invalid Source Argument to Job Assign");
            }
            base.AssignFromSource(aSource);
            _jobName = (aSource as Job)._jobName;
            _clnName = (aSource as Job)._clnName;
            _docKey = (aSource as Job)._docKey;
            _docName = (aSource as Job)._docName;
            _docWordCount = (aSource as Job)._docWordCount;
            _lanSourceKey = (aSource as Job)._lanSourceKey;
            _lanTargetKey = (aSource as Job)._lanTargetKey;
            _lanSourceNames = (aSource as Job)._lanSourceNames;
            _lanTargetNames = (aSource as Job)._lanTargetNames;

            _dateCreated = (aSource as Job)._dateCreated;
            _dateStarted = (aSource as Job)._dateStarted;
            _dateFinished = (aSource as Job)._dateFinished;
            _dateEdited = (aSource as Job)._dateEdited;
            _dateDesCompletion = (aSource as Job)._dateDesCompletion;
            _dateEstCompletion = (aSource as Job)._dateEstCompletion;
            _dateActCompletion = (aSource as Job)._dateActCompletion;
        }

        #endregion
    }
}
