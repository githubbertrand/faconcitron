using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lemonwayToolboxClient
{
    public partial class Form1 : Form
    {
        private const int defaultFiboRank = 10;
        private const string defaultXmlToJson = "<foo>bar</foo>";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExecThread(callWebServiceFibo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExecThread(callXmlToJson);
        }

        private void ExecThread(Func<returnMsgValue> mymethode)
        {
            this.Cursor = Cursors.WaitCursor;

            returnMsgValue ret = null;
            using (var t = new FormWait())
            {
                t.Show();
                var cThread = new Thread(() => ret = mymethode());
                cThread.Start();
                var completed = cThread.Join(10000);
                t.Close();
                if (!completed)
                {
                    MessageBox.Show("service not response after 10 sec wait. please retry later.");
                }
                else if (ret != null && string.IsNullOrEmpty(ret.ErrorMsg))
                {
                    MessageBox.Show(string.Format("result {0}", ret.ReturnValue));
                }
                else if (ret != null)
                {
                    MessageBox.Show(string.Format("error during invoke : {0}", ret.ErrorMsg));
                }
            }
            this.Cursor = Cursors.Default;
        }
        private returnMsgValue callWebServiceFibo()
        {
            try
            {
                var t = new ServiceReference1.lemonwayToolBoxSoapClient();
                Thread.Sleep(3000);
                return new returnMsgValue(t.FibonacciValue(defaultFiboRank).ToString(), string.Empty);
            }
            catch (Exception e)
            {
                return new returnMsgValue(string.Empty, e.Message);
            }
        }
        private returnMsgValue callXmlToJson()
        {
            try
            {
                var t = new ServiceReference1.lemonwayToolBoxSoapClient();
                return new returnMsgValue(t.XmlToJsonParser(defaultXmlToJson).ToString(), string.Empty);
            }
            catch (Exception e)
            {
                return new returnMsgValue(string.Empty, e.Message);
            }
        }

        private class returnMsgValue
        {
            public string ErrorMsg;
            public string ReturnValue;
            public returnMsgValue(string retValue, string errorMsg)
            {
                ReturnValue = retValue;
                ErrorMsg = errorMsg;
            }
        }
    }
}
