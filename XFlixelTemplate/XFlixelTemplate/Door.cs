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
    class Door : FlxSprite
    {

        public Door(int xPos, int yPos)
            : base(xPos, yPos)
        {
            loadGraphic("exit", true, false, 66, 110);

            addAnimation("animation", new int[] { 0 }, 12, true);

            play("animation");

            width = 26;

            setOffset(20, 0);
        }

        override public void update()
        {


            base.update();

        }


    }
}
