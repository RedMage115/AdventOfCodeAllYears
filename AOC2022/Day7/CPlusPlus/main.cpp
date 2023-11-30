//
// Created by Red on 2/12/2023.
//
#include "DaySeven.hpp"
#include <iostream>
using namespace std;
int main() {
    string introPath = R"(D:\AdventOfCode\AOC2022\Day7\Inputs\)";
    string actualPath = R"(D:\AdventOfCode\AOC2022\Day7\Inputs\)";
    cout << AdventOfCode::DaySeven::Intro(introPath) << endl;
    cout << AdventOfCode::DaySeven::PartOne(actualPath) << endl;
    cout << AdventOfCode::DaySeven::PartTwo(actualPath) << endl;
}