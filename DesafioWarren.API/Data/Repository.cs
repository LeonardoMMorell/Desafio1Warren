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
            cdtUpdated.fullName = cadastro.fullName;
            cdtUpdated.email = cadastro.email;
            cdtUpdated.emailConfirmation = cadastro.emailConfirmation;
            cdtUpdated.cpf = cadastro.cpf;
            cdtUpdated.emailSms = cadastro.emailSms;
            cdtUpdated.cellphone = cadastro.cellphone;
            cdtUpdated.cellphone = cadastro.cellphone;
            cdtUpdated.country = cadastro.country;
            cdtUpdated.city = cadastro.city;
            cdtUpdated.address = cadastro.address;
            cdtUpdated.postalCode = cadastro.postalCode;
            cdtUpdated.whatsapp = cadastro.whatsapp;
        }

        public void deleteCdt(Cadastro cadastro)
        {
            Cadastros.Remove(cadastro);
        }
    }
}