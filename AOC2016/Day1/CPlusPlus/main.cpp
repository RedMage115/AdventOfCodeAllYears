#include <iostream>
#include <fstream>
#include <vector>
using namespace std;

void trim(string& text){
    for (int i = 0; i < text.length(); ++i) {
        if (text[i] == ' ') {
            text.erase(i, 1);
        }
    }
}

struct position {
    int x = 0;
    int y = 0;
};

enum direction {
    y_plus,
    x_plus,
    y_minus,
    x_minus,
};

direction getDirection(int rot, direction curPos) {
    if (curPos == y_plus && rot == -1){
        return x_minus;
    }
    if (curPos == x_minus && rot == 1){
        return y_plus;
    }
    return static_cast<direction>(curPos + rot);
}

void doMove(int len, position &pos, direction dir) {
    switch (dir) {
        case y_plus:
            pos.y += len;
            break;
        case x_plus:
            pos.x += len;
            break;
        case y_minus:
            pos.y -= len;
            break;
        case x_minus:
            pos.x -= len;
            break;
    }
}

int partOne() {
    ifstream input;
    input.open(R"(D:\AdventOfCode\AOC2016\Day1\Inputs\actual.txt)");
    position pos;
    direction direction = y_plus;
    int distance = 0;
    vector<string> directions;
    while(input){
        string line;
        getline(input, line, ',');
        trim(line);
        directions.push_back(line);
    }
    for (auto& dir:directions) {
        if (dir.length() < 2) continue;
        //cout << dir << endl;
        switch (dir[0]) {
            case 'L':
                direction = getDirection(-1, direction);
                break;
            case 'R':
                direction = getDirection(1, direction);
                break;
            default:
                break;
        }
        int len = stoi(dir.substr(1));
        doMove(len, pos, direction);
        cout << "x:" << pos.x << '\t' << "Y:" << pos.y << endl;
    }
    return pos.y + pos.x;
}

int partTwo() {
    ifstream input;
    input.open(R"(D:\AdventOfCode\AOC2016\Day1\Inputs\intro2.txt)");
    position pos;
    direction direction = y_plus;
    int distance = 0;
    vector<string> directions;
    vector<position> posHistory;
    while(input){
        string line;
        getline(input, line, ',');
        trim(line);
        directions.push_back(line);
    }
    int cnt = 0;
    for (auto& dir:directions) {
        if (dir.length() < 2) continue;
        cout << cnt <<" - [" << direction <<"] " << dir << endl;
        switch (dir[0]) {
            case 'L':
                direction = getDirection(-1, direction);
                break;
            case 'R':
                direction = getDirection(1, direction);
                break;
            default:
                break;
        }
        int len = stoi(dir.substr(1));
        doMove(len, pos, direction);

        for (int i = 0; i < posHistory.size() ; ++i) {
            if (pos.x == posHistory[i].x && pos.y == posHistory[i].y){
                cout << "ANSWER[" << i << "] x:" << pos.x << '\t' << "Y:" << pos.y << endl;
                posHistory.push_back(pos);
                cout << cnt << " - x:" << pos.x << '\t' << "Y:" << pos.y << endl;
                return posHistory[i].x + posHistory[i].y;
            }
        }
        posHistory.push_back(pos);
        cout << cnt << " - x:" << pos.x << '\t' << "Y:" << pos.y << endl;
        cnt++;
    }
    return 0;
}


int main() {
    std::cout << "AOC C++ 2016 Day 1" << std::endl;
    int result1 = partOne();
    std::cout << "Part One: " << result1 << std::endl;
    int result2 = partTwo();
    std::cout << "Part Two: " << result2 << std::endl;
    return 0;
}
