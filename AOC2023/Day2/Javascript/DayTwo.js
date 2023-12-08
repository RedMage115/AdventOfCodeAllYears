const IntroFile = String.raw`D:\AdventOfCodeAllYears\AOC2023\Day2\Inputs\intro.txt`;
const ActualFile = String.raw`D:\AdventOfCodeAllYears\AOC2023\Day2\Inputs\actual.txt`;
const fs = require('fs');

const MaxBlue = 14;
const MaxRed = 12;
const MaxGreen = 13;

function PartOne(file) {
    let lines = fs.readFileSync(file, 'utf8', (err, data) => {console.log(err)});
    let split = lines.split('\n');
    const gameIdRegex = new RegExp("\\d+");
    const redRegex = new RegExp("\\d+ red");
    const greenRegex = new RegExp("\\d+ green");
    const blueRegex = new RegExp("\\d+ blue");
    let sum = 0;
    split.forEach(element => {
        let gameId = element.split(':')[0].match(gameIdRegex)[0]
        let rounds = element.split(':')[1].split("; ");
        let possible = true;
        rounds.forEach(round => {

            const redRaw = round.match(redRegex);
            const greenRaw = round.match(greenRegex);
            const blueRaw = round.match(blueRegex);
            let red = 0;
            let green = 0;
            let blue = 0;
            if(redRaw){
                red = parseInt(redRaw[0]);
            }
            if(greenRaw){
                green = parseInt(greenRaw[0]);
            }
            if(blueRaw){
                blue = parseInt(blueRaw[0]);
            }
            if(red > MaxRed || green > MaxGreen || blue > MaxBlue){
                possible = false;
            }
        });

        if(possible){
            sum+= parseInt(gameId);
        }
    });
    return sum;
}

function PartTwo(file) {
    let lines = fs.readFileSync(file, 'utf8', (err, data) => {console.log(err)});
    let split = lines.split('\n');
    const gameIdRegex = new RegExp("\\d+");
    const redRegex = new RegExp("\\d+ red");
    const greenRegex = new RegExp("\\d+ green");
    const blueRegex = new RegExp("\\d+ blue");
    let sum = 0;
    split.forEach(element => {
        let gameId = element.split(':')[0].match(gameIdRegex)[0]
        let rounds = element.split(':')[1].split("; ");
        let minRed = 0;
        let minGreen = 0;
        let minBlue = 0;
        rounds.forEach(round => {

            const redRaw = round.match(redRegex);
            const greenRaw = round.match(greenRegex);
            const blueRaw = round.match(blueRegex);
            let red = 0;
            let green = 0;
            let blue = 0;
            if(redRaw){
                red = parseInt(redRaw[0]);
            }
            if(greenRaw){
                green = parseInt(greenRaw[0]);
            }
            if(blueRaw){
                blue = parseInt(blueRaw[0]);
            }
            if(red > minRed) minRed = red;
            if(green > minGreen) minGreen = green;
            if(blue > minBlue) minBlue = blue;
        });
        sum += (minRed * minBlue * minGreen);
    });
    return sum;
}



function main() {
    console.log(`Intro: ${PartOne(IntroFile)}`);
    console.log(`Part One: ${PartOne(ActualFile)}`);
    console.log(`Part Two: ${PartTwo(ActualFile)}`);
}

main();
