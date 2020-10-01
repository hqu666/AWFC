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
using Microsoft.Web.WebView2.Core;

namespace AWCF {
	/// <summary>
	/// WebPage.xaml の相互作用ロジック
	/// </summary>
	public partial class WebPage : Page {
		public WebPage()
		{
			InitializeComponent();
		}

		private void ButtonGo_Click(object sender, RoutedEventArgs e)
		{
			if (webView != null && webView.CoreWebView2 != null) {
				webView.CoreWebView2.Navigate(addressBar.Text);
			}
		}

	}
}
