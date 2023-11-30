//
// Created by stewart on 31/10/2023.
//

#ifndef ADVENTOFCODE_DAYFOUR_HPP
#define ADVENTOFCODE_DAYFOUR_HPP
#include <string>
#include <vector>
using namespace std;

namespace AdventOfCode {

    class DayFour {
    public:
        struct AssignmentRange {
            AssignmentRange(int start, int end);
            int start;
            int end;
        };
        static int Intro(string const& path);
        static int PartOne(string const& path);
        static int IntroTwo(string const& path);
        static int PartTwo(string const& path);

    private:
        static bool IsContained(AssignmentRange& range1, AssignmentRange& range2);
        static bool AnyOverlap(AssignmentRange& range1, AssignmentRange& range2);
        static int GetRangeMiddle(string& range);

    };

} // AdventOfCode

#endif //ADVENTOFCODE_DAYFOUR_HPP
