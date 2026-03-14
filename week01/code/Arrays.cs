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
        // 1 - I'll create an array with the size equal to the number of multiples
        double[] multiples = new double[length];

        // 2 - Loop from 1 to the number of multiples
        for (int i = 0; i < length; i++)
        {
            // 3 - Multiply the starting number by the loop counter
            multiples[i] = number * (i + 1);
            // 4 - Store each result in the array
        }
        // 5 - Return the array
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
        // 1 - I'll Determine the size of the list
        int size = data.Count;

        // 2 - Get the last amount elements
        List<int> lastPart = data.GetRange(size - amount, amount);

        // 3 - Get the first elements
        List<int> firstPart = data.GetRange(0, size - amount);

        // 4 - Clear the original list
         data.Clear();

        // 5 - Add the last elements first
        data.AddRange(lastPart);

        // 6 - Add the first elements after (I'll switch the order of the first and last parts)
        data.AddRange(firstPart);
    }
}
