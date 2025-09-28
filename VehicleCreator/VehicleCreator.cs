namespace project_3 {
    internal class Program {
        // klasa bazowa
        class Vehicle {
            public string Brand { get; set; }
            public int Year { get; set; }

            public Vehicle() {
                Brand = "N/A";
                Year = 1970;
            }

            public Vehicle(string brand, int year) {
                Brand = brand;
                Year = year;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Brand: {Brand}, Year: {Year}");
            }
        }
        
        // klasa pochodna
        class Car : Vehicle {
            public int NumberOfDoors { get; set; }

            // konstruktor klasy pochodnej
            public Car(string brand, int year, int doors) : base(brand, year) {
                Brand = brand;
                Year = doors;
                NumberOfDoors = doors;
            }

            public void DisplayDetails() {
                Console.WriteLine($"Car has {NumberOfDoors} doors.");
            }
        }
        
        // klasa pochodna
        class Bicycle : Vehicle {
            public bool HasBasket { get; set; }

            public Bicycle(string brand, int year, bool basket) : base(brand, year) {
                HasBasket = basket;
            }

            public void DislayDetails() {
                string basket = HasBasket ? "has basket." : "has no basket.";
                Console.WriteLine($"Bicycle {basket}");
            }
        }

        class Boat : Vehicle {
            // prywatne pola
            private double _length;
            private int _horsepower;

            public double Length
            {
                get
                {
                    return _length;
                }
                set
                {
                    if (value > 0) {
                        _length = value;
                    }
                    else {
                        Console.WriteLine("Boat length must be greater than 0.");
                    }
                }
            }

            public int Horsepower
            {
                get
                {
                    return _horsepower;
                }
                set
                {
                    if (value > 0) {
                        _horsepower = value;
                    }
                    else {
                        Console.WriteLine("Horsepower must be greater than 0.");
                    }
                }
            }

            public void DisplayDetails() {
                Console.WriteLine($"Boat {Brand} is {Length}m long and has {Horsepower}hp.");
            }
        }

        static void Main(string[] args) {
            // Car c1 = new Car
            // {
            //     Brand = "Ford",
            //     Year = 2015,
            //     NumberOfDoors = 4
            // };
            //
            // Bicycle b1 = new Bicycle
            // {
            //     Brand = "Romet",
            //     Year = 2020,
            //     HasBasket = true
            // };

            Car c1 = new Car("Kia", 2025, 4);
            c1.DisplayInfo();
            c1.DisplayDetails();
            Console.WriteLine();

            Bicycle b1 = new Bicycle("Romet", 2000, false);
            b1.DisplayInfo();
            b1.DislayDetails();
            Console.WriteLine();

            Boat boat1 = new Boat()
            {
                Brand = "Yamaha",
                Horsepower = 280,
                Length = 5.25,
                Year = 2013
            };
            boat1.DisplayInfo();
            boat1.DisplayDetails();
        }
    }
}