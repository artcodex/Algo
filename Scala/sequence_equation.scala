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

object Result {

    /*
     * Complete the 'permutationEquation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY p as parameter.
     */

    def permutationEquation(p: Array[Int]): Array[Int] = {
        val q = p.zipWithIndex.toMap
        val result = p.zipWithIndex.map({case (v, i) =>
        val a = q.get(i+1).getOrElse(0)
        q.get(a+1).getOrElse(0) + 1
        })
        
        result
    }

}

object Solution {
    def main(args: Array[String]) {
        val printWriter = new PrintWriter(sys.env("OUTPUT_PATH"))

        val n = StdIn.readLine.trim.toInt

        val p = StdIn.readLine.replaceAll("\\s+$", "").split(" ").map(_.trim.toInt)

        val result = Result.permutationEquation(p)

        printWriter.println(result.mkString("\n"))

        printWriter.close()
    }
}

