//
// Created by Red on 2/12/2023.
//
#include "DayFour.hpp"
#include <iostream>
using namespace std;
int main() {
    string introPath = R"(D:\AdventOfCode\AOC2022\Day4\Inputs\)";
    string actualPath = R"(D:\AdventOfCode\AOC2022\Day4\Inputs\)";
    cout << AdventOfCode::DayFour::Intro(introPath) << endl;
    cout << AdventOfCode::DayFour::PartOne(actualPath) << endl;
    cout << AdventOfCode::DayFour::PartTwo(actualPath) << endl;
}