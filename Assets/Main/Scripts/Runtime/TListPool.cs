using System.Collections.Generic;


namespace Tinker
{
    internal static class TListPool<T>
    {
        // Object pool to avoid allocations.
        private static readonly TObjectPool<List<T>> s_ListPool = new TObjectPool<List<T>>(null, l => l.Clear());

        public static List<T> Get()
        {
            return s_ListPool.Get();
        }

        public static void Release(List<T> toRelease)
        {
            s_ListPool.Release(toRelease);
        }
    }
}