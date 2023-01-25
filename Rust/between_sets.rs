use std::env;
use std::fs::File;
use std::io::{self, BufRead, Write};

/*
 * Complete the 'getTotalX' function below.
 *
 * The function is expected to return an INTEGER.
 * The function accepts following parameters:
 *  1. INTEGER_ARRAY a
 *  2. INTEGER_ARRAY b
 */

fn getTotalX(a: &[i32], b: &[i32]) -> i32 {
    let start = *a.iter().max().unwrap();
    let end = *b.iter().max().unwrap();
    let mut first = Vec::new();
    let mut result: i32 = 0;
    
    
    for i in start..end+1 {
        let mut count = 0;
        for val in a.iter() {
            if i % *val == 0 {
                count+=1;
            } else {
                break;
            }
        }
        
        if count == a.len() {
            first.push(i);
        }
    }
    
    
    for op in first.iter() {
        let mut count = 0;
        for val in b.iter() {
            if  *val % *op == 0 {
                count += 1;
            } else {
                break;
            }
        }
        
        if count == b.len() {
            result+=1;
        }
    }
    
    return result;
}

fn main() {
    let stdin = io::stdin();
    let mut stdin_iterator = stdin.lock().lines();

    let mut fptr = File::create(env::var("OUTPUT_PATH").unwrap()).unwrap();

    let first_multiple_input: Vec<String> = stdin_iterator.next().unwrap().unwrap()
        .split(' ')
        .map(|s| s.to_string())
        .collect();

    let n = first_multiple_input[0].trim().parse::<i32>().unwrap();

    let m = first_multiple_input[1].trim().parse::<i32>().unwrap();

    let arr: Vec<i32> = stdin_iterator.next().unwrap().unwrap()
        .trim_end()
        .split(' ')
        .map(|s| s.to_string().parse::<i32>().unwrap())
        .collect();

    let brr: Vec<i32> = stdin_iterator.next().unwrap().unwrap()
        .trim_end()
        .split(' ')
        .map(|s| s.to_string().parse::<i32>().unwrap())
        .collect();

    let total = getTotalX(&arr, &brr);

    writeln!(&mut fptr, "{}", total).ok();
}

