using System;

namespace cs
{
    class ArrowSnipeToken : Piece
    {
        public override string getName(){return "::";}
        public override bool canAtk(){return false;}
        public override bool ismovable(){return false;}
        public override void walk(int x, int y){}
        public override int value(){return -1;}
        int srcx, srcy;
        public ArrowSnipeToken(int srcx, int srcy, int player){
            this.srcx = srcx;
            this.srcy = srcy;
            this.player = player;
        }
        public override void turnTurn(int x, int y){
            Piece piece = Plate.plate[srcx][srcy];
            if(piece==null || piece.player!=player || piece.getName()!="弓")
                Plate.plate[x][y]=null;
        }
    }
}
