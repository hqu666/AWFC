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

namespace AWCF {

	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : NavigationWindow {
	
	private static WebWindow webW = null;
		public MainWindow()
		{
			InitializeComponent();
			callWeb();
		}

		private void callWeb(){
			if (webW == null) {
				// 次に表示するページ（ページ2）を生成、以後使いまわし
				webW = new WebWindow();
			}

			// ページ2へ移動
			this.NavigationService.Navigate(webW);

		}

	}
}
