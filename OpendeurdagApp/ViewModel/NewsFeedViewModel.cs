using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        private MainPageViewModel mainvm;
        private bool isLoading;

        public bool IsLoading
        {
            get { return isLoading; }
            set { isLoading = value; RaisePropertyChanged(); }
        }

        private readonly string url = "http://localhost:51420/api/";

        public NewsFeedViewModel(MainPageViewModel mainPagevm)
        {
            IsLoading = true;
            mainvm = mainPagevm;
            getNewsFeed();
        }
        private async void getNewsFeed()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url + "newsfeeditems");
            NewsfeedList = JsonConvert.DeserializeObject<ObservableCollection<NewsfeedItem>>(jsonString);
            IsLoading = false;
        }

       

    }
}
