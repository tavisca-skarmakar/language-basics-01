using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {

            // spilting the given equation string
            string A = equation.Split('*')[0];
            string B = equation.Split('*')[1].Split('=')[0];
            string C = equation.Split('=')[1];

            //checking if A,B,C are integer type or not
            bool flag_A = int.TryParse(A, out int int_A);
            bool flag_B = int.TryParse(B, out int int_B);
            bool flag_C = int.TryParse(C, out int int_C);

            if (!flag_A)
            {
                string op = "" + int.Parse(C) / int.Parse(B);

                if (op.Length != A.Length) return -1;
                if (int.Parse(C) % int.Parse(B) != 0) return -1;

                return Digit(op, A);
            }
            else if (!flag_B)
            {
                string op = "" + int.Parse(C) / int.Parse(A);

                if (op.Length != B.Length) return -1;
                if (int.Parse(C) % int.Parse(A) != 0) return -1;

                return Digit(op, B);
            }
            else if (!flag_C)
            {
                string op = "" + int.Parse(A) * int.Parse(B);

                if (op.Length != C.Length) return -1;
                if (int.Parse(A) * int.Parse(B) != int.Parse(op)) return -1;

                return Digit(op, C);
            }

            return -1;
        }

        public static int Digit(string op, string compare)
        {
            for (int i = 0; i < op.Length; i++)
            {
                if (op[i] != compare[i] && compare[i] == '?') return (int)(op[i] - '0');
            }
            return -1;
        }
    }
}
