using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Newtonsoft.Json;
using OpendeurdagApp.Model;
using OpendeurdagApp.Model.DAL;

namespace OpendeurdagApp.ViewModel
{
    public class NewsFeedViewModel: ViewModelBase
    {
        private ObservableCollection<NewsfeedItem> newsfeedList;

        public ObservableCollection<NewsfeedItem> NewsfeedList
        {
            get {return newsfeedList;}
            set { newsfeedList = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<Richting> richtingen;

        public ObservableCollection<Richting> Richtingen
        {
            get { return richtingen; }
            set { richtingen = value; RaisePropertyChanged(); }
        }

        private Visibility isAdmin;

        public Visibility IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; RaisePropertyChanged(); }
        }

        private MainPageViewModel mainvm;
        private bool isLoading;
        private bool isNewsFeedsLoading;
        private bool isRichtingLoading;

        public bool IsLoading
        {
            get { return isRichtingLoading; }
            set { isRichtingLoading = value; RaisePropertyChanged(); }
        }

        private readonly string url = "http://localhost:51420/api/";

        public NewsFeedViewModel(MainPageViewModel mainPagevm)
        {
            IsLoading = true;
            isRichtingLoading = true;
            isNewsFeedsLoading = true;
            mainvm = mainPagevm;
            getNewsFeed();
            getOpleidingen();
        }
        private async void getNewsFeed()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url + "newsfeeditems");
            NewsfeedList = JsonConvert.DeserializeObject<ObservableCollection<NewsfeedItem>>(jsonString);
            IsLoading = isNewsFeedsLoading && isRichtingLoading;
        }
        private async void getOpleidingen()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url + "richtings");
            Richtingen = JsonConvert.DeserializeObject<ObservableCollection<Richting>>(jsonString);
            IsLoading = isNewsFeedsLoading && isRichtingLoading;

        }

        public void setIsAdmin(bool admin)
        {
            IsAdmin = admin ? Visibility.Collapsed : Visibility.Visible;
            mainvm.IsAdmin = admin ? Visibility.Visible : Visibility.Collapsed;
        }



    }
}
