using System;

namespace cs
{
    class Flag : Piece
    {
        public override string getName(){return "旗";}
        public override string getDefLevel(){return "无";}
        public override bool canAtk(){return false;}
        public override int value(){return 8;}

        public override void walk(int x, int y){ //计算棋子移动范围 
            Plate.walk(x,y,1,1,x,y);
        }
    }
}
