using System.Linq;
using System.Text;

namespace Lb_03
{
    public class RabinKarpSearcher
    {
        public string Search(string text, string word)
        {
            int n = text.Length;
            int m = word.Length;
            int hashText = Hash(text);
            int hashWord = Hash(word);

            string currentSegment = text.Substring(0, m);
            for (int i = 0; i < n - m; i++)
            {
                if (hashText == hashWord)
                    if (currentSegment == word)
                        return currentSegment;

                currentSegment = text.Substring(i + 1, m);
                hashText = Hash(currentSegment);
            }

            return string.Empty;

        }

        private int Hash(string text)
        {            
            return text.GetHashCode();
        }
    }
}
