using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PeaShooterGame.Utils
{
    public class Actor : GameObject
    {
        public Faction UnitFaction { get; set; }
        public Movement Move { get; set; }

        public Actor(Vector2 position, Animation anim, Faction faction,
                     float depth = 0) : base(position, anim, depth)
        {
            this.UnitFaction = faction;
        }

        public Actor(Vector2 position, Vector2 scale, Animation anim, Faction faction,
                     float depth = 0) : base(position, scale, anim, depth)
        {
            this.UnitFaction = faction;
        }

        public override void Update()
        {


            base.Update();
        }
    }
}
