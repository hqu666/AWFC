using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCF.ViewModels {
	class WebViewModel : INotifyPropertyChanged {
		public string WebUrl { get; set; }
		public WebViewModel()
		{
			SetURl();
		}

		public void SetURl()
		{
			WebUrl = "https://www.yahoo.co.jp/";

		}



        //        /// <summary>
        //        /// System.Windows.Forms.WebBrowser()でWebBrowserを生成する
        //        /// </summary>
        //        private void MakeWebPlayer()
        //        {
        //            string TAG = "[MakeWebPlayer]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                InitPlayerPane("web");

        //                if (this.playerWebBrowser == null)
        //                {
        //                    this.playerWebBrowser = new System.Windows.Forms.WebBrowser();
        //                    this.MediaPlayerPanel.Controls.Add(this.playerWebBrowser);
        //                    //			this.MediaControlPanel.Visible = false;

        //                    this.playerWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
        //                    this.playerWebBrowser.Location = new System.Drawing.Point(0, 0);
        //                    this.playerWebBrowser.Margin = new System.Windows.Forms.Padding(0);
        //                    this.playerWebBrowser.MinimumSize = new System.Drawing.Size(MediaPlayerPanel.Width, MediaPlayerPanel.Height);
        //                    //		this.playerWebBrowser.Name = "playerWebBrowser";
        //                    this.playerWebBrowser.ScrollBarsEnabled = false;
        //                    /*		this.playerWebBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(
        //																(System.Windows.Forms.AnchorStyles.Top |
        //																System.Windows.Forms.AnchorStyles.Left |
        //																System.Windows.Forms.AnchorStyles.Right |
        //																System.Windows.Forms.AnchorStyles.Bottom)));

        //							 MediaPlayerSplitContainer
        //							 */
        //                    //		this.playerWebBrowser.Size = new System.Drawing.Size(829, 627);
        //                    this.playerWebBrowser.TabIndex = 25;
        //                    this.playerWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1_DocumentCompleted);
        //                    this.playerWebBrowser.Resize += new System.EventHandler(this.ReSizeViews);
        //                }

        //                //		MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }

        //        private void MakeWebSouceBody(string fileName, string urlStr)
        //        {
        //            string TAG = "[MakeWebSouceBody]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                dbMsg += ",fileName=" + fileName;
        //                dbMsg += ",url=" + urlStr;
        //                dbMsg += ",this[" + this.Width + "×" + this.Height + "]";       //this[1936×751]
        //                dbMsg += ",ファイルブラウザ[" + FileBrowserSplitContainer.Width + "×" + FileBrowserSplitContainer.Height + "]";     //ファイルブラウザ[586×712],Collapsed=False
        //                dbMsg += ",Collapsed=" + baseSplitContainer.Panel1Collapsed;
        //                /*	if (!baseSplitContainer.Panel1Collapsed) {//ファイルブラウザopen
        //						webWidth -= FileBrowserSplitContainer.Width;
        //						dbMsg += ",ファイルブラウザ>" + webWidth;
        //					}*/
        //                dbMsg += ",プレイリスト[" + PlayListsplitContainer.Width + "×" + PlayListsplitContainer.Height + "]";//,プレイリスト[235×712],
        //                dbMsg += ",Collapsed=" + viewSplitContainer.Panel1Collapsed;
        //                /*	if (!viewSplitContainer.Panel1Collapsed) {
        //					//	webWidth -= PlayListsplitContainer.Width;
        //						dbMsg += ",プレイリスト>" + PlayListsplitContainer.Width;
        //					}*/
        //                dbMsg += ",MediaPlayerPanel[" + this.MediaPlayerPanel.Width + "×" + this.MediaPlayerPanel.Height + "]"; //MediaPlayerPanel[1091×625]
        //                int webWidth = this.MediaPlayerPanel.Width - 18;     //this.Width - 44;   //  playerWebBrowser.Width - 28;
        //                int webHeight = this.MediaPlayerPanel.Height - 72;   // playerWebBrowser.Height - 60;
        //                dbMsg += ",web[" + webWidth + "×" + webHeight + "]";                                                    //web[1057×553]
        //                string[] extStrs = fileName.Split('.');
        //                string extentionStr = "." + extStrs[extStrs.Length - 1].ToLower();

        //                string contlolPart = @"<!DOCTYPE html>
        //<html>
        //	<head>
        //		<meta charset = " + '"' + "UTF-8" + '"' + " >\n";
        //                contlolPart += "\t\t<meta http-equiv = " + '"' + "Pragma" + '"' + " content =  " + '"' + "no-cache" + '"' + " />\n";          //キャッシュを残さない；HTTP1.0プロトコル
        //                contlolPart += "\t\t<meta http-equiv = " + '"' + "Cache-Control" + '"' + " content =  " + '"' + "no-cache" + '"' + " />\n"; //キャッシュを残さない；HTTP1.1プロトコル
        //                contlolPart += "\t\t<meta http-equiv = " + '"' + "X-UA-Compatible" + '"' + " content =  " + '"' + "requiresActiveX =true" + '"' + " />\n";
        //                //	contlolPart += "\n\t\t\t<link rel = " + '"' + "stylesheet" + '"' + " type = " + '"' + "text/css" + '"' + " href = " + '"' + "brows.css" + '"' + "/>\n";
        //                string retType = GetFileTypeStr(fileName);
        //                dbMsg += ",retType=" + retType;
        //                if (retType == "video" ||
        //                     retType == "image" ||
        //                    retType == "audio"
        //                    )
        //                {
        //                }
        //                else
        //                {
        //                    contlolPart += "\t</head>\n";
        //                    contlolPart += "\t<body>\n\t\t";
        //                }
        //                dbMsg += ",fileName=" + fileName;
        //                if (lsFullPathName != fileName)
        //                {       //8/31;仮対応；書き換わり対策
        //                    dbMsg += ",***書き換わり発生***" + fileName;
        //                    fileName = lsFullPathName;
        //                }

        //                if (retType == "video")
        //                {
        //                    contlolPart += MakeVideoSouce(fileName, webWidth, webHeight);
        //                }
        //                else if (retType == "image")
        //                {
        //                    contlolPart += MakeImageSouce(fileName, webWidth, webHeight);
        //                }
        //                else if (retType == "audio")
        //                {
        //                    contlolPart += MakeAudioSouce(fileName, webWidth, webHeight);
        //                }
        //                else if (retType == "text")
        //                {
        //                    contlolPart += MakeTextSouce(fileName, webWidth, webHeight);
        //                }
        //                else if (retType == "application")
        //                {
        //                    contlolPart += MakeApplicationeSouce(fileName, webWidth, webHeight);
        //                }
        //                if (debug_now)
        //                {
        //                    contlolPart += "\t\t<div>,urlStr=" + urlStr;
        //                    contlolPart += "<br>\n\t\t" + ",playerUrl=" + playerUrl + "</div>\n";
        //                }
        //                contlolPart += "\t</body>\n</html>\n\n";
        //                dbMsg += ",contlolPart=" + contlolPart;
        //                if (File.Exists(urlStr))
        //                {
        //                    dbMsg += "既存ファイル有り";
        //                    System.IO.File.Delete(urlStr);                //20170818;ここで停止？
        //                    dbMsg += ">Exists=" + File.Exists(urlStr);
        //                }
        //                ////UTF-8でテキストファイルを作成する
        //                System.IO.StreamWriter sw = new System.IO.StreamWriter(urlStr, false, System.Text.Encoding.UTF8);
        //                sw.Write(contlolPart);
        //                sw.Close();
        //                dbMsg += ">Exists=" + File.Exists(urlStr);
        //                Uri nextUri = new Uri("file://" + urlStr);
        //                dbMsg += ",nextUri=" + nextUri;
        //                try
        //                {
        //                    MakeWebPlayer();
        //                    playerWebBrowser.Navigate(nextUri);
        //                }
        //                catch (System.UriFormatException er)
        //                {
        //                    dbMsg += "<<playerWebBrowser.Navigateでエラー発生>>" + er.Message;
        //                }
        //                //		MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }//形式に合わせたhtml作成

        //        private void MakeWebSouce(string fileName)
        //        {
        //            string TAG = "[MakeWebSouce]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                dbMsg += ",fileName=" + fileName;
        //                FileInfo fi = new FileInfo(fileName);
        //                if (fi.Exists)
        //                {                     //変換するURIがファイルを表していることを確認する☆読み込み時にリロードのループになる
        //                    string[] urlStrs = assemblyPath.Split(Path.DirectorySeparatorChar);
        //                    assemblyName = urlStrs[urlStrs.Length - 1];
        //                    string urlStr = assemblyPath.Replace(assemblyName, "brows.htm");//	urlStr = urlStr.Substring( 0, urlStr.IndexOf( "bin" ) ) + "brows.htm";
        //                    dbMsg += ",url=" + urlStr;
        //                    /*		int webWidth = webBrowser1.Width - 20;
        //							int webHeight = webBrowser1.Height - 40;
        //							dbMsg += ",web[" + webWidth + "×" + webHeight + "]";*/
        //                    string[] extStrs = fileName.Split('.');
        //                    string extentionStr = "." + extStrs[extStrs.Length - 1].ToLower();
        //                    if (extentionStr == ".htm" ||
        //                        extentionStr == ".html")
        //                    {
        //                        string titolStr = "webでHTMLを読み込みますか？";
        //                        string msgStr = "組み込んであるScriptなどで異常終了する場合があります\n" +
        //                            "「はい」　web表示\n" +
        //                            "     　　　※異常終了する場合は読み込みを中断します。" +
        //                            "「いいえ」ソースをテキストで表示\n" +
        //                            "「キャンセル」読込み中止";
        //                        DialogResult result = MessageBox.Show(msgStr, titolStr,
        //                            MessageBoxButtons.YesNoCancel,
        //                            MessageBoxIcon.Asterisk,
        //                            MessageBoxDefaultButton.Button1);                  //メッセージボックスを表示する
        //                        if (result == DialogResult.Yes)
        //                        {
        //                            //「はい」が選択された時
        //                            urlStr = fileName;
        //                            Uri nextUri = new Uri("file://" + urlStr);
        //                            dbMsg += ",nextUri=" + nextUri;
        //                            try
        //                            {
        //                                MakeWebPlayer();
        //                                playerWebBrowser.ScriptErrorsSuppressed = true;      //
        //                                playerWebBrowser.Navigate(nextUri);
        //                            }
        //                            catch (Exception e)
        //                            {
        //                                Console.WriteLine(TAG + "でエラー発生" + e.Message + ";" + dbMsg);
        //                            }
        //                        }
        //                        else if (result == DialogResult.No)
        //                        {
        //                            //「いいえ」が選択された時
        //                            MakeWebSouceBody(fileName, urlStr);
        //                        }
        //                        else if (result == DialogResult.Cancel)
        //                        {
        //                            //「キャンセル」が選択された時
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (lsFullPathName != "" && fileName != "未選択" && lsFullPathName != fileName)
        //                        {       //8/31;仮対応；書き換わり対策
        //                            dbMsg += ",***書き換わり発生*<<" + lsFullPathName + " ; " + fileName + ">>";
        //                            fileName = lsFullPathName;
        //                        }
        //                        MakeWebSouceBody(fileName, urlStr);
        //                    }
        //                }
        //                else
        //                {
        //                    dbMsg += ",***指定されたファイルが無い？？*";
        //                }
        //                //			MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception e)
        //            {
        //                dbMsg += "<<以降でエラー発生>>" + e.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }//形式に合わせたhtml作成
        //         /*		http://html5-css3.jp/tips/youtube-html5video-window.html
        //		  *		http://dobon.net/vb/dotnet/string/getencodingobject.html
        //		  */

        //        #endregion

        //        //Flash/////////////////////////////////////////////////////////////////////////////web//
        //        #region FlashBlock
        //        /// <summary>
        //        /// ふらだんす   https://www.streaming.jp/fladance/
        //        /// error : video_fileが設定されていません。
        //        /// </summary>
        //        /// <param name="fileName"></param>
        //        private void LoadFladance(string fileName)
        //        {
        //            string TAG = "[LoadFladance]" + fileName;
        //            string dbMsg = TAG;
        //            try
        //            {
        //                dbMsg += ",assemblyPath=" + assemblyPath;       // + ",assemblyName=" + assemblyName;
        //                playerUrl = assemblyPath.Replace("AWSFileBroeser.exe", "fladance.swf");       //
        //                dbMsg += ",playerUrl=" + playerUrl;
        //                this.SFPlayer.LoadMovie(0, playerUrl);
        //                Uri urlObj = new Uri(fileName);
        //                if (urlObj.IsFile)
        //                {             //Uriオブジェクトがファイルを表していることを確認する
        //                    fileName = urlObj.AbsoluteUri;                 //Windows形式のパス表現に変換する
        //                    dbMsg += "Path=" + fileName;
        //                }
        //                string[] strs = { "fms_app=&video_file=", @"""", fileName };
        //                string flashVvarsStr = strs[0] + strs[1] + strs[2] + strs[1];          //flvmov= M:\sample\123.flv
        //                //string flashVvarsStr = @"fms_app=&video_file=" + fileName + '"';// + "&autoplay = true";             //&quot;	&#34;	&#x22;	'"' "fms_app=&video_file=\"M:\\sample\\123.flv\""
        //                //string flashVvars = "fms_app=&video_file=" + fileName + "&" + "image_file=&link_url=&autoplay=true&mute=false&controllbar=true&buffertime=10" + '"';
        //                dbMsg += ",flashVvars=" + flashVvarsStr;
        //                this.SFPlayer.FlashVars = flashVvarsStr;
        //                /*
        //                                string clsId = "clsid:d27cdb6e-ae6d-11cf-96b8-444553540000";
        //                                this.SFPlayer.SetVariable("classid", clsId);
        //                                string codeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0";
        //                                this.SFPlayer.SetVariable("codebase", codeBase);
        //                                //<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000"
        //                                //codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0" width="横幅" height="高さ">
        //                                this.SFPlayer.SetVariable("src", fileName);
        //                                this.SFPlayer.SetVariable("video_file", fileName);

        //                                string mineTypeStr = "application/x-shockwave-flash";       //video/x-flv ?  application/x-shockwave-flash  ?   mineType.Text;
        //                                System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
        //                                if (fi.Extension.Equals(".f4v"))
        //                                {
        //                                    mineTypeStr = "video/mp4";       // mineType.Text;
        //                                }
        //                                dbMsg += ",mineTypeStr=" + mineTypeStr;
        //                                string pluginspage = "http://www.macromedia.com/go/getflashplayer";
        //                                //contlolPart += "<param name= " + '"' + "allowFullScreen" + '"' + " value=" + '"' + "true" + '"' + "/>";
        //                                //                    this.SFPlayer.Movie = fileName;    //contlolPart += "<param name =" + '"' + "movie" + '"' + " value=" + '"' + fileName + '"' + "/>";
        //                                //   string EmbedStr =  "fms_app=" + '"' + playerUrl + '"' +           //ストリーミング再生の場合のみ設定可能
        //                                //  string EmbedStr = '"' + wiPlayerID + '"' + " src=" + '"' + playerUrl + '"' +

        //                                string EmbedStr = " video_file=" + '"' + fileName + '"' +
        //                                                                " width=" + '"' + this.MediaPlayerPanel.Width + '"' + " height= " + '"' + this.MediaPlayerPanel.Height + '"' +            // '"' + webWidth + '"'
        //                                                                " type=" + '"' + mineTypeStr + '"' +
        //                                                                " allowfullscreen=" + '"' + " true= " + '"' +
        //                                                                " flashvars=" + '"' + flashVvars + '"' +
        //                                                                " type=" + '"' + "application/x-shockwave-flash" + '"' +
        //                                                                " pluginspage=" + '"' + pluginspage + '"' +
        //                                                                //                " autoplay=" + true +
        //                                                                "/>";

        //                                //     this.SFPlayer.EmbedMovie = true;
        //                                //           this.SFPlayer. = true;
        //                                this.SFPlayer.SetVariable("src", playerUrl);
        //                                this.SFPlayer.SetVariable("type", mineTypeStr);
        //                                this.SFPlayer.SetVariable("flashvars", flashVvars);
        //                                //this.SFPlayer.SetVariable("type", "application/x-shockwave-flash");
        //                                //this.SFPlayer.SetVariable("pluginspage", pluginspage);
        //                                //      LoadFLV(fileName);
        //                                //         this.SFPlayer.Validating = fileName;
        //                                //        this.SFPlayer.Visible = true;ではtrueにならない
        //                                //<param name = "flashvars" value = "fms_app=FMSアプリケーションディレクトリのパス&video_file=動画ファイルのパス
        //                                //                                    &image_file=サムネイル画像のパス&link_url=リンク先のURL&autoplay=オートプレイのON・OFF
        //                                //                                    &mute=ミュートのON・OFF&volume=音量&controller=操作パネルの表示・非表示&buffertime=バッファ時間" />
        //                                //<param name="allowFullScreen" value="フルスクリーン化を可能にするかどうか" />
        //                                //<param name="movie" value="ふらだんすswfファイルのパス" />

        //                                //<embed src="ふらだんすswfファイルのパス" width="横幅" height="高さ" allowFullScreen="フルスクリーン化を可能にするかどうか" flashvars="fms_app=FMSアプリケーションディレクトリのパス&video_file=動画ファイルのパス&image_file=サムネイル画像のパス&link_url=リンク先のURL&autoplay=オートプレイのON・OFF&mute=ミュートのON・OFF&volume=音量&controller=操作パネルの表示・非表示&buffertime=バッファ時間" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" /></object>
        //                                this.SFPlayer.MovieData = fileName;
        //                                */
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                this.mediaPlayer = null;
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }

        //        /// <summary>
        //        /// Adobe Flash Player https://www.mi-j.com/service/FLASH/player/index.html　
        //        /// </summary>
        //        /// <param name="fileName"></param>
        //        private void LoadFlvplayer(string fileName)
        //        {
        //            string TAG = "[LoadFlvplayer]" + fileName;
        //            string dbMsg = TAG;
        //            try
        //            {
        //                dbMsg += ",assemblyPath=" + assemblyPath;       // + ",assemblyName=" + assemblyName;
        //                playerUrl = assemblyPath.Replace("AWSFileBroeser.exe", "flvplayer-305.swf");
        //                dbMsg += ",playerUrl=" + playerUrl;
        //                this.SFPlayer.LoadMovie(0, playerUrl);        //axShockwaveFlash1.LoadMovie(0, Application.StartupPath + "\\test.swf");
        //                                                              //       this.SFPlayer.LoadMovie(0, fileName); //でthis.SFPlayer.Movieにセットされるが再生はされない
        //                Uri urlObj = new Uri(fileName);
        //                string flashVvarsStr = "flvmov= " + urlObj.ToString();          //"flvmov= M:\\sample\\123.flv"	
        //                //string flashVvarsStr = "flvmov= " + fileName;          //"flvmov= M:\\sample\\123.flv"	
        //                //  string flashVvarsStr = "flvmov= \"" + fileName;          //		"flvmov= \"M:\\sample\\123.flv"	
        //                //string flashVvarsStr = "flvmov= \x22" + fileName + "\x22";          //"flvmov= \"M:\\sample\\123.flv\""
        //                //      string[] strs = { @"flvmov= ", @"", fileName ,@""};
        //                //string flashVvarsStr = strs[0] + strs[1] + strs[2] + strs[3];          //flvmov= M:\sample\123.flv
        //                //        string flashVvarsStr = "flvmov=" + fileName + '"'; //FlashVars=flvmov=M:\sample\123.flv
        //                //           string flashVvarsStr = @"flvmov=" + fileName + @""; //FlashVars=flvmov=M:\sample\123.flv
        //                dbMsg += ",flashVvarsStr=" + flashVvarsStr;
        //                this.SFPlayer.FlashVars = flashVvarsStr;  //  file://M://sample/123.flv        + '"'    \x22
        //                                                          //    axShockwaveFlash1.CallFunction("<invoke name=\"loadAndPlayVideo\" returntype=\"xml\"><arguments><string>" + videoPath + "</string></arguments></invoke>");

        //                //string clsId = "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000";
        //                //this.SFPlayer.SetVariable("classid", clsId);
        //                //string codeBase = "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,115,0";
        //                //this.SFPlayer.SetVariable("codebase", codeBase);
        //                //   this.SFPlayer.SetVariable("src", fileName);
        //                //this.SFPlayer.SetVariable("video_file", fileName);
        //                //string mineTypeStr = "application/x-shockwave-flash";       //video/x-flv ?  application/x-shockwave-flash  ?   mineType.Text;
        //                //System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
        //                //if (fi.Extension.Equals(".f4v"))
        //                //{
        //                //    mineTypeStr = "video/mp4";       // mineType.Text;
        //                //}
        //                //dbMsg += ",mineTypeStr=" + mineTypeStr;
        //                //string pluginspage = "http://www.macromedia.com/go/getflashplayer";
        //                string ObjectStr = "<object width=" + '"' + this.MediaPlayerPanel.Width + '"' + " height= " + '"' + this.MediaPlayerPanel.Height + '"' +
        //                                         " classid=" + '"' + "clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" + '"' +
        //                                         " codebase=" + '"' + "http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,115," + '"' + " />";
        //                this.SFPlayer.SetVariable("object", ObjectStr);
        //                string Param1Str = "<param  name=" + '"' + "movie" + '"' + " value= " + '"' + playerUrl + '"' + " />";//    this.SFPlayer.SetVariable("param", Param1Str);
        //                string Param2Str = "< param name =" + '"' + "allowFullScreen" + '"' + " value= " + '"' + "true" + '"' + " />";//  this.SFPlayer.SetVariable("param", Param2Str);
        //                string Param3Str = "<param  name=" + '"' + "FlashVars" + '"' + " value= " + '"' + "flvmov=" + fileName + '"' + " />";//  this.SFPlayer.SetVariable("param", Param2Str);

        //                string EmbedStr = "<embed width=" + '"' + this.MediaPlayerPanel.Width + '"' + " height= " + '"' + this.MediaPlayerPanel.Height + '"' +
        //                                   " src=" + '"' + playerUrl + '"' +
        //                                  " flashvars=" + '"' + "flvmov=" + fileName + '"' + " allowFullScreen = " + '"' + "true" + '"' + " />";
        //                ObjectStr += Param1Str + Param2Str + Param3Str + EmbedStr;
        //                //this.SFPlayer.CallFunction(ObjectStr);
        //                //  this.SFPlayer.  //   this.SFPlayer.SetVariable("MovieData", fileName);   this.SFPlayer.MovieData = fileName;
        //                //dbMsg += ",AccessibleDefaultActionDescription=" + this.SFPlayer.AccessibleDefaultActionDescription;
        //                //dbMsg += ",AccessibleDescription=" + this.SFPlayer.AccessibleDescription;
        //                //dbMsg += ",AccessibleName=" + this.SFPlayer.AccessibleName;
        //                //dbMsg += ",AccessibleRole=" + this.SFPlayer.AccessibleRole;
        //                //dbMsg += ",Controls=" + this.SFPlayer.Controls;
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                this.mediaPlayer = null;
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }

        //        /// <summary>
        //        /// 参照　http://rexef.com/webtool/flaver3/sample.html
        //        /// </summary>
        //        /// <param name="fileName"></param>
        //        private void LoadFlaever(string fileName)
        //        {
        //            string TAG = "[LoadFlaever]" + fileName;
        //            string dbMsg = TAG;
        //            try
        //            {
        //                dbMsg += ",assemblyPath=" + assemblyPath;       // + ",assemblyName=" + assemblyName;
        //                playerUrl = assemblyPath.Replace("AWSFileBroeser.exe", "flaver.swf");
        //                dbMsg += ",playerUrl=" + playerUrl;
        //                this.SFPlayer.LoadMovie(0, playerUrl);
        //                string flashVvarsStr = "file= " + fileName;          //  file://M://sample/123.flv        + '"'    \x22
        //                dbMsg += ",flashVvarsStr=" + flashVvarsStr;
        //                this.SFPlayer.FlashVars = flashVvarsStr;
        //                string ObjectStr = "<object data=" + '"' + playerUrl + '"' +
        //                                    " type = " + '"' + "application/x-shockwave-flash" + '"' +
        //                                    " width =" + '"' + this.MediaPlayerPanel.Width + '"' + " height= " + '"' + this.MediaPlayerPanel.Height + '"' + " />";
        //                //    this.SFPlayer.SetVariable("object", ObjectStr);
        //                string Param1Str = "<param  name=" + '"' + "movie" + '"' + " value= " + '"' + playerUrl + '"' + " />";//    this.SFPlayer.SetVariable("param", Param1Str);
        //                string Param2Str = "<param  name=" + '"' + "FlashVars" + '"' + " value= " + '"' + "file=" + '"' + fileName + '"' + " />";//  this.SFPlayer.SetVariable("param", Param2Str);
        //                string Param3Str = "< param name =" + '"' + "allowFullScreen" + '"' + " value= " + '"' + "always" + '"' + " /></object>";//  this.SFPlayer.SetVariable("param", Param3Str);

        //                ////this.SFPlayer.CallFunction(ObjectStr);
        //                ////  this.SFPlayer.  //   this.SFPlayer.SetVariable("MovieData", fileName);   this.SFPlayer.MovieData = fileName;
        //                ////dbMsg += ",AccessibleDefaultActionDescription=" + this.SFPlayer.AccessibleDefaultActionDescription;
        //                ////dbMsg += ",AccessibleDescription=" + this.SFPlayer.AccessibleDescription;
        //                ////dbMsg += ",AccessibleName=" + this.SFPlayer.AccessibleName;
        //                ////dbMsg += ",AccessibleRole=" + this.SFPlayer.AccessibleRole;
        //                ////dbMsg += ",Controls=" + this.SFPlayer.Controls;
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                this.mediaPlayer = null;
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }


        //        /*
        //         FLV・SWFファイルの再生 http://www.geocities.co.jp/NatureLand/2023/reference/Multimedia/movie02.html
        //         Flash 4 で新しくサポートされたスクリプトメソッド       http://kb2.adobe.com/jp/cps/228/228681.html
        //         */
        //        /// <summary>
        //        /// Flashのmoveプレイヤーで渡されたファイルを再生
        //        /// 
        //        /// error : video_fileが設定されていません。
        //        /// </summary>
        //        /// <param name="fileName">再生ファイル名</param>
        //        private void MakeFlash(string fileName)
        //        {
        //            string TAG = "[MakeFlash]" + fileName;
        //            string dbMsg = TAG;
        //            try
        //            {
        //                this.MediaPlayerPanel.Controls.RemoveAt(0);
        //                this.SFPlayer = null;
        //                this.playerWebBrowser = null;
        //                this.mediaPlayer = null;
        //                InitializeFLComponent();
        //                try
        //                {
        //                    System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
        //                    if (fi.Extension.Equals(".flv") || fi.Extension.Equals(".f4v"))
        //                    {
        //                        LoadFladance(fileName);
        //                        //             LoadFlvplayer( fileName);
        //                        //        LoadFlaever(fileName);
        //                    }
        //                    else if (fi.Extension.Equals(".swf"))
        //                    {
        //                        this.SFPlayer.LoadMovie(0, fileName); //でthis.SFPlayer.Movieにセットされるが再生はされない
        //                                                              //   Movie   "M:\\sample\\EmbedFlash.swf" 
        //                    }
        //                    dbMsg += ",Movie=" + this.SFPlayer.Movie;
        //                    dbMsg += ",MovieData=" + this.SFPlayer.MovieData;
        //                    dbMsg += ",FlashVars=" + this.SFPlayer.FlashVars;
        //                    this.SFPlayer.FlashCall += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FlashCallEventHandler(this.SFPlayer_FlashCall);
        //                    //          ((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).EndInit();                   //必須
        //                    this.SFPlayer.Play();
        //                }
        //                catch
        //                {
        //                    MessageBox.Show("Flashがインストールされていないようです");
        //                }


        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                this.mediaPlayer = null;
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }
        //        //C#でFLVファイルをお手軽再生   http://zecl.hatenablog.com/entry/20081119/p1///////////////////////////////
        //        private void SFPlayer_FlashCall(object sender, _IShockwaveFlashEvents_FlashCallEvent e)
        //        {
        //            string TAG = "[SFPlayer_FlashCall]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                var document = new XmlDocument();
        //                document.LoadXml(e.request);

        //                XmlNodeList list = document.GetElementsByTagName("arguments");
        //                //ResizePlayer(Convert.ToInt32(list[0].FirstChild.InnerText), Convert.ToInt32(list[0].ChildNodes[1].InnerText));

        //                var width = int.Parse(list[0].ChildNodes[0].InnerText);
        //                var height = int.Parse(list[0].ChildNodes[1].InnerText);

        //                this.ClientSize = new System.Drawing.Size(width, height);
        //                this.SFPlayer.ClientSize = this.SFPlayer.Size;
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }

        //        ///// <summary>
        //        ///// DragDrop
        //        ///// </summary>
        //        ///// <param name="sender"></param>
        //        ///// <param name="e"></param>
        //        //private void Form1_DragDrop(object sender, DragEventArgs e)
        //        //{
        //        //    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        //        //    LoadFLV(files[0]);
        //        //}

        //        ///// <summary>
        //        ///// DragEnter
        //        ///// </summary>
        //        ///// <param name="sender"></param>
        //        ///// <param name="e"></param>
        //        //private void Form1_DragEnter(object sender, DragEventArgs e)
        //        //{
        //        //    if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
        //        //    {
        //        //        e.Effect = DragDropEffects.All;
        //        //    }
        //        //}
        //        private void InitializeFLComponent()
        //        {
        //            string TAG = "[InitializeFLComponent]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));   //?
        //                this.SFPlayer = new AxShockwaveFlashObjects.AxShockwaveFlash();
        //                ((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).BeginInit();      //必須;http://bbs.wankuma.com/index.cgi?mode=al2&namber=9784&KLOG=22
        //                this.SuspendLayout();           //必要？
        //                this.SFPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
        //                this.SFPlayer.Enabled = true;
        //                this.SFPlayer.Location = new System.Drawing.Point(0, 0);
        //                this.SFPlayer.Name = "SFPlayer";
        //                this.SFPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("this.SFPlayer.OcxState")));
        //                this.SFPlayer.Size = new System.Drawing.Size(this.MediaPlayerPanel.Width, this.MediaPlayerPanel.Height);
        //                this.SFPlayer.TabIndex = 0;

        //                // 
        //                // Form1
        //                // 
        //                //      this.AllowDrop = true;
        //                //       this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        //                //       this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //                this.MediaPlayerPanel.Controls.Add(this.SFPlayer);
        //                // 
        //                // Form1続き
        //                // 
        //                ////this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
        //                ////this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
        //                this.SFPlayer.FSCommand += new AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEventHandler(this.SFPlayer_FSCommand);
        //                this.SFPlayer.RegionChanged += new System.EventHandler(this.SFPlayer_RegionChanged);
        //                this.SFPlayer.Move += new System.EventHandler(this.SFPlayer_Move);
        //                ((System.ComponentModel.ISupportInitialize)(this.SFPlayer)).EndInit();                   //必須
        //                this.ResumeLayout(false);

        //                InitAxShockwaveFlash();
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }

        //        }

        //        /// <summary>
        //        /// AxShockwaveFlashの設定
        //        /// </summary>
        //        private void InitAxShockwaveFlash()
        //        {
        //            string TAG = "[InitAxShockwaveFlash]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                this.SFPlayer.AllowFullScreen = "false";
        //                this.SFPlayer.BGColor = "000000";
        //                this.SFPlayer.AllowNetworking = "all";

        //                this.SFPlayer.CtlScale = "NoScale";
        //                //this.SFPlayer.CtlScale = "NoBorder ";
        //                //this.SFPlayer.CtlScale = "ExactFit";
        //                //this.SFPlayer.CtlScale = "ShowAll";

        //                this.SFPlayer.DeviceFont = false;
        //                this.SFPlayer.EmbedMovie = true;

        //                this.SFPlayer.FrameNum = -1;
        //                this.SFPlayer.Loop = true;
        //                this.SFPlayer.Playing = true;
        //                this.SFPlayer.Profile = true;
        //                this.SFPlayer.Quality2 = "High";
        //                this.SFPlayer.SAlign = "LT";
        //                this.SFPlayer.WMode = "Window";
        //                this.SFPlayer.Dock = DockStyle.Fill;
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }

        //        /// <summary>
        //        /// FLVファイルのロード
        //        /// </summary>
        //        /// <param name="videoPath"></param>
        //        private void LoadFLV(string fileName)
        //        {
        //            string TAG = "[LoadFLV]" + fileName;
        //            string dbMsg = TAG;
        //            try
        //            {
        //                string mineTypeStr = mineType.Text;
        //                dbMsg += ",mineTypeStr=" + mineTypeStr;
        //                string pluginspage = "http://www.macromedia.com/go/getflashplayer";
        //                string flashVvars = "fms_app=&video_file=" + fileName + "&" +       // & amp;
        //                                                                                    //								"link_url ="+ nextMove + "&" +
        //                         "image_file=&link_url=&autoplay=true&mute=false&controllbar=true&buffertime=10" + '"';
        //                string contlolPart = "";
        //                //contlolPart += "\t</head>\n";
        //                //contlolPart += "\t<body style = " + '"' + "background-color: #000000;color:#ffffff;" + '"' + " >\n\t\t";
        //                //contlolPart += "<object id=" + '"' + wiPlayerID + '"' +
        //                //                    " classid=" + '"' + clsId + '"' +
        //                //                " codebase=" + '"' + codeBase + '"' +
        //                //                " width=" + '"' + webWidth + '"' + " height=" + '"' + webHeight + '"' +
        //                //                 ">\n";
        //                contlolPart += "<param name=" + '"' + "FlashVars" + '"' + " value=" + '"' + flashVvars + '"' + "/>";                        //常にバーを表示する
        //                contlolPart += "<param name= " + '"' + "allowFullScreen" + '"' + " value=" + '"' + "true" + '"' + "/>";
        //                contlolPart += "<param name =" + '"' + "movie" + '"' + " value=" + '"' + fileName + '"' + "/>";
        //                contlolPart += "<embed name=" + '"' + wiPlayerID + '"' +
        //                                                " src=" + '"' + fileName + '"' +
        //                                                " width=" + '"' + this.MediaPlayerPanel.Width + '"' + " height= " + '"' + this.MediaPlayerPanel.Height + '"' +            // '"' + webWidth + '"'
        //                                                " type=" + '"' + mineTypeStr + '"' +
        //                                                " allowfullscreen=" + '"' + " true= " + '"' +
        //                                                " flashvars=" + '"' + flashVvars + '"' +
        //                                                " type=" + '"' + "application/x-shockwave-flash" + '"' +
        //                                                " pluginspage=" + '"' + pluginspage + '"' + "/>";
        //                dbMsg += ",contlolPart=" + contlolPart;
        //                this.SFPlayer.CallFunction(contlolPart);
        //                //SFPlayerのプロパティ		MovieData	""	string
        //                //         this.SFPlayer.CallFunction("<invoke name=\"loadAndPlayVideo\" returntype=\"xml\"><arguments><string>" + fileName + "</string></arguments></invoke>");
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }

        //        }

        //        //#region Dispose
        //        ///// <summary>
        //        ///// 使用中のリソースをすべてクリーンアップします。
        //        ///// </summary>
        //        ///// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        //        //protected override void Dispose(bool disposing)
        //        //{
        //        //    if (disposing && (components != null))
        //        //    {
        //        //        components.Dispose();
        //        //    }
        //        //    base.Dispose(disposing);
        //        //}
        //        //#endregion

        //        /// 
        //        /// 

        //        private void SFPlayer_FSCommand(object sender, AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent e)
        //        {
        //            string TAG = "[SFPlayer_FSCommand]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                dbMsg += e.command + ";";
        //                //switch (e.command)
        //                //{
        //                //    case 0:
        //                //        dbMsg += "1";
        //                //        //            PlayTitolLabel.Text = ("Undefined;WindowsMediaPlayerの状態が定義されていません");
        //                //        break;
        //                //}
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                this.mediaPlayer = null;
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }

        //        private void SFPlayer_Move(object sender, EventArgs e)
        //        {
        //            string TAG = "[SFPlayer_Move]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                dbMsg += e.ToString() + ";";
        //                //switch (e.command)
        //                //{
        //                //    case 0:
        //                //        dbMsg += "1";
        //                //        //            PlayTitolLabel.Text = ("Undefined;WindowsMediaPlayerの状態が定義されていません");
        //                //        break;
        //                //}
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                this.mediaPlayer = null;
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }

        //        private void SFPlayer_RegionChanged(object sender, EventArgs e)
        //        {
        //            string TAG = "[SFPlayer_RegionChanged]";
        //            string dbMsg = TAG;
        //            try
        //            {
        //                dbMsg += e.ToString() + ";";
        //                //switch (e.command)
        //                //{
        //                //    case 0:
        //                //        dbMsg += "1";
        //                //        //            PlayTitolLabel.Text = ("Undefined;WindowsMediaPlayerの状態が定義されていません");
        //                //        break;
        //                //}
        //                MyLog(TAG, dbMsg);
        //            }
        //            catch (Exception er)
        //            {
        //                this.mediaPlayer = null;
        //                dbMsg += "<<以降でエラー発生>>" + er.Message;
        //                MyLog(TAG, dbMsg);
        //            }
        //        }
        //        #endregion



        public event PropertyChangedEventHandler PropertyChanged;
	}
}
