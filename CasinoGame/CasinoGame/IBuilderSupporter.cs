using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    interface IBuilderSupporter
    {
        void BuildService<T>(T service) where T : ISaveLoadService<string>;
        void BuildCustom<U>(U games) where U : CasinoGameBase;
    }
}
