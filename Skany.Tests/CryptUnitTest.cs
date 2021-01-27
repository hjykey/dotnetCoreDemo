using System;
using Xunit;

namespace Skany.Tests
{
    using Core;

    public class CryptUnitTest
    {
        [Theory]
        [InlineData("zhang")]
        [InlineData("baidu")]
        public void HashPasswordTest(string password)
        {
            string salt;
            var hashPassword = CryptHelper.HashPassword(password, out salt);
            Assert.NotNull(hashPassword);
            Assert.NotNull(salt);
            Assert.True(hashPassword.Length == CryptHelper.HashLength);
            Assert.True(salt.Length == CryptHelper.SaltLength);
            VerifyPasswordTest(password, hashPassword, salt);
        }

        [Theory]
        [InlineData("zhang", "ÁēÕĀ1fv¾ĒëÜĝ}f§¼kÈ$Æ7KĎĞĐMĬZĝČ9ËÅ«¢ÝĪÙØê£İ)¥jµQIįa", "ïÛŀB³äĭonÊ")]
        [InlineData("baidu", " g©®Ģ¹Óäõ¥ģH»7ċuO¸%AOĮ©ĩ§8ĆKĄöĉĖß$µåË¬üÖ=ĝĴ¶Cę¨§h/", "ĀĖ§į^H7Í_h")]
        public void VerifyPasswordTest(string password, string hashPassword, string salt)
        {
            Assert.True(hashPassword.Length == CryptHelper.HashLength);
            Assert.True(salt.Length == CryptHelper.SaltLength);
            Assert.True(CryptHelper.VerifyPassword(password, hashPassword, salt));
        }
    }
}