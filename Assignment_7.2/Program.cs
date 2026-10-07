using System.Text;

namespace Assignment_7._2
{
    internal class Program
    {

        static int[] RandomIntArray()
        {
            Random random = new Random();

            int size = random.Next(5, 10);
            int[] newArray = new int[size];

            for (int i = 0; i < size; i++)
            {
                int newValue = random.Next(0,999);
                while (newArray.Contains(newValue))
                {
                    newValue = random.Next(0, 999);
                }

                newArray [i] = newValue;
            }

            return newArray;
        }

        static void Divide(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                Console.WriteLine($"Left: {left}, Mid: {mid}, Right:{right}");

                Divide(arr, left, mid);

                Console.WriteLine($"Left: {left}, Mid: {mid}");
                Divide(arr, mid + 1, right);

                Console.WriteLine($"Mid: {mid}, Right:{right}");
                Merge(arr, left, mid, right);

                Console.WriteLine($"Left: {left}, Mid: {mid}, Right:{right}");
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int[] temp = new int[right + 1];
            int k = left;

            while (i <= mid && j <= right)
            {
                if (arr[i] < arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }

            while (i <= mid)
            {
                temp[k] = arr[i];
                k++;
                i++;
            }

            while (j <= right)
            {
                temp[k] = arr[j];
                k++;
                j++;
            }

            for(int x = left; x <= right; x++)
            {
                arr[x] = temp[x];
            }

            Console.Write("\nTemp ");
            PrintArray(temp);
            Console.WriteLine();
        }

        static void PrintArray(int[] array)
        {
            Console.Write("Array: ");
            foreach(var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        static string VowelChange(string word)
        {
            if (word.Length <= 1) return "";

            List<char> vowel = new List<char> { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U', 'y', 'Y' };
            int leftIndex = -1, rightIndex = -1;

            char[] newWord = word.ToCharArray();
            int left = 0, right = word.Length - 1;
            while(left <= right)
            {
                while(leftIndex == -1)
                {
                    if (vowel.Contains(word[left]))
                    {
                        leftIndex = left++;
                    }
                    left++;
                }

                while(rightIndex == -1)
                {
                    if (vowel.Contains(word[right]))
                    {
                        rightIndex = right++;
                    }
                    right--;
                }

                if (leftIndex != -1 && rightIndex != -1) 
                {
                    char temp = newWord[leftIndex];
                    newWord[leftIndex] = newWord[rightIndex];
                    newWord[rightIndex] = temp;

                    leftIndex = -1; 
                    rightIndex = -1;
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach (char ch in newWord)
            {
                sb.Append(ch);
            }

            return sb.ToString();
        }

        static bool Anagram(string word, string target)
        {
            List<char> words = word.ToCharArray().ToList();
            List<char> targets = target.ToCharArray().ToList();

            foreach (char ch in target)
            {
                if (!words.Contains(ch) || target.Length > word.Length) return false;
            }

            return true;
        }


        static void MergeSort()
        {
            int[] array = RandomIntArray();

            Console.WriteLine("Merge Sort Method");

            PrintArray(array);
            Console.WriteLine();

            Divide(array, 0, array.Length - 1);

            Console.Write("\nFinal ");
            PrintArray(array);
        }

        static void StringChangeVowels()
        {
            Console.WriteLine("\n\nString Change Vowels Method:\n ");

            string word = VowelChange("hello");
            Console.WriteLine($"{word}");

            string word2 = VowelChange("avacado");
            Console.WriteLine($"{word2}");

            string word3 = VowelChange("intelligent");
            Console.WriteLine($"{word3}");
        }

        static void AnagramMethod()
        {
            string word1 = "anagram", word2 = "rat";
            string target1 = "nagaram", target2 = "cat";

            Console.WriteLine("\n\nAnagram Method");
            Console.WriteLine($"s = {word1}, t = {target1} is {Anagram(word1, target1)}");
            Console.WriteLine($"s = {word2}, t = {target2} is {Anagram(word2, target2)}");
        }

        static void Print()
        {
            MergeSort();

            StringChangeVowels();

            AnagramMethod();
        }


        static void Main(string[] args)
        {
            Print();
        }
    }
}
