using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.Users;

namespace Domain.Entities.Users;

public sealed class User : BaseEntity<Guid>
{
    public UsersCode Code { get; private set; } 
    public UsersNames Names { get; private set; }
    public UsersSurnames Surnames { get; private set; }
    public UsersMail Mail { get; private set; }
    public UsersPassword Password { get; private set; }
    public UsersActive Active { get; private set; }
    public UsersCreateDate CreateDate { get; private set; }
    public UsersFinishDate FinishDate { get; private set; }
    public UsersrolId RoleId { get; private set; }
    private User() { }
    public User(UsersCode code, UsersNames names, UsersSurnames surnames, UsersMail mail, UsersPassword password, UsersActive active, UsersCreateDate createDate, UsersFinishDate finishDate, UsersrolId roleId)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        Names = names ?? throw new ArgumentNullException(nameof(names));
        Surnames = surnames ?? throw new ArgumentNullException(nameof(surnames));
        Mail = mail ?? throw new ArgumentNullException(nameof(mail));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        Active = active ?? throw new ArgumentNullException(nameof(active));
        CreateDate = createDate ?? throw new ArgumentNullException(nameof(createDate));
        FinishDate = finishDate ?? throw new ArgumentNullException(nameof(finishDate));
        RoleId = roleId ?? throw new ArgumentNullException(nameof(roleId));
    }
    public void UpdateCode(UsersCode code)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
    }

    public void UpdateNames(UsersNames names)
    {
        Names = names ?? throw new ArgumentNullException(nameof(names));
    }

    public void UpdateSurnames(UsersSurnames surnames)
    {
        Surnames = surnames ?? throw new ArgumentNullException(nameof(surnames));
    }

    public void UpdateMail(UsersMail mail)
    {
        Mail = mail ?? throw new ArgumentNullException(nameof(mail));
    }

    public void UpdatePassword(UsersPassword password)
    {
        Password = password ?? throw new ArgumentNullException(nameof(password));
    }

    public void UpdateActive(UsersActive active)
    {
        Active = active ?? throw new ArgumentNullException(nameof(active));
    }

    public void UpdateFinishDate(UsersFinishDate finishDate)
    {
        FinishDate = finishDate ?? throw new ArgumentNullException(nameof(finishDate));
    }

    public void UpdateRoleId(UsersrolId roleId)
    {
        RoleId = roleId ?? throw new ArgumentNullException(nameof(roleId));
    }
}
