using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RE.Core.DomainObjects
{
    public class Email
    {
        public const int EmailMaxLenght = 254;
        public const int EmailMinLenght = 5;

        public string EnderecoEmail { get; private set; }

        //Construtor do EntityFramework
        protected Email()
        {

        }

        public Email(string enderecoEmail)
        {
            if (!Validar(enderecoEmail)) throw new DomainException("E-mail inválido!");
            EnderecoEmail = enderecoEmail;
        }

        public static bool Validar(string enderecoEmail)
        {
            var regexEmail = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            return regexEmail.IsMatch(enderecoEmail);
        }
    }
}
