using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class SimpleBootstrapHelperFixture
    {
        [Test]
        public void SimpleBootstrapHelperProducesCorrectHtmlForInput()
        {
            // Given
            SimpleBootstrapHelper helper = new SimpleBootstrapHelper();

            // When
            string input = helper.Input("input-name", "My Input").ToString().Replace("\r\n", Environment.NewLine);

            // Then
            Assert.AreEqual(@"
<label for=""input-name"" class=""control-label"">My Input</label>
<input type=""text"" name=""input-name"" class=""form-control"">", input);
        }
    }
}
