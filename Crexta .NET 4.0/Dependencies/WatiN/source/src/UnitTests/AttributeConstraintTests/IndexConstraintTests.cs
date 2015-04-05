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
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using WatiN.Core.UnitTests.TestUtils;

namespace WatiN.Core.UnitTests.AttributeConstraintTests
{
	/// <summary>
	/// Summary description for IndexConstraintTests.
	/// </summary>
	[TestFixture]
	public class IndexConstraintTests : BaseWithBrowserTests
	{
		public override Uri TestPageUri
		{
			get { return MainURI; }
		}

		[Test]
		public void ShouldBeAbleToFindElementsByTheirIndex()
		{
			Assert.That(Ie.TextField(Find.ByIndex(3)).Id, Is.EqualTo("readonlytext"));
		}

		[Test]
		public void ShouldBeAbleToRefindElementByIndexAfterCallingRefresh()
		{
			TextField textField = Ie.TextField(Find.ByIndex(3));
			Assert.That(textField.Id, Is.EqualTo("readonlytext"));

			textField.Refresh();

			Assert.That(textField.Id, Is.EqualTo("readonlytext"));
		}
	}
}
