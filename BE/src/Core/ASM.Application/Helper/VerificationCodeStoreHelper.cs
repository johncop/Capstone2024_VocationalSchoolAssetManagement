namespace ASM.Application.Helper
{
    public class VerificationCodeStoreHelper
    {
        private static readonly Dictionary<string, (string Code, DateTime Expiration)> _verificationCodes = new();

        public static void StoreVerificationCode(string userId, string code)
        {
            _verificationCodes[userId] = (code, DateTime.UtcNow.AddMinutes(15)); // Set expiration for 15 minutes
        }

        public static bool TryGetVerificationCode(string userId, string code, out string? retrievedCode)
        {
            if (_verificationCodes.TryGetValue(userId, out var entry) && entry.Code == code && entry.Expiration > DateTime.UtcNow)
            {
                retrievedCode = entry.Code;
                return true;
            }

            retrievedCode = null;
            return false;
        }

        public static void RemoveVerificationCode(string userId)
        {
            _verificationCodes.Remove(userId);
        }
    }
}
