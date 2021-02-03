using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace PlayerWFCL {
	public partial class WMPControl : UserControl {
		public string titolStr = "【WMPControl】";
		/// <summary>
		/// 再生ファイル名
		/// </summary>
		public string TargetURLStr = "";
		/// <summary>
		/// 現在のメディア
		/// </summary>
		IWMPMedia cMedia;
		/// <summary>
		///  Windows Media Playerの設定
		/// </summary>
		IWMPSettings wmpSettings;

		public WMPControl(string targetURLStr) {
			string TAG = "[WMPControl]";
			string dbMsg = TAG;
			try {
				this.TargetURLStr = targetURLStr;
				InitializeComponent();
				Initialize();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		private void Initialize() {
			string TAG = "[Initialize]";
			string dbMsg = TAG;
			try {
				((System.ComponentModel.ISupportInitialize)(this.WMPlayer)).BeginInit();
				//
				// axWindowsMediaPlayer
				//
				this.WMPlayer.Enabled = true;
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WMPControl));
				this.WMPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer.OcxState")));
				// 	コントロールの表示方法:再生、停止などのコントロールと音量
			//	this.WMPlayer.uiMode = "mini";
				// コンテキスト メニューを有効にする
				this.WMPlayer.enableContextMenu = true;
				// 動画がウィンドウより小さいとき、ウィンドウの大きさに広げる
				this.WMPlayer.stretchToFit = true;
				//// ウィンドウなしでビデオを表示する
				this.WMPlayer.windowlessVideo = true;
				this.WMPlayer.settings.autoStart=true;

				wmpSettings = this.WMPlayer.settings;

				((System.ComponentModel.ISupportInitialize)(this.WMPlayer)).EndInit();
				this.Load += new System.EventHandler(this.WMPControlLoad);
				//0124			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
				//0124			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		private void WMPControlLoad(object sender, EventArgs e) {
			string TAG = "[WMPControlLoad]";
			string dbMsg = TAG;
			try {
				try {
					dbMsg += "開始[" + WMPlayer.Width + "×" + WMPlayer.Height + "]";				// + "、元実行ファイル= " + assemblyName;
					dbMsg += "\r\nTargetURLStr=" + TargetURLStr;
					AddURl(TargetURLStr);
				} catch {
					MessageBox.Show("Flashがインストールされていないようですが・・(^ω^;)");
				}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		//
		public void ReSizeContlor(int setWidth, int setHeight) {
			string TAG = "[ReSizeContlor]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + WMPlayer.Width + "×" + WMPlayer.Height + "]";
				dbMsg += ">set[" + setWidth + "×" + Height + "]";
				if (10< setWidth && 10 < setHeight) {
					WMPlayer.Width = setWidth;
					WMPlayer.Height = setHeight;
					dbMsg += ">>[" + WMPlayer.Width + "×" + WMPlayer.Height + "]";
				}
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
				cMedia = this.WMPlayer.currentMedia;
				dbMsg += ",名前＝" + cMedia.name;
				dbMsg += ",type=" + cMedia.GetType();
				dbMsg += ",動画サイズ[" + cMedia.imageSourceWidth + "×" + cMedia.imageSourceHeight + "]";
				dbMsg += ",全長[" + cMedia.durationString + "]";
				
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
