using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zephry;

namespace Z2Z
{
    public class ClientFilter : Zephob
    {
        private bool _isFiltered;
        private string _clientNameFilter;

        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
        }

        public string ClientNameFilter
        {
            get { return _clientNameFilter; }
            set { _clientNameFilter = value; }
        }

        public override void AssignFromSource(object aSource)
        {
            if (!(aSource is ClientFilter))
            {
                throw new ArgumentException("Invalid assignment source", "ClientFilter");
            }

            _isFiltered = (aSource as ClientFilter)._isFiltered;
            _clientNameFilter = (aSource as ClientFilter)._clientNameFilter;
        }
    }
}
