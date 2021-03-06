﻿using System;
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
using LitJson;
using System.Web;
using System.Threading;

namespace QiangHaoQi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            username.Text = "13297912053";
            password.Text = "123654";
        }

        private class NameAndUrl
        {
            public NameAndUrl(string name, string url, string sn="")
            {
                this.name = name;
                this.url = url+"?sn="+sn;
                this.sn = sn;
            }
            public string name;
            public string url;
            public string sn;
        }

        private class DocInfo
        {
            public DocInfo(string name, string id, string sn)
            {
                this.name = name;
                this.id = id;
                this.sn = sn;
            }
            public string name;
            public string id;
            public string sn;
        }

        public class SchedulingTableInfo
        {
            public SchedulingTableInfo(string date, string timeId, string weekid)
            {
                this.date = date;
                this.timeId = timeId;
                this.weekid = weekid;
            }
            public string date;
            public string timeId;
            public string weekid;
        }

        public class PermitInfo
        {
            public PermitInfo(string Code, string LockOrderID, string WaterID, string HinStr, string Url, string Time)
            {
                this.Code = Code;
                this.LockOrderID = LockOrderID;
                this.WaterID = WaterID;
                this.HinStr = HinStr;
                this.Url = Url;
                this.Time = Time;
            }
            public string Code;
            public string LockOrderID;
            public string WaterID;
            public string HinStr;
            public string Url;
            public string Time;
        }

        public class PersonInfo
        {
            public PersonInfo(string name, string memberID, string memberSN)
            {
                this.name = name;
                this.memberID = memberID;
                this.memberSN = memberSN;
            }
            public string name;
            public string memberID;
            public string memberSN;
            public string IDCard;
            public string year;
            public string month;
            public string day;
        }

        private const string baseUrl = "http://www.yihu.com/";
        private List<NameAndUrl> departmentsArr = new List<NameAndUrl>();
        private List<NameAndUrl> doctorArr = new List<NameAndUrl>();
        //private List<DocInfo> doctorInfo = new List<DocInfo>();
        private CookieContainer cookieContainer = new CookieContainer();
        private List<SchedulingTableInfo> schedulingTableInfo = new List<SchedulingTableInfo>();
        private List<PersonInfo> personInfo = new List<PersonInfo>();
        private PermitInfo permitInfo;

        private void Set_NameAndUrl(List<NameAndUrl> list, MatchCollection nameAndUrl)
        {
            foreach (Match m in nameAndUrl)
            {
                //this.comb_type.Items.Add(new ControlItem(dr,dr["answertypename"].ToString()));
                //Departments.Items.Add(m.Groups["name"].Value);
                list.Add(new NameAndUrl(m.Groups["name"].Value, baseUrl+m.Groups["url"].Value, m.Groups["sn"].Value));
            }
            //Departments.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            departmentsArr.Clear();
            //crifanLib crifan = new crifanLib();

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
            //if (false)
            //{
            //    request = (HttpWebRequest)HttpWebRequest.Create(url2);
            //    //HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create(url);
            //    request.CookieContainer = cookieContainer;
            //    request.Referer = url;
            //    request.ContentType = "application/x-www-form-urlencoded";
            //    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            //    request.Method = "GET";
            //    response = (HttpWebResponse)request.GetResponse();

            //    request = (HttpWebRequest)HttpWebRequest.Create(url3);
            //    //HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create(url);
            //    request.CookieContainer = cookieContainer;
            //    request.Referer = url;
            //    request.ContentType = "application/x-www-form-urlencoded";
            //    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            //    request.Method = "GET";
            //    response = (HttpWebResponse)request.GetResponse();
            //}
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

            Departments.Items.Clear();
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
            doctorArr.Clear();

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

            //(?<=\s)\d+(?=\s)
            //<a target="_blank" href="/doctor/hb/EE8DC590BDB14B069C5F1D95FAC060DD.shtml?sn=22573" title="黄玉兰">黄玉兰</a>
            //string h1userP = @"<a\s+href=""(?<url>[^""]+?)""\s+title=""[^""]*"">(?<name>.+?)</a>";
            //string h1userP = @"<a\s+target=""[^""]*""\s+href=""(?<url>[^""]+?)""\s+title=""[^""]*"">(?<name>.+?)</a>";
            string h1userP = @"<a\s+target=""_blank""\s+href=""(?<url>[^\?]+?)\?sn=(?<sn>[^""]+?)""\s+title=""[^""]*"">(?<name>.+?)</a>";
            MatchCollection foundH1user = (new Regex(h1userP)).Matches(textBox1.Text);

            textBox1.Text = "";
            Doctor.Items.Clear();
            foreach (Match m in foundH1user)
            {
                if (m.Success)
                {
                    //extracted the expected h1user's value
                    textBox1.Text += m.Groups["name"].Value;
                    textBox1.Text += m.Groups["url"].Value;
                    textBox1.Text += m.Groups["sn"].Value;
                    textBox1.Text += "\r\n";
                    Doctor.Items.Add(m.Groups["name"].Value);
                }
                else
                {
                    textBox1.Text += "Not found h1 user !";
                }
            }
            if(Doctor.Items.Count != 0)
                Doctor.SelectedIndex = 0;

            Set_NameAndUrl(doctorArr, foundH1user);
        }

        private void DocOk_Click(object sender, EventArgs e)
        {
            schedulingTableInfo.Clear();
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(doctorArr[Doctor.SelectedIndex].url);

            ////填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            //request.CookieContainer = cookieContainer;
            //request.Referer = doctorArr[Doctor.SelectedIndex].url;
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.Accept = "*/*";
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            //request.Method = "GET";

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Stream stream = response.GetResponseStream();  //转换为数据流
            //StreamReader reader = new StreamReader(stream);
            //string html = reader.ReadToEnd();   //通过StreamReader类读取流
            //reader.Close();
            //stream.Close();
            //textBox1.Text = html;
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(doctorArr[Doctor.SelectedIndex].url);

            string url = "http://guahaojsonp.yihu.com/action/GuaHao/ArangeJson.ashx?d=&page=1&viewtime=1&docid="+doctorArr[Doctor.SelectedIndex].sn+"&docsn="+doctorArr[Doctor.SelectedIndex].sn;
            string url1 = "http://guahaojsonp.yihu.com/action/GuaHao/ArangeJson.ashx?d=&page=2&viewtime=1&docid=" + doctorArr[Doctor.SelectedIndex].sn + "&docsn=" + doctorArr[Doctor.SelectedIndex].sn;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();  //转换为数据流
            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();   //通过StreamReader类读取流
            //reader.Close();
            //stream.Close();
            textBox1.Text = html;
            JsonData jsd;
            
           // Encoding htmlEncoding = Encoding.GetEncoding("UTF-8").GetString();
            //htmlEncoding.GetString()
            try
            {
                string h1userP = @"\((?<js>[^\)]+?)\)";
                Match foundH1user = (new Regex(h1userP)).Match(textBox1.Text);
                jsd = JsonMapper.ToObject(foundH1user.Groups["js"].Value);
                //textBox1.Text = (string)jsd["IsLogin"];
                //textBox1.Text = jsd["ArrangeList"][0].ToString();
                //textBox1.Text = jsd["ArrangeList"].IsArray.ToString();
                //print (frame["cmd"]);
                //print (frame["data"]);
                //DataProc((byte)frame["cmd"], (JsonData)frame["data"]);
                if (jsd["ArrangeList"].IsArray)
                {
                    TimeCh.Items.Clear();
                    foreach (JsonData j in jsd["ArrangeList"])
                    {
                        string outStr = "";
                        string[] strlist = j["ShowMsg"].ToString().Replace("%", "").Split('u'); 
                        //string[] strlist = j["ShowMsg"].ToString().Replace("%u", "/").Split('/');
                        for (int i = 1; i < strlist.Length; i++)
                        {
                            if (strlist[i].Length > 4)
                            {
                                string str1 = strlist[i].Substring(0,4);
                                string str2 = strlist[i].Substring(4);
                                outStr += (char)int.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                                outStr += str2;
                            }
                            else
                            {
                                //将unicode字符转为10进制整数，然后转为char中文字符  
                                outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                            }
                        }  
                        TimeCh.Items.Add("星期：" + j["WeekIndex"].ToString() +
                            "(" + j["RegDate"].ToString() + ")" +
                            (j["TimeId"].ToString() == "1" ? "上午" : "下午") + "," +
                            outStr);

                        schedulingTableInfo.Add(new SchedulingTableInfo(j["RegDate"].ToString(), j["TimeId"].ToString(), j["WeekIndex"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                //print(ex);
                //return;
                textBox1.Text = "json error";
            }
            Thread.Sleep(2000);//两次请求太快，网站可能会阻止第二次请求
            request = (HttpWebRequest)HttpWebRequest.Create(url1);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();  //转换为数据流
            reader = new StreamReader(stream);
            html = reader.ReadToEnd();   //通过StreamReader类读取流
            reader.Close();
            stream.Close();
            textBox1.Text = html;

            // Encoding htmlEncoding = Encoding.GetEncoding("UTF-8").GetString();
            //htmlEncoding.GetString()
            try
            {
                string h1userP = @"\((?<js>[^\)]+?)\)";
                Match foundH1user = (new Regex(h1userP)).Match(textBox1.Text);
                jsd = JsonMapper.ToObject(foundH1user.Groups["js"].Value);
                //textBox1.Text = (string)jsd["IsLogin"];
                //textBox1.Text = jsd["ArrangeList"][0].ToString();
                //textBox1.Text = jsd["ArrangeList"].IsArray.ToString();
                //print (frame["cmd"]);
                //print (frame["data"]);
                //DataProc((byte)frame["cmd"], (JsonData)frame["data"]);
                if (jsd["ArrangeList"].IsArray)
                {
                    foreach (JsonData j in jsd["ArrangeList"])
                    {
                        string outStr = "";
                        string[] strlist = j["ShowMsg"].ToString().Replace("%", "").Split('u');
                        for (int i = 1; i < strlist.Length; i++)
                        {
                            if (strlist[i].Length > 4)
                            {
                                string str1 = strlist[i].Substring(0, 4);
                                string str2 = strlist[i].Substring(4);
                                outStr += (char)int.Parse(str1, System.Globalization.NumberStyles.HexNumber);
                                outStr += str2;
                            }
                            else
                            {
                                //将unicode字符转为10进制整数，然后转为char中文字符  
                                outStr += (char)int.Parse(strlist[i], System.Globalization.NumberStyles.HexNumber);
                            }
                        }
                        TimeCh.Items.Add("星期：" + j["WeekIndex"].ToString() +
                            "(" + j["RegDate"].ToString() + ")" +
                            (j["TimeId"].ToString() == "1" ? "上午" : "下午") + "," +
                            outStr);

                        schedulingTableInfo.Add(new SchedulingTableInfo(j["RegDate"].ToString(), j["TimeId"].ToString(), j["WeekIndex"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                //print(ex);
                //return;
                textBox1.Text = "json error";
            }


            if (TimeCh.Items.Count != 0)
                TimeCh.SelectedIndex = 0;
        }

        private void TimeOk_Click(object sender, EventArgs e)
        {
            PersonCh.Items.Clear();
            string url = "http://www.yihu.com/Action/doctor/NumberWater.ashx?sn=" + doctorArr[Doctor.SelectedIndex].sn +
                "&date=" + schedulingTableInfo[TimeCh.SelectedIndex].date + "&timeid=" + schedulingTableInfo[TimeCh.SelectedIndex].timeId +
                "&type=3&weekid=" + schedulingTableInfo[TimeCh.SelectedIndex].weekid + "&url=&state=4&d=";

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stream = response.GetResponseStream();  //转换为数据流
            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();   //通过StreamReader类读取流
            //reader.Close();
            //stream.Close();
            textBox1.Text = html;

            //onclick="CheckUser(122037417)"
            //(?<url>[^\?]+?)
            string h1userP = @"onclick=""CheckUser\((?<requestSN>.+?)\)""";
            MatchCollection foundH1user = (new Regex(h1userP)).Matches(textBox1.Text);

            textBox1.Text = "";
            foreach (Match m in foundH1user)
            {
                if (m.Success)
                {
                    //extracted the expected h1user's value
                    textBox1.Text += m.Groups["requestSN"].Value;
                    textBox1.Text += "\r\n";
                }
                else
                {
                    textBox1.Text += "Not found h1 user !";
                }
            }

            url = "http://www.yihu.com/action/doctor/guahaocheck1.ashx";
            request = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "POST";

            Dictionary<string, string> keyvalues = new Dictionary<string, string>();
            keyvalues.Add("doctorsn", doctorArr[Doctor.SelectedIndex].sn);
            keyvalues.Add("sn", foundH1user[0].Groups["requestSN"].Value);
            keyvalues.Add("d", "");

            Encoding encoding;
            encoding = Encoding.UTF8;

            string postData = null;
            // 将数据项转变成 name1=value1&name2=value2 的形式
            if (keyvalues != null && keyvalues.Count > 0)
            {
                postData = string.Join("&",
                        (from kvp in keyvalues
                         let item = kvp.Key + "=" + HttpUtility.UrlEncode(kvp.Value)
                         select item
                         ).ToArray()
                     );
            }

            byte[] buffer = encoding.GetBytes(postData);
            request.ContentLength = buffer.Length;

            Stream stream1 = request.GetRequestStream();
            stream1.Write(buffer, 0, buffer.Length);
            stream1.Close();



            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();  //转换为数据流
            reader = new StreamReader(stream);
            html = reader.ReadToEnd();   //通过StreamReader类读取流
            reader.Close();
            stream.Close();
            textBox1.Text = html;

            JsonData jsd;
            try
            {
                jsd = JsonMapper.ToObject(html);
                permitInfo = new PermitInfo(jsd["Code"].ToString(), jsd["LockOrderID"].ToString(), jsd["WaterID"].ToString(),
                    jsd["HinStr"].ToString(), jsd["Url"].ToString(), jsd["Time"].ToString());
                //textBox1.Text = jsd["Url"].ToString();
                //textBox1.Text = jsd["ArrangeList"][0].ToString();
                //textBox1.Text = jsd["ArrangeList"].IsArray.ToString();
                //print (frame["cmd"]);
                //print (frame["data"]);
                //DataProc((byte)frame["cmd"], (JsonData)frame["data"]);

            }
            catch (Exception ex)
            {
                //print(ex);
                //return;
                textBox1.Text = "json error";
            }

            url = "http://www.yihu.com" + permitInfo.Url;
            HttpWebRequest request1 = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request1.CookieContainer = cookieContainer;
            request1.Referer = url;
            request1.ContentType = "application/x-www-form-urlencoded";
            request1.Accept = "*/*";
            request1.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request1.Method = "GET";

            HttpWebResponse response1 = (HttpWebResponse)request1.GetResponse();

            stream = response1.GetResponseStream();  //转换为数据流
            reader = new StreamReader(stream);
            html = reader.ReadToEnd();   //通过StreamReader类读取流
            reader.Close();
            stream.Close();
            textBox1.Text = url;//html;


            url = "http://www.yihu.com/Action/Doctor/NewMemberBind.ashx?url=&d=";
            request = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();  //转换为数据流
            reader = new StreamReader(stream);
            html = reader.ReadToEnd();   //通过StreamReader类读取流
            reader.Close();
            stream.Close();
            textBox1.Text = html;
            //http://www.yihu.com/Action/Doctor/NewMemberBind.ashx?url=&d=
            //onclick="NewBindMemberInfo(1,9824864);">宋师</div>
            h1userP = @"onclick=""NewBindMemberInfo\((?<memberID>.+?),(?<memberSN>.+?)\);"">(?<name>.+?)</div>";
            foundH1user = (new Regex(h1userP)).Matches(textBox1.Text);

            textBox1.Text = "";
            foreach (Match m in foundH1user)
            {
                if (m.Success)
                {
                    //extracted the expected h1user's value
                    textBox1.Text += m.Groups["name"].Value;
                    textBox1.Text += m.Groups["memberID"].Value;
                    textBox1.Text += m.Groups["memberSN"].Value;
                    textBox1.Text += "\r\n";

                    PersonCh.Items.Add(m.Groups["name"].Value);
                    personInfo.Add(new PersonInfo(m.Groups["name"].Value, m.Groups["memberID"].Value, m.Groups["memberSN"].Value));
                }
                else
                {
                    textBox1.Text += "Not found h1 user !";
                }
            }
            //string url = "http://www.yihu.com/Action/Doctor/NewMemberBind.ashx?url=&d=";
            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            ////填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            //request.CookieContainer = cookieContainer;
            //request.Referer = url;
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.Accept = "*/*";
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            //request.Method = "GET";

            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Stream stream = response.GetResponseStream();  //转换为数据流
            //StreamReader reader = new StreamReader(stream);
            //string html = reader.ReadToEnd();   //通过StreamReader类读取流
            //reader.Close();
            //stream.Close();
            //textBox1.Text = html;
            ////http://www.yihu.com/Action/Doctor/NewMemberBind.ashx?url=&d=
            ////onclick="NewBindMemberInfo(1,9824864);">宋师</div>
            //string h1userP = @"onclick=""NewBindMemberInfo\((?<memberID>.+?),(?<memberSN>.+?)\);"">(?<name>.+?)</div>";
            //MatchCollection foundH1user = (new Regex(h1userP)).Matches(textBox1.Text);

            //textBox1.Text = "";
            //foreach (Match m in foundH1user)
            //{
            //    if (m.Success)
            //    {
            //        //extracted the expected h1user's value
            //        textBox1.Text += m.Groups["name"].Value;
            //        textBox1.Text += m.Groups["memberID"].Value;
            //        textBox1.Text += m.Groups["memberSN"].Value;
            //        textBox1.Text += "\r\n";

            //        PersonCh.Items.Add(m.Groups["name"].Value);
            //        personInfo.Add(new PersonInfo(m.Groups["name"].Value, m.Groups["memberID"].Value, m.Groups["memberSN"].Value));
            //    }
            //    else
            //    {
            //        textBox1.Text += "Not found h1 user !";
            //    }
            //}
            if (PersonCh.Items.Count != 0)
                PersonCh.SelectedIndex = 0;
        }

        private void ChoosePerson_Click(object sender, EventArgs e)
        {
            //http://www.yihu.com/Action/Doctor/NewRegCheck.ashx?time=&url=&membersn=9824864&memberid=1&ID=122433029
            string url = "http://www.yihu.com/Action/Doctor/NewRegCheck.ashx?time=&url=&membersn=" + personInfo[PersonCh.SelectedIndex].memberSN
                + "&memberid=" + personInfo[PersonCh.SelectedIndex].memberID + "&ID=" + permitInfo.WaterID;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
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

            //id="hidIdentityNo" value="42098219871205564x" />
            string h1userP = @"id=""hidIdentityNo""\s+value=""(?<IDCard>.+?)""\s+/>";
            Match foundH1user = (new Regex(h1userP)).Match(textBox1.Text);
            IDCardText.Text = foundH1user.Groups["IDCard"].Value;
            personInfo[PersonCh.SelectedIndex].IDCard = foundH1user.Groups["IDCard"].Value;
            personInfo[PersonCh.SelectedIndex].year = foundH1user.Groups["IDCard"].Value.Substring(6, 4);
            personInfo[PersonCh.SelectedIndex].month = foundH1user.Groups["IDCard"].Value.Substring(10, 2);
            personInfo[PersonCh.SelectedIndex].day = foundH1user.Groups["IDCard"].Value.Substring(12, 2);

            textBox1.Text = personInfo[PersonCh.SelectedIndex].year+"-";
            textBox1.Text += personInfo[PersonCh.SelectedIndex].month+"-";
            textBox1.Text += personInfo[PersonCh.SelectedIndex].day;
        }

        private void IDCardOK_Click(object sender, EventArgs e)
        {
            //http://www.yihu.com/Action/UpDateUser.ashx?up=0&cardup=0&
            //id=122037417&memberid=1&membersn=9824864&provinceid=17&ghthospitalid=1214&IdentityNo=42098219871205564x&
            //clinicCardNo=%E5%88%9D%E8%AF%8A&othercard=%E6%97%A0%E5%8C%BB%E4%BF%9D%E5%8D%A1&
            //year=1987&month=12&day=5&d=1417445132505&url=http://www.yihu.com/doctor/NewOrderList.aspx?doctorsn=22598&sn=122037417&saleid=3605236
            string url = "http://www.yihu.com/Action/UpDateUser.ashx?up=0&cardup=0&id=" + permitInfo.WaterID +
            "&memberid=" + personInfo[PersonCh.SelectedIndex].memberID + "&membersn=" + personInfo[PersonCh.SelectedIndex].memberSN +
            "&provinceid=17&ghthospitalid=1214&IdentityNo=" + personInfo[PersonCh.SelectedIndex].IDCard +
            "&clinicCardNo=%E5%88%9D%E8%AF%8A&othercard=%E6%97%A0%E5%8C%BB%E4%BF%9D%E5%8D%A1&year=" + personInfo[PersonCh.SelectedIndex].year +
            "&month=" + personInfo[PersonCh.SelectedIndex].month +
            "&day=" + personInfo[PersonCh.SelectedIndex].day + "&d=&url=" + permitInfo.Url;
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
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

            //url = "http://www.yihu.com/shop/pay/";
            //request = (HttpWebRequest)HttpWebRequest.Create(url);
            ////填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            //request.CookieContainer = cookieContainer;
            //request.Referer = url;
            //request.ContentType = "application/x-www-form-urlencoded";
            //request.Accept = "*/*";
            //request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            //request.Method = "GET";

            //response = (HttpWebResponse)request.GetResponse();

            //stream = response.GetResponseStream();  //转换为数据流
            //reader = new StreamReader(stream);
            //html = reader.ReadToEnd();   //通过StreamReader类读取流
            //reader.Close();
            //stream.Close();
            //textBox1.Text = html;

            //string h1userP1 = @"id=""__VIEWSTATE""\s+value=""(?<VIEWSTATE>[^""]+?)""";
            //Match foundH1user1 = (new Regex(h1userP1)).Match(textBox1.Text);
            //string h1userP2 = @"id=""__EVENTVALIDATION""\s+value=""(?<EVENTVALIDATION>[^""]+?)""";
            //Match foundH1user2 = (new Regex(h1userP2)).Match(textBox1.Text);

            //textBox1.Text = "";
            ////foreach (Match m in foundH1user)
            ////{
            ////    if (m.Success)
            ////    {
            ////        //extracted the expected h1user's value
            ////        textBox1.Text += m.Groups["VIEWSTATE"].Value;
            ////        textBox1.Text += "\r\n";
            ////        textBox1.Text += m.Groups["EVENTVALIDATION"].Value;
            ////        textBox1.Text += "\r\n";
            ////    }
            ////    else
            ////    {
            ////        textBox1.Text += "Not found h1 user !";
            ////    }
            ////}
            //if (foundH1user1.Success)
            //{
            //    textBox1.Text += foundH1user1.Groups["VIEWSTATE"].Value;
            //    textBox1.Text += "\r\n";
            //}
            //if (foundH1user2.Success)
            //{
            //    textBox1.Text += foundH1user2.Groups["EVENTVALIDATION"].Value;
            //    textBox1.Text += "\r\n";
            //}

            url = "http://www.yihu.com/shop/pay/";
            request = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "GET";

            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();  //转换为数据流
            reader = new StreamReader(stream);
            html = reader.ReadToEnd();   //通过StreamReader类读取流
            reader.Close();
            stream.Close();
            textBox1.Text = html;


            url = "http://www.yihu.com/Shop/pay/";
            request = (HttpWebRequest)HttpWebRequest.Create(url);
            //填充数据包的信息，填充的值都是在数据包查找对应的信息得到的
            request.CookieContainer = cookieContainer;
            request.Referer = url;
            request.ContentType = "application/x-www-form-urlencoded";
            request.Accept = "*/*";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/38.0.2125.111 Safari/537.36";
            request.Method = "POST";

            Dictionary<string, string> keyvalues = new Dictionary<string, string>();
            keyvalues.Add("__VIEWSTATE", "/wEPDwUJNDczNTQ1ODY2D2QWBGYPZBYCAgIPFgIeBXN0eWxlZBYCAgEPFgIeCWlubmVyaHRtbAUG5a6L5biIZAIBD2QWBAIBDxYCHgdWaXNpYmxlZ2QCBg8PZBYCHgdvbmNsaWNrBRNyZXR1cm4gU2VuZE90aGVyKCk7ZGSMh7G1UIDQ/jqJxoKZKZL/GjLHcNFAkzrSBwWjm/Sq8Q==");
            keyvalues.Add("__EVENTVALIDATION", "/wEWBwLyh8D7BALEku31BQLyyqfVAQKatLeqAQK5jfL3BQLetsaBCQKRt/i8DqCvjrtutS+T6hvZJJvbpBG6T5Yqk0HGNI4G7XNZCc2A");
            keyvalues.Add("txtphone", "");
            keyvalues.Add("yuepaytype", "99");
            keyvalues.Add("ConfirmPaymentBtn", "确定支付");
            keyvalues.Add("PayTypeID", "99");
            keyvalues.Add("ProductType", "1");
            keyvalues.Add("cardBalanceType", "99");

            Encoding encoding;
            encoding = Encoding.UTF8;

            string postData = null;
            // 将数据项转变成 name1=value1&name2=value2 的形式
            if (keyvalues != null && keyvalues.Count > 0)
            {
                postData = string.Join("&",
                        (from kvp in keyvalues
                         let item = kvp.Key + "=" + HttpUtility.UrlEncode(kvp.Value)
                         select item
                         ).ToArray()
                     );
            }

            byte[] buffer = encoding.GetBytes(postData);
            request.ContentLength = buffer.Length;

            Stream stream1 = request.GetRequestStream();
            stream1.Write(buffer, 0, buffer.Length);
            stream1.Close();

            response = (HttpWebResponse)request.GetResponse();

            stream = response.GetResponseStream();  //转换为数据流
            reader = new StreamReader(stream);
            html = reader.ReadToEnd();   //通过StreamReader类读取流
            reader.Close();
            stream.Close();
            textBox1.Text = html;
        }

    }
}
