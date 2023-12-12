using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Categories.Responses
{
    public class GettedCategoryByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
