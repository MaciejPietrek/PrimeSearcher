// ASMDLL.cpp : Definiuje eksportowane funkcje dla aplikacji DLL.
//

#include "stdafx.h"  
#include "ASMDLL.h"  

extern "C" int function1();

namespace ASM
{
	int Functions::Start(int LowerBound, int UpperBound)
	{
		return function1();
	}
}
