/**
Code is copyrighted by William Lee Jarboe/Hartmann.
3/21/2020
All rights reserved
h
**/
#include <string>
#include <fstream>
#include <iostream>
#include <vector>
#include <iomanip>
#include <sstream>
using namespace std;
void main()
{
	string filename;
	ifstream infile;
	cout << "ComwpODG's Succ Detector v0.07b\n";
	try {
		infile.open("combat.log");
		string line;
		while (!infile.eof())
		{
			getline(infile, line);
			if (line.find("AURA_SHIP_ATTRACTION") != -1 && line.find("Create") != -1 && line.find("DodgeDrive") == -1)
			{
				//line operations
				string player = "";
				string time = "";
				string succ = "";
				player = line.substr(line.length() - 16, 16);
				time = line.substr(0, 12);
				player = player.substr(player.find("'", 0));
				succ = line.substr(0, line.find("'", 36));
				succ = succ.substr(36);
				if (player.find("NPC") == -1 && player != "'")
				{
					cout << "@" << time << " - " << setw(20) << player << " succed using " << succ << "\n";
				}
			}
		}
	}
	catch (exception e)
	{
		cout << "Run the program adjacent to the combat log you want to read.";
	}
	system("pause");
}