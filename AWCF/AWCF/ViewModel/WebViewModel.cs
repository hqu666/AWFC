using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWCF.ViewModel {
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

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
