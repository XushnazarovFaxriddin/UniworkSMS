using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Webkit;

namespace UniworkSMS
{
    [Activity(Label = "InfoPage")]
    public class InfoPage : Activity
    {
        string url;
        WebView webView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.info);
            // Create your application here
            var UiDesign = FindViewById<RelativeLayout>(Resource.Id.UiDesignDiv);
            var Information = FindViewById<RelativeLayout>(Resource.Id.InformationBtn);
            var UXdesign = FindViewById<RelativeLayout>(Resource.Id.UxDesignBtn);
            var FounBtn = FindViewById<RelativeLayout>(Resource.Id.FoundationBtn);
            UiDesign.Click += delegate
            {
                url = "https://t.me/The_sardorb3k";
                var uri = Uri.Parse(url);
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
            UXdesign.Click += delegate
            {
                url = "https://t.me/Xushnazarov_555";
                var uri = Uri.Parse(url);
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);
            };
            Information.Click += delegate
            {
                StartActivity(typeof(AboutPage));
            };
            FounBtn.Click += delegate
            {
                Context context = Application.Context;
                string text = "Developers: Faxriddin Xushnazarov and Sardorbek Sattorov";
                ToastLength duration = ToastLength.Short;
                var toast = Toast.MakeText(context, text, duration);
                toast.Show();
            };
        }

        

        private void Information_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}