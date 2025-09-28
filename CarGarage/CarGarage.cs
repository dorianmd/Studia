
namespace project_1 {
    internal class CarGarage {
        public enum Color {
            Czerwony,
            Zielony,
            Niebieski
        }

        public enum Type {
            Samochód,
            Motor,
            Ciężarówka,
            Suv
        }
        class Vehicle {
            public string Name { get; set; }
            public Color Color { get; set; }
            public double Speed { get; set; }
            public double Fuel { get; set; }
            public List<Type> Type { get; set; }
            public string Extra { get; set; }

            public void ShowData() {
                Console.WriteLine($"Nazwa: {Name}, kolor: {Color}, predkosc: {Speed}, paliwo: {Fuel}, nadwozie: {string.Join(" ,", Type)}\nDodatkowe informacje: {Extra}");
            }
        }

        class Garage {
            public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
            public byte Capacity { get; set; }

            public void AddVehicle(Vehicle vehicle) {
                if (Vehicles.Count() >= Capacity) {
                    Console.WriteLine("Garaż jest pełny!");
                } else if (Vehicles.Contains(vehicle)) {
                    Console.WriteLine($"{vehicle.Type[0]} {vehicle.Name} jest już w garażu.");
                }
                else {
                    Vehicles.Add(vehicle);
                    Console.WriteLine($"Dodano {vehicle.Type[0]} {vehicle.Name} do Garażu");
                }
            }

            public void RemoveVehicle(Vehicle vehicle) {
                if (Vehicles.Contains(vehicle)) {
                    Vehicles.Remove(vehicle);
                    Console.WriteLine($"Usunięto {vehicle.Type[0]} {vehicle.Name} z garażu.");
                }
                else {
                    Console.WriteLine($"{vehicle.Type[0]} {vehicle.Name} nie znajduje się w garażu.");
                }
            }
            public void ShowVehicles() {
                Dictionary<Type, int> vehicleTypes = new Dictionary<Type, int>();

                foreach (Vehicle vehicle in Vehicles) {
                    foreach (var type in vehicle.Type) {
                        if (vehicleTypes.ContainsKey(type)) {
                            vehicleTypes[type]++;
                        }
                        else {
                            vehicleTypes[type] = 1;
                        }
                    }
                }
                foreach (var type in vehicleTypes) {
                    Console.WriteLine($"{type}");
                }
            }
        }
        
        static void Main(string[] args) {
            Vehicle bike1 = new Vehicle();
            bike1.Name = "Yamaha";
            bike1.Type = new List<Type> { Type.Motor };
            Console.Clear();
            // bike1.ShowData();

            Vehicle car1 = new Vehicle() {Name = "Fiat", Color = Color.Niebieski, Speed = 90, Fuel = 69, Type = new List<Type> { Type.Samochód, Type.Suv}, Extra = "Brak OC"};
            // car1.ShowData();
            
            Vehicle car2 = new Vehicle() {Name = "Ford", Color = Color.Niebieski, Speed = 100, Fuel = 69, Type = new List<Type> { Type.Samochód, Type.Suv}, Extra = "Brak OC"};
            
            Garage garage1 = new Garage();
            garage1.Capacity = 2;
            garage1.AddVehicle(car1);
            garage1.AddVehicle(car1);
            garage1.AddVehicle(car2);
            garage1.AddVehicle(bike1);
            // garage1.RemoveVehicle(bike1);
            // garage1.RemoveVehicle(bike1);
            
            garage1.ShowVehicles();
        }
    }
}