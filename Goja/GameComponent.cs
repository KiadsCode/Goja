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
    }
}