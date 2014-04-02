using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File : TextureHelper
 * Author : Filipe
 * Date : 01/04/2014 10:51:54
 * Description :
 *
 */

namespace MonoGame.FlatUI
{
    public class TextureHelper
    {
        public static Texture2D FillMaskColor(GraphicsDevice device, Texture2D maks, Color color)
        {
            Texture2D _texture = new Texture2D(device, maks.Width, maks.Height);
            Color[] _buttonData = new Color[maks.Width * maks.Height];
            Color[] _maskData = new Color[maks.Width * maks.Height];

            maks.GetData(_maskData);
            for (Int32 i = 0; i < _maskData.Length; ++i)
            {
                _buttonData[i] = _maskData[i];
                if (_buttonData[i].A >= 200)
                {
                    _buttonData[i] = color;
                }
            }
            _texture.SetData(_buttonData);
            return _texture;
        }
    }
}
