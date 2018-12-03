#pragma once  

#ifdef ASM_EXPORTS  
#define ASM_API __declspec(dllexport)   
#else  
#define ASM_API __declspec(dllimport)   
#endif  

namespace ASM
{
	// This class is exported from the ASM.dll  
	class Functions
	{
	public:
		static ASM_API int Start(int LowerBound, int UpperBound);
	};
}
