//
// Created by Red on 2/12/2023.
//
#include "DaySix.hpp"
#include <iostream>
using namespace std;
int main() {
    string introPath = R"(D:\AdventOfCode\AOC2022\Day6\Inputs\)";
    string actualPath = R"(D:\AdventOfCode\AOC2022\Day6\Inputs\)";
    cout << AdventOfCode::DaySix::Intro(introPath) << endl;
    cout << AdventOfCode::DaySix::PartOne(actualPath) << endl;
    cout << AdventOfCode::DaySix::PartTwo(actualPath) << endl;
}