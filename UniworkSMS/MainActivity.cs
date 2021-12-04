using Android.App;
using Android.OS;
using Android.Webkit;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Views;
using System;
using System.Threading.Tasks;
using System.Timers;

namespace UniworkSMS
{
    [Activity(Icon = "@drawable/icon", Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        static int count = 0;
        static string Login = String.Empty, Misol;
        string Url = "https://uniwork.buxdu.uz/forgot.asp";
        WebView web_view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            web_view = FindViewById<WebView>(Resource.Id.webView);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(new HelloWebViewClient());
            web_view.LoadUrl(Url);
            Timer timer = new Timer(1000);
            timer.Elapsed += async (sender, e) => Send(null, null);
            var StartBtn = FindViewById<Button>(Resource.Id.StartBtn);
            var InfoBtn = FindViewById<Button>(Resource.Id.InfoBtn);
            var LoginTxt = FindViewById<EditText>(Resource.Id.logintxt);
            var CountTxt = FindViewById<TextView>(Resource.Id.countTxt);

            // Information Page
            var InformationBtn = FindViewById<Button>(Resource.Id.InformationBtn);
            var UxDesignBtn = FindViewById<TextView>(Resource.Id.UxDesignBtn);
            if (LoginTxt.Text == "")
            {
                StartBtn.Enabled = false;
            }
            else
            {
                StartBtn.Enabled = true;
            }
            web_view.EvaluateJavascript("document.getElementsByTagName('div')[12].innerHTML='';", null);
            LoginTxt.TextChanged += (s, e) =>
            {
                CountTxt.Text = "0";
                count = 0;
                if (LoginTxt.Text == "")
                {
                    StartBtn.Enabled = false;
                }
                else
                {
                    StartBtn.Enabled = true;
                }
            };
            InfoBtn.Click += (s, e) =>
            {
                //SetContentView(Resource.Layout.info);
                StartActivity(typeof(InfoPage));
            };
            StartBtn.Click += (s, e) =>
            {
                count++;
                CountTxt.Text = count.ToString();
                Login = LoginTxt.Text;
                web_view.EvaluateJavascript($"document.getElementById('login').value ='{Login}';", null);
                web_view.EvaluateJavascript(@"var natija=document.getElementsByTagName('tr')[4].innerText.replace('=\n\t\t','');
document.getElementById('javob').value = eval(natija);", null);
                web_view.EvaluateJavascript("document.getElementsByTagName('input')[5].form.submit();", null);

            };
            static async void Send(object s, EventArgs e)
            {


            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
    }
    public class HelloWebViewClient : WebViewClient
    {
        [System.Obsolete]
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return false;
        }
    }
}