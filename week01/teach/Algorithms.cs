using System.Diagnostics;

public static class Algorithms {
    public static void Run() {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}", "n", "alg1-count", "alg2-count", "alg3-count",
            "alg1-time", "alg2-time", "alg3-time");
        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}", "----------");

        for (int n = 0; n < 15001; n += 1000) {
            int count1 = Algorithm1(n);
            int count2 = Algorithm2(n);
            int count3 = Algorithm3(n);
            double time1 = Time(Algorithm1, n, 10);
            double time2 = Time(Algorithm2, n, 10);
            double time3 = Time(Algorithm3, n, 10);
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15:0.00000}{5,15:0.00000}{6,15:0.00000}", n, count1, count2,
                count3, time1, time2,
                time3);
        }
    }

    private static double Time(Func<int, int> algorithm, int input, int times) {
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i) {
            algorithm(input);
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm1(int size) {
        var count = 0;
        for (var i = 0; i < size; ++i)
            count += 1;

        return count;
    }

    // O(n)

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm2(int size) {
        var count = 0;
        for (var i = 0; i < size; ++i)
        for (var j = 0; j < size; ++j)
            count += 1;

        return count;
    }

    // O(n^2)

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm3(int size) {
        var count = 0;
        var start = 0;
        var end = size - 1;
        while (start <= end) {
            var middle = (end - start) / 2 + start;
            start = middle + 1;
            count += 1;
        }

        return count;
    }
    //O(log n)
}

// Answer the following questions. When you have answered each question, compare your response to the sample solution provided.

// Do the actual results agree with the big O predictions made earlier? If not, what do you think the big O should be?
// The Algorithm1 function has a single for loop. This implies O(n). If we look at the actual results, we see that count is the same value as the size of the list. The Algorithm2 function has a loop within a loop. This implies O(n^2). If we look at the actual results, we see that the count is the square of the size of the data. The Algorithm3 functions finds the center of the list and then looks at the 2nd half the list. This process is repeated in which each iteration of the while loop the list is cut in half again. This implies O(log n). If we look at the actual results, we see that the count is approximately the base 2 logarithm of the size.

// Which method (Algorithm1, Algorithm2, Algorithm3) has the best performance and which one the worst performance?
// Based on the timing data, Algorithm3 is much faster and Algorithm2 is much slower. Note that Algorithm3 is barely increasing (if at all) and Algorithm2 is growing by larger amounts as the size of the data increases. This result agrees with the big O notation from above. O(log n) is better than O(n), and O(n) is better than O(n2) when n is "large".

// Looking at the results, why do we say that big O only applies when n in "large"?
// When n is small, the time for all three algorithms is very close to each other. Realizing that these are in milliseconds, the amount of time to see the result for Algorithm2 when n is large will start to approach 1 second unlike the other 2 functions. However, when n is small, no difference is seen by the user.