/*
Copyright (c) 2023 Xavier Arpa López Thomas Peter ('Kingdox')

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using System.Collections.Generic;
namespace Kingdox.UniFlux.Core.Internal
{
    ///<summary>
    /// This class represents an implementation of an IFlux interface with a TKey key and an action without parameters.
    ///</summary>
    internal sealed class ActionFlux<TKey> :  IFlux<TKey, Action>
    {
        /// <summary>
        /// A dictionary that stores functions with no parameters
        /// </summary>
        internal readonly Dictionary<TKey, Action> dictionary = new Dictionary<TKey, Action>();
        /// <summary>
        /// Gets the dictionary that stores the functions with no parameters
        /// </summary>
        IDictionary<TKey, Action> IStore<TKey, Action>.Storage => dictionary;
        ///<summary>
        /// Subscribes an event to the action dictionary if the given condition is met
        ///</summary>
        ///<param name="condition">Condition that must be true to subscribe the event</param>
        ///<param name="key">Key of the event to subscribe</param>
        ///<param name="action">Action to execute when the event is triggered</param>
        void IStore<TKey, Action>.Store(in bool condition, in TKey key, in Action action)
        {
            if (condition)
            {
                if (!dictionary.ContainsKey(key)) dictionary.Add(key, default);
                dictionary[key] += action;
            }
            else if (dictionary.ContainsKey(key))
            {
                dictionary[key] -= action;
                if (dictionary[key] == null) dictionary.Remove(key);
            }
        }
        ///<summary>
        /// Triggers the function stored in the dictionary with the specified key. 
        ///</summary>
        void IFlux<TKey, Action>.Dispatch(in TKey key)
        {
            if (dictionary.ContainsKey(key)) dictionary[key]?.Invoke();
        }
    }
}