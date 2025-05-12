using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ATDS.Common
{
    public class CSVOutput
    {
        private enum LC_CHKFLG : byte
        {
            OK,
            SV,
            CL,
            NG
        }

        private const string lcstrHideColName = "HIDE_COL";

        private string _SVOutputPath;

        private string _SVOutputFileNM;

        private string _CLOutputPath;

        private string _CLOutputFileNM;

        private bool _QuotAddFLG;

        private bool _HeadAddFLG;

        private bool _OverWriteFLG;

        public string SVOutputPath
        {
            get
            {
                return _SVOutputPath;
            }
            set
            {
                _SVOutputPath = value;
            }
        }

        public bool QuotAddFLG
        {
            get
            {
                return _QuotAddFLG;
            }
            set
            {
                _QuotAddFLG = value;
            }
        }

        public bool HeadAddFLG
        {
            get
            {
                return _HeadAddFLG;
            }
            set
            {
                _HeadAddFLG = value;
            }
        }

        public bool OverWriteFLG
        {
            get
            {
                return _OverWriteFLG;
            }
            set
            {
                _OverWriteFLG = value;
            }
        }

        public string SVOutputFileNM
        {
            get
            {
                return _SVOutputFileNM;
            }
            set
            {
                _SVOutputFileNM = value;
            }
        }

        public string CLOutputPath
        {
            get
            {
                return _CLOutputPath;
            }
            set
            {
                _CLOutputPath = value;
            }
        }

        public string CLOutputFileNM
        {
            get
            {
                return _CLOutputFileNM;
            }
            set
            {
                _CLOutputFileNM = value;
            }
        }

        public CSVOutput()
        {
            _SVOutputPath = FileSystem.CurDir();
            _SVOutputFileNM = "NoName";
            _CLOutputPath = "";
            _CLOutputFileNM = "NoName";
            _QuotAddFLG = true;
            _HeadAddFLG = true;
            _OverWriteFLG = true;
        }

        public CSVOutput(string FileName)
        {
            _SVOutputPath = FileSystem.CurDir();
            _SVOutputFileNM = "NoName";
            _CLOutputPath = "";
            _CLOutputFileNM = "NoName";
            _QuotAddFLG = true;
            _HeadAddFLG = true;
            _OverWriteFLG = true;
            _SVOutputPath = "";
            _SVOutputFileNM = "";
            _CLOutputPath = Path.GetDirectoryName(FileName);
            _CLOutputFileNM = Path.GetFileName(FileName);
        }

        public void MakeCSV(DataRow dr)
        {
            checked
            {
                string[,] array = new string[1, dr.ItemArray.Length - 1 + 1];
                object[] itemArray = dr.ItemArray;
                int lowerBound = itemArray.GetLowerBound(0);
                int upperBound = itemArray.GetUpperBound(0);
                int index = default(int);
                for (int i = lowerBound; i <= upperBound; i++)
                {
                    array.SetValue(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(itemArray.GetValue(i)), "").ToString(), index, i);
                }

                itemArray = null;
                MakeCSV(array);
                array = null;
            }
        }

        public void MakeCSV(DataTable dt)
        {
            checked
            {
                int num = default(int);
                string[,] array;
                if (HeadAddFLG)
                {
                    array = new string[dt.Rows.Count + 1, dt.Columns.Count - 1 + 1];
                    {
                        IEnumerator enumerator = dt.Rows.GetEnumerator();
                        try
                        {
                            if (enumerator.MoveNext())
                            {
                                DataRow dataRow = (DataRow)enumerator.Current;
                                object[] itemArray = dataRow.ItemArray;
                                int lowerBound = itemArray.GetLowerBound(0);
                                int upperBound = itemArray.GetUpperBound(0);
                                for (int i = lowerBound; i <= upperBound; i++)
                                {
                                    array.SetValue(FunctionLib.Nz(dt.Columns[i].ColumnName, "").ToString(), num, i);
                                }

                                itemArray = null;
                                num++;
                            }
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                }
                else
                {
                    array = new string[dt.Rows.Count - 1 + 1, dt.Columns.Count - 1 + 1];
                }

                foreach (DataRow row in dt.Rows)
                {
                    object[] itemArray2 = row.ItemArray;
                    int lowerBound2 = itemArray2.GetLowerBound(0);
                    int upperBound2 = itemArray2.GetUpperBound(0);
                    for (int i = lowerBound2; i <= upperBound2; i++)
                    {
                        array.SetValue(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(itemArray2.GetValue(i)), "").ToString(), num, i);
                    }

                    itemArray2 = null;
                    num++;
                }

                MakeCSV(array);
                array = null;
            }
        }

        public void MakeCSV(DataSet ds)
        {
            int num = 0;
            IEnumerator enumerator = ds.Tables[0].Rows.GetEnumerator();
            checked
            {
                try
                {
                    if (enumerator.MoveNext())
                    {
                        DataRow dataRow = (DataRow)enumerator.Current;
                        object[] itemArray = dataRow.ItemArray;
                        int lowerBound = itemArray.GetLowerBound(0);
                        int upperBound = itemArray.GetUpperBound(0);
                        for (int i = lowerBound; i <= upperBound; i++)
                        {
                            if (Strings.InStr(FunctionLib.Nz(ds.Tables[0].Columns[i].ColumnName, "").ToString(), "HIDE_COL") == 0)
                            {
                                num++;
                            }
                        }

                        itemArray = null;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }

                int num3 = default(int);
                string[,] array;
                if (HeadAddFLG)
                {
                    array = new string[ds.Tables[0].Rows.Count + 1, num - 1 + 1];
                    {
                        IEnumerator enumerator2 = ds.Tables[0].Rows.GetEnumerator();
                        try
                        {
                            if (enumerator2.MoveNext())
                            {
                                DataRow dataRow = (DataRow)enumerator2.Current;
                                object[] itemArray2 = dataRow.ItemArray;
                                int num2 = 0;
                                int lowerBound2 = itemArray2.GetLowerBound(0);
                                int upperBound2 = itemArray2.GetUpperBound(0);
                                for (int i = lowerBound2; i <= upperBound2; i++)
                                {
                                    if (Strings.InStr(FunctionLib.Nz(ds.Tables[0].Columns[i].ColumnName, "").ToString(), "HIDE_COL") == 0)
                                    {
                                        if (ds.Tables.Count == 1)
                                        {
                                            array.SetValue(FunctionLib.Nz(ds.Tables[0].Columns[i].ColumnName, "").ToString(), num3, num2);
                                        }
                                        else
                                        {
                                            array.SetValue(GetComment(ds.Tables[1], FunctionLib.Nz(ds.Tables[0].Columns[i].ColumnName, "").ToString()), num3, num2);
                                        }

                                        num2++;
                                    }
                                }

                                itemArray2 = null;
                                num3++;
                            }
                        }
                        finally
                        {
                            IDisposable disposable2 = enumerator2 as IDisposable;
                            if (disposable2 != null)
                            {
                                disposable2.Dispose();
                            }
                        }
                    }
                }
                else
                {
                    array = new string[ds.Tables[0].Rows.Count - 1 + 1, num - 1 + 1];
                }

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    object[] itemArray3 = row.ItemArray;
                    int num2 = 0;
                    int lowerBound3 = itemArray3.GetLowerBound(0);
                    int upperBound3 = itemArray3.GetUpperBound(0);
                    for (int i = lowerBound3; i <= upperBound3; i++)
                    {
                        if (Strings.InStr(FunctionLib.Nz(ds.Tables[0].Columns[i].ColumnName, "").ToString(), "HIDE_COL") == 0)
                        {
                            array.SetValue(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(itemArray3.GetValue(i)), "").ToString(), num3, num2);
                            num2++;
                        }
                    }

                    itemArray3 = null;
                    num3++;
                }

                MakeCSV(array);
                array = null;
            }
        }

        public void MakeCSV(string[] AL)
        {
            checked
            {
                string[,] array = new string[1, AL.GetUpperBound(0) + 1];
                int upperBound = AL.GetUpperBound(0);
                for (int i = 0; i <= upperBound; i++)
                {
                    array.SetValue(RuntimeHelpers.GetObjectValue(AL.GetValue(i)), 0, i);
                }

                MakeCSV(array);
            }
        }

        public void MakeCSV(string[,] AL)
        {
            try
            {
                int num = OutputCHKFLG();
                if (num == 3)
                {
                    return;
                }

                if (num == 0 || num == 1)
                {
                    checked
                    {
                        using StreamWriter streamWriter = new StreamWriter(SVOutputPath + "\\" + SVOutputFileNM, !OverWriteFLG, Encoding.GetEncoding("Shift_JIS"));
                        string[,] array = AL;
                        int lowerBound = AL.GetLowerBound(0);
                        int upperBound = AL.GetUpperBound(0);
                        for (int i = lowerBound; i <= upperBound; i++)
                        {
                            string text = "";
                            int lowerBound2 = AL.GetLowerBound(1);
                            int upperBound2 = AL.GetUpperBound(1);
                            for (int j = lowerBound2; j <= upperBound2; j++)
                            {
                                string text2 = Conversions.ToString(array.GetValue(i, j));
                                text = ((!QuotAddFLG) ? (text + text2 + ",") : (text + "\"" + text2 + "\","));
                            }

                            text = Strings.Left(text, Strings.Len(text) - 1);
                            streamWriter.WriteLine(text);
                        }

                        array = null;
                    }
                }

                if (!(num == 0 || num == 2))
                {
                    return;
                }

                checked
                {
                    using StreamWriter streamWriter2 = new StreamWriter(CLOutputPath + "\\" + CLOutputFileNM, !OverWriteFLG, Encoding.GetEncoding("Shift_JIS"));
                    string[,] array2 = AL;
                    int lowerBound3 = AL.GetLowerBound(0);
                    int upperBound3 = AL.GetUpperBound(0);
                    for (int i = lowerBound3; i <= upperBound3; i++)
                    {
                        string text = "";
                        int lowerBound4 = AL.GetLowerBound(1);
                        int upperBound4 = AL.GetUpperBound(1);
                        for (int j = lowerBound4; j <= upperBound4; j++)
                        {
                            string text2 = Conversions.ToString(array2.GetValue(i, j));
                            text = ((!QuotAddFLG) ? (text + text2 + ",") : (text + "\"" + text2 + "\","));
                        }

                        text = Strings.Left(text, Strings.Len(text) - 1);
                        streamWriter2.WriteLine(text);
                    }

                    array2 = null;
                }
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                ProjectData.ClearProjectError();
            }
        }

        private int OutputCHKFLG()
        {
            int num = 0;
            if (!Directory.Exists(SVOutputPath) | (Operators.CompareString(SVOutputPath, "", TextCompare: false) == 0))
            {
                num = 3;
            }

            if (!Directory.Exists(CLOutputPath) | (Operators.CompareString(CLOutputPath, "", TextCompare: false) == 0))
            {
                if (num == 0)
                {
                    num = 1;
                }
            }
            else if (num == 3)
            {
                num = 2;
            }

            return num;
        }

        private string GetComment(DataTable commentDT, string ColumnName)
        {
            string result = ColumnName;
            foreach (DataRow row in commentDT.Rows)
            {
                if (Operators.CompareString(row[0].ToString(), ColumnName, TextCompare: false) == 0)
                {
                    result = row[1].ToString();
                    break;
                }
            }

            return result;
        }
    }
}
