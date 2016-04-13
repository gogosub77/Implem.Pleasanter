﻿using Implem.Libraries.Utilities;
using Implem.Pleasanter.Libraries.DataSources;
using Implem.Pleasanter.Libraries.DataTypes;
using Implem.Pleasanter.Libraries.ServerData;
using Implem.Pleasanter.Libraries.Utilities;
using Implem.Pleasanter.Models;
using System.Collections.Generic;
using System.Linq;
namespace Implem.Pleasanter.Libraries.Converts
{
    public static class SearchIndexExtensions
    {
        public static void SearchIndexes(
            this int self, Dictionary<string, int> searchIndexHash, int searchPriority)
        {
            Update(searchIndexHash, self.ToString(), searchPriority);
        }

        public static void SearchIndexes(
            this long self, Dictionary<string, int> searchIndexHash, int searchPriority)
        {
            Update(searchIndexHash, self.ToString(), searchPriority);
        }

        public static void SearchIndexes(
            this string self, Dictionary<string, int> searchIndexHash, int searchPriority)
        {
            SearchIndexes(searchIndexHash, self, searchPriority);
        }

        public static void SearchIndexes(
            this Title self, Dictionary<string, int> searchIndexHash, int searchPriority)
        {
            SearchIndexes(searchIndexHash, self.Value, searchPriority);
        }

        public static void SearchIndexes(
            this User self, Dictionary<string, int> searchIndexHash, int searchPriority)
        {
            SearchIndexes(searchIndexHash, self.FullName, searchPriority);
        }

        public static void SearchIndexes(
            this Comments self, Dictionary<string, int> searchIndexHash, int searchPriority)
        {
            SearchIndexes(
                searchIndexHash,
                self.Select(o => SiteInfo.UserFullName(o.Creator) + " " + o.Body).Join(" "),
                searchPriority);
        }

        public static void OutgoingMailsSearchIndexes(
            Dictionary<string, int> searchIndexHash,
            string referenceType,
            long referenceId)
        {
            new OutgoingMailCollection(where: Rds.OutgoingMailsWhere()
                .ReferenceType(referenceType)
                .ReferenceId(referenceId)).Select(o => " ".JoinParam(
                    o.From.ToString(),
                    o.To,
                    o.Cc,
                    o.Bcc,
                    o.Title.Value,
                    o.Body)).Join(" ")
                        .SearchIndexes(createIndex: true)
                        .Distinct()
                        .ForEach(searchIndex =>
                           Update(searchIndexHash, searchIndex, 300));
        }

        private static void SearchIndexes(
            Dictionary<string, int> searchIndexHash,
            string text,
            int searchPriority)
        {
            SearchIndexes(text, createIndex: true).ForEach(searchIndex =>
                Update(searchIndexHash, searchIndex, searchPriority));
        }

        private static void Update(
            Dictionary<string, int> searchIndexHash, string searchIndex, int searchPriority)
        {
            var word = searchIndex.ToLower().Trim();
            word = CSharp.Japanese.Kanaxs.KanaEx.ToHankaku(word);
            word = CSharp.Japanese.Kanaxs.KanaEx.ToZenkakuKana(word);
            if (word != string.Empty)
            {
                if (!searchIndexHash.ContainsKey(word))
                {
                    searchIndexHash.Add(word, searchPriority);
                }
                else if (searchIndexHash[word] > searchPriority)
                {
                    searchIndexHash[word] = searchPriority;
                }
            }
        }

        public static IEnumerable<string> SearchIndexes(this string self, bool createIndex = false)
        {
            return new WordBreaker(self, createIndex).Results
                .Select(o => o.Trim())
                .Where(o => o != string.Empty)
                .Distinct();
        }
    }
}