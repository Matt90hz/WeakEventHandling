using IncaTechnologies.WeakEventHandling.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncaTechnologies.WeakEventHandling.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IWeakEvent{TEventHandler}"/> and <see cref="IParamsWeakEvent{TEventHandler}"/> implementations
    /// </summary>
    internal static class WeakEventExtensions
    {
        /// <summary>
        /// Remove all the elements contaning a <see cref="WeakReference"/> that are not alive.
        /// </summary>
        /// <param name="weaks">A list of elements that contains <see cref="WeakReference"/>.</param>
        /// <typeparam name="TWeak">Type that implements <see cref="IWeak"/></typeparam>
        /// <returns>The nuber of the elements removed.</returns>
        public static int ClearDead<TWeak>(this ICollection<TWeak> weaks) where TWeak : IWeak
        {
            var counter = 0;

            for(var i = weaks.Count - 1; i >= 0; i--)
            {
                var weak = weaks.ElementAt(i);

                if (weak.IsAlive) continue;

                weaks.Remove(weak);
                counter++;
            }

            return counter;
        }
    }
}
