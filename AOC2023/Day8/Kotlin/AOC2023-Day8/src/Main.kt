import java.io.File




fun partOne(file: String) : Int {
    val directionList = mutableListOf<Char>()
    val nodeList = mutableListOf<Node>()
    File(file).forEachLine fileLoop@ {
         //println(it)
        if (it.isBlank()) {
            return@fileLoop
        }
        if (!it.contains("=")) {
            for (c in it){
                directionList.add(c)
            }
            return@fileLoop
        }
        val root = it.split("=").first().trim()
        val dests = it.split("=").last().split(", ")
        val left = dests.first().trim().trim('(')
        val right = dests.last().trim().trim(')')
        nodeList.add(Node(root, left, right, 0))
    }
    var currentNode = nodeList.find { node -> node.rootNode == "AAA" }
    if (currentNode == null) return 0
    var steps = 0
    locationLoop@ while(currentNode?.rootNode != "ZZZ"){
        if (currentNode == null) return 0
        directionLoop@ for (dir in directionList) {
            when(dir) {
               'L' -> currentNode = nodeList.find { node -> node.rootNode == currentNode?.leftDest }
               'R' -> currentNode = nodeList.find { node -> node.rootNode == currentNode?.rightDest }
               else -> println("AAAAAAAAAA")
            }
            steps++
            if (currentNode?.rootNode == "ZZZ") {
                println("Breaking on ZZZ")
                println(currentNode.rootNode)
                continue@locationLoop
            }
        }
    }

    return steps
}

fun partTwo(file: String) : Long {
    val directionList = mutableListOf<Char>()
    val nodeList = mutableListOf<Node>()
    File(file).forEachLine fileLoop@ {
        //println(it)
        if (it.isBlank()) {
            return@fileLoop
        }
        if (!it.contains("=")) {
            for (c in it){
                directionList.add(c)
            }
            return@fileLoop
        }
        val root = it.split("=").first().trim()
        val dests = it.split("=").last().split(", ")
        val left = dests.first().trim().trim('(')
        val right = dests.last().trim().trim(')')
        nodeList.add(Node(root, left, right, 0))
    }
    val currentNodes = nodeList.filter { node -> node.rootNode.last() == 'A' }

    for (x in 0..currentNodes.count() - 1) {
        var cNode:Node? = currentNodes[x]
        locationLoop@ while(cNode?.rootNode?.last() != 'Z'){
            directionLoop@ for (dir in directionList) {
                when(dir) {
                    'L' -> cNode = nodeList.find { node -> node.rootNode == cNode?.leftDest }
                    'R' -> cNode = nodeList.find { node -> node.rootNode == cNode?.rightDest }
                    else -> println("AAAAAAAAAA")
                }
                currentNodes[x].stepsRequired++
                if (cNode?.rootNode?.last() == 'Z') {
                    println("Breaking on Z")
                    println(cNode.rootNode)
                    continue@locationLoop
                }
            }
        }
    }
    var acc = 0L
    for (n in 1..<currentNodes.count()) {
        if (acc == 0L) {
            acc = lcm(currentNodes[n].stepsRequired, currentNodes[n-1].stepsRequired)
        }
        else {
            acc = lcm(acc, currentNodes[n].stepsRequired)
        }
    }

    return acc
}

fun gcf(a:Long, b:Long) : Long {
    var x = a
    var y = b
    while (y != 0L) {
        val temp = y
        y = x%y
        x = temp
    }
    return x
}

fun lcm(a:Long, b:Long) : Long {
    return (a / gcf(a,b)) * b
}



fun main() {
    val introFile = "D:\\AdventOfCodeAllYears\\AOC2023\\Day8\\Inputs\\intro.txt"
    val actualFile = "D:\\AdventOfCodeAllYears\\AOC2023\\Day8\\Inputs\\actual.txt"

    println("Intro: ${partOne(introFile)}")
    println("Part One: ${partOne(actualFile)}")
    println("Part One: ${partTwo(actualFile)}")
}



class Node(val rootNode: String, val leftDest: String, val rightDest: String, var stepsRequired: Long)