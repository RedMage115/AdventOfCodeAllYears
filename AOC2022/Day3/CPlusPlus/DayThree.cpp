//
// Created by stewart on 31/10/2023.
//
#include <fstream>
#include <iostream>
#include <vector>
#include "DayThree.hpp"

int AdventOfCode::DayThree::Intro(const string &path) {
    ifstream fileStream;
    string finalPath = path + (R"(\Day3_Intro.txt)");
    fileStream.open(finalPath);

    string line;
    int totalSum;

    vector<char> chars ={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

    while (getline(fileStream, line)){
        char matchingChar;
        int mid = line.length() / 2;
        string firstHalf = line.substr(0,mid);
        string secondHalf = line.substr(mid,line.length());

        for (char c : firstHalf) {
            for (char s : secondHalf) {
                if (c == s){
                    matchingChar = c;
                }
            }
        }
        //cout << matchingChar << endl;
        for (int i =0; i < chars.size(); ++i) {
            if (matchingChar == chars[i]){
                //cout << "Value Is:" << i << endl;
                i++;
                totalSum += i;
                i=0;
                break;
            }
        }
    }
    return totalSum;
}

int AdventOfCode::DayThree::PartOne(const string &path) {
    ifstream fileStream;
    string finalPath = path + (R"(\Day3_Actual.txt)");
    fileStream.open(finalPath);

    string line;
    int totalSum;

    vector<char> chars ={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

    while (getline(fileStream, line)){
        char matchingChar;
        int mid = line.length() / 2;
        string firstHalf = line.substr(0,mid);
        string secondHalf = line.substr(mid,line.length());

        for (char c : firstHalf) {
            for (char s : secondHalf) {
                if (c == s){
                    matchingChar = c;
                }
            }
        }
        //cout << matchingChar << endl;
        for (int i =0; i < chars.size(); ++i) {
            if (matchingChar == chars[i]){
                //cout << "Value Is:" << i << endl;
                i++;
                totalSum += i;
                i=0;
                break;
            }
        }
    }
    return totalSum;
}

int AdventOfCode::DayThree::PartTwo(const string &path) {
    ifstream fileStream;
    string finalPath = path + (R"(\Day3_Actual.txt)");
    fileStream.open(finalPath);

    string line;
    int totalSum;

    vector<char> chars ={'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

    int groupCounter;
    vector<string> group;
    vector<char> groupBadges;

    while (getline(fileStream, line)){
        group.push_back(line);
        groupCounter++;
        if (groupCounter == 3) {
            groupBadges.push_back(FindCommonLetter(group));
            groupCounter = 0;
            group.clear();
        }
    }

    for (char badge:groupBadges) {
        for (int i = 0; i < chars.size(); ++i) {
            if (badge == chars[i]){
                i++;
                totalSum += i;
                i=0;
                break;
            }
        }
    }

    return totalSum;
}


char AdventOfCode::DayThree::FindCommonLetter(vector<string> group) {
    string person1 = group[0];
    string person2 = group[1];
    string person3 = group[2];

    for (char a:person1) {
        for (char b:person2) {
            for (char c:person3) {
                if (a == b && b == c){
                    return a;
                }
            }
        }
    }
}