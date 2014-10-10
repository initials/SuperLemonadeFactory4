using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using org.flixel;

using System.Linq;
using System.Xml.Linq;

namespace SuperLemonadeFactory4
{
    public class IntroState : FlxState
    {

        override public void create()
        {
            FlxG.backColor = Color.Purple;
            base.create();

            FlxSprite robot = new FlxSprite(0, 0);
            robot.loadGraphic("surt/race_or_die", true, false, 20, 20);
            robot.addAnimation("static", robot.generateFrameNumbersBetween(0,40), 12, true);
            robot.play("static");
            robot.angle = 0;
            robot.width = 32;
            robot.height = 32;
            robot.setOffset(12, 12);
            add(robot);

        }

        override public void update()
        {




            base.update();
        }


    }
}
