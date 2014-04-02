using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File : Fonts
 * Author : Filipe
 * Date : 01/04/2014 12:00:54
 * Description :
 *
 */

namespace MonoGame.FlatUI
{
    public class Fonts
    {
        /// <summary>
        /// Draw centered text in rectangle
        /// </summary>
        /// <param name="batch">SpriteBatch</param>
        /// <param name="font">Font</param>
        /// <param name="rectangle">Dest rectangle</param>
        /// <param name="text">Text</param>
        /// <param name="color">Text color</param>
        public static void DrawCenteredText(SpriteBatch batch, SpriteFont font, Rectangle rectangle, String text, Color color)
        {
            Vector2 size = font.MeasureString(text);
            Vector2 topLeft = new Vector2(rectangle.Center.X, rectangle.Center.Y) - (size * 0.5f);
            batch.DrawString(font, text, topLeft, color);
        }
    }
}
