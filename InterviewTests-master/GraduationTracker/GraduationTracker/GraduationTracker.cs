using GraduationTracker.Models;
using GraduationTracker.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker
{
    public partial class GraduationTracker
    {
       private IRepository _repository;
        public GraduationTracker(IRepository repository)
        {
            _repository = repository;
        }

        public Tuple<bool, STANDING>  HasGraduated(Diploma diploma, Student student)
        {
            var credits = 0;
            int sumOfMarks = 0;
            var requirementsForDiploma = diploma.Requirements;
            Dictionary<int, int> CoursesIDCreaditToPassList = new Dictionary<int, int>();
            foreach (var requiredId in requirementsForDiploma)
            {
                CoursesIDCreaditToPassList.Add(_repository.GetRequirement(requiredId).Courses[0], _repository.GetRequirement(requiredId).Credits);
            }

            List<int> CourseIDStudendHasPassed = new List<int>();
            foreach (var course in student.Courses)
            {
                CourseIDStudendHasPassed.Add(course.Id);
                sumOfMarks+=course.Mark ;
                credits += CoursesIDCreaditToPassList.FirstOrDefault(x=>x.Key ==course.Id).Value;
            }

            if (CourseIDStudendHasPassed.All(CoursesIDCreaditToPassList.Keys.ToList().Contains)
                && credits == diploma.Credits)
            {
              return  CalculateAverage(sumOfMarks, student.Courses.Length);
            }

            else
                return new Tuple<bool, STANDING>(false, STANDING.Remedial);

        }

        public Tuple<bool, STANDING> CalculateAverage(int sum, int courseCount)
        {
            int average = sum / courseCount;
            switch (average)
            {
                case var expression when average < 50:
                    return new Tuple<bool, STANDING>(false, STANDING.Remedial);
                case var expression when 50 <= average && average < 80:
                    return new Tuple<bool, STANDING>(true, STANDING.Average);
                case var expression when 80 <= average && average < 95:
                    return new Tuple<bool, STANDING>(true, STANDING.MagnaCumLaude);
                default:
                    return new Tuple<bool, STANDING>(true, STANDING.SumaCumLaude);

            }
        }
    }
}
