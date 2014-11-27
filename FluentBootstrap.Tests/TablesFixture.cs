using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBootstrap.Tests
{
    [TestFixture]
    public class TablesFixture
    {
        [Test]
        public void StripedTableProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Tables>("test-striped",
@"<table class=""table-striped table"">
   <thead>
    <tr>
     <th>#</th>
     <th>First Name</th>
     <th>Last Name</th>
     <th>Username</th>
    </tr>
   </thead>
   <tbody>
    <tr>
     <td>1</td>
     <td>Mark</td>
     <td>Otto</td>
     <td>mdo</td>
    </tr>
    <tr>
     <td>2</td>
     <td>Jacob</td>
     <td>Thornton</td>
     <td>fat</td>
    </tr>
   </tbody>
  </table>");
        }

        [Test]
        public void TableWithExplicitSectionsProducesCorrectHtml()
        {
            TestHelper.AssertHtml<FluentBootstrap.Tests.Web.Views.Tests.Tables>("test-explicit-sections",
@"<table class=""table"">
   <thead>
    <tr>
     <th>#</th>
     <th>First Name</th>
     <th>Last Name</th>
     <th>Username</th>
    </tr>
    <tr>
     <td>1</td>
     <td>Mark</td>
     <td>Otto</td>
     <td>mdo</td>
    </tr>
   </thead>
   <tbody>
    <tr>
     <th>#</th>
     <th>First Name</th>
     <th>Last Name</th>
     <th>Username</th>
    </tr>
    <tr>
     <td>2</td>
     <td>Jacob</td>
     <td>Thornton</td>
     <td>fat</td>
    </tr>
   </tbody>
  </table>");
        }
    }
}
