using GPACalculatorWeek1.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculatorWeek1.UI
{
    public static class Display
    {
        public static void userInput()
        {

            String[] courseCodes;
            int[] courseUnit;
            int[] scores;



            Console.Write("Enter total number of courses ");
            byte n = byte.Parse(Console.ReadLine());

            courseCodes = new String[n];
            courseUnit = new int[n];
            scores = new int[n];
            bool error = false;
            for (int i = 0; i < n; i++)
            {
                do
                {
                    Console.Write("Enter your courseCode (e.g CSC 101) ");
                    courseCodes[i] = Console.ReadLine();
                    error = false;

                    if (courseCodes[i].Length != 7)
                    {
                        Console.WriteLine("Incorrect course code ! Input your course code once more");
                        error = true;

                    }
                }
                while (error == true);



                Console.Write("Enter your course unit ");
enterUnit:
                string unit = Console.ReadLine();

                int unt;

                if (!int.TryParse(unit, out unt))
                {
                    Console.WriteLine("This is not a number!");
                    goto enterUnit;
                    //Console.WriteLine($"{unit}");
                }

                courseUnit[i] = Convert.ToInt32(unit);

                //Console.WriteLine("Input your courseUnit");
                //var courseUnitAsString = Console.ReadLine();
                //int courseUnit;
                //if (int.TryParse(courseUnitAsString, out courseUnit))
                //    Console.WriteLine($"{courseUnit}");
                //else
                //    Console.WriteLine("This is not a number!");


                //Console.WriteLine("Input your age");
                //var ageAsString = Console.ReadLine();
                //int age;
                //if (int.TryParse(ageAsString, out age))
                //    Console.WriteLine($"Your age is: {age}");
                //else
                //    Console.WriteLine("This is not a number!");




                Console.WriteLine("Enter your score ");
enterScore:
                string _Score = Console.ReadLine();

                int score;

                if (!int.TryParse(_Score, out score))
                {
                    Console.WriteLine("Enter a valid score!");
                    goto enterScore;
                    //Console.WriteLine($"{scores[i]}");

                }


                scores[i] = Convert.ToInt32(_Score);

            }
            var calculator = new calculation(courseCodes, courseUnit, scores, n);

            calculator.calc();

            //Console.WriteLine();
            Console.Clear();
            Console.WriteLine();
            TableGenerator.PrintLine();
            Console.WriteLine();
            TableGenerator.PrintRow("COURSE & CODE", "COURSE UNIT", " GRADE", "GRADE - UNIT", "WEIGHT Pt.", "REMARK");

            for (var i = 0; i < n; i++)
            {
                string[] newRow = new string[6]
                {
                    courseCodes[i],
                    courseUnit[i].ToString(),
                    calculator.grade[i].ToString(),
                    calculator.getGradeUnit(calculator.grade[i].ToString()).ToString(),
                    calculator.getweightPoint(courseUnit[i],calculator.getGradeUnit(calculator.grade[i].ToString())).ToString(),
                    calculator.remark[i].ToString()
                };
                
                TableGenerator.PrintLine();
                TableGenerator.PrintRow(newRow);

            }
            TableGenerator.PrintLine();

            Console.WriteLine($"Total Course Unit Registered is {calculator.totalCourseUnit}");
            Console.WriteLine($"Total Course Unit Passed is {calculator.totalCourseUnitPassed}");
            Console.WriteLine($"Total Weight Point is {calculator.totalWeightPoint}");
            Console.WriteLine($"Your GPA is = {calculator.getGPA(calculator.totalWeightPoint, calculator.totalCourseUnit).ToString("#.00")} to 2 decimal places.");

            //string s = "This is an example to show where to bold the text".Replace(" is ", " <b>is</b> ");
            //Console.WriteLine(s);

            Console.WriteLine("For reference, GPA is calculated as follows:");

            Console.WriteLine(" GPA = (total weight point) / (total course unit);");
            Console.WriteLine("where: (Weight point) = (course unit) * (grade unit)");


        }


    }
}
