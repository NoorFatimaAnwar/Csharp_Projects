using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using gamePacOop.GameGL;

namespace gamePacOop
{
    public partial class Form1 : Form
    {
        MarioGamePlayer pacman;
        HorizontalGhost ghostH1;
        HorizontalGhost ghostH2;
        VerticalGhost ghostV1;
        RandomGhost ghostR1;
       

        List<Ghost> ghosts = new List<Ghost>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GameGrid grid = new GameGrid("maze.txt", 23, 61);
            Image pacManImage = GameGL.Game.getGameObjectImage('P');
            GameCell startCell = grid.getCell(8, 10);
            pacman = new MarioGamePlayer(pacManImage, startCell);

            Image ghostH1Img = GameGL.Game.getGameObjectImage('H');
            GameCell startH1 = grid.getCell(16, 45);
            ghostH1 = new HorizontalGhost(GameDirection.Left, ghostH1Img, startH1);
            Image ghostH2Img = GameGL.Game.getGameObjectImage('H');
            GameCell startH2 = grid.getCell(4, 15);
            ghostH2 = new HorizontalGhost(GameDirection.Left, ghostH2Img, startH2);

            Image ghostV1Img = GameGL.Game.getGameObjectImage('V');
            GameCell startV1 = grid.getCell(6, 30);
            ghostV1 = new VerticalGhost(GameDirection.Up, ghostV1Img, startV1);

            Image ghostR1Img = GameGL.Game.getGameObjectImage('R');
            GameCell startR1 = grid.getCell(10, 23);
            ghostR1 = new RandomGhost( ghostR1Img, startR1);

           

            ghosts.Add(ghostH1);
            ghosts.Add(ghostH2);
            ghosts.Add(ghostV1);
            ghosts.Add(ghostR1);
         

            printMaze(grid);
        }

        void printMaze(GameGrid grid)
        {
            for (int x = 0; x < grid.Rows; x++)
            {

                for (int y = 0; y < grid.Cols; y++)
                {
                    GameCell cell = grid.getCell(x, y);
                    this.Controls.Add(cell.PictureBox);
                    //        printCell(cell);
                }

            }
        }
        static void printCell(GameCell cell)
        {
            Console.SetCursorPosition(cell.Y, cell.X);
            Console.Write(cell.CurrentGameObject.DisplayCharacter);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (!isGameEnd())
            {


                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    pacman.move(GameDirection.Left);
                    
                }
                else if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    pacman.move(GameDirection.Right);
                    
                }
                else if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    pacman.move(GameDirection.Up);
                  
                }
                else if (Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    pacman.move(GameDirection.Down);
                  
                }

                foreach (Ghost g in ghosts)
                {

                    g.move();
                }

                label1.Text = "Scores: " + pacman.returnScore();
            }
            else
            {
                gameLoop.Stop();
                this.Hide();
                endForm gameover = new endForm();
                gameover.Show();
            }

        }
       public bool isGameEnd()
        {
            
            int score = pacman.returnScore();
            if (score == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
