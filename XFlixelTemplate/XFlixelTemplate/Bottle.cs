using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SuperLemonadeFactory4
{
    class Bottle : FlxSprite
    {

        public Bottle(int xPos, int yPos)
            : base(xPos, yPos)
        {
            loadGraphic(FlxG.Content.Load<Texture2D>("bottle"), true, false, 12, 26);
            acceleration.Y = 980;
            this.setDrags(100, 100);
        }

        override public void update()
        {


            base.update();

        }


    }
}
