using Microsoft.AspNetCore.Components.Forms;
using System.Collections;
using System.Globalization;
using System.Resources;
using static ATDS.API.Info.Enum.Enum;

namespace ATDS.API.Helper
{
    public static class LanguageHelper
    {
        //public LanguageHelper(int language)
        //{
        //    SetLanguage(language);
        //}

        //public void SetLanguage(int language)
        //{
        //    string lang = "";
        //    switch (language)
        //    {
        //        case (int)LanguageEnum.Vietnamese:
        //            lang = "vi-VN";
        //            break;
        //        case (int)LanguageEnum.English:
        //            lang = "en-GB";
        //            break;
        //        case (int)LanguageEnum.Japanese:
        //            lang = "ja-JP";
        //            break;
        //    }
        //    try
        //    {
        //        NumberFormatInfo numberInfo = CultureInfo.CreateSpecificCulture(lang).NumberFormat;
        //        CultureInfo info = new CultureInfo(lang);
        //        info.NumberFormat = numberInfo;
        //        //later, we will if-else the language here
        //        //info.DateTimeFormat.DateSeparator = "/";
        //        //info.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        //        //Thread.CurrentThread.CurrentUICulture = info;
        //        //Thread.CurrentThread.CurrentCulture = info;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static string GetStringByLanguage(string key, int defaultLanguage = 0, LanguageEnum? language = null)
        {
            string strResult = string.Empty;
            // if dont set language -> set for default value
            if (language == null)
            {
                language = (LanguageEnum)defaultLanguage;
            }

            //get value
            switch (language)
            {
                case LanguageEnum.Vietnamese:

                    strResult = "VN";
                    break;
                case LanguageEnum.English:
                    strResult =  "EN";
                    break;
                case LanguageEnum.Japanese:
                    strResult = "JP";
                    break;
;
            }

            return strResult;
        }
    }
}
