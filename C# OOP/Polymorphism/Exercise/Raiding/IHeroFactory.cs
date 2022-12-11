using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public interface IHeroFactory
    {
        BaseHero CreateHero(string type, string name);
    }
}
