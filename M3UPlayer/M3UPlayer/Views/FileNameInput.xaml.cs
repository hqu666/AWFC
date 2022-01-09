using System;
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
using System.Windows.Shapes;

namespace M3UPlayer.Views
{
    /// <summary>
    /// FileNameInput.xaml の相互作用ロジック
    /// </summary>
    public partial class FileNameInput : Window
    {

        //public string PathStr { get; set; }
        //public string FileNameStr { get; set; }
        //public string ExtStr { get; set; }

        public FileNameInput()
        {
            string TAG = "FileNameInput";
            string dbMsg = "";
            try
            {
                InitializeComponent();
      //          PathStr = ".m3u8";
                MyLog(TAG, dbMsg);
            }
            catch (Exception er)
            {
                MyErrorLog(TAG, dbMsg, er);
            }
        }

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
            dbMsg = "[FileNameInput]" + dbMsg;
            //dbMsg = "[" + MethodBase.GetCurrentMethod().Name + "]" + dbMsg;
            CS_Util Util = new CS_Util();
            Util.MyLog(TAG, dbMsg);
        }

        public static void MyErrorLog(string TAG, string dbMsg, Exception err)
        {
            dbMsg = "[FileNameInput]" + dbMsg;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        

        }
    }
}
