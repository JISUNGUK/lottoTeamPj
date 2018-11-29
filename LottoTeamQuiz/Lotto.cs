using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoTeamQuiz
{
    class Lotto
    {
        int lottoNum; // 회차
        string winningNum; // 당첨번호
        string etc; // 비고

        public int LottoNum { get => lottoNum; set => lottoNum = value; }
        public string WinningNum { get => winningNum; set => winningNum = value; }
        public string Etc { get => etc; set => etc = value; }

        public Lotto(int lottoNum, string winningNum, string etc)
        {
            this.lottoNum = lottoNum;
            this.winningNum = winningNum;
            this.etc = etc;
        }

        public Lotto()
        {
        }
    }
}
