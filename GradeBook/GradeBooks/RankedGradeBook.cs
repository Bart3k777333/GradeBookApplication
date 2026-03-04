using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks;

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
            throw new InvalidOperationException();
        }

        int students20Percent = Students.Count / 5;

        int higherGradesCount = Students.Count(s => s.AverageGrade >  averageGrade);

        if (higherGradesCount < students20Percent) return 'A';
        if (higherGradesCount < students20Percent * 2) return 'B';
        if (higherGradesCount < students20Percent * 3) return 'C';
        if (higherGradesCount < students20Percent * 4) return 'D';

        return 'F';
    }
}