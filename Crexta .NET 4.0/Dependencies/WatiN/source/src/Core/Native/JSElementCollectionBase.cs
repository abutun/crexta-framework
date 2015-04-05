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

using WatiN.Core.UtilityClasses;

namespace WatiN.Core.Native
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Base element collection common to all browsers that communicate with WatiN using javascript.
    /// </summary>
    public abstract class JSElementCollectionBase : INativeElementCollection2
    {
        protected ClientPortBase clientPort;

        protected string containerReference;

        protected JSElementCollectionBase(ClientPortBase clientPort, string containerReference)
        {
            if (clientPort == null)
                throw new ArgumentNullException("clientPort");
            if (containerReference == null)
                throw new ArgumentNullException("containerReference");

            this.clientPort = clientPort;
            this.containerReference = containerReference;
        }


        /// <summary>
        /// Gets all the native elements.
        /// </summary>
        /// <returns>Enumeration of native elements</returns>
        public IEnumerable<INativeElement> GetElements()
        {
            return GetElementByTagImpl("*");
        }

        /// <summary>
        /// Gets a collection of elements by tag name.
        /// </summary>
        /// <param name="tagName">Name of the tag.</param>
        /// <returns>Collection of elements for the given <paramref name="tagName"/>.</returns>
        protected virtual IEnumerable<INativeElement> GetElementByTagImpl(string tagName)
        {
            if (tagName == null)
            {
                throw new ArgumentNullException("tagName");
            }

            Initialize();

            var command = string.Format("{0}.getElementsByTagName(\"{1}\")", containerReference, tagName);
            var ffElements = GetElementArrayEnumerator(command);

            foreach (var ffElement in ffElements)
            {
                if (tagName != "*") ffElement.TagName = tagName;
                yield return ffElement;
            }
        }

        protected virtual IEnumerable<JSElement> GetElementArrayEnumerator(string command)
        {
            return JSUtils.ElementArrayEnumerator(command, clientPort);
        }

        /// <summary>
        /// Gets a collection of elements by id.
        /// </summary>
        /// <param name="id">The id of the element.</param>
        /// <returns>Collection of elements for the given <paramref name="id"/>.</returns>
        protected IEnumerable<INativeElement> GetElementsByIdImpl(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            Initialize();
            
            if (!clientPort.HasJavaScriptSupportForQuerySelector)
            {
                var elementReference = clientPort.CreateVariableName();
                var documentReference = GetDocumentReference(containerReference);
                var command = string.Format("{0} = {1}.getElementById(\"{2}\"); {0} != null", elementReference, documentReference, id);
                if (clientPort.WriteAndReadAsBool(command))
                {
                    yield return new JSElement(clientPort, elementReference);
                }
            }            
            else
            {
                var command = string.Format("{0}.querySelectorAll(\"[Id='{1}']\")", containerReference, id);
                var ffElements = GetElementArrayEnumerator(command);
                foreach (var ffElement in ffElements)
                {
                    yield return ffElement;
                }
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected void Initialize()
        {
            // In case of a redirect this call makes sure the doc variable is pointing to the "active" page.
            clientPort.InitializeDocument();
        }

        protected static string GetDocumentReference(string referencedElement)
        {
            if (referencedElement.Contains(".") &&
                !(referencedElement.EndsWith("contentDocument") || referencedElement.EndsWith("ownerDocument")))
            {
                return referencedElement + ".ownerDocument";
            }

            return referencedElement;
        }

        /// <inheritdoc />
        public virtual IEnumerable<INativeElement> GetElementsById(string id)
        {
            return GetElementsByIdImpl(id);
        }

        public IEnumerable<INativeElement> GetElementsWithQuerySelector(string selector, DomContainer domContainer)
        {
            domContainer.RunScript(new ScriptLoader().GetSizzleInstallScript());

            var command = string.Format("window.Sizzle('{0}', {1})", selector, containerReference);

            var ffElements = GetElementArrayEnumerator(command);
            foreach (var ffElement in ffElements)
            {
                yield return ffElement;
            }
        }

        /// <inheritdoc />
        public virtual IEnumerable<INativeElement> GetElementsByTag(string tagName)
        {
            return GetElementByTagImpl(tagName);
        }
    }
}