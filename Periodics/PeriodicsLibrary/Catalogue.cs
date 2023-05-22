using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicsLibrary
{
    public class Catalogue : IEnumerable<Edition>
    {
        private List<Edition> allEditions;
        public int Count { get => allEditions.Count; }
        public Catalogue(IEnumerable<Edition> editions)
        {
            allEditions = new List<Edition>(editions.Distinct());
        }
        
        public IEnumerator<Edition> GetEnumerator() => allEditions.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}