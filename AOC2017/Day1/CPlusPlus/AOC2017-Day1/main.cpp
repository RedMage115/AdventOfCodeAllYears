#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int Intro() {
    auto file = ifstream (R"(D:\AdventOfCode\AOC2017\Day1\Inputs\intro.txt)");
    int sum = 0;
    string line;
    while (getline(file, line)){
        string loop = line + line;
        for (int i = 0; i < line.length(); ++i) {
            if (loop[i] == loop[i+1]){
                sum += (loop[i] - '0');
            }
        }
    }
    return sum;
}

int PartOne() {
    auto file = ifstream (R"(D:\AdventOfCode\AOC2017\Day1\Inputs\actual.txt)");
    int sum = 0;
    string line;
    while (getline(file, line)){
        string loop = line + line;
        for (int i = 0; i < line.length(); ++i) {
            if (loop[i] == loop[i+1]){
                sum += (loop[i] - '0');
            }
        }
    }
    return sum;
}

int PartTwo() {
    auto file = ifstream (R"(D:\AdventOfCode\AOC2017\Day1\Inputs\actual.txt)");
    int sum = 0;
    string line;
    while (getline(file, line)){
        string loop = line + line;
        int half = line.length() / 2;
        for (int i = 0; i < line.length(); ++i) {
            if (loop[i] == loop[i+half]){
                sum += (loop[i] - '0');
            }
        }
    }
    return sum;
}


int main() {
    std::cout << "Intro: " << Intro() << std::endl;
    std::cout << "Part One: " << PartOne() << std::endl;
    std::cout << "Part Two: " << PartTwo() << std::endl;
    return 0;
}
