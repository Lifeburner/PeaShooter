using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeaShooterGame.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PeaShooterGame.Scenes
{
    public class TestScene : IScene
    {
        Texture2D spiderTexture;
        Animation spiderAnim;
        Actor spider;
        PhysicalBody spiderPhysics;
        Movement spiderMove;

        public void LoadContent(ContentManager content)
        {

            spiderTexture = content.Load<Texture2D>(@"Images/arachnobase");
            spiderAnim = new Animation(spiderTexture, spiderTexture.Width, spiderTexture.Height, 9, 1, 20);

            spider = new Actor(new Vector2(300, 300), spiderAnim, new Faction("NullFac"));
            spiderMove = new Movement(spider, new Vector2(1f, 3f));
            spider.Move = spiderMove;

            spiderPhysics = new PhysicalBody((int)spider.Position.X, (int)spider.Position.Y,
                                             spider.Anim.Dimension.X / spider.Anim.Frame.X,
                                             spider.Anim.Dimension.Y / spider.Anim.Frame.Y,
                                             spider);
            spider.Collider = spiderPhysics;

            //spider.Origin = Vector2.Zero;
            spider.Scale = new Vector2(0.5f, 0.5f);

        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                spider.Anim.Active = true;
                spider.Move.Move(Direction.Left);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                spider.Anim.Active = true;
                spider.Move.Move(Direction.Right);
            }
            else spider.Anim.Active = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Up)) spider.Move.Move(Direction.Up);

            // TODO: Add your update logic here
            spider.Update();
            //spider.Rotation += 0.01f;
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spider.Draw(spriteBatch);
        }
    }
}
