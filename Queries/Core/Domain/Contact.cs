﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Queries.Core.Domain;

public class Contact
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public string Phone { get; set; }
}
