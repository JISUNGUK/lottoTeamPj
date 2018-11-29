using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
namespace LottoTeamQuiz
{
    public partial class StaticsEX : Form
    {
        List<Statics> staticList = new List<Statics>();
        ImageList img = new ImageList();
        public StaticsEX()
        {
            InitializeComponent();
        }
        public StaticsEX(ImageList Img):this()
        {
            this.img = Img;
            InitializeComponent();
        }

        private void StaticsEX_Load(object sender, EventArgs e)
        {
            indexGrid.Refresh();
            int i = 0;
            HtmlAgilityPack.HtmlWeb HW = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument HD = HW.Load("http://nlotto.co.kr/gameResult.do?method=statByNumber");
           foreach(HtmlAgilityPack.HtmlNode HN in HD.DocumentNode.SelectNodes("//table/tbody/tr"))
            {
                i = 1;
               foreach (HtmlAgilityPack.HtmlNode hn in HD.DocumentNode.SelectNodes("//td"))
                { 
                    if (hn.Attributes[0].Value == "tbbghn")
                        staticList.Add(new Statics(i++, Int32.Parse(hn.InnerText)));
                }
                break;
            }
            indexGrid.DataSource = staticList;
            indexGrid.Columns[0].HeaderText = "숫자";
            indexGrid.Columns[1].HeaderText = "당첨횟수";

            


        }

        private void IndexedGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Statics> descList = new List<Statics>();
            foreach (var v in staticList)
            { 
                        
                        descList.Add(v);
            }

            for (int j = 0; j < descList.Count - 1; j++)
            {
                for (int k = j + 1; k < descList.Count; k++)
                {
                    if (descList[k].Count > descList[j].Count)//당첨횟수가 더 많은 숫자를 위쪽에 나오게함
                    {
                        Statics temps = descList[k];
                        descList[k] = descList[j];
                        descList[j] = temps;
                    }
                    if(descList[k].Count == descList[j].Count)//당첨횟수가 같고 공의 숫자가 더 작은것을 앞으로,,
                    {
                        if(descList[k].No < descList[j].No)
                        {
                            Statics temps = descList[k];
                            descList[k] = descList[j];
                            descList[j] = temps;
                        }
                    }    
                    

                }
            }

            descGrid.DataSource = descList;
            descGrid.Columns[0].HeaderText = "숫자";
            descGrid.Columns[1].HeaderText = "당첨횟수";

        }
    }
}
