#include <iostream>
#include <fstream>
#include <vector>
#include <map>
#include <regex>

using namespace std;


int PartOne() {
    auto file = ifstream (R"(D:\AdventOfCode\AOC2023\Day1\Inputs\actual.txt)");
    //auto file = ifstream (R"(D:\AdventOfCode\AOC2023\Day1\CPlusPlus\AOC2023-Day1\why.txt)");
    string line;
    auto numbers = vector<char>();
    numbers.push_back('1');
    numbers.push_back('2');
    numbers.push_back('3');
    numbers.push_back('4');
    numbers.push_back('5');
    numbers.push_back('6');
    numbers.push_back('7');
    numbers.push_back('8');
    numbers.push_back('9');
    int sum = 0;
    while(getline(file, line)) {
        char first = '+';
        char last = '+';
        for (char i : line) {
            for (auto num:numbers) {
                if (num == i){
                    first = i;
                    break;
                }
            }
            if (first != '+') break;
        }
        for (int x = line.length() - 1; x > -1; --x) {
            auto text = line[x];
            for (auto num2:numbers) {
                if (num2 == text){
                    last = text;
                    break;
                }
            }
            if (last != '+') break;
        }
        int final = 10 * (first - 48) + (last  - 48);
        sum += final;
    }

    return sum;
}

int PartTwo() {
    auto file = ifstream (R"(D:\AdventOfCode\AOC2023\Day1\Inputs\actual.txt)");
    //auto file = ifstream (R"(D:\AdventOfCode\AOC2023\Day1\CPlusPlus\AOC2023-Day1\why.txt)");
    string line;
    auto numbers = vector<char>();
    numbers.push_back('1');
    numbers.push_back('2');
    numbers.push_back('3');
    numbers.push_back('4');
    numbers.push_back('5');
    numbers.push_back('6');
    numbers.push_back('7');
    numbers.push_back('8');
    numbers.push_back('9');
    auto numMap = map<string, string>();
    numMap.insert({"one", "o1n"});
    numMap.insert({"two", "t2o"});
    numMap.insert({"three", "thr3e"});
    numMap.insert({"four", "fo4r"});
    numMap.insert({"five", "fi5e"});
    numMap.insert({"six", "s6x"});
    numMap.insert({"seven", "se7en"});
    numMap.insert({"eight", "ei8ht"});
    numMap.insert({"nine", "ni9e"});
    int sum = 0;
    while(getline(file, line)) {
        for (const auto& numM:numMap) {
            line = regex_replace(line, regex(numM.first), numM.second);
        }
        char first = '+';
        char last = '+';
        for (char i : line) {
            for (auto num:numbers) {
                if (num == i){
                    first = i;
                    break;
                }
            }
            if (first != '+') break;
        }
        for (int x = line.length() - 1; x > -1; --x) {
            auto text = line[x];
            for (auto num2:numbers) {
                if (num2 == text){
                    last = text;
                    break;
                }
            }
            if (last != '+') break;
        }
        int final = 10 * (first - 48) + (last  - 48);
        sum += final;
    }

    return sum;
}


int main() {
    std::cout << "Part One: " << PartOne() << std::endl;
    std::cout << "Part Two: " << PartTwo() << std::endl;
    return 0;
}
