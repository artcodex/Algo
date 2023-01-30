package main

import (
    "bufio"
    "fmt"
    "io"
    "os"
    "time"
    "strconv"
    "strings"
)

/*
 * Complete the 'dayOfProgrammer' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts INTEGER year as parameter.
 */

func dayOfProgrammer(year int32, writer *bufio.Writer) string {
    // Write your code here
    t := time.Date(int(year), time.January, 1, 20, 0, 0, 0, time.UTC)
    newTime := t.AddDate(0,0,255)
    isLeap := year%4 == 0
    
    if year < 1918 && isLeap {
       if year%400 != 0 && year%100 == 0 {
           newTime = newTime.AddDate(0,0,-1)
       }
    } else if year == 1918 {
        newTime = newTime.AddDate(0,0,13)
    }
        
    return fmt.Sprintf("%02d.%02d.%d\n", newTime.Day(), newTime.Month(), newTime.Year())
}

func main() {
    reader := bufio.NewReaderSize(os.Stdin, 16 * 1024 * 1024)

    stdout, err := os.Create(os.Getenv("OUTPUT_PATH"))
    checkError(err)

    defer stdout.Close()

    writer := bufio.NewWriterSize(stdout, 16 * 1024 * 1024)

    yearTemp, err := strconv.ParseInt(strings.TrimSpace(readLine(reader)), 10, 64)
    checkError(err)
    year := int32(yearTemp)

    result := dayOfProgrammer(year, writer)

    fmt.Fprintf(writer, "%s\n", result)

    writer.Flush()
}

func readLine(reader *bufio.Reader) string {
    str, _, err := reader.ReadLine()
    if err == io.EOF {
        return ""
    }

    return strings.TrimRight(string(str), "\r\n")
}

func checkError(err error) {
    if err != nil {
        panic(err)
    }
}

