//
// Created by Red on 30/10/2023.
//

#include "DayTwo.hpp"
#include <iostream>
#include <fstream>
#include <vector>
using namespace std;


int AdventOfCode::DayTwo::Intro(string const& path) {

    ifstream fileStream;
    string finalPath = path + (R"(\Day2_Intro.txt)");
    fileStream.open(finalPath);

    Moves oppPlay;
    Moves mePlay;
    Outcomes matchOutcome;
    int roundPoints = 0;
    int totalPoints = 0;
    string line;
    while (getline(fileStream, line)) {
        roundPoints = 0;
        char oppRaw = line[0];
        char meRaw = line[2];
        switch (oppRaw) {
            case 'A':
                oppPlay = Rock;
                break;
            case 'B':
                oppPlay = Paper;
                break;
            case 'C':
                oppPlay = Scissors;
                break;
            default:
                break;
        }

        switch (meRaw) {
            case 'X':
                mePlay = Rock;
                break;
            case 'Y':
                mePlay = Paper;
                break;
            case 'Z':
                mePlay = Scissors;
                break;
            default:
                break;
        }
        roundPoints += mePlay;

        if (oppPlay == mePlay){
            matchOutcome = Draw;
        } else if (oppPlay == Rock && mePlay == Paper){
            matchOutcome = Win;
        } else if (oppPlay == Rock && mePlay == Scissors){
            matchOutcome = Loss;
        } else if (oppPlay == Paper && mePlay == Rock){
            matchOutcome = Loss;
        } else if (oppPlay == Paper && mePlay == Scissors){
            matchOutcome = Win;
        } else if (oppPlay == Scissors && mePlay == Rock){
            matchOutcome = Win;
        } else if (oppPlay == Scissors && mePlay == Paper){
            matchOutcome = Loss;
        }
        roundPoints += matchOutcome;
        totalPoints += roundPoints;
    }

    return totalPoints;
}

int AdventOfCode::DayTwo::PartOne(string const& path) {

    ifstream fileStream;
    string finalPath = path + (R"(\Day2_Actual.txt)");
    fileStream.open(finalPath);
    Moves oppPlay;
    Moves mePlay;
    Outcomes matchOutcome;
    int roundPoints = 0;
    int totalPoints = 0;
    string line;
    while (getline(fileStream, line)) {
        roundPoints = 0;
        char oppRaw = line[0];
        char meRaw = line[2];
        switch (oppRaw) {
            case 'A':
                oppPlay = Rock;
                break;
            case 'B':
                oppPlay = Paper;
                break;
            case 'C':
                oppPlay = Scissors;
                break;
            default:
                break;
        }

        switch (meRaw) {
            case 'X':
                mePlay = Rock;
                break;
            case 'Y':
                mePlay = Paper;
                break;
            case 'Z':
                mePlay = Scissors;
                break;
            default:
                break;
        }
        roundPoints += mePlay;

        if (oppPlay == mePlay){
            matchOutcome = Draw;
        } else if (oppPlay == Rock && mePlay == Paper){
            matchOutcome = Win;
        } else if (oppPlay == Rock && mePlay == Scissors){
            matchOutcome = Loss;
        } else if (oppPlay == Paper && mePlay == Rock){
            matchOutcome = Loss;
        } else if (oppPlay == Paper && mePlay == Scissors){
            matchOutcome = Win;
        } else if (oppPlay == Scissors && mePlay == Rock){
            matchOutcome = Win;
        } else if (oppPlay == Scissors && mePlay == Paper){
            matchOutcome = Loss;
        }
        roundPoints += matchOutcome;
        totalPoints += roundPoints;
    }

    return totalPoints;
}

int AdventOfCode::DayTwo::IntroTwo(string const& path) {
    ifstream fileStream;
    string finalPath = path + (R"(\Day2_Intro.txt)");
    fileStream.open(finalPath);
    Moves oppPlay;
    Moves mePlay;
    Outcomes matchOutcome;
    int roundPoints = 0;
    int totalPoints = 0;
    string line;
    while (getline(fileStream, line)) {
        roundPoints = 0;
        char oppRaw = line[0];
        char meRaw = line[2];
        switch (oppRaw) {
            case 'A':
                oppPlay = Rock;
                break;
            case 'B':
                oppPlay = Paper;
                break;
            case 'C':
                oppPlay = Scissors;
                break;
            default:
                break;
        }

        switch (meRaw) {
            case 'X':
                matchOutcome = Loss;
                break;
            case 'Y':
                matchOutcome = Draw;
                break;
            case 'Z':
                matchOutcome = Win;
                break;
            default:
                break;
        }
        roundPoints += matchOutcome;
        if (matchOutcome == Loss){
            switch (oppPlay) {
                case Rock:
                    mePlay = Scissors;
                    break;
                case Paper:
                    mePlay = Rock;
                    break;
                case Scissors:
                    mePlay = Paper;
                    break;
            }
        }
        else if (matchOutcome == Win){
            switch (oppPlay) {
                case Rock:
                    mePlay = Paper;
                    break;
                case Paper:
                    mePlay = Scissors;
                    break;
                case Scissors:
                    mePlay = Rock;
                    break;
            }
        }
        else if (matchOutcome == Draw){
            switch (oppPlay) {
                case Rock:
                    mePlay = Rock;
                    break;
                case Paper:
                    mePlay = Paper;
                    break;
                case Scissors:
                    mePlay = Scissors;
                    break;
            }
        }
        roundPoints += mePlay;

        totalPoints += roundPoints;
    }

    return totalPoints;
}

int AdventOfCode::DayTwo::PartTwo(string const& path) {
    ifstream fileStream;
    string finalPath = path + (R"(\Day2_Actual.txt)");
    fileStream.open(finalPath);
    Moves oppPlay;
    Moves mePlay;
    Outcomes matchOutcome;
    int roundPoints = 0;
    int totalPoints = 0;
    string line;
    while (getline(fileStream, line)) {
        roundPoints = 0;
        char oppRaw = line[0];
        char meRaw = line[2];
        switch (oppRaw) {
            case 'A':
                oppPlay = Rock;
                break;
            case 'B':
                oppPlay = Paper;
                break;
            case 'C':
                oppPlay = Scissors;
                break;
            default:
                break;
        }

        switch (meRaw) {
            case 'X':
                matchOutcome = Loss;
                break;
            case 'Y':
                matchOutcome = Draw;
                break;
            case 'Z':
                matchOutcome = Win;
                break;
            default:
                break;
        }
        roundPoints += matchOutcome;
        if (matchOutcome == Loss){
            switch (oppPlay) {
                case Rock:
                    mePlay = Scissors;
                    break;
                case Paper:
                    mePlay = Rock;
                    break;
                case Scissors:
                    mePlay = Paper;
                    break;
            }
        }
        else if (matchOutcome == Win){
            switch (oppPlay) {
                case Rock:
                    mePlay = Paper;
                    break;
                case Paper:
                    mePlay = Scissors;
                    break;
                case Scissors:
                    mePlay = Rock;
                    break;
            }
        }
        else if (matchOutcome == Draw){
            switch (oppPlay) {
                case Rock:
                    mePlay = Rock;
                    break;
                case Paper:
                    mePlay = Paper;
                    break;
                case Scissors:
                    mePlay = Scissors;
                    break;
            }
        }
        roundPoints += mePlay;

        totalPoints += roundPoints;
    }

    return totalPoints;
}