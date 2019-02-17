using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PizzaTown
{
	class Player
	{
		// Fields
		private int health;
		private int score;
		private Texture2D leftTexture;
		private Texture2D rightTexture;
		private Texture2D usedTexture;
		private Rectangle position;

		// Properties
		public int Health
		{
			get { return health; }
			set { health = value; }
		}
		public int Score
		{
			get { return score; }
			set { score = value; }
		}
		public int X
		{
			get { return position.X; }
			set { position.X = value; }
		}
		public int Y
		{
			get { return position.Y; }
			set { position.Y = value; }
		}
		public Rectangle Position { get { return position; } }
		

		// Constructor

		/// <summary>
		/// Creates a new player object
		/// </summary>
		/// <param name="leftTexture">The visual for when the player is moving left</param>
		/// <param name="rightTexture">The visual for when the player is moving right</param>
		/// <param name="position">The hitbox of the player</param>
		public Player(Texture2D leftTexture, Texture2D rightTexture, Rectangle position)
		{
			health = 100;
			score = 0;
			this.leftTexture = leftTexture;
			this.rightTexture = rightTexture;
			usedTexture = leftTexture;
			this.position = position;
		}

		// Methods
		public void Update()
		{
			ProcessInput();
		}

		public void Draw(SpriteBatch sb)
		{
			sb.Draw(usedTexture, position, Color.White);
		}

		/// <summary>
		/// Takes in input and moves the player
		/// </summary>
		protected void ProcessInput()
		{
			KeyboardState kbState = Keyboard.GetState();
			bool moving = false; // eliminates moving with both 1 and 2 key movement

			// 2-key movement
			if (kbState.IsKeyDown(Keys.W) && kbState.IsKeyDown(Keys.A)) // up and left
			{
				position.Y--;
				position.X--;
				moving = true;
				usedTexture = leftTexture;
			}
			else if (kbState.IsKeyDown(Keys.S) && kbState.IsKeyDown(Keys.A)) // down and left
			{
				position.Y++;
				position.X--;
				moving = true;
				usedTexture = leftTexture;
			}
			else if (kbState.IsKeyDown(Keys.S) && kbState.IsKeyDown(Keys.D)) // down and right
			{
				position.X++;
				position.Y++;
				moving = true;
				usedTexture = rightTexture;
			}
			else if (kbState.IsKeyDown(Keys.W) && kbState.IsKeyDown(Keys.D)) // up and right
			{
				position.Y--;
				position.X++;
				moving = true;
				usedTexture = rightTexture;
			}

			if (!moving)
			{
				// 1-key Movement
				if (kbState.IsKeyDown(Keys.W)) // up
				{
					position.Y--;
				}
				else if (kbState.IsKeyDown(Keys.A)) // left
				{
					position.X--;
					usedTexture = leftTexture;
				}
				else if (kbState.IsKeyDown(Keys.S)) // down
				{
					position.Y++;
				}
				else if (kbState.IsKeyDown(Keys.D)) // right
				{
					position.X++;
					usedTexture = rightTexture;
				}
			}
		}
	}
}
