using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Domain.ValueObject.Users;

public sealed record UsersMail
{
    public string Value { get; }

    private UsersMail(string value)
    {
        Value = value;
    }

    public static UsersMail Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El email es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (!MailAddress.TryCreate(normalized, out var mailAddress))
            throw new ArgumentException("El email no tiene un formato válido.", nameof(value));

        if (!string.Equals(mailAddress.Address, normalized, StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException("El email no debe incluir nombre para mostrar u otros formatos.", nameof(value));

        return new UsersMail(normalized);
    }

    public override string ToString() => Value;
}
