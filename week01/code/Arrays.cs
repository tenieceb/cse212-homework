using System.Data;
using System.Globalization;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        //////// My Plan ////////
        // Start by creating an array with the assigned length of the length provided
        // iterate through the new array and use a nested for withibn that to multiply the "number" beginning with 1 up to the "length" assigning the "results" as it iterates
        double[] multiples = new double[length];
        for (int i = 0; i < length; i++){
            for (double j=1; i<length; j++){
                multiples[i]= j*number;
            }
        }

        return multiples;
    }

    

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        //////// My Plan ////////
        // Using data.GetRange(0, data.Count - amount) to select all of the data that will need to be shifted and assign it to a new <List> 
        // Next, remove the same range from the data that we just assigned to a new <List> using data.RemoveRange(0, data.Count - amount)
        // Lastly, use data.AddRange(new <List>) to add the list we created with GetRange to the end of the data list which will have shifted the values to the right "amount" of times.
        List<int> shiftThis = data.GetRange(0, data.Count - amount);
        data.RemoveRange(0,data.Count - amount);
        data.AddRange(shiftThis);
        foreach (int i in data){
            Console.WriteLine($"{i}");
        }
    }

}
