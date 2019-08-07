using System;
using UnityEngine;
namespace cs
{
    class Catapult : Piece
    {
        int arrowLength=10;
        public override string getName(){return "投";}
        public override int value(){return 6;}
        public override bool ismechanics(){return true;}//是否为机械
        public override string getDefLevel(){return "机械";}
        public override string getPrompt(){if(PlayerControl.stone[PlayerControl.player]>0) return "U-投掷"; else return "";}

        public override void walk(int x, int y){ //计算棋子移动范围 
        }
        public override void calSkill(int selx, int sely){
            for(int i=1;i<=arrowLength; ++i){
                if(Plate.inside(selx+i, sely)) Plate.plateCol[selx+i][sely]=Color.gray;
                if(Plate.inside(selx+i, sely+i)) Plate.plateCol[selx+i][sely+i]=Color.gray;
                if(Plate.inside(selx, sely+i)) Plate.plateCol[selx][sely+i]=Color.gray;
                if(Plate.inside(selx-i, sely+i)) Plate.plateCol[selx-i][sely+i]=Color.gray;
                if(Plate.inside(selx-i, sely)) Plate.plateCol[selx-i][sely]=Color.gray;
                if(Plate.inside(selx-i, sely-i)) Plate.plateCol[selx-i][sely-i]=Color.gray;
                if(Plate.inside(selx, sely-i)) Plate.plateCol[selx][sely-i]=Color.gray;
                if(Plate.inside(selx+i, sely-i)) Plate.plateCol[selx+i][sely-i]=Color.gray;
            }
        }
        public override bool releaseSkill(int srcx, int srcy, int dstx, int dsty){
            if(Plate.plateCol[dstx][dsty] == Color.gray){
                PlayerControl.stone[PlayerControl.player]--;
                Piece piece = Plate.plate[dstx][dsty];
                if(piece!=null){if(piece.ismechanics())  Plate.plate[dstx][dsty]=null; else piece.dizzy+=4;}
                piece = Plate.plate[dstx-1][dsty];
                if(piece!=null){if(piece.ismechanics())  Plate.plate[dstx-1][dsty]=null; else piece.dizzy+=4;}
                piece = Plate.plate[dstx+1][dsty];
                if(piece!=null){if(piece.ismechanics())  Plate.plate[dstx-1][dsty]=null; else piece.dizzy+=4;}
                piece = Plate.plate[dstx][dsty-1];
                if(piece!=null){if(piece.ismechanics())  Plate.plate[dstx][dsty-1]=null; else piece.dizzy+=4;}
                piece = Plate.plate[dstx][dsty+1];
                if(piece!=null){if(piece.ismechanics())  Plate.plate[dstx][dsty+1]=null; else piece.dizzy+=4;}
                return true;
            }
            return false;
        }
    }
}