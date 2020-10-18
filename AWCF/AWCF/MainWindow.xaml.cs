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
using Microsoft.Web.WebView2;

namespace AWCF {
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		public MainWindow()
		{
			InitializeComponent();
	//		CallWeb();
		}

		public void CallWeb()
		{
			//MainFrame.Navigate(typeof(WebPage));

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
			WebWindow webWindow = new WebWindow();
			webWindow.Show();
		}

	}
}
