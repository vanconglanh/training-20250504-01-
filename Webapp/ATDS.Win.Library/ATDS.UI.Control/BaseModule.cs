using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.UI.Control
{
    [StandardModule]
    internal sealed class BaseModule
    {
        public static int LenB(string strTarget)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return Encoding.GetEncoding("Shift_JIS").GetByteCount(strTarget);
        }

        public static string LeftB(string stTarget, int iByteSize)
        {
            string result = "";
            if (Operators.CompareString(stTarget, "", TextCompare: false) != 0)
            {
                result = ((LenB(stTarget) > iByteSize) ? MidB(stTarget, 1, iByteSize) : stTarget);
            }

            return result;
        }

        public static string MidB(string stTarget, int iStart)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            byte[] bytes = encoding.GetBytes(stTarget);
            return checked(encoding.GetString(bytes, iStart - 1, bytes.Length - iStart + 1));
        }

        public static string MidB(string stTarget, int iStart, int iByteSize)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            byte[] bytes = encoding.GetBytes(stTarget);
            return encoding.GetString(bytes, checked(iStart - 1), iByteSize);
        }

        public static string RightB(string stTarget, int iByteSize)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            byte[] bytes = encoding.GetBytes(stTarget);
            return encoding.GetString(bytes, checked(bytes.Length - iByteSize), iByteSize);
        }
    }
}
