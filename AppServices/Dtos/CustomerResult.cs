namespace Application.Dtos
{
    public class CustomerResult
    {
        public string Fullname { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }
    }
}