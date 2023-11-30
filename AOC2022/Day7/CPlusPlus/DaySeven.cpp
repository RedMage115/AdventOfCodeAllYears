//
// Created by Red on 2/11/2023.
//

#include "DaySeven.hpp"
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

namespace AdventOfCode {
    int DaySeven::Intro(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(Day7_Intro.txt)");
        myFileStream.open(finalPath);
        string line;
        int result;
        vector<DirDirectory> allDirs;
        DirDirectory& currentDir = allDirs.front();
        DirCommand currentCmd;
        while (getline(myFileStream, line)){
            if (line[0] == '$'){
                currentCmd = ParseCommand(line);
                string name = line.substr(4);
                if (currentCmd == cd){
                    bool found;
                    for (const DirDirectory& dir:allDirs) {
                        if (dir.Name == name){
                            found = true;
                            currentDir = dir;
                        }
                    }
                    if (!found){
                        allDirs.push_back(DirDirectory(name));
                        currentDir = allDirs.back();
                    }
                } else{

                }
            } else {

            }
        }
        return 0;
    }

    int DaySeven::PartOne(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(Day7_Actual.txt)");
        myFileStream.open(finalPath);
        string line;
        int result;
        while (getline(myFileStream, line)){}
        return 0;
    }

    int DaySeven::IntroTwo(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(Day7_Intro.txt)");
        myFileStream.open(finalPath);
        string line;
        int result;
        while (getline(myFileStream, line)){}
        return 0;
    }

    int DaySeven::PartTwo(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(Day7_Actual.txt)");
        myFileStream.open(finalPath);
        string line;
        int result;
        while (getline(myFileStream, line)){}
        return 0;
    }

    DaySeven::DirCommand DaySeven::ParseCommand(const string& command) {
        DirCommand result;
        for (char c:command) {
            switch (c) {
                case 'c':
                    result = DirCommand::cd;
                    break;
                case 'l':
                    result = DirCommand::ls;
                    break;
                default:
                    continue;
            }
        }
        return result;
    }


} // AdventOfCode