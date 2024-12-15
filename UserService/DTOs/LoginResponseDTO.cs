namespace UserService.DTOs
{
    public class LoginResponseDTO
    {
        public string token { get; set; }
        public UserDTO userInfo { get; set; }
    }
}
