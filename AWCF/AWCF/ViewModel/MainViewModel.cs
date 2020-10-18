using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCF.ViewModel {
	class MainViewModel : INotifyPropertyChanged {

		public string FrameSource { get; set; }

		public MainViewModel()
		{
			CallWeb();
		}

		public void CallWeb()
		{
			FrameSource = "WebPage.xaml";
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
