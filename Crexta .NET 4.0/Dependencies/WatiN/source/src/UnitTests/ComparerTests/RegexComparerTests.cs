#region WatiN Copyright (C) 2006-2011 Jeroen van Menen

//Copyright 2006-2011 Jeroen van Menen
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

#endregion Copyright

using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using WatiN.Core.Comparers;
using WatiN.Core.Interfaces;

namespace WatiN.Core.UnitTests
{
	[TestFixture]
	public class RegexComparerTests
	{
		[Test]
		public void ConstructorWithValue()
		{
			var comparer = new RegexComparer(new Regex("^A test value$"));

			Assert.IsTrue(comparer.Compare("A test value"), "Exact match should pass.");

			Assert.IsFalse(comparer.Compare("a test Value"), "Match should be case sensitive");
			Assert.IsFalse(comparer.Compare("A test value 2"), "Exact match plus more should not pass.");
			Assert.IsFalse(comparer.Compare("test"), "Partial match should not match");
			Assert.IsFalse(comparer.Compare("completely different"), "Something completely different should not match");
			Assert.IsFalse(comparer.Compare(String.Empty), "String.Empty should not match");
			Assert.IsFalse(comparer.Compare(null), "null should not match");
		}

		[Test, ExpectedException(typeof (ArgumentNullException))]
		public void ConstructorWithNullShouldThrowArgumentNullException()
		{
			new RegexComparer(null);
		}

		[Test]
		public void ConstuctorWithStringEmpty()
		{
			var comparer = new RegexComparer(new Regex(String.Empty));

			Assert.IsTrue(comparer.Compare(String.Empty), "String.Empty should match");
			Assert.IsTrue(comparer.Compare(" "), "Any string should not match");

			Assert.IsFalse(comparer.Compare(null), "null should not match");
		}

        [Test]
        public void ToStringShouldDescribeTheCondition()
        {
            var comparer = new RegexComparer(new Regex("^A test value$"));
            Assert.AreEqual("matches '^A test value$'", comparer.ToString());
        }
	}
}