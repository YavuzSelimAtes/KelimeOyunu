#include <iostream>
#include <string>
#include <fstream>
#include <locale.h>

using namespace std;

void dosyayioku(string* kelime);

int main()
{
	setlocale(LC_ALL, "tr_TR.UTF-8");
	string kelimedizini;
	
	dosyayioku(&kelimedizini);

	for (int i = 0; i < kelimedizini.length(); i++)
	{
		if (kelimedizini[i] == ' ')
		{
			kelimedizini[i] = ',';
			kelimedizini.insert(i, "'");
			kelimedizini.insert(i+2, "'");
		}
		if (i == 0)
			kelimedizini.insert(i, "'");
	}

	kelimedizini.insert(kelimedizini.length(), "'");

	cout << kelimedizini << endl;
}

void dosyayioku(string* kelime)
{
	ifstream cinDosya("kelimeler.txt");

	if (cinDosya.is_open()) {
		string oku;

		while (getline(cinDosya, oku))
		{
			*kelime += oku;
			*kelime += " ";
		}
		cinDosya.close();
	}

}
