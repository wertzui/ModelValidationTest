using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelValidationTest
{
    public class TestController : Controller
    {
        public bool TestSingle(ModelBase model)
        {
            return TryValidateModel(model);
        }

        public bool TestMultiple(IEnumerable<ModelBase> models)
        {
            return TryValidateModel(models);
        }
    }
}
