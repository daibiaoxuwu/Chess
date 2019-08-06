using System;

namespace cs
{
    class Fire : Piece
    {
        public override string getName(){return "[]";}
        public override int value(){return -1;}
        public override bool ismovable(){return false;}
        public override string getDefLevel(){return "机械";}
        public override void walk(int x, int y){ //计算棋子移动范围 
        }
    }
}