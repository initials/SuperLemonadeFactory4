using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using org.flixel;

using System.Linq;
using System.Xml.Linq;

using SuperLemonadeFactory4.characters;

namespace SuperLemonadeFactory4
{
    public class IntroState : FlxState
    {

        FlxGroup charactersGrp;
        FlxGroup blocksGrp;

        override public void create()
        {
            FlxG.backColor = Color.DarkSlateBlue;
            base.create();

            FlxTileblock t = new FlxTileblock(0, 300, 320, 64);
            t.auto = FlxTileblock.HUDELEMENT;
            t.loadTiles("level1_specialBlock", 13, 13, 0);

            add(t);


            FlxSprite robot = new FlxSprite(30, 30);
            robot.loadGraphic("lemonade_strip_100", true, false, 25, 25);
            robot.addAnimation("static", robot.generateFrameNumbersBetween(0,40), 12, true);
            robot.play("static");
            add(robot);

            Andre andre = new Andre(0, 0);
            add(andre);


        }

        override public void update()
        {




            base.update();
        }


    }
}
