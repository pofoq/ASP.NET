using System;

namespace PromoCodeFactory.WebHost.Models;

public sealed class UpdateEmployeeRequest : AddEmployeeRequest
{
    public Guid Id { get; set; }
}
