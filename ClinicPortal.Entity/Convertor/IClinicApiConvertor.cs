using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicPortal.Entity.Convertor
{
    public interface IClinicApiConvertor<out T>
    {
        T Execute(string input);
    }
}
