using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanBlogApp.Application.DTOs.common;
public class BaseDTO
{
    public int PostId { get; set; }
    public DateTime CreatedAt { get; set; }
}

