using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // crate a set to store the words because sets have O(1) lookup time and does not allow dupicates
        var wordSet = new HashSet<string>(words);
        // crate a list to store your results 
        var results = new List<string>();
        // for each word in the array
        foreach (string word in words)
        {
            // make sure you skip duplicate words like aa
            if(!wordSet.Contains(word))
                continue;
            
            // reverse the word and check if the reversed word is in the set
            var reversedword = new string(word.Reverse().ToArray());
            // if it is in the set then add the pair to the result set 
            if (wordSet.Contains(reversedword) && word != reversedword)
            {
            results.Add($"{word}&{reversedword}");
            // make sure you dont count again by removing from the set 
            wordSet.Remove(word);
            wordSet.Remove(reversedword);
            }


        }
        // return the result of the set as an array 
        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string census)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(census))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            // if degrees is in column 4 the it is in index 3 
            var degree = fields[3];

            // add it to the dictionary if it does not contain the degree already 
            if (!degrees.ContainsKey(degree))
                degrees[degree] = 1;
            else
                degrees[degree]++;
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        // ignore any spaces and convert to a common character to be easily compared and to ignore cases when Ab and Ba are compared
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();
        // chack if the words length are equal
        if (word1.Length != word2.Length)
        {
            return false;
        }
        // crate a dictionary to store all the values ones as an int to keep count and one as string
        var dictionary = new Dictionary<char, int>();
        // foreach letter in word1 is equal to word2
        foreach (char letter in word1)
        {
            if (!dictionary.ContainsKey(letter))
                dictionary[letter] = 1;
            else
                dictionary[letter]++;
        }
        // foreach word in word2 
        foreach (char letter in word2)
        {
            // if any word goes below zero then its not an anagram 
            // if not decrease count 
            // if the chracter is not in the dictionary then its not an anagram 
            if (!dictionary.ContainsKey(letter))
                return false;
            dictionary[letter]--;

            if (dictionary[letter] < 0)
                return false;

        }
        // if it has all the characters and the same number or characters the return true 
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        List<string> results = new List<string>();
        foreach (var feature in featureCollection.features)
        {
            var props = feature.properties;
            var date = DateTimeOffset.FromUnixTimeMilliseconds(props.time);
            if (date.Date == DateTimeOffset.UtcNow.Date)
            {
                results.Add($"{props.place} - Mag {props.mag}");
            }
        }
        return results.ToArray();
    }
}