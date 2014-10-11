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
    class Worker : BaseActor
    {

        public Worker(int xPos, int yPos)
            : base(xPos, yPos)
        {
            name = "worker";

            loadGraphic(FlxG.Content.Load<Texture2D>("characters"), true, false, 25, 25);
            loadAnimationsFromGraphicsGaleCSV("content/characters.csv");
            play("worker_run");

            this.runSpeed = 40;

        }

        override public void update()
        {


            base.update();

        }


    }
}
