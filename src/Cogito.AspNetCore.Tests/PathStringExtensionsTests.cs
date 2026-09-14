using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cogito.AspNetCore.Tests
{

    [TestClass]
    public class PathStringExtensionsTests
    {

        [TestMethod]
        public void Test_ends_with_segments()
        {
            var v = new PathString("/root/path");
            var o = new PathString("/path");
            Assert.IsTrue(v.EndsWithSegments(o));
        }

        [TestMethod]
        public void Test_not_ends_with_segment()
        {
            var v = new PathString("/root/path");
            var o = new PathString("/foo");
            Assert.IsFalse(v.EndsWithSegments(o));
        }

        [TestMethod]
        public void Test_root_segment()
        {
            var v = new PathString("/");
            var o = new PathString("/");
            Assert.IsTrue(v.EndsWithSegments(o));
        }

        [TestMethod]
        public void Test_null_segment2()
        {
            var v = new PathString("/");
            var o = new PathString("");
            Assert.IsTrue(v.EndsWithSegments(o));
        }

        [TestMethod]
        public void Test_null_segment3()
        {
            var v = new PathString("");
            var o = new PathString("/");
            Assert.IsFalse(v.EndsWithSegments(o));
        }

        [TestMethod]
        public void Test_not_ends_with_null_segment()
        {
            var v = new PathString("/foo/bar");
            var o = new PathString("/");
            Assert.IsFalse(v.EndsWithSegments(o));
        }

        [TestMethod]
        public void Test_ends_with_and_return_remaining_1()
        {
            var o = new PathString("/OriginalUrl/page");
            var v = new PathString("/page");
            Assert.IsTrue(o.EndsWithSegments(v, out var remaining) && remaining == "/OriginalUrl");
        }

    }

}
