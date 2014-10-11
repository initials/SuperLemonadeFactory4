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
    class SmallCrate : FlxSprite
    {

        public SmallCrate(int xPos, int yPos)
            : base(xPos, yPos)
        {
            loadGraphic(FlxG.Content.Load<Texture2D>("smallCrateExplode"), true, false, 32, 32);
            acceleration.Y = 980;

        }

        override public void update()
        {


            base.update();

        }


    }
}
