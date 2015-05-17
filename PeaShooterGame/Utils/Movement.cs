using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PeaShooterGame.Utils
{
    public class Movement
    {
        private Vector2 _speed;
        private Vector2 _result;
        private Actor _actor;

        public bool SelfUpdate { get; set; }
        public Vector2 Speed
        {
            get { return this._speed; }
            set
            {
                if (value.X < 0 && value.Y < 0) this._speed = Vector2.Zero;
                else if (value.X < 0) this._speed = new Vector2(0, value.Y);
                else if (value.Y < 0) this._speed = new Vector2(value.X, 0);
                else this._speed = value;
            }
        }

        public Movement(Actor actor, Vector2 speed)
        {
            this._actor = actor;
            this.Speed = speed;
            this.SelfUpdate = true;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    this._result = this._actor.Position - new Vector2(0, this.Speed.X);
                    break;
                case Direction.Down:
                    this._result = this._actor.Position + new Vector2(0, this.Speed.X);
                    break;
                case Direction.Left:
                    this._result = this._actor.Position - new Vector2(this.Speed.Y, 0);
                    break;
                case Direction.Right:
                    this._result = this._actor.Position + new Vector2(this.Speed.Y, 0);
                    break;
                default:
                    throw new FormatException();
            }

            if (this.SelfUpdate) this._actor.Position = this._result;
        }
    }

    public enum Direction { Up, Down, Left, Right }
}
