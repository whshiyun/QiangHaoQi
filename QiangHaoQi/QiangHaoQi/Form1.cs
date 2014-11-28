using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace QiangHaoQi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            username.Text = "13297912053";
            password.Text = "112200";
        }

        private class NameAndUrl
        {
            public NameAndUrl(string name, string url)
            {
                this.name = name;
                this.url = url;
            }
            public string name;
            public string url;
        }

        private const string baseUrl = "http://www.yihu.com/";
        private List<NameAndUrl> departmentsArr = new List<NameAndUrl>();
        private List<NameAndUrl> doctorArr = new List<NameAndUrl>();
        private CookieContainer cookieContainer = new CookieContainer();

        private void Set_NameAndUrl(List<NameAndUrl> list, MatchCollection nameAndUrl)
        {
            foreach (Match m in nameAndUrl)
            {
                //this.comb_type.Items.Add(new ControlItem(dr,dr["answertypename"].ToString()));
                //Departments.Items.Add(m.Groups["name"].Value);
                list.Add(new NameAndUrl(m.Groups["name"].Value, baseUrl + m.Groups["url"].Value));
            }
            //Departments.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crifanLib crifan = new crifanLib();

            //textBox1.Text = "aaaaaaaaaaaaa";
            string url = "http://jsonp.yihu.com/action/login/login.ashx?d=1416883229934&loginid=" + username.Text + "&pwd=" + password.Text + "&type=1&CkSavePwd=n&callback=_jqjsp&_1416883229934=";
            //cookieContainer.Add()
            //用url实例化HttpWebRequest类
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);

            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //foreach (Cookie cookie in response.Cookies)
            //{
            //    cookieContainer.Add(cookie);
            //}
            cookieContainer.Add(response.Cookies);
            //crifan.addCookieToCookies(response.Cookies);

            Stream stream = response.GetResponseStream();  //转换为数据流
            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();   //通过StreamReader类读取流
            //reader.Close();
            //stream.Close();
            textBox1.Text = html;


            string url1 = "http://www.yihu.com/hospital/hb/CE95AEF045804CCE86A04F3191BA6FF2.shtml";
            //"http://www.yihu.com/Action/Doctor/NewRegCheck.ashx?time=1417097780646&url=http%3A%2F%2Fwww.yihu.com%2Fdoctor%2FNewOrderList.aspx%3Fdoctorsn%3D710036578%26sn%3D121826776%26saleid%3D3565097&membersn=9824864&memberid=1&ID=121826776";
            //"http://www.yihu.com/Action/Doctor/NewMemberBind.ashx?url=http%3A%2F%2Fwww.yihu.com%2Fdoctor%2FNewOrderList.aspx%3Fdoctorsn%3D710036578%26sn%3D121826776%26saleid%3D3565097&d=1417097479373";
            //"http://www.yihu.com/Action/doctor/NumberWater.ashx?sn=710036578&date=2014-12-02&timeid=1&type=3&weekid=2&url=http%253A//www.yihu.com/doctor/ordernumber.aspx%253Fstate%253D4%2526doctorsn%253D710036578%2526registerdate%253D2014-12-02%2526timeid%253D1%2526weekid%253D2%2526ordertype%253D3%2526watersn%253D39428543&state=4&d=1417096199516";
            //"http://www.yihu.com/";
            string url2 = "http://sr2.yihuimg.com/js/default.js?yj=2014/11/27%2010:46:45";
            string url3 = "http://hm.baidu.com/hm.gif?cc=1&ck=1&cl=24-bit&ds=1680x1050&ep=12856%2C4994&et=3&fl=15.0&ja=1&ln=zh-CN&lo=0&lt=1416881715&nv=0&rnd=376184298&si=50a96b999b752ef15792867dfda15c2a&st=4&su=http%3A%2F%2Fwww.yihu.co";

            request = (HttpWebRequest)HttpWebRequest.Create(url1);
            //HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            //request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            response = (HttpWebResponse)request.GetResponse();
            if (false)
            {
                request = (HttpWebRequest)HttpWebRequest.Create(url2);
                //HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create(url);
                request.CookieContainer = cookieContainer;
                request.Referer = url;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
                request.Method = "GET";
                response = (HttpWebResponse)request.GetResponse();

                request = (HttpWebRequest)HttpWebRequest.Create(url3);
                //HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create(url);
                request.CookieContainer = cookieContainer;
                request.Referer = url;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
                request.Method = "GET";
                response = (HttpWebResponse)request.GetResponse();
            }
            string htmlCharset = "UTF-8";
            //use songtaste's html's charset GB2312 to decode html
            //otherwise will return messy code
            Encoding htmlEncoding = Encoding.GetEncoding(htmlCharset);
            //StreamReader sr = new StreamReader(response.GetResponseStream(), htmlEncoding);
            reader = new StreamReader(response.GetResponseStream(), htmlEncoding);
            string respHtml = reader.ReadToEnd();
            textBox1.Text = respHtml;


            //<a href="/dept/0300/0201148ABD1542B89FAEDB94D1C84C59.shtml" title="成人内科">成人内科</a>
            //string h1userP = @"<a\s+href=""[^""]*""\s+title=""[\u4e00-\u9fa5]*"">(?<h1user>.+?)</a>";//@"<h1\s+class=""h1user"">(?<h1user>.+?)</h1>";
            //string h1userP = @"<a\s+href="".*""\s+title="".*""\s+class="".*"">(?<h1user>.+?)</a>";
            //string h1userP = @"<a\s+href=""[^""]*""\s+title=""[^""]*"">(?<name>.+?)</a>";

            string h1userP = @"<a\s+href=""(?<url>[^""]+?)""\s+title=""[^""]*"">(?<name>.+?)</a>";
            //Match foundH1user = (new Regex(h1userP)).Match(textBox1.Text);
            MatchCollection foundH1user = (new Regex(h1userP)).Matches(textBox1.Text);
            //MatchCollection foundH1user = Regex.Matches(textBox1.Text, h1userP);
            //Match foundH1user = Regex.Match(textBox1.Text, h1userP);
            //textBox1.Text = "";
            foreach (Match m in foundH1user)
            {
                if (m.Success)
                {
                    //extracted the expected h1user's value
                    //textBox1.Text += m.Groups["name"].Value;
                   // textBox1.Text += m.Groups["url"].Value;
                    //textBox1.Text += "\r\n";
                    Departments.Items.Add(m.Groups["name"].Value);
                }
                else
                {
                    textBox1.Text += "Not found h1 user !";
                }
            }
            Departments.SelectedIndex = 0 ;

            Set_NameAndUrl(departmentsArr, foundH1user);

            reader.Close();
            stream.Close();
        }

        private void DepartmentOk_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(departmentsArr[Departments.SelectedIndex].url);

            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = departmentsArr[Departments.SelectedIndex].url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();  //转换为数据流
            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();   //通过StreamReader类读取流
            reader.Close();
            stream.Close();
            textBox1.Text = html;

            //<a target="_blank" href="/doctor/hb/EE8DC590BDB14B069C5F1D95FAC060DD.shtml?sn=22573" title="黄玉兰">黄玉兰</a>
            //string h1userP = @"<a\s+href=""(?<url>[^""]+?)""\s+title=""[^""]*"">(?<name>.+?)</a>";
            string h1userP = @"<a\s+target=""[^""]*""\s+href=""(?<url>[^""]+?)""\s+title=""[^""]*"">(?<name>.+?)</a>";
            MatchCollection foundH1user = (new Regex(h1userP)).Matches(textBox1.Text);
            textBox1.Text = "";
            foreach (Match m in foundH1user)
            {
                if (m.Success)
                {
                    //extracted the expected h1user's value
                    textBox1.Text += m.Groups["name"].Value;
                    textBox1.Text += m.Groups["url"].Value;
                    textBox1.Text += "\r\n";
                    Doctor.Items.Add(m.Groups["name"].Value);
                }
                else
                {
                    textBox1.Text += "Not found h1 user !";
                }
            }
            Doctor.SelectedIndex = 0;

            Set_NameAndUrl(doctorArr, foundH1user);
        }

        private void DocOk_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(doctorArr[Doctor.SelectedIndex].url);

            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = doctorArr[Doctor.SelectedIndex].url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();  //转换为数据流
            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();   //通过StreamReader类读取流
            reader.Close();
            stream.Close();
            textBox1.Text = html;
        }
    }
}
