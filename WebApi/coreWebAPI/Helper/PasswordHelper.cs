namespace coreWebAPI.Helper
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class PasswordHelper
    {
        private static readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        public static string HashPassword(string password)
        {
            // Hash the password using the PasswordHasher
            return _passwordHasher.HashPassword(null, password);  // The first argument is an arbitrary user object.
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            // Verify the entered password against the stored hash
            var result = _passwordHasher.VerifyHashedPassword(null, storedHash, password);

            // PasswordVerificationResult.Success means the password is correct
            return result == PasswordVerificationResult.Success;
        }
    }

}
