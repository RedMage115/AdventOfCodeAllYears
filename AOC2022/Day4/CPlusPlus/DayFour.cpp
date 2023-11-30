//
// Created by stewart on 31/10/2023.
//

#include "DayFour.hpp"
#include <fstream>
#include <iostream>
#include <vector>
using namespace std;


namespace AdventOfCode {
    int DayFour::Intro(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day4_Intro.txt)");
        myFileStream.open(finalPath);
        int finalSum = 0;
        string line;
        while (getline(myFileStream, line)){
            int middle = 0;
            for (char c:line) {
                if (c == ','){
                    break;
                }
                middle++;
            }
            string firstHalf = line.substr(0, middle);
            int firstMiddle = GetRangeMiddle(firstHalf);
            string firstHalfStart = firstHalf.substr(0,firstMiddle);
            string firstHalfEnd = firstHalf.substr(firstMiddle + 1);


            string secondHalf = line.substr(middle +1);
            int secondMiddle = GetRangeMiddle(secondHalf);
            string secondHalfStart = secondHalf.substr(0,secondMiddle);
            string secondHalfEnd = secondHalf.substr(secondMiddle + 1);

            //cout << firstHalfStart << "-" << firstHalfEnd << endl;
            //cout << secondHalfStart << "-" << secondHalfEnd << endl;


            AssignmentRange firstRange(stoi(firstHalfStart), stoi(firstHalfEnd));
            AssignmentRange secondRange(stoi(secondHalfStart), stoi(secondHalfEnd));
            if (IsContained(firstRange, secondRange)){
                finalSum++;
            }
            middle = 0;
        }
        return finalSum;
    }

    int DayFour::PartOne(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day4_Actual.txt)");
        myFileStream.open(finalPath);
        int finalSum = 0;
        string line;
        while (getline(myFileStream, line)){
            int middle = 0;
            for (char c:line) {
                if (c == ','){
                    break;
                }
                middle++;
            }
            string firstHalf = line.substr(0, middle);
            int firstMiddle = GetRangeMiddle(firstHalf);
            string firstHalfStart = firstHalf.substr(0,firstMiddle);
            string firstHalfEnd = firstHalf.substr(firstMiddle + 1);


            string secondHalf = line.substr(middle +1);
            int secondMiddle = GetRangeMiddle(secondHalf);
            string secondHalfStart = secondHalf.substr(0,secondMiddle);
            string secondHalfEnd = secondHalf.substr(secondMiddle + 1);

            //cout << firstHalfStart << "-" << firstHalfEnd << endl;
            //cout << secondHalfStart << "-" << secondHalfEnd << endl;


            AssignmentRange firstRange(stoi(firstHalfStart), stoi(firstHalfEnd));
            AssignmentRange secondRange(stoi(secondHalfStart), stoi(secondHalfEnd));
            if (IsContained(firstRange, secondRange)){
                finalSum++;
            }
            middle = 0;
        }
        return finalSum;
    }

    int DayFour::IntroTwo(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day4_Intro.txt)");
        myFileStream.open(finalPath);
        int finalSum = 0;
        string line;
        while (getline(myFileStream, line)){
            int middle = 0;
            for (char c:line) {
                if (c == ','){
                    break;
                }
                middle++;
            }
            string firstHalf = line.substr(0, middle);
            int firstMiddle = GetRangeMiddle(firstHalf);
            string firstHalfStart = firstHalf.substr(0,firstMiddle);
            string firstHalfEnd = firstHalf.substr(firstMiddle + 1);


            string secondHalf = line.substr(middle +1);
            int secondMiddle = GetRangeMiddle(secondHalf);
            string secondHalfStart = secondHalf.substr(0,secondMiddle);
            string secondHalfEnd = secondHalf.substr(secondMiddle + 1);

            //cout << firstHalfStart << "-" << firstHalfEnd << endl;
            //cout << secondHalfStart << "-" << secondHalfEnd << endl;


            AssignmentRange firstRange(stoi(firstHalfStart), stoi(firstHalfEnd));
            AssignmentRange secondRange(stoi(secondHalfStart), stoi(secondHalfEnd));
            if (AnyOverlap(firstRange, secondRange)){
                finalSum++;
            }
            middle = 0;
        }
        return finalSum;
    }


    int DayFour::PartTwo(const string &path) {
        ifstream myFileStream;
        string finalPath = path + (R"(\Day4_Actual.txt)");
        myFileStream.open(finalPath);
        int finalSum = 0;
        string line;
        while (getline(myFileStream, line)){
            int middle = 0;
            for (char c:line) {
                if (c == ','){
                    break;
                }
                middle++;
            }
            string firstHalf = line.substr(0, middle);
            int firstMiddle = GetRangeMiddle(firstHalf);
            string firstHalfStart = firstHalf.substr(0,firstMiddle);
            string firstHalfEnd = firstHalf.substr(firstMiddle + 1);


            string secondHalf = line.substr(middle +1);
            int secondMiddle = GetRangeMiddle(secondHalf);
            string secondHalfStart = secondHalf.substr(0,secondMiddle);
            string secondHalfEnd = secondHalf.substr(secondMiddle + 1);

            //cout << firstHalfStart << "-" << firstHalfEnd << endl;
            //cout << secondHalfStart << "-" << secondHalfEnd << endl;


            AssignmentRange firstRange(stoi(firstHalfStart), stoi(firstHalfEnd));
            AssignmentRange secondRange(stoi(secondHalfStart), stoi(secondHalfEnd));
            if (AnyOverlap(firstRange, secondRange)){
                finalSum++;
            }
            middle = 0;
        }
        return finalSum;
    }

    bool DayFour::IsContained(DayFour::AssignmentRange& range1, DayFour::AssignmentRange& range2) {
        //cout << "Range 1: " << range1.start << " - " << range1.end << endl;
        //cout << "Range 2: " << range2.start << " - " << range2.end << endl;
        if (range1.start <= range2.start){
            if (range1.end >= range2.end){
                return true;
            }
        }
        if (range2.start <= range1.start){
            if (range2.end >= range1.end){
                return true;
            }
        }
        return false;
    }

    int DayFour::GetRangeMiddle(string &range) {
        int mid = 0;
        for (int i = 0; i < range.length(); ++i) {
            if (range[i] == '-'){
                mid = i;
                break;
            }
        }
        return mid;
    }

    bool DayFour::AnyOverlap(DayFour::AssignmentRange &range1, DayFour::AssignmentRange &range2) {
        //cout << "Range 1: " << range1.start << " - " << range1.end << endl;
        //cout << "Range 2: " << range2.start << " - " << range2.end << endl;
        for (int i = range1.start; i <= range1.end; ++i) {
            if (i == range2.start || i == range2.end) {
                //cout << "Overlap on: " << i << endl;
                return true;
            }
        }
        for (int i = range2.start; i <= range2.end; ++i) {
            if (i == range1.start || i == range1.end) {
                //cout << "Overlap on: " << i << endl;
                return true;
            }
        }
        //cout << "No Overlap" << endl;
        return false;
    }

    DayFour::AssignmentRange::AssignmentRange(int _start, int _end) {
        start = _start;
        end = _end;
    }

} // AdventOfCode