const IntroFile = "D:\\AdventOfCodeAllYears\\AOC2023\\Day1\\Inputs\\intro.txt"
const ActualFile = "D:\\AdventOfCodeAllYears\\AOC2023\\Day1\\Inputs\\actual.txt"
const fs = require('fs');



function PartOne(file) {
    let lines = fs.readFileSync(file, 'utf8', (err) => {if(err) console.log(err);});
    let split = lines.split('\n');
    const regex = new RegExp("\\d");
    let sum = 0;
    split.forEach(element => {
        let first = '';
        let last = '';
        for (let index = 0; index < element.length; index++) {
            const entry = element[index];
            if(regex.test(entry)){
                first = entry;
                break;
            }
        }
        for (let index = element.length; index >= 0; index--) {
            const entry = element[index];
            if(regex.test(entry)){
                last = entry;
                break;
            }
        }
        let result = first+last;
        sum += parseInt(result);
    });

    return sum;
}


function PartTwo(file) {
    let lines = fs.readFileSync(file, 'utf8', (err) => {if(err) console.log(err);});
    let split = lines.split('\n');
    const regex = new RegExp("\\d");
    let sum = 0;
    split.forEach(element => {
        element = element.replace("one", "o1e");
        element = element.replace("two", "t2o");
        element = element.replace("three", "th3ee");
        element = element.replace("four", "fo4r");
        element = element.replace("five", "fi5e");
        element = element.replace("six", "s6x");
        element = element.replace("seven", "se7en");
        element = element.replace("eight", "eig8t");
        element = element.replace("nine", "ni9e");
        console.log(element)
        let first = '';
        let last = '';
        for (let index = 0; index < element.length; index++) {
            const entry = element[index];
            if(regex.test(entry)){
                first = entry;
                break;
            }
        }
        for (let index = element.length; index >= 0; index--) {
            const entry = element[index];
            if(regex.test(entry)){
                last = entry;
                break;
            }
        }
        let result = first+last;
        sum += parseInt(result);
        console.log(result);
    });

    return sum;
}


function main() {
    console.log(`Intro: ${PartOne(IntroFile)}`)
    console.log(`Part One: ${PartOne(ActualFile)}`)
    console.log(`Part Two: ${PartTwo(ActualFile)}`)
}


main();
