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

using WatiN.Core.Native;

namespace WatiN.Core
{
	/// <summary>
	/// This class provides specialized functionality for a HTML label element.
	/// </summary>
    [ElementTag("label")]
    public class Label : ElementContainer<Label>
	{
		public Label(DomContainer domContainer, INativeElement labelElement) : base(domContainer, labelElement) {}

        public Label(DomContainer domContainer, ElementFinder finder) : base(domContainer, finder) { }

        public virtual string AccessKey
		{
			get { return GetAttributeValue("accessKey"); }
		}

        public virtual string For
		{
			get { return GetAttributeValue(Find.forAttribute); }
		}
	}
}
