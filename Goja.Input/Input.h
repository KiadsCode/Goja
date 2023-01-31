#include <Windows.h>
#include "VECTOR2F.h"

using namespace GojaCPP;

namespace Goja
{
	public enum class Keys : unsigned int
	{
		A = (unsigned int)'A',
		C = (unsigned int)'C',
		D = (unsigned int)'D',
		E = (unsigned int)'E',
		F = (unsigned int)'F',
		G = (unsigned int)'G',
		H = (unsigned int)'H',
		I = (unsigned int)'I',
		J = (unsigned int)'J',
		L = (unsigned int)'L',
		M = (unsigned int)'M',
		N = (unsigned int)'N',
		O = (unsigned int)'O',
		P = (unsigned int)'P',
		Q = (unsigned int)'Q',
		R = (unsigned int)'R',
		S = (unsigned int)'S',
		T = (unsigned int)'T',
		U = (unsigned int)'U',
		V = (unsigned int)'V',
		W = (unsigned int)'W',
		X = (unsigned int)'X',
		Y = (unsigned int)'Y',
		Z = (unsigned int)'Z',
		Plus = (unsigned int)'+',
		Minus = (unsigned int)'-',
		Space = (unsigned int)VK_SPACE,
		One = (unsigned int)'1',
		Two = (unsigned int)'2',
		Three = (unsigned int)'3',
		Four = (unsigned int)'4',
		Five = (unsigned int)'5',
		Six = (unsigned int)'6',
		Seven = (unsigned int)'7',
		Eigth = (unsigned int)'8',
		Nine = (unsigned int)'9',
		Zero = (unsigned int)'0',
		None = (unsigned int)'-',
		Escape = (unsigned int)VK_ESCAPE,
		Cancel = (unsigned int)VK_CANCEL,
		Enter = (unsigned int)VK_RETURN,
		Shift = (unsigned int)VK_SHIFT,
		Control = (unsigned int)VK_CONTROL,
		CapsLock = (unsigned int)VK_CAPITAL,
		Pause = (unsigned int)VK_PAUSE,
		Alt = (unsigned int)VK_MENU,
		End = (unsigned int)VK_END,
		Insert = (unsigned int)VK_INSERT,
		Delete = (unsigned int)VK_DELETE,
		Down = (unsigned int)VK_DOWN,
		Left = (unsigned int)VK_LEFT,
		Right = (unsigned int)VK_RIGHT,
		Up = (unsigned int)VK_UP,
		LMB = (unsigned int)VK_LBUTTON,
		RMB = (unsigned int)VK_RBUTTON,
		MMB = (unsigned int)VK_MBUTTON,
		Button1X = (unsigned int)VK_XBUTTON1,
		Button2X = (unsigned int)VK_XBUTTON2
	};
	public ref class Input
	{
public:
		static VECTOR2F^ GetGlobalMousePosition();
		static bool IsKeyDown(Keys key);
		static bool IsKeyUp(Keys key);
	};
}