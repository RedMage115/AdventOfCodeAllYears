//
// Created by stewart on 31/10/2023.
//

#ifndef ADVENTOFCODE_DAYTHREE_HPP
#define ADVENTOFCODE_DAYTHREE_HPP
#include <string>
#include <vector>
using namespace std;


namespace AdventOfCode {

    class DayThree {
    public:
        static int Intro (string const& path);
        static int PartOne (string const& path);
        static int PartTwo (string const& path);
    private:
        static char FindCommonLetter(vector<string> group);
    };
};
#endif //ADVENTOFCODE_DAYTHREE_HPP
