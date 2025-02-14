namespace WebApplication1
{
    public class TestService
    {
        private readonly AuthService _authService;

        public TestService(AuthService authService)
        {
            _authService = authService;
        }

        public bool TestSqlInjection()
        {
            string maliciousInput = "' OR 1=1 --";
            return _authService.LoginUser(maliciousInput, "password");
        }

        public bool TestXSS()
        {
            string maliciousInput = "<script>alert('XSS')</script>";
            return !ValidationHelpers.IsValidInput(maliciousInput);
        }
    }

}
