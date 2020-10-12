using System.Collections.Generic;
using HotChocolate;
using ClassroomApp.Model;
using ClassroomApp.Services;

namespace ClassroomApp.Types
{
    public class SharedResolver
    {
        public IEnumerable<Student> GetRStudents(
                    [Parent]Department department,
                    [Service]IClassroomService repository)
        {
            return repository.GetStudents(department.Id);
        }

        public double GetHeight(Unit? unit, [Parent] IPerson person)
        {
            return ConvertToUnit(person.Height, unit);
        }

        private double ConvertToUnit(double length, Unit? unit)
        {
            if (unit == Unit.Foot)
            {
                return length * 3.28084d;
            }
            return length;
        }
    }
}