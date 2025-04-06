
using System.ComponentModel;

namespace DapperORMProject
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public User(int id , string name, string email, string password)
        {
            this.ID = id;
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }

        public override string ToString()
        {
            return $"({this.ID}) {this.Name} - {this.Email} - {this.Password}";
        }
    }
}
