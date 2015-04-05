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

using System.Text.RegularExpressions;
using WatiN.Core.Constraints;

namespace WatiN.Core.Interfaces
{
    /// <summary>
    /// Used to find elements by a default characteristic such as by id or by
    /// some other application-specific rule.
    /// </summary>
    public interface IFindByDefaultFactory
    {
        /// <summary>
        /// Gets a constraint to find an element by matching its default characteristics
        /// against the specified string.
        /// </summary>
        /// <param name="value">The string to match against</param>
        /// <returns>A constraint</returns>
        Constraint ByDefault(string value);

        /// <summary>
        /// Gets a constraint to find an element by matching its default characteristics
        /// against the specified regular expression.
        /// </summary>
        /// <param name="value">The regular expression to match against</param>
        /// <returns>A constraint</returns>
        Constraint ByDefault(Regex value);
    }
}