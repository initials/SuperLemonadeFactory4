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
    class Chef : BaseActor
    {

        public Chef(int xPos, int yPos)
            : base(xPos, yPos)
        {
            name = "chef";

            loadGraphic(FlxG.Content.Load<Texture2D>("characters"), true, false, 25, 25);
            loadAnimationsFromGraphicsGaleCSV("content/characters.csv");
            play("chef_run");

            this.runSpeed = 85;
            width = 10;
            height = 10;

            setOffset(8, 15);
        }

        override public void update()
        {


            base.update();

        }


    }
}
