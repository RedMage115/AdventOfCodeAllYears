//
// Created by Red on 2/11/2023.
//

#ifndef ADVENTOFCODE_DAYSEVEN_HPP
#define ADVENTOFCODE_DAYSEVEN_HPP
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;
namespace AdventOfCode {

    class DaySeven {
    public:
        enum DirCommand {
            cd,
            ls,
        };
        struct DirFile {
            string Directory;
            string Name;
            int Size;
        };
        struct DirDirectory {
            string Name;
            vector<DirFile> Files;
            vector<DirDirectory> SubDir;
        };



        static int Intro(const string &path);
        static int PartOne(const string &path);
        static int IntroTwo(const string &path);
        static int PartTwo(const string &path);

    private:
        static DirCommand ParseCommand(const string& command);

    };

} // AdventOfCode

#endif //ADVENTOFCODE_DAYSEVEN_HPP
