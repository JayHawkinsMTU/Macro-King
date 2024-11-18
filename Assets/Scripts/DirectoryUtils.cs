using System.Text.RegularExpressions;

public static class DirectoryUtils
{
    /// <summary>
    /// Sanitizes a string to make it a valid directory or file name.
    /// </summary>
    public static string SanitizeToValidName(string inputName)
    {
        // Remove any invalid characters for directory/file names
        string sanitized = Regex.Replace(inputName, @"[<>:""/\\|?*\x00-\x1F]", "");

        // Trim whitespace and reserved trailing characters (e.g., space or dot)
        sanitized = sanitized.Trim().TrimEnd('.');

        // If the name becomes empty or only whitespace, provide a default name
        if (string.IsNullOrWhiteSpace(sanitized))
        {
            sanitized = "Unnamed";
        }

        return sanitized;
    }
}
