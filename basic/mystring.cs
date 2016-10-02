using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic
{
    class mystring
    {
        public static void test()
        {
            #region $@ string test
            //var name = "Dave";
            //Console.WriteLine("My name is {name}");
            //Console.WriteLine($"My name is {name}");
            //Console.WriteLine(@"My name is \{name}");
            //Console.WriteLine(@"test\ntest");
            //Console.WriteLine(@"test
            //test");
            #endregion

            string mySecretName = String.Empty;
            // '' char
            // "" string

            //String.Compare function

            int figure;
            if (Int32.TryParse("32", out figure)) Console.WriteLine("convering success");
            Console.WriteLine(figure);
            if (!Int32.TryParse("32a", out figure)) Console.WriteLine("convering failed");
            Console.WriteLine(figure);

            Console.Write(@"{0:C} of 1.56 : "); Console.WriteLine("{0:C}", 1.56);
            Console.Write(@"{0:D5} of 123 : "); Console.WriteLine("{0:D5}", 123);
            Console.Write(@"{0:E} of 1.56 : "); Console.WriteLine("{0:E}", 1.56);
            Console.Write(@"{0:F1} of 1.56 : "); Console.WriteLine("{0:F1}", 1.56);
            Console.Write(@"{0:N1} of 1.56 : "); Console.WriteLine("{0:N1}", 1.56);
            Console.Write(@"{0:N0} of 1.56 : "); Console.WriteLine("{0:N0}", 1.56);
            Console.Write(@"{0:N} of 1.234 : "); Console.WriteLine("{0:N}", 1.234);
            Console.Write(@"{0:X} of 123 : "); Console.WriteLine("{0:X}", 123);
            Console.Write(@"{0:000.00} of 12.3 : "); Console.WriteLine("{0:000.00}", 12.3);
            Console.Write(@"{0:##0.0#} of 0 : "); Console.WriteLine("{0:##0.0#}", 0);
            Console.Write(@"{0:#00.#%} of .1234 : "); Console.WriteLine("{0:#00.#%}", .1234);

            //StringBuilder를 사용하면 string의 immutability로 인한 string copy를 최소화할 수 있다.
            //string은 엄청 시간 걸림
            int stringSize = 10000;
            var timer=new Stopwatch();
            timer.Start();
            var list = Enumerable.Range(0, stringSize).ToList();
            timer.Stop();
            Console.WriteLine("list enumeration:{0}",timer.Elapsed.TotalSeconds);
            //list.ForEach(Console.WriteLine);
            timer.Restart();
            var listOfNames = list.Select(x => x.ToString()).ToArray();
            //Console.WriteLine(string.Join(",",listOfNames));
            timer.Stop();
            Console.WriteLine("list to array:{0}", timer.Elapsed.TotalSeconds);

            timer.Restart();
            var s = string.Empty;
            for (int i = 0; i < stringSize; i++)
            { s += listOfNames[i]; }
            timer.Stop();
            Console.WriteLine("using string:{0}", timer.Elapsed.TotalSeconds);

            timer.Restart();
            StringBuilder sb = new StringBuilder(short.MaxValue);  // Allocate a bunch.
            for (int i = 0; i < 1000; i++)
            {
                sb.Append(listOfNames[i]);    // Same list of names as earlier 
            }
            string result = sb.ToString();  // Retrieve the results.
            timer.Stop();
            Console.WriteLine("using stringbuilder:{0}", timer.Elapsed.TotalSeconds);

        }

        public static void AlighOutput()
        {
            List<string> names = new List<string> {"Christa  ",
                                             "  Sarah",
                                             "Jonathan",
                                             "Sam",
                                             " Schmekowitz "};

            // First output the names as they start out.
            Console.WriteLine("The following names are of "
                              + "different lengths");

            foreach (string s in names)
            {
                Console.WriteLine("This is the name '" + s + "' before");
            }
            Console.WriteLine();

            // This time, fix the strings so they are
            // left justified and all the same length.

            // First, copy the source array into an array that you can manipulate.
            List<string> stringsToAlign = new List<string>();

            // At the same time, remove any unnecessary spaces from either end
            // of the names.
            for (int i = 0; i < names.Count; i++)
            {
                string trimmedName = names[i].Trim();
                stringsToAlign.Add(trimmedName);
            }

            // Now find the length of the longest string so that
            // all other strings line up with that string.
            int maxLength = 0;
            foreach (string s in stringsToAlign)
            {
                if (s.Length > maxLength)
                {
                    maxLength = s.Length;
                }
            }

            // Now justify all the strings to the length of the maximum string.
            for (int i = 0; i < stringsToAlign.Count; i++)
            {
                stringsToAlign[i] = stringsToAlign[i].PadRight(maxLength + 1);
            }

            // Finally output the resulting padded, justified strings.
            Console.WriteLine("The following are the same names "
                            + "normalized to the same length");
            foreach (string s in stringsToAlign)
            {
                Console.WriteLine("This is the name '" + s + "' afterwards");
            }

            // Wait for user to acknowledge.
            Console.WriteLine("\nPress Enter to terminate...");
            Console.Read();
        }
        public static void BuildSentence()
        {
            Console.WriteLine("Each line you enter will be "
                      + "added to a sentence until you "
                      + "enter EXIT or QUIT");
            // Ask the user for input; continue concatenating
            // the phrases input until the user enters exit or
            // quit (start with an empty sentence).
            string sentence = "";
            for (;;)
            {
                // Get the next line.
                Console.WriteLine("Enter a string ");
                string line = Console.ReadLine();
                // Exit the loop if line is a terminator.
                string[] terms = { "EXIT", "exit", "QUIT", "quit" };
                // Compare the string entered to each of the
                // legal exit commands.
                bool quitting = false;
                //foreach (string term in terms)
                //{
                //    // Break out of the for loop if you have a match.
                //    if (String.Compare(line, term) == 0)
                //    {
                //        quitting = true;
                //    }
                //}
                foreach (string term in terms)
                {          // Break out of the for loop if you have a match.       
                    if ((String.Compare("exit", line, true) == 0) || (String.Compare("quit", line, true) == 0))
                    { quitting = true; }
                }
                if (quitting == true)
                {
                    break;
                }
                // Otherwise, add it to the sentence.
                sentence = String.Concat(sentence, line);
                // Let the user know how she's doing.
                Console.WriteLine("\nyou've entered: " + sentence);
            }
            Console.WriteLine("\ntotal sentence:\n" + sentence);
            // Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }

        public static void IsAllDigit()
        {
            // Input a string from the keyboard.
            Console.WriteLine("Enter an integer number");
            string s = Console.ReadLine();

            // First check to see if this could be a number.
            if (!IsAllDigits(s)) // Call our special method.
            {
                Console.WriteLine("Hey! That isn't a number");
            }
            else
            {
                // Convert the string into an integer.
                int n = Int32.Parse(s);

                // Now write out the number times 2.
                Console.WriteLine("2 * " + n + ", = " + (2 * n));
            }
            // Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
        // IsAllDigits - Return true if all of the characters
        //    in the string are digits.
        public static bool IsAllDigits(string raw)
        {
            // First get rid of any benign characters
            // at either end; if there's nothing left
            // then we don't have a number.
            string s = raw.Trim();  // Ignore whitespace on either side.
            if (s.Length == 0)
            {
                return false;
            }

            // Loop through the string.
            for (int index = 0; index < s.Length; index++)
            {
                // A non-digit indicates that the string
                // is probably not a number.
                if (Char.IsDigit(s[index]) == false)
                {
                    return false;
                }
            }

            // No non-digits found; it's probably OK.
            return true;
        }
        public static void OutputForamt()
        {
            // Keep looping - inputting numbers until the user
            // enters a blank line rather than a number.
            for (;;)
            {
                // First input a number - terminate when the user
                // inputs nothing but a blank line.
                Console.WriteLine("Enter a double number");
                string numberInput = Console.ReadLine();
                if (numberInput.Length == 0)
                {
                    break;
                }
                double number = Double.Parse(numberInput);

                // Now input the specifier codes; split them
                // using spaces as dividers.
                Console.WriteLine("Enter the format specifiers"
                                  + " separated by a blank "
                                  + "(Example: C E F1 N0 0000000.00000)");
                char[] separator = { ' ' };
                string formatString = Console.ReadLine();
                string[] formats = formatString.Split(separator);

                // Loop through the list of format specifiers.
                foreach (string s in formats)
                {
                    if (s.Length != 0)
                    {
                        // Create a complete format specifier
                        // from the letters entered earlier.
                        string formatCommand = "{0:" + s + "}";

                        // Output the number entered using the
                        // reconstructed format specifier.
                        Console.Write(
                              "The format specifier {0} results in ", formatCommand);
                        try
                        {
                            Console.WriteLine(formatCommand, number);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("<illegal control>");
                        }
                        Console.WriteLine();
                    }
                }
            }

            // Wait for user to acknowledge.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
        public static void ParseOutput()
        {
            // Prompt the user to input a sequence of numbers.
            Console.WriteLine(
                 "Input a series of numbers separated by commas:");

            // Read a line of text.
            string input = Console.ReadLine();
            Console.WriteLine();

            // Now convert the line into individual segments
            // based upon either commas or spaces.
            char[] dividers = { ',', ' ' };
            string[] segments = input.Split(dividers);

            // Convert each segment into a number.
            int sum = 0;
            foreach (string s in segments)
            {
                // Skip any empty segments.
                if (s.Length > 0)
                {
                    // Skip strings that aren't numbers.
                    if (IsAllDigits(s))
                    {
                        // Convert the string into a 32-bit int.
                        int num = 0;
                        if (Int32.TryParse(s, out num))
                        {
                            Console.WriteLine("Next number = {0}", num);
                            // Add this number into the sum.
                            sum += num;
                        }
                        // If parse fails, move on to next number.
                    }
                }
            }

            // Output the sum.
            Console.WriteLine("Sum = {0}", sum);

            // Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
        public static void RemoveWhite()
        {
            // Define the white space characters.
            char[] whiteSpace = { ' ', '\n', '\t' };

            // Start with a string embedded with whitespace.
            string s = " this is a\nstring"; // Contains spaces & newline.
            Console.WriteLine("before:" + s);

            // Output the string with the whitespace missing.
            Console.Write("after:");

            // Start looking for the white space characters.
            for (;;)
            {
                // Find the offset of the character; exit the loop
                // if there are no more.
                int offset = s.IndexOfAny(whiteSpace);
                if (offset == -1)
                {
                    break;
                }

                // Break the string into the part prior to the
                // character and the part after the character.
                string before = s.Substring(0, offset);
                string after = s.Substring(offset + 1);

                // Now put the two substrings back together with the
                // character in the middle missing.
                s = String.Concat(before, after);
                // Loop back up to find next whitespace char in 
                // this modified s.
            }
            Console.WriteLine(s);

            // Wait for user to acknowledge the results.
            Console.WriteLine("Press Enter to terminate...");
            Console.Read();
        }
    }
}
