using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace DapperORMProject
{
    public static class User_DAL
    {
        public static IEnumerable<User> GetAllUsers()
        {
            IDbConnection db = new SqlConnection(ConnectionSettings.ConnectionString);

            var SQL = "SELECT * FROM Users";

            IEnumerable<User> AllUsers = Enumerable.Empty<User>();

            try { AllUsers = db.Query<User>(SQL); }
            catch { }    
            
            return (AllUsers.Count() > 0) ? AllUsers : Enumerable.Empty<User>();
        }
        public static int InsertNewUser(User NewUser)
        {
            IDbConnection db = new SqlConnection(ConnectionSettings.ConnectionString);

            var SQL = "INSERT INTO Users (Name , Email , Password) " +
                      "VALUES (@Name , @Email , @Password)  " + 
                      "SELECT CAST(SCOPE_IDENTITY() AS INT) ";

             var Parameters = new 
             {
                 Name =  NewUser.Name ,
                 Email = NewUser.Email , 
                 Password = NewUser.Password
             };

            int NewID = -1;

            try
            {
                NewID = db.Query<int>(SQL, Parameters).Single();
            }
            catch { }

            return NewID;
        }
        public static bool UpdateUser(User user)
        {
            IDbConnection db = new SqlConnection(ConnectionSettings.ConnectionString);

            var SQL =
                " UPDATE Users SET " +
                " Name = @Name , Email = @Email , Password = @Password " +
                " WHERE Id = @Id";

            var Parameters = new 
            { 
                Id = user.ID ,
                Name = user.Name,
                Email = user.Email ,
                Password = user.Password
            };

            int AffectedRows = 0;

            try { AffectedRows = db.Execute(SQL, Parameters); }
            catch { }

            return AffectedRows > 0;
        }
        public static bool DeleteUser(int ID)
        {
            IDbConnection db = new SqlConnection(ConnectionSettings.ConnectionString);

            var SQL = "DELETE FROM Users WHERE Id = @Id";

            var Parameters = new { Id = ID };

            int AffectedRows = 0;

            try { AffectedRows = db.Execute(SQL, Parameters); }
            catch { }

            return AffectedRows > 0;
        }
    }
}
