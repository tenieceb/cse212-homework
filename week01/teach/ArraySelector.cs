using System.Xml.XPath;

public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
    }
// MY PLAN
// Iterate through the selector array. 
// Use If statements to determine if the value is 1 or 2.
// If 1 then pull the next value from list1
// If 2 then pull the next value from list2
// Doing this by targeting the list1[0] or list2[0] and assigning it to a variable. Add the variable to the new array that will be returned
// After, using list1 = list1.Skip(1).ToArray() or list2 = list2.Skip(1).ToArray()
// This solution is not ideal if list1 and list2 need to remain intact and would require creating a new array without the the index[0] which would take time

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        var result = new int[select.Length];

        for (var i = 0; i < select.Length; i++)
        {
            if (select[i] == 1)
           {     result[i] = list1[0];
                list1 = list1.Skip(1).ToArray();}
            else 
            {    result[i] = list2[0];
                list2 = list2.Skip(1).ToArray();}
            ;
        }

        return result;
    }



// ///////////// SAMPLE SOLUTION PLAN //////////////////
// To solve the Array Selector problem, we will need to do the following as we loop through the selector array:

// If the current value in the selector array is a 1, then we want to get the next item from the first array
// If the current value in the selector array is a 2, then we want to get the next item from the second array
// We need to append the value we just selected to the new array
// We will need a way to determine what the next item is in either array 1 or array 2. We will need variables to keep track of where we are (i.e. the index) in both arrays:

// array1Index - We will use this to keep track of the index of the next item in the first array
// array2Index - We will use this to keep track of the index of the next item in the second array
// We will initialize both of these variables to 0. When we select an item from one of the arrays (per the selector array) we will add one to either array1Index or array2Index depending on which one was selected.
    // private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    // {
    //     var result = new int[select.Length];
    //     var list1index = 0;
    //     var list2index = 0;
    //     for (var i = 0; i < select.Length; i++)
    //     {
    //         if (select[i] == 1)
    //             result[i] = list1[list1index++];
    //         else
    //             result[i] = list2[list2index++];
    //     }

    //     return result;
    // }
}