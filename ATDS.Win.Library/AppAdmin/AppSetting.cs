using System;
using System.Drawing;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.AppAdmin
{
    public class AppSetting
    {
        private const string AppSettingFile = "AppSetting.xml";

        private static string _AppHomeDir;

        private static string _BBS;

        private static string _UseDB;

        private static string _DBUser;

        private static string _DBPassword;

        private static string _DBInstance;

        private static string _DBName;

        private static string _UseDB2;

        private static string _DBUser2;

        private static string _DBPassword2;

        private static string _DBInstance2;

        private static string _DBName2;

        private static string _ErrLogFileName;

        private static string _InformationFileName;

        private static string _ImageSettingFileName;

        private static string _SoundSettingFileName;

        private static Font _AppFontBasic;

        private static Color _AppColorBasic;

        private static Color _AppColor1;

        private static Color _AppColor2;

        private static Color _AppColor3;

        private static Color _AppColor4;

        private static Color _AppColor5;

        private static string _CommonText1;

        private static string _CommonText2;

        private static string _CommonText3;

        private static string _CommonText4;

        private static string _CommonText5;

        private static bool _IsSettingFile;

        public static string AppHomeDir => _AppHomeDir;

        public static string MenuDir => _AppHomeDir + "menu\\";

        public static string ImageDir => _AppHomeDir + "img\\";

        public static string SoundDir => _AppHomeDir + "wav\\";

        public static string InfomationDir => _AppHomeDir + "info\\";

        public static string ErrLogDir => _AppHomeDir + "log\\";

        public static string AppUserHomeDir => _AppHomeDir + "home\\";

        public static string AppFunctionSettingDir => _AppHomeDir + "xml\\";

        public static string TempDir => _AppHomeDir + "tmp\\";

        public static string CsvDir => _AppHomeDir + "csv\\";

        public static string XmlDir => _AppHomeDir + "xml\\";

        public static string ExcelDir => _AppHomeDir + "xls\\";

        public static string MdbDir => _AppHomeDir + "mdb\\";

        public static string HelpDir => _AppHomeDir + "help\\";

        public static string ManualDir => _AppHomeDir + "man\\";

        public static string BBS => _BBS;

        public static string UseDB => _UseDB;

        public static string DBUser => _DBUser;

        public static string DBPassword => _DBPassword;

        public static string DBName => _DBName;

        public static string DBInstance => _DBInstance;

        public static string UseDB2 => _UseDB2;

        public static string DBUser2 => _DBUser2;

        public static string DBPassword2 => _DBPassword2;

        public static string DBInstance2 => _DBInstance2;

        public static string DBName2 => _DBName2;

        public static string ErrLogFileName => _ErrLogFileName;

        public static string InformationFileName => _InformationFileName;

        public static string ImageSettingFileName => _ImageSettingFileName;

        public static string SoundSettingFileName => _SoundSettingFileName;

        public static Font AppFontBasic => _AppFontBasic;

        public static Color AppColorBasic => _AppColorBasic;

        public static Color AppColor1 => _AppColor1;

        public static Color AppColor2 => _AppColor2;

        public static Color AppColor3 => _AppColor3;

        public static Color AppColor4 => _AppColor4;

        public static Color AppColor5 => _AppColor5;

        public static string CommonText1 => _CommonText1;

        public static string CommonText2 => _CommonText2;

        public static string CommonText3 => _CommonText3;

        public static string CommonText4 => _CommonText4;

        public static string CommonText5 => _CommonText5;

        public static bool IsSettingFile => _IsSettingFile;

        static AppSetting()
        {
            _AppHomeDir = AppDomain.CurrentDomain.BaseDirectory.ToString();
            _BBS = "";
            _UseDB = "";
            _DBUser = "";
            _DBPassword = "";
            _DBInstance = "";
            _DBName = "";
            _UseDB2 = "";
            _DBUser2 = "";
            _DBPassword2 = "";
            _DBInstance2 = "";
            _DBName2 = "";
            _ErrLogFileName = "Errlog.txt";
            _InformationFileName = "*.rtf";
            _ImageSettingFileName = "ImageSetting.xml";
            _SoundSettingFileName = "SoundSetting.xml";
            _AppFontBasic = new Font("MS UI Gothic", 9f);
            _AppColorBasic = Color.FromName("Control");
            _AppColor1 = Color.FromName("Control");
            _AppColor2 = Color.FromName("Control");
            _AppColor3 = Color.FromName("Control");
            _AppColor4 = Color.FromName("Control");
            _AppColor5 = Color.FromName("Control");
            _CommonText1 = "";
            _CommonText2 = "";
            _CommonText3 = "";
            _CommonText4 = "";
            _CommonText5 = "";
            _IsSettingFile = false;
            try
            {
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
        }

        public static void LoadAppSettings(string FilePath)
        {
            XmlDocument xmlDocument = new XmlDocument();
            checked
            {
                try
                {
                    xmlDocument.Load(FilePath + "AppSetting.xml");
                    foreach (XmlNode item in xmlDocument.GetElementsByTagName("AppSetting"))
                    {
                        XmlNode xmlNode2 = item;
                        int num = 0;
                        int num2 = xmlNode2.ChildNodes.Count - 1;
                        for (num = 0; num <= num2; num++)
                        {
                            switch (xmlNode2.ChildNodes[num].Name)
                            {
                                case "AppHomeDir":
                                    _AppHomeDir = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "BBS":
                                    _BBS = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "UseDB":
                                    _UseDB = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "DBUser":
                                    _DBUser = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "DBPassword":
                                    _DBPassword = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "DBName":
                                    _DBName = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "DBInstance":
                                    _DBInstance = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "UseDB2":
                                    _UseDB2 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "DBUser2":
                                    _DBUser2 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "DBPassword2":
                                    _DBPassword2 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "DBInstance2":
                                    _DBInstance2 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "DBName2":
                                    _DBName2 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "ErrLogFileName":
                                    _ErrLogFileName = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "InformationFileName":
                                    _InformationFileName = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "ImageSettingFileName":
                                    _ImageSettingFileName = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "SoundSettingFileName":
                                    _SoundSettingFileName = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "AppFontBasic":
                                    {
                                        string[] array = Strings.Split(xmlNode2.ChildNodes[num].InnerText, ";");
                                        _AppFontBasic = new Font(array[0], Conversions.ToSingle(array[1]));
                                        break;
                                    }
                                case "AppColorBasic":
                                    _AppColorBasic = Color.FromName(xmlNode2.ChildNodes[num].InnerText);
                                    break;
                                case "AppColor1":
                                    _AppColor1 = Color.FromName(xmlNode2.ChildNodes[num].InnerText);
                                    break;
                                case "AppColor2":
                                    _AppColor2 = Color.FromName(xmlNode2.ChildNodes[num].InnerText);
                                    break;
                                case "AppColor3":
                                    _AppColor3 = Color.FromName(xmlNode2.ChildNodes[num].InnerText);
                                    break;
                                case "AppColor4":
                                    _AppColor4 = Color.FromName(xmlNode2.ChildNodes[num].InnerText);
                                    break;
                                case "AppColor5":
                                    _AppColor5 = Color.FromName(xmlNode2.ChildNodes[num].InnerText);
                                    break;
                                case "CommonText1":
                                    _CommonText1 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "CommonText2":
                                    _CommonText2 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "CommonText3":
                                    _CommonText3 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "CommonText4":
                                    _CommonText4 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                                case "CommonText5":
                                    _CommonText5 = xmlNode2.ChildNodes[num].InnerText;
                                    break;
                            }
                        }

                        xmlNode2 = null;
                    }

                    _IsSettingFile = true;
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    //ErrLog.Write(new ErrLogInfo(ex2));
                    throw new Exception("設定ファイルの読込でエラー（AppSetting）", ex2);
                }
                finally
                {
                    xmlDocument = null;
                }

                if (!Directory.Exists(_AppHomeDir))
                {
                    throw new DirectoryNotFoundException("ホームディレクトリ「" + _AppHomeDir + "」が見つかりません。");
                }
            }
        }
    }
}
