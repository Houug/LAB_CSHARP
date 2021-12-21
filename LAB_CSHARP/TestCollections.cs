using System;
using System.Collections.Generic;
using System.Linq;

namespace LAB_CSHARP
{
    public delegate KeyValuePair<TKey,TValue> GenerateElement<TKey, TValue>(int j);
    public class TestCollections<TKey,TValue>
    {
        private List<TKey> _keyList;
        private List<string> _stringList;
        private Dictionary<TKey, TValue> _keyDict;
        private Dictionary<string, TValue> _stringDict;
        private GenerateElement<TKey, TValue> _generateElement;
        
        public TestCollections(int count, GenerateElement<TKey, TValue> j)
        {
            if (count <= 0) throw new ArgumentException();

            _generateElement = j;
            for (int i = 0; i < count; i++)
            {
                var element = _generateElement(i);
                _keyDict.Add(element.Key, element.Value);
                _stringDict.Add(element.Key.ToString(), element.Value);
                _keyList.Add(element.Key);
                _stringList.Add(element.Key.ToString());
            }
        }
        
        public void StopwatchKeyList()
        {
            var firstElement = _keyList[0];
            var middleElement = _keyList[_keyList.Count / 2];
            var lastElement = _keyList[-1];
            var outsideElement = _generateElement(_keyList.Count + 10).Key;


            _keyList.Contains(firstElement);
            _keyList.Contains(middleElement);
            _keyList.Contains(lastElement);
            _keyList.Contains(outsideElement);
        }
        
        public void StopwatchKeyDictByKey()
        {
            var firstElement = _keyDict.ElementAt(0).Key;
            var middleElement = _keyDict.ElementAt(_keyDict.Count / 2).Key;
            var lastElement = _keyDict.ElementAt(_keyDict.Count - 1).Key;
            var outsideElement = _generateElement(_keyDict.Count + 10).Key;

            _keyDict.ContainsKey(firstElement);
            _keyDict.ContainsKey(middleElement);
            _keyDict.ContainsKey(lastElement);
            _keyDict.ContainsKey(outsideElement);
        }
        
        public void StopwatchKeyDictByValue()
        {
            var firstElement = _keyDict.ElementAt(0).Value;
            var middleElement = _keyDict.ElementAt(_keyDict.Count / 2).Value;
            var lastElement = _keyDict.ElementAt(_keyDict.Count - 1).Value;
            var outsideElement = _generateElement(_keyDict.Count + 10).Value;

            _keyDict.ContainsValue(firstElement);
            _keyDict.ContainsValue(middleElement);
            _keyDict.ContainsValue(lastElement);
            _keyDict.ContainsValue(outsideElement);
        }
    }
}