using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace PizzaTown
{
	public enum MenuState
	{
		Main, 
		Game, 
		Shop, 
		GameOver
	}
	
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		SpriteFont fontArial16;

		// Field components for drawing to the screen
		Texture2D playerLeft;
		Texture2D playerRight;
		Texture2D mountLeft;
		Texture2D mountRight;
		Texture2D pizzaPic;
		Rectangle playerBox;
		Rectangle mountBox;

		// Other Fields
		MenuState menuState;
		Random rng;
		Player player;
		List<Collectable> pizzas;
		double timer;
		int extraTime;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			rng = new Random();
			pizzas = new List<Collectable>();
			timer = 15.0;
			extraTime = 0;
			
			//mountBox = new Rectangle( , , 70, 50);
			
			playerBox = new Rectangle(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2, 80, 80);

			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			playerLeft = Content.Load<Texture2D>("boyLeft");
			playerRight = Content.Load<Texture2D>("boyRight");
			mountLeft = Content.Load<Texture2D>("corgiLeft");
			mountRight = Content.Load<Texture2D>("corgiRight");
			pizzaPic = Content.Load<Texture2D>("pizza");
			fontArial16 = Content.Load<SpriteFont>("arial16");

			player = new Player(playerLeft, playerRight, playerBox);

			for (int x = 0; x < 5; x++)
			{
				pizzas.Add(new Collectable(pizzaPic, new Rectangle(rng.Next(GraphicsDevice.Viewport.Width) - 30, rng.Next(GraphicsDevice.Viewport.Height) - 20, 50, 50)));
			}
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			switch(menuState)
			{
				case MenuState.Main:
					// Enters the game if ENTER is pressed
					KeyboardState kb = Keyboard.GetState();
					if (kb.IsKeyDown(Keys.Enter))
						menuState = MenuState.Game;
					break;

				case MenuState.Game:
					// Checks to see if any pizzas are left on the screen
					bool pizzasLeft = false;
					foreach(Collectable pizza in pizzas)
					{
						if (pizza.IsActive)
							pizzasLeft = true;
					}
					// If no pizzas are left on the screen, or the timer 
					// runs out the player enters the shop
					if (!pizzasLeft || timer <= 0)
						menuState = MenuState.Shop;

					// If the player dies (health = 0) the game is over
					if (player.Health <= 0)
						menuState = MenuState.GameOver;

					timer -= 0.1;
					player.Update();
					break;

				case MenuState.Shop:
					// Re-enters the game when the player presses ENTER
					kb = Keyboard.GetState();
					if (kb.IsKeyDown(Keys.Enter))
					{
						timer = 15 + extraTime;
						menuState = MenuState.Game;
					}
					break;

				case MenuState.GameOver:
					// Returns back to the Main Menu when ENTER is pressed
					kb = Keyboard.GetState();
					if (kb.IsKeyDown(Keys.Enter))
						menuState = MenuState.Main;
					break;
			}
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			switch (menuState)
			{
				case MenuState.Main:
					spriteBatch.DrawString(fontArial16, "Main Menu", new Vector2((GraphicsDevice.Viewport.Width / 2) - 50, 10), Color.Black);
					break;
				case MenuState.Game:
					player.Draw(spriteBatch);
					spriteBatch.DrawString(fontArial16, "Time: " + string.Format("{0:0.00}", timer), new Vector2(GraphicsDevice.Viewport.Width - 120, 10), Color.Black);
					spriteBatch.DrawString(fontArial16, "Pizzas Collected: " + player.Score, new Vector2(10, 10), Color.Black);
					spriteBatch.DrawString(fontArial16, "Health: " + player.Health, new Vector2(10, 30), Color.Black);

					// Checks for collisions, disabling 
					for (int x = 0; x < pizzas.Count; x++)
					{
						if (player.Position.Intersects(pizzas[x].Position))
						{
							if (pizzas[x].IsActive)
							{
								player.Score += 1;
								pizzas[x].IsActive = false;
							}
						}

						if(pizzas[x].IsActive)
							pizzas[x].Draw(spriteBatch);
					}
					break;
				case MenuState.Shop:
					spriteBatch.DrawString(fontArial16, "Shop", new Vector2((GraphicsDevice.Viewport.Width / 2) - 50, 10), Color.Black);
					break;
				case MenuState.GameOver:
					spriteBatch.DrawString(fontArial16, "Game Over", new Vector2((GraphicsDevice.Viewport.Width / 2) - 50, 10), Color.Black);
					break;
			}
			
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
