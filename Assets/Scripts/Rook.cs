using System;
using UnityEngine;
namespace cs
{
    class Rook : Piece
    {
        public override string getName(){return "车";}
        public override string getDefLevel(){return "无";}
        public override int value(){return 11;}
        public override void walk(int x, int y){ //计算棋子移动范围 
            int i;
            for(i = 1; i <= 6 && Plate.inside(x+i,y) && Plate.plate[x+i][y]==null; ++i){Plate.plateCol[x+i][y]=Color.gray;} Plate.canStrike(player, x+i, y, 0, 0, x, y);
            for(i = 1; i <= 6 && Plate.inside(x-i,y) && Plate.plate[x-i][y]==null; ++i){Plate.plateCol[x-i][y]=Color.gray;} Plate.canStrike(player, x-i, y, 0, 0, x, y);
            for(i = 1; i <= 6 && Plate.inside(x,y+i) && Plate.plate[x][y+i]==null; ++i){Plate.plateCol[x][y+i]=Color.gray;} Plate.canStrike(player, x, y+i, 0, 0, x, y);
            for(i = 1; i <= 6 && Plate.inside(x,y-i) && Plate.plate[x][y-i]==null; ++i){Plate.plateCol[x][y-i]=Color.gray;} Plate.canStrike(player, x, y-i, 0, 0, x, y);
        }
    }
}
