using Awesomium.Core;
using Core.UsuallyCommon; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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
using Work.EntityFramework;

namespace Works
{

    public struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitUrl();
            if (!WebCore.IsInitialized)
            {
                WebCore.Initialize(new WebConfig()
                {
                    HomeURL = new Uri(BaseAddress),
                    LogPath = @".\starter.log",
                    LogLevel = LogLevel.Verbose
                });
            }
            InitializeComponent();
            this.WindowState = System.Windows.WindowState.Maximized; this.Source = WebCore.Configuration.HomeURL;

            readDataTimer.Tick += new EventHandler(timeCycle);
            readDataTimer.Interval = new TimeSpan(0, 0, 0, 8);
            //readDataTimer.Start();
        }
        #region webborrow

        // This will be set to the target URL, when this window does not
        // host a created child view. The WebControl, is bound to this property.
        public Uri Source
        {
            get { return (Uri)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Identifies the <see cref="Source"/> dependency property.
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
            typeof(Uri), typeof(MainWindow),
            new FrameworkPropertyMetadata(null));


        // This will be set to the created child view that the WebControl will wrap,
        // when ShowCreatedWebView is the result of 'window.open'. The WebControl, 
        // is bound to this property.
        public IntPtr NativeView
        {
            get { return (IntPtr)GetValue(NativeViewProperty); }
            private set { this.SetValue(MainWindow.NativeViewPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey NativeViewPropertyKey =
            DependencyProperty.RegisterReadOnly("NativeView",
            typeof(IntPtr), typeof(MainWindow),
            new FrameworkPropertyMetadata(IntPtr.Zero));

        // Identifies the <see cref="NativeView"/> dependency property.
        public static readonly DependencyProperty NativeViewProperty =
            NativeViewPropertyKey.DependencyProperty;

        // The visibility of the address bar and status bar, depends
        // on the value of this property. We set this to false when
        // the window wraps a WebControl that is the result of JavaScript
        // 'window.open'.
        public bool IsRegularWindow
        {
            get { return (bool)GetValue(IsRegularWindowProperty); }
            private set { this.SetValue(MainWindow.IsRegularWindowPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsRegularWindowPropertyKey =
            DependencyProperty.RegisterReadOnly("IsRegularWindow",
            typeof(bool), typeof(MainWindow),
            new FrameworkPropertyMetadata(true));

        // Identifies the <see cref="IsRegularWindow"/> dependency property.
        public static readonly DependencyProperty IsRegularWindowProperty =
            IsRegularWindowPropertyKey.DependencyProperty;


        private void webControl_WindowClose(object sender, WindowCloseEventArgs e)
        {
            // The page called 'window.close'. If the call
            // comes from a frame, ignore it.
            if (!e.IsCalledFromFrame)
                this.Close();
        }

        #endregion


        public WorkEntityFramework entity = new WorkEntityFramework();
        public CookieContainer cookcontainer = new CookieContainer();
        public CookieContainer GetCookieContainer()
        {
            cookcontainer = new CookieContainer();
            //if (cookcontainer == null || cookcontainer.Count == 0)
            //{
                entity.cookies.ToList().ForEach(x =>
                cookcontainer.Add(new Cookie() { Name = x.name, Value = x.value, Domain = x.host_key }));
            //}
            return cookcontainer;
        }


        public string BaseAddress { get; set; }

        public string SearchResult { get; set; }

        public string BaiJiaLe { get; set; }

        public string SESSION_ID { get; set; }

        public void InitUrl()
        {
            BaseAddress = entity.urls.AsNoTracking().FirstOrDefault(x => x.Name == UrlEnum.BaseAddress).Url;

            SearchResult = entity.urls.AsNoTracking().FirstOrDefault(x => x.Name == UrlEnum.SeearchResult).Url;

            BaiJiaLe = entity.urls.AsNoTracking().FirstOrDefault(x => x.Name == UrlEnum.BaiJiaLe).Url.Replace("BaseAddress", BaseAddress);

            try
            {
                SESSION_ID = entity.cookies.AsNoTracking().FirstOrDefault(x => x.name == "SESSION_ID").value;

                SearchResult = SearchResult.Replace("BaseAddress", BaseAddress).Replace("SESSION_ID", SESSION_ID);

                SearchResult = string.Format(SearchResult, DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd"), DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"), 100);
            }
            catch (Exception)
            {

            }


        }

        public async Task<List<GameResult>> GetResultHtml()
        {
            //lblMessage.Text += SearchResult;
            lblMessage.Text += "==SESSION_ID=="+ SESSION_ID;
            string result = await HttpHelper.GetAsync(SearchResult, GetCookieContainer());
            List<GameResult> games = new List<GameResult>();
            if (result.Length < 1000)
            {
                lblMessage.Text += result;
            }
            try
            {
                HtmlAgilityPack.HtmlDocument docs = new HtmlAgilityPack.HtmlDocument();

                docs.LoadHtml(result);
                var table = docs.DocumentNode.SelectSingleNode("//*[@class=\"table table-hover text-middle table-bordered footable\"]");
                var trs = table.SelectSingleNode("tbody").SelectNodes("tr").ToList().Take(5);
                if (trs == null)
                    return null;
                foreach (var item in trs)
                {
                    var tds = item.SelectNodes("td");
                    GameResult sx = new GameResult()
                    {
                        InvestTime = (tds[0].InnerText).ToDateTime().AddHours(12),
                        OrderNumber = (tds[1].InnerText).ToStringExtension().Trim(),
                        JuHao = (tds[2].InnerText).ToStringExtension().Trim(),
                        ChangCi = (tds[3].InnerText).ToStringExtension().Trim(),
                        GameType = (tds[4].InnerText).ToStringExtension().Trim(),
                        Result = (tds[6].InnerText).ToStringExtension().Trim(),
                        InvestMoney = (tds[7].InnerText).ToStringExtension().Trim().ToDecimal(),
                        ValidMoney = (tds[8].InnerText).ToStringExtension().Trim().ToDecimal(),
                        WinMoney = (tds[9].InnerText).ToStringExtension().Trim().ToDecimal(),
                        Remark = (tds[10].InnerText).ToStringExtension().Trim(),
                    };
                    games.Add(sx);
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text += ex.Message;
            }
            return games;
        }


        public void SaveDb(GameResult game)
        {
            //entity.gameresult.Add(game);
            //entity.SaveChanges();
        }

        public void SendEmail(string content)
        {
            EmailHelper.SendEmail("415552548@qq.com", "omgyvfhsugztbhcc", "13701859214@qq.com", "", "works", content, "smtp.qq.com", 25);
        }


        private static System.Windows.Threading.DispatcherTimer readDataTimer = new System.Windows.Threading.DispatcherTimer();


        public void timeCycle(object sender, EventArgs e)
        {
            this.lblMessage.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Invest();
        }
        public async void Invest()
        {
            lblMessage.Text = string.Empty;
            //lblMessage.Content += "readay initurl";
            InitUrl();

            List<GameResult> result = new List<GameResult>();
            try
            {
                  result = await GetResultHtml();
            }
            catch (Exception ex)
            {
                lblMessage.Text += ex.Message;
            }
        
            if (result == null || result.Count == 0)
            {
                lblMessage.Text += "not result";
                return;
            }

            InitUrl();
            var list = result.OrderByDescending(x => x.InvestTime).Take(10).ToList();

            var second = result.Skip(1).Take(1).FirstOrDefault();

            Decimal lostmoney = 0;
            Decimal minvalue = MinValue.Text.ToDecimal();
            Decimal addmoney = Addmoney.Text.ToDecimal();

            Decimal lostPersent = LostPresent.Text.ToDecimal();
            Decimal basePersent = 10 / lostPersent;

            int allcount = 0;

            if (second != null)
            { 
                var ms = Math.Abs((list.FirstOrDefault().InvestMoney - second.InvestMoney).ToDecimal())  ;
                if(ms !=(list.FirstOrDefault().InvestMoney.ToInt32() / basePersent + 1).ToDecimal() * addmoney)
                {
                    if (list.FirstOrDefault().InvestMoney < second.InvestMoney && allcount %2 ==0)
                        lostmoney = second.InvestMoney.Value - list.FirstOrDefault().InvestMoney.Value + addmoney;
                    allcount++;
                }

                
            }
            bool isover = IsOver(list.First());
            if (isover)
            {
                lblMessage.Text += "start invest";
                var last = list.FirstOrDefault();

                var lastmoney = last.Remark.IndexOf('/') > -1 ? last.Remark.Split('/')[1].ToDecimal() : 10000;

                // invest
                decimal investmoney = last.InvestMoney.ToDecimal();


                if (last.WinMoney > 0)
                {
                    investmoney -= (last.InvestMoney.ToInt32() / basePersent + 1).ToDecimal() * addmoney;
                }
                if (last.WinMoney < 0)
                {
                    investmoney += (last.InvestMoney.ToInt32() / basePersent + 1).ToDecimal() * addmoney;
                }

                investmoney += lostmoney;

                if (investmoney < minvalue)
                    investmoney = minvalue;

                if (lastmoney < investmoney)
                {
                    // send email
                    string message = string.Format("金额不足：{0},下注需要：{1}", lastmoney, investmoney);
                    SendEmail(message);
                    lblMessage.Text += message;
                    return;
                }
                // 准备按钮
                MouseHelper.DoClick(TenDollayXy.Text.Split(',')[0].ToInt32(), TenDollayXy.Text.Split(',')[1].ToInt32());
                var clicktencount = investmoney / 10;

                bool random = RandomHelper.RandomBool();

                int x = random ? XianXy.Text.Split(',')[0].ToInt32() : ZhuangXy.Text.Split(',')[0].ToInt32();
                int y = random ? XianXy.Text.Split(',')[1].ToInt32() : ZhuangXy.Text.Split(',')[1].ToInt32();
                for (int c = 0; c < clicktencount; c++)
                {
                    MouseHelper.DoClick(x, y);
                }

                MouseHelper.DoClick(OkXy.Text.Split(',')[0].ToInt32(), OkXy.Text.Split(',')[1].ToInt32());

                lblMessage.Text += string.Format("投注成功，投注金额:{0}",investmoney);
            }
            else
            {
                lblMessage.Text += "wait game over";
                if (list.Count > 1)
                    SaveDb(list.Skip(1).Take(1).FirstOrDefault());
                else
                    SaveDb(list.FirstOrDefault());
            }
        }

        public bool IsOver(GameResult game)
        {
            if (game == null
                || string.IsNullOrEmpty(game.Result.Trim()) || game.Result.Trim().IndexOf("undefined") > -1
                || string.IsNullOrEmpty(game.Remark.Trim()) || game.Remark.Trim().IndexOf("undefined") > -1)
                return false;
            return true;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            POINT pt = new POINT();
            GetCursorPos(out pt);
            Key key = e.Key;
            switch (key)
            {
                case Key.F8:
                    TenDollayXy.Text = string.Format("{0},{1}",pt.X,pt.Y);
                    break;
                case Key.F9:
                    OkXy.Text = string.Format("{0},{1}", pt.X, pt.Y);
                    break;

                case Key.F7:
                    XianXy.Text = string.Format("{0},{1}", pt.X, pt.Y);
                    break;

                case Key.F6:
                    ZhuangXy.Text = string.Format("{0},{1}", pt.X, pt.Y);
                    break;
            }
        }

        private void btnstart_Click(object sender, RoutedEventArgs e)
        {
            readDataTimer.Start();
        }

        private void btnend_Click(object sender, RoutedEventArgs e)
        {
            readDataTimer.Stop();
        }

        private void ToBaijia_Click(object sender, RoutedEventArgs e)
        {
            this.webControl.Source = BaiJiaLe.ToUri();
        }
    }

    public class MouseHelper
    {
        #region win32

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos(out POINT pt);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags,
            int dx, int dy, uint data, UIntPtr extraInfo);

        [Flags]
        enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }
        public static void DoClick(int x, int y)
        {
            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }
        #endregion
    }
}
