using System;

namespace cs
{
    class Wall : Piece
    {
        
        public override string getName(){return "墙";}
        public override int value(){return 2;}
        public override string getDefLevel(){return "机械";}
        public override bool ismovable(){return false;}

        public override void walk(int x, int y){ //计算棋子移动范围 
        }
    }
}