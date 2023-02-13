use std::env;
use std::fs::File;
use std::io::{self, BufRead, Write};

/*
 * Complete the 'viralAdvertising' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts INTEGER n as parameter.
 */

fn viralAdvertising(n: i32) -> i32 {
    let mut likes = 0;
    let mut people = 5;
    for i in 1..n+1 {
        let cur_like = (f64::from(people) / 2.0).floor() as i32;
        people = cur_like * 3;
        likes += cur_like;
    }
    
    return likes;
}

fn main() {
    let stdin = io::stdin();
    let mut stdin_iterator = stdin.lock().lines();

    let mut fptr = File::create(env::var("OUTPUT_PATH").unwrap()).unwrap();

    let n = stdin_iterator.next().unwrap().unwrap().trim().parse::<i32>().unwrap();

    let result = viralAdvertising(n);

    writeln!(&mut fptr, "{}", result).ok();
}
