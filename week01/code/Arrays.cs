using System.IO.Pipelines;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // crate an array with size of the number of multiples
        double[] results = new double[length];



        // loop from 0 up to -1
        for (int i = 0; i < length; i = i + 1)
        {
        // for each position i, calculate start * (i +1)
            results[i] = number * (i + 1);
        }
        // store the value in the array
        // return the array
        
        return results; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static List<int> RotateListRight(List<int> data, int amount)
    {
        // create a list that will hold the final results after the rotation
        List<int> FinalResults = new List<int>();


        // to get the slice from the range you must get the data count using data.count

        // create a list that will hold the last amount of items from the data list
        List<int> lastSlice = data.GetRange(data.Count - amount, amount);
        
        // crate a list that will hold the first amount of items from the data list 
        List<int> FirstSlice = data.GetRange(0, data.Count - amount);
        // add the first and last slices to the final results list in the correct order
        FinalResults.AddRange(lastSlice);
        FinalResults.AddRange(FirstSlice);
        // display the final results list to the console
        return FinalResults; 
    }
}
