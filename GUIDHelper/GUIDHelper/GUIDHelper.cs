// Ignore Spelling: Validator

using System.Text.RegularExpressions;

namespace GUIDHelper
{
    public partial class GUIDHelper
    {
        [GeneratedRegex("^[0-9A-Fa-f]{8}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{4}-[0-9A-Fa-f]{12}$")]
        private static partial Regex GuidValidatorRegex();

        public static bool ValidateWithRegex(string input)
        {
            return GuidValidatorRegex().IsMatch(input);
        }
    }
}
