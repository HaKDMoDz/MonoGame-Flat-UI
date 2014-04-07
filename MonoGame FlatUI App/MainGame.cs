using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using MonoGame.FlatUI;

namespace MonoGame_FlatUI
{
    public class MainGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        FlatUIEngine Engine;

        Button Button1;
        Button Button2;
        Button Button3;

        Label Label1;

        Container Container1;

        public MainGame()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.Engine = new FlatUIEngine(this.Content, this.GraphicsDevice);

            this.Button1 = new Button(this.Engine, 10, 80, 290, 50, "Click me!");
            this.Button1.OnClick += Button1_OnClick;
            this.Button2 = new Button(this.Engine, 10, 10, 250, 50, "Not in container", ColorType.PeterRiver);
            this.Button3 = new Button(this.Engine, 10, 70, 250, 50, "Yeah Flat Button", ColorType.Alizarin);

            this.Label1 = new Label(this.Engine, 25, 10, "Welcome to MonoGame FlatUI");

            this.Container1 = new Container(this.Engine);
            this.Container1.SetPosition(350, 50);
            this.Container1.SetSize(310, 150);
            this.Container1.AddControl(this.Button1);
            this.Container1.AddControl(this.Label1);

            this.Engine.AddControl(this.Container1);
            this.Engine.AddControl(this.Button2);
            this.Engine.AddControl(this.Button3);
            
            base.Initialize();
        }

        void Button1_OnClick(object sender)
        {
            System.Windows.Forms.MessageBox.Show("Button 1 click");
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent() { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.Engine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(ColorType.Turquoise);

            this.Engine.Draw();

            base.Draw(gameTime);
        }
    }
}
