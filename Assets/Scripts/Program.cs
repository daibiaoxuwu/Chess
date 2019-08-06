using System;

namespace cs
{
    class Program
    {       
        static int LINENUM = 0;
        public static int curx = 0, cury = 0;
        public static int player = 0, mode = 0;


        static bool[] flag;
        static void turnTurn(){
            Plate.turnTurn();
            for(int p=0;p<=1;++p){
                if(flag[p]){
                    bool findflag=false;
                    bool findKing=false;
                    int maxvalue=-1,maxx=0, maxy=0;
                    for(int i = 0; i < 15; ++i){
                        for(int j = 0; j < 15; ++j){
                            if(Plate.plate[i][j]==null || Plate.plate[i][j].player!=p) continue;
                            if(Plate.plate[i][j].dizzy>0) Plate.plate[i][j].dizzy--;
                            if(Plate.plate[i][j].value()>maxvalue){
                                if(maxvalue<Plate.plate[i][j].value()){
                                    maxvalue=Plate.plate[i][j].value();
                                    maxx=i;maxy=j;
                                }
                            }
                            if(Plate.plate[i][j] is King) findKing=true;
                            if(Plate.plate[i][j] is Flag){
                                if((p==0 && i>9) || (p==1 && i<5)){
                                    Console.WriteLine("玩家"+p.ToString()+"通过插旗获得胜利。");
                                  //  string answer=Console.ReadKey().Key.ToString();
                                }
                                findflag=true;
                            }
                        }
                    }
                    if(findflag==false){
                        flag[p]=false;
                        Plate.plate[maxx][maxy]=null;
                    }
                    if(findKing==false){
                        Console.WriteLine("玩家"+(1-p).ToString()+"获得胜利。");
                      //  string answer=Console.ReadKey().Key.ToString();
                    }
                }
            }

            mode=0;
            player=1-player;
            Plate.colRefresh();
        }
        public static int[] stone;

        static void Main(string[] args)
        {
            // init();
            flag=new bool[2];
            flag[0]=true;flag[1]=true;
            stone=new int[2];
            stone[0]=1;stone[1]=1;


            string lastSkill="";
            bool isPush=false;
            bool issteal=false;
            while(true){
                Plate.print();
                if(mode==0){                
                    Console.WriteLine("ASDF-移动 J-选择棋子");
                    string answer = "";// Console.ReadKey().Key.ToString();
                    if(answer=="W" && curx>0) curx--;
                    else if(answer=="S" && curx<14) curx++;
                    else if(answer=="D" && cury<14) cury++;
                    else if(answer=="A" && cury>0) cury--;
                    else if(answer=="J"){
                        if(Plate.selectPiece()){
                            mode=1;
                            isPush=false;
                            issteal=false;
                            Plate.colRefresh();
                            Plate.calMove(curx, cury);
                            continue;
                        }
                    }
                    Plate.colRefresh();
                    Plate.calMove(curx, cury);
                } else if(mode==1){
                    Plate.colRefresh();
                    Plate.calMove(Plate.selx, Plate.sely);
                    Console.Write("ASDF-移动 J-行动 K-取消选择 " + Plate.getPrompt());
                    if(Plate.plate[Plate.selx][Plate.sely]!=null && !Plate.plate[Plate.selx][Plate.sely].ismechanics()){
                    if(Plate.selx>0 && Plate.plate[Plate.selx-1][Plate.sely]!=null && Plate.plate[Plate.selx-1][Plate.sely].ismechanics() && Plate.plate[Plate.selx-1][Plate.sely].player==player ||
                    Plate.sely>0 && Plate.plate[Plate.selx][Plate.sely-1]!=null && Plate.plate[Plate.selx][Plate.sely-1].ismechanics() && Plate.plate[Plate.selx][Plate.sely-1].player==player  ||
                    Plate.selx<14 && Plate.plate[Plate.selx+1][Plate.sely]!=null && Plate.plate[Plate.selx+1][Plate.sely].ismechanics() && Plate.plate[Plate.selx+1][Plate.sely].player==player  ||
                    Plate.sely<14 && Plate.plate[Plate.selx][Plate.sely+1]!=null && Plate.plate[Plate.selx][Plate.sely+1].ismechanics() && Plate.plate[Plate.selx][Plate.sely+1].player==player )
                        if(isPush) Console.Write(" O 关闭挟持"); else Console.Write(" O 开启挟持");
                    }
                    issteal=false;
                    if(Plate.plate[Plate.selx][Plate.sely]!=null && !Plate.plate[Plate.selx][Plate.sely].ismechanics()){
                    if(Plate.selx>0 && Plate.plate[Plate.selx-1][Plate.sely]!=null && Plate.plate[Plate.selx-1][Plate.sely].ismechanics() && Plate.plate[Plate.selx-1][Plate.sely].player!=player ||
                    Plate.sely>0 && Plate.plate[Plate.selx][Plate.sely-1]!=null && Plate.plate[Plate.selx][Plate.sely-1].ismechanics() && Plate.plate[Plate.selx][Plate.sely-1].player!=player  ||
                    Plate.selx<14 && Plate.plate[Plate.selx+1][Plate.sely]!=null && Plate.plate[Plate.selx+1][Plate.sely].ismechanics() && Plate.plate[Plate.selx+1][Plate.sely].player!=player  ||
                    Plate.sely<14 && Plate.plate[Plate.selx][Plate.sely+1]!=null && Plate.plate[Plate.selx][Plate.sely+1].ismechanics() && Plate.plate[Plate.selx][Plate.sely+1].player!=player ){
                        issteal=true;
                        for(int i=Math.Max(0,Plate.selx-2); i<=Math.Min(14,Plate.selx+2);++i)
                            for(int j=Math.Max(0,Plate.sely-2+Math.Abs(Plate.selx-i)); j<=Math.Min(14,Plate.sely+2-Math.Abs(Plate.selx-i));++j)
                                if(Plate.plate[i][j]!=null && Plate.plate[i][j].player==1-player && !Plate.plate[i][j].ismechanics())
                                    issteal=false;
                        }
                        if(issteal) Console.Write(" P 偷盗");
                    }
                    Console.WriteLine();

                    string answer="";//=Console.ReadKey().Key.ToString();
                    if(answer=="W" && curx>0) curx--;
                    else if(answer=="S" && curx<14) curx++;
                    else if(answer=="D" && cury<14) cury++;
                    else if(answer=="A" && cury>0) cury--;
                    else if(answer=="O") {
                        isPush=!isPush;
                        if(isPush){
                            for(int i=0;i<15;++i)
                                for(int j=0;j<15;++j)
                                    if((i!=Plate.selx-2 && i!=Plate.selx-1 && i!=Plate.selx+1 && i!=Plate.selx+2 || j!=Plate.sely) &&
                                        (j!=Plate.sely-2 && j!=Plate.sely-1 && j!=Plate.sely+1 && j!=Plate.sely+2 || i!=Plate.selx)){
                                            Plate.plateCol[i][j]=ConsoleColor.Black;
                                        }
                        }
                        else{
                            Plate.colRefresh();
                            Plate.calMove(Plate.selx, Plate.sely);
                        }
                    }
                    else if(answer=="P" && issteal){
                        if(curx>0 && Plate.plate[curx-1][cury]!=null && Plate.plate[curx-1][cury].ismechanics()) Plate.plate[curx-1][cury].player=player;
                        if(cury>0 && Plate.plate[curx][cury-1]!=null && Plate.plate[curx][cury-1].ismechanics()) Plate.plate[curx][cury-1].player=player;
                        if(curx<14 && Plate.plate[curx+1][cury]!=null && Plate.plate[curx+1][cury].ismechanics()) Plate.plate[curx+1][cury].player=player;
                        if(cury<14 && Plate.plate[curx][cury+1]!=null && Plate.plate[curx][cury+1].ismechanics()) Plate.plate[curx][cury+1].player=player;
                        turnTurn();
                        continue;
                    }
                    else if(answer=="K"){
                        mode=0;
                        Plate.colRefresh();
                        continue;
                    } else {
                        int response = Plate.listenKey(answer);
                        if(response==0){ //移动，返回0
                            if(isPush) pushMec(Plate.selx, Plate.sely, curx, cury);
                            turnTurn();
                            continue;
                        } else if(response!=-1){ //不是无效按键
                            lastSkill=answer;
                            mode=response;
                            Plate.colRefresh();
                            Plate.calSkill();
                            continue;
                        }
                    }
                } else if(mode==2){ //技能
                    Console.WriteLine("ASDF-移动 J-释放"+lastSkill+"技能 K-取消释放");
                    string answer="";//=Console.ReadKey().Key.ToString();
                    if(answer=="W" && curx>0) curx--;
                    else if(answer=="S" && curx<14) curx++;
                    else if(answer=="D" && cury<14) cury++;
                    else if(answer=="A" && cury>0) cury--;
                    else if(answer=="K"){
                        mode=1;
                        Plate.colRefresh();
                        Plate.calMove(Plate.selx, Plate.sely);
                        continue;
                    } else if(answer=="J") {
                        if(Plate.releaseSkill()){
                            turnTurn();
                            continue;
                        }
                    }
                    Plate.colRefresh();
                    Plate.calSkill();
                }
            }
            
        }
        static void pushMec(int srcx, int srcy, int dstx, int dsty){
            bool move1=false, move2=false, move3=false, move4=false;
            Piece selpiece;
            if(srcx>0 && Plate.plate[srcx-1][srcy]!=null && Plate.plate[srcx-1][srcy].ismechanics() && Plate.plate[srcx-1][srcy].player==player )
                if(dstx>0 && (Plate.plate[dstx-1][dsty]==null || Plate.plate[srcx-1][srcy] is Ram)){
                    if(Plate.plate[dstx-1][dsty]!=null && Plate.plate[dstx-1][dsty] is Wall) stone[player]++;
                    move1=true;
                }
            if(srcx<14 && Plate.plate[srcx+1][srcy]!=null && Plate.plate[srcx+1][srcy].ismechanics() && Plate.plate[srcx+1][srcy].player==player )
                if(dstx<14 &&  (Plate.plate[dstx+1][dsty]==null || Plate.plate[srcx+1][srcy] is Ram)){
                    if(Plate.plate[dstx+1][dsty]!=null && Plate.plate[dstx+1][dsty] is Wall) stone[player]++;
                    move2=true;
                }
            if(srcy>0 && Plate.plate[srcx][srcy-1]!=null && Plate.plate[srcx][srcy-1].ismechanics() && Plate.plate[srcx][srcy-1].player==player )
                if(dsty>0 &&  (Plate.plate[dstx][dsty-1]==null || Plate.plate[srcx][srcy-1] is Ram)){
                    if(Plate.plate[dstx][dsty-1]!=null && Plate.plate[dstx][dsty-1] is Wall) stone[player]++;
                    move3=true;
                } 
            if(srcy<14 && Plate.plate[srcx][srcy+1]!=null && Plate.plate[srcx][srcy+1].ismechanics() && Plate.plate[srcx][srcy+1].player==player )
                if(dsty<14 &&  (Plate.plate[dstx][dsty+1]==null || Plate.plate[srcx][srcy+1] is Ram)){
                    if(Plate.plate[dstx][dsty+1]!=null && Plate.plate[dstx][dsty+1] is Wall) stone[player]++;
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
        }
    }
}
