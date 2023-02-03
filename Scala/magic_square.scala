import java.io._
import java.math._
import java.security._
import java.text._
import java.util._
import java.util.concurrent._
import java.util.function._
import java.util.regex._
import java.util.stream._
import scala.collection.immutable._
import scala.collection.mutable._
import scala.collection.concurrent._
import scala.concurrent._
import scala.io._
import scala.math._
import scala.sys._
import scala.util.matching._
import scala.reflect._
import Array._

object Result {

    /*
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */
    def filterArray(c: Array[Int]): Boolean = {
        val rows = Array(0, 0, 0)
        val cols = Array(0, 0, 0)
        val diagonals = Array(0, 0)
        var i = 0

        for (i <- 0 to 8) {
            rows(i / 3) += c(i)
            cols(i % 3) += c(i)
        }

        diagonals(0) = c(0) + c(4) + c(8)
        diagonals(1) = c(2) + c(4) + c(6)

        val totals = rows.concat(cols).concat(diagonals)
        val results = totals.filter(z => z != totals(0))

        results.length == 0
    }
  
    def formingMagicSquare(s: Array[Array[Int]]): Int = {
    // Write your code here
        val flatS = s.flatMap((x) => x)
        val numbers = range(1, 10)
        val combinations = numbers.permutations

        val combos = combinations.toArray
        println(combos.length)

        val possible = combos.filter(filterArray)

        var minCost = Int.MaxValue
        var listV:Array[Int] = null
        possible.foreach(c => {
        var cost = 0

        for (i <- 0 to 8) {
            if (c(i) != flatS(i)) {
            cost = cost + math.abs(c(i) - flatS(i))
            }
        }

        if (cost < minCost) {
            minCost = cost
            listV = c
        }
        })

        return minCost
    }

}

object Solution {
    def main(args: Array[String]) {
        val printWriter = new PrintWriter(sys.env("OUTPUT_PATH"))

        val s = Array.ofDim[Int](3, 3)

        for (i <- 0 until 3) {
            s(i) = StdIn.readLine.replaceAll("\\s+$", "").split(" ").map(_.trim.toInt)
        }

        val result = Result.formingMagicSquare(s)

        printWriter.println(result)

        printWriter.close()
    }
}

