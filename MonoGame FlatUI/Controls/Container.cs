using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File : Container.cs
 * Author : Filipe
 * Date : 07/04/2014 11:35:52
 * Description :
 *
 */

namespace MonoGame.FlatUI
{
    public class Container : Control
    {
        #region FIELDS

        private List<Control> Controls { get; set; }
        private Color Color { get; set; }

        #endregion

        #region CONSTRUCTORS

        public Container(FlatUIEngine engine)
            : base(engine)
        {
            this.Controls = new List<Control>();
            this.Color = ColorType.GrayPanel;
            this.SetPosition(0, 0);
            this.SetSize(100, 50);
        }

        public Container(FlatUIEngine engine, Int32 x, Int32 y, Int32 width, Int32 height)
            : base(engine)
        {
            this.Controls = new List<Control>();
            this.Color = ColorType.GrayPanel;
            this.SetPosition(x, y);
            this.SetSize(width, height);
        }

        public Container(FlatUIEngine engine, Int32 x, Int32 y, Int32 width, Int32 height, Color color)
            : base(engine)
        {
            this.Controls = new List<Control>();
            this.Color = color;
            this.SetPosition(x, y);
            this.SetSize(width, height);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Draw the container and his controls
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.Color != null)
            {
                Rectangle[] _rectangles = TextureHelper.GetRectanglesFromRoundRectMask(this.EnginePointer.Masks[0]);
                Texture2D _container = TextureHelper.FillMaskColor(this.EnginePointer.GraphicsDevice, this.EnginePointer.Masks[0], this.Color);
                spriteBatch.Draw(_container, this.Position, _rectangles[0], Color.White);
                spriteBatch.Draw(_container, new Rectangle(this.X + 5, this.Y, this.Width - 10, 5), _rectangles[1], Color.White);
                spriteBatch.Draw(_container, new Vector2(this.X + this.Width - 5, this.Y), _rectangles[2], Color.White);
                spriteBatch.Draw(_container, new Rectangle(this.X, this.Y + 5, this.Width, this.Height - 10), _rectangles[1], Color.White);
                spriteBatch.Draw(_container, new Vector2(this.X, this.Y + this.Height - 5), _rectangles[3], Color.White);
                spriteBatch.Draw(_container, new Rectangle(this.X + 5, this.Y + this.Height - 5, this.Width - 10, 5), _rectangles[1], Color.White);
                spriteBatch.Draw(_container, new Vector2(this.X + this.Width - 5, this.Y + this.Height - 5), _rectangles[4], Color.White);
            }
            foreach (Control _control in this.Controls)
            {
                _control.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Update all controls of the container
        /// </summary>
        public override void Update()
        {
            foreach (Control _control in this.Controls)
            {
                _control.Update();
            }
        }

        /// <summary>
        /// Add a control to the container
        /// </summary>
        /// <param name="control">Control to add</param>
        public void AddControl(Control control)
        {
            if (control == null)
            {
                throw new NullReferenceException("Cannot add a null object");
            }
            control.ParentControl = this;
            control.EnginePointer = this.EnginePointer;
            if (this.Controls.Contains(control) == false)
            {
                this.Controls.Add(control);
            }
        }

        /// <summary>
        /// Remove a control from the container
        /// </summary>
        /// <param name="control">Control to remove</param>
        public void RemoveControl(Control control)
        {
            if (control == null)
            {
                throw new NullReferenceException("Cannot delete a null object");
            }
            if (this.Controls.Contains(control) == true)
            {
                this.Controls.Remove(control);
            }
        }
        #endregion
    }
}
