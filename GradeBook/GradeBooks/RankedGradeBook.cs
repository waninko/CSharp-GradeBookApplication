﻿
using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
   public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
               
            }
            var test = Students.Count * (0.2);
            var threshold = (int)Math.Ceiling(test);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if(Students.Count >= 5){
                if (grades[threshold - 1] <= averageGrade)
                    return 'A';
                else if (grades[(threshold * 2) - 1] <= averageGrade)
                    return 'B';
                else if (grades[(threshold * 3) - 1] <= averageGrade)
                    return 'C';
                else if (grades[(threshold * 4) - 1] <= averageGrade)
                    return 'D';
                else return 'F';
            }
            return base.GetLetterGrade(averageGrade);
        }
    }
}
