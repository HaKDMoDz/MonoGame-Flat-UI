﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File : Label.cs
 * Author : Filipe
 * Date : 07/04/2014 15:41:55
 * Description :
 *
 */

namespace MonoGame.FlatUI
{
    public class Label : Control
    {
        #region FIELDS

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// Initialize a basic label
        /// </summary>
        /// <param name="engine">Engine pointer</param>
        public Label(FlatUIEngine engine)
            : base(engine)
        {
            this.Text = "";
            this.SetPosition(0, 0);
        }

        /// <summary>
        /// Initialize a label with a position
        /// </summary>
        /// <param name="engine">Engine pointer</param>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        public Label(FlatUIEngine engine, Int32 x, Int32 y)
            : base(engine)
        {
            this.Text = "";
            this.SetPosition(x, y);
        }

        /// <summary>
        /// Initialize a label with position and text
        /// </summary>
        /// <param name="engine">Engine pointer</param>
        /// <param name="x">X Position</param>
        /// <param name="y">Y Position</param>
        /// <param name="text">Label text</param>
        public Label(FlatUIEngine engine, Int32 x, Int32 y, String text)
            : base(engine)
        {
            this.Text = text;
            this.SetPosition(x, y);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Draw the label
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the label
        /// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
