using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PeaShooterGame.Utils
{
    public class GameObject
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public Vector2 Origin { get; set; }
        public float Rotation { get; set; }
        public SpriteEffects Effects { get; set; }
        public float Depth { get; set; }
        public Animation Anim { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }

        public GameObject(Vector2 position, Animation anim, float depth = 0)
        {
            this.Name = "";
            this.Tag = "";
            this.Position = position;
            this.Scale = new Vector2(1f, 1f);
            this.Rotation = 0;
            this.Effects = SpriteEffects.None;
            this.Depth = depth;
            this.Anim = anim;
            if (anim == null) this.Origin = new Vector2(this.Anim.Sprite.Width / 2f,
                                                        this.Anim.Sprite.Height / 2f);
            else this.Origin = new Vector2(anim.Result.Width / 2f, anim.Result.Height / 2f);
        }

        public GameObject(Vector2 position, Vector2 scale, Animation anim, float depth = 0)
        {
            this.Name = "";
            this.Tag = "";
            this.Position = position;
            this.Scale = scale;
            this.Rotation = 0;
            this.Effects = SpriteEffects.None;
            this.Depth = depth;
            this.Anim = anim;
            if (anim == null) this.Origin = new Vector2(this.Anim.Sprite.Width / 2f,
                                                        this.Anim.Sprite.Height / 2f);
            else this.Origin = new Vector2(anim.Result.Width / 2f, anim.Result.Height / 2f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Anim != null)
            {
                spriteBatch.Draw(this.Anim.Sprite, this.Position, this.Anim.Result, Color.White,
                                 this.Rotation, this.Origin, this.Scale, this.Effects, this.Depth); 
            }
            else
            {
                spriteBatch.Draw(this.Anim.Sprite, this.Position, null, Color.White, this.Rotation,
                                 this.Origin, this.Scale, this.Effects, this.Depth);
            }
        }
    }
}
