﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Instructors.Responses
{
    public class GettedInstructorByIdResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
