
namespace SchoolLibValidatorUnitTest
{
    public class TeacherRepository
    {
        private int nextId = 1;
        private List<Teacher> teachers = new List<Teacher>();

        public Teacher AddTeacher(Teacher teacher)
        {
            teacher.Id = nextId++;
            teachers.Add(teacher);
            return teacher;
        }

        public List<Teacher> Get()
        {
            //List<Teacher> newTeachers = teachers;
            //return newTeachers;
            return new List<Teacher>( teachers );
        }

        public Teacher? Get(int id)
        {
            return teachers.FirstOrDefault(t => t.Id == id);
        }

        public Teacher? Delete(int id)
        {
            Teacher? teacher = Get(id);
            if (teacher == null)
            {
                return null;
            }

            teachers.Remove(teacher);
            return teacher;
        }

        public Teacher Update(int id, Teacher data)
        {
            Teacher? existingTeacher = Get(id);
            if (existingTeacher == null)
            {
                return null;
            }

            existingTeacher.Name = data.Name;
            existingTeacher.Salary = data.Salary;
            return existingTeacher;
        }


    }
}
