using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonScripts.Service.Interfaces
{
    public interface IChocolateyService
    {
        void Install();
        void InstallPackage();
    }
}