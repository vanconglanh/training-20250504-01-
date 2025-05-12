using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.Common
{
    [StandardModule]
    public sealed class FunctionLib
    {
        public enum CommonFlag : byte
        {
            FlagOff,
            FlagOn
        }

        public enum DisplayCalendarDiv : byte
        {
            YYMMDD,
            YYYYMMDD,
            MMDD,
            YYYYMM,
            TIME,
            YYYYMMDD_DDD,
            YYYY
        }

        public enum FractionType : byte
        {
            Round_Down,
            Round_Up,
            Round_Off
        }

        public enum SeirekiWarekiDiv : byte
        {
            Seireki = 1,
            Wareki
        }

        public const string lcFormat_S_YMD = "yyyy/MM/dd";

        public const string lcFormat_S_YMD2 = "yy/MM/dd";

        public const string lcFormat_S_YMD_DDD = "yyyy/MM/dd (ddd)";

        public const string lcFormat_S_MD = "MM/dd";

        public const string lcFormat_S_YM = "yyyy/MM";

        public const string lcFormat_S_TIME = "HH:mm";

        public const string lcFormat_S_Y = "yyyy";

        public const string lcFormat_W_YMD = "ggyy年MM月dd日";

        public const string lcFormat_W_YMD_DDD = "ggyy年MM月dd日 (ddd)";

        public const string lcFormat_W_MD = "MM月dd日";

        public const string lcFormat_W_YM = "ggyy年MM月";

        public const string lcFormat_W_TIME = "HH時mm分";

        public const string lcFormat_W_Y = "ggyy年";

        public const string lcKana_S = "ｧｨｩｪｫｬｭｮｯぁぃぅぇぉっゃゅょゎァィゥェォッャュョヮヵヶｰ";

        public const string lcKana_L = "ｱｲｳｴｵﾔﾕﾖﾂあいうえおつやゆよわアイウエオツヤユヨワカケ-";

        public const string lcPadKey_Space = " ";

        public const string lcPadKey_Zero = "0";

        public const string lcHintText_SpaceSearch = "スペースキーで検索画面を表示します";

        public const string lcMessageText_NodataInSearch = "該当するデータはありません。";

        public const string lcMessageText_Nodata = "データがありません。";

        public const string lcMessageText_Insert = "登録しますか？";

        public const string lcMessageText_Update = "変更しますか？";

        public const string lcMessageText_Apply = "申請しますか？";

        public const string lcMessageText_Delete = "削除しますか？";

        public const string lcMessageText_Proc = "処理を行いますか？";

        public const string lcMessageText_Save = "保存しますか？";

        public static DateTime CCDate(string strDate)
        {
            DateTime minValue = DateTime.MinValue;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if (Operators.CompareString(strDate, "", TextCompare: false) == 0)
            {
                return minValue;
            }

            if (strDate.Length == 8)
            {
                num = Conversions.ToInteger(MidByte(strDate, 0, 4));
                num2 = Conversions.ToInteger(MidByte(strDate, 4, 2));
                num3 = Conversions.ToInteger(MidByte(strDate, 6, 2));
            }
            else
            {
                strDate = strDate.PadLeft(6, '0');
                num = Conversions.ToInteger(MidByte(strDate, 0, 2));
                num2 = Conversions.ToInteger(MidByte(strDate, 2, 2));
                num3 = Conversions.ToInteger(MidByte(strDate, 4, 2));
            }
            return DateTime.Parse(Conversions.ToString(num) + "/" + Conversions.ToString(num2) + "/" + Conversions.ToString(num3));
        }

        public static string CCDate(DateTime dteDate)
        {
            string result = "";
            if (Information.IsNothing(dteDate))
            {
                return result;
            }

            return dteDate.ToString("yyyyMMdd");
        }

        public static DateTime CTime(string strDate)
        {
            DateTime minValue = DateTime.MinValue;
            int num = 0;
            int num2 = 0;
            if (Operators.CompareString(strDate, "", TextCompare: false) == 0)
            {
                return minValue;
            }

            if (strDate.Length == 4)
            {
                num = Conversions.ToInteger(MidByte(strDate, 0, 2));
                num2 = Conversions.ToInteger(MidByte(strDate, 2, 2));
            }
            else
            {
                strDate = strDate.PadLeft(6, '0');
                num = Conversions.ToInteger(MidByte(strDate, 0, 2));
                num2 = Conversions.ToInteger(MidByte(strDate, 2, 2));
            }

            return DateTime.Parse(Conversions.ToString(num) + ":" + Conversions.ToString(num2));
        }

        public static string CTime(DateTime dteDate)
        {
            string result = "";
            if (Information.IsNothing(dteDate))
            {
                return result;
            }

            return dteDate.ToString("HHmm");
        }

        public static byte CCByte(object objBoolean)
        {
            if (Conversions.ToBoolean(objBoolean))
            {
                return 1;
            }

            return 0;
        }

        public static bool CCByte(byte objByte)
        {
            if (objByte == 1)
            {
                return true;
            }

            return false;
        }

        public static object Nz(object Value, object Value2)
        {
            if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(Value)) || Value == null)
            {
                return Value2;
            }

            return Value;
        }

        public static int LenByte(string myString)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            return encoding.GetByteCount(myString);
        }

        public static string MidByte(string myString, int StartIndex, int Count)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            byte[] bytes = encoding.GetBytes(myString);
            int byteCount = encoding.GetByteCount(myString);
            string text = "";
            if (StartIndex < 0 || Count <= 0 || StartIndex > byteCount)
            {
                return "";
            }

            text = encoding.GetString(bytes, 0, StartIndex);
            checked
            {
                if ((StartIndex > 0) & text.EndsWith("\0"))
                {
                    StartIndex++;
                }

                if (StartIndex + Count > byteCount)
                {
                    Count = byteCount - StartIndex;
                }

                return encoding.GetString(bytes, StartIndex, Count).TrimEnd(default(char));
            }
        }

        public static string CWareki(DateTime vdteDate, string vstrFormat = "ggyy年MM月dd日")
        {
            string text = "";
            CultureInfo cultureInfo = new CultureInfo("ja-JP");
            JapaneseCalendar calendar = new JapaneseCalendar();
            string result;
            try
            {
                cultureInfo.DateTimeFormat.Calendar = calendar;
                text = vdteDate.ToString(vstrFormat, cultureInfo);
                result = text;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                result = "";
                ProjectData.ClearProjectError();
            }

            return result;
        }

        public static string NendoCalc(string strDate, int Kishu)
        {
            try
            {
                if ((Operators.CompareString(strDate, "", TextCompare: false) == 0) | (strDate.Length != 8))
                {
                    return "";
                }

                DateTime dateTime = CCDate(strDate);
                if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
                {
                    return "";
                }

                return NendoCalc(dateTime, Kishu);
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public static string NendoCalc(DateTime dteDate, int Kishu)
        {
            try
            {
                if (Kishu > Conversions.ToInteger(dteDate.ToString("MM")))
                {
                    dteDate = dteDate.AddYears(-1);
                }

                return dteDate.ToString("yyyy");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public static bool GetKaihiKankaku(DateTime dteDate, int Kishu, int Kankaku, ref string FromDate, ref string ToDate)
        {
            string text = "";
            try
            {
                text = NendoCalc(dteDate, Kishu);
                DateTime t = Conversions.ToDate(text + "/" + Conversions.ToString(Kishu) + "/01");
                while (DateTime.Compare(dteDate, t) >= 0)
                {
                    t = t.AddMonths(Kankaku);
                }

                FromDate = t.ToString("yyyyMM");
                ToDate = t.AddMonths(checked(Kankaku - 1)).ToString("yyyyMM");
                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public static bool GetKaihiKankaku_ThisTime(DateTime dteDate, int Kishu, int Kankaku, ref string FromDate, ref string ToDate)
        {
            string text = "";
            try
            {
                text = NendoCalc(dteDate, Kishu);
                DateTime t = Conversions.ToDate(text + "/" + Conversions.ToString(Kishu) + "/01");
                while (DateTime.Compare(dteDate, t) >= 0)
                {
                    t = t.AddMonths(Kankaku);
                }

                FromDate = dteDate.ToString("yyyyMM");
                ToDate = t.AddMonths(-1).ToString("yyyyMM");
                return true;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public static string GetLastDay(string strDate)
        {
            try
            {
                DateTime dateTime = CCDate(strDate);
                if (Information.IsNothing(dateTime))
                {
                    return "";
                }

                if (DateTime.Compare(dateTime, DateTime.MinValue) == 0)
                {
                    return "";
                }

                return CCDate(GetLastDay(dateTime));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
            finally
            {
            }
        }

        public static DateTime GetLastDay(DateTime dteDate)
        {
            DateTime minValue = DateTime.MinValue;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            try
            {
                num = dteDate.Year;
                num2 = dteDate.Month;
                num3 = DateTime.DaysInMonth(num, num2);
                return Conversions.ToDate(Conversions.ToString(num) + "/" + Conversions.ToString(num2) + "/" + Conversions.ToString(num3));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
            finally
            {
            }
        }

        public static string SetFixedStrings(string myString, int Count, string PadString, bool IsPadLeft)
        {
            string text = MidByte(myString, 0, Count);
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            byte[] bytes = encoding.GetBytes(text);
            int byteCount = encoding.GetByteCount(text);
            int num = 0;
            string text2 = "";
            string result = "";
            if (Count <= 0 || byteCount < 0)
            {
                return result;
            }

            num = checked(Count - byteCount);
            text2 = text2.PadLeft(num, Conversions.ToChar(PadString));
            return (Count < byteCount) ? encoding.GetString(bytes, 0, byteCount).TrimEnd(default(char)) : ((Count <= byteCount) ? text : ((!IsPadLeft) ? (text + text2) : (text2 + text)));
        }

        public static string KanaLConv(string myString)
        {
            string sDest = myString;
            int num = Strings.Len(myString);
            for (int i = 1; i <= num; i = checked(i + 1))
            {
                string @string = Strings.Mid(myString, i, 1);
                int num2 = Strings.InStr(1, "ｧｨｩｪｫｬｭｮｯぁぃぅぇぉっゃゅょゎァィゥェォッャュョヮヵヶｰ", @string);
                if (num2 > 0)
                {
                    StringType.MidStmtStr(ref sDest, i, int.MaxValue, Strings.Mid("ｱｲｳｴｵﾔﾕﾖﾂあいうえおつやゆよわアイウエオツヤユヨワカケ-", num2, 1));
                }
            }

            return sDest;
        }

        public static string ReplaceMark(string myString)
        {
            string text = "";
            try
            {
                return myString.Replace("'", "''");
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public static DataSet CollectDataset(DataSet dataDS, DataSet commentDS)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();
            try
            {
                dataTable = dataDS.Tables[0].Copy();
                dataTable2 = commentDS.Tables[0].Copy();
                dataTable2.TableName = "comment";
                dataSet.Tables.Add(dataTable);
                dataSet.Tables.Add(dataTable2);
                return dataSet;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
            finally
            {
                dataSet = null;
                dataTable = null;
                dataTable2 = null;
            }
        }

        public static decimal FractionProc(decimal vdecNum, FractionType venmHasuType, int vintDecimalPlaces)
        {
            return FractionProc(vdecNum, (byte)venmHasuType, vintDecimalPlaces);
        }

        public static decimal FractionProc(decimal vdecNum, byte vbytHasu, int vintDecimalPlaces)
        {
            decimal num = default(decimal);
            int num2 = 0;
            decimal num3 = default(decimal);
            bool flag = false;
            if (decimal.Compare(vdecNum, 0m) < 0)
            {
                flag = true;
                vdecNum = Math.Abs(vdecNum);
            }

            checked
            {
                switch (vbytHasu)
                {
                    case 0:
                        num = new decimal(Math.Pow(10.0, vintDecimalPlaces));
                        vdecNum = Conversion.Fix(decimal.Multiply(vdecNum, num));
                        vdecNum = decimal.Divide(vdecNum, num);
                        break;
                    case 1:
                        num2 = vdecNum.ToString().IndexOf(".");
                        if (num2 != -1 && vdecNum.ToString().Length - (num2 + 1) > vintDecimalPlaces)
                        {
                            num = new decimal(Math.Pow(10.0, vintDecimalPlaces + 1));
                            vdecNum = decimal.Add(decimal.Multiply(vdecNum, num), 4m);
                            num3 = decimal.Multiply(Conversions.ToDecimal(Nz(vdecNum.ToString().Remove(0, num2 + 1), 0)), 0.1m);
                            if (decimal.Compare(num3, 0m) > 0)
                            {
                                vdecNum = decimal.Add(vdecNum, 1m);
                            }
                            vdecNum = decimal.Divide(vdecNum, num);
                        }

                        break;
                }

                vdecNum = Conversions.ToDecimal(Strings.FormatNumber(vdecNum, vintDecimalPlaces, TriState.True, TriState.False, TriState.False));
                if (flag)
                {
                    vdecNum = decimal.Multiply(vdecNum, -1m);
                }

                return vdecNum;
            }
        }

        public static string CCDate_Bugyo(string strDate)
        {
            DateTime minValue = DateTime.MinValue;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            if (Operators.CompareString(strDate, "", TextCompare: false) == 0)
            {
                return "";
            }

            if (strDate.Length == 8)
            {
                num = Conversions.ToInteger(MidByte(strDate, 0, 4));
                num2 = Conversions.ToInteger(MidByte(strDate, 4, 2));
                num3 = Conversions.ToInteger(MidByte(strDate, 6, 2));
            }
            else
            {
                strDate = strDate.PadLeft(6, '0');
                num = Conversions.ToInteger(MidByte(strDate, 0, 2));
                num2 = Conversions.ToInteger(MidByte(strDate, 2, 2));
                num3 = Conversions.ToInteger(MidByte(strDate, 4, 2));
            }

            return DateTime.Parse(Conversions.ToString(num) + "/" + Conversions.ToString(num2) + "/" + Conversions.ToString(num3)).ToString("yyyyMMdd");
        }
    }
}
