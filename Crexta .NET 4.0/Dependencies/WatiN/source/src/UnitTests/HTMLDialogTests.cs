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
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using WatiN.Core.Constraints;
using WatiN.Core.Exceptions;
using WatiN.Core.UnitTests.TestUtils;
using TimeoutException=WatiN.Core.Exceptions.TimeoutException;

namespace WatiN.Core.UnitTests
{
	[TestFixture]
	public class HTMLDialogTests : BaseWithBrowserTests
	{
		[TearDown]
		public void TearDown()
		{
			Ie.HtmlDialogs.CloseAll();
		}

        [Test]
		public void Should_find_modal_HTMLDialog_by_title_then_typetext_and_handle_alert_popup()
		{			
            Ie.Button("modalid").ClickNoWait();

			using (var htmlDialog = Ie.HtmlDialog(Find.ByTitle("PopUpTest")))
			{
				Assert.IsInstanceOfType(typeof (DomContainer), htmlDialog);

				Assert.IsNotNull(htmlDialog, "Dialog niet aangetroffen");
				Assert.AreEqual("PopUpTest", htmlDialog.Title, "Unexpected title");

				htmlDialog.TextField("name").TypeText("Textfield in HTMLDialog");
				htmlDialog.Button("hello").Click();
			}
		}

		[Test]
		public void HTMLDialogModalByUrl()
		{
			Ie.Button("modalid").ClickNoWait();

			using (var htmlDialog = Ie.HtmlDialog(Find.ByUrl(PopUpURI)))
			{
				Assert.IsNotNull(htmlDialog, "Dialog not found");
				Assert.AreEqual("PopUpTest", htmlDialog.Title, "Unexpected title");
			}
		}

		[Test]
		public void HTMLDialogShouldBeClosedWhenDisposed()
		{
			// Given no HtmlDialog is shown
			Assert.That(Ie.HtmlDialogs.Length, Is.EqualTo(0));
			
			// When I open an HtmlDialog
			// and verify it exists
			// and the HtmlDialog instance gets disposed
			Ie.Button("modalid").ClickNoWait();

			using (var htmlDialog = Ie.HtmlDialog(Find.ByUrl(PopUpURI)))
			{
				Assert.IsNotNull(htmlDialog, "Dialog not found");
			}

			// Then again there should be no HtmlDialog open
			Assert.That(Ie.HtmlDialogs.Length, Is.EqualTo(0));
		}


		[Test]
		public void HTMLDialogsExists()
		{
			Constraint findBy = Find.ByUrl(PopUpURI);
			Assert.IsFalse(Ie.HtmlDialogs.Exists(findBy));

			Ie.Button("modalid").ClickNoWait();

			Thread.Sleep(1000);

			Assert.IsTrue(Ie.HtmlDialogs.Exists(findBy));
		}

		[Test]
		public void HTMLDialogNotFoundException()
		{
			const int timeoutTime = 2;
			const string expectedMessage = "Could not find a HTMLDialog matching criteria: Attribute 'title' contains 'PopUpTest' ignoring case. (Search expired after '2' seconds). Is there a popup blocker active?";

            var startTime = DateTime.Now;

			try
			{
				// Time out after timeoutTime seconds
				startTime = DateTime.Now;
				Ie.HtmlDialog(Find.ByTitle("PopUpTest"), timeoutTime);
				Assert.Fail("PopUpTest should not be found");
			}
			catch (Exception e)
			{
				Assert.IsInstanceOfType(typeof (HtmlDialogNotFoundException), e, "Unexpected exception");
				// add 1 second to give it some slack.
				Assert.Greater(timeoutTime + 1, DateTime.Now.Subtract(startTime).TotalSeconds);
				Assert.AreEqual(expectedMessage, e.Message, "Unexpected exception message");
			}
		}

		[Test]
		public void HTMLDialogModeless()
		{
			Ie.Button("popupid").Click();
            Thread.Sleep(100);
			using (Document dialog = Ie.HtmlDialogs[0])
			{
				var value = dialog.TextField("dims").Value;
				Assert.AreEqual("47", value);
			}
		}

	    [Test]
        public void HtmlDialog_should_exist()
	    {
	        // GIVEN
	        bool exists;

            Ie.Button("popupid").Click();
            Thread.Sleep(100);

            using (var dialog = Ie.HtmlDialogs[0])
            {
                // WHEN
                exists = dialog.Exists;
            }

            // THEN
            Assert.That(exists, Is.True, "Expect HtmlDialog would exist");
	    }

	    [Test]
        public void HtmlDialog_should_not_exist()
	    {
	        // GIVEN
	        bool exists;

            Ie.Button("popupid").Click();
            Thread.Sleep(100);

	        var dialog = Ie.HtmlDialogs[0];
            dialog.Close();

            // WHEN
            exists = dialog.Exists;

            // THEN
            Assert.That(exists, Is.False, "Expect HtmlDialog should no longer exist");
	    }

        [Test]
        public void Should_wait_until_html_dialog_is_closed()
        {
            // GIVEN
            Ie.Button("popupid").Click();
            Thread.Sleep(100);

            var dialog = Ie.HtmlDialogs[0];
            dialog.Button("closebutton").ClickNoWait();

            // WHEN
            dialog.WaitUntilClosed();

            // THEN
            Assert.That(dialog.Exists, Is.False, "Expect HtmlDialog was closed");
        }

        [Test]
        public void WaitUntilClosed_should_throw_trimeout_exception_when_timed_out()
        {
            // GIVEN
            Ie.Button("popupid").Click();
            Thread.Sleep(100);

            var dialog = Ie.HtmlDialogs[0];

            try
            {
                // WHEN
                dialog.WaitUntilClosed(1);

                Assert.Fail("Should have thrown TimeoutException");
            }
            catch (TimeoutException)
            {
                // THEN: this is OK
            }
        }

		public override Uri TestPageUri
		{
			get { return MainURI; }
		}
	}
}