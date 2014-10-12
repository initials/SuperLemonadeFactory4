using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using org.flixel;

using System.Linq;
using System.Xml.Linq;

using SuperLemonadeFactory4.characters;

using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics;

namespace SuperLemonadeFactory4
{
    public class IntroState : FlxState
    {

        FlxGroup charactersGrp;
        FlxGroup blocksGrp;
        FlxGroup movingBlocksGrp;
        FlxGroup doors;
        FlxGroup crates;

        World _world;

        override public void create()
        {
            FlxG.backColor = FlxColor.ToColor("dedbc3");
            base.create();

            _world = new World(new Vector2(0, 98.0f));

            charactersGrp = new FlxGroup();
            blocksGrp = new FlxGroup();
            movingBlocksGrp = new FlxGroup();
            doors = new FlxGroup();
            crates = new FlxGroup();
            

            //Dictionary<string,string> levelAttrs = FlxXMLReader.readAttributesFromOelFile("ogmo/level1.oel", "level/grid");
            //FlxTilemap tiles = new FlxTilemap();
            //tiles.useExtraMiddleTiles = false;
            //tiles.auto = FlxTilemap.AUTO;
            //tiles.indexOffset = -1;
            //tiles.loadMap(levelAttrs["grid"], FlxG.Content.Load<Texture2D>("level1_tiles"), 10, 10);
            //tiles.setScrollFactors(0, 0);
            //tiles.boundingBoxOverride = true;
            
            //blocksGrp.add(tiles);

            List<Dictionary<string, string>> lblocks = FlxXMLReader.readNodesFromOelFile("ogmo/level1.oel", "level/grid");
            foreach (Dictionary<string, string> nodes in lblocks)
            {
                FarTileblock t = new FarTileblock(Convert.ToInt32(nodes["x"]) + (Convert.ToInt32(nodes["w"]) / 2), Convert.ToInt32(nodes["y"]) + (Convert.ToInt32(nodes["h"]) / 2), Convert.ToInt32(nodes["w"]), Convert.ToInt32(nodes["h"]), _world);
                t.auto = FlxTilemap.AUTO;
                t.loadTiles("level1_tiles", 10, 10, 0);
                blocksGrp.add(t);
                t._body.BodyType = BodyType.Static;


                FlxTileblock t2 = new FlxTileblock(Convert.ToInt32(nodes["x"]), Convert.ToInt32(nodes["y"]), Convert.ToInt32(nodes["w"]), Convert.ToInt32(nodes["h"]));
                t2.auto = FlxTilemap.AUTO;
                t2.loadTiles("level1_tiles", 10, 10, 0);
                blocksGrp.add(t2);




            }

            List<Dictionary<string, string>> blocks = FlxXMLReader.readNodesFromOelFile("ogmo/level1.oel", "level/tileblocks");
            foreach (Dictionary<string, string> nodes in blocks)
            {

                if (nodes["Name"] == "elevator")
                {
                    MovingBlock block = new MovingBlock(Convert.ToInt32(nodes["x"]), Convert.ToInt32(nodes["y"]));
                    block.loadGraphic("level1_specialBlock", false, true, 40, 20);
                    movingBlocksGrp.add(block);

                    FlxPath xpath = new FlxPath(null);
                    xpath.add(Convert.ToInt32(nodes["x"]) + 20, Convert.ToInt32(nodes["y"]) + 10);
                    xpath.addPointsUsingStrings(nodes["pathNodesX"], nodes["pathNodesY"], 20, 10);
                    block.followPath(xpath, 80, FlxObject.PATH_FORWARD, false);


                }
                if (nodes["Name"] == "door")
                {
                    Door door = new Door(Convert.ToInt32(nodes["x"]), Convert.ToInt32(nodes["y"])-100);
                    doors.add(door);



                }
                //foreach (var item in nodes)
                //{
                //    Console.WriteLine("{0} {1}", item.Key, item.Value);
                //}
                

            }
            //bat = new Bat(x, y);
            //actors.add(bat);
            //Console.WriteLine("Building a bat {0} {1} {2} {3}", x, y, PathNodesX, PathNodesY);

            //if (PathNodesX != "" && PathNodesY != "")
            //{
            //    Console.WriteLine("Building a path {0} {1} {2}", PathNodesX, PathNodesY, PathCornering);

            //    FlxPath xpath = new FlxPath(null);
            //    xpath.add(x, y);
            //    xpath.addPointsUsingStrings(PathNodesX, PathNodesY);
            //    bat.followPath(xpath, PathSpeed, PathType, false);
            //    bat.pathCornering = PathCornering;


            //}




            Andre andre = new Andre(0, 0);
            charactersGrp.add(andre);

            Liselot liselot = new Liselot(40, 40);
            charactersGrp.add(liselot);

            Army army = new Army(30, 20);
            charactersGrp.add(army);

            Inspector inspector = new Inspector(50, 50);
            charactersGrp.add(inspector);

            Worker worker = new Worker(60,60);
            charactersGrp.add(worker);

            Chef chef = new Chef(100, 30);
            charactersGrp.add(chef);


            FlxTileblock bg = new FlxTileblock(0, 0, 240, 800);
            bg.auto = FlxTileblock.RANDOM;
            bg.loadTiles("level1_shelfTile", 80, 80, 0);
            add(bg);

            bg = new FlxTileblock(640, 0, 240, 800);
            bg.auto = FlxTileblock.RANDOM;
            bg.loadTiles("level1_shelfTile", 80, 80, 0);
            add(bg);

            for (int i = 0; i < 5; i++)
            {
                SmallCrate c = new SmallCrate((int)FlxU.random(0, FlxG.width), (int)FlxU.random(0, FlxG.height-100));
                crates.add(c);
            }

            for (int i = 0; i < 5; i++)
            {
                Bottle b = new Bottle((int)FlxU.random(0, FlxG.width), (int)FlxU.random(0, FlxG.height-100));
                crates.add(b);
            }
            for (int i = 0; i < 55; i++)
            {
                Fruit f = new Fruit((int)FlxU.random(0, FlxG.width), (int)FlxU.random(0, FlxG.height - 100), _world);
                f._body.ApplyLinearImpulse(new Vector2(20, 2120));


                crates.add(f);
            }


            add(doors);
            add(charactersGrp);
            add(blocksGrp);
            add(movingBlocksGrp);
            add(crates);

            FlxG.showHud();
            FlxG.setHudTextPosition(1, FlxG.width / 2, 10);
            FlxG.setHudTextScale(1, 3);
        }

        public bool overlappedCrate(object sender, FlxSpriteCollisionEvent e)
        {
            
            FlxG.score++;

            if (e.Object2.GetType().ToString().EndsWith("Fruit"))
            {
                ((Fruit)(e.Object2))._body.SetTransform(new Vector2((int)FlxU.random(0, 0), (int)FlxU.random(0, 0)), 0.0f);
                //e.Object2.reset(-110, -110);
                e.Object2.debugName = "repack";
                ((Fruit)(e.Object2))._body.Enabled = false;


            }
            if (e.Object2.GetType().ToString().EndsWith("Crate"))
            {
                foreach (var item in crates.members)
                {
                    if (item.GetType().ToString().EndsWith("Fruit")) //&& item.debugName == "repack"
                    {
                        //e.Object2.reset(e.Object2.x, e.Object2.y);
                        ((Fruit)(item))._body.SetTransform(new Vector2(e.Object2.x, e.Object2.y), 0.0f);
                        item.debugName = "";
                        ((Fruit)(item))._body.Enabled = true;

                    }
                }
                e.Object2.reset((int)FlxU.random(0, FlxG.width), (int)FlxU.random(0, FlxG.height - 100));
            }

            

            return true;
        }
        public bool overlapped(object sender, FlxSpriteCollisionEvent e)
        {
            //if (e.Object2 == doors.members[1])
            //{
            //    e.Object1.x = doors.members[0].x+70;
            //    e.Object1.y = doors.members[0].y + 80;
            //}
            if (e.Object2 == doors.members[0])
            {
                e.Object1.x = doors.members[1].x;
                e.Object1.y = doors.members[1].y + 80;
            }
            return true;
        }

        override public void update()
        {
            _world.Step(Math.Min((float)FlxG.elapsedAsGameTime.ElapsedGameTime.TotalSeconds, (1f / 30f)));

            if (FlxG.keys.justPressed(Keys.B))
            {
                FlxG.showBounds = !FlxG.showBounds ;
            }

            FlxG.setHudText(1, FlxG.score.ToString() );

            FlxU.collide(movingBlocksGrp, crates);
            FlxU.collide(blocksGrp, crates);
            FlxU.collide(charactersGrp, blocksGrp);
            FlxU.collide(charactersGrp, movingBlocksGrp);
            FlxU.overlap(charactersGrp, doors, overlapped);
            FlxU.overlap(charactersGrp, crates, overlappedCrate);

            if (FlxControl.ACTIONJUSTPRESSED)
            {


                foreach (MovingBlock block in movingBlocksGrp.members)
                {
                    block.forward = !block.forward;

                    if (block.forward && block.velocity.X == 0 && block.velocity.Y == 0)
                        block.startFollowingPath(FlxObject.PATH_FORWARD);
                    if (!block.forward && block.velocity.X == 0 && block.velocity.Y == 0)
                        block.startFollowingPath(FlxObject.PATH_BACKWARD);
                }
                

            }


            base.update();
        }


    }
}
