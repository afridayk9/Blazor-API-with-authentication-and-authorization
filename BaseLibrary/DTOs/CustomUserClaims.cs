using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTOs;
public record CustomUserClaims(string id = null!, string Name = null!, string email = null!, string role = null!);