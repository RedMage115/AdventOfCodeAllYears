//
// Created by Red on 30/10/2023.
//

#ifndef ADVENTOFCODE_DAYTWO_HPP
#define ADVENTOFCODE_DAYTWO_HPP
#include <string>
using namespace std;


namespace AdventOfCode {

    class DayTwo {
    public:
        static int Intro(string const& path);
        static int PartOne(string const& path);
        static int IntroTwo(string const& path);
        static int PartTwo(string const& path);
        enum Moves {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        };
        enum Outcomes {
            Win = 6,
            Draw = 3,
            Loss = 0
        };
    };

}
#endif //ADVENTOFCODE_DAYTWO_HPP
