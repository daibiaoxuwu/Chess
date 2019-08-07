using System;
using UnityEngine;
namespace cs
{
    class Dragon : Piece
    {
        public override string getName(){return "龙";}
        public override int value(){return 15;}
        public override string getDefLevel(){return "无";}
        public override string getAtkLevel(){return "粉碎";}

        public override void walk(int x, int y){
            int i;
            for(i = 1; Plate.inside(x+i,y) && Plate.plate[x+i][y]==null; ++i){Plate.plateCol[x+i][y]=Color.gray;} Plate.canStrike(player, x+i, y, 0, 0, x, y); Plate.canStrike(player, x+i*2, y, 0, 0, x, y); 
            for(i = 1; Plate.inside(x-i,y) && Plate.plate[x-i][y]==null; ++i){Plate.plateCol[x-i][y]=Color.gray;} Plate.canStrike(player, x-i, y, 0, 0, x, y); Plate.canStrike(player, x-i*2, y, 0, 0, x, y); 
            for(i = 1; Plate.inside(x,y+i) && Plate.plate[x][y+i]==null; ++i){Plate.plateCol[x][y+i]=Color.gray;} Plate.canStrike(player, x, y+i, 0, 0, x, y); Plate.canStrike(player, x, y+i*2, 0, 0, x, y); 
            for(i = 1; Plate.inside(x,y-i) && Plate.plate[x][y-i]==null; ++i){Plate.plateCol[x][y-i]=Color.gray;} Plate.canStrike(player, x, y-i, 0, 0, x, y); Plate.canStrike(player, x, y-i*2, 0, 0, x, y); 
            for(i = 1; Plate.inside(x+i,y+i) && Plate.plate[x+i][y+i]==null; ++i){Plate.plateCol[x+i][y+i]=Color.gray;} Plate.canStrike(player, x+i, y+i, 0, 0, x, y); Plate.canStrike(player, x+i*2, y+i*2, 0, 0, x, y); 
            for(i = 1; Plate.inside(x-i,y-i) && Plate.plate[x-i][y-i]==null; ++i){Plate.plateCol[x-i][y-i]=Color.gray;} Plate.canStrike(player, x-i, y-i, 0, 0, x, y); Plate.canStrike(player, x-i*2, y-i*2, 0, 0, x, y); 
            for(i = 1; Plate.inside(x-i,y+i) && Plate.plate[x-i][y+i]==null; ++i){Plate.plateCol[x-i][y+i]=Color.gray;} Plate.canStrike(player, x-i, y+i, 0, 0, x, y); Plate.canStrike(player, x-i*2, y+i*2, 0, 0, x, y); 
            for(i = 1; Plate.inside(x+i,y-i) && Plate.plate[x+i][y-i]==null; ++i){Plate.plateCol[x+i][y-i]=Color.gray;} Plate.canStrike(player, x+i, y-i, 0, 0, x, y); Plate.canStrike(player, x+i*2, y-i*2, 0, 0, x, y); 
        }
    }
}