//
// Created by Red on 30/10/2023.
//

#include "DayOne.hpp"
#include <iostream>
#include <fstream>
#include <vector>
using namespace std;


int AdventOfCode::DayOne::Intro(string const& path) {
    ifstream myFileStream;
    string finalPath = path;
    myFileStream.open(finalPath);

    auto counts = vector<int>();
    int sum = 0;

    string line;

    while (getline(myFileStream, line)){
        //cout << "Text is:" << endl;
        //cout << line << endl;

        if (line.empty() || line == " "){
            counts.push_back(sum);
            sum = 0;
        } else{
            sum += stoi(line);
        }

        //cout << "Sum is:" << endl;
        //cout << sum << endl;
    }
    //cout << "End of file" << endl;
    //cout << endl;
    //cout << "Sums Are:" << endl;
    int highest = 0;
    for (int i : counts) {
        //cout << i << endl;
        if (i > highest){
            //cout << "Highest is now: " << i << endl;
            highest = i;
        }
    }
    return highest;
}

int AdventOfCode::DayOne::PartOne(string const& path) {
    ifstream myFileStream;
    string finalPath = path;
    myFileStream.open(finalPath);
    auto counts = vector<int>();
    int sum = 0;

    string line;

    while (getline(myFileStream, line)){
        //cout << "Text is:" << endl;
        //cout << line << endl;

        if (line.empty() || line == " "){
            counts.push_back(sum);
            sum = 0;
        } else{
            sum += stoi(line);
        }

        //cout << "Sum is:" << endl;
        //cout << sum << endl;
    }
    //cout << "End of file" << endl;
   // cout << endl;
    //cout << "Sums Are:" << endl;
    int highest = 0;
    for (int i : counts) {
        //cout << i << endl;
        if (i > highest){
            //cout << "Highest is now: " << i << endl;
            highest = i;
        }
    }
    return highest;
}

long int AdventOfCode::DayOne::PartTwo(string const& path) {
    ifstream myFileStream;
    string finalPath = path;
    myFileStream.open(finalPath);
    auto counts = vector<long int>();
    long int sum = 0;

    string line;

    while (getline(myFileStream, line)){
       // cout << "Text is:" << endl;
        //cout << line << endl;

        if (line.empty() || line == " "){
            counts.push_back(sum);
            sum = 0;
        } else{
            sum += stoi(line);
        }

        //cout << "Sum is:" << endl;
        //cout << sum << endl;
    }
    //cout << "End of file" << endl;
    //cout << endl;
    //cout << "Sums Are:" << endl;
    long int highest;
    long int  second;
    long int  third;
    for (long int i : counts) {
        //cout << i << endl;
        if (i > highest){
            //cout << "Highest is now: " << i << endl;
            third = second;
            second = highest;
            highest = i;

        }
        else if (i > second){
            //cout << "Second is now: " << i << endl;
            third = second;
            second = i;
        }
        else if (i > third){
            //cout << "Third is now: " << i << endl;
            third = i;
        }
    }
    return highest + second + third;
}
