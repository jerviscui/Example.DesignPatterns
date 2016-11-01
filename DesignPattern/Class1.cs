using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DesignPattern
{
    public class Class1
    {
        [Fact]
        public void TestMehtod()
        {
            1.ShouldBe(1);
        }
    }
}
