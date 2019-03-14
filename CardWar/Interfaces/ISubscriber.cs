using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardWar
{
    public interface ISubscriber
    {
        void Update(IPublisher publisher);
        void Terminate(IPublisher publisher);
    }
}
