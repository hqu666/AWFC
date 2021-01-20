using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerWFCL {
	public partial class WMPControl : UserControl {
		public string titolStr = "【WMPControl】";


		public WMPControl() {
			string TAG = "[WMPControl]";
			string dbMsg = TAG;
			try {
				InitializeComponent();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		public void AddURl(string targetURLStr) {
			string TAG = "[AddURl]";
			string dbMsg = TAG;
			try {
				this.WMPlayer.URL = targetURLStr;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		//////////////////////https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/advanced/walkthrough-hosting-an-activex-control-in-wpf?view=netframeworkdesktop-4.8&viewFallbackFrom=netframework-4.8
		private void MyLog(string TAG, string dbMsg) {
			dbMsg = titolStr + dbMsg;
#if DEBUG
			Console.WriteLine(TAG + ";" + dbMsg);

			//Constant.debugNow = true;
#endif
		}

		public void MyErrorLog(string TAG, string dbMsg, Exception err) {
			dbMsg = titolStr + dbMsg;
			Console.WriteLine(TAG + "; " + dbMsg + "でエラー発生;" + err);
		}


	}
}
