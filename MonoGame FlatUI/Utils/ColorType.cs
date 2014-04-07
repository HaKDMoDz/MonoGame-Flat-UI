using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File : ColorType
 * Author : Filipe
 * Date : 31/03/2014 11:09:41
 * Description :
 *
 */

namespace MonoGame.FlatUI
{
    public static class ColorType
    {
        private static Color GetColorFromHex(String hex)
        {
            Int32 r = Int32.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            Int32 g = Int32.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            Int32 b = Int32.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            return new Color(r, g, b);
        }

        public static Color Turquoise
        {
            get
            {
                return GetColorFromHex("1ABC9C");
            }
        }

        public static Color GreenSea
        {
            get
            {
                return GetColorFromHex("16A085");
            }
        }

        public static Color Emerald
        {
            get
            {
                return GetColorFromHex("2ECC71");
            }
        }

        public static Color Nephritis
        {
            get
            {
                return GetColorFromHex("27AE60");
            }
        }

        public static Color PeterRiver
        {
            get
            {
                return GetColorFromHex("3498DB");
            }
        }

        public static Color BelizeHole
        {
            get
            {
                return GetColorFromHex("2980B9");
            }
        }

        public static Color Amethyst
        {
            get
            {
                return GetColorFromHex("9B59B6");
            }
        }

        public static Color Wisteria
        {
            get
            {
                return GetColorFromHex("8E44AD");
            }
        }

        public static Color WetAsphalt
        {
            get
            {
                return GetColorFromHex("34495E");
            }
        }

        public static Color MidnightBlue
        {
            get
            {
                return GetColorFromHex("2C3E50");
            }
        }

        public static Color SunFlower
        {
            get
            {
                return GetColorFromHex("F1C40F");
            }
        }

        public static Color Orange
        {
            get
            {
                return GetColorFromHex("F39C12");
            }
        }

        public static Color Carrot
        {
            get
            {
                return GetColorFromHex("E67E22");
            }
        }

        public static Color Pumpkin
        {
            get
            {
                return GetColorFromHex("D35400");
            }
        }

        public static Color Alizarin
        {
            get
            {
                return GetColorFromHex("E74C3C");
            }
        }

        public static Color Pomegranate
        {
            get
            {
                return GetColorFromHex("C0392B");
            }
        }

        public static Color Clouds
        {
            get
            {
                return GetColorFromHex("ECF0F1");
            }
        }

        public static Color Silver
        {
            get
            {
                return GetColorFromHex("BDC3C7");
            }
        }

        public static Color Concrete
        {
            get
            {
                return GetColorFromHex("95A5A6");
            }
        }

        public static Color Asbestos
        {
            get
            {
                return GetColorFromHex("7F8C8D");
            }
        }

        public static Color GrayPanel
        {
            get
            {
                return GetColorFromHex("eff0f2");
            }
        }
    }
}
