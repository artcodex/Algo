vuse std::env;
use std::fs::File;
use std::io::{self, BufRead, Write};

/*
 * Complete the 'breakingRecords' function below.
 *
 * The function is expected to return an INTEGER_ARRAY.
 * The function accepts INTEGER_ARRAY scores as parameter.
 */

fn breakingRecords(scores: &[i32]) -> Vec<i32> {
    let mut min = scores[0];
    let mut max = scores[0];
    let mut minCount = 0;
    let mut maxCount = 0;
    
    for score in scores {
        if *score > max {
            maxCount += 1;
            max = *score;
        }
        
        if *score < min {
            minCount += 1;
            min = *score;
        }
    }
    
    let mut vec = Vec::new();
    vec.push(maxCount);
    vec.push(minCount);
    
    return vec;
}

fn main() {
    let stdin = io::stdin();
    let mut stdin_iterator = stdin.lock().lines();

    let mut fptr = File::create(env::var("OUTPUT_PATH").unwrap()).unwrap();

    let n = stdin_iterator.next().unwrap().unwrap().trim().parse::<i32>().unwrap();

    let scores: Vec<i32> = stdin_iterator.next().unwrap().unwrap()
        .trim_end()
        .split(' ')
        .map(|s| s.to_string().parse::<i32>().unwrap())
        .collect();

    let result = breakingRecords(&scores);

    for i in 0..result.len() {
        write!(&mut fptr, "{}", result[i]).ok();

        if i != result.len() - 1 {
            write!(&mut fptr, " ").ok();
        }
    }

    writeln!(&mut fptr).ok();
}

