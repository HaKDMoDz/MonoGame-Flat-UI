using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame.FlatUI
{
    public abstract class Control
    {
        #region FIELDS

        public Boolean Enabled { get; set; }
        public Boolean Visible { get; set; }
        public Boolean Focus { get; set; }
        public Int32 X { get; private set; }
        public Int32 Y { get; private set; }
        public Int32 Width { get; private set; }
        public Int32 Height { get; private set; }
        public String Text { get; set; }

        public event MonoGameEventHandler OnEnter;
        public event MonoGameEventHandler OnLeave;
        public event MonoGameEventHandler OnHover;
        public event MonoGameEventHandler OnClick;
        public event MonoGameEventHandler OnPress;

        protected ControlState State { get; set; }

        protected FlatUIEngine EnginePointer { get; private set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(this.X, this.Y, this.Width, this.Height);
            }
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(this.X, this.Y);
            }
        }

        #endregion

        #region CONSTRUCTORS

        public Control(FlatUIEngine engine) 
        {
            this.State = ControlState.Normal;
            this.Enabled = true;
            this.Visible = true;
            this.Focus = false;
            this.EnginePointer = engine;
            this.EnginePointer.AddControl(this);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Set the control position
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public void SetPosition(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Set the control size
        /// </summary>
        /// <param name="width">Control width</param>
        /// <param name="height">Control height</param>
        public void SetSize(Int32 width, Int32 height)
        {
            this.Width = width;
            this.Height = height;
        }

        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);

        public virtual void MouseHover()
        {
            this.State = ControlState.Hover;
            if (this.Focus == false)
            {
                this.Focus = true;
                if (this.OnEnter != null)
                {
                    this.OnEnter(this);
                }
            }
            if (this.OnHover != null)
            {
                this.OnHover(this);
            }
        }

        public virtual void MousePress()
        {
            if (this.Focus == true)
            {
                this.State = ControlState.Press;
                if (this.OnPress != null)
                {
                    this.OnPress(this);
                }
            }
        }

        public virtual void MouseClick()
        {
            if (this.OnClick != null)
            {
                this.OnClick(this);
            }
        }

        public virtual void MouseLeave()
        {
            if (this.Focus == true)
            {
                this.Focus = false;
                this.State = ControlState.Normal;
                if (this.OnLeave != null)
                {
                    this.OnLeave(this);
                }
            }
        }

        #endregion
    }

    public enum ControlState
    {
        Normal = 0,
        Hover,
        Press
    }
}
