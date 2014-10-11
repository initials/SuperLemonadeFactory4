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
    class MovingBlock : FlxMovingPlatform
    {
        public bool forward = true;
        public MovingBlock(int xPos, int yPos)
            : base(xPos, yPos)
        {
            
        }

        override public void update()
        {


            base.update();

        }


    }
}
