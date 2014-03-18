using CommonLibary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTest
{
    [TestClass]
    public class IEnumerableExtensionTest
    {
        [TestMethod]
        public void Filter()
        {
            var items = new List<string> {
                   "1","12","13","14","5","6","7","8","9"
            };

            Console.WriteLine("Items starting with Test using delegate");
            Func<string, bool> itemNameFilter = delegate(string testItem) { return testItem.StartsWith("1"); };
            foreach (var testItem in items.Filter(itemNameFilter))
            {
                Console.WriteLine(testItem);
            }
        }
    }
}
