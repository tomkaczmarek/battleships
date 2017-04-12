using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace BattleShipsLibraryTest
{    
    public class FieldsTestXUnit
    {
        private readonly ITestOutputHelper output;

        public FieldsTestXUnit(ITestOutputHelper _out)
        {
            output = _out;
        }

        [Fact]
        public void XUNitShouldMakeConcreteFieldSymbol()
        {
            int i = 5;
            int j = 5;

            output.WriteLine("{0}", i);

            Assert.Equal(i, j);
        }

    }
}
