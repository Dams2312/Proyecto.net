using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Domain.ValueObject.CustomerEmail;

public sealed record CustomerEmailAddress
{
    public string Value { get; }

    private CustomerEmailAddress(string value)
    {
        Value = value;
    }

    public static CustomerEmailAddress Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El correo es obligatorio.", nameof(value));

        value = value.Trim().ToLower();

        if (value.Length > 150)
            throw new ArgumentException("El correo no puede superar los 150 caracteres.", nameof(value));

        try
        {
            var mailAddress = new MailAddress(value);

            if (!string.Equals(mailAddress.Address, value, StringComparison.OrdinalIgnoreCase))
                throw new ArgumentException("El correo contiene un formato inválido.", nameof(value));
        }
        catch
        {
            throw new ArgumentException("El correo electrónico no es válido.", nameof(value));
        }

        return new CustomerEmailAddress(value);
    }

    public override string ToString() => Value;    
}
