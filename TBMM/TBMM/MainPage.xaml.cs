using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace TBMM
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        readonly WebClient webClient;
        int num = 0;
        RootObject json;
        public string url;
        public string currencyPair;
        public class RootObject
        {
            /*  public double last { get; set; }
              public double high { get; set; }
              public double low { get; set; }
              public double volume { get; set; }
              public double vwap { get; set; }
              public double max_bid { get; set; }
              public double min_ask { get; set; }*/
            // public double best_bid { get; set; }
            // public double best_ask { get; set; }
            public double ask { get; set; }
            public double bid { get; set; }
            public double highestBid { get; set; }
            public double lowestAsk { get; set; }
        }
        public MainPage()
        {
            InitializeComponent();
            webClient = new WebClient();
        }
        private void OnButtonClicked(object sender, EventArgs e)
        {
            (sender as Button).Text = "Click: " + ++num;
        }
        private void OnButton2Clicked(object sender, EventArgs e)
        {
            string urlExchange;
            urlExchange = "https://api.hitbtc.com/api/2/public/ticker/";
            currencyPair = "BTCUSD";
            url = urlExchange + currencyPair;


            using (WebClient wc = webClient)
            {
                string webPage = null;

                try
                {
                    webPage = wc.DownloadString(@url);
                /*    if (exchange == "HitBTC")
                    {
                        errorHitBtc = false;
                    }*/
                    json = null;
                    json = JsonConvert.DeserializeObject<RootObject>(webPage);


                }
                catch (WebException)
                {

                  /*  if (exchange == "HitBTC")
                    {
                        errorHitBtc = true;
                        text.Text = "API HitBTC недоступно" + url;
                    }*/

                    url = null;
                }
            }




            texts.Text = json.bid.ToString();
        }
    }
}