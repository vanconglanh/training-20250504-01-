using System.Runtime.CompilerServices;

namespace ATDS.UI.Control
{   
    public class ComboItem
    {
        private string _Code;

        private string _Name;

        private object _Value;

        public string Code => _Code;

        public string Name => _Name;

        public object Value => _Value;

        public ComboItem()
        {
        }

        public ComboItem(string Code, string Name, object Value)
        {
            _Code = Code;
            _Name = Name;
            _Value = RuntimeHelpers.GetObjectValue(Value);
        }
    }
}
