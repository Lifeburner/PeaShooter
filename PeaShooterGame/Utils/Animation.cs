using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PeaShooterGame.Utils
{
    public class Animation
    {
        public Point Dimension { get; private set; }
        public Point Frame { get; private set; }
        public Rectangle Result { get; private set; }
        public bool Active { get; set; }
        public Texture2D Sprite { get; set; }
        
        private Point _frameDim;
        private int _currentX;
        private int _currentY;
        private int _framesToPass;
        private int _totalFrames;

        public Animation(Texture2D spriteSheet, Point dim, Point frame, int fps)
        {
            this.Sprite = spriteSheet;
            this.Dimension = dim;
            this.Frame = frame;
            this._frameDim = new Point(this.Dimension.X / this.Frame.X,
                                       this.Dimension.Y / this.Frame.Y);
            this.Result = new Rectangle(0, 0, this._frameDim.X, this._frameDim.Y);
            this._framesToPass = 60 / fps;
            this.Active = false;
        }

        public Animation(Texture2D spriteSheet, int dimWidth, int dimHeight, int frameX, int frameY, int fps)
        {
            this.Sprite = spriteSheet;
            this.Dimension = new Point(dimWidth, dimHeight);
            this.Frame = new Point(frameX, frameY);
            this._frameDim = new Point(this.Dimension.X / this.Frame.X,
                                       this.Dimension.Y / this.Frame.Y);
            this.Result = new Rectangle(0, 0, this._frameDim.X, this._frameDim.Y);
            this._framesToPass = 60 / fps;
            this.Active = false;
        }

        public void Update()
        {
            if (this.Active) this._Animate();
            this.Result = new Rectangle(this._currentX * this._frameDim.X,
                                        this._currentY * this._frameDim.Y,
                                        this._frameDim.X, this._frameDim.Y);
            if (_AnimCheck()) this._totalFrames = 0;
            else this._totalFrames++;
        }

        private bool _AnimCheck()
        {
            return this._totalFrames == this._framesToPass;
        }
        
        private void _Animate()
        {
            if (this._AnimCheck())
            {
                if (this._currentX == this.Frame.X - 1 || this.Frame.X == 1)
                {
                    this._currentX = 0;
                    if (this._currentY == this.Frame.Y - 1 || this.Frame.Y == 1) this._currentY = 0;
                    else this._currentY++;
                }
                else this._currentX++;
            }
        }
    }
}
