﻿using System.Collections.ObjectModel;

namespace Endpoint.Controllers.Resources;

public class MakeResource
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<ModelResource> Models { get; set; }

    /// <summary>
    /// Vi undgår nullreference
    /// </summary>
    public MakeResource()
    {
        Models = new Collection<ModelResource>();
    }
}