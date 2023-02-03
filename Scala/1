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

    // Complete the catAndMouse function below.
    def catAndMouse(x: Int, y: Int, z: Int): String = {

        val distA = math.abs(z-x)
        val distB = math.abs(z-y)
        
        if (distA > distB) {
            return "Cat B"
        } else if (distB > distA) {
            return "Cat A"
        } else {
            return "Mouse C"
        }
    }

    def main(args: Array[String]) {
        val stdin = scala.io.StdIn

        val printWriter = new PrintWriter(sys.env("OUTPUT_PATH"))

        val q = stdin.readLine.trim.toInt

        for (qItr <- 1 to q) {
            val xyz = stdin.readLine.split(" ")

            val x = xyz(0).trim.toInt

            val y = xyz(1).trim.toInt

            val z = xyz(2).trim.toInt

            val result = catAndMouse(x, y, z)

            printWriter.println(result)
        }

        printWriter.close()
    }
}

