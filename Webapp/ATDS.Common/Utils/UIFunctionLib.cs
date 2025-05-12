using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.Common
{
    [StandardModule]
    public sealed class UIFunctionLib
    {
        private const string lcRegex_YMD = "[0-9]{8}";

        private const string lcRegex_S_YMD = "[0-9][0-9][0-9][0-9](\\.|/|\\-)[0-9]{1,2}(\\.|/|\\-)[0-9]{1,2}";

        private const string lcRegex_YM = "[0-9]{6}";

        private const string lcRegex_S_YM = "[0-9][0-9][0-9][0-9](\\.|/|\\-)[0-9]{1,2}";

        private const string lcRegex_S_Y = "[0-9][0-9][0-9][0-9]";

        private const string lcRegex_W_MD = "[0-9]{1,2}(月)[0-9]{1,2}(日)";

        private const string lcRegex_S_MD = "[0-9]{1,2}(\\.|/|\\-)[0-9]{1,2}";

        private const string lcRegex_TIME = "[0-9]{4}";

        private const string lcRegex_W_TIME = "[0-9]{1,2}(時)[0-9]{1,2}(分)";

        private const string lcRegex_S_TIME = "[0-9]{1,2}(\\.|:|\\-)[0-9]{1,2}";

        private static string lcRegex_W_YMD()
        {
            return "(" + EraAlpJoin() + ")[0-9]{1,2}(\\.|/|\\-)[0-9]{1,2}(\\.|/|\\-)[0-9]{1,2}";
        }

        private static string lcRegex_W_YMD2()
        {
            return "(" + EraJoin() + ")[0-9]{1,2}(年)[0-9]{1,2}(月)[0-9]{1,2}(日)";
        }

        private static string lcRegex_W_YM1()
        {
            return "(" + EraAlpJoin() + ")[0-9]{1,2}(\\.|/|\\-)[0-9]{1,2}";
        }

        private static string lcRegex_W_YM2()
        {
            return "(" + EraJoin() + ")[0-9]{1,2}(年)[0-9]{1,2}(月)";
        }

        private static string lcRegex_W_Y1()
        {
            return "(" + EraAlpJoin() + ")[0-9]{1,2}";
        }

        private static string lcRegex_W_Y2()
        {
            return "(" + EraJoin() + ")[0-9]{1,2}(年)";
        }

        public static string lcRegex_W_Alp()
        {
            return "(" + EraAlpJoin() + ")";
        }

        private static string EraJoin()
        {
            string text = "";
            foreach (KeyValuePair<int, string> item in GetEra())
            {
                text = text + Interaction.IIf(Operators.CompareString(text, "", TextCompare: false) == 0, "", "|").ToString() + item.Value;
            }

            return text;
        }

        private static string EraAlpJoin()
        {
            string text = "";
            foreach (KeyValuePair<int, string> item in GetEraAlp())
            {
                text = text + Interaction.IIf(Operators.CompareString(text, "", TextCompare: false) == 0, "", "|").ToString() + item.Value;
                text = text + Interaction.IIf(Operators.CompareString(text, "", TextCompare: false) == 0, "", "|").ToString() + item.Value.ToLower();
            }

            return text;
        }

        private static Dictionary<int, string> GetEra()
        {
            JapaneseCalendar japaneseCalendar = new JapaneseCalendar();
            CultureInfo cultureInfo = new CultureInfo("ja-JP", useUserOverride: false);
            cultureInfo.DateTimeFormat.Calendar = japaneseCalendar;
            int[] eras = japaneseCalendar.Eras;
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            int[] array = eras;
            foreach (int num in array)
            {
                dictionary.Add(num, cultureInfo.DateTimeFormat.GetEraName(num));
            }

            return dictionary;
        }

        private static Dictionary<int, string> GetEraAlp()
        {
            JapaneseCalendar calendar = new JapaneseCalendar();
            CultureInfo cultureInfo = new CultureInfo("ja-JP", useUserOverride: false);
            cultureInfo.DateTimeFormat.Calendar = calendar;
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            int num = 65;
            do
            {
                string text = Conversions.ToString(Strings.ChrW(num));
                int era = cultureInfo.DateTimeFormat.GetEra(text);
                if (era > 0)
                {
                    dictionary.Add(era, text);
                }

                num = checked(num + 1);
            }
            while (num <= 90);
            return dictionary;
        }

        // TODO: Change optional to other option
        //public static string ChangeDate(string strDate, FunctionLib.SeirekiWarekiDiv Div, FunctionLib.DisplayCalendarDiv DisplayCalendar = FunctionLib.DisplayCalendarDiv.YYYYMMDD, [Optional][DefaultParameterValue("")] ref string DateString)
        public static string ChangeDate(string strDate, FunctionLib.SeirekiWarekiDiv Div, FunctionLib.DisplayCalendarDiv DisplayCalendar = FunctionLib.DisplayCalendarDiv.YYYYMMDD, string DateString = "")
        {
            string text = "";
            string result = "";
            try
            {
                if (Operators.CompareString(strDate, "", TextCompare: false) == 0)
                {
                    return "";
                }

                if (Regex.IsMatch(Strings.Trim(strDate), "[0-9][0-9][0-9][0-9](\\.|/|\\-)[0-9]{1,2}(\\.|/|\\-)[0-9]{1,2}") | Regex.IsMatch(Strings.Trim(strDate), lcRegex_W_YMD()) | Regex.IsMatch(Strings.Trim(strDate), lcRegex_W_YMD2()))
                {
                    text = strDate;
                }
                else if (Regex.IsMatch(Strings.Trim(strDate), "[0-9]{8}"))
                {
                    text = Strings.Left(strDate, 4) + "/" + Strings.Mid(strDate, 5, 2) + "/" + Strings.Right(strDate, 2);
                }
                else if (Regex.IsMatch(Strings.Trim(strDate), "[0-9]{6}"))
                {
                    text = Strings.Left(strDate, 4) + "/" + Strings.Mid(strDate, 5, 2) + "/01";
                }
                else if (Regex.IsMatch(Strings.Trim(strDate), "[0-9][0-9][0-9][0-9](\\.|/|\\-)[0-9]{1,2}") | Regex.IsMatch(Strings.Trim(strDate), lcRegex_W_YM1()))
                {
                    text = strDate + "/01";
                }
                else if (Regex.IsMatch(Strings.Trim(strDate), lcRegex_W_YM2()))
                {
                    text = ((!strDate.EndsWith("月")) ? (strDate + "月01日") : (strDate + "01日"));
                }
                else if (Regex.IsMatch(strDate, "[0-9]{1,2}(\\.|/|\\-)[0-9]{1,2}") | Regex.IsMatch(Strings.Trim(strDate), "[0-9]{1,2}(月)[0-9]{1,2}(日)"))
                {
                    text = strDate;
                }
                else if (Regex.IsMatch(strDate, "[0-9][0-9][0-9][0-9]") | Regex.IsMatch(Strings.Trim(strDate), lcRegex_W_Y1()))
                {
                    text = strDate + "/01/01";
                }
                else if (Regex.IsMatch(Strings.Trim(strDate), lcRegex_W_Y2()))
                {
                    text = ((!strDate.EndsWith("年")) ? (strDate + "年01月01日") : (strDate + "01月01日"));
                }

                if (Information.IsDate(text))
                {
                    DateTime dateTime = Conversions.ToDate(text);
                    if ((DateTime.Compare(dateTime, FunctionLib.CCDate("19000101")) >= 0) & (DateTime.Compare(dateTime, FunctionLib.CCDate("20871231")) <= 0))
                    {
                        //result = ChangeDate(dateTime, Div, DisplayCalendar, ref DateString);
                        // TODO
                        result = ChangeDate(dateTime, Div, DisplayCalendar, DateString);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        //public static string ChangeDate(DateTime dteDate, FunctionLib.SeirekiWarekiDiv Div, FunctionLib.DisplayCalendarDiv DisplayCalendar = FunctionLib.DisplayCalendarDiv.YYYYMMDD, [Optional][DefaultParameterValue("")] ref string DateString)
        public static string ChangeDate(DateTime dteDate, FunctionLib.SeirekiWarekiDiv Div, FunctionLib.DisplayCalendarDiv DisplayCalendar = FunctionLib.DisplayCalendarDiv.YYYYMMDD, string DateString = "")
        {
            string text = "";
            string text2 = "yyyy/MM/dd";
            try
            {
                if (Div == FunctionLib.SeirekiWarekiDiv.Seireki)
                {
                    switch (DisplayCalendar)
                    {
                        case FunctionLib.DisplayCalendarDiv.YYYYMMDD:
                            text2 = "yyyy/MM/dd";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYMMDD:
                            text2 = "yy/MM/dd";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYYMM:
                            text2 = "yyyy/MM";
                            break;
                        case FunctionLib.DisplayCalendarDiv.MMDD:
                            text2 = "MM/dd";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYY:
                            text2 = "yyyy";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYYMMDD_DDD:
                            text2 = "yyyy/MM/dd (ddd)";
                            break;
                    }

                    text = dteDate.ToString(text2);
                }
                else
                {
                    switch (DisplayCalendar)
                    {
                        case FunctionLib.DisplayCalendarDiv.YYMMDD:
                        case FunctionLib.DisplayCalendarDiv.YYYYMMDD:
                            text2 = "ggyy年MM月dd日";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYYMM:
                            text2 = "ggyy年MM月";
                            break;
                        case FunctionLib.DisplayCalendarDiv.MMDD:
                            text2 = "MM月dd日";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYY:
                            text2 = "ggyy年";
                            break;
                        case FunctionLib.DisplayCalendarDiv.YYYYMMDD_DDD:
                            text2 = "ggyy年MM月dd日 (ddd)";
                            break;
                    }

                    text = FunctionLib.CWareki(dteDate, text2);
                }

                DateString = dteDate.ToString("yyyyMMdd");
                return text;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public static string ChangeTime(string strDate, FunctionLib.SeirekiWarekiDiv Div, [Optional][DefaultParameterValue("")] ref string TimeString)
        {
            string text = "";
            string result = "";
            try
            {
                if (Operators.CompareString(strDate, "", TextCompare: false) == 0)
                {
                    return "";
                }

                text = ((Regex.IsMatch(Strings.Trim(strDate), "[0-9]{1,2}(\\.|:|\\-)[0-9]{1,2}") | Regex.IsMatch(Strings.Trim(strDate), "[0-9]{1,2}(時)[0-9]{1,2}(分)")) ? strDate.Replace(".", ":").Replace("-", ":") : ((!Regex.IsMatch(Strings.Trim(strDate), "[0-9]{4}")) ? "" : (Strings.Left(strDate, 2) + ":" + Strings.Right(strDate, 2))));
                if (Operators.CompareString(text, "", TextCompare: false) != 0 && Information.IsDate(text))
                {
                    DateTime dteDate = Conversions.ToDate(text);
                    result = ChangeTime(dteDate, Div, ref TimeString);
                }

                return result;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public static string ChangeTime(DateTime dteDate, FunctionLib.SeirekiWarekiDiv Div, [Optional][DefaultParameterValue("")] ref string TimeString)
        {
            string text = "";
            string text2 = "HH:mm";
            try
            {
                if (Div == FunctionLib.SeirekiWarekiDiv.Seireki)
                {
                    text2 = "HH:mm";
                    text = dteDate.ToString(text2);
                }
                else
                {
                    text2 = "HH時mm分";
                    text = FunctionLib.CWareki(dteDate, text2);
                }

                TimeString = dteDate.ToString("HHmm");
                return text;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }
    }
}
