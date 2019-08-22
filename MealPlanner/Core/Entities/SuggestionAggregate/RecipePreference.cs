using Ardalis.GuardClauses;
using Core.Entities.RecipeAggregate;
using System;

namespace Core.Entities.SuggestionAggregate
{
    public class RecipePreference : BaseEntity
    {
        public Recipe Recipe { get; set; }
        public int Rating { get; set; }
        public TimeSpan Frequency { get; set; }
        public string User { get; set; }

        public RecipePreference(Recipe recipe, int rating, TimeSpan frequency, string user)
        {
            Guard.Against.OutOfRange(rating, nameof(rating), 1, 5);

            Recipe = recipe;
            Rating = rating;
            Frequency = frequency;
            User = user;
        }
    }
}
