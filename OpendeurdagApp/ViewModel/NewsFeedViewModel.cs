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
        private readonly string url = "http://localhost:51420/api/";

        public NewsFeedViewModel(MainPageViewModel mainPagevm)
        {
            mainvm = mainPagevm;
            NewsfeedList = new ObservableCollection<NewsfeedItem>(CampusRepository.GetNewsFeed());
            //getNewsFeed();
        }
        private async void getNewsFeed()
        {
            HttpClient client = new HttpClient();
            var jsonString = await client.GetStringAsync(url + "newsfeed");
            NewsfeedList = JsonConvert.DeserializeObject<ObservableCollection<NewsfeedItem>>(jsonString);
        }
    }
}
