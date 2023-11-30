use std::{fs::File, io::Read};

fn main() {
    part1();
}



fn part1() {
    let intro = "D:\\AdventOfCode\\AOC2023\\Day1\\Inputs\\intro.txt";
    let input = "D:\\AdventOfCode\\AOC2023\\Day1\\Inputs\\actual.txt";

    let mut file = File::open(intro).unwrap();
    let mut text = String::new();
    file.read_to_string(&mut text);
    let mut lines:Vec<&str> = text.split('\n').collect();

    for line in lines {
        println!("{}", line);
    }

}
