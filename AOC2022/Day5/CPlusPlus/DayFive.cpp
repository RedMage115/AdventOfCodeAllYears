//
// Created by Red on 31/10/2023.
//

#include "DayFive.hpp"
#include <iostream>
#include <fstream>
#include <utility>
#include <vector>
#include <string>
#include <map>
#include <algorithm>
using namespace std;


namespace AdventOfCode {
    string DayFive::Intro(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day5_Intro.txt)");
        myFileStream.open(finalPath);
        string line;

        map<int, CrateStack> AllStacks;

        AllStacks.insert({1, CrateStack(1)});
        AllStacks.insert({2, CrateStack(2)});
        AllStacks.insert({3, CrateStack(3)});

        //cout << AllStacks[1].toString() << endl;

        AllStacks[1].Crates.emplace_back(Crate("Z"));
        AllStacks[1].Crates.emplace_back(Crate("N"));

        AllStacks[2].Crates.emplace_back(Crate("M"));
        AllStacks[2].Crates.emplace_back(Crate("C"));
        AllStacks[2].Crates.emplace_back(Crate("D"));

        AllStacks[3].Crates.emplace_back(Crate("P"));
        /*for (auto stk:AllStacks) {
            cout << stk.second.toString() << endl;
        }*/
        while (getline(myFileStream, line)){
            //cout << line << endl;
            auto cmd = ParseCommand(line);
            //cout << "Moving: " << cmd.Qty << " crate(s) from " << cmd.FromId << " to " << cmd.ToId << endl;
            MoveCrate(AllStacks[cmd.FromId], AllStacks[cmd.ToId], cmd.Qty);
        }
        string result;
        for (auto stk:AllStacks) {
            //cout << stk.second.toString() << endl;
            result.append(stk.second.Crates.back().Id);
        }


        return result;
    }

    string DayFive::PartOne(const string &path) {
        ifstream myInitStream;
        string initPath = path + (R"(\Day5_Init.txt)");
        myInitStream.open(initPath);
        string initLine;

        map<int, CrateStack> AllStacks;

        AllStacks.insert({1, CrateStack(1)});
        AllStacks.insert({2, CrateStack(2)});
        AllStacks.insert({3, CrateStack(3)});
        AllStacks.insert({4, CrateStack(4)});
        AllStacks.insert({5, CrateStack(5)});
        AllStacks.insert({6, CrateStack(6)});
        AllStacks.insert({7, CrateStack(7)});
        AllStacks.insert({8, CrateStack(8)});
        AllStacks.insert({9, CrateStack(9)});

        while (getline(myInitStream, initLine)){
            int id = stoi(initLine.substr(0,1));
            string contents = initLine.substr(1);
            for (int i = 0; i < contents.length(); ++i) {
                AllStacks[id].Crates.emplace_back(Crate(contents.substr(i, 1)));
            }
        }


        for (auto stk:AllStacks) {
            //cout << stk.second.toString() << endl;
        }

        ifstream myFileStream;
        string finalPath = path + (R"(\Day5_Actual.txt)");
        myFileStream.open(finalPath);
        string line;
        int lineCount = 0;
        while (getline(myFileStream, line)){
            lineCount++;
            //cout << "Line " << lineCount << " Start" << endl;
            auto cmd = ParseCommand(line);
            //cout << "Moving: " << cmd.Qty << " crate(s) from " << cmd.FromId << " to " << cmd.ToId << endl;
            MoveCrate(AllStacks[cmd.FromId], AllStacks[cmd.ToId], cmd.Qty);
            //cout << "Line " << lineCount << " Done" << endl;
            for (auto stk:AllStacks) {
                //cout << stk.second.toString() << endl;
            }
        }
        string result;
        for (auto stk:AllStacks) {
            //cout << stk.second.toString() << endl;
            result.append(stk.second.Crates.back().Id);
        }


        return result;
    }

    string DayFive::IntroTwo(const string &path) {
        ifstream myInitStream;
        string initPath = path + (R"(\Day5_IntroInit.txt)");
        myInitStream.open(initPath);
        string initLine;

        map<int, CrateStack> AllStacks;

        AllStacks.insert({1, CrateStack(1)});
        AllStacks.insert({2, CrateStack(2)});
        AllStacks.insert({3, CrateStack(3)});
        //AllStacks.insert({4, CrateStack(4)});
        //AllStacks.insert({5, CrateStack(5)});
        //AllStacks.insert({6, CrateStack(6)});
        //AllStacks.insert({7, CrateStack(7)});
        //AllStacks.insert({8, CrateStack(8)});
        //AllStacks.insert({9, CrateStack(9)});

        while (getline(myInitStream, initLine)){
            int id = stoi(initLine.substr(0,1));
            string contents = initLine.substr(1);
            for (int i = 0; i < contents.length(); ++i) {
                AllStacks[id].Crates.emplace_back(Crate(contents.substr(i, 1)));
            }
        }


        for (auto stk:AllStacks) {
            //cout << stk.second.toString() << endl;
        }

        ifstream myFileStream;
        string finalPath = path + (R"(\Day5_Intro.txt)");
        myFileStream.open(finalPath);
        string line;
        int lineCount = 0;
        while (getline(myFileStream, line)){
            lineCount++;
            //cout << "Line " << lineCount << " Start" << endl;
            auto cmd = ParseCommand(line);
            //cout << "Moving: " << cmd.Qty << " crate(s) from " << cmd.FromId << " to " << cmd.ToId << endl;
            MoveCrateMulti(AllStacks[cmd.FromId], AllStacks[cmd.ToId], cmd.Qty);
            //cout << "Line " << lineCount << " Done" << endl;
            for (auto stk:AllStacks) {
               // cout << stk.second.toString() << endl;
            }
        }
        string result;
        for (auto stk:AllStacks) {
            //cout << stk.second.toString() << endl;
            result.append(stk.second.Crates.back().Id);
        }


        return result;
    }

    string DayFive::PartTwo(const string &path) {
        ifstream myInitStream;
        string initPath = path + (R"(\Day5_Init.txt)");
        myInitStream.open(initPath);
        string initLine;

        map<int, CrateStack> AllStacks;

        AllStacks.insert({1, CrateStack(1)});
        AllStacks.insert({2, CrateStack(2)});
        AllStacks.insert({3, CrateStack(3)});
        AllStacks.insert({4, CrateStack(4)});
        AllStacks.insert({5, CrateStack(5)});
        AllStacks.insert({6, CrateStack(6)});
        AllStacks.insert({7, CrateStack(7)});
        AllStacks.insert({8, CrateStack(8)});
        AllStacks.insert({9, CrateStack(9)});

        while (getline(myInitStream, initLine)){
            int id = stoi(initLine.substr(0,1));
            string contents = initLine.substr(1);
            for (int i = 0; i < contents.length(); ++i) {
                AllStacks[id].Crates.emplace_back(Crate(contents.substr(i, 1)));
            }
        }


        /*for (auto stk:AllStacks) {
            cout << stk.second.toString() << endl;
        }*/

        ifstream myFileStream;
        string finalPath = path + (R"(\Day5_Actual.txt)");
        myFileStream.open(finalPath);
        string line;
        int lineCount = 0;
        while (getline(myFileStream, line)){
            lineCount++;
            //cout << "Line " << lineCount << " Start" << endl;
            auto cmd = ParseCommand(line);
           // cout << "Moving: " << cmd.Qty << " crate(s) from " << cmd.FromId << " to " << cmd.ToId << endl;
            MoveCrateMulti(AllStacks[cmd.FromId], AllStacks[cmd.ToId], cmd.Qty);
            //cout << "Line " << lineCount << " Done" << endl;
            for (auto stk:AllStacks) {
                //cout << stk.second.toString() << endl;
            }
        }
        string result;
        for (auto stk:AllStacks) {
            //cout << stk.second.toString() << endl;
            result.append(stk.second.Crates.back().Id);
        }


        return result;
    }

    void DayFive::MoveCrate(DayFive::CrateStack &sendStack, DayFive::CrateStack &recStack, int qty) {
        for (int i = 0; i < qty; ++i) {
            Crate topCrate = sendStack.Crates.back();
            recStack.Crates.emplace_back(topCrate);
            sendStack.Crates.pop_back();
        }
    }

    DayFive::CrateMoveCommand DayFive::ParseCommand(const string& line) {
        int qtyStart;
        int qtyEnd;
        for (int i = 0; i < line.length(); ++i) {
            if (line[i] == 'e'){
                qtyStart = i + 1;
            }
            if (line[i] == 'f'){
                qtyEnd = i - 1;
                i = 0;
                break;
            }
        }

        //cout << "Qty: " << line.substr(qtyStart, qtyEnd - qtyStart) << endl;
        //cout << "To: " << line.substr(line.length() - 1) << endl;
        //cout << "From: " << line.substr(qtyEnd + 4, 1) << endl;

        int qty = stoi(line.substr(qtyStart,qtyEnd - qtyStart));
        int to = stoi(line.substr(line.length() - 1));
        int from = stoi(line.substr(qtyEnd + 5, 2));
        //cout << "Qty: " << qty << endl;
        //cout << "To: " << to << endl;
        //cout << "From: " << from << endl;
        return {from, to, qty};
    }

    void DayFive::MoveCrateMulti(DayFive::CrateStack &sendStack, DayFive::CrateStack &recStack, int qty) {
        vector<Crate> moveStack;
        for (int i = 0; i < qty; ++i) {
            moveStack.emplace_back(sendStack.Crates.back());
            sendStack.Crates.pop_back();
        }
        reverse(moveStack.begin(), moveStack.end());
        for (const Crate& c:moveStack) {
            recStack.Crates.emplace_back(c);
        }
    }

    string DayFive::CrateStack::toString() {
        string result;
        string idStr = "Stack " + to_string(StackId) + " - ";
        result.append(idStr);
        for (const Crate& c:Crates) {
            result.append("[");
            result.append(c.Id);
            result.append("]");
        }
        return result;
    }
} // AdventOfCode