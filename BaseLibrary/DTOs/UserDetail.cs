﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs;
public class UserDetail
{
    public string? Email { get; set; }
    public List<string>? Roles { get; set; }
}

