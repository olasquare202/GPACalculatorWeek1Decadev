using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculatorWeek1.Core
{
    public class calculation
    {
        private String[] courseCodes;
        private int[] courseUnit;
        private int[] scores;
        public ArrayList grade = new ArrayList();
        public ArrayList remark = new ArrayList();
        public ArrayList weightPoint = new ArrayList();
        public int totalCourseUnit = 0;
        public int totalWeightPoint = 0;
        public int totalCourseUnitPassed = 0;
        private int n;
        //(Weight point) = (course unit)* (grade unit);

        //Constructor
        public calculation(String[] courseCodes, int[] courseUnit, int[] scores, int n)
        {
            this.courseCodes = courseCodes;
            this.courseUnit = courseUnit;
            this.scores = scores;
            this.n = n;

        }

        public int getGradeUnit(string gradeUnit)
        {
            switch (gradeUnit)
            {
                case "A":
                    return 5;

                case "B":
                    return 4;

                case "C":
                    return 3;

                case "D":
                    return 2;

                case "E":
                    return 1;

                case "F":
                    return 0;

                default:
                    return 0;


            }
        }

        public int getweightPoint(int courseUnit, int gradePoint)
        {
            return courseUnit * gradePoint;
        }

        public decimal getGPA(int totalWeightPoint, int totalCourseUnit)
        {
            decimal result = Convert.ToDecimal(totalWeightPoint) / Convert.ToDecimal(totalCourseUnit);
            //Console.WriteL
            return result;

        }



        public void calc()
        {


            for (int x = 0; x < n; x++)
            {
                totalCourseUnit = totalCourseUnit + courseUnit[x];

                int y = Convert.ToInt32(scores[x]);
                if (y >= 70)
                {
                    grade.Add("A");
                    totalWeightPoint = totalWeightPoint + (getGradeUnit("A") * courseUnit[x]);
                    remark.Add("Excellence");
                    totalCourseUnitPassed = totalCourseUnitPassed + courseUnit[x];
                }

                else if (y >= 60)
                {
                    grade.Add("B");
                    remark.Add("Very Good");
                    totalWeightPoint = totalWeightPoint + (getGradeUnit("B") * courseUnit[x]);
                    totalCourseUnitPassed = totalCourseUnitPassed + courseUnit[x];

                }

                else if (y >= 50)
                {
                    grade.Add("C");
                    remark.Add("Good");
                    totalWeightPoint = totalWeightPoint + (getGradeUnit("C") * courseUnit[x]);
                    totalCourseUnitPassed = totalCourseUnitPassed + courseUnit[x];
                }

                else if (y >= 40)
                {
                    grade.Add("D");
                    remark.Add("Fair");
                    totalWeightPoint = totalWeightPoint + (getGradeUnit("D") * courseUnit[x]);
                    totalCourseUnitPassed = totalCourseUnitPassed + courseUnit[x];
                }

                else
                {
                    grade.Add("F");
                    remark.Add("Fail");
                    totalWeightPoint = totalWeightPoint + (getGradeUnit("F") * courseUnit[x]);
                }


            }
        }
    }

}
