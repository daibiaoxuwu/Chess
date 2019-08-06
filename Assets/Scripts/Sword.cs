using System;

namespace cs
{
    class Sword : Piece
    {
        public override string getName(){return "剑";}
        public override string getDefLevel(){return "轻甲";}
        public override bool isAgile(){return true;}
        public override int value(){return 8;}
    }
}
