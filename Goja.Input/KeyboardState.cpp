#include "KeyboardState.h"

namespace Goja
{
	namespace Input
	{
		KeyboardState::KeyboardState()
		{
			A = GetAsyncKeyState((int)Keys::A);
			B = GetAsyncKeyState((int)Keys::B);
			C = GetAsyncKeyState((int)Keys::C);
			D = GetAsyncKeyState((int)Keys::D);
			E = GetAsyncKeyState((int)Keys::E);
			F = GetAsyncKeyState((int)Keys::F);
			G = GetAsyncKeyState((int)Keys::G);
			H = GetAsyncKeyState((int)Keys::H);
			I = GetAsyncKeyState((int)Keys::I);
			J = GetAsyncKeyState((int)Keys::J);
			K = GetAsyncKeyState((int)Keys::K);
			L = GetAsyncKeyState((int)Keys::L);
			M = GetAsyncKeyState((int)Keys::M);
			N = GetAsyncKeyState((int)Keys::N);
			O = GetAsyncKeyState((int)Keys::O);
			P = GetAsyncKeyState((int)Keys::P);
			Q = GetAsyncKeyState((int)Keys::Q);
			R = GetAsyncKeyState((int)Keys::R);
			S = GetAsyncKeyState((int)Keys::S);
			T = GetAsyncKeyState((int)Keys::T);
			U = GetAsyncKeyState((int)Keys::U);
			V = GetAsyncKeyState((int)Keys::V);
			W = GetAsyncKeyState((int)Keys::W);
			X = GetAsyncKeyState((int)Keys::X);
			Y = GetAsyncKeyState((int)Keys::Y);
			Z = GetAsyncKeyState((int)Keys::Z);
			Space = GetAsyncKeyState((int)Keys::Space);
			One = GetAsyncKeyState((int)Keys::One);
			Two = GetAsyncKeyState((int)Keys::Two);
			Three = GetAsyncKeyState((int)Keys::Three);
			Four = GetAsyncKeyState((int)Keys::Four);
			Five = GetAsyncKeyState((int)Keys::Five);
			Six = GetAsyncKeyState((int)Keys::Six);
			Seven = GetAsyncKeyState((int)Keys::Seven);
			Eight = GetAsyncKeyState((int)Keys::Eight);
			Nine = GetAsyncKeyState((int)Keys::Nine);
			Zero = GetAsyncKeyState((int)Keys::Zero);
			Plus = GetAsyncKeyState((int)VK_OEM_PLUS);
			Minus = GetAsyncKeyState((int)VK_OEM_MINUS);
			Escape = GetAsyncKeyState((int)VK_ESCAPE);
			Cancel = GetAsyncKeyState((int)VK_CANCEL);
			Enter = GetAsyncKeyState((int)VK_RETURN);
			Shift = GetAsyncKeyState((int)VK_SHIFT);
			Control = GetAsyncKeyState((int)VK_CONTROL);
			CapsLock = GetAsyncKeyState((int)VK_CAPITAL);
			Pause = GetAsyncKeyState((int)VK_PAUSE);
			Alt = GetAsyncKeyState((int)VK_MENU);
			End = GetAsyncKeyState((int)VK_END);
			Insert = GetAsyncKeyState((int)VK_INSERT);
			Delete = GetAsyncKeyState((int)VK_DELETE);
			Down = GetAsyncKeyState((int)VK_DOWN);
			Left = GetAsyncKeyState((int)VK_LEFT);
			Right = GetAsyncKeyState((int)VK_RIGHT);
			Up = GetAsyncKeyState((int)VK_UP);
		}
		bool KeyboardState::IsKeyDown(Keys key)
		{
			switch ((int)key)
			{
			case (int)Keys::A:
				return A;
				break;
			case (int)Keys::B:
				return B;
				break;
			case (int)Keys::C:
				return C;
				break;
			case (int)Keys::D:
				return D;
				break;
			case (int)Keys::E:
				return E;
				break;
			case (int)Keys::F:
				return F;
				break;
			case (int)Keys::G:
				return G;
				break;
			case (int)Keys::H:
				return H;
				break;
			case (int)Keys::I:
				return I;
				break;
			case (int)Keys::J:
				return J;
				break;
			case (int)Keys::K:
				return K;
				break;
			case (int)Keys::L:
				return L;
				break;
			case (int)Keys::M:
				return M;
				break;
			case (int)Keys::N:
				return N;
				break;
			case (int)Keys::O:
				return O;
				break;
			case (int)Keys::P:
				return P;
				break;
			case (int)Keys::Q:
				return Q;
				break;
			case (int)Keys::R:
				return R;
				break;
			case (int)Keys::S:
				return S;
				break;
			case (int)Keys::T:
				return T;
				break;
			case (int)Keys::U:
				return U;
				break;
			case (int)Keys::V:
				return V;
				break;
			case (int)Keys::W:
				return W;
				break;
			case (int)Keys::X:
				return X;
				break;
			case (int)Keys::Y:
				return Y;
				break;
			case (int)Keys::Z:
				return Z;
				break;
			case (int)Keys::One:
				return One;
				break;
			case (int)Keys::Two:
				return Two;
				break;
			case (int)Keys::Three:
				return Three;
				break;
			case (int)Keys::Four:
				return Four;
				break;
			case (int)Keys::Five:
				return Five;
				break;
			case (int)Keys::Six:
				return Six;
				break;
			case (int)Keys::Seven:
				return Seven;
				break;
			case (int)Keys::Eight:
				return Eight;
				break;
			case (int)Keys::Nine:
				return Nine;
				break;
			case (int)Keys::Zero:
				return Zero;
				break;
			case (int)Keys::Minus:
				return Minus;
				break;
			case (int)Keys::Plus:
				return Plus;
				break;
			case (int)Keys::Space:
				return Space;
				break;
			case (int)Keys::Escape:
				return Escape;
				break;
			case (int)Keys::Cancel:
				return Cancel;
				break;
			case (int)Keys::Enter:
				return Enter;
				break;
			case (int)Keys::Shift:
				return Shift;
				break;
			case (int)Keys::Control:
				return Control;
				break;
			case (int)Keys::Pause:
				return Pause;
				break;
			case (int)Keys::End:
				return End;
				break;
			case (int)Keys::Insert:
				return Insert;
				break;
			case (int)Keys::Delete:
				return Delete;
				break;
			case (int)Keys::Down:
				return Down;
				break;
			case (int)Keys::Left:
				return Left;
				break;
			case (int)Keys::Right:
				return Right;
				break;
			case (int)Keys::Up:
				return Up;
				break;
			default:
				return false;
				break;
			}
			return false;
		}
		bool KeyboardState::IsKeyUp(Keys key)
		{
			return !IsKeyDown(key);
		}
	}
}