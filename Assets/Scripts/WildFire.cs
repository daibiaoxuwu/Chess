using System;

namespace cs
{
    class WildFire : Piece
    {
        int arrowLength=8;
        public override string getName(){return "火";}
        public override int value(){return 7;}
        public override bool ismechanics(){return true;}//是否为机械
        public override string getDefLevel(){return "机械";}
        public override string getPrompt(){if(PlayerControl.stone[PlayerControl.player]>0) return "U-投掷"; else return "";}

        public override void walk(int x, int y){ //计算棋子移动范围 
        }
        public override void calSkill(int selx, int sely){
            for(int i=1;i<=arrowLength; ++i){
                if(Plate.inside(selx+i, sely)) Plate.plateCol[selx+i][sely]=ConsoleColor.DarkGray;
                if(Plate.inside(selx+i, sely+i)) Plate.plateCol[selx+i][sely+i]=ConsoleColor.DarkGray;
                if(Plate.inside(selx, sely+i)) Plate.plateCol[selx][sely+i]=ConsoleColor.DarkGray;
                if(Plate.inside(selx-i, sely+i)) Plate.plateCol[selx-i][sely+i]=ConsoleColor.DarkGray;
                if(Plate.inside(selx-i, sely)) Plate.plateCol[selx-i][sely]=ConsoleColor.DarkGray;
                if(Plate.inside(selx-i, sely-i)) Plate.plateCol[selx-i][sely-i]=ConsoleColor.DarkGray;
                if(Plate.inside(selx, sely-i)) Plate.plateCol[selx][sely-i]=ConsoleColor.DarkGray;
                if(Plate.inside(selx+i, sely-i)) Plate.plateCol[selx+i][sely-i]=ConsoleColor.DarkGray;
            }
        }
        public override bool releaseSkill(int srcx, int srcy, int dstx, int dsty){
            if(Plate.plateCol[dstx][dsty] == ConsoleColor.DarkGray){
                Piece piece = new Fire();
                piece.player=player;
                if(Plate.plate[dstx][dsty]!=null && Plate.plate[dstx][dsty] is Wall) PlayerControl.stone[player]++;
                Plate.plate[dstx][dsty]=piece;
                Plate.plate[srcx][srcy]=null;
                return true;
            }
            return false;
        }
    }
}