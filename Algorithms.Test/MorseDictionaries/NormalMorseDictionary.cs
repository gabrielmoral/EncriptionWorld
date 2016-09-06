using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncriptionAlgorithms.Test
{
    internal class NormalMorseDictionary : MorseDictionaryDefinition
    {
        protected override void AddCode(string v1, string v2)
        {
            codes.Add(v1, v2);
        }
    }
}