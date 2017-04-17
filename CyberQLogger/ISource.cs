using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberQLogger
{
    public interface ISource
    {
        string Fetch();
        DateTime GetCurrentTime();
    }
}
