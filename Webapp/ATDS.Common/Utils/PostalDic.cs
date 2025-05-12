using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;


namespace ATDS.Common
{
    public class PostalDic
    {
        private enum LC_COL : byte
        {
            JIS_Code,
            OldPostal,
            Postal,
            Pref_Kana,
            City_Kana,
            Town_Kana,
            Pref,
            City,
            Town,
            Town_Multi_Flg,
            Town_Aza_Flg,
            Town_Cho_Flg,
            Postal_Multi_Flg,
            Upd_Code,
            Upd_Type,
            Jigyosho_Name,
            Max
        }

        private enum LC_COL_JIGYOSHO : byte
        {
            JIS_Code,
            Kana,
            Name,
            Pref,
            City,
            Town,
            House,
            Postal,
            OldPostal,
            Shiten_Name,
            Postal_Type,
            Multi_Flg,
            Upd_Code
        }

        private static DataView _dic;

        private static string _csvfile;

        private OleDbConnection oConn;

        private OleDbCommand oCommand;

        private DataSet oDataSet;

        private OleDbDataAdapter oDataAdapter;

        public static string CsvFile
        {
            get
            {
                return _csvfile;
            }
            set
            {
                _csvfile = value;
                LoadPostalCSV(Path.GetDirectoryName(_csvfile) + "\\", Path.GetFileName(_csvfile), "jigyosyo.csv");
            }
        }

        public PostalDic()
        {
            oConn = new OleDbConnection();
            oCommand = new OleDbCommand();
            oDataSet = new DataSet();
            oDataAdapter = new OleDbDataAdapter();
        }

        static PostalDic()
        {
            _csvfile = AppDomain.CurrentDomain.BaseDirectory.ToString() + "ken_all.csv";
            _dic = new DataView();
        }

        public static void LoadPostalCSV(string vPath, string vCSVFile, string vCSVFile_Jigyosho)
        {
            OleDbConnection oleDbConnection = new OleDbConnection();
            OleDbCommand oleDbCommand = new OleDbCommand();
            DataSet dataSet = new DataSet();
            DataSet dataSet2 = new DataSet();
            OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter();
            string text = "";
            object[] array = new object[16];
            try
            {
                if (!File.Exists(vPath + vCSVFile) && !File.Exists(vPath + vCSVFile_Jigyosho))
                {
                    return;
                }

                oleDbConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=" + vPath + "\\;Extended Properties=\"Text;HDR=No;FMT=Delimited\"";
                oleDbCommand.Connection = oleDbConnection;
                if (File.Exists(vPath + vCSVFile))
                {
                    oleDbCommand.CommandText = "SELECT * FROM " + vCSVFile;
                    oleDbDataAdapter.SelectCommand = oleDbCommand;
                    oleDbDataAdapter.Fill(dataSet);
                    DataTableCollection tables = dataSet.Tables;
                    if (tables.Count > 0)
                    {
                        tables[0].Columns.Add();
                        tables[0].Columns[15].DataType = typeof(string);
                    }

                    tables = null;
                }

                if (File.Exists(vPath + vCSVFile_Jigyosho))
                {
                    if (dataSet.Tables.Count == 0)
                    {
                        dataSet.Tables.Add();
                        int num = 0;
                        do
                        {
                            dataSet.Tables[0].Columns.Add(GetColName(num));
                            num = checked(num + 1);
                        }
                        while (num <= 15);
                    }

                    oleDbCommand.CommandText = "SELECT * FROM " + vCSVFile_Jigyosho;
                    oleDbDataAdapter.SelectCommand = oleDbCommand;
                    oleDbDataAdapter.Fill(dataSet2);
                    foreach (DataRow row in dataSet2.Tables[0].Rows)
                    {
                        Array.Clear(array, 0, 16);
                        array[0] = RuntimeHelpers.GetObjectValue(row[0]);
                        array[1] = RuntimeHelpers.GetObjectValue(row[8]);
                        array[2] = RuntimeHelpers.GetObjectValue(row[7]);
                        array[3] = "";
                        array[4] = "";
                        array[5] = "";
                        array[6] = RuntimeHelpers.GetObjectValue(row[3]);
                        array[7] = RuntimeHelpers.GetObjectValue(row[4]);
                        array[8] = Conversions.ToString(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(row[5]), "")) + Conversions.ToString(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(row[6]), ""));
                        array[9] = 0;
                        array[10] = 0;
                        array[11] = 0;
                        array[12] = RuntimeHelpers.GetObjectValue(row[11]);
                        array[13] = RuntimeHelpers.GetObjectValue(row[12]);
                        array[14] = 0;
                        array[15] = RuntimeHelpers.GetObjectValue(row[2]);
                        dataSet.Tables[0].Rows.Add(array);
                    }
                }

                _dic = dataSet.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
            finally
            {
                oleDbConnection.Close();
                oleDbConnection.Dispose();
                oleDbCommand.Dispose();
                dataSet.Dispose();
                oleDbDataAdapter.Dispose();
                dataSet2.Dispose();
                array = null;
            }
        }

        public static Postal SearchID(string vCode)
        {
            try
            {
                Postal[] array = Search(GetColName(2) + " = '" + vCode + "'");
                if (array.Length > 0)
                {
                    return array[0];
                }

                return new Postal();
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
            finally
            {
                Postal[] array = null;
            }
        }

        public static Postal[] SearchPostal(string vCode)
        {
            return Search(GetColName(2) + " LIKE '" + vCode + "%'");
        }

        public static Postal[] SearchAddress(string vAddress, ref string rMatchStr)
        {
            ArrayList arrayList = new ArrayList();
            int num = 1;
            string text = "";
            string colName = GetColName(6);
            string colName2 = GetColName(7);
            string colName3 = GetColName(8);
            checked
            {
                try
                {
                    rMatchStr = vAddress;
                    if ((vAddress.IndexOf("都") >= 0) | (vAddress.IndexOf("道") >= 0) | (vAddress.IndexOf("府") >= 0) | (vAddress.IndexOf("県") >= 0))
                    {
                        text = text + "'" + vAddress + "' LIKE '%' + " + colName + " + '%' OR ";
                    }

                    text = text + "'" + vAddress + "' LIKE '%' + " + colName2 + " + '%' OR '" + vAddress + "' LIKE '%' + " + colName3 + " + '%' OR  " + colName + " +  " + colName2 + " +  " + colName3 + " LIKE '%" + vAddress + "%'";
                    Postal[] array = Search(text);
                    if (array.Length > 0)
                    {
                        num = 1;
                        while (rMatchStr.Length != 0)
                        {
                            Postal[] array2 = array;
                            foreach (Postal postal in array2)
                            {
                                if (postal.GetFullAddress().IndexOf(rMatchStr) >= 0)
                                {
                                    arrayList.Add(postal);
                                }
                            }

                            if (arrayList.Count > 0)
                            {
                                break;
                            }

                            num++;
                            rMatchStr = Strings.Left(rMatchStr, rMatchStr.Length - 1);
                        }
                    }

                    return (Postal[])arrayList.ToArray(typeof(Postal));
                }
                catch (Exception ex)
                {
                    ProjectData.SetProjectError(ex);
                    Exception ex2 = ex;
                    throw;
                }
                finally
                {
                    arrayList = null;
                    Postal[] array = null;
                }
            }
        }

        public static Postal[] SearchCity(string vCity)
        {
            return Search(GetColName(7) + " + " + GetColName(8) + " LIKE '%" + vCity + "%'");
        }

        public static Postal[] SearchCityKana(string vCityKana)
        {
            return Search(GetColName(4) + " + " + GetColName(5) + " LIKE '%" + vCityKana + "%'");
        }

        private static Postal[] Search(string vRowFilter)
        {
            ArrayList arrayList = new ArrayList();
            try
            {
                _dic.RowFilter = vRowFilter;
                foreach (DataRowView item in _dic)
                {
                    arrayList.Add(new Postal(Conversions.ToString(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(item[2]), "")), Conversions.ToString(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(item[6]), "")), Conversions.ToString(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(item[7]), "")), Conversions.ToString(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(item[8]), "")), Conversions.ToString(FunctionLib.Nz(RuntimeHelpers.GetObjectValue(item[15]), ""))));
                }
                return (Postal[])arrayList.ToArray(typeof(Postal));
            }
            catch (Exception ex)
            {
                ProjectData.SetProjectError(ex);
                Exception ex2 = ex;
                throw;
            }
            finally
            {
                arrayList = null;
            }
        }

        private static string GetColName(int vCol)
        {
            return "F" + Conversions.ToString(checked(vCol + 1));
        }
    }
}
