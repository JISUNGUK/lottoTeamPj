using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoTeamQuiz
{
    class DetailLotto
    {
        #region 이상권 작성
        private int lottoNum; // 회차
        private int[] rank; // 순위
        private string[] price; // 등위별 총 당첨금액
        private int[] person; // 당첨인원수
        private string[] personPrice; // 한사람당 받는 금액

        public int LottoNum { get => lottoNum; set => lottoNum = value; }
        public int[] Rank { get => rank; set => rank = value; }
        public string[] Price { get => price; set => price = value; }
        public int[] Person { get => person; set => person = value; }
        public string[] PersonPrice { get => personPrice; set => personPrice = value; }

        public DetailLotto(int lottoNum, int[] rank, string[] price, int[] person, string[] personPrice)
        {
            this.lottoNum = lottoNum;
            this.rank = rank;
            this.price = price;
            this.person = person;
            this.personPrice = personPrice;
        }

        public DetailLotto() { } 
        #endregion
    }
}
