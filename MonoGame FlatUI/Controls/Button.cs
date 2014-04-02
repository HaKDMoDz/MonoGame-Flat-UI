using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File : Bouton
 * Author : Filipe
 * Date : 30/03/2014 21:37:37
 * Description :
 *
 */

namespace MonoGame.FlatUI
{
    public class Button : Control
    {
        #region FIELDS

        private Color NormalColor { get; set; }
        private Color HoverColor { get; set; }
        private Color PressColor { get; set; }

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a new button
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        public Button(FlatUIEngine engine)
            : base(engine) 
        {
            this.NormalColor = ColorType.Turquoise;
            this.InitializeColors();
        }

        /// <summary>
        /// Initialize a new button with his position and size
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">Button width</param>
        /// <param name="height">Button height</param>
        public Button(FlatUIEngine engine, Int32 x, Int32 y, Int32 width, Int32 height)
            : base(engine)
        {
            this.SetPosition(x, y);
            this.SetSize(width, height);
            this.NormalColor = ColorType.Turquoise;
            this.InitializeColors();
        }

        /// <summary>
        /// Initialize a new button with position, size and text
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">Button width</param>
        /// <param name="height">Button height</param>
        /// <param name="text">Button text</param>
        public Button(FlatUIEngine engine, Int32 x, Int32 y, Int32 width, Int32 height, String text)
            : base(engine)
        {
            this.SetPosition(x, y);
            this.SetSize(width, height);
            this.Text = text;
            this.NormalColor = ColorType.Turquoise;
            this.InitializeColors();
        }

        /// <summary>
        /// Initialize a new button with position, size and text
        /// </summary>
        /// <param name="engine">UI Engine pointer</param>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="width">Button width</param>
        /// <param name="height">Button height</param>
        /// <param name="text">Button text</param>
        /// <param name="color">Button color</param>
        public Button(FlatUIEngine engine, Int32 x, Int32 y, Int32 width, Int32 height, String text, Color color)
            : base(engine)
        {
            this.SetPosition(x, y);
            this.SetSize(width, height);
            this.Text = text;
            this.NormalColor = color;
            this.InitializeColors();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Intialize Hover and Press color
        /// </summary>
        private void InitializeColors()
        {
            this.HoverColor = new Color(this.NormalColor.R + 46, this.NormalColor.G + 13, this.NormalColor.B + 19);
            this.PressColor = new Color(this.NormalColor.R - 4, this.NormalColor.G - 28, this.NormalColor.B - 23);
        }

        /// <summary>
        /// Update the button
        /// </summary>
        public override void Update()
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

        /// <summary>
        /// Draw the button
        /// </summary>
        /// <param name="spriteBatch">Engine sprite batch</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle[] _rectangles = new Rectangle[5];
            _rectangles[0] = new Rectangle(0, 0, 5, 5);
            _rectangles[1] = new Rectangle(5, 0, 1, 1);
            _rectangles[2] = new Rectangle(this.EnginePointer.Masks[0].Width - 5, 0, 5, 5);
            _rectangles[3] = new Rectangle(0, this.EnginePointer.Masks[0].Height - 5, 5, 5);
            _rectangles[4] = new Rectangle(this.EnginePointer.Masks[0].Width - 5, this.EnginePointer.Masks[0].Height - 5, 5, 5);

            Texture2D _button = null;
            Color _color = this.NormalColor;
            if (this.State == ControlState.Hover)
            {
                _color = this.HoverColor;
            }
            else if (this.State == ControlState.Press)
            {
                _color = this.PressColor;
            }
            _button = TextureHelper.FillMaskColor(this.EnginePointer.GraphicsDevice, this.EnginePointer.Masks[0], _color);

            spriteBatch.Draw(_button, this.Position, _rectangles[0], Color.White);
            spriteBatch.Draw(_button, new Rectangle(this.X + 5, this.Y, this.Width - 10, 5), _rectangles[1], Color.White);
            spriteBatch.Draw(_button, new Vector2(this.X + this.Width - 5, this.Y), _rectangles[2], Color.White);
            spriteBatch.Draw(_button, new Rectangle(this.X, this.Y + 5, this.Width, this.Height - 10), _rectangles[1], Color.White);
            spriteBatch.Draw(_button, new Vector2(this.X, this.Y + this.Height - 5), _rectangles[3], Color.White);
            spriteBatch.Draw(_button, new Rectangle(this.X + 5, this.Y + this.Height - 5, this.Width - 10, 5), _rectangles[1], Color.White);
            spriteBatch.Draw(_button, new Vector2(this.X + this.Width - 5, this.Y + this.Height - 5), _rectangles[4], Color.White);

            Fonts.DrawCenteredText(spriteBatch, this.EnginePointer.Font, new Rectangle(this.X, this.Y, this.Width, this.Height), this.Text, Color.White);
        }

        #endregion
    }
}
