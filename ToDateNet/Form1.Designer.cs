namespace ToDateNet
{
    partial class FrmToDateNet
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            GrapeCity.Win.Editors.Fields.DateHourField dateHourField1 = new GrapeCity.Win.Editors.Fields.DateHourField();
            GrapeCity.Win.Editors.Fields.DateLiteralField dateLiteralField1 = new GrapeCity.Win.Editors.Fields.DateLiteralField();
            GrapeCity.Win.Editors.Fields.DateMinuteField dateMinuteField1 = new GrapeCity.Win.Editors.Fields.DateMinuteField();
            GrapeCity.Win.Editors.Fields.DateLiteralField dateLiteralField2 = new GrapeCity.Win.Editors.Fields.DateLiteralField();
            GrapeCity.Win.Editors.Fields.DateSecondField dateSecondField1 = new GrapeCity.Win.Editors.Fields.DateSecondField();
            GrapeCity.Win.Editors.Fields.DateYearField dateYearField1 = new GrapeCity.Win.Editors.Fields.DateYearField();
            GrapeCity.Win.Editors.Fields.DateLiteralField dateLiteralField3 = new GrapeCity.Win.Editors.Fields.DateLiteralField();
            GrapeCity.Win.Editors.Fields.DateMonthField dateMonthField1 = new GrapeCity.Win.Editors.Fields.DateMonthField();
            GrapeCity.Win.Editors.Fields.DateLiteralField dateLiteralField4 = new GrapeCity.Win.Editors.Fields.DateLiteralField();
            GrapeCity.Win.Editors.Fields.DateDayField dateDayField1 = new GrapeCity.Win.Editors.Fields.DateDayField();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToDateNet));
            this.label1 = new System.Windows.Forms.Label();
            this.chk時間復元 = new System.Windows.Forms.CheckBox();
            this.btn実行 = new System.Windows.Forms.Button();
            this.btn参照 = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnGET = new System.Windows.Forms.Button();
            this.btn設定 = new System.Windows.Forms.Button();
            this.gcTime1 = new GrapeCity.Win.Editors.GcTime(this.components);
            this.gcDate1 = new GrapeCity.Win.Editors.GcDate(this.components);
            this.dropDownButton1 = new GrapeCity.Win.Editors.DropDownButton();
            this.gcShortcut1 = new GrapeCity.Win.Editors.GcShortcut(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtParam = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcTime1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDate1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "変更する日付";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk時間復元
            // 
            this.chk時間復元.Location = new System.Drawing.Point(14, 84);
            this.chk時間復元.Name = "chk時間復元";
            this.chk時間復元.Size = new System.Drawing.Size(392, 25);
            this.chk時間復元.TabIndex = 8;
            this.chk時間復元.Text = "プログラム開始時時刻を上記日付に変更してdebugする。終了時時間を戻す";
            this.toolTip1.SetToolTip(this.chk時間復元, "実行する前に日付を変更日付にしてからプログラムを開始します。");
            this.chk時間復元.UseVisualStyleBackColor = true;
            this.chk時間復元.CheckedChanged += new System.EventHandler(this.chk時間復元_CheckedChanged);
            // 
            // btn実行
            // 
            this.btn実行.Location = new System.Drawing.Point(412, 62);
            this.btn実行.Name = "btn実行";
            this.btn実行.Size = new System.Drawing.Size(100, 39);
            this.btn実行.TabIndex = 7;
            this.btn実行.Text = "実行(&X)";
            this.toolTip1.SetToolTip(this.btn実行, "プログラムを実行します。");
            this.btn実行.UseVisualStyleBackColor = true;
            this.btn実行.Click += new System.EventHandler(this.btn実行_Click);
            // 
            // btn参照
            // 
            this.btn参照.Location = new System.Drawing.Point(412, 33);
            this.btn参照.Name = "btn参照";
            this.btn参照.Size = new System.Drawing.Size(100, 24);
            this.btn参照.TabIndex = 6;
            this.btn参照.Text = "参照...";
            this.toolTip1.SetToolTip(this.btn参照, "プログラムの参照を行います");
            this.btn参照.UseVisualStyleBackColor = true;
            this.btn参照.Click += new System.EventHandler(this.btn参照_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(64, 32);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(342, 19);
            this.txtFile.TabIndex = 5;
            // 
            // btnGET
            // 
            this.btnGET.Location = new System.Drawing.Point(412, 3);
            this.btnGET.Name = "btnGET";
            this.btnGET.Size = new System.Drawing.Size(100, 25);
            this.btnGET.TabIndex = 4;
            this.btnGET.Text = "現在時間取得";
            this.toolTip1.SetToolTip(this.btnGET, "インターネットより現在時刻を取得します");
            this.btnGET.UseVisualStyleBackColor = true;
            this.btnGET.Click += new System.EventHandler(this.btnGET_Click);
            // 
            // btn設定
            // 
            this.btn設定.Location = new System.Drawing.Point(333, 3);
            this.btn設定.Name = "btn設定";
            this.btn設定.Size = new System.Drawing.Size(75, 25);
            this.btn設定.TabIndex = 3;
            this.btn設定.Text = "日付設定";
            this.toolTip1.SetToolTip(this.btn設定, "現在日を「」変更する日付」に強制変更します。");
            this.btn設定.UseVisualStyleBackColor = true;
            this.btn設定.Click += new System.EventHandler(this.btn設定_Click);
            // 
            // gcTime1
            // 
            dateLiteralField1.Text = ":";
            dateLiteralField2.Text = ":";
            this.gcTime1.Fields.AddRange(new GrapeCity.Win.Editors.Fields.DateField[] {
            dateHourField1,
            dateLiteralField1,
            dateMinuteField1,
            dateLiteralField2,
            dateSecondField1});
            this.gcTime1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gcTime1.Location = new System.Drawing.Point(222, 3);
            this.gcTime1.Name = "gcTime1";
            this.gcShortcut1.SetShortcuts(this.gcTime1, new GrapeCity.Win.Editors.ShortcutCollection(new System.Windows.Forms.Keys[] {
                System.Windows.Forms.Keys.F2,
                System.Windows.Forms.Keys.F5,
                ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return)))}, new object[] {
                ((object)(this.gcTime1)),
                ((object)(this.gcTime1)),
                ((object)(this.gcTime1))}, new string[] {
                "ShortcutClear",
                "SetNow",
                "ApplyRecommendedValue"}));
            this.gcTime1.Size = new System.Drawing.Size(89, 25);
            this.gcTime1.TabIndex = 2;
            // 
            // gcDate1
            // 
            dateLiteralField3.Text = "/";
            dateLiteralField4.Text = "/";
            this.gcDate1.Fields.AddRange(new GrapeCity.Win.Editors.Fields.DateField[] {
            dateYearField1,
            dateLiteralField3,
            dateMonthField1,
            dateLiteralField4,
            dateDayField1});
            this.gcDate1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gcDate1.Location = new System.Drawing.Point(120, 3);
            this.gcDate1.Name = "gcDate1";
            this.gcShortcut1.SetShortcuts(this.gcDate1, new GrapeCity.Win.Editors.ShortcutCollection(new System.Windows.Forms.Keys[] {
                System.Windows.Forms.Keys.F2,
                System.Windows.Forms.Keys.F5,
                ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Return)))}, new object[] {
                ((object)(this.gcDate1)),
                ((object)(this.gcDate1)),
                ((object)(this.gcDate1))}, new string[] {
                "ShortcutClear",
                "SetNow",
                "ApplyRecommendedValue"}));
            this.gcDate1.SideButtons.AddRange(new GrapeCity.Win.Editors.SideButtonBase[] {
            this.dropDownButton1});
            this.gcDate1.Size = new System.Drawing.Size(98, 25);
            this.gcDate1.TabIndex = 1;
            this.gcDate1.Value = new System.DateTime(2016, 6, 9, 0, 0, 0, 0);
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.Name = "dropDownButton1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtParam
            // 
            this.txtParam.Location = new System.Drawing.Point(64, 59);
            this.txtParam.Name = "txtParam";
            this.txtParam.Size = new System.Drawing.Size(341, 19);
            this.txtParam.TabIndex = 10;
            this.toolTip1.SetToolTip(this.txtParam, "プログラムのパラメータを指定してください。");
            this.txtParam.Validating += new System.ComponentModel.CancelEventHandler(this.txtParam_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "パラメータ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "プログラム";
            // 
            // FrmToDateNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 113);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtParam);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btn実行);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn参照);
            this.Controls.Add(this.chk時間復元);
            this.Controls.Add(this.btnGET);
            this.Controls.Add(this.btn設定);
            this.Controls.Add(this.gcTime1);
            this.Controls.Add(this.gcDate1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmToDateNet";
            this.Opacity = 0.8D;
            this.Text = "時刻変更サポートツール";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmToDateNet_FormClosing);
            this.Load += new System.EventHandler(this.FrmToDateNet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTime1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDate1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn実行;
        private System.Windows.Forms.Button btn参照;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnGET;
        private System.Windows.Forms.Button btn設定;
        private GrapeCity.Win.Editors.GcTime gcTime1;
        private GrapeCity.Win.Editors.GcShortcut gcShortcut1;
        private GrapeCity.Win.Editors.GcDate gcDate1;
        private GrapeCity.Win.Editors.DropDownButton dropDownButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox chk時間復元;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip1;

    }
}

