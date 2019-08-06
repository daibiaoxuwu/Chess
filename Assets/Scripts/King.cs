using System;

namespace cs
{
    class King : Piece
    {
        public override string getName(){return "王";}
        public override string getDefLevel(){return "无";}
        public override int value(){return 0;}

        public override void walk(int x, int y){ //计算棋子移动范围 
            Plate.walk(x,y,1,1,x,y);
        }
    }
}
