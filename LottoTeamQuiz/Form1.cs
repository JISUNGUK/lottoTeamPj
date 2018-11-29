using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace LottoTeamQuiz
{
    public partial class Form1 : Form
    {
        //디비스트링
        string dbstring = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        #region 이상권작성
        List<Lotto> listLotto = new List<Lotto>();
        List<Lotto> listLotto1 = new List<Lotto>();
        List<DetailLotto> listDetailLotto = new List<DetailLotto>();
        private Uri uri;
        #endregion

        List<Lotto> lottos = new List<Lotto>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            grid_Viewer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid_Viewer.MultiSelect = false;


            //DBClear();
            // 번호를 구해서
            LottoParser(GetFinalNum());
        }

        /// <summary>
        /// 디비 삭제함...
        /// </summary>
        void DBClear()
        {
            using (SqlConnection con = new SqlConnection(dbstring))
            using (SqlCommand com = new SqlCommand())
            {
                con.Open();

                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "DeleteLotto";
                com.ExecuteNonQuery();
            }
            MessageBox.Show("디비지웠어요");
        }

        private void LottoParser(int final)
        {
            using (SqlConnection con = new SqlConnection(dbstring))
            {
                con.Open();
                bool flag = false;

                // 못읽는거 체크 여기 지워야함
                //final = -1;

                while (true)
                {
                    //정지구분
                    //if (final == 30) flag = true;

                    string uriString = ConfigurationManager.AppSettings["url1"];
                    final += 1;
                    uriString += "&drwNo=" + final;

                    uri = new Uri(uriString);

                    #region 유효데이터 찾고 리스트 추가 시퀀스
                    HttpWebResponse response = WebRequest.Create(uri).GetResponse() as HttpWebResponse;
                    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                    string webString = streamReader.ReadToEnd();

                    HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(webString);

                    //  최신회차의 로또가 있는지를 검사함
                    //  DB에 이전 회차까지의 당첨번호가 있다면 <DB의 내역을 가져온다>
                    //  만약 DB에 당첨번호가 없다면 < 파싱해 0 ~ 최신회차까지의 데이터를 전부 파싱한다.
                    if (LottoValidChk(htmlDoc))
                    {
                        MessageBox.Show("최신회차의 로또가 아직 없어요.");
                        //  최신회차가 없고 데이터베이스에 저장된 인스턴스의 마지막 회차가 0이 아니라면
                        //  결국 디비가 최신이라는 의미임
                        if (GetFinalNum() != 0)
                        {
                            DataSet();
                            break;
                        }
                    }

                    Lotto lotto = new Lotto();
                    string getInfo = htmlDoc.DocumentNode.SelectNodes("//meta")[3].GetAttributeValue("content", "");
                    lotto.LottoNum = Int32.Parse(getInfo.Remove(getInfo.IndexOf("회")).Remove(0, 4));
                    lotto.WinningNum = getInfo.Remove(getInfo.IndexOf(".")).Remove(0, getInfo.IndexOf("호") + 1);
                    lotto.Etc = getInfo.Remove(getInfo.LastIndexOf(".")).Remove(0, getInfo.IndexOf(".") + 1);

                    listLotto.Add(lotto);

                    #endregion

                    #region 상권이디테일
                    DetailLotto detailLotto = new DetailLotto();

                    detailLotto.LottoNum = Int32.Parse(getInfo.Remove(getInfo.IndexOf("회")).Remove(0, 4));

                    detailLotto.Rank = new int[5] { Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.InnerText.Remove(1)), Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.InnerText.Remove(1)), Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.InnerText.Remove(1)), Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.InnerText.Remove(1)), Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.InnerText.Remove(1)) };

                    detailLotto.Price = new string[5] { htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.InnerText.Replace("원", ""), htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.InnerText.Replace("원", ""), htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.InnerText.Replace("원", ""), htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.InnerText.Replace("원", ""), htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.InnerText.Replace("원", "") };

                    detailLotto.Person = new int[5] { Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Replace(",", "")), Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Replace(",", "")), Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Replace(",", "")), Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Replace(",", "")), Int32.Parse(htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText.Replace(",", "")) };

                    detailLotto.PersonPrice = new string[5] { htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText, htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText, htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText, htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText, htmlDoc.DocumentNode.SelectNodes("//tbody")[0].FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText };

                    listDetailLotto.Add(detailLotto);
                    #endregion

                    DBInsert(con, lotto);
                }
                DataSet();
            }

        }

        /// <summary>
        /// 디비에 insert함 타겟테이블은 lotto임
        /// 추후 디테일 Insert할 경우 오버라이드 할것
        /// </summary>
        /// <param name="con">SqlConn 객체</param>
        /// <param name="lotto">Lotto 클래스 객체 넣어줄것</param>
        private static void DBInsert(SqlConnection con, Lotto lotto)
        {
            #region DB Insert 시퀀스
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "InsertLotto";

            com.Parameters.AddWithValue("@lottonum", lotto.LottoNum);
            com.Parameters.AddWithValue("@winningnum", lotto.WinningNum);
            com.Parameters.AddWithValue("@etc", lotto.Etc);

            com.ExecuteNonQuery();

            #endregion
        }

        /// <summary>
        /// DataShow -> DataSet으로 .. 리스트에 값을 넣어주기로 함
        /// </summary>
        void DataSet()
        {
            using(SqlConnection con=new SqlConnection(dbstring))
            using (SqlCommand com = new SqlCommand())
            {
                con.Open();
                com.Connection = con;
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.CommandText = "GetEntryLotto";

                SqlDataReader reader = com.ExecuteReader();

                cbo_lottoNum.Items.Add("전체");
                while (reader.Read())
                {
                    Lotto lotto = new Lotto(Convert.ToInt32(reader[0].ToString()), reader[1].ToString(), reader[2].ToString());
                    lottos.Add(lotto);

                    cbo_lottoNum.Items.Add(lotto.LottoNum);
                }
                DataShow(lottos);
            }
        }

        private void DataShow(List<Lotto> list)
        {
            grid_Viewer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid_Viewer.DataSource = list;
        }


        /// <summary>
        /// 로또번호를 파싱해 DB에 저장할수있도록 문자를 자르고 숫자만 남겨줌
        /// </summary>
        /// <param name="lottonum">입력한 로또파싱</param>
        /// <returns></returns>
        private static string SplitNum(string lottonum)
        {
            lottonum = lottonum.Remove(0, lottonum.IndexOf("당첨번호") + 4);
            lottonum = lottonum.Remove(lottonum.IndexOf("."));

            return lottonum;
        }
        /// <summary>
        /// 숫자를 배열로 잘라줌
        /// </summary>
        /// <param name="lottonum"></param>
        /// <returns></returns>
        private static string[] Split(string lottonum)
        {
            string[] num = new string[6];
            // 11,16,19,21,27,31+30
            num = lottonum.Replace(" ", "").Split(',', '+');

            return num;
        }

        /// <summary>
        /// 리스트를 받아 그에 해당하는 번호의 이미지를 출력함
        /// </summary>
        /// <param name="list">당첨번호</param>
        void ImageShow(List<int> list)
        {
            WebClient web = new WebClient();

            for (int i = 0; i < list.Count; i++)
            {
                Stream stream = web.OpenRead(@"http://www.nlotto.co.kr/img/common_new/ball_" + list[i].ToString() + ".png");
                Image image = Image.FromStream(stream);

                largImgList.Images.Add(i.ToString(), image);
            }

            //이미지리스트 사이즈 색 변경
            largImgList.ImageSize = new Size(70, 70);
            largImgList.ColorDepth = ColorDepth.Depth32Bit;

            list_Img.View = View.LargeIcon;

            list_Img.LargeImageList = largImgList;


            for (int i = 0; i < largImgList.Images.Count; i++)
            {
                list_Img.Items.Add("", i.ToString());
            }


        }
        void ImageShow(string[] list)
        {
            WebClient web = new WebClient();
            largImgList.Images.Clear();
            list_Img.Clear();

            for (int i = 0; i < list.Length; i++)
            {
                Stream stream = web.OpenRead(@"http://www.nlotto.co.kr/img/common_new/ball_" + list[i].ToString() + ".png");
                Image image = Image.FromStream(stream);

                largImgList.Images.Add(i.ToString(), image);

            }

            //이미지리스트 사이즈 색 변경
            largImgList.ImageSize = new Size(70, 70);
            largImgList.ColorDepth = ColorDepth.Depth32Bit;

            list_Img.View = View.LargeIcon;

            list_Img.LargeImageList = largImgList;


            for (int i = 0; i < largImgList.Images.Count; i++)
            {
                list_Img.Items.Add("", i.ToString());
            }
        }

        /// <summary>
        /// 콤보박스 변경시 해당 회차의 로또 정보가 나옴, 전체도 나오도록 추가했음
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_Viewer.DataSource = null;

            if (cbo_lottoNum.Text=="전체")
            {
                grid_Viewer.DataSource = lottos;
                return;
            }
            else
            {
                foreach (var item in lottos)
                {
                    if (item.LottoNum == Convert.ToInt32(cbo_lottoNum.Text))
                    {
                        listLotto1.Clear();
                        listLotto1.Add(new Lotto(item.LottoNum, item.WinningNum, item.Etc));
                    }
                }
            }
            grid_Viewer.DataSource = listLotto1;
            ImageShow(Split(listLotto1[0].WinningNum));
            
        }

        /// <summary>
        /// 그리드 뷰의 아이템 클릭시 해당 디테일 내용과, 이미지를 show 함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_Viewer_SelectionChanged(object sender, EventArgs e)
        {
            var pick = grid_Viewer.CurrentRow.Cells[1].Value.ToString();
            ImageShow(Split(pick));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_Analyze_Click(object sender, EventArgs e)
        {
            GetFinalNum();
            FrmAnalyze form = new FrmAnalyze();
            form.Show();

        }

        /// <summary>
        /// DB에 저장된 로또 마지막 회차를 반환함
        /// </summary>
        /// <returns>false 시 0 반환함 </returns>
        int GetFinalNum()
        {
            using (SqlConnection con = new SqlConnection(dbstring))
            using (SqlCommand com = new SqlCommand())
            {
                con.Open();
                com.Connection = con;
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "GetFinalNum";
                int num = 0;

                try
                {
                    var dr = com.ExecuteReader();
                    while (dr.Read())
                    {
                        num = (int)dr[0];
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("데이터베이스에 로또의 내역이 없습니다..\n서버에서 로드합니다..");
                    return num;
                }
                return num;
            }
        }

        /// <summary>
        /// 회차에 당첨번호가 있는지를 체크함 , 당첨번호가 없다면 그 회차는 아직 발표가 나지 않음을 뜻함
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>false : 당첨번호 있음 , true : 당첨번호 없음</returns>
        bool LottoValidChk(HtmlAgilityPack.HtmlDocument doc)
        {
            //doc.DocumentNode.SelectNodes("//head/meta")
            foreach (HtmlAgilityPack.HtmlNode item in doc.DocumentNode.SelectNodes("//head/meta"))
            {
                if (item.Attributes[0].Value == "desc")
                {
                    if (item.Attributes[2].Value.Contains(",,,,,+."))
                    {
                        //MessageBox.Show(item.Attributes[2].Value);
                        return true;
                        //  당첨번호가 없다!
                    }
                }
            }
            return false;
        }
    }

}
