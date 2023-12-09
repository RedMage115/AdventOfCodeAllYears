import java.io.File


fun partOne(file: String) : Int {
    val regexRed = Regex("\\d+ red")
    val regexGreen = Regex("\\d+ green")
    val regexBlue = Regex("\\d+ blue")
    val redMax = 12
    val greenMax = 13
    val blueMax = 14
    var sum = 0
    File(file).forEachLine {
        val gameId = it.split(":")[0].split(' ')[1].toInt()
        val rounds = it.split(":")[1].split(";")
        println("$rounds")
        var redHighest = 0
        var greenHighest = 0
        var blueHighest = 0
        for (round in rounds){
            val redRaw = regexRed.findAll(round)
            val greenRaw = regexGreen.findAll(round)
            val blueRaw = regexBlue.findAll(round)
            var red = 0;
            var green = 0;
            var blue = 0;
            if (redRaw.count() > 0){ red = redRaw.first().value.trim().split(' ')[0].toInt()}
            if (greenRaw.count() > 0){ green = greenRaw.first().value.trim().split(' ')[0].toInt()}
            if (blueRaw.count() > 0){ blue = blueRaw.first().value.trim().split(' ')[0].toInt()}

            if (red > redHighest) {redHighest = red}
            if (green > greenHighest) {greenHighest = green}
            if (blue > blueHighest) {blueHighest = blue}
        }
        println("Red Highest: $redHighest")
        println("Green Highest: $greenHighest")
        println("Blue Highest: $blueHighest")
        if (redHighest <= redMax && greenHighest <= greenMax && blueHighest <= blueMax){
            sum+=gameId;
        }
    }
    return sum
}
fun partTwo(file: String) : Int {
    val regexRed = Regex("\\d+ red")
    val regexGreen = Regex("\\d+ green")
    val regexBlue = Regex("\\d+ blue")
    val redMax = 12
    val greenMax = 13
    val blueMax = 14
    var sum = 0
    File(file).forEachLine {
        val gameId = it.split(":")[0].split(' ')[1].toInt()
        val rounds = it.split(":")[1].split(";")
        println("$rounds")
        var redHighest = 0
        var greenHighest = 0
        var blueHighest = 0
        for (round in rounds){
            val redRaw = regexRed.findAll(round)
            val greenRaw = regexGreen.findAll(round)
            val blueRaw = regexBlue.findAll(round)
            var red = 0;
            var green = 0;
            var blue = 0;
            if (redRaw.count() > 0){ red = redRaw.first().value.trim().split(' ')[0].toInt()}
            if (greenRaw.count() > 0){ green = greenRaw.first().value.trim().split(' ')[0].toInt()}
            if (blueRaw.count() > 0){ blue = blueRaw.first().value.trim().split(' ')[0].toInt()}

            if (red > redHighest) {redHighest = red}
            if (green > greenHighest) {greenHighest = green}
            if (blue > blueHighest) {blueHighest = blue}
        }
        println("Red Highest: $redHighest")
        println("Green Highest: $greenHighest")
        println("Blue Highest: $blueHighest")
        sum+=(redHighest*blueHighest*greenHighest)
    }
    return sum
}

fun main() {
    val introFile = "D:\\AdventOfCodeAllYears\\AOC2023\\Day2\\Inputs\\intro.txt"
    val actualFile = "D:\\AdventOfCodeAllYears\\AOC2023\\Day2\\Inputs\\actual.txt"
    println("Intro: ${partOne(introFile)}")
    println("Part One: ${partOne(actualFile)}")
    println("Part Two: ${partTwo(actualFile)}")
}