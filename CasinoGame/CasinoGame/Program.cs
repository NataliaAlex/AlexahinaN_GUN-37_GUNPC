using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasinoGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var casino = new Casino();
            var saveLoadService = new FileSystemSaveLoadService("D:\\");
            casino.BuildService(saveLoadService);
            casino.StartGame();
        }
    }
}
