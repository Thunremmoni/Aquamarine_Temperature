#include<bits/stdc++.h>
#include<Windows.h>

constexpr auto VERSION = " 1.0.0 Beta ";

#define EXITPROG exit(0);
#define CLS system("cls");
#define SLEEP(x) Sleep(x);

int main()
{
	//Program Begin
	std::cout << "Loading AIR version" << VERSION << "..." << std::endl;
	FILE *data_f, *nowEdit_f, *outPut_f, *clsInfo_f = fopen("data\errorList.ops","r");
	if (clsInfo_f == nullptr)puts("ops error : Failed to open FILE cls");
	else {

	}
	SLEEP(300); 
	puts("Finished");
	CLS

	//OPT
	while (true)
	{
		std::string doOption_s;
		std::cin >> doOption_s;
		if (doOption_s == "help") {
			puts("Project AIR --Usage\n");
			puts("Options");
			printf("\thelp\tView Command list\n\n");
			printf("\timport\tInject file\n\n");
			printf("\tClone\tSave Result\n\n");
		}
		else if (doOption_s == "clear")CLS;
	}

	EXITPROG
}