using System;

namespace cs
{
    class Lance : Piece
    {
        public override string getName(){return "矛";}
        public override string getDefLevel(){return "重甲";}
        public override bool isAgile(){return true;}
        public override int value(){return 8;}

        public override void walk(int x, int y){ //计算棋子移动范围 

        //a true b true b; a true b false ab; a false a;
            if(!Plate.walkable(x-1,y) || !Plate.canStrike(PlayerControl.player, x-2,y,2,2,x,y)) Plate.canStrike(PlayerControl.player, x-1,y,2,2,x,y);
            if(!Plate.walkable(x+1,y) || !Plate.canStrike(PlayerControl.player, x+2,y,2,2,x,y)) Plate.canStrike(PlayerControl.player, x+1,y,2,2,x,y);
            if(!Plate.walkable(x,y-1) || !Plate.canStrike(PlayerControl.player, x,y-2,2,2,x,y)) Plate.canStrike(PlayerControl.player, x,y-1,2,2,x,y);
            if(!Plate.walkable(x,y+1) || !Plate.canStrike(PlayerControl.player, x,y+2,2,2,x,y)) Plate.canStrike(PlayerControl.player, x,y+1,2,2,x,y);
        }
    }
}
