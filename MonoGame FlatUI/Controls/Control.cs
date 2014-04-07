using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame.FlatUI
{
    /// <summary>
    /// MonoGame FlatUI Control class
    /// </summary>
    public abstract class Control
    {
        #region FIELDS

        public Boolean Enabled { get; set; }
        public Boolean Visible { get; set; }
        public Boolean Focus { get; set; }
        public Int32 X { get; protected set; }
        public Int32 Y { get; protected set; }
        public Int32 Width { get; protected set; }
        public Int32 Height { get; protected set; }
        public String Text { get; set; }

        public event MonoGameEventHandler OnEnter;
        public event MonoGameEventHandler OnLeave;
        public event MonoGameEventHandler OnHover;
        public event MonoGameEventHandler OnClick;
        public event MonoGameEventHandler OnPress;

        public Rectangle Rectangle
        {
            get
            {
                if (this.ParentControl == null)
                {
                    return new Rectangle(this.X, this.Y, this.Width, this.Height);
                }
                else
                {
                    return new Rectangle(this.X + this.ParentControl.X,
                        this.Y + this.ParentControl.Y,
                        this.Width,
                        this.Height);
                }
            }
        }

        public Vector2 Position
        {
            get
            {
                if (this.ParentControl == null)
                {
                    return new Vector2(this.X, this.Y);
                }
                else
                {
                    return new Vector2(this.X + this.ParentControl.X, this.Y + this.ParentControl.Y);
                }
            }
        }

        protected ControlState State { get; set; }

        internal FlatUIEngine EnginePointer { get; set; }

        internal Control ParentControl { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a control
        /// </summary>
        /// <param name="engine">Engine Pointer</param>
        public Control(FlatUIEngine engine) 
        {
            this.State = ControlState.Normal;
            this.Enabled = true;
            this.Visible = true;
            this.Focus = false;
            this.EnginePointer = engine;
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

        public virtual void Update()
        {
            MouseState _state = Mouse.GetState();
            if (_state.IsInRectangle(this.Rectangle) == true)
            {
                this.MouseHover();
                if (_state.IsMouseDown(_state.LeftButton) == true)
                {
                    this.MousePress();
                }
                if (_state.MouseClick(MouseButton.LeftButton) == true)
                {
                    this.MouseClick();
                }
            }
            else
            {
                this.MouseLeave();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }

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
