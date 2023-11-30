//
// Created by Red on 2/12/2023.
//
#include "DayThree.hpp"
#include <iostream>
using namespace std;
int main() {
    string introPath = R"(D:\AdventOfCode\AOC2022\Day3\Inputs\)";
    string actualPath = R"(D:\AdventOfCode\AOC2022\Day3\Inputs\)";
    cout << AdventOfCode::DayThree::Intro(introPath) << endl;
    cout << AdventOfCode::DayThree::PartOne(actualPath) << endl;
    cout << AdventOfCode::DayThree::PartTwo(actualPath) << endl;
}