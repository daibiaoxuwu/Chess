using System;
using UnityEngine;
namespace cs
{
    class Elephant : Piece
    {
        public override string getName(){return "象";}
        public override string getDefLevel(){return "无";}
        public override string getPrompt(){return "U-挟持";}
        public override int value(){return 13;}
        public override void walk(int x, int y){ //计算棋子移动范围 
            for(int i = x - 2; i <= x + 2; ++ i)
                for(int j = y - 2; j <= y + 2; ++ j)
                    Plate.canStrike(player, i,j,2,2,x,y);
        }
        public override void calSkill(int selx, int sely){
            Plate.canStrike(PlayerControl.player, selx+1,sely,2,2,selx,sely);
            Plate.canStrike(PlayerControl.player, selx-1,sely,2,2,selx,sely);
            Plate.canStrike(PlayerControl.player, selx,sely+1,2,2,selx,sely);
            Plate.canStrike(PlayerControl.player, selx,sely-1,2,2,selx,sely);
            Plate.canStrike(PlayerControl.player, selx+2,sely,2,2,selx,sely);
            Plate.canStrike(PlayerControl.player, selx-2,sely,2,2,selx,sely);
            Plate.canStrike(PlayerControl.player, selx,sely+2,2,2,selx,sely);
            Plate.canStrike(PlayerControl.player, selx,sely-2,2,2,selx,sely);
        }
        public override bool releaseSkill(int srcx, int srcy, int dstx, int dsty){
            if(Plate.plateCol[dstx][dsty]!=Color.gray &&
                    Plate.plateCol[dstx][dsty]!=Color.yellow){
                        return false;
                    }
            Piece selpiece = Plate.plate[srcx][srcy]; 
            Plate.plate[dstx][dsty]=selpiece;
            Plate.plate[srcx][srcy]=null;
            bool move1=false, move2=false, move3=false, move4=false;
            if(srcx>0 && Plate.plate[srcx-1][srcy]!=null && Plate.plate[srcx-1][srcy].ismovable())
                if(dstx>0 && Plate.plate[dstx-1][dsty]==null){
                    move1=true;
                }
            if(srcx<14 && Plate.plate[srcx+1][srcy]!=null && Plate.plate[srcx+1][srcy].ismovable())
                if(dstx<14 && Plate.plate[dstx+1][dsty]==null){
                    move2=true;
                }
            if(srcy>0 && Plate.plate[srcx][srcy-1]!=null && Plate.plate[srcx][srcy-1].ismovable())
                if(dsty>0 && Plate.plate[dstx][dsty-1]==null){
                    move3=true;
                } 
            if(srcy<14 && Plate.plate[srcx][srcy+1]!=null && Plate.plate[srcx][srcy+1].ismovable())
                if(dsty<14 && Plate.plate[dstx][dsty+1]==null){
                    move4=true;
                }    
            if(move1){
                selpiece = Plate.plate[srcx-1][srcy];
                selpiece.wait=0;
                Plate.plate[dstx-1][dsty]=selpiece;
                Plate.plate[srcx-1][srcy]=null;
            }
            if(move2){
                    selpiece = Plate.plate[srcx+1][srcy];
                    selpiece.wait=0;
                    Plate.plate[dstx+1][dsty]=selpiece;
                    Plate.plate[srcx+1][srcy]=null;
            }
            if(move3){
                    selpiece = Plate.plate[srcx][srcy-1];
                    selpiece.wait=0;
                    Plate.plate[dstx][dsty-1]=selpiece;
                    Plate.plate[srcx][srcy-1]=null;
            }
            if(move4){
                    selpiece = Plate.plate[srcx][srcy+1];
                    selpiece.wait=0;
                    Plate.plate[dstx][dsty+1]=selpiece;
                    Plate.plate[srcx][srcy+1]=null;
            }
            return true;
        }
    }
}
