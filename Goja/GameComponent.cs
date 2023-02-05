using System;

namespace Goja
{
    public class GameComponent
    {
        private Game _game;
        private bool _enabled = true;

        public bool Enabled { get { return _enabled; } set { _enabled = value; } }
        public Game Game { get { return _game; } }

        public GameComponent(Game game)
        {
            _game = game;
        }

        public virtual void Initialize()
        {
        }

        public virtual void Update(double elapsed)
        {
        }
        
		#region Equals and GetHashCode implementation
		public override bool Equals(object obj)
		{
			GameComponent other = obj as GameComponent;
				if (other == null)
					return false;
						return object.Equals(this._game, other._game) && this._enabled == other._enabled;
		}

		public override int GetHashCode()
		{
			int hashCode = 0;
			unchecked {
				if (_game != null)
					hashCode += 1000000007 * _game.GetHashCode();
				hashCode += 1000000009 * _enabled.GetHashCode();
			}
			return hashCode;
		}

		public static bool operator ==(GameComponent lhs, GameComponent rhs) {
			if (ReferenceEquals(lhs, rhs))
				return true;
			if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
				return false;
			return lhs.Equals(rhs);
		}

		public static bool operator !=(GameComponent lhs, GameComponent rhs) {
			return !(lhs == rhs);
		}

		#endregion
    }
}