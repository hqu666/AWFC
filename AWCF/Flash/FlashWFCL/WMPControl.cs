using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Windows;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;
using MessageBox = System.Windows.Forms.MessageBox;

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
		public IWMPMedia cMedia;
		/// <summary>
		///  Windows Media Playerの設定
		/// </summary>
		public IWMPSettings wmpSettings;

		public string DurationStr;
		private double _Duration;
		/// <summary>
		/// 全長
		/// </summary>
		public double Duration {
			//get { return GetDataBindItem<string>("Title").Value; }
			//private set { GetDataBindItem<string>("Title").Value = value; }
			get => _Duration;
			set {
				if (_Duration == value)
					return;
				_Duration = value;
			}
		}

		public string PositionStr;
		private double _Position;
		/// <summary>
		/// 再生ポジション
		/// </summary>
		public double Position {
			get => _Position;
			set {
				if (_Position == value)
					return;
				_Position = value;
			}
		}

		private bool _IsPlaying;
		/// <summary>
		/// 再生ポジション
		/// </summary>
		public bool IsPlaying {
			get => _IsPlaying;
			set {
				if (_IsPlaying == value)
					return;
				_IsPlaying = value;
			}
		}



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
				this.DurationStr = "";
				this.Duration=0;
				this.PositionStr = "";
				this.Position=0;
				this.IsPlaying = false;
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
				this.WMPlayer.PlayStateChange += MediaPlayer_PlayStateChange;
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
		//		Thread.Sleep(1000);

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

		/// <summary>
		/// ステータスが変更された時に呼び出される
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e) {
			string TAG = "[MediaPlayer_PlayStateChange]";
			string dbMsg = TAG;
			try {
				AxWMPLib.AxWindowsMediaPlayer WMP = (AxWMPLib.AxWindowsMediaPlayer)sender;
				dbMsg += "newState=" + e.newState;
				switch (e.newState) {
					case (int)WMPLib.WMPPlayState.wmppsUndefined:        //0
						dbMsg += "wmppsUndefined;";
						break;
					case (int)WMPLib.WMPPlayState.wmppsStopped:			//1
						dbMsg += "停止時;";
						this.IsPlaying = false;
						break;

					case (int)WMPLib.WMPPlayState.wmppsPaused:          //2
						dbMsg += ";一時停止;";
						this.IsPlaying = false;
						break;

					case (int)WMPLib.WMPPlayState.wmppsPlaying:			//3
						dbMsg += ":再生時;";
						this.IsPlaying = true;
						if (WMP.Ctlcontrols != null) {
							this.Position = WMP.Ctlcontrols.currentPosition;
							this.PositionStr = WMP.Ctlcontrols.currentPositionString;
							dbMsg += "[" + this.Position + " =" + this.PositionStr + " / ";
						}
						if (WMP.currentMedia != null) {
							this.Duration = WMP.currentMedia.duration;
							this.DurationStr = WMP.currentMedia.durationString;
							dbMsg += "、全長=" + this.Duration + "=" + DurationStr + "]";
						}
						break;
					case (int)WMPLib.WMPPlayState.wmppsScanForward:    //4
						dbMsg += "wmppsScanForward ;";
						break;
					case (int)WMPLib.WMPPlayState.wmppsScanReverse:    //5
						dbMsg += "wmppsScanReverse ;";
						break;
					case (int)WMPLib.WMPPlayState.wmppsBuffering:      //6
						dbMsg += "wmppsBuffering ;";
						break;
					case (int)WMPLib.WMPPlayState.wmppsWaiting:        //7
						dbMsg += "wmppsWaiting ;";
						break;

					case (int)WMPLib.WMPPlayState.wmppsMediaEnded:		//8
						dbMsg += ";再生終了時;";
						//			timer1.Start();
						break;

					case (int)WMPLib.WMPPlayState.wmppsTransitioning:	//9
						dbMsg += ";再生準備中;";
						if (WMP.currentMedia != null) {
							this.Duration = WMP.currentMedia.duration;
							this.DurationStr = WMP.currentMedia.durationString;
							dbMsg += "、全長=" + this.Duration + "=" + DurationStr + "]";
						}
						break;

					case (int)WMPLib.WMPPlayState.wmppsReady:			//10
						dbMsg += ";再生準備完了;";
						if (WMP.currentMedia != null) {
							this.Duration = WMP.currentMedia.duration;
							this.DurationStr = WMP.currentMedia.durationString;
							dbMsg += "、全長=" + this.Duration + "=" + DurationStr + "]";
						}
						break;
					case (int)WMPLib.WMPPlayState.wmppsReconnecting:   //11
						dbMsg += ";wmppsReconnecting ;";
						break;
					case (int)WMPLib.WMPPlayState.wmppsLast:           //12
						dbMsg += ";wmppsLast ;";
						break;

					default:
						dbMsg += "その他;";
						break;
				}
				dbMsg += ",再生中＝";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		public double GetPlayPosition() {
			string TAG = "[GetPlayControls]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + WMPlayer.Width + "×" + WMPlayer.Height + "]";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyLog(TAG, dbMsg);
			}
			return WMPlayer.Ctlcontrols.currentPosition;
		}

		public double GetDuration() {
			string TAG = "[GetDuration]";
			string dbMsg = TAG;
			double retDouble=0;
			try {
				retDouble=WMPlayer.currentMedia.duration;
				dbMsg += "、全長=" + retDouble + "=" + WMPlayer.currentMedia.durationString;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyLog(TAG, dbMsg);
			}
			return retDouble;
		}



		public AxWMPLib.AxWindowsMediaPlayer GetPlayer() {
			string TAG = "[GetPlayer]";
			string dbMsg = TAG;
			try {
				dbMsg += "開始[" + WMPlayer.Width + "×" + WMPlayer.Height + "]";
				MyLog(TAG, dbMsg);
			//	AxWMPLib.AxWindowsMediaPlayer pr = WMPlayer;
			} catch (Exception er) {
				MyLog(TAG, dbMsg);
			}
			return WMPlayer;
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
