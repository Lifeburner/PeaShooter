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
        GameObject spider;

        public void LoadContent(ContentManager content)
        {

            spiderTexture = content.Load<Texture2D>(@"Images/arachnobase");
            spiderAnim = new Animation(spiderTexture.Width, spiderTexture.Height, 9, 1, 20);

            spider = new GameObject(spiderTexture, new Vector2(300, 300), spiderAnim);
            //spider.Origin = Vector2.Zero;
            spider.Scale = new Vector2(0.5f, 0.5f);

        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                spider.Anim.Active = true;
                spider.Position += new Vector2(-1f, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                spider.Anim.Active = true;
                spider.Position += new Vector2(1f, 0);
            }
            else spider.Anim.Active = false;

            // TODO: Add your update logic here
            spiderAnim.Update();
            //spider.Rotation += 0.01f;
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spider.Draw(spriteBatch);
        }
    }
}
