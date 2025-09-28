namespace project_2 {
    internal class Program {
        enum FavColor {
            Czerwony,
            Czarny,
            Niebieski
        }
            
        class Person {
            // pola prywatne
            private string _name;
            private byte _age;
            private int _birthYear;

            public int BirthYear
            {
                get { return DateTime.Now.Year - Age; }
                private set
                {
                    _birthYear = value;
                }
            }
            
            // właściwości publiczne z walidacją
            public string Name
            {
                get { return _name; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value)) {
                        Console.WriteLine("Error: Name cannot be empty. Setting default value (N/A).");
                        _name = "N/A";
                    }
                    else {
                        _name = value;
                    }
                }
            }
            public byte Age
            {
                get { return _age; }
                set
                {
                    if (value is < 0 or > 140) {
                        Console.WriteLine($"Error: Age must be within 0-140. Setting default value (0).");
                        _age = 0;
                    }
                    else {
                        _age = value;
                    }
                } 
            }
            public FavColor Color { get; set; }
            
            // konstruktor domyślny
            public Person() {
                Name = _name;
                Age = 0;
                Console.WriteLine("Name and age not provided, using default constructor.");
            }
            
            // konstruktor parametryczny
            public Person(string name) {
                Name = name;
            }
            
            public Person(string name, byte age) : this(name) {
                Age = age;
                Console.WriteLine("Constructor with 2 parameters.");
            }

            public Person(string name, byte age, FavColor color) : this(name, age) {
                Color = color;
                Console.WriteLine("Constructor with 3 parameters.");
            }

            public Person(Person otherPerson) {
                Name = otherPerson.Name;
                Age = otherPerson.Age;
                Color = otherPerson.Color;
                Console.WriteLine("Called copy constructor.");
            }

            public void Info() {
                Console.WriteLine($"Name: {Name}, Age: {Age}, Color: {Color}, Year of birth: {BirthYear}\n");
            }
        }

        static void Main(string[] args) {
            Person p1 = new Person();
            p1.Info();

            Person p2 = new Person("Jakub");

            Person p3 = new Person("Andrzej", 120);
            p3.Info();

            Person p4 = new Person("Ania", 225, FavColor.Niebieski);
            p4.Info();

            Person p5 = new Person(p4);
            p5.Info();
        }
    }
}