using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics;

namespace SuperLemonadeFactory4
{
    class Fruit : FarSprite
    {

        public Fruit(int xPos, int yPos, World world)
            : base(xPos, yPos, world)
        {
            loadGraphic(FlxG.Content.Load<Texture2D>("fruit"), true, false, 8, 8);

            attachCircle(2, 2);


        }

        override public void update()
        {


            base.update();

        }


    }
}
