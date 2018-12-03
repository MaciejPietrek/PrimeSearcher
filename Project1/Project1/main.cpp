#include <iostream>

using namespace std;

extern "C" int function();

int main()
{
	if (function())
	{
		cout << "true";
	}
	else
	{
		cout << "false";
	}


	return 0;
}