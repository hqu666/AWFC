using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using AWCF.Models;
using AWCF.ViewModels;

namespace AWCF.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
		MainViewModel VM;

		public MainWindow()
        {
            InitializeComponent();
			VM = new MainViewModel();
			this.DataContext = VM;

	//		VM.PLList = new ObservableCollection<PlayListModel>();

		}


		private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            //	CoreWebView2 がnull
            //if (webView != null && webView.CoreWebView2 != null) {
            //	webView.CoreWebView2.Navigate(addressBar.Text);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //WebWindow webWindow = new WebWindow();
            //webWindow.Show();
        }

		private void Window_Closed(object sender, EventArgs e) {
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			VM.BeforeClose();
		}

		//Drag: https://hilapon.hatenadiary.org/entry/20110209/1297247754 ///////////////////////////////////////////////////////////////////////
		private bool _isDragging;
		private bool _isEditing;
		private ObservableCollection<PlayListModel> _shareTable;
		/// <summary>
		/// DraggedItem Dependency Property
		/// </summary>
		public static readonly DependencyProperty DraggedItemProperty =
				DependencyProperty.Register("DraggedItem", typeof(PlayListModel), typeof(MainWindow));

		/// <summary>
		/// Gets or sets the DraggedItem property. This dependency property indicates ....
		/// </summary>
		public PlayListModel DraggedItem {
			get { return (PlayListModel)GetValue(DraggedItemProperty); }
			set { SetValue(DraggedItemProperty, value); }
		}

		/// <summary>
		/// State flag which indicates whether the grid is in edit
		/// mode or not.
		/// </summary>
		public void OnBeginEdit(object sender, DataGridBeginningEditEventArgs e) {
			string TAG = "[OnBeginEdit]";
			string dbMsg = "";
			try {
				_isEditing = true;
				if (_isDragging) ResetDragDrop();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		public void OnEndEdit(object sender, DataGridCellEditEndingEventArgs e) {
			string TAG = "[OnEndEdit]";
			string dbMsg = "";
			try {
				_isEditing = false;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// Initiates a drag action if the grid is not in edit mode.
		/// </summary>
		private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
			string TAG = "[OnMouseLeftButtonDown]";
			string dbMsg = "";
			try {
				DataGrid droplist = (DataGrid)sender;
				dbMsg += ",AllowDrop=" + droplist.AllowDrop;
				dbMsg += "[" + droplist.SelectedIndex + "]";
				PlayListModel selectedItem = (PlayListModel)droplist.SelectedItem;
				dbMsg += ",Summary=" + selectedItem.Summary;
				dbMsg += ",UrlStr=" + selectedItem.UrlStr;
				//if (_isEditing) return;

				//				var row = UIHelpers.TryFindFromPoint<DataGridRow>((UIElement)sender, e.GetPosition(shareGrid));
			//	if (row == null || row.IsEditing) return;

				//set flag that indicates we're capturing mouse movements
				_isDragging = true;
				DraggedItem = (PlayListModel)droplist.SelectedItem;
				//				DraggedItem = (PlayListModel)row.Item;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// Completes a drag/drop operation.
		/// </summary>
		private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
			string TAG = "[OnMouseLeftButtonUp]";
			string dbMsg = "";
			try {
				DataGrid droplist = (DataGrid)sender;
				dbMsg += ",AllowDrop=" + droplist.AllowDrop;
				dbMsg += "[" + droplist.SelectedIndex + "]";
				PlayListModel selectedItem = (PlayListModel)droplist.SelectedItem;
				dbMsg += ",Summary=" + selectedItem.Summary;
				dbMsg += ",UrlStr=" + selectedItem.UrlStr;
				if (!_isDragging || _isEditing) {
					return;
				}

				//get the target item
				PlayListModel targetItem = (PlayListModel)droplist.SelectedItem;

				if (targetItem == null || !ReferenceEquals(DraggedItem, targetItem)) {

					//// create tempporary row
					//var temp = DraggedItem.Row.Table.NewRow();
					//temp.ItemArray = DraggedItem.Row.ItemArray;
					//int tempIndex = _shareTable.Rows.IndexOf(DraggedItem.Row);

					////remove the source from the list
					//_shareTable.Rows.Remove(DraggedItem.Row);

					////get target index
					//var targetIndex = _shareTable.Rows.IndexOf(targetItem.Row);

					////insert temporary at the target's location
					//_shareTable.Rows.InsertAt(temp, targetIndex);

					////select the dropped item
					//shareGrid.SelectedItem = shareGrid.Items[targetIndex];
				}

				//reset
				ResetDragDrop();
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// Updates the popup's position in case of a drag/drop operation.
		/// </summary>
		private void OnMouseMove(object sender, MouseEventArgs e) {
			string TAG = "[OnMouseMove]";
			string dbMsg = "";
			try {
				DataGrid droplist = (DataGrid)sender;
				dbMsg += ",AllowDrop=" + droplist.AllowDrop;
				dbMsg += "[" + droplist.SelectedIndex + "]";
				PlayListModel selectedItem = (PlayListModel)droplist.SelectedItem;
				dbMsg += ",Summary=" + selectedItem.Summary;
				dbMsg += ",UrlStr=" + selectedItem.UrlStr;
				if (!_isDragging || e.LeftButton != MouseButtonState.Pressed) return;

				//display the popup if it hasn't been opened yet
				if (!popup1.IsOpen) {
					//switch to read-only mode
				//	PlayList.IsReadOnly = true;

					//make sure the popup is visible
					popup1.IsOpen = true;
				}

				Size popupSize = new Size(popup1.ActualWidth, popup1.ActualHeight);
				popup1.PlacementRectangle = new Rect(e.GetPosition(this), popupSize);

				//make sure the row under the grid is being selected
				Point position = e.GetPosition(PlayList);
			//	var row = UIHelpers.TryFindFromPoint<DataGridRow>(PlayList, position);
			//	if (row != null) PlayList.SelectedItem = droplist.SelectedItem;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// Closes the popup and resets the
		/// grid to read-enabled mode.
		/// </summary>
		private void ResetDragDrop() {
			string TAG = "[ResetDragDrop]";
			string dbMsg = "";
			try {
				_isDragging = false;
				popup1.IsOpen = false;
		//		PlayList.IsReadOnly = false;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}
		///////////////////////////////////////////////////////Drag: https://hilapon.hatenadiary.org/entry/20110209/1297247754 //////////////////

		/// <summary>
		/// ドラッグオブジェクトがコントロールの境界内にドラッグされると発生
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayList_DragEnter(object sender, DragEventArgs e) {
			string TAG = "[PlayListBox_DragEnter]";
			string dbMsg = "";
			try {
				//dbMsg += "(" + e.X + "," + e.Y + ")";
				//dbMsg += "dragFrom=" + dragFrom;
				//dbMsg += ",dragSouceUrl=" + dragSouceUrl;
				//dbMsg += "(前;" + b_dragSouceUrl + ")";
				//if (dragFrom == playListBox.Name) {
				//	dbMsg += ";playList内;";
				//	ListBox list = (ListBox)sender;                                 //playListが参照される
				//	PlaylistDragEnterNo = list.SelectedIndex;
				//	dbMsg += "(DragEnter;" + PlaylistDragEnterNo + ")";
				//	(DragEnter; 0)M:\\sample\123.flvfile:\\\M:\\sample\123.flvfile:\\\M:\\sample\media.flv

				//				string listSelectValue = list.SelectedValue.ToString();
				//	dbMsg += listSelectValue;
				//	DDEfect = DragDropEffects.Move;//ドラッグ＆ドロップの効果を、Moveに設定
				//								   /*		} else if (dragFrom == FilelistView.Name) {
				//											   dbMsg += ";playListBoxkから;";
				//											   DDEfect = DragDropEffects.Copy;*/
				//								   //		playListBox.DoDragDrop(dragSouceUrl, DragDropEffects.Copy);
				//} else if (dragFrom == fileTree.Name ||
				//		dragFrom == FilelistView.Name
				//		) {
				//	dbMsg += ";fileTreeから;";
				//	DDEfect = DragDropEffects.Copy;
				//} else {                                //エクスプローラー？ if(dragSouceUrl!= b_dragSouceUrl || b_dragSouceUrl =="")
				//	if (DragURLs.Count < 1) {
				//		DragURLs = new List<string>();
				//		foreach (string item in (string[])e.Data.GetData(DataFormats.FileDrop)) {       //エクスプローラーから	http://www.itlab51.com/?p=2904	
				//			dbMsg += ",=" + item.ToString();
				//			DragURLs.Add(item.ToString());
				//		}
				//		dbMsg += ",=" + DragURLs.Count + "件";
				//		dragFrom = "other";
				//		dragSouceUrl = DragURLs[0];
				//		//		b_dragSouceUrl = "";
				//		DDEfect = DragDropEffects.Copy;
				//	}
				//}
				//e.Effect = DDEfect;             //		e.Effect = DragDropEffects.All;     //http://www.itlab51.com/?p=2904
				//dbMsg += ",DDEfect=" + e.Effect;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// DragLeave	オブジェクトがコントロールの境界外にドラッグされたときに発生
		/// //		https://dobon.net/vb/dotnet/control/draganddrop.html
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayList_DragLeave(object sender, DragEventArgs e) {
			string TAG = "[PlayList_DragLeave]";// + fileName;
			string dbMsg = "";
			try {

				//dbMsg += "dragFrom=" + dragFrom;
				//dbMsg += ",dragSouceUrl=" + dragSouceUrl;
				//dbMsg += ",DDEfect=" + DDEfect;
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}

		}

		/// <summary>
		/// オブジェクトがコントロールの境界を越えてドラッグされると発生
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayList_DragOver(object sender, DragEventArgs e) {
			string TAG = "[PlayListBox_DragOver]";// + fileName;
			string dbMsg = "";
			try {
				//		https://dobon.net/vb/dotnet/control/draganddrop.html
				//dbMsg += "dragFrom=" + dragFrom;
				//dbMsg += ",dragSouceUrl=" + dragSouceUrl;
				//dbMsg += ",DDEfect=" + DDEfect;
				////		Object senderObject = sender;                                 //playListが参照される
				////		+Items   { System.Windows.Forms.ListBox.ObjectCollection}		System.Windows.Forms.ListBox.ObjectCollection
				//if (dragFrom == playListBox.Name) {
				//	if (e.Data.GetDataPresent(typeof(string))) {                //ドラッグされているデータがstring型か調べる
				//		if ((e.KeyState & 8) == 8 && (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy) {                //Ctrlキーが押されていればCopy//"8"はCtrlキーを表す
				//			e.Effect = DragDropEffects.Copy;
				//		} else if ((e.KeyState & 32) == 32 && (e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) {   //Altキーが押されていればLink//"32"はAltキーを表す
				//			e.Effect = DragDropEffects.Link;
				//		} else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move) {                              //何も押されていなければMove
				//			e.Effect = DragDropEffects.Move;
				//		} else {
				//			//			e.Effect = DragDropEffects.None;
				//		}
				//	} else {
				//		//		e.Effect = DragDropEffects.None;                    //string型でなければ受け入れない
				//	}
				//} else {
				//	e.Effect = DragDropEffects.All;
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}


		//        /// <summary>
		//        /// ドラッグ アンド ドロップ操作が完了したときに発生
		//        /// </summary>
		//        /// <param name="sender"></param>
		//        /// <param name="e"></param>
		//        private void PlayListBox_DragDrop(object sender, DragEventArgs e)
		//        {
		//            string TAG = "[PlayListBox_DragDrop]";
		//            string dbMsg = TAG;
		//            try
		//            {
		//                dbMsg += "dragFrom=" + dragFrom;
		//                dbMsg += ",dragSouceUrl=" + dragSouceUrl;
		//                dbMsg += ",DDEfect=" + DDEfect;

		//                /*
		//								if (DragURLs.Count < 1) {
		//									DragURLs = new List<string>();
		//									foreach (string item in (string[])e.Data.GetData(DataFormats.FileDrop)) {
		//										dbMsg += ",=" + item.ToString();
		//										DragURLs.Add(item.ToString());
		//									}
		//									dbMsg += ",=" + DragURLs.Count + "件";
		//									dragFrom = "other";
		//									dragSouceUrl = DragURLs[0];
		//									DDEfect = DragDropEffects.Copy;
		//								}
		//								*/
		//                if (dragFrom != "" && dragSouceUrl != "")
		//                {                                               //
		//                    Point dropPoint = Control.MousePosition;                            //dropPoint取得☆最優先にしないと取れなくなる
		//                    dropPoint = playListBox.PointToClient(dropPoint);                   //ドロップ時のマウスの位置をクライアント座標に変換
		//                    dbMsg += "(dropPoint;" + dropPoint.X + "," + dropPoint.Y + ")";
		//                    int dropPointIndex = playListBox.IndexFromPoint(dropPoint);         //マウス下のＬＢのインデックスを得る
		//                    dbMsg += "(dropPointIndex;" + dropPointIndex + "/" + playListBox.Items.Count + ")";//

		//                    ListBox droplist = (ListBox)sender;
		//                    string dropSouceUrl = "";
		//                    if (-1 < dropPointIndex)
		//                    {
		//                        dropSouceUrl = playListBox.Items[dropPointIndex].ToString();             //☆ (ListBox)senderで拾えない
		//                    }
		//                    else if (0 < playListBox.Items.Count)
		//                    {
		//                        dropSouceUrl = playListBox.Items[playListBox.Items.Count - 1].ToString();             //☆ (ListBox)senderで拾えない
		//                        dropPointIndex = playListBox.Items.Count;
		//                        dbMsg += ">>(dropPointIndex;" + dropPointIndex + ")";//
		//                    }
		//                    else
		//                    {
		//                        dropPointIndex = 0;
		//                    }
		//                    dbMsg += ",dropSouceUrl=" + dropSouceUrl;
		//                    string playList = PlaylistComboBox.Text;
		//                    dbMsg += ",playList=" + playList;
		//                    if (e.Data.GetDataPresent(typeof(string)))
		//                    {                                 //ドロップされたデータがstring型か調べる
		//                        dragSouceUrl = (string)e.Data.GetData(typeof(string));                    //ドロップされたデータ(string型)を取得
		//                        dbMsg += ",e.Data:dragSouceUrl=" + dragSouceUrl;
		//                    }

		//                    if (b_dragSouceUrl != dragSouceUrl)
		//                    {                                           //二重動作回避？？発生原因不明
		//                                                                //			if (dropPointIndex > -1 && dropPointIndex < playListBox.Items.Count) {      //dropPointがplayList内で取得出来たら
		//                        b_dragSouceUrl = dragSouceUrl;                                                                   //	dropSouceUrl = e.Data.GetData(DataFormats.Text).ToString(); //ドラッグしてきたアイテムの文字列をstrに格納する☆他リストからは参照できない
		//                        if (dragFrom == playListBox.Name)
		//                        {                                     //プレイリスト内の移動なら		draglist == droplist
		//                            if (dragSouceIDl != dropPointIndex)
		//                            {
		//                                dbMsg += "を;" + dropPointIndex + "に移動";
		//                                DelFromPlayList(playList, dragSouceIDl);                        //一旦削除
		//                                if (dragSouceIDl < dropPointIndex)
		//                                {
		//                                    dropPointIndex--;
		//                                }
		//                            }
		//                        }
		//                        dbMsg += ">>>" + dropSouceUrl;
		//                        Files2PlayListIndex(playList, dragSouceUrl, dropPointIndex);
		//                        dragSouceUrl = "";
		//                        dbMsg += ",最終選択=" + dropPointIndex;
		//                        droplist.SelectedIndex = dropPointIndex;          //選択先のインデックスを指定
		//                        plaingItem = playListBox.SelectedValue.ToString();
		//                        dbMsg += ";plaingItem=" + plaingItem;
		//                        //					playListBox.Items[dragSouceIDP] = playListBox.Items[ind];
		//                        //					playListBox.Items[ind] = str;
		//                        //draglist.DoDragDrop("", DragDropEffects.None);//ドラッグスタート
		//                        //			}
		//                    }
		//                    else
		//                    {
		//                        dbMsg += "<<二重発生回避>>";
		//                    }
		//                }
		//                dragFrom = "";
		//                //	dragSouceUrl = "";
		//                dragSouceIDl = -1;
		//                DDEfect = DragDropEffects.None;
		//                MyLog(TAG, dbMsg);
		//            }
		//            catch (Exception er)
		//            {
		//                dbMsg += "<<以降でエラー発生>>" + er.Message;
		//                MyLog(TAG, dbMsg);
		//            }
		//        }


		private void PlayList_Drop(object sender, DragEventArgs e) {
			string TAG = "[PlayList_Drop]";
			string dbMsg = "";
			try {
				//TreeView tv = (TreeView)sender;
				//dbMsg += "dragFrom=" + dragFrom;
				//dbMsg += ",dragSouceUrl=" + dragSouceUrl;
				//dbMsg += ",DDEfect=" + DDEfect;
				//dbMsg += " , Effect(" + e.Effect + ")" + e.Effect.ToString();
				//if (e.Effect != DragDropEffects.None && dragFrom != "") {
				//	dbMsg += ">Drop開始>";
				//	dbMsg += ">source=null";
				//	fileTreeDropNode = tv.GetNodeAt(tv.PointToClient(new Point(e.X, e.Y))); //ドロップ先のTreeNodeを取得する
				//	tv.SelectedNode = fileTreeDropNode;
				//	dbMsg += " Drop先は" + tv.SelectedNode.FullPath;
				//	string dropSouce = fileTreeDropNode.FullPath.ToString();
				//	dbMsg += ",dropSouce=" + dropSouce;
				//	DropPeast(copySouce, cutSouce, dragSouceUrl, dropSouce);
				//	/*表示だけの書き換えなら
				//		TreeNode cln = ( TreeNode ) source.Clone();                             //ドロップされたNodeのコピーを作成
				//		target.Nodes.Add( cln );												//Nodeを追加
				//		target.Expand();														//ドロップ先のNodeを展開
				//		tv.SelectedNode = cln;                                                  //追加されたNodeを選択
				//	*/
				//	if (dragFrom == fileTree.Name) {                //同じtreeviewの中で
				//		if (e.Effect.ToString() == "Move") {        //カット指定なら
				//			cutSouce = fileTree.SelectedNode.FullPath;       //カットするアイテムのurl
				//			dbMsg += " , 移動した時は、ドラッグしたノード=" + dragNode.Name.ToString();             //移動先に書き換わる
				//			string dragNodeName = cutSouce.Replace(@":\\", @":\");
				//			dbMsg += " , dragNodeName=" + dragNodeName + " を削除";
				//			TreeNode dragParentNode = dragNode.Parent;
				//			dbMsg += " , " + fileTreeDropNode + " を選択";
				//			fileTree.Nodes.Remove(dragNode);
				//			fileTree.SelectedNode = fileTreeDropNode;
				//		}
				//	}
				//} else {
				//	dbMsg += ">Drop中断";
				//}
				//e.Effect = DragDropEffects.None;
				//fileTreeDropNode = null;
				//dragFrom = "";
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void PlayList_PreviewDragEnter(object sender, DragEventArgs e) {
			string TAG = "[PlayList_PreviewDragEnter]";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void PlayList_PreviewDragLeave(object sender, DragEventArgs e) {
			string TAG = "[PlayList_PreviewDragLeave]";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void PlayList_PreviewDragOver(object sender, DragEventArgs e) {
			string TAG = "[PlayList_PreviewDragOver]";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void PlayList_PreviewDrop(object sender, DragEventArgs e) {
			string TAG = "[PlayList_PreviewDrop]";
			string dbMsg = "";
			try {
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// 始めのマウスクリック
		// https://dobon.net/vb/dotnet/control/draganddrop.html
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayList_MouseDown(object sender, MouseButtonEventArgs e) {
			string TAG = "[PlayList_MouseDown]";// + fileName;
			string dbMsg = "";
			try {
				DataGrid droplist = (DataGrid)sender;
				dbMsg += ",AllowDrop=" + droplist.AllowDrop;
				dbMsg += "[" + droplist.SelectedIndex + "]";
				PlayListModel selectedItem = (PlayListModel)droplist.SelectedItem;
				dbMsg += ",Summary=" + selectedItem.Summary;
				dbMsg += ",UrlStr=" + selectedItem.UrlStr;
				//if (_isEditing) return;

				//				var row = UIHelpers.TryFindFromPoint<DataGridRow>((UIElement)sender, e.GetPosition(shareGrid));
				//	if (row == null || row.IsEditing) return;

				//set flag that indicates we're capturing mouse movements
				_isDragging = true;
				DraggedItem = (PlayListModel)droplist.SelectedItem;
				//				DraggedItem = (PlayListModel)row.Item;



				//draglist = (ListBox)sender;
				//PlayListMouseDownNo = draglist.SelectedIndex;
				//dbMsg += "(Down;" + PlayListMouseDownNo + ")";
				//if (e.Button == System.Windows.Forms.MouseButtons.Left) {                   //マウス左ボタン
				//	dbMsg += ",選択モード切替；ModifierKeys=" + Control.ModifierKeys;
				//	if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {                //シフト
				//		playListBox.SelectionMode = SelectionMode.MultiExtended;               //3:		インデックスが配列の境界外です。?
				//	} else if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {     //コントロール
				//		playListBox.SelectionMode = SelectionMode.MultiSimple;
				//		2:	MultiSimple / MultiExtended   http://www.atmarkit.co.jp/fdotnet/chushin/introwinform_03/introwinform_03_02.html

				//				} else {                                                                //無しなら
				//		playListBox.SelectionMode = SelectionMode.One;                         //1:単一選択
				//	}
				//	dbMsg += " ,SelectionMode=" + draglist.SelectionMode;
				//}
				//if (-1 < PlayListMouseDownNo) {
				//	PlayListMouseDownValue = draglist.SelectedValue.ToString();
				//	dbMsg += PlayListMouseDownValue;
				//	dragFrom = draglist.Name;
				//	dragSouceIDl = draglist.SelectedIndex;
				//	mouceDownPoint = Control.MousePosition;
				//	mouceDownPoint = draglist.PointToClient(mouceDownPoint);//ドラッグ開始時のマウスの位置をクライアント座標に変換
				//	dbMsg += "(mouceDownPoint;" + mouceDownPoint.X + "," + mouceDownPoint.Y + ")";
				//	dragSouceIDP = draglist.IndexFromPoint(mouceDownPoint);//マウス下のListBoxのインデックスを得る
				//	dbMsg += "(Pointから;" + dragSouceIDP + ")";
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		private void PlayList_MouseMove(object sender, MouseEventArgs e) {
			string TAG = "[PlayList_MouseMove]";
			string dbMsg = "";
			try {
				if (!_isDragging || e.LeftButton != MouseButtonState.Pressed) return;

				//display the popup if it hasn't been opened yet
				if (!popup1.IsOpen) {
					//switch to read-only mode
					//	PlayList.IsReadOnly = true;

					//make sure the popup is visible
					popup1.IsOpen = true;
				}

				Size popupSize = new Size(popup1.ActualWidth, popup1.ActualHeight);
				popup1.PlacementRectangle = new Rect(e.GetPosition(this), popupSize);

				//make sure the row under the grid is being selected
				Point position = e.GetPosition(PlayList);
				//	var row = UIHelpers.TryFindFromPoint<DataGridRow>(PlayList, position);
				//	if (row != null) PlayList.SelectedItem = droplist.SelectedItem;
  
				
				
				//	dbMsg += "(MovePoint;" + e.X + "," + e.Y + ")";
				//	draglist = (ListBox)sender;
				//	dbMsg += "draglist=" + draglist.Name;
				//	dbMsg += ",Button=" + e.Button;
				//	dbMsg += ",ModifierKeys=" + Control.ModifierKeys;
				//	/*			if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift) {
				//					draglist.SelectionMode = SelectionMode.MultiExtended;
				//				} else if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
				//					draglist.SelectionMode = SelectionMode.MultiSimple;
				//				} else {
				//					draglist.SelectionMode = SelectionMode.One;			//	MultiSimple/MultiExtended	http://www.atmarkit.co.jp/fdotnet/chushin/introwinform_03/introwinform_03_02.html
				//*/
				//	if (e.Button == System.Windows.Forms.MouseButtons.Left) {        //左ボタン
				//																	 //	draglist.SelectionMode = SelectionMode.One;
				//		if (mouceDownPoint != Point.Empty) {
				//			dbMsg += "(DownPoint;" + mouceDownPoint.X + "," + mouceDownPoint.Y + ")";
				//			int dx = mouceDownPoint.X - e.X;
				//			int dy = mouceDownPoint.Y - e.Y;
				//			dbMsg += "(d;" + dx + "," + dy + ")";
				//			double dMove = Math.Sqrt(dx * dx + dy * dy);
				//			dbMsg += ">>dMove=" + dMove;
				//			if (draglist.ItemHeight < dMove) {    //一行以上の移動   //mouceDownPoint.X != e.X || mouceDownPoint.Y != e.Y
				//				dbMsg += "(" + dragSouceIDP + ")";
				//				if (-1 < dragSouceIDP) {
				//					dbMsg += "(dragSouc;" + dragSouceIDl + ")";
				//					dragSouceUrl = PlayListMouseDownValue;// playListBox.Items[dragSouceIDP].ToString();
				//					dbMsg += "dragSouceUrl;" + dragSouceUrl;
				//					dbMsg += ">playListBoxへ>";
				//					DragURLs = new List<string>();
				//					if (1 == draglist.SelectedItems.Count) {
				//						draglist.SelectedIndex = dragSouceIDP;              //隣接への選択ずれ対策
				//					}
				//					for (int i = 0; i < draglist.SelectedItems.Count; ++i) {
				//						dbMsg += "(" + i + ")";
				//						PlayListItems itemxs = (PlayListItems)draglist.SelectedItems[i];
				//						string SelectedItems = itemxs.FullPathStr;
				//						dbMsg += SelectedItems;
				//						DragURLs.Add(SelectedItems);
				//					}
				//					dbMsg += ">>" + DragURLs.Count + "件";

				//					draglist.DoDragDrop(dragSouceUrl, DragDropEffects.Move);//ドラッグスタート
				//					if (dragFrom == "") {
				//						dragFrom = draglist.Name;
				//					}
				//					dbMsg += ">>DoDragDrop";
				//					mouceDownPoint = Point.Empty;
				//				}
				//				MyLog(TAG, dbMsg);
				//			}
				//		}
				//	} else {
				//		b_dragSouceUrl = "";
				//	}
				//		MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		/// <summary>
		/// マウスボタンを離す
		/// 右クリックされたアイテムからフルパスをグローバル変数に設定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PlayList_MouseUp(object sender, MouseButtonEventArgs e) {
			string TAG = "[PlayList_MouseUp]";
			string dbMsg = "";
			try {
				DataGrid droplist = (DataGrid)sender;
				dbMsg += ",AllowDrop=" + droplist.AllowDrop;
				dbMsg += "[" + droplist.SelectedIndex + "]";
				PlayListModel selectedItem = (PlayListModel)droplist.SelectedItem;
				dbMsg += ",Summary=" + selectedItem.Summary;
				dbMsg += ",UrlStr=" + selectedItem.UrlStr;
				//get the target item
				PlayListModel targetItem = (PlayListModel)droplist.SelectedItem;

				if (targetItem == null || !ReferenceEquals(DraggedItem, targetItem)) {

					//// create tempporary row
					//var temp = DraggedItem.Row.Table.NewRow();
					//temp.ItemArray = DraggedItem.Row.ItemArray;
					//int tempIndex = _shareTable.Rows.IndexOf(DraggedItem.Row);

					////remove the source from the list
					//_shareTable.Rows.Remove(DraggedItem.Row);

					////get target index
					//var targetIndex = _shareTable.Rows.IndexOf(targetItem.Row);

					////insert temporary at the target's location
					//_shareTable.Rows.InsertAt(temp, targetIndex);

					////select the dropped item
					//shareGrid.SelectedItem = shareGrid.Items[targetIndex];
				}

				//reset
				ResetDragDrop();






				//PlaylistMouseUp = droplist.SelectedIndex;
				//dbMsg += "(MouseUp:" + PlaylistMouseUp + ")";
				//string listSelectValue = "";
				//if (-1 < PlaylistMouseUp) {
				//	listSelectValue = droplist.SelectedValue.ToString();
				//	dbMsg += listSelectValue;
				//}


				//if (this.FormBorderStyle == FormBorderStyle.None || this.WindowState == FormWindowState.Maximized) {                //フルスクリーン
				//	通常サイズに戻すplToolStripMenuItem.Visible = true;
				//} else {            //	this.FormBorderStyle = FormBorderStyle.Sizable; //this.WindowState = FormWindowState.Normal;              //通常サイズに戻す
				//	通常サイズに戻すplToolStripMenuItem.Visible = false;
				//}

				//if (e.Button == System.Windows.Forms.MouseButtons.Right) {
				//	dbMsg += "右ボタンを離した";
				//	plIndex = playListBox.IndexFromPoint(e.Location);             //プレイリスト上のマウス座標から選択すべきアイテムのインデックスを取得
				//	dbMsg += ",index=" + plIndex;
				//	if (plIndex >= 0) {               // インデックスが取得できたら
				//		plRightClickItemUrl = PlayListBoxItem[plIndex].FullPathStr;
				//		dbMsg += ",plRightClickItemUrl=" + plRightClickItemUrl;
				//		playListBox.ClearSelected();                    // すべての選択状態を解除してから
				//		playListBox.SelectedIndex = index;                  // アイテムを選択
				//		Point pos = playListBox.PointToScreen(e.Location);
				//		dbMsg += ",pos=" + pos;
				//		PlayListContextMenuStrip.Show(pos);                     // コンテキストメニューを表示
				//	}
				//}
				MyLog(TAG, dbMsg);
			} catch (Exception er) {
				MyErrorLog(TAG, dbMsg, er);
			}
		}

		//        /*
		//				private void PlayListBox_GiveFeedback(object sender, GiveFeedbackEventArgs e) {
		//					string TAG = "[PlayListBox_GiveFeedback]";
		//					string dbMsg = TAG;
		//					try {
		//						/*		https://dobon.net/vb/dotnet/control/draganddrop.html

		//		dbMsg += "Effect=" + e.Effect.ToString();
		//		e.UseDefaultCursors = false;                //既定のカーソルを使用しない
		//		//ドロップ効果にあわせてカーソルを指定する
		//		if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move) {
		//		//			Cursor.Current = moveCursor;
		//		} else if ((e.Effect & DragDropEffects.Copy) == DragDropEffects.Copy) {
		//		//			Cursor.Current = copyCursor;
		//		} else if ((e.Effect & DragDropEffects.Link) == DragDropEffects.Link) {
		//		//			Cursor.Current = linkCursor;
		//		} else {
		//		//			Cursor.Current = noneCursor;
		//		}

		//						MyLog(TAG, dbMsg);
		//					} catch (Exception er) {
		//						dbMsg += "<<以降でエラー発生>>" + er.Message;
		//						MyLog(TAG, dbMsg);
		//					}
		//				}
		//		*/



		//        /// <summary>
		//        /// ドラッグ中にマウスの右ボタンを押すことにより、ドラッグがキャンセル
		//        /// 
		//        /// https://dobon.net/vb/dotnet/control/draganddrop.html
		//        /// </summary>
		//        /// <param name="sender"></param>
		//        /// <param name="e"></param>
		//        /*		private void PlayListBox_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
		//					string TAG = "[PlayListBox_QueryContinueDrag]";
		//					string dbMsg = TAG;
		//					try {
		//						//マウスの右ボタンが押されていればドラッグをキャンセル
		//						dbMsg += "KeyState=" + e.KeyState;
		//						if ((e.KeyState & 2) == 2) {                //"2"はマウスの右ボタンを表す
		//							dbMsg += "マウスの右ボタンでドラッグをキャンセル";
		//							e.Action = DragAction.Cancel;
		//						}
		//						MyLog(TAG, dbMsg);
		//					} catch (Exception er) {
		//						dbMsg += "<<以降でエラー発生>>" + er.Message;
		//						MyLog(TAG, dbMsg);
		//					}
		//				}*/
		public static void MyLog(string TAG, string dbMsg) {
			dbMsg = "[MainWindow]" + dbMsg;
			//dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyLog(TAG, dbMsg);
		}

		public static void MyErrorLog(string TAG, string dbMsg, Exception err) {
			dbMsg = "[MainWindow]" + dbMsg;
			CS_Util Util = new CS_Util();
			Util.MyErrorLog(TAG, dbMsg, err);
		}

		public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
																		MessageBoxButton buttns,
																		MessageBoxImage icon
																		) {
			CS_Util Util = new CS_Util();
			return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
		}



	}
}
