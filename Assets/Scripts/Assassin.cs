using System;

namespace cs
{
    class Assassin : Piece
    {
        
        public override string getName(){return "刺";}
        public override string getAtkLevel(){return "刺杀";}
        public override string getDefLevel(){return "无";}
        public override int value(){return 14;}

        public override string getPrompt(){return "U-潜行";}

        public override void walk(int x, int y){ //计算棋子移动范围 
            if(tire>0) Plate.walk(x,y,5,5,x,y);
        }
        public override void turnTurn(int x, int y){
            if(tire>0) --tire;
        }

    }
}