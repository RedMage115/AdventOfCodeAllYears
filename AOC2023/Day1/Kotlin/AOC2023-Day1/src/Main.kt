import java.io.File

fun partOne(file: String): Int {
    var sum = 0
    File(file).forEachLine {
        var first = ' '
        var last = ' '
        for(c in it) {
            if (c.isDigit()) {
                first = c
                break
            }
        }
        for(c in it.reversed()) {
            if (c.isDigit()) {
                last = c
                break
            }
        }
        val result = "" + first + last
        //println(result)
        sum+= result.toInt()
    }
    return sum
}

fun partTwo(file: String): Int {
    var sum = 0
    File(file).forEachLine {
        var line = it
        line = line.replace("one","o1e")
        line = line.replace("two","t2o")
        line = line.replace("three","th3ee")
        line = line.replace("four","fo4r")
        line = line.replace("five","fi5e")
        line = line.replace("six","s6x")
        line = line.replace("seven","sev7n")
        line = line.replace("eight","ei8ht")
        line = line.replace("nine","ni9e")
        var first = ' '
        var last = ' '
        for(c in line) {
            if (c.isDigit()) {
                first = c
                break
            }
        }
        for(c in line.reversed()) {
            if (c.isDigit()) {
                last = c
                break
            }
        }
        val result = "" + first + last
        //println(result)
        sum+= result.toInt()
    }
    return sum
}

fun main() {
    val introFile = "D:\\AdventOfCodeAllYears\\AOC2023\\Day1\\Inputs\\intro.txt";
    val actualFile = "D:\\AdventOfCodeAllYears\\AOC2023\\Day1\\Inputs\\actual.txt";
    val intro = partOne(introFile)
    val partOne = partOne(actualFile)
    val partTwo = partTwo(actualFile)
    println("Intro: $intro")
    println("Part One: $partOne")
    println("Part Two: $partTwo")

}



