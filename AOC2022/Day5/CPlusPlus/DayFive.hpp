//
// Created by Red on 31/10/2023.
//

#ifndef ADVENTOFCODE_DAYFIVE_HPP
#define ADVENTOFCODE_DAYFIVE_HPP
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

namespace AdventOfCode {

    class DayFive {
    public:
        struct Crate {
            string Id;
        };

        struct CrateStack {
            string toString();
            int StackId;
            vector<Crate> Crates;
        };

        struct CrateMoveCommand {
            int FromId;
            int ToId;
            int Qty;
        };

        static string Intro(string const& path);
        static string PartOne(string const& path);
        static string IntroTwo(string const& path);
        static string PartTwo(string const& path);
    private:
        static void MoveCrate(CrateStack& sendStack, CrateStack& recStack, int qty);
        static void MoveCrateMulti(CrateStack& sendStack, CrateStack& recStack, int qty);
        static CrateMoveCommand ParseCommand(const string& line);
    };

} // AdventOfCode

#endif //ADVENTOFCODE_DAYFIVE_HPP
