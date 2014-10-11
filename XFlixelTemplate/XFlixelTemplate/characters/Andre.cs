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
    class Andre : BaseActor
    {

        public Andre(int xPos, int yPos)
            : base(xPos, yPos)
        {
            name = "andre";

            loadGraphic(FlxG.Content.Load<Texture2D>("characters"), true, false, 25, 25);
            loadAnimationsFromGraphicsGaleCSV("content/characters.csv");
            play("andre_run");

            this.runSpeed = 75;

        }

        public override void hitLeft(FlxObject Contact, float Velocity)
        {
            base.hitLeft(Contact, Velocity);

            //velocity.Y -=50;
        }

        public override void hitRight(FlxObject Contact, float Velocity)
        {
            //Console.WriteLine("Hitting Right");


            

            base.hitRight(Contact, Velocity);

            //velocity.Y-=50;
        }

        public override void hitSide(FlxObject Contact, float Velocity)
        {

            base.hitSide(Contact, Velocity);
        }

        override public void update()
        {
            
            

            base.update();
            
        }


    }
}
