﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TranThanhSolution5.Models.Data;

namespace TranThanhSolution5.Models.View
{
    public class EditStudentView
    {
        public Guid Uuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime Birthday { get; set; }
        public DateTime UpdateAt { get; set; }

    }
}