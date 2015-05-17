using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PeaShooterGame.Utils
{
    public class PhysicalBody
    {
        private GameObject _object;
        private static float _gravitationalPull = 1f;

        public Rectangle BoundingBox { get; set; }
        public float Mass { get; set; }
        public bool GravityEnabled { get; set; }

        public PhysicalBody(Rectangle box, GameObject gObject, float mass = 1f, bool gravity = true)
        {
            this._object = gObject;
            this.BoundingBox = box;
            this.Mass = mass;
            this.GravityEnabled = gravity;
        }

        public PhysicalBody(int boxX, int boxY, int boxWidth, int boxHeight, GameObject gObject,
            float mass = 1f, bool gravity = true)
        {
            this._object = gObject;
            this.BoundingBox = new Rectangle(boxX, boxY, boxWidth, boxHeight);
            this.Mass = mass;
            this.GravityEnabled = gravity;
        }

        public bool CollisionCheck(PhysicalBody collider)
        {
            return this.BoundingBox.Intersects(collider.BoundingBox);
        }

        public void Update ()
        {
            if (this.GravityEnabled) this._object.Position += new Vector2(0, _gravitationalPull);
        }
    }
}
