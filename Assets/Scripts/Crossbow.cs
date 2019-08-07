using System;
using UnityEngine;
namespace cs
{
    class Crossbow : Piece
    {
        static int arrowLength = 4;
        
        public override string getName(){return "弩";}
        public override string getDefLevel(){return "重甲";}
        public override bool canAtk(){return false;}
        public override bool isAgile(){return true;}
        public override string getPrompt(){return "U-射击";}
        public override int value(){return 9;}

        public override void calSkill(int selx, int sely){
            for(int i = 1; i <= arrowLength; ++ i){
                Plate.canStrike(player, selx+i, sely, 0, 0, selx, sely, true);
                Plate.canStrike(player, selx-i, sely, 0, 0, selx, sely, true);
                Plate.canStrike(player, selx, sely+i, 0, 0, selx, sely, true);
                Plate.canStrike(player, selx, sely-i, 0, 0, selx, sely, true);
            }
        }
        public override bool releaseSkill(int srcx, int srcy, int dstx, int dsty){
            if(Plate.plateCol[dstx][dsty] == Color.yellow 
                    || Plate.plateCol[dstx][dsty] == Color.gray){
                waitx=dstx;
                waity=dsty;
                wait=1;
                return true;
            } else {
                return false;
            }
        }

        public override void turnTurn(int srcx, int srcy){
            if(wait==1) wait=2;
            else if(wait==2){
                int atkx = srcx, atky = srcy;
                for(int i = 1; i <= arrowLength; ++ i){
                    atkx+=Math.Sign(waitx-srcx);
                    atky+=Math.Sign(waity-srcy);
                    if(Plate.plate[atkx][atky]!=null){
                        if(Plate.canStrike(player, atkx,atky,0,0,srcx,srcy,true)){
                            Plate.plate[atkx][atky]=null;
                        }
                        break;
                    }
                }
                wait=0;
            }
        }
    }
}
