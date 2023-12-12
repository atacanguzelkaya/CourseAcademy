using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Instructors.Responses
{
    public class GetListedInstructorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}