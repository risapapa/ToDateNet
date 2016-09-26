using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;
using System.Runtime.CompilerServices;

namespace ToDateNet
{
    public partial class FrmToDateNet : Form
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMiliseconds;
        }

        [DllImport("kernel32.dll")]
        public static extern bool SetLocalTime(
            ref SystemTime sysTime);

        public FrmToDateNet() {
            InitializeComponent();
        }

        private void FrmToDateNet_Load(object sender, EventArgs e) {
            DateTime tm = DateTime.Now;
            gcDate1.Value = new DateTime(tm.Year, tm.Month, tm.Day);
            gcTime1.Value = new TimeSpan(tm.Hour, tm.Minute, tm.Second);
            Xml xL = new Xml();
            txtFile.Text = xL.XmlRead("共通", "Path", "Debug");
            txtParam.Text = xL.XmlRead("共通", "Path", "Param");

            chk時間復元.Checked = xL.XmlRead("共通", "Path", "時間復元", "False") != "False";
        }

        private void btn設定_Click(object sender, EventArgs e) {
            DateTime dt = (DateTime)gcDate1.Value;
            TimeSpan ts = (TimeSpan)gcTime1.Value;
            dt = new DateTime(dt.Year, dt.Month, dt.Day, ts.Hours, ts.Minutes, ts.Seconds);
            setNow(dt);
        }
        private void setNow(DateTime? dt) {
            if (dt != null) {
                setNow((DateTime)dt);
            }
        }
        private void setNow(DateTime dt) {
            //システム日時に設定する日時を指定する
            SystemTime sysTime = new SystemTime();
            sysTime.wYear = (ushort)dt.Year;
            sysTime.wMonth = (ushort)dt.Month;
            sysTime.wDay = (ushort)dt.Day;
            sysTime.wHour = (ushort)dt.Hour;
            sysTime.wMinute = (ushort)dt.Minute;
            sysTime.wSecond = (ushort)dt.Second;
            sysTime.wMiliseconds = (ushort)dt.Millisecond;
            //システム日時を設定する
            SetLocalTime(ref sysTime);
        }

        /// <summary>
        /// 世界協定時刻(UTC)をDateTimeオブジェクトで取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGET_Click(object sender, EventArgs e) {
#if DEBUGn
            // UDP生成
            System.Net.Sockets.UdpClient objSck;
            System.Net.IPEndPoint ipAny =
                new System.Net.IPEndPoint(
                System.Net.IPAddress.Any, 0);
            objSck = new System.Net.Sockets.UdpClient(ipAny);

            // UDP送信
            Byte[] sdat=new Byte[48];
            sdat[0] = 0xB;
            objSck.Send(sdat, sdat.GetLength(0),
                "time.windows.com", 123);

            // UDP受信
            Byte[] rdat = objSck.Receive(ref ipAny);

            // 1900年1月1日からの経過時間(日時分秒)
            long lngAllS; // 1900年1月1日からの経過秒数
            long lngD;    // 日
            long lngH;    // 時
            long lngM;    // 分
            long lngS;    // 秒

            // 1900年1月1日からの経過秒数
            lngAllS = (long)(
                        rdat[40] * Math.Pow(2, (8 * 3)) +
                        rdat[41] * Math.Pow(2, (8 * 2)) +
                        rdat[42] * Math.Pow(2, (8 * 1)) +
                        rdat[43]);

            lngD = lngAllS / (24 * 60 * 60); // 日
            lngS = lngAllS % (24 * 60 * 60); // 残りの秒数
            lngH = lngS / (60 * 60);         // 時
            lngS = lngS % (60 * 60);         // 残りの秒数
            lngM = lngS / 60;                // 分
            lngS = lngS % 60;                // 秒

            // DateTime型への変換
            DateTime dtTime = new DateTime(1900,1,1);
            dtTime = dtTime.AddDays(lngD);
            dtTime = dtTime.AddHours(lngH);
            dtTime = dtTime.AddMinutes(lngM);
            dtTime = dtTime.AddSeconds(lngS);
            // グリニッジ標準時から日本時間への変更
            dtTime = dtTime.AddHours(9);
#else
            DateTime dtTime = getNow();
#endif
            DateTime defultDate = new DateTime();
            if (dtTime.CompareTo(defultDate) != 0) {
                setNow(dtTime);
                // 現在の日時表示
                System.Diagnostics.Trace.WriteLine(dtTime);
                gcDate1.Value = new DateTime(dtTime.Year, dtTime.Month, dtTime.Day);
                gcTime1.Value = new TimeSpan(dtTime.Hour, dtTime.Minute, dtTime.Second);
                MessageBox.Show("日付を元に戻しました。", "現在日を求める", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("日付を取得できません", "ToDayNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DateTime getNow() {
            try {
                // UDP生成
                System.Net.Sockets.UdpClient objSck;
                System.Net.IPEndPoint ipAny =
                    new System.Net.IPEndPoint(
                    System.Net.IPAddress.Any, 0);
                objSck = new System.Net.Sockets.UdpClient(ipAny);

                // UDP送信
                Byte[] sdat = new Byte[48];
                sdat[0] = 0xB;
                objSck.Send(sdat, sdat.GetLength(0),
                    "time.windows.com", 123);

                // UDP受信
                Byte[] rdat = objSck.Receive(ref ipAny);

                // 1900年1月1日からの経過時間(日時分秒)
                long lngAllS; // 1900年1月1日からの経過秒数
                long lngD;    // 日
                long lngH;    // 時
                long lngM;    // 分
                long lngS;    // 秒

                // 1900年1月1日からの経過秒数
                lngAllS = (long)(
                            rdat[40] * Math.Pow(2, (8 * 3)) +
                            rdat[41] * Math.Pow(2, (8 * 2)) +
                            rdat[42] * Math.Pow(2, (8 * 1)) +
                            rdat[43]);

                lngD = lngAllS / (24 * 60 * 60); // 日
                lngS = lngAllS % (24 * 60 * 60); // 残りの秒数
                lngH = lngS / (60 * 60);         // 時
                lngS = lngS % (60 * 60);         // 残りの秒数
                lngM = lngS / 60;                // 分
                lngS = lngS % 60;                // 秒

                // DateTime型への変換
                DateTime dtTime = new DateTime(1900, 1, 1);
                dtTime = dtTime.AddDays(lngD);
                dtTime = dtTime.AddHours(lngH);
                dtTime = dtTime.AddMinutes(lngM);
                dtTime = dtTime.AddSeconds(lngS);
                // グリニッジ標準時から日本時間への変更
                dtTime = dtTime.AddHours(9);
                return dtTime;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "ToDayNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
              //throw new Exception("throw at line " + GetLineNumber(), ex); 
                return new DateTime();
            }
        }
        static int GetLineNumber([CallerLineNumber] int line = 0) { return line; }
        private void btn実行_Click(object sender, EventArgs e) {
            try {
                if (chk時間復元.Checked) {
                    btn設定_Click(sender, EventArgs.Empty);
                }
                string fl = txtFile.Text + " " + txtParam.Text;
                System.Diagnostics.Process hProcess = System.Diagnostics.Process.Start(txtFile.Text, txtParam.Text);
                hProcess.WaitForExit(); //終了するまで待つ
                hProcess.Close();
                hProcess.Dispose();
                if (chk時間復元.Checked) {
                    btnGET_Click(sender, EventArgs.Empty);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "ToDayNet", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn参照_Click(object sender, EventArgs e) {
            openFileDialog1.Title = "実行するファイルを指定してください";
            openFileDialog1.Filter = "実行(*.exe)|*.exe|すべてのファイル(*.*)|*.*";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK) {
                txtFile.Text = openFileDialog1.FileName;
                Xml xL = new Xml();
                //xL.XmlWrite("共通", "Path", "Debug", txtFile.Text);
                xL.XmlReWrite("共通", "Path", "Debug", txtFile.Text);
            }
       
        }

        private void chk時間復元_CheckedChanged(object sender, EventArgs e) {
            Xml xL = new Xml();
            xL.XmlReWrite("共通", "Path", "時間復元", chk時間復元.Checked.ToString());
        }

        private void FrmToDateNet_FormClosing(object sender, FormClosingEventArgs e) {
            //時刻確認
            DateTime LocalNow = DateTime.Now;
            DateTime Now = getNow();
            TimeSpan ts = Now - LocalNow;
            if (ts.TotalMinutes <= 5 && ts.TotalMinutes >= -5) {
            } 
            else if (MessageBox.Show("時間を元に戻しますか?","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) {
                btnGET_Click(sender, EventArgs.Empty);
            }
        }

        private void txtParam_Validating(object sender, CancelEventArgs e) {
            Xml xL = new Xml();
            xL.XmlReWrite("共通", "Path", "Param", txtParam.Text);
        }

    }
    class Xml
    {
        XmlDocument xDoc = new XmlDocument();
        public Xml()
        {
            if (File.Exists("VMAP.xml")) {
                xDoc.Load("VMAP.xml");    //XML宣言
            }
            else {
                XmlDeclaration xmd = xDoc.CreateXmlDeclaration("1.0", "shift-jis", "yes");    //XML宣言
                xDoc.AppendChild(xmd);
                XmlElement root = xDoc.CreateElement("VMAP");     //ルートノードの作成
                xDoc.AppendChild(root);   //xmlDocumentオブジェクトにルートノードを追加
                xDoc.Save("VMAP.xml");
            }
        }
        public void XmlWrite(string nodeElement1, string nodeElement2, string nodeElement3, string nt1) {
            XmlDocument xd = new XmlDocument();
            if (File.Exists("VMAP.xml")) {
                xd.Load("VMAP.xml");    //XML宣言
            }
            //XML宣言作成
            XmlDeclaration xmd = xd.CreateXmlDeclaration("1.0", "shift-jis", "yes");    //XML宣言
            xd.AppendChild(xmd);
            XmlElement root = xd.CreateElement("VMAP");     //ルートノードの作成
            XmlNode xn1 = xd.CreateNode(XmlNodeType.Element, nodeElement1, "");   //子ノードの作成
            XmlNode xn2 = xd.CreateNode(XmlNodeType.Element, nodeElement2, "");   //孫ノードの作成
            XmlNode xn3 = xd.CreateNode(XmlNodeType.Element, nodeElement3, "");   //ひ孫ノードの作成
            XmlCharacterData xt = xd.CreateTextNode(nt1);   //孫ノードの値
            xn3.AppendChild(xt);    //孫ノードの値を孫ノードに追加
            xn2.AppendChild(xn3);    //孫ノードの値を孫ノードに追加
            xn1.AppendChild(xn2);    //孫ノードの値を孫ノードに追加

            root.AppendChild(xn1);  //子ノードをルートノードに追加
            xd.AppendChild(root);   //xmlDocumentオブジェクトにルートノードを追加
            Console.WriteLine(xd.OuterXml);
            xd.Save("VMAP.xml");
        }
        void NodeMake(string nodeElement1, string nodeElement2, string text = null) {
            XmlNodeList xl = xDoc.SelectNodes(nodeElement1 + "/" + nodeElement2);
            if (xl.Count == 0) {
                XmlNode Root = xDoc.SelectSingleNode(nodeElement1);
                XmlNode xn = xDoc.CreateNode(XmlNodeType.Element, nodeElement2, "");   //子ノードの作成
                Root.AppendChild(xn);
                if (text != null) {
                    XmlCharacterData xt = xDoc.CreateTextNode(text);   //孫ノードの値
                    xn.AppendChild(xt);    //孫ノードの値を孫ノードに追加
                }    
            }
            else if (text != null) {
                xl[0].InnerText = text;
            }
        }
        public void XmlReWrite(string nodeElement1, string nodeElement2, string nodeElement3, string text) {
#if DEBUGn
            XmlDocument xd = new XmlDocument();
            if (File.Exists("VMAP.xml")) {
                xd.Load("VMAP.xml");    //XML宣言
                //子
                XmlNodeList xl = xd.SelectNodes("VMAP/" + nodeElement1);
                if (xl.Count == 0) {
                    XmlNode Root = xd.SelectSingleNode("VMAP");
                    XmlNode xn1 = xd.CreateNode(XmlNodeType.Element, nodeElement1, "");   //子ノードの作成
                    Root.AppendChild(xn1);
                }
                //孫
                xl = xd.SelectNodes("VMAP/" + nodeElement1 + "/" + nodeElement2);
                if (xl.Count == 0) {
                    XmlNode Root = xd.SelectSingleNode("VMAP/" + nodeElement1);
                    XmlNode xn2 = xd.CreateNode(XmlNodeType.Element, nodeElement2, "");   //子ノードの作成
                    Root.AppendChild(xn2);
                }
                //孫
                xl = xd.SelectNodes("VMAP/" + nodeElement1 + "/" + nodeElement2 + "/" + nodeElement3);
                if (xl.Count == 0) {
                    XmlNode Root = xd.SelectSingleNode("VMAP/" + nodeElement1 + "/" + nodeElement2);
                    XmlNode xn3 = xd.CreateNode(XmlNodeType.Element, nodeElement3, "");   //子ノードの作成
                    Root.AppendChild(xn3);
                }
                
                //xl = xd.SelectNodes("VMAP/" + nodeElement1 + "/" + nodeElement2 + "/" + nodeElement3);
                //if (xl.Count > 0) {
                xl[0].InnerText = text;
                    xd.Save("VMAP.xml");
                //}
            }
            else {
                XmlWrite(nodeElement1, nodeElement2, nodeElement3, text);
                return;
            }
#else
            NodeMake("VMAP", nodeElement1);
            NodeMake("VMAP/" + nodeElement1, nodeElement2);
            NodeMake("VMAP/" + nodeElement1 + "/" + nodeElement2, nodeElement3, text);
            xDoc.Save("VMAP.xml");
#endif
        }
        public string XmlRead(string nodeElement1, string nodeElement2, string nodeElement3,string 初期値 = "") {
            string Text = "";
#if DEBUGn
            XmlDocument xd = new XmlDocument();
            if (File.Exists("VMAP.xml")) {
                xd.Load("VMAP.xml");    //XML宣言
                //xPathを使って、表示するノードを選択する
                string ndPath = "VMAP/" + nodeElement1 + "/" + nodeElement2 + "/" + nodeElement3;
                XmlNodeList xl = xd.SelectNodes(ndPath);
                foreach (XmlNode xn in xl) {
                    Console.WriteLine(xn.InnerText);
                }
                if (xl.Count > 0) {
                     Text =  xl[0].InnerText;
                }
            }
            //もう一つのパターン
            if (File.Exists("VMAP.xml")) {
                xd.Load("VMAP.xml");    //XML宣言
                //xPathを使って、表示するノードを選択する
                string ndPath = "VMAP/" + nodeElement1 + "/" + nodeElement2;
                XmlNodeList nodeList = xd.SelectNodes(ndPath);
                foreach (XmlNode nd in nodeList) {
                    Text = nd.SelectSingleNode(nodeElement3).InnerText;
                }
            }            
#else
            //xPathを使って、表示するノードを選択する
            string ndPath = "VMAP/" + nodeElement1 + "/" + nodeElement2 + "/" + nodeElement3;
            XmlNodeList xl = xDoc.SelectNodes(ndPath);
            foreach (XmlNode xn in xl) {
                Console.WriteLine(xn.InnerText);
            }
            if (xl.Count > 0) {
                Text = xl[0].InnerText;
            }
            else {
                Text = 初期値;
            }
#endif
            return Text;
        }
    }
}
