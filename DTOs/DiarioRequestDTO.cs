using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autenticacao01.DTOs
{
    public record DiarioRequestDTO(int? Id, string Title, string Text);
}