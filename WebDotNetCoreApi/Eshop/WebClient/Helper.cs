namespace WebClient
{
    public static class Helper
    {
        public static string RandomString(int len)
        {
            char[] chars = new char[len]; 
            Random random = new Random();
            string pattern = "qwertyuiopasdfghjklzxcvbnm1234567890";
            for (int i = 0; i < len; i++)
            {
                chars[i] = pattern[random.Next(pattern.Length)];
            }
            return string.Join(string.Empty, chars);    
        }
    }
}
