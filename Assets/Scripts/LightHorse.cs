using System;

namespace cs
{
    class LightHorse : Piece
    {
        
        public override string getName(){return "轻";}
        public override int value(){return 12;}

        public override void walk(int x, int y){ //计算棋子移动范围 
            if(tire==0) Plate.walk(x,y,4,4,x,y);
        }
        public override void turnTurn(int srcx, int srcy){
            if(tire==1) tire=2;//自己回合结束
            else if(tire==2) tire=3;//对方回合结束，自己下一个回合仍然不能动
            else if(tire==3) tire=0;
        }
    }
}