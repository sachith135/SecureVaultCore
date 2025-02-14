namespace WebApplication1
{

    using System.Data.SqlClient;

    public class AuthService
    {
        private readonly string _connectionString;

        public AuthService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool LoginUser(string username, string password)
        {
            const string allowedSpecialCharacters = "@#$%&*!";
            if (!ValidationHelpers.IsValidInput(username) || !ValidationHelpers.IsValidInput(password, allowedSpecialCharacters))
            {
                return false;
            }

            using var connection = new SqlConnection(_connectionString);
            const string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND PasswordHash = @Password";
            using var command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);

            connection.Open();
            var result = (int)command.ExecuteScalar();
            return result > 0;
        }
    }

}
