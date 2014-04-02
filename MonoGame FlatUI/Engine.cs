using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

/*
 * File : Engine
 * Author : Filipe
 * Date : 30/03/2014 19:33:00
 * Description :
 *
 */

namespace MonoGame.FlatUI
{
    public class FlatUIEngine
    {
        #region FIELDS

        private ContentManager Content { get; set; }

        internal GraphicsDevice GraphicsDevice { get; private set; }

        internal Texture2D[] Masks { get; private set; }

        internal SpriteFont Font { get; private set; }

        private SpriteBatch SpriteBatch { get; set; }

        protected List<Control> Controls { get; private set; }

        #endregion

        #region CONSTRUCTORS

        public FlatUIEngine(ContentManager contentManager, GraphicsDevice graphicsDevice) 
        {
            this.Content = contentManager;
            this.GraphicsDevice = graphicsDevice;
            this.SpriteBatch = new SpriteBatch(graphicsDevice);
            this.Initialize();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Initialize the Engine
        /// </summary>
        private void Initialize()
        {
            this.Controls = new List<Control>();
            // Load Masks
            this.Masks = new Texture2D[2];
            this.Masks[0] = this.Content.Load<Texture2D>(@"Theme\mask-square.png");
            this.Masks[1] = this.Content.Load<Texture2D>(@"Theme\mask.png");
            // Load font
            this.Font = this.Content.Load<SpriteFont>(@"Theme\flat-ui");
        }

        /// <summary>
        /// Update all visible controls
        /// </summary>
        public void Update()
        {
            Mouse.GetState().Update();
            foreach (Control _control in this.Controls)
            {
                if (_control.Visible == true)
                {
                    _control.Update();
                }
            }
        }

        /// <summary>
        /// Draw all visible controls
        /// </summary>
        public void Draw()
        {
            this.SpriteBatch.Begin();
            foreach (Control _control in this.Controls)
            {
                if (_control.Visible == true)
                {
                    _control.Draw(this.SpriteBatch);
                }
            }
            this.SpriteBatch.End();
        }

        /// <summary>
        /// Add control to the engine
        /// </summary>
        /// <param name="control">Control to add</param>
        public void AddControl(Control control)
        {
            if (this.Controls.Contains(control) == false)
            {
                this.Controls.Add(control);
            }
        }

        /// <summary>
        /// Remove a control from the engine
        /// </summary>
        /// <param name="control">Control to remove</param>
        public void RemoveControl(Control control)
        {
            if (this.Controls.Contains(control) == true)
            {
                this.Controls.Remove(control);
            }
        }

        #endregion
    }
}
