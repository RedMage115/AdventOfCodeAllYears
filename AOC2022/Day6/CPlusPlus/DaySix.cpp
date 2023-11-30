//
// Created by Red on 1/11/2023.
//

#include "DaySix.hpp"
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
using namespace std;

namespace AdventOfCode {
    int DaySix::Intro(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day6_Intro.txt)");
        myFileStream.open(finalPath);
        string line;
        int result;
        while (getline(myFileStream, line)){
            for (int i = 3; i < line.length(); ++i) {
                char first = line[i-3];
                char second = line[i-2];
                char third = line[i-1];
                char fourth = line[i];

                //cout << first << second << third << fourth << endl;

                if (first == second) continue;
                if (first == third) continue;
                if (first == fourth) continue;

                if (second == first) continue;
                if (second == third) continue;
                if (second == fourth) continue;

                if (third == second) continue;
                if (third == first) continue;
                if (third == fourth) continue;

                if (fourth == second) continue;
                if (fourth == third) continue;
                if (fourth == first) continue;

                result = i+1;
                break;
            }
        }

        return result;
    }

    int DaySix::PartOne(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day6_Actual.txt)");
        myFileStream.open(finalPath);
        string line;
        int result;
        while (getline(myFileStream, line)){
            for (int i = 3; i < line.length(); ++i) {
                char first = line[i-3];
                char second = line[i-2];
                char third = line[i-1];
                char fourth = line[i];

                //cout << first << second << third << fourth << endl;

                if (first == second) continue;
                if (first == third) continue;
                if (first == fourth) continue;

                if (second == first) continue;
                if (second == third) continue;
                if (second == fourth) continue;

                if (third == second) continue;
                if (third == first) continue;
                if (third == fourth) continue;

                if (fourth == second) continue;
                if (fourth == third) continue;
                if (fourth == first) continue;

                result = i+1;
                break;
            }
        }

        return result;
    }

    int DaySix::IntroTwo(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day6_Intro.txt)");
        myFileStream.open(finalPath);
        string line;
        int result;
        while (getline(myFileStream, line)){
            for (int i = 14; i < line.length(); ++i) {
                string messageBuffer;
                messageBuffer.append(line.substr(i-14,1));
                int count = 13;
                //cout << messageBuffer << endl;
                while (messageBuffer.find(line.substr(i-count,1)) == string::npos && count > 0){
                    messageBuffer.append(line.substr(i-count,1));
                    //cout << messageBuffer << endl;
                    count--;
                }
                if(count != 0){
                    count = 13;
                    continue;
                }

                //cout << messageBuffer << endl;

                result = i;
                break;
            }
        }

        return result;
    }

    int DaySix::PartTwo(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day6_Actual.txt)");
        myFileStream.open(finalPath);
        string line;
        int result;
        while (getline(myFileStream, line)){
            for (int i = 14; i < line.length(); ++i) {
                string messageBuffer;
                messageBuffer.append(line.substr(i-14,1));
                int count = 13;
                //cout << messageBuffer << endl;
                while (messageBuffer.find(line.substr(i-count,1)) == string::npos && count > 0){
                    messageBuffer.append(line.substr(i-count,1));
                    //cout << messageBuffer << endl;
                    count--;
                }
                if(count != 0){
                    count = 13;
                    continue;
                }

                //cout << messageBuffer << endl;

                result = i;
                break;
            }
        }

        return result;
    }
} // AdventOfCode