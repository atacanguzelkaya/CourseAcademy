﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Courses.Requests
{
    public class CreateCourseRequest
    {
        public Guid CategoryId { get; set; }
        public Guid InstructorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}