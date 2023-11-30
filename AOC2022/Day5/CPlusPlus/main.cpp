//
// Created by Red on 2/12/2023.
//
#include "DayFive.hpp"
#include <iostream>
using namespace std;
int main() {
    string introPath = R"(D:\AdventOfCode\AOC2022\Day5\Inputs\)";
    string actualPath = R"(D:\AdventOfCode\AOC2022\Day5\Inputs\)";
    cout << AdventOfCode::DayFive::Intro(introPath) << endl;
    cout << AdventOfCode::DayFive::PartOne(actualPath) << endl;
    cout << AdventOfCode::DayFive::PartTwo(actualPath) << endl;
}