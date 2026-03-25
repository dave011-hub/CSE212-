public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text) {
        // TODO Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency

        // crate a set to store the letters 
        var uniqueletters = new HashSet<char>();
        
        // for each letter in the text, check if it is already in the set
        foreach(char letter in text)
        {
            // if there are no duplicates of a letter then it will return true meaning it is unique 
            if (uniqueletters.Contains(letter))
                return false;
            uniqueletters.Add(letter);

        }

        return true;

    }
}


// private static bool AreUniqueLetters(string text)
// {
//     // TODO Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency
//     var set1 = new HashSet<char>();
//     for (var i = 0; i < text.Length; ++i)
//     {
//         if (set1.Contains(text[i]))
//         {
//             return false;
//         }
//         else
//         {
//             set1.Add(text[i]);
//         }
//         // for (var j = 0; j < text.Length; ++j) {
//         //     // Don't want to compare to yourself ... that will always result in a match
//         //     if (i != j && text[i] == text[j])
//         //         return false;
//         // }
//     }

//     return true;
// }