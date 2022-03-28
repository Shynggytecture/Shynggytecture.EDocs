using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands
{
    public interface ICommand<TCommandArg, TCommandProccessId>
    {
        TCommandProccessId Handle(TCommandArg arg);
    }
}
