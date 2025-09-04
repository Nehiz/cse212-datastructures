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
        // Plan for the MultiplesOf function
        // 1. Create a new array with size = length
        // 2. Loop from 0 to 'length' - 1
        //    a. For each index (i) in the array, calculate the multiple by multiplying (i + 1) * number
        //    b. Store the result in the array at index 'i'
        // 3. After the loop, return the populated array.

        //  Step 1: Create a new array
        double[] result = new double[length];

        //  Step 2: Loop from 0 to 'length' - 1
        for (int i = 0; i < length; i++)
        {
            //    a. For each index (i) in the array, calculate the multiple by multiplying (i + 1) * number
            double multiple = (i + 1) * number;

            //    b. Store the result in the array at index 'i'
            result[i] = multiple;
        }

        return result; // replace this return statement with your own
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
        // Plan for the RotateListRight function
        // 1. Handle edge case: if data is null, empty or rotation amount is 0, do nothing
        // 2. Determine the effective number of elements to move from the end of the list.
        // 3. Extract two parts of the list (movedPart and remainingPart) using GetRange. 
        //    movedPart = the last effectiveAmount elements; remainingPart = the rest of the list.
        // 4. Clear the original list.
        // 5. Add the movedPart and remainingPart back into the original list in that order to complete the rotation.

        // Step 1: Handle edge case 
        if (data == null || data.Count == 0)
        {
            return; // Do nothing
        } 

        // Step 2: Determine the new effective rotation amount.
        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0)
        {
            return; // Do nothing
        }

        // Step 3 Extract the two parts of the List.
        List<int> movedPart = data.GetRange(data.Count - effectiveAmount, effectiveAmount);
        List<int> remainingPart = data.GetRange(0, data.Count - effectiveAmount);

        // Step 4 & 5: Clear and rebuild it with the rotated parts.
        data.Clear();
        data.AddRange(movedPart);
        data.AddRange(remainingPart);
    }
}
