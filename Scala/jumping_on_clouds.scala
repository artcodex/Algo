import java.io._
import java.math._
import java.security._
import java.text._
import java.util._
import java.util.concurrent._
import java.util.function._
import java.util.regex._
import java.util.stream._

object Solution {

    // Complete the jumpingOnClouds function below.
    def jumpingOnClouds(c: Array[Int], k: Int): Int = {
        var e = 100
        var i = 0

        do {
        e -= 1
        i = (i + k) % c.length
        if (c(i) == 1) {
            e -= 2
        }
        } while (i != 0)

        e
    }

    def main(args: Array[String]) {
        val stdin = scala.io.StdIn

        val printWriter = new PrintWriter(sys.env("OUTPUT_PATH"))

        val nk = stdin.readLine.split(" ")

        val n = nk(0).trim.toInt

        val k = nk(1).trim.toInt

        val c = stdin.readLine.split(" ").map(_.trim.toInt)
        val result = jumpingOnClouds(c, k)

        printWriter.println(result)

        printWriter.close()
    }
}

