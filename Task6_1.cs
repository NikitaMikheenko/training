namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Man dasha = new Man("Dasha", "woman", 20, 55f);

            Student nikita = new Student("men");

            Teacher egor = new Teacher("men");

            dasha.ChangeAge(21);

            nikita.AddYearOfStudy(3);

            nikita.IncreaseTheYearOfStudy();
            nikita.ChangeAge(21);

            egor.Appoint("Biology teacher");

            egor.Dismiss();

            egor.ChangeWeight(90.5f);
        } 
    }

    class Man
    {
        string _name, _gender;
        int _age;
        float _weight;

        public Man(string gender)
        {
            _gender = gender;
        }

        public Man(string name, string gender, int age, float weight)
        {
            _name = name;
            _gender = gender;
            _age = age;
            _weight = weight;
        }

        public void ChangeAge(int age)
        {
            _age = age;
        }

        public void ChangeName(string name)
        {
            _name = name;
        }

        public void ChangeWeight(float weight)
        {
            _weight = weight;
        }
    }

    class Student : Man
    {
        int _yearOfStudy;

        public Student(string gender) : base(gender)
        {
        }

        public Student(string name, string gender, int age, float weight, int yearOfStudy) : base(name, gender, age, weight)
        {
            _yearOfStudy = yearOfStudy;
        }

        public void AddYearOfStudy(int yearOfStudy)
        {
            _yearOfStudy = yearOfStudy;
        }

        public void IncreaseTheYearOfStudy()
        {
            _yearOfStudy++;
        }
    }

    class Teacher : Man
    {
        string _position;

        public Teacher(string gender) : base(gender)
        {
        }

        public Teacher(string name, string gender, int age, float weight, string position) : base(name, gender, age, weight)
        {
            _position = position;
        }

        public void Appoint(string position)
        {
            _position = position;
        }

        public void Dismiss()
        {
            _position = "unemployed";
        }
    }
}