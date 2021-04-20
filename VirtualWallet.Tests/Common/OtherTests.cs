using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VirtualWallet.Common.Extensions;

namespace VirtualWallet.Tests.Common
{
    [TestFixture]
    public class OtherTests
    {
        [Test]
        [Explicit]
        public void EncrtypTest()
        {
            var x = "".Encrypt(); 
        }
    }
}
