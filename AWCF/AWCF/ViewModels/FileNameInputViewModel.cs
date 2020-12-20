using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Reflection;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data;
using System.Runtime.CompilerServices;

using Livet;
using Livet.Commands;
using Livet.Messaging.Windows;
using Livet.EventListeners;
using Livet.Messaging;
using Livet.Messaging.IO;

namespace AWCF.ViewModels
{
    public class FileNameInputViewModel : ViewModel
    {
        public bool NeedHideOwner { get; set; }
        /// <summary>
        /// ドライブ～フォルダ
        /// </summary>
        public string PathStr { get; set; }
        public string FileNameStr { get; set; }
        public string ExtStr { get; set; }
        

        public FileNameInputViewModel()
        {
            Initialize();
        }


        public void Initialize()
        {
            string TAG = "Initialize";
            string dbMsg = "";
            try
            {
             //   ExtStr = ".m3u8";
                RaisePropertyChanged(); //	"dataManager"
                MyLog(TAG, dbMsg);
            }
            catch (Exception er)
            {
                MyErrorLog(TAG, dbMsg, er);
            }
        }




        #region FolderDlogShow	　フォルダ選択
        private ViewModelCommand _FolderDlogShow;

        public ViewModelCommand FolderDlogShow
        {
            get {
                if (_FolderDlogShow == null)
                {
                    _FolderDlogShow = new ViewModelCommand(ShowFolderDlog);
                }
                return _FolderDlogShow;
            }
        }
        /// <summary>
        /// フォルダ選択ダイアログから選択されたフォルダを記録する
        /// </summary>
        private void ShowFolderDlog(){
            string TAG = "ShowFolderDlog";
            string dbMsg = "";
            try{
                //①
                System.Windows.Forms.FolderBrowserDialog fbDialog = new System.Windows.Forms.FolderBrowserDialog();
                // ダイアログの説明文を指定する
                fbDialog.Description = "添付ファイルをフォルダ単位で指定";
                // デフォルトのフォルダを指定する
                dbMsg += ",PathStr=" + PathStr;
                fbDialog.SelectedPath = PathStr;
                // 「新しいフォルダーの作成する」ボタンを表示しない
                fbDialog.ShowNewFolderButton = false;
                //フォルダを選択するダイアログを表示する
                if (fbDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                    PathStr = fbDialog.SelectedPath;
                    if (!PathStr.EndsWith("\\")){
                        PathStr += "\\";
                    }
                    RaisePropertyChanged("PathStr");
                    dbMsg += ">>" + PathStr;
                    string[] files = System.IO.Directory.GetFiles(@PathStr, "*", System.IO.SearchOption.AllDirectories);
                    dbMsg += ">>" + files.Length + "件";
                    //設定ファイル更新
                }else{
                    dbMsg += "キャンセルされました";
                }
                // オブジェクトを破棄する
                fbDialog.Dispose();
                RaisePropertyChanged();
                MyLog(TAG, dbMsg);
            }
            catch (Exception er)
            {
                MyErrorLog(TAG, dbMsg, er);
            }
        }

        
        #endregion
        #region CancelCommand
        private ViewModelCommand _CancelCommand;

        public ViewModelCommand CancelCommand
        {
            get {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new ViewModelCommand(Cancel);
                }
                return _CancelCommand;
            }
        }

        public void Cancel()
        {
            DialogResult = null;
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
        }
        #endregion

        #region UpdateCommand
        private ViewModelCommand _UpdateCommand;

        public ViewModelCommand UpdateCommand
        {
            get {
                if (_UpdateCommand == null)
                {
                    _UpdateCommand = new ViewModelCommand(Update);
                }
                return _UpdateCommand;
            }
        }

        public string DialogResult { get; private set; }

        public void Update()
        {
            string TAG = "Initialize";
            string dbMsg = "";
            try
            {
                //_Origin.Address = _Person.Address;
                //_Origin.Name = _Person.Name;
                this.DialogResult = PathStr + FileNameStr + ExtStr;
                RaisePropertyChanged();
                dbMsg += ",DialogResult= " + DialogResult;
                MyLog(TAG, dbMsg);
                Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Close"));
            }
            catch (Exception er)
            {
                MyErrorLog(TAG, dbMsg, er);
            }
        }
        #endregion


        //デバッグツール///////////////////////////////////////////////////////////その他//
        Boolean debug_now = true;

        //Livet Messenger用///////////////////////
        new public void Dispose()
        {
            // 基本クラスのDispose()でCompositeDisposableに登録されたイベントを解放する。
            //base.Dispose();
            //Dispose(true);
        }
        ///////////////////////Livet Messenger用//
        public static void MyLog(string TAG, string dbMsg)
        {
            dbMsg = "[FileNameInputViewModel]" + dbMsg;
            //dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
            CS_Util Util = new CS_Util();
            Util.MyLog(TAG, dbMsg);
        }

        public static void MyErrorLog(string TAG, string dbMsg, Exception err)
        {
            dbMsg = "[FileNameInputViewModel]" + dbMsg;
            CS_Util Util = new CS_Util();
            Util.MyErrorLog(TAG, dbMsg, err);
        }

        public MessageBoxResult MessageShowWPF(String titolStr, String msgStr,
                                                                        MessageBoxButton buttns,
                                                                        MessageBoxImage icon
                                                                        )
        {
            CS_Util Util = new CS_Util();
            return Util.MessageShowWPF(msgStr, titolStr, buttns, icon);
        }


    }
}
