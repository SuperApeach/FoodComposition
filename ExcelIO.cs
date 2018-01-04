using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace Food
{
    class ExcelIO
    {
        Excel.Application excelApp = null;
        Excel.Workbook wb = null;
        Excel.Worksheet ws = null;

        public Dictionary<string, string[]> ReadExcel()
        {
            Dictionary<string, string[]> foodDic = new Dictionary<string, string[]>();

            try
            {
                //string  = System.IO.Path.Ge;
                string path = System.Windows.Forms.Application.StartupPath + @"\food.xlsx";


                excelApp = new Excel.Application();
                //wb = excelApp.Workbooks.Open(@"C:\food.xlsx");
                wb = excelApp.Workbooks.Open(path);
                ws = wb.Worksheets.get_Item(1) as Excel.Worksheet;

                

                Excel.Range rng = ws.Range[ws.Cells[6, 2], ws.Cells[5517, 23]];// [줄,칸] = [세로(숫자),가로(알파벳)]

                object[,] data = rng.Value;

                for (int r = 1; r <= data.GetLength(0); r+=2)
                {
                    string[] dicValues = new string[data.GetLength(1)-1];// - 1 을 해줘야? ㅇㅇ
                    for (int c = 2; c <= data.GetLength(1); c++)
                    {
                        if(data[r,c] != null)
                        {
                            if (data[r, c].ToString().Equals("-") || data[r, c].ToString().Equals("tr"))
                            {
                                dicValues[c - 2] = "0";
                            }
                            else if (data[r, c].ToString().Contains("-"))
                            {
                                dicValues[c - 2] = data[r, c].ToString().Replace("-", "");
                            }
                            else
                            {
                                dicValues[c - 2] = data[r, c].ToString();
                            }
                        }
                        else 
                        {
                            dicValues[c - 2] = "0";
                        }
                        
                    }
                    foodDic[data[r, 1].ToString()] = dicValues;
                }
                wb.Close(true);
                excelApp.Quit();

                
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }

            return foodDic;
        }

        public void WriteExcel(string fileName, DataTable exportTable)
        {
            Excel.Application outExcel = new Excel.Application();
            Excel.Workbook outWB = outExcel.Workbooks.Add();
            Excel.Worksheet outWS = outWB.Worksheets.get_Item(1) as Excel.Worksheet;
            int r = 2;

            for (int i = 0; i < exportTable.Columns.Count; i++)
            {
                outWS.Cells[1, i + 1] = exportTable.Columns[i].ToString();
            }

            foreach (DataRow row in exportTable.Rows)
            {
                
                for (int i = 0; i < exportTable.Columns.Count; i++)//?
                {
                    outWS.Cells[r, i + 1] = row[i].ToString();
                }
                r++;
            }

            /*
            int r = 1;
            List<string> testData = new List<string>() { "Excel", "Access", "Word" };

            

            foreach (var d in testData)
            {
                outWS.Cells[r, 1] = d;
                r++;
            }*/
            string name = "\\"+ fileName + ".xls";
            string path = System.Windows.Forms.Application.StartupPath;
            outWB.SaveAs(path + @name, Excel.XlFileFormat.xlWorkbookNormal);
            outWB.Close(true);
            outExcel.Quit();

            MessageBox.Show("엑셀 출력 완료");
        }
    }
}
