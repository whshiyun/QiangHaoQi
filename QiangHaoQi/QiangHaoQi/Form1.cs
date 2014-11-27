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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            crifanLib crifan = new crifanLib();

            //textBox1.Text = "aaaaaaaaaaaaa";
            string url = "http://jsonp.yihu.com/action/login/login.ashx?d=1416883229934&loginid="+username.Text+"&pwd="+password.Text+"&type=1&CkSavePwd=n&callback=_jqjsp&_1416883229934=";
            CookieContainer cookieContainer = new CookieContainer();
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


            string url1 = "http://www.yihu.com/";//"http://www.yihu.com/#";
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
