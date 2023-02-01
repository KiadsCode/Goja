#pragma once
#include "Keys.h"

namespace Goja
{
	namespace Input
	{
		public ref class KeyboardState
		{
		public:
			KeyboardState();
			bool IsKeyDown(Keys key);
			bool IsKeyUp(Keys key);
		private:
			bool A;
			bool B;
			bool C;
			bool D;
			bool E;
			bool F;
			bool G;
			bool H;
			bool I;
			bool J;
			bool K;
			bool L;
			bool M;
			bool N;
			bool O;
			bool P;
			bool Q;
			bool R;
			bool S;
			bool T;
			bool U;
			bool V;
			bool W;
			bool Plus;
			bool Minus;
			bool Space;
			bool X;
			bool Y;
			bool Z;
			bool One;
			bool Two;
			bool Three;
			bool Four;
			bool Five;
			bool Six;
			bool Seven;
			bool Eight;
			bool Nine;
			bool Zero;
			bool Escape;
			bool Cancel;
			bool Enter;
			bool Shift;
			bool Control;
			bool CapsLock;
			bool Pause;
			bool Alt;
			bool End;
			bool Insert;
			bool Delete;
			bool Down;
			bool Left;
			bool Right;
			bool Up;
		};
	}
}