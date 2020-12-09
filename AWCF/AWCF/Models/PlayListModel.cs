using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Livet;

namespace AWCF.Models
{
    public class PlayListModel : NotificationObject, ICloneable
    {
        /// <summary>
        /// Url
        /// </summary>
        private string _UrlStr;
        public string UrlStr
        {
            get => _UrlStr;
            set {
                if (_UrlStr == value)
                    return;
                _UrlStr = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// 要約・表記
        /// </summary>
        private string _Summary;
        public string Summary
        {
            get => _Summary;
            set {
                if (_Summary == value)
                    return;
                _Summary = value;
                RaisePropertyChanged();
            }
        }



        object ICloneable.Clone()
        {
            return new PlayListModel()
            {
                UrlStr = this.UrlStr,
                Summary = this.Summary,
            };
        }

    }

    public class PlayListCollection : ObservableCollection<PlayListModel>
    {
        public PlayListCollection()
        {
        }
    }
}
