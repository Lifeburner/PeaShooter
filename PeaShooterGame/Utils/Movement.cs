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

        public bool SelfUpdate { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Result { get; private set; }
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

        public Movement(Vector2 position, Vector2 speed)
        {
            this.Position = position;
            this.Speed = speed;
            this.SelfUpdate = true;
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    this.Result = this.Position - new Vector2(0, this.Speed.X);
                    break;
                case Direction.Down:
                    this.Result = this.Position + new Vector2(0, this.Speed.X);
                    break;
                case Direction.Left:
                    this.Result = this.Position - new Vector2(this.Speed.Y, 0);
                    break;
                case Direction.Right:
                    this.Result = this.Position + new Vector2(this.Speed.Y, 0);
                    break;
                default:
                    throw new FormatException();
            }

            if (this.SelfUpdate) this.Position = this.Result;
        }
    }

    public enum Direction { Up, Down, Left, Right }
}
