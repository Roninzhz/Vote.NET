using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Vote.NET
{
    public partial class Vote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblView.Text = "";
            HttpCookie getCookie = Request.Cookies["Vote"];//读cookie
            if(getCookie == null)
            {
                lblState.Text = "您还未投票";
            }
            else
            {
                lblState.Text = "您已经投过票了";
            }
            GetVote();//读取vote.txt文件
        }
        ArrayList count = new ArrayList();
        //定义读取文件的方法
        protected void GetVote()
        {
            string filepath = Server.MapPath("vote.txt");
            //if (!File.Exists(Server.MapPath("vote.txt")))
            //{
            //    File.CreateText(Server.MapPath("vote.txt"));
            //}
            StreamReader sr = File.OpenText(filepath);
            while (sr.Peek() != -1)
            {
                string str = sr.ReadLine();
                string[] strVote = str.Split('l');
                foreach (string ss in strVote)
                    count.Add(int.Parse(ss));
            }
            sr.Close();
        }
        //定义写文件的方法
        protected void PutVote()
        {
            string filepath = Server.MapPath("vote.txt");
            //if (!File.Exists(Server.MapPath("vote.txt")))
            //{
            //    File.CreateText(Server.MapPath("vote.txt"));
            //}
            StreamWriter sw = new StreamWriter(filepath,false);
            string str = count[0].ToString();
            for(int i = 1; i < count.Count; i++)
            {
                str += "l" + count[i].ToString();
            }
            sw.WriteLine(str);
            sw.Close();
        }

        protected void btnVote_Click(object sender, EventArgs e)
        {
            if (rbtlVote.SelectedIndex != -1)
            {
                //防止重复投票
                HttpCookie getCookie = Request.Cookies["Vote"];
                if (getCookie != null)
                {
                    Response.Write("<script>alert('你已经投过票了，不能重复投票');" +
                        "location='javascript:history.go(-1)'</script>");
                }
                else
                {
                    int k = rbtlVote.SelectedIndex;
                    //报错
                    count[k] = int.Parse(count[k].ToString()) + 1;
                    PutVote();
                    HttpCookie vCookie = new HttpCookie("vote");
                    vCookie.Value = "vote";
                    vCookie.Expires = DateTime.Now.AddDays(1);
                    Response.Write("<script>alert('投票成功');</script>");
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            lblView.Text = "各候选人票数：<br/>";
            for(int i = 0; i < rbtlVote.Items.Count; i++)
            {
                lblView.Text += rbtlVote.Items[i].Value + ":" + "票" + "<br/>";
            }
        }
    }
}