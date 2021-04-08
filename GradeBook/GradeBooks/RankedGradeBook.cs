using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook (string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("You must have at least 5 students to do ranked grading.");
            }

            var section = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[section - 1])
                return 'A';
            if (averageGrade >= grades[(section * 2)- 1])
                return 'B';
            if (averageGrade >= grades[(section * 3) - 1])
                return 'C';
            if (averageGrade >= grades[(section * 4) - 1])
                return 'D';
            return 'F';
        }

    }
}
