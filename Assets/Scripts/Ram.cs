using System;

namespace cs
{
    class Ram : Piece
    {
        
        public override string getName(){return "木";}
        public override int value(){return 5;}
        public override bool ismechanics(){return true;}//是否为机械
        public override string getDefLevel(){return "机械";}

        public override void walk(int x, int y){ //计算棋子移动范围 
        }
    }
}