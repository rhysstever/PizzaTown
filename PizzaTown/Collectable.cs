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
	class Collectable
	{
		// Fields

		private Texture2D texture;
		private Rectangle position;
		private bool isActive;

		// Properties
		public Texture2D Texture { get { return texture; } }
		public Rectangle Position { get { return position; } }
		public bool IsActive
		{
			get { return isActive; }
			set { isActive = value; }
		}

		// Constructor

		public Collectable(Texture2D texture, Rectangle rect)
		{
			this.texture = texture;
			position = rect;
			isActive = true;
		}

		// Methods

		public void Draw(SpriteBatch sb)
		{
			sb.Draw(texture, position, Color.White);
		}
	}
}
