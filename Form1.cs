using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Food
{
    public partial class Form1 : Form
    {
        ExcelIO excel = new ExcelIO();
        FoodDictionary fd = new FoodDictionary();
        DataTable selectedTable = new DataTable();
        

        public string[] columnname = new string[] {"식품명","용량", "에너지", "수분",
            "단백질", "지질", "회분","탄수화물","총 식이섬유","수용성 식이섬유","불용성 식이섬유",
            "칼슘","인","철","칼륨","나트륨","비타민A","retinol","β-carotene","비타민B1",
            "비타민B2","나이아신","비타민C"};

        /*"식품명","용량\n(g)", "에너지\n(kcal)", "수분\n(g)",
            "단백질\n(g)", "지질\n(g)", "회분\n(g)","탄수화물\n(g)","총 식이섬유\n(g)","수용성 식이섬유\n(g)","불용성 식이섬유\n(g)",
            "칼슘\n(mg)","인\n(mg)","철\n(mg)","칼륨\n(mg)","나트륨\n(mg)","비타민A\n(RE)","retinol\n(μg)","β-carotene\n(μg)","비타민B1\n(mg)",
            "비타민B2\n(mg)","나이아신\n(mg)","비타민C\n(mg)"
            */

        string[] sumSelectedTable;
        string[] mod100SumSelectedTable;
        string[] modSumSelectedTable;
        string[] modNumSum;

        public Form1()
        {
            InitializeComponent();

            selectedTable.Columns.Add(new DataColumn(columnname[0], typeof(string))); // 이 부분 form 초기화에 넣으면 어떻게? 이따가

            foreach (string item in columnname.Skip(1))
            {
                selectedTable.Columns.Add(new DataColumn(item, typeof(double)));
            }
        }

        private void weightBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 46
                                     && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchButton_Click(this, new EventArgs());
            }
        }

        private void Enter_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                modifyButton_Click(this, new EventArgs());
            }
        }

        private void Enter_KeyDown3(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                outExcelButton_Click(this, new EventArgs());
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {

            if (nameBox.Text.Equals("") || weightBox.Text.Equals(""))
            {
                MessageBox.Show("식품명과 중량을 입력하세요.");
            }
            else
            {
                List<string[]> foodlist = fd.search(nameBox.Text, Convert.ToDouble(weightBox.Text));

                DataTable table = new DataTable();



                table.Columns.Add(new DataColumn(columnname[0], typeof(string))); // 칼럼 첫번째칸(이름) 설정

                foreach (string item in columnname.Skip(1)) // 칼럼 나머지부분 모두 설정
                {
                    table.Columns.Add(new DataColumn(item, typeof(double)));
                }


                foreach (string[] line in foodlist) // 데이터 한줄씩 반복해 입력
                {
                    table.Rows.Add(line);
                }

                dataGridView1.DataSource = table;
            }
        }

        private string[] selectedRowsButton_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
                dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

            string[] selectedRow = null; //= new string[dataGridView1.ColumnCount]; // 정말 갯수가 맞나? 확인필요

            if(selectedRowCount > 0)
            {
                selectedRow = new string[dataGridView1.ColumnCount];

                for(int i=0; i<selectedRowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        selectedRow[j] = dataGridView1.SelectedRows[i].Cells[j].Value.ToString();
                    }
                }
            }
            return selectedRow;
        }

        private List<string[]> selectedRowsButton2_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
                dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);

            List<string[]> selectedRows = null; //= new string[dataGridView1.ColumnCount]; // 정말 갯수가 맞나? 확인필요

            if (selectedRowCount > 0)
            {
                selectedRows = new List<string[]>();
                //selectedRow = new string[dataGridView1.ColumnCount];

                for (int i = 0; i < selectedRowCount; i++)
                {
                    string[] row = new string[dataGridView2.ColumnCount];
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        row[j] = dataGridView2.SelectedRows[i].Cells[j].Value.ToString();
                    }

                    selectedRows.Add(row);
                }
            }
            return selectedRows;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            string[] selectedList;
            //DataTable viewTable;
            

            if ((selectedList = selectedRowsButton_Click(this, new EventArgs())) != null)
            {
                selectedTable.Rows.Add(selectedList);
                SumColumns();
            }

            ViewTableForm(selectedTable.Copy());
            /*
            viewTable = selectedTable.Copy();
            viewTable.Rows.Add(new string[columnname.Length]);
            viewTable.Rows.Add(sumSelectedTable);
            viewTable.Rows.Add(mod100SumSelectedTable);
            viewTable.Rows.Add(modSumSelectedTable);




            dataGridView2.DataSource = viewTable;
            */
    }

    private void deleteButton_Click(object sender, EventArgs e) //한줄(여러줄) 삭제 기능
        {
            List<string[]> deleteList = selectedRowsButton2_Click(this, new EventArgs());
            

            //DataTable viewTable;

            if (deleteList != null)
            {
                int index = 0;

                DataTable temp = selectedTable.Copy();

                foreach (DataRow DR in temp.Rows)
                {
                    index = temp.Rows.IndexOf(DR);

                    for (int i = 0; i < deleteList.Count; i++)
                    {
                        if (DR["식품명"].ToString() == deleteList[i][0])
                        {
                            selectedTable.Rows.RemoveAt(index);
                        }
                    }
                }

                selectedTable.AcceptChanges();
                SumColumns();
            }

            ViewTableForm(selectedTable.Copy());
            
            /*
            viewTable = selectedTable.Copy();
            viewTable.Rows.Add(new string[columnname.Length]);
            viewTable.Rows.Add(sumSelectedTable);
            viewTable.Rows.Add(mod100SumSelectedTable);
            viewTable.Rows.Add(modSumSelectedTable);

            


            dataGridView2.DataSource = viewTable;
            */
        }
        /*
        private void AddColumns(string[] target) // [미사용 함수] 같은 행을 다시 더해주는 반복 작업 없이
        {                                       // 더해진 줄만 기존에다가 더해주는 함수. 근데 뺄셈 함수를 따로 구현해야함.(지저분)
            if (sumSelectedTable != null)
            {
                double sum = 0;
                for (int i = 1; i < target.Length; i++)
                {
                    sum = Convert.ToDouble(sumSelectedTable[i])
                        + Convert.ToDouble(target[i]);

                    sumSelectedTable[i] = sum.ToString();
                }
            }
            else
            {
                sumSelectedTable = new string[columnname.Length];
                sumSelectedTable[0] = "합계: ";
                for (int i = 1; i < target.Length; i++)
                {
                    sumSelectedTable[i] = string.Copy(target[i]);
                }
            }
        }
        */
        public void SumColumns()
        {
            DataTable targetTable = selectedTable.Copy();
            string[] sumCols = new string[columnname.Length];

            double[] sum = Enumerable.Repeat<double>(0, sumCols.Length - 1).ToArray<double>();//모두 0으로 초기화 하는 코드

            sumCols[0] = "합계: ";

            if (targetTable.Rows != null)
            {
                for (int i = 0; i < targetTable.Rows.Count; i++)
                {
                    for (int j = 1; j < sumCols.Length; j++)
                    {
                        sum[j - 1] += Convert.ToDouble(targetTable.Rows[i][j]);
                    }
                }
            }
            

            for (int i = 1; i < sumCols.Length; i++)
            {
                sumCols[i] = sum[i - 1].ToString();
            }

            sumSelectedTable = sumCols;
            ModifySumColumns();
        }

        public void ModifySumColumns()
        {
            //DataTable targetTable = selectedTable.Copy();
            
            string[] modify = new string[columnname.Length];
            string[] modify100 = new string[columnname.Length];
            string[] modifyNum = new string[columnname.Length];

            double[] sum = new double[modify.Length - 1];
            double[] sum100 = new double[modify.Length - 1];
            double[] sumNum = new double[modify.Length - 1];

            modify[0] = "1인분 용량 : ";
            modify100[0] = "100g당 용량 : ";
            modifyNum[0] = "1단위(1개) 용량 : ";

            for (int i = 1; i < modify.Length; i++)
            {
                double per = Convert.ToDouble(modifyBox.Text) / Convert.ToDouble(sumSelectedTable[1]);
                double per100 = 100.0 / Convert.ToDouble(sumSelectedTable[1]);
                
                sum[i - 1] = per * Convert.ToDouble(sumSelectedTable[i]);
                sum100[i - 1] = per100 * Convert.ToDouble(sumSelectedTable[i]);
                sumNum[i - 1] = Convert.ToDouble(sumSelectedTable[i]) / Convert.ToDouble(measureBox.Text);
            }

            for (int i = 1; i < modify.Length; i++)
            {
                modify[i] = sum[i - 1].ToString();
                modify100[i] = sum100[i - 1].ToString();
                modifyNum[i] = sumNum[i - 1].ToString();
            }

            modSumSelectedTable = modify;
            mod100SumSelectedTable = modify100;
            modNumSum = modifyNum;
        }

        

        private void outExcelButton_Click(object sender, EventArgs e)
        {


            DataTable outputTable = new DataTable();

            outputTable.Columns.Add(new DataColumn(columnname[0], typeof(string))); // 이 부분 form 초기화에 넣으면 어떻게? 이따가

            foreach (string item in columnname.Skip(1))
            {
                outputTable.Columns.Add(new DataColumn(item, typeof(string)));
            }

            string[] measure = { "단위", "g", "kcal", "g", "g", "g", "g", "g", "g", "g", "g",
                "mg", "mg", "mg", "mg", "mg", "RE", "μg", "μg", "mg", "mg", "mg", "mg" };

            outputTable.Rows.Add(measure);
            for (int i = 0; i < selectedTable.Rows.Count; i++)
            {
                string[] inputline  = new string[columnname.Length];
                for (int j = 0; j < columnname.Length; j++)
                {
                    inputline[j] = selectedTable.Rows[i][j].ToString();
                }
                outputTable.Rows.Add(inputline);
            }
            outputTable.Rows.Add(new string[columnname.Length]);
            outputTable.Rows.Add(sumSelectedTable);
            outputTable.Rows.Add(mod100SumSelectedTable);
            outputTable.Rows.Add(modSumSelectedTable);
            outputTable.Rows.Add(modNumSum);

            DataTable viewTable = selectedTable.Copy();
            viewTable.Rows.Add(new string[columnname.Length]);
            viewTable.Rows.Add(sumSelectedTable);
            viewTable.Rows.Add(mod100SumSelectedTable);
            viewTable.Rows.Add(modSumSelectedTable);
            viewTable.Rows.Add(modNumSum);
            
            excel.WriteExcel(exportNameBox.Text, outputTable); 
            
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            AddDataForm form2 = new AddDataForm(selectedTable, this); //dataGridView2도 넘긴다면?
            form2.Show();

            //dataGridView2.DataSource = selectedTable;

            /*
            if (form2.CheckConfirm())
            {
                List<string[]> addList = form2.GetData();

                for (int i = 0; i < addList.Count; i++)
                {
                    selectedTable.Rows.Add(addList[i]);
                }
                selectedTable.AcceptChanges();
            }
            else
            {
            
            }
            */

            // 추가가 안됨. adddataform에서 추가해줘야 할듯 
            // 아님. addDataForm에서는 자기를 불러온 객체를 찾기 힘듦.
            // 여기서 데이터 추가 작업을 해줘야함.
            // sumColumn 함수를 그냥 사용하는게 편할듯.


        }// 이 함수가 모두 끝나야 addForm이 화면에 표시가 됨.(데이터갱신이 안됨)
        
        private void modifyButton_Click(object sender, EventArgs e)
        {

            ModifySumColumns();
            ViewTableForm(selectedTable.Copy());

            /*
            DataTable viewTable;
            viewTable = selectedTable.Copy();

            ModifySumColumns();

            viewTable.Rows.Add(new string[columnname.Length]);
            viewTable.Rows.Add(sumSelectedTable);
            viewTable.Rows.Add(mod100SumSelectedTable);
            viewTable.Rows.Add(modSumSelectedTable);




            dataGridView2.DataSource = viewTable;*/

        }

        public void ViewTableForm(DataTable inTable)
        {
            DataTable viewTable;
            viewTable = inTable;

            viewTable.Rows.Add(new string[columnname.Length]); // 이 결과 4줄을 하나의 배열 안에 집어넣기.
            viewTable.Rows.Add(sumSelectedTable);
            viewTable.Rows.Add(mod100SumSelectedTable);
            viewTable.Rows.Add(modSumSelectedTable);
            viewTable.Rows.Add(modNumSum);

            dataGridView2.DataSource = viewTable;
        }
    }
}
