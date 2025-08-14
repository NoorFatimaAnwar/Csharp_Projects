using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace gamePacOop.GameGL
{
    class Game
    {
        public static GameObject getBlankGameObject()
        {
            GameObject blankGameObject = new GameObject(GameObjectType.NONE, gamePacOop.Properties.Resources.simplebox);
            return blankGameObject;
        }

        public static GameObject getpalletGameObject()
        {
            GameObject palletGameObject = new GameObject(GameObjectType.REWARD, gamePacOop.Properties.Resources.coin);
            return palletGameObject;
        }
        public static Image getGameObjectImage(char displayCharacter)
        {
            Image img = gamePacOop.Properties.Resources.simplebox;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                img = gamePacOop.Properties.Resources._2;
            }

            if (displayCharacter == '#')
            {
                img = gamePacOop.Properties.Resources._1;
            }

            if (displayCharacter == '.')
            {
                img = gamePacOop.Properties.Resources.coin;
            }
            if (displayCharacter == 'P' || displayCharacter == 'p')
            {
                img = gamePacOop.Properties.Resources.Mario;
            }
            if (displayCharacter == 'H' || displayCharacter == 'h')
            {
                img = gamePacOop.Properties.Resources.HGhost;
            }
            if (displayCharacter == 'V' || displayCharacter == 'v')
            {
                img = gamePacOop.Properties.Resources.VGhost;
            }

          
            if (displayCharacter == 'R' || displayCharacter == 'r')
            {
                img = gamePacOop.Properties.Resources.RGhost;
            }

            return img;
        }
    }
}
