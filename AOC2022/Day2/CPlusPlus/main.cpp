//
// Created by Red on 2/12/2023.
//
#include "DayTwo.hpp"
#include <iostream>
using namespace std;
int main() {
    string introPath = R"(D:\AdventOfCode\AOC2022\Day2\Inputs\)";
    string actualPath = R"(D:\AdventOfCode\AOC2022\Day2\Inputs\)";
    cout << AdventOfCode::DayTwo::Intro(introPath) << endl;
    cout << AdventOfCode::DayTwo::PartOne(actualPath) << endl;
    cout << AdventOfCode::DayTwo::PartTwo(actualPath) << endl;
}