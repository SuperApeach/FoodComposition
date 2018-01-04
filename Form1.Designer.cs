namespace Food
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.weightBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectButton = new System.Windows.Forms.Button();
            this.outExcelButton = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.deleteButton = new System.Windows.Forms.Button();
            this.exportNameBox = new System.Windows.Forms.TextBox();
            this.addDataButton = new System.Windows.Forms.Button();
            this.modifyBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.modifyButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.measureBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(976, 363);
            this.dataGridView1.TabIndex = 0;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("굴림", 14F);
            this.searchButton.Location = new System.Drawing.Point(686, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(101, 44);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "검색";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(198, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "식품명";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(307, 22);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(100, 25);
            this.nameBox.TabIndex = 3;
            this.nameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 15F);
            this.label2.Location = new System.Drawing.Point(437, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "중량(g)";
            // 
            // weightBox
            // 
            this.weightBox.Location = new System.Drawing.Point(546, 21);
            this.weightBox.Name = "weightBox";
            this.weightBox.Size = new System.Drawing.Size(100, 25);
            this.weightBox.TabIndex = 5;
            this.weightBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            this.weightBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.weightBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 13F);
            this.label3.Location = new System.Drawing.Point(502, 453);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "↓";
            // 
            // selectButton
            // 
            this.selectButton.Font = new System.Drawing.Font("굴림", 15F);
            this.selectButton.Location = new System.Drawing.Point(535, 443);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(100, 34);
            this.selectButton.TabIndex = 7;
            this.selectButton.Text = "선택";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // outExcelButton
            // 
            this.outExcelButton.Font = new System.Drawing.Font("굴림", 15F);
            this.outExcelButton.Location = new System.Drawing.Point(894, 446);
            this.outExcelButton.Name = "outExcelButton";
            this.outExcelButton.Size = new System.Drawing.Size(94, 40);
            this.outExcelButton.TabIndex = 8;
            this.outExcelButton.Text = "출력";
            this.outExcelButton.UseVisualStyleBackColor = true;
            this.outExcelButton.Click += new System.EventHandler(this.outExcelButton_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 492);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(976, 312);
            this.dataGridView2.TabIndex = 9;
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("굴림", 15F);
            this.deleteButton.Location = new System.Drawing.Point(641, 443);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(98, 34);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "삭제";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // exportNameBox
            // 
            this.exportNameBox.Location = new System.Drawing.Point(788, 453);
            this.exportNameBox.Name = "exportNameBox";
            this.exportNameBox.Size = new System.Drawing.Size(100, 25);
            this.exportNameBox.TabIndex = 11;
            this.exportNameBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown3);
            // 
            // addDataButton
            // 
            this.addDataButton.AutoSize = true;
            this.addDataButton.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.addDataButton.Location = new System.Drawing.Point(12, 446);
            this.addDataButton.Name = "addDataButton";
            this.addDataButton.Size = new System.Drawing.Size(143, 32);
            this.addDataButton.TabIndex = 12;
            this.addDataButton.Text = "데이터 추가";
            this.addDataButton.UseVisualStyleBackColor = true;
            this.addDataButton.Click += new System.EventHandler(this.addDataButton_Click);
            // 
            // modifyBox
            // 
            this.modifyBox.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modifyBox.Location = new System.Drawing.Point(171, 816);
            this.modifyBox.Name = "modifyBox";
            this.modifyBox.Size = new System.Drawing.Size(67, 27);
            this.modifyBox.TabIndex = 13;
            this.modifyBox.Text = "100";
            this.modifyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.modifyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown2);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(12, 819);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "1인분 용량(g) : ";
            // 
            // modifyButton
            // 
            this.modifyButton.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.modifyButton.Location = new System.Drawing.Point(535, 812);
            this.modifyButton.Name = "modifyButton";
            this.modifyButton.Size = new System.Drawing.Size(92, 32);
            this.modifyButton.TabIndex = 15;
            this.modifyButton.Text = "변환";
            this.modifyButton.UseVisualStyleBackColor = true;
            this.modifyButton.Click += new System.EventHandler(this.modifyButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(266, 819);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "1단위당 용량(개) :";
            // 
            // measureBox
            // 
            this.measureBox.Font = new System.Drawing.Font("굴림", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.measureBox.Location = new System.Drawing.Point(447, 816);
            this.measureBox.Name = "measureBox";
            this.measureBox.Size = new System.Drawing.Size(64, 27);
            this.measureBox.TabIndex = 17;
            this.measureBox.Text = "1";
            this.measureBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.measureBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 920);
            this.Controls.Add(this.measureBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.modifyButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.modifyBox);
            this.Controls.Add(this.addDataButton);
            this.Controls.Add(this.exportNameBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.outExcelButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.weightBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "성분분석";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox weightBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button outExcelButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox exportNameBox;
        private System.Windows.Forms.Button addDataButton;
        private System.Windows.Forms.TextBox modifyBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button modifyButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox measureBox;
    }
}

