﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Xml;
using AxShockwaveFlashObjects;
using System.Threading;

namespace AWCF.Views {
	public partial class FlashPage : Page {
		public string titolStr = "【FlashPage】";
		private System.ComponentModel.IContainer components = null;
		public AxShockwaveFlash SFPlayer;
		public string TargetURLStr;

		#region コンストラクタ
		public FlashPage(string targetURLStr) {
			string TAG = "[FlashPage]";
			string dbMsg = TAG;
			try {
				dbMsg += "targetURLStr=" + targetURLStr;
				TargetURLStr = targetURLStr;
				this.Loaded += this_loaded;
//				this.Loaded += LoadedProc;
				//	Parent.Activated += this_activated;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		private void this_loaded(object sender, RoutedEventArgs e) {
			string TAG = "[LoadedProc]";
			string dbMsg = TAG;
			try {
				Initialize();
				InitAxShockwaveFlash();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		/// <summary>
		/// 要素の配置、描画、および操作の準備が完了したときに発生
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void LoadedProc(object sender, RoutedEventArgs e) {
			string TAG = "[LoadedProc]";
			string dbMsg = TAG;
			try {
				await Task.Run(() =>
				{
					do {
						Thread.Sleep(100);
					} while (!System.Windows.Application.Current.Dispatcher.Invoke(() => { bool IsActive = false; return IsActive; }));
				});
				Initialize();
				InitAxShockwaveFlash();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		private void this_activated(object sender, RoutedEventArgs e) {
			string TAG = "[this_activated]";
			string dbMsg = TAG;
			try {
				Initialize();
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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlashPage));
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
				ActiveXHost.Child = SFPlayer;

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

				this.SFPlayer.AllowFullScreen = "false";
				this.SFPlayer.BGColor = "000000";
				this.SFPlayer.AllowNetworking = "all";

				this.SFPlayer.CtlScale = "NoScale";
				//this.SFPlayer.CtlScale = "NoBorder ";
				//this.SFPlayer.CtlScale = "ExactFit";
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
					SFPlayer.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(SFPlayer_FlashCall);
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

		//0117
		/// <summary>
		/// DragDrop
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void Form1_DragDrop(object sender, DragEventArgs e) {
		//	string TAG = "[InitAxShockwaveFlash]";
		//	string dbMsg = TAG;
		//	try {
		//		dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
		//		string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
		//		LoadFLV(files[0]);
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		dbMsg += "<<以降でエラー発生>>" + er.Message;
		//		MyLog(TAG, dbMsg);
		//	}
		//}

		/// <summary>
		/// DragEnter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//private void Form1_DragEnter(object sender, DragEventArgs e) {
		//	string TAG = "[Form1_DragEnter]";
		//	string dbMsg = TAG;
		//	try {
		//		dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
		//		if (e.Data.GetDataPresent(DataFormats.FileDrop, false)) {
		//			e.Effect = DragDropEffects.All;
		//		}
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		dbMsg += "<<以降でエラー発生>>" + er.Message;
		//		MyLog(TAG, dbMsg);
		//	}
		//}
		#endregion

		#region メソッド

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
		//protected override void Dispose(bool disposing) {
		//	string TAG = "[Dispose]";
		//	string dbMsg = TAG;
		//	try {
		//		dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]";
		//		if (disposing && (components != null)) {
		//			components.Dispose();
		//		}
		//		base.Dispose(disposing);
		//		MyLog(TAG, dbMsg);
		//	} catch (Exception er) {
		//		dbMsg += "<<以降でエラー発生>>" + er.Message;
		//		MyLog(TAG, dbMsg);
		//	}
		//}
		#endregion

		///////////////////////http://zecl.hatenablog.com/entry/20081119/p1
		public void MyLog(string TAG, string dbMsg) {
			dbMsg = titolStr + dbMsg;
			//dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public void MyErrorLog(string TAG, string dbMsg, Exception err) {
			dbMsg = titolStr + dbMsg;
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

