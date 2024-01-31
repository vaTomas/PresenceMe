using OfficeOpenXml.Export.ToDataTable;
using PresenceMe.LocalDatabase;
using PresenceMe.MyPackages;
using System;
using System.Collections.Generic;

namespace PresenceMe.src
{
    internal class RFIDManager
    {
        public static string RetrieveOwner(uint uid)
        {
            // Try to retrieve the owner directly
            if (DBPresenceMe.LocalData.RFIDs.TryGetValue(uid, out string owner))
            {
                return owner;
            }

            // If not found, try to find a matching key
            uint? matchingKey = FindMatchingKey(uid);
            if (matchingKey.HasValue)
            {
                ReplaceKey(DBPresenceMe.LocalData.RFIDs, matchingKey.Value, uid);
                return DBPresenceMe.LocalData.RFIDs[uid];
            }

            return null;
        }

        private static uint? FindMatchingKey(uint uid)
        {
            foreach (var kvp in DBPresenceMe.LocalData.RFIDs)
            {
                if (MyPackages.CompareBits.Compare(uid, kvp.Key, 0, 20))
                {
                    return kvp.Key;
                }
            }
            return null;
        }

        private static void ReplaceKey<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey oldKey, TKey newKey)
        {
            // Check if the old key exists in the dictionary
            if (dictionary.TryGetValue(oldKey, out TValue value))
            {
                // Remove the old key
                dictionary.Remove(oldKey);

                // Add the new key with the same value
                dictionary.Add(newKey, value);
            }
        }
    }
}
