using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * File : Mouse
 * Author : Filipe
 * Date : 01/04/2014 16:04:56
 * Description :
 *
 */

namespace MonoGame.FlatUI
{
    public enum MouseButton
    {
        LeftButton = 0,
        RightButton,
        MiddleButton,
        XButton1,
        XButton2
    }

    public static class MouseExt
    {
        private static MouseState CurrentMouseState { get; set; }
        private static MouseState LastMouseState { get; set; }

        /// <summary>
        /// Check if the mouse position is in the rectangle
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="rectangle"></param>
        /// <returns></returns>
        public static Boolean IsInRectangle(this MouseState mouse, Rectangle rectangle)
        {
            return rectangle.Contains(new Point(mouse.X, mouse.Y));
        }

        /// <summary>
        /// Check if a mouse button is pressed
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public static Boolean IsMouseDown(this MouseState mouse, ButtonState button)
        {
            return button == ButtonState.Pressed;
        }

        /// <summary>
        /// Check if a mouse button is released
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public static Boolean IsMouseUp(this MouseState mouse, ButtonState button)
        {
            return button == ButtonState.Released;
        }

        /// <summary>
        /// Mouse click check
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="button"></param>
        /// <returns>Clicked or not</returns>
        public static Boolean MouseClick(this MouseState mouse, MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton :
                    return (LastMouseState.LeftButton == ButtonState.Pressed && CurrentMouseState.LeftButton == ButtonState.Released);
                case MouseButton.RightButton:
                    return (LastMouseState.RightButton == ButtonState.Pressed && CurrentMouseState.RightButton == ButtonState.Released);
                case MouseButton.MiddleButton:
                    return (LastMouseState.MiddleButton == ButtonState.Pressed && CurrentMouseState.MiddleButton == ButtonState.Released);
                case MouseButton.XButton1:
                    return (LastMouseState.XButton1 == ButtonState.Pressed && CurrentMouseState.XButton1 == ButtonState.Released);
                case MouseButton.XButton2:
                    return (LastMouseState.XButton2 == ButtonState.Pressed && CurrentMouseState.XButton2 == ButtonState.Released);
                default: return false;
            }
        }

        /// <summary>
        /// Check if the mouse button is pressed
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public static Boolean MouseDown(this MouseState mouse, MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton: return CurrentMouseState.LeftButton == ButtonState.Pressed;
                case MouseButton.RightButton: return CurrentMouseState.RightButton == ButtonState.Pressed;
                case MouseButton.MiddleButton: return CurrentMouseState.MiddleButton == ButtonState.Pressed;
                case MouseButton.XButton1: return CurrentMouseState.XButton1 == ButtonState.Pressed;
                case MouseButton.XButton2: return CurrentMouseState.XButton2 == ButtonState.Pressed;
                default: return false;
            }
        }

        /// <summary>
        /// Check if the mouse button is released
        /// </summary>
        /// <param name="mouse"></param>
        /// <param name="button"></param>
        /// <returns></returns>
        public static Boolean MouseUp(this MouseState mouse, MouseButton button)
        {
            switch (button)
            {
                case MouseButton.LeftButton: return CurrentMouseState.LeftButton == ButtonState.Released;
                case MouseButton.RightButton: return CurrentMouseState.RightButton == ButtonState.Released;
                case MouseButton.MiddleButton: return CurrentMouseState.MiddleButton == ButtonState.Released;
                case MouseButton.XButton1: return CurrentMouseState.XButton1 == ButtonState.Released;
                case MouseButton.XButton2: return CurrentMouseState.XButton2 == ButtonState.Released;
                default: return false;
            }
        }

        /// <summary>
        /// Update mouse states
        /// </summary>
        /// <param name="mouse"></param>
        public static void Update(this MouseState mouse)
        {
            LastMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
        }

        /// <summary>
        /// Return the current mouse state
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns>Current mouse state</returns>
        public static MouseState GetCurrentMouseState(this MouseState mouse)
        {
            return CurrentMouseState;
        }

        /// <summary>
        /// Return the last mouse state
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns>Last mouse state</returns>
        public static MouseState GetLastMouseState(this MouseState mouse)
        {
            return LastMouseState;
        }


    }
}
