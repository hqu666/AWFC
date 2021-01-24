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
		/// <summary>
		/// 実行デレクトリ
		/// </summary>
		public string assemblyPath;
		/// <summary>
		/// 元実行ファイル
		/// </summary>
		public string assemblyName;


		public FlushControl() {
			string TAG = "[WMPControl]";
			string dbMsg = TAG;
			try {
				InitializeComponent();
				this.assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				dbMsg += "、実行デレクトリ= " + assemblyPath;
				string[] urlStrs = assemblyPath.Split(System.IO.Path.DirectorySeparatorChar);                   //パスセパレータで切り分け
				this.assemblyName = urlStrs[urlStrs.Length - 1];
				dbMsg += "、元実行ファイル= " + assemblyName;

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
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlushControl));
				((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).BeginInit();
				this.SFPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
				this.SFPlayer.Enabled = true;
				this.SFPlayer.Location = new System.Drawing.Point(0, 0);
				this.SFPlayer.Name = "SFPlayer";
				this.SFPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SFPlayer.OcxState")));
				this.SFPlayer.Size = new System.Drawing.Size(960, 540);
				this.SFPlayer.TabIndex = 0;
				this.Name = "FlashObj";

				// 
				// Form1
				// 
				this.AllowDrop = true;
				this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
				this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
				this.ClientSize = new System.Drawing.Size(394, 312);
				//0124		this.MaximizeBox = false;
				//0124		this.Text = "Form1";
				//0124						this.Load += new System.EventHandler(this.FlushControlLoad);
				//0124			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
				//0124			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
				((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).EndInit();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				dbMsg += "<<以降でエラー発生>>" + er.Message;
				MyLog(TAG, dbMsg);
			}
		}

		private void FlushControlLoad(object sender, EventArgs e) {
			string TAG = "[FlushControlLoad]";
			string dbMsg = TAG;
			try {
				try {
					dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]" + "、元実行ファイル= " + assemblyName;
					//		string playerUrl = assemblyPath.Replace(assemblyName, "flvplayer-305.swf");
					string playerUrl = assemblyPath.Replace(assemblyName, "fladance.swf");
					dbMsg += " 、playerUrl= " + playerUrl;
					SFPlayer.LoadMovie(0, playerUrl);
					SFPlayer.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(SFPlayer_FlashCall);
				} catch {
					MessageBox.Show("Flashがインストールされていないようですが・・(^ω^;)");
				}
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

				this.SFPlayer.CtlScale = "NoScale";
				//this.SFPlayer.CtlScale = "NoBorder ";
				//	this.SFPlayer.CtlScale = "ExactFit";
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

		/// <summary>
		/// クラス外から再生ファイルを指定する
		/// </summary>
		/// <param name="targetURLStr"></param>
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
						//	SFPlayer.CallFunction(targetURLStr);
					} else if (extention.Equals(".swf")) {
						SFPlayer.LoadMovie(0, targetURLStr); //でthis.SFPlayer.Movieにセットされるが再生はされない
															 //   Movie   "M:\\sample\\EmbedFlash.swf" 
					}
					SFPlayer.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(SFPlayer_FlashCall);
					SFPlayer.Play();
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
		public void LoadFLV(string targetURLStr) {
			string TAG = "[LoadFLV]";
			string dbMsg = TAG;
			try {
				if (this.SFPlayer != null) {
					dbMsg += "開始[" + SFPlayer.Width + "×" + SFPlayer.Height + "]" + "、元実行ファイル= " + assemblyName;
					//		string playerUrl = assemblyPath.Replace(assemblyName, "flvplayer-305.swf");
					string playerUrl = assemblyPath.Replace(assemblyName, "fladance.swf");
					dbMsg += " 、playerUrl= " + playerUrl;
					SFPlayer.LoadMovie(0, playerUrl);


					//string flashVvars = "flvmov=rtmp:///" + @targetURLStr;
					//			string flashVvars = "fms_app=&video_file=file:///" + @targetURLStr;
					string flashVvars = "\"" + "fms_app=&video_file=file:///" + @targetURLStr;
					flashVvars += "&image_file=&link_url=&autoplay=true&mute=false&controllbar=true&buffertime=10" + "\"";
					dbMsg += "\r\nflashVvars= " + flashVvars;
					SFPlayer.FlashVars = flashVvars;
					//		SFPlayer.Movie = playerUrl;

					/*<param name="FlashVars" 
					 value="fms_app=&video_file=file:///P:/dendow/1actress/%E7%A2%BA%E8%AA%8D%E4%B8%AD/%E5%B8%82%E8%B2%A9/%E5%88%BA%E9%9D%92%E5%9E%82%E3%82%8C%E4%B9%B3/20_34-92_109nmin.flv
					 &image_file=&link_url=&autoplay=true&mute=false&controllbar=true&buffertime=10""/>
					 */
					///////オリジナル		"+ playerUrl + "
					////		this.SFPlayer.CallFunction("<invoke name=\"loadAndPlayVideo\" returntype=\"xml\"><arguments><string>" + videoPath + "</string></arguments></invoke>");
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

				//0124		var width = int.Parse(list[0].ChildNodes[0].InnerText);
				//0124		var height = int.Parse(list[0].ChildNodes[1].InnerText);

				//0117			this.ClientSize = new System.Drawing.Size(width, height);
				//0124		SFPlayer.ClientSize = this.SFPlayer.Size;
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
