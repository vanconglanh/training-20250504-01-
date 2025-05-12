using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Common
{
    public class Postal
    {
        private string _PostalString;

        private string _Address1;

        private string _Address2;

        private string _Address3;

        private string _Jigyosho_Name;

        public string PostalString
        {
            get
            {
                return _PostalString;
            }
            set
            {
                _PostalString = value;
            }
        }

        public string Address1
        {
            get
            {
                return _Address1;
            }
            set
            {
                _Address1 = value;
            }
        }

        public string Address2
        {
            get
            {
                return _Address2;
            }
            set
            {
                _Address2 = value;
            }
        }

        public string Address3
        {
            get
            {
                return _Address3;
            }
            set
            {
                _Address3 = value;
            }
        }

        public string Jigyosho_Name
        {
            get
            {
                return _Jigyosho_Name;
            }
            set
            {
                _Jigyosho_Name = value;
            }
        }

        public Postal()
        {
            _PostalString = "";
            _Address1 = "";
            _Address2 = "";
            _Address3 = "";
            _Jigyosho_Name = "";
        }

        public Postal(string vPostal, string vAddress1, string vAddress2, string vAddress3)
        {
            _PostalString = "";
            _Address1 = "";
            _Address2 = "";
            _Address3 = "";
            _Jigyosho_Name = "";
            _PostalString = vPostal;
            _Address1 = vAddress1;
            _Address2 = vAddress2;
            _Address3 = vAddress3;
        }

        public Postal(string vPostal, string vAddress1, string vAddress2, string vAddress3, string vJigyosho_Name)
            : this(vPostal, vAddress1, vAddress2, vAddress3)
        {
            _Jigyosho_Name = vJigyosho_Name;
        }

        public string GetFullAddress()
        {
            return _Address1 + _Address2 + _Address3;
        }

        public string GetAddress()
        {
            return _Address2 + _Address3;
        }
    }
}
