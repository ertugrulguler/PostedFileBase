﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PostedFiles.Model.Attributes
{
    public class FileTypesAttribute:ValidationAttribute
    {
        private readonly List<string> _types;

        public FileTypesAttribute(string types)
        {
            _types = types.Split(',').ToList();
        }

        public override bool IsValid(object value)
        {
            if (value==null)
            {
                return true;
            }
            var fileExt = System.IO.Path.GetExtension((value as HttpPostedFileBase).FileName.Substring(1));
            return _types.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
        }

    }
}
