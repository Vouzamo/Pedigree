using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Pedigree.Common.Models;
using Pedigree.Importer.Infrastructure;

namespace Pedigree.Importer
{
    public class Program
    {
        public const string MySqlConnectionString = "<< CONNECTION STRING >>";

        public static Dictionary<int, Title> Titles { get; set; }
        public static Dictionary<int, CoatColor> Colors { get; set; }
        public static Dictionary<int, Dog> Dogs { get; set; }
        public static Dictionary<int, Person> People { get; set; }

        public static void Main(string[] args)
        {
            Titles = new Dictionary<int, Title>();
            Colors = new Dictionary<int, CoatColor>();
            Dogs = new Dictionary<int, Dog>();
            People = new Dictionary<int, Person>();

            using (var db = new AppDbContext())
            {
                FetchAll(db);
            }

            Console.Write("Press any key to exit: ");
            Console.ReadKey();
        }

        public static void FetchAll(AppDbContext db)
        {
            var connection = new MySqlConnection(MySqlConnectionString);
            connection.Open();

            MySqlCommand command = new MySqlCommand("SELECT * FROM tblDogs;", connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProcessDog(db, reader);
                }
            }

            connection.Close();
        }

        public static Guid FetchTitle(AppDbContext db, int id)
        {
            Guid generatedId;

            if (!Titles.ContainsKey(id))
            {
                var connection = new MySqlConnection(MySqlConnectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand($"SELECT * FROM tblTitles where id = '{id}';", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var title = new Title((string)reader["title"], (string)reader["short"]);

                        db.Add(title);
                        db.SaveChanges();

                        Titles.Add(id, title);

                        generatedId = title.Id;

                        break;
                    }
                }

                connection.Close();
            }
            else
            {
                generatedId = Titles[id].Id;
            }

            return generatedId;
        }

        public static Guid FetchColor(AppDbContext db, int id)
        {
            Guid generatedId;

            if (!Colors.ContainsKey(id))
            {
                var connection = new MySqlConnection(MySqlConnectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand($"SELECT * FROM tblColours where id = '{id}';", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var color = new CoatColor((string)reader["colour"]);

                        db.Add(color);
                        db.SaveChanges();

                        Colors.Add(id, color);

                        generatedId = color.Id;

                        break;
                    }
                }

                connection.Close();
            }
            else
            {
                generatedId = Colors[id].Id;
            }

            return generatedId;
        }

        public static Guid FetchDog(AppDbContext db, int id)
        {
            Guid generatedId;

            if(!Dogs.ContainsKey(id))
            {
                var connection = new MySqlConnection(MySqlConnectionString);
                connection.Open();

                MySqlCommand command = new MySqlCommand($"SELECT * FROM tblDogs where id = '{id}';", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        generatedId = ProcessDog(db, reader);
                        break;
                    }
                }

                connection.Close();
            }
            else
            {
                generatedId = Dogs[id].Id;
            }

            return generatedId;
        }

        public static Guid FetchPerson(AppDbContext db, int id)
        {
            Guid generatedId;

            if (!People.ContainsKey(id))
            {
                Person person;

                if(id == 4)
                {
                    person = new Person("John Halstead");
                }
                else
                {
                    person = new Person("Sandra Halstead");
                }

                db.Add(person);
                db.SaveChanges();

                People.Add(id, person);

                generatedId = person.Id;
            }
            else
            {
                generatedId = People[id].Id;
            }

            return generatedId;
        }

        public static Guid ProcessDog(AppDbContext db, MySqlDataReader reader)
        {
            var id = Convert.ToInt32((long)reader["id"]);

            if(!Dogs.ContainsKey(id))
            {
                Console.WriteLine($"Mapping dog {id} for first time");

                var name = (string)reader["name"];

                var title = Convert.ToInt32((long)reader["title"]);
                //var breed = Convert.ToInt32((long)reader["breed"]);
                var sex = Convert.ToInt32((bool)reader["sex"]);
                var colour = Convert.ToInt32((long)reader["colour"]);

                var registration = (string)reader["registration"];
                var stud = (string)reader["stud"];

                var hip = (string)reader["hip"];
                var elbow = (string)reader["elbow"];
                var eye = (string)reader["eye"];
                var gpra = (string)reader["gpra"];
                var cnm = (string)reader["cnm"];
                var dob = (string)reader["dob"];

                var owner = Convert.ToInt32((long)reader["owner"]);
                var breeder = Convert.ToInt32((long)reader["breeder"]);

                var sire = Convert.ToInt32((long)reader["sire"]);
                var dam = Convert.ToInt32((long)reader["dam"]);

                // Create new dog
                var dog = new Dog(name, DetermineSex(sex));

                if(title > 0)
                {
                    dog.TitleId = FetchTitle(db, title);
                }

                if(colour > 0)
                {
                    dog.CoatColorId = FetchColor(db, colour);
                }

                dog.RegistrationNumber = registration;
                dog.StudNumber = stud;

                dog.HipScore = hip;
                dog.ElbowScore = elbow;
                dog.EyeCertificate = eye;
                dog.GPRA = gpra;
                dog.CNM = cnm;

                if(!string.IsNullOrEmpty(dob))
                {
                    DateTime parsedDateOfBirth;

                    if(DateTime.TryParse(dob, out parsedDateOfBirth))
                    {
                        dog.DateOfBirth = parsedDateOfBirth;
                    }
                }
                

                if(owner > 0)
                {
                    dog.OwnerId = FetchPerson(db, owner);
                }

                if(breeder > 0)
                {
                    dog.PersonId = FetchPerson(db, breeder);
                }

                if(sire > 0)
                {
                    Console.WriteLine($"- found sire with id {sire}");
                    dog.SireId = FetchDog(db, sire);
                }

                if(dam > 0)
                {
                    Console.WriteLine($"- found dam with id {dam}");
                    dog.DamId = FetchDog(db, dam);
                }

                // Import it
                db.Add(dog);
                db.SaveChanges();

                // Save mapping
                Dogs.Add(id, dog);
            }

            return Dogs[id].Id;
        }

        public static Sex DetermineSex(int sex)
        {
            if(sex == 0)
            {
                return Sex.Dog;
            }

            if(sex == 1)
            {
                return Sex.Bitch;
            }

            return Sex.Unknown;
        }
    }
}
