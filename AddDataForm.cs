using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food
{
    public partial class AddDataForm : Form
    {
        int dataLineNum = 0;
        int dataLineHeight = 30;
        DataTable form1Table;
        Form1 form1;
        
        
        List<TextBox> textList = new List<TextBox>();
        

        public AddDataForm(DataTable getTable, Form1 form)
        {
            form1Table = getTable; // form1의 selectedTable을 받아옴.
            form1 = form;
            InitializeComponent();
            this.makeFoodLabel(); // 패널 속 라벨 생성
            this.addDataLine();//기본 1줄 생성
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            this.addDataLine(); // 데이터 입력 텍스트박스 생성
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            this.deleteDataLine();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            //  isConfirm = true;

           // DataTable viewTable = form1Table.Copy();

            
            
            for (int i = 0; i < textList.Count / form1.columnname.Length; i++)
            {
                string[] line = new string[form1.columnname.Length];

                for (int j = 0; j < form1.columnname.Length; j++)
                {
                    if (textList[j + i*form1.columnname.Length].Text.Equals(""))
                    {

                        line[j] = "0";
                    }
                    else
                    {
                        line[j] =  textList[j + i * form1.columnname.Length].Text;
                    }
                    //line[j] = textList[j + i * columnname.Length].Text;
                }

                form1Table.Rows.Add(line);
                form1.SumColumns();
            }

            form1.ViewTableForm(form1Table.Copy());

            /*
            viewTable = form1Table.Copy();
            viewTable.Rows.Add(new string[columnname.Length]);
            viewTable.Rows.Add(form1.sumSelectedTable);
            viewTable.Rows.Add(form1.mod100SumSelectedTable);
            viewTable.Rows.Add(form1.modSumSelectedTable);

            form1DataGridView.DataSource = viewTable;
            */

            /* 구 코드
            for (int i = 0; i < textList.Count / columnname.Length; i++)
            {
                string[] line = new string[columnname.Length];

                for (int j = 0; j < columnname.Length; j++)
                {
                    line[j] = textList[j + i * columnname.Length].Text;
                }

                form1Table.Rows.Add(line);
            }

            form1Table.AcceptChanges();
            */
            this.Close();
        }
        

        private void makeFoodLabel()
        {
           

            for (int i = 0, j = 0; i < form1.columnname.Length; i++)
            {
                System.Windows.Forms.Label dataLabel = new System.Windows.Forms.Label();
                dataLabel.AutoSize = true;
                dataLabel.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                dataLabel.Location = new System.Drawing.Point(j, 0);
                dataLabel.Name = "lab" + i;
                dataLabel.Size = new System.Drawing.Size(53, 15);
                dataLabel.TabIndex = 22;
                dataLabel.Text = form1.columnname[i];

                Graphics g = CreateGraphics();

                int widthL = (int)g.MeasureString(form1.columnname[i], new Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)))).Width;

                j = widthL + 25 + dataLabel.Location.X;


                this.dataPanel.Controls.Add(dataLabel);

            }
        }

        private void addDataLine()// 좌우 스크롤바를 움직이고 추가하면 그 위치서부터 추가되는 이상한버그가 있음 (??)
        {
            for (int i = 0, j = 0; i < form1.columnname.Length; i++)
            {
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();

                Graphics g = CreateGraphics();

                int widthL = (int)g.MeasureString(form1.columnname[i], new Font("굴림", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)))).Width;

                textBox.Location = new System.Drawing.Point(j, dataLineHeight); // 높이 수정
                textBox.Name = dataLineNum + "_" + "value" + i; // 이름 대조해서 삭제기능 (식별자)
                textBox.Size = new System.Drawing.Size(widthL + 15, 15);
                textBox.TabIndex = 3;
                

                j = widthL + 25 + textBox.Location.X;

                this.dataPanel.Controls.Add(textBox);
                textList.Add(textBox);
            }
            
                dataLineNum++;
                dataLineHeight += 30;
            
            
        }

        private void deleteDataLine()
        {
            

            int c = this.dataPanel.Controls.Count;
            Control cC =  this.dataPanel.Controls[0];

            for (int i = this.dataPanel.Controls.Count-1; i >= 0; i--) // 0~count 탐색 : 똑같은현상
            { // count ~ 0 탐색(역방향)  제대로 됨.
                if(this.dataPanel.Controls[i].Name[0] - 48 == dataLineNum - 1)
                {
                    //this.dataPanel.Controls[i].
                    textList.Remove((TextBox)this.dataPanel.Controls[i]);  // remove나 뭐든 사용해서 같이 지워줘야함
                    this.dataPanel.Controls.Remove(this.dataPanel.Controls[i]);
                }
            }
            /*

            foreach (Control item in this.dataPanel.Controls.OfType<TextBox>())// foreach는 read에 특화 delete할때는 이런 오류가 됨.
            {   // for loop로 바꿔야 됨.

                if (item.Name[0] - 48 == dataLineNum-1)  // 앞에껀 char형식으로 아스키코드 '0' = 48 / dataLineNum은 자동으로 다음번호로 넘어가니 - 1
                {
                    
                    this.dataPanel.Controls.Remove(item);
                   // item.Dispose();

                
                }
            }
            
            */
            if (dataLineNum > 0 && dataLineHeight > 30)
            {
                dataLineNum--;
                dataLineHeight -= 30;
            }
        }
    }
}
