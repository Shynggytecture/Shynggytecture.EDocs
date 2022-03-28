using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shynggytecture.EDocs.Core.Commands
{
    public interface ICommandAsync<TCommandArg, TCommandProccessId>
    {
        Task<TCommandProccessId> Handle(TCommandArg arg);
    }
}
