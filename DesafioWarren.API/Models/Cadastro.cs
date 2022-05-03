namespace DesafioWarren.API.Models
{
    public class Cadastro
    {
        public Cadastro() { }
        public Cadastro(int Id, string fullName, string email, string emailConfirmation, string cpf, string cellphone, DateTime birthdate, bool emailSms, bool whatsapp, string country, string city, string postalcode, string address, int number)
        {
            this.Id = Id;
            this.fullName = fullName;
            this.email = email;
            this.emailConfirmation = emailConfirmation;
            this.cpf = cpf;
            this.cellphone = cellphone;
            this.birthdate = birthdate;
            this.emailSms = emailSms;
            this.whatsapp = whatsapp;
            this.country = country;
            this.city = city;
            this.postalCode = postalcode;
            this.address = address;
            this.number = number;
        }
        public int Id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string emailConfirmation { get; set; }
        public string cpf { get; set; }
        public string cellphone { get; set; }
        public DateTime birthdate { get; set; }
        public bool emailSms { get; set; }
        public bool whatsapp { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string address { get; set; }
        public int number { get; set; }
    }
}
