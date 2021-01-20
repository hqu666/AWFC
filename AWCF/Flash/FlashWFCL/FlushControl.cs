using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxShockwaveFlashObjects;
using System.Xml;

namespace PlayerWFCL {
	public partial class FlushControl : UserControl {

		public string titolStr = "【WMPControl】";

		public FlushControl() {
			string TAG = "[WMPControl]";
			string dbMsg = TAG;
			try {
				InitializeComponent();
				InitAxShockwaveFlash();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}


		/// <summary>
		/// FormのInitializeComponent
		/// </summary>
		private void Initialize() {
			string TAG = "[Initialize]";
			string dbMsg = TAG;
			try {
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlushControl));
				this.SFPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
				((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).BeginInit();
				////コントロールのレイアウト ロジックを一時的に中断します。
				//this.SuspendLayout();
				this.SFPlayer.Enabled = true;
				this.SFPlayer.Location = new System.Drawing.Point(0, 0);
				this.SFPlayer.Name = "SFPlayer";
				//this.SFPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SFPlayer.OcxState")));
				////'System.Windows.Forms.AxHost+InvalidActiveXStateException' 
				this.SFPlayer.Size = new System.Drawing.Size(960, 540);
				this.SFPlayer.TabIndex = 0;

				////フォームのクライアント領域のサイズを取得または設定
				//this.ClientSize = new System.Drawing.Size(284, 261);
				//生成したAxShockwaveFlashObjectsの追加	

				//this.Controls.Add(this.SFPlayer);
				//	Frame frame = new Frame();
				//		this.PlayerFrame.Navigate(this.SFPlayer);
				////		System.Windows.Forms.AxHost + InvalidActiveXStateException
				//	this.FlashGrid.Children.Add((UIElement)frame);

				this.Name = "FlashPage";
				((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).EndInit();
				////SuspendLayoutの終了：レイアウトロジックを再開する
				//this.ResumeLayout(false);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		/// <summary>
		/// AxShockwaveFlashの設定
		/// </summary>
		private void InitAxShockwaveFlash() {
			string TAG = "[InitAxShockwaveFlash]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";

				this.SFPlayer.AllowFullScreen = "true";
				this.SFPlayer.BGColor = "000000";
				this.SFPlayer.AllowNetworking = "all";

			//	this.SFPlayer.CtlScale = "NoScale";
				//this.SFPlayer.CtlScale = "NoBorder ";
				this.SFPlayer.CtlScale = "ExactFit";
				//this.SFPlayer.CtlScale = "ShowAll";

				this.SFPlayer.DeviceFont = false;
				this.SFPlayer.EmbedMovie = true;

				this.SFPlayer.FrameNum = -1;
				this.SFPlayer.Loop = true;
				this.SFPlayer.Playing = true;
				this.SFPlayer.Profile = true;
				this.SFPlayer.Quality2 = "High";
				this.SFPlayer.SAlign = "LT";
				this.SFPlayer.WMode = "Window";
				this.SFPlayer.Dock = DockStyle.Fill;

		//		this.SFPlayer.Controls.Add. = DockStyle.Fill;

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
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
				try {
					string extention = System.IO.Path.GetExtension(targetURLStr);
					dbMsg += "、拡張子=" + extention;
					if (extention.Equals(".flv") || extention.Equals(".f4v")) {
							LoadFLV(targetURLStr);
					} else if (extention.Equals(".swf")) {
						//swfファイルならなんでもいい
						SFPlayer.LoadMovie(0, targetURLStr); //でthis.SFPlayer.Movieにセットされるが再生はされない
															 //   Movie   "M:\\sample\\EmbedFlash.swf" 
					}
					SFPlayer.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(SFPlayer_FlashCall);
				} catch {
					string titolStr = "Flash";
						//dbMsg += ",result=" + result;
					string msgStr = "Flashがインストールされていないようです";
					dbMsg += ",msgStr=" + msgStr;
					//System.Windows.MessageBoxResult result = MessageShowWPF(titolStr, msgStr,
					//														System.Windows.MessageBoxButton.OK,
					//														System.Windows.MessageBoxImage.Exclamation);
					//dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		/// <summary>
		/// FLVファイルのロード
		/// </summary>
		/// <param name="videoPath"></param>
		public void LoadFLV(string videoPath) {
			string TAG = "[LoadFLV]";
			string dbMsg = TAG;
			try {
				if (this.SFPlayer != null) {
					dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
					this.SFPlayer.CallFunction("<invoke name=\"loadAndPlayVideo\" returntype=\"xml\"><arguments><string>" + videoPath + "</string></arguments></invoke>");
				} else {
					dbMsg += "SFPlayer = null";
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}


		private void SFPlayer_FlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
			string TAG = "[SFPlayer_FlashCall]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
				var document = new XmlDocument();
				document.LoadXml(e.request);

				XmlNodeList list = document.GetElementsByTagName("arguments");
				//ResizePlayer(Convert.ToInt32(list[0].FirstChild.InnerText), Convert.ToInt32(list[0].ChildNodes[1].InnerText));

				var width = int.Parse(list[0].ChildNodes[0].InnerText);
				var height = int.Parse(list[0].ChildNodes[1].InnerText);

				//0117			this.ClientSize = new System.Drawing.Size(width, height);
				SFPlayer.ClientSize = this.SFPlayer.Size;
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
