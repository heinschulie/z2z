using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry; 

namespace Z2Z
{
    public class ClientCollection : Zephob
    {
        #region Fields

        private ClientFilter _clientFilter = new ClientFilter();
        private List<Client> _clientList = new List<Client>();

        #endregion

        #region  Properties

        /// <summary>
        /// Gets or sets the provider filter.
        /// </summary>
        /// <value>
        /// The provider filter.
        /// </value>
        public ClientFilter ClientFilter
        {
            get { return _clientFilter; }
            set { _clientFilter = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="Provider"/> list.
        /// </summary>
        /// <value>
        /// The Provider list.
        /// </value>
        public List<Client> ClientList
        {
            get { return _clientList; }
            set { _clientList = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///    Assigns all <c>aSource</c> object's values to this instance of <see cref="ProviderCollection"/>.
        /// </summary>
        /// <param name="aSource">A source object.</param>
        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ClientCollection))
            {
                throw new ArgumentException("Invalid assignment source", "ClientCollection");
            }

            _clientFilter.AssignFromSource((aSource as ClientCollection)._clientFilter);
            _clientList.Clear();
            (aSource as ClientCollection)._clientList.ForEach(vClientSource =>
            {
                Client vClientTarget = new Client();
                vClientTarget.AssignFromSource(vClientSource);
                _clientList.Add(vClientTarget);
            });
        }

        #endregion
    }
}
