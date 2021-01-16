using System;
using System.Windows.Forms;
using System.Xml;
using AxShockwaveFlashObjects;

namespace AWCF.Views {
	public partial class FlashForm : Form {
		private System.ComponentModel.IContainer components = null;
		public AxShockwaveFlash SFPlayer;
		private AxShockwaveFlash axShockwaveFlash1;
		public string TargetURLStr;

		#region コンストラクタ
		public FlashForm(string targetURLStr) {
			string TAG = "[FlashForm]";
			string dbMsg = TAG;
			try {
				dbMsg += "targetURLStr=" + targetURLStr;
				TargetURLStr = targetURLStr;
				InitializeComponent();
				InitAxShockwaveFlash();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}
		#endregion

		#region イベント
		private void Form1_Load(object sender, EventArgs e) {
			string TAG = "[Form1_Load]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
				try {
					string extention = System.IO.Path.GetExtension(TargetURLStr);
					dbMsg += "、拡張子=" + extention;
					if (extention.Equals(".flv") || extention.Equals(".f4v")) {
						LoadFLV(TargetURLStr);
					} else if (extention.Equals(".swf")) {
						SFPlayer.LoadMovie(0, TargetURLStr); //でthis.SFPlayer.Movieにセットされるが再生はされない
																//   Movie   "M:\\sample\\EmbedFlash.swf" 
					}
					//swfファイルならなんでもいい
					//	SFPlayer.LoadMovie(0, Application.StartupPath + TargetURLStr);
					SFPlayer.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(axShockwaveFlash1_FlashCall);
				} catch {
					string titolStr = "Flash";
					string msgStr = "Flashがインストールされていないようです";
					System.Windows.MessageBoxResult result = MessageShowWPF(titolStr, msgStr,
																			System.Windows.MessageBoxButton.OK,
																			System.Windows.MessageBoxImage.Exclamation);
					dbMsg += ",result=" + result;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		private void axShockwaveFlash1_FlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e) {
			string TAG = "[axShockwaveFlash1_FlashCall]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
				var document = new XmlDocument();
				document.LoadXml(e.request);

				XmlNodeList list = document.GetElementsByTagName("arguments");
				//ResizePlayer(Convert.ToInt32(list[0].FirstChild.InnerText), Convert.ToInt32(list[0].ChildNodes[1].InnerText));

				var width = int.Parse(list[0].ChildNodes[0].InnerText);
				var height = int.Parse(list[0].ChildNodes[1].InnerText);

				this.ClientSize = new System.Drawing.Size(width, height);
				SFPlayer.ClientSize = this.SFPlayer.Size;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		/// <summary>
		/// DragDrop
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragDrop(object sender, DragEventArgs e) {
			string TAG = "[InitAxShockwaveFlash]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				LoadFLV(files[0]);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		/// <summary>
		/// DragEnter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragEnter(object sender, DragEventArgs e) {
			string TAG = "[Form1_DragEnter]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
				if (e.Data.GetDataPresent(DataFormats.FileDrop, false)) {
					e.Effect = DragDropEffects.All;
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}
		#endregion

		#region メソッド

		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlashForm));
			this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
			((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
			this.SuspendLayout();
			// 
			// axShockwaveFlash1
			// 
			this.axShockwaveFlash1.Enabled = true;
			this.axShockwaveFlash1.Location = new System.Drawing.Point(63, 104);
			this.axShockwaveFlash1.Name = "axShockwaveFlash1";
			this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
			this.axShockwaveFlash1.Size = new System.Drawing.Size(166, 95);
			this.axShockwaveFlash1.TabIndex = 0;
			// 
			// FlashForm
			// 
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.axShockwaveFlash1);
			this.Name = "FlashForm";
			((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
			this.ResumeLayout(false);

		}

		/// <summary>
		/// AxShockwaveFlashの設定
		/// </summary>
		private void InitAxShockwaveFlash() {
			string TAG = "[InitAxShockwaveFlash]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";

				this.SFPlayer.AllowFullScreen = "false";
				this.SFPlayer.BGColor = "000000";
				this.SFPlayer.AllowNetworking = "all";

				this.SFPlayer.CtlScale = "NoScale";
				//this.axShockwaveFlash1.CtlScale = "NoBorder ";
				//this.axShockwaveFlash1.CtlScale = "ExactFit";
				//this.axShockwaveFlash1.CtlScale = "ShowAll";

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
				if (SFPlayer != null) {
					dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
					SFPlayer.CallFunction("<invoke name=\"loadAndPlayVideo\" returntype=\"xml\"><arguments><string>" + videoPath + "</string></arguments></invoke>");
				} else {
					dbMsg += "SFPlayer = null";
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}
		#endregion

		#region Dispose
		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing) {
			string TAG = "[Dispose]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
				if (disposing && (components != null)) {
					components.Dispose();
				}
				base.Dispose(disposing);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}
		#endregion

		///////////////////////http://zecl.hatenablog.com/entry/20081119/p1
		public static void MyLog(string TAG, string dbMsg) {
			dbMsg = "[FlashForm]" + dbMsg;
			//dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err) {
			dbMsg = "[FlashForm]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

		public System.Windows.MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		System.Windows.MessageBoxButton buttns,
																		System.Windows.MessageBoxImage icon
																		) {
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}

	}
}