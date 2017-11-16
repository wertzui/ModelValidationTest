using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelValidationTest
{
    public abstract class ModelBase
    {
    }
    public class Model : ModelBase
    {
        [Range(1, int.MaxValue)]
        public int NumberA { get; set; }
    }
}
