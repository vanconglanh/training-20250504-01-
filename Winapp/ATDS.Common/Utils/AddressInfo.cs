using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;


namespace ATDS.Common
{
    public class AddressInfo
    {
        private string _Postal;

        private string _Address1;

        private string _Address2;

        private string _Address3;

        private string _Tel;

        private string _Fax;

        private string _MailAddress;

        private string _Mobile;

        private string _MobileAddress;

        private string _HP;

        public string Postal
        {
            //get
            //{
            //    string text = "";
            //    //if (Haifun & (Operators.CompareString(_Postal, "", TextCompare: false) != 0))
            //    //TODO
            //    if ((Operators.CompareString(_Postal, "", TextCompare: false) != 0))
            //    {
            //        return Strings.Left(_Postal, 3) + "-" + Strings.Right(_Postal, 4);
            //    }

            //    return _Postal;
            //}
            set
            {
                _Postal = value;
            }
        }
        // Lanh: Added
        public string GetPostal(bool Haifun = false)
        {
            if (Haifun & (Operators.CompareString(_Postal, "", TextCompare: false) != 0))
            {
                return Strings.Left(_Postal, 3) + "-" + Strings.Right(_Postal, 4);
            }

            return _Postal;
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

        public string Tel
        {
            get
            {
                return _Tel;
            }
            set
            {
                _Tel = value;
            }
        }

        public string Fax
        {
            get
            {
                return _Fax;
            }
            set
            {
                _Fax = value;
            }
        }

        public string MailAddress
        {
            get
            {
                return _MailAddress;
            }
            set
            {
                _MailAddress = value;
            }
        }

        public string Mobile
        {
            get
            {
                return _Mobile;
            }
            set
            {
                _Mobile = value;
            }
        }

        public string MobileAddress
        {
            get
            {
                return _MobileAddress;
            }
            set
            {
                _MobileAddress = value;
            }
        }

        public string HP
        {
            get
            {
                return _HP;
            }
            set
            {
                _HP = value;
            }
        }

        public AddressInfo()
        {
            _Postal = "";
            _Address1 = "";
            _Address2 = "";
            _Address3 = "";
            _Tel = "";
            _Fax = "";
            _MailAddress = "";
            _Mobile = "";
            _MobileAddress = "";
            _HP = "";
        }

        public string FullAddress()
        {
            return _Address1 + _Address2 + _Address3;
        }
    }
}
