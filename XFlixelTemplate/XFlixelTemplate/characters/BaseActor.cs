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
    class BaseActor : FlxSprite
    {
        public string name;
        public int runSpeed = 100;
        public bool shouldStop = false;

        public BaseActor(int xPos, int yPos)
            : base(xPos, yPos)
        {
            acceleration.Y = 980;
            facing = Flx2DFacing.Right;




        }

        override public void update()
        {


            if (!shouldStop)
            {
                play(name + "_run");

                if (this.facing == Flx2DFacing.Right)
                    this.velocity.X = this.runSpeed;
                else if (this.facing == Flx2DFacing.Left)
                    this.velocity.X = this.runSpeed * -1;
            }
            else
            {
                play(name + "_idle");

                this.velocity.X = 0;

            }
            if (this.x < 5)
            {
                this.x = 6;
                this.facing = Flx2DFacing.Right;
            }
            if (this.x > FlxG.width - 25)
            {
                this.x = FlxG.width - 26;
                this.facing = Flx2DFacing.Left;
            }
            //if (FlxControl.ACTIONJUSTPRESSED)
            //{
            //    velocity.Y -= 123;
            //}

            base.update();

        }

        public override void hitBottom(FlxObject Contact, float Velocity)
        {

            //Console.WriteLine(Contact.GetType().ToString());

            if (Contact.GetType().ToString() == "SuperLemonadeFactory4.MovingBlock" && (Contact.velocity.Y != 0 || Contact.velocity.X != 0))
            {
                //if (this.x > (Contact.x + 12) && this.x < (Contact.x + Contact.width - 12))
                shouldStop = true;
            }
            else
            {
                shouldStop = false;
            }
                
            base.hitBottom(Contact, Velocity);
        }

    }
}
