namespace WebApplication1
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ValidationHelpers
    {
        public static bool IsValidInput(string input, string allowedSpecialCharacters = "")
        {
            if (string.IsNullOrEmpty(input)) return false;

            var validCharacters = new HashSet<char>(allowedSpecialCharacters);
            return input.All(c => char.IsLetterOrDigit(c) || validCharacters.Contains(c));
        }

        public static string SanitizeInput(string input)
        {
            return Microsoft.AspNetCore.WebUtilities.HtmlEncoder.Default.Encode(input);
        }
    }

}
