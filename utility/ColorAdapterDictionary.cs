using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLifeWinForms.utility
{

    public interface ColorAdapterDictionary : IEnumerable<KeyValuePair<string, ColorAdapter>>
    {
        void Add(string key, ColorAdapter value);
        ColorAdapter Get(string key);
        IEnumerable<string> Keys();
        void increment();
    }
    
    public class DefaultColorAdapterDictionary : ColorAdapterDictionary
    {
        IList<KeyValuePair<string, ColorAdapter>> adapters;
        ColorAdapter special_case;

        public DefaultColorAdapterDictionary(IList<KeyValuePair<string, ColorAdapter>> adapters, ColorAdapter dead_adapter)
        {
            this.adapters = adapters;
            special_case = dead_adapter;
        }

        public void increment()
        {
            foreach (KeyValuePair<string, ColorAdapter> pair in adapters)
            {
                if (pair.Value != special_case) pair.Value.increment();
            }
        }

        public void Add(string key, ColorAdapter adapter)
        {
            adapters.Add(new KeyValuePair<string, ColorAdapter>(key, adapter));
        }

        public IEnumerable<string> Keys()
        {
            foreach (KeyValuePair<string, ColorAdapter> pair in this)
            {
                yield return pair.Key;
            }
        }

        public ColorAdapter Get(string key)
        {
            return adapters.FirstOrDefault(x => x.Key == key).Value ?? special_case;
        }

        public IEnumerator<KeyValuePair<string, ColorAdapter>> GetEnumerator()
        {
            return adapters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
