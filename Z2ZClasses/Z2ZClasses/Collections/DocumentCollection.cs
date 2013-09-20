using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace Z2Z
{
    public class DocumentCollection : Zephob
    {
        #region Fields

        private DocumentFilter _documentFilter = new DocumentFilter();
        private List<Document> _documentList = new List<Document>();

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the Document filter.
        /// </summary>
        /// <value>
        /// The Document filter.
        /// </value>
        public DocumentFilter DocumentFilter
        {
            get { return _documentFilter; }
            set { _documentFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="Document"/> list.
        /// </summary>
        /// <value>
        /// The Document list.
        /// </value>
        public List<Document> DocumentList
        {
            get { return _documentList; }
            set { _documentList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="ProviderCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is DocumentCollection))
            {
                throw new ArgumentException("Invalid assignment source", "DocumentCollection");
            }

            _documentFilter.AssignFromSource((aSource as DocumentCollection)._documentFilter);
            _documentList.Clear();
            (aSource as DocumentCollection)._documentList.ForEach(vDocumentSource =>
            {
                Document vDocumentTarget = new Document();
                vDocumentTarget.AssignFromSource(vDocumentSource);
                _documentList.Add(vDocumentTarget);
            });
        }

        #endregion
    }
}
