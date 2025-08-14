using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamePacOop.GameGL
{
    class MarioGamePlayer : GameObject
    {
        
        int score;
        public MarioGamePlayer(Image image, GameCell startCell) : base(GameObjectType.PLAYER, image)
        {
            this.CurrentCell = startCell;
        }
        public GameCell move(GameDirection direction)
        {
            GameCell currentCell = this.CurrentCell;
            GameCell nextCell = currentCell.nextCell(direction);
            ScoresIncrease(nextCell);
            Scoresdecrease(nextCell);

            this.CurrentCell = nextCell;
             
            
            if (currentCell != nextCell)
            {
                currentCell.setGameObject(Game.getBlankGameObject());

            }
            return nextCell;
        }


        private void ScoresIncrease(GameCell nextCell)
        {
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.REWARD)
            {
                score++;
            }

        }
        private void Scoresdecrease(GameCell nextCell)
        {
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.ENEMY)
            {
                score--;
            }

        }
        public   int returnScore()
        {
            return this.score;
        }

   
    }
}
