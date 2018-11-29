using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoTeamQuiz
{
    class Statics
    {
        private int no, count;

        public Statics(int no, int count)
        {
            this.no = no;
            this.count = count;
        }

        public int No { get => no; set => no = value; }
        public int Count { get => count; set => count = value; }
    }
}
