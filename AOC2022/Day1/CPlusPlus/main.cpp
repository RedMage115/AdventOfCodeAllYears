//
// Created by Red on 2/12/2023.
//
#include "DayOne.hpp"
#include <iostream>
using namespace std;
int main() {
    string introPath = R"(D:\AdventOfCode\AOC2022\Day1\Inputs\intro.txt)";
    string actualPath = R"(D:\AdventOfCode\AOC2022\Day1\Inputs\actual.txt)";
    cout << AdventOfCode::DayOne::Intro(introPath) << endl;
    cout << AdventOfCode::DayOne::PartOne(actualPath) << endl;
    cout << AdventOfCode::DayOne::PartTwo(actualPath) << endl;
}