﻿using Shq.Keywords;

namespace Shq.Lexical
{
    public static class Tokenizer
    {

        // Yes it supposed to be null
        private static readonly char[]? TOKEN_SEPARTOR = null;

        public static IEnumerable<string> Tokenize(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return Enumerable.Empty<string>();
            }

            var tokens = new List<string>();

            foreach (var word in query.Split(TOKEN_SEPARTOR))
            {
                var abbreviations = KeywordDictionary.GetByAbbreviations(word);

                if (abbreviations?.Key != null)
                {
                    tokens.Add(abbreviations.Value.Key);
                } else
                {
                    tokens.Add(word);
                }
            }

            return tokens;
        }
    }
}
