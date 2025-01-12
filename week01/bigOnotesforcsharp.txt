// Examples to understand Big O in C# written by CHATGPT to help me understand the concept better
// notes written by TenieceB.

// O(1): Constant Time
static int PancakeO1(int[] pancakes) {
    // Always flips the first pancake, regardless of the stack size
    //it doesn't matter the number after the pancakes[index] 
    return pancakes[0];
}

// O(n): Linear Time
static void PancakeON(int[] pancakes) {
    // Flips each pancake one by one
    foreach (var pancake in pancakes) {
        Console.WriteLine($"Flipping pancake {pancake}");
    }
}

// O(n^2): Quadratic Time
static void PancakeON2(int[] pancakes) {
    // Compare each pancake with every other pancake
    for (int i = 0; i < pancakes.Length; i++) {
        // Iterating through the pancakes in the pancake "pile" but then keeping pancake i out
        for (int j = 0; j < pancakes.Length; j++) {
            // Iterating through the pancake pile again to compare to the pancake i, even if it includes i as well
            // To not compare pancake i to itself we would change "int j = 0" to "int j = i +1" to skip i and previously compared values
            Console.WriteLine($"Comparing pancake {pancakes[i]} with {pancakes[j]}");
        }
    }
}

// O(log n): Logarithmic Time
static bool PancakeOLogN(int[] pancakes, int target) {
    // Searching for a pancake using binary search aka - cutting the list in half and checking which half has the item
    // Only works with lists that are already sorted by smaller to larger or alphabetical order or the reverse of each of those.
    int left = 0, right = pancakes.Length - 1;
    // sets up an index of "0 to (n - 1)" where n is the length of the array or list.
    while (left <= right) {
        //loops as long as our left index is not greater than our right index
        int mid = (left + right) / 2;
        // finds the middle index and automatically rounds it down if the number is a decimal
        if (pancakes[mid] == target) {
            return true; //automatically end the loop and the function returning as true
            // checks the value at the index "mid" in the list/array and compares it to what we are searching for, if found it returns that the value is within the list
        } else if (pancakes[mid] < target) {
            // if the value is less than the target at the index of mid, we adjust our "0 to (n-1)" to be "1 to (n-1)" moving our mid index to the right by one and looping again
            left = mid + 1;
        } else {
            // if the value is greater than the target at the index of mid, we adjust our "0 to (n-1)" to be "1 to ((n-1)-1)" moving our mid index to the left by one and looping again
            right = mid - 1;
        }
    }
    return false;//if the while loop checks the whole array and it doe not find our target value within the array it will reuturn false
//this does not have to be a bool it can be a void or an int just depending on what is needed for the program
}

// O(n log n): Log-linear Time
static void PancakeONLogN(int[] pancakes) {
    // Sorting the pancakes (e.g., merge sort, quicksort)
    Array.Sort(pancakes); //Sort in this situation automatically will sort ascending even when its alphabetically, it can be altered to sort in a specific way depending on what the program needs
    // divides the array/list by half and compares each value to each value and then puts the items back together saving into a new, sorted array/list by the same name as the original
    // Sorting itself has a complexity of O(n log n)
    foreach (var pancake in pancakes) {
        Console.WriteLine($"Sorted pancake {pancake}");
    }//this foreach function has a O(n)
    // because the BigO is determined by which operation is more time consuming within a function and which one dominates the larger array/list length, that is why it is O(n log n) and O(n) does not apply

}

// O(2^n): Exponential Time
static int PancakeO2N(int n) {
    // For demonstration: Counting all subsets of a pancake stack
    if (n == 0) return 1;
    return PancakeO2N(n - 1) + PancakeO2N(n - 1);
}

// O(n!): Factorial Time
static void PancakeONFactorial(int[] pancakes) {
    // For demonstration: Generating all permutations of pancakes
    Permute(pancakes, 0, pancakes.Length - 1);
}

static void Permute(int[] arr, int l, int r) {
    if (l == r) {
        Console.WriteLine(string.Join(", ", arr));
    } else {
        for (int i = l; i <= r; i++) {
            (arr[l], arr[i]) = (arr[i], arr[l]); // Swap
            Permute(arr, l + 1, r);
            (arr[l], arr[i]) = (arr[i], arr[l]); // Backtrack
        }
    }
}


// Using either a graphing calculator or a graphing website (e.g. desmos.com), put the following in order (best performance, …, worst performance) for when n is large:
// O(n^2), O(1), O(2^n), O(n log n), O(log n), O(n)

// new order based on the graph:
// O(1)
// O(log n)
// O(n)
// O(n log n)
// O(n^2)
// and then O(2^n)