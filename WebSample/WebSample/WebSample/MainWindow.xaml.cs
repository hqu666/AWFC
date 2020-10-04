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
using System.Windows.Navigation;
using System.Windows.Shapes;

/// <summary>
/// 旧WebViewサンプル
/// https://www.366service.com/jp/qa/9f93db74daf5e38f0370f62729c69a51
/// </summary>
namespace WebSample {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow()
		{
			InitializeComponent();
		}

		/// <summary>
		/// viewが形成された後
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void WebView_Loaded(object sender, RoutedEventArgs e)
		{
			Uri uri = new Uri("https://www.yahoo.co.jp/");
			webView1.Navigate(uri);

			//Task<string> htmlEv = Task.Run(() => {
			//	return webView1.InvokeScriptAsync("eval", "document.documentElement.outerHTML;");
			//});
			//htmlEv.Wait();
			//string htmlText = htmlEv.Result;
		}

		private void BTN1_Click(object sender, RoutedEventArgs e)
		{
			//MessageBox.Show("Loaded");
			//WebView1.Navigate(new Uri("https://www.google.com"));
		}

	}
}
