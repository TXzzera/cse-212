using System.Text.Json;

public static class SetsAndMaps
{
    // Find all pairs of words in a collection that are reverses of each other
    public static string[] FindPairs(string[] words)
    {
        var set = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1])
                continue;

            string reversed = $"{word[1]}{word[0]}";

            if (set.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                set.Add(word);
            }
        }

        return result.ToArray();
    }
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        // Read a file of degrees and count how many of each degree there are.
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");

            if (fields.Length < 4)
                continue;

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }
    // Two words are anagrams if they contain the same letters in a different order.
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        var dict = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (dict.ContainsKey(c))
                dict[c]++;
            else
                dict[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!dict.ContainsKey(c))
                return false;

            dict[c]--;

            if (dict[c] < 0)
                return false;
        }

        return true;
    }
    // Get a summary of recent earthquakes, including the location and magnitude of each earthquake
    public static string[] EarthquakeDailySummary()
    {
        //source about earthquakes from government website, in GeoJSON format:
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var request = new HttpRequestMessage(HttpMethod.Get, uri);
        using var stream = client.Send(request).Content.ReadAsStream();
        using var reader = new StreamReader(stream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var data = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = new List<string>();

        foreach (var feature in data.features)
        {
            string place = feature.properties.place;
            double mag = feature.properties.mag;

            result.Add($"{place} - Mag {mag}");
        }

        return result.ToArray();
    }
}