namespace Reflection
{
    class StudentFunction
    {
        private Student student;
        public StudentFunction()
        {
            student = new Student
            {
                Name = "Stuart Shepherd",
                University = "University of East London",
                Roll = 1234
            };
        }

        public string GetName()
        {
            return student.Name;
        }

        public string GetUniversity()
        {
            return student.University;
        }

        public int GetRoll()
        {
            return student.Roll;
        }
    }
}