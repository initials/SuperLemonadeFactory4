using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.flixel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace SuperLemonadeFactory4.characters
{
    class Andre : FlxSprite
    {

        public Andre(int xPos, int yPos)
            : base(xPos, yPos)
        {

            string anims = FlxU.loadFromDevice("content/characters.csv");

            Console.WriteLine(anims);

            loadGraphic(FlxG.Content.Load<Texture2D>("characters"), true, false, 25, 25);

            addAnimation("idle", new int[] { 1 }, 12, true);
            addAnimation("run", new int[] { 6,7,8,9,10,11 }, 12, true);

            play("run");

            acceleration.Y = 222;
            
        }

        public override void hitLeft(FlxObject Contact, float Velocity)
        {
            velocity.Y = -1350;

            base.hitLeft(Contact, Velocity);
        }

        public override void hitRight(FlxObject Contact, float Velocity)
        {
            velocity.Y = -1350;

            base.hitRight(Contact, Velocity);
        }

        public override void hitSide(FlxObject Contact, float Velocity)
        {

            base.hitSide(Contact, Velocity);
        }

        override public void update()
        {

            

            base.update();
            velocity.X = 100;
        }


    }
}
