using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
namespace cs
{
    public static class Plate
    {


        public static Piece[][] plate;
        public static ConsoleColor[][] plateCol;
        public static int[][] plateDist;//for tire
        public static void init(){
            plate = new Piece[15][];
            for(int i = 0; i < 15; ++ i){
                plate[i] = new Piece[15];
            }
            for(int player = 0; player < 2; ++ player){
                /*
                if (!File.Exists("1.CSV")){
                    Console.WriteLine("找不到布局文件1.CSV。请将其放在本程序同一目录下。");
                    Console.ReadKey();
                    return;
                }
                FileStream fs = new FileStream("1.CSV", FileMode.Open);
                StreamReader reader = new StreamReader(fs);
                string line = string.Empty;
                int xpos = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] lines = line.Split(",");
                    for(int i = 0; i < 15; ++ i){
                        if(lines[i].Equals("S")){ //Sword
                            Sword piece = new Sword();
                            piece.player = player;
                            plate[(player==0?xpos:15-xpos)][i] = piece;
                        }
                    }
                    xpos++;
                }*/


                plateCol = new ConsoleColor[15][];
                for(int i = 0; i < 15; ++ i){
                    plateCol[i] = new ConsoleColor[15];
                    for(int j = 0; j < 15; ++ j){
                        plateCol[i][j] = ConsoleColor.Black;
                    }
                }
                plateDist = new int[15][];
                for(int i = 0; i < 15; ++ i){
                    plateDist[i] = new int[15];
                    for(int j = 0; j < 15; ++ j){
                        plateDist[i][j] = -1;
                    }
                }
                Piece piece = new Sword(); piece.player = 0; plate[3][1] = piece; 
                piece = new Sword(); piece.player = 0; plate[4][3] = piece; 
                piece = new Sword(); piece.player = 0; plate[4][5] = piece; 
                piece = new Sword(); piece.player = 0; plate[2][7] = piece; 
                piece = new Sword(); piece.player = 0; plate[2][9] = piece; 
                piece = new Lance(); piece.player = 0; plate[4][4] = piece; 
                piece = new Lance(); piece.player = 0; plate[4][2] = piece; 
                piece = new Lance(); piece.player = 0; plate[4][13] = piece; 
                piece = new Lance(); piece.player = 0; plate[3][12] = piece; 
                piece = new Lance(); piece.player = 0; plate[3][11] = piece; 
                piece = new Arrow(); piece.player = 0; plate[3][5] = piece; 
                piece = new Arrow(); piece.player = 0; plate[4][4] = piece; 
                piece = new Crossbow(); piece.player = 0; plate[4][7] = piece; 
                piece = new Crossbow(); piece.player = 0; plate[4][8] = piece; 
                piece = new Shield(); piece.player = 0; plate[1][7] = piece; 
                piece = new Shield(); piece.player = 0; plate[1][9] = piece; 
                piece = new Rook(); piece.player = 0; plate[3][0] = piece; 
                piece = new Rook(); piece.player = 0; plate[3][14] = piece; 
                piece = new LightHorse(); piece.player = 0; plate[4][0] = piece; 
                piece = new LightHorse(); piece.player = 0; plate[4][1] = piece; 
                piece = new HeavyHorse(); piece.player = 0; plate[3][10] = piece; 
                piece = new HeavyHorse(); piece.player = 0; plate[4][14] = piece; 
                piece = new Elephant(); piece.player = 0; plate[4][9] = piece; 
                piece = new Flag(); piece.player = 0; plate[4][10] = piece; 
                piece = new Ram(); piece.player = 0; plate[4][11] = piece; 
                piece = new Catapult(); piece.player = 0; plate[1][3] = piece; 
                piece = new WildFire(); piece.player = 0; plate[1][9] = piece; 
                piece = new Tower(); piece.player = 0; plate[1][8] = piece; 
                piece = new Assassin(); piece.player = 0; plate[3][8] = piece; 
                piece = new Dragon(); piece.player = 0; plate[2][10] = piece; 
                piece = new King(); piece.player = 0; plate[0][7] = piece; 
                piece = new Wall(); piece.player = 0; plate[1][5] = piece; 
                piece = new Wall(); piece.player = 0; plate[1][6] = piece; 
                piece = new Wall(); piece.player = 0; plate[2][6] = piece; 
                piece = new Wall(); piece.player = 0; plate[3][6] = piece; 

                piece = new Wall(); piece.player = 2; plate[7][6] = piece; 
                piece = new Wall(); piece.player = 2; plate[7][8] = piece; 
                piece = new Wall(); piece.player = 2; plate[6][7] = piece; 
                piece = new Wall(); piece.player = 2; plate[8][7] = piece; 
                piece = new Wall(); piece.player = 2; plate[7][7] = piece; 

                piece = new Sword(); piece.player = 1; plate[11][1] = piece; 
                piece = new Sword(); piece.player = 1; plate[10][3] = piece; 
                piece = new Sword(); piece.player = 1; plate[10][5] = piece; 
                piece = new Sword(); piece.player = 1; plate[12][7] = piece; 
                piece = new Sword(); piece.player = 1; plate[12][9] = piece; 
                piece = new Lance(); piece.player = 1; plate[10][4] = piece; 
                piece = new Lance(); piece.player = 1; plate[10][2] = piece; 
                piece = new Lance(); piece.player = 1; plate[10][13] = piece; 
                piece = new Lance(); piece.player = 1; plate[11][12] = piece; 
                piece = new Lance(); piece.player = 1; plate[11][11] = piece; 
                piece = new Arrow(); piece.player = 1; plate[11][5] = piece; 
                piece = new Arrow(); piece.player = 1; plate[10][4] = piece; 
                piece = new Crossbow(); piece.player = 1; plate[10][7] = piece; 
                piece = new Crossbow(); piece.player = 1; plate[10][8] = piece; 
                piece = new Shield(); piece.player = 1; plate[13][7] = piece; 
                piece = new Shield(); piece.player = 1; plate[13][9] = piece; 
                piece = new Rook(); piece.player = 1; plate[11][0] = piece; 
                piece = new Rook(); piece.player = 1; plate[11][14] = piece; 
                piece = new LightHorse(); piece.player = 1; plate[10][0] = piece; 
                piece = new LightHorse(); piece.player = 1; plate[10][1] = piece; 
                piece = new HeavyHorse(); piece.player = 1; plate[11][10] = piece; 
                piece = new HeavyHorse(); piece.player = 1; plate[10][14] = piece; 
                piece = new Elephant(); piece.player = 1; plate[10][9] = piece; 
                piece = new Flag(); piece.player = 1; plate[10][10] = piece; 
                piece = new Ram(); piece.player = 1; plate[10][11] = piece; 
                piece = new Catapult(); piece.player = 1; plate[13][3] = piece; 
                piece = new WildFire(); piece.player = 1; plate[13][9] = piece; 
                piece = new Tower(); piece.player = 1; plate[13][8] = piece; 
                piece = new Assassin(); piece.player = 1; plate[11][8] = piece; 
                piece = new Dragon(); piece.player = 1; plate[12][10] = piece; 
                piece = new King(); piece.player = 1; plate[14][7] = piece; 
                piece = new Wall(); piece.player = 1; plate[13][5] = piece; 
                piece = new Wall(); piece.player = 1; plate[13][6] = piece; 
                piece = new Wall(); piece.player = 1; plate[12][6] = piece; 
                piece = new Wall(); piece.player = 1; plate[11][6] = piece; 

                colRefresh();
                calMove(0,0);
                /*
                 * TODO!!!
                for (int i = 0; i < 15; ++i)
                {                   
                    for (int j = 0; j < 15; ++j)
                    {
                        if(plateCol[i][j] > 0){
                            MapGenerator.floors[i][j].child!! SetActive(true);
                        }else{
                            MapGenerator.floors[i][j].child!! SetActive(false);
                        }
                        //TODO:
                        //Console.BackgroundColor = plateCol[i][j];
                        //if (plate[i][j] != null && plate[i][j].dizzy > 0) Console.BackgroundColor = (plate[i][j].player == 0 ? ConsoleColor.DarkCyan : ConsoleColor.DarkMagenta);
                        
                       
                    }                  
                }*/
            }

            
        }
        public static void colRefresh(){
            for(int i = 0; i < 15; ++ i){
                for(int j = 0; j < 15; ++ j){
                    plateCol[i][j] = ConsoleColor.Black;
                }
            }
        }

        public static void print(){
        /*
            Console.Clear();
            Console.WriteLine("玩家"+Program.player.ToString() + "行动。玩家0石头："+Program.stone[0].ToString()+"玩家1石头："+Program.stone[1]);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 0 1 2 3 4 5  ");
            for(int i = 0; i < 15; ++ i){
                if(i<5) Console.ForegroundColor = ConsoleColor.Blue;
                else if(i>9) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor=ConsoleColor.Black;

                if(i<9) Console.Write(" ");
                Console.Write((i+1).ToString());

                for(int j = 0; j < 15; ++ j){
                    Console.BackgroundColor = plateCol[i][j];
                    if(plate[i][j]!=null && plate[i][j].dizzy>0) Console.BackgroundColor=(plate[i][j].player==0 ? ConsoleColor.DarkCyan : ConsoleColor.DarkMagenta);
                    if(i==Program.curx && j==Program.cury){
                        Console.BackgroundColor = (Program.player==0 ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed);
                    } 
                           
                    if(plate[i][j]==null){
                        Console.Write("  ");
                    } else{
                        Console.ForegroundColor=(plate[i][j].player==0 ? ConsoleColor.Blue :
                        (plate[i][j].player==1? ConsoleColor.Red : ConsoleColor.White));
                        Console.Write(plate[i][j].getName());
                    }
                }
                if(i<5) Console.ForegroundColor = ConsoleColor.Blue;
                else if(i>9) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor=ConsoleColor.Black;
                if(i<9) Console.Write(" ");
                Console.WriteLine((i+1).ToString());
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("   1 2 3 4 5 6 7 8 9 0 1 2 3 4 5  ");
            Console.ForegroundColor = ConsoleColor.White;
            */
        }

        public static void calMove(int x, int y){ //判断光标处棋子的移动，修改plateCol
            Piece piece = plate[x][y];
            if(piece==null || piece.player!=Program.player || piece.dizzy>0) return;
            piece.walk(x, y);
        }
        public static bool inside(int x, int y){
            return(x>=0 && x<15 && y>=0 && y<15);
        }
        public static ConsoleColor playerCol(){
            return  (Program.player==0 ? ConsoleColor.DarkBlue : ConsoleColor.DarkRed);
        }

        public static bool canStrike(int player, int x, int y,int steps, int maxsteps, int origx, int origy, bool spAtk = false){
            //在空格子和可以击杀时为true.否则,出界，为队友，被防御均为false.
            if(!(inside(x,y))) return false;
            if(plate[x][y]==null){
                plateCol[x][y]=ConsoleColor.DarkGray;
                return true;
            } else if(plate[x][y].player==player){
                return false;
            }

            if(!plate[origx][origy].canAtk() && !spAtk) return false;
            string atkLevel = plate[origx][origy].getAtkLevel();
            if(atkLevel=="粉碎" || plate[x][y].dizzy>0 || (atkLevel=="刺杀" && plate[x][y].getDefLevel()!="机械")){
                plateCol[x][y]=ConsoleColor.DarkYellow;
                return true;
            }
            //刺杀：没有return说明为机械。
            switch(plate[x][y].getDefLevel()){
                case "无":
                    plateCol[x][y]=ConsoleColor.DarkYellow;
                    return true;
                case "轻甲":
                    if(Math.Abs(x-origx)!=Math.Abs(y-origy)){
                        plateCol[x][y]=ConsoleColor.DarkYellow;
                        return true;
                    } else {
                        return false;
                    }
                case "重甲":
                    if(x!=origx && y!=origy){
                        plateCol[x][y]=ConsoleColor.DarkYellow;
                        return true;
                    } else {
                        return false;
                    }
                case "盾牌":
                    if(plate[x][y].waity==0 && plate[x][y].waitx==0){
                        plate[x][y].waitx = (plate[x][y].player==0 ? 1 : -1);
                    }
                    if(Math.Sign(plate[x][y].waity) != Math.Sign(origy-y) ||
                            Math.Sign(plate[x][y].waitx) != Math.Sign(origx-x)){
                        plateCol[x][y]=ConsoleColor.DarkYellow;
                        return true;
                    }

                    if(plate[x][y].waity==0){
                        if(origy==y) return false;
                    } else if(plate[x][y].waitx==0){
                        if(origx==x) return false;
                    } else if((double)(origx-x)/(plate[x][y].waitx)==(double)(origy-y)/(plate[x][y].waity)){
                        return false;
                    }
                    plateCol[x][y]=ConsoleColor.DarkYellow;
                    return true;
                case "机械":
                    return false;
                default: //?
                    return false;
            }
        }

        public static void walk(int x, int y, int steps, int maxsteps, int origx, int origy){ //计算棋子移动范围：默认的走路
            if(!(inside(x,y)) || steps<0) return;
            plateDist[x][y]=steps;
            if (steps!=maxsteps && plate[x][y]!=null){
                canStrike(Program.player, x,y,steps,maxsteps, origx, origy);
                return;
            } else {
                plateCol[x][y]=ConsoleColor.DarkGray;
            }
            walk(x-1,y,steps-1,maxsteps, origx, origy);
            walk(x+1,y,steps-1,maxsteps, origx, origy);
            walk(x,y-1,steps-1,maxsteps, origx, origy);
            walk(x,y+1,steps-1,maxsteps, origx, origy);
        }

        public static int selx, sely;
        public static bool selectPiece(){
            Piece piece = plate[Program.curx][Program.cury];
            if(piece!=null && piece.player==Program.player){
                selx=Program.curx;
                sely=Program.cury;
                return true;
            }
            return false;
        }

        public static bool move(){
            Piece selpiece = plate[selx][sely]; 
            if(move(Program.curx, Program.cury, selx, sely)){
                if(selpiece.getName()=="轻" && plateDist[Program.curx][Program.cury]==0){
                    selpiece.tire=1;
                }
                return true;
            }
            return false;
        }
        public static bool move(int dstx, int dsty, int selx, int sely){
            if(dstx==selx && dsty == sely) return false;
            if(plateCol[dstx][dsty]==ConsoleColor.DarkGray ||
                    plateCol[dstx][dsty]==ConsoleColor.DarkYellow){
                Piece selpiece = plate[selx][sely]; 

                plate[dstx][dsty]=selpiece;
                plate[selx][sely]=null;
                
                return true;
            }
            return false;  
        }

        public static bool walkable(int x, int y){
            return(inside(x,y) && plate[x][y]==null);
        }

        public static int listenKey(string answer){
            Piece piece = plate[selx][sely];
            if(!piece.getPrompt().Equals("")){
                string[] prompts=Regex.Split(piece.getPrompt()," ",RegexOptions.IgnoreCase);
                
                foreach(string prompt in prompts){
                    if(answer.ToCharArray()[0] ==prompt.ToCharArray()[0]){
                        piece.selectedSkill = answer;
                        if(piece is Assassin){piece.tire=3;return 0;} else return 2;
                    }
                }
            }
            if(answer.Equals("J")){
                Piece movePiece = plate[selx][sely];
                if(move()){
                    movePiece.wait=0;
                    return 0;
                }
            }
            return -1;
        }
        public static string getPrompt(){
            return plate[selx][sely].getPrompt();
        }

        public static bool releaseSkill(){
            return plate[selx][sely].releaseSkill(selx, sely, Program.curx, Program.cury);
        }
        public static void calSkill(){
            plate[selx][sely].calSkill(selx, sely);
        }
        //arrows!

        public static void turnTurn(){
            //处理对面回合的箭雨
            for(int i=0;i<15;++i)
                for(int j=0;j<15;++j){
                    if(plate[i][j]!=null) plate[i][j].turnTurn(i,j);
                }
        }
      
    }
}
