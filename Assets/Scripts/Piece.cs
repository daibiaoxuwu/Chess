using UnityEngine;
using System.Collections;
namespace cs
{
    public abstract class Piece
    {
        public int player;
        public int posx, posy;
        public abstract string getName();
        public virtual string getDefLevel(){return "无";}
        public virtual string getAtkLevel(){return "普通";}
        public virtual bool canAtk(){return true;}
        public virtual bool isAgile(){return false;}//翻墙能力
        public virtual bool ismovable(){return true;}//被挟持能力
        public virtual bool ismechanics(){return false;}//是否为机械
        public virtual void walk(int x, int y){ //计算棋子移动范围 
            Plate.walk(x,y,2,2,x,y);
        }
        public abstract int value();//价值，夺旗后被牺牲的顺序

        //skill
        public virtual string getPrompt(){
            return "";
        }
        public string selectedSkill;
        public virtual bool releaseSkill(int srcx, int srcy, int dstx, int dsty){
            return false;
        }
        public virtual void calSkill(int selx, int sely){ }
        public virtual void turnTurn(int x, int y){ }
        
        public int wait = 0, tire=0;
        public int waitx, waity;
        public int dizzy;
    }
}
