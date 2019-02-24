using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTown
{
	class Button
	{
		private Texture2D image;
		//private Texture2D otherImage;
		private Rectangle position;

		public Button(Texture2D image, Rectangle position)
		{
			this.image = image;
			//this.otherImage = otherImage;
			this.position = position;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			MouseState mouseState = Mouse.GetState();

			//if ((mouseState.X < position.X + position.Width) && (mouseState.X > position.X)
			//	&& (mouseState.Y > position.Y) && (mouseState.Y < position.Y + position.Height))
			//{
			//	spriteBatch.Draw(otherImage, position, Color.White);
			//}
			//else
			//{
			//	spriteBatch.Draw(image, position, Color.White);
			//}

			spriteBatch.Draw(image, position, Color.White);
		}
	}
}
