using DesafioWarren.API.Models;

namespace DesafioWarren.API.Data
{
    public class Repository : IRepository
    {
        public List<Cadastro> Cadastros { get; set; } = new List<Cadastro>()
        {
            new Cadastro()
            {
                Id = 1,
                fullName = "Leonardo Matheus Morell",
                email = "lmmorell79@gmail.com",
                emailConfirmation = "",
                cpf = "12949249906",
                cellphone = "47 992438398",
                birthdate = DateTime.Parse ("23/05/2006"),
                emailSms = true,
                whatsapp = false,
                country = "Brasil",
                city = "Blumenau",
                postalCode = "740660",
                address = "Rua Bruno Mette",
                number = 2
            }
        };

        public void add(Cadastro Cadastro)
        {
            int lastId = Cadastros.Last().Id;
            Cadastro.Id = lastId + 1;
            Cadastros.Add(Cadastro);
        }

        public void update(Cadastro cadastro, Cadastro cdtUpdated)
        {
            cdtUpdated.Id = cdtUpdated.Id;
            cdtUpdated.fullName = cdtUpdated.fullName;
            cdtUpdated.email = cdtUpdated.email;
            cdtUpdated.emailConfirmation = cdtUpdated.emailConfirmation;
            cdtUpdated.cpf = cdtUpdated.cpf;
            cdtUpdated.emailSms = cdtUpdated.emailSms;
            cdtUpdated.cellphone = cdtUpdated.cellphone;
            cdtUpdated.cellphone = cdtUpdated.cellphone;
            cdtUpdated.country = cdtUpdated.country;
            cdtUpdated.city = cdtUpdated.city;
            cdtUpdated.address = cdtUpdated.address;
            cdtUpdated.postalCode = cdtUpdated.postalCode;
            cdtUpdated.whatsapp = cdtUpdated.whatsapp;

        }

        public void deleteCdt(Cadastro cadastro)
        {
            Cadastros.Remove(cadastro);
        }
    }
}