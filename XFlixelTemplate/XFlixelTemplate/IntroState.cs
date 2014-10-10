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

            charactersGrp = new FlxGroup();
            blocksGrp = new FlxGroup();


            FlxCaveGeneratorExt caveExt = new FlxCaveGeneratorExt(100, 60, 0.48f, 5);
            string[,] caveLevel = caveExt.generateCaveLevel();

            //Optional step to print cave to the console.
            //caveExt.printCave(caveLevel);

            string newMap = caveExt.convertMultiArrayStringToString(caveLevel);

            //Create a tilemap and assign the cave map.
            FlxTilemap tiles = new FlxTilemap();
            tiles.auto = FlxTilemap.AUTO;
            tiles.indexOffset = 0;
            tiles.loadMap(newMap, FlxG.Content.Load<Texture2D>("level1_tiles"), 10, 10);
            tiles.setScrollFactors(0, 0);
            tiles.boundingBoxOverride = true;
            blocksGrp.add(tiles);

            Andre andre = new Andre(0, 0);
            charactersGrp.add(andre);

            add(charactersGrp);
            add(blocksGrp);

        }

        override public void update()
        {

            FlxU.collide(charactersGrp, blocksGrp);



            base.update();
        }


    }
}
