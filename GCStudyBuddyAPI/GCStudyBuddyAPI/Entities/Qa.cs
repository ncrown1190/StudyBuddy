using System;
using System.Collections.Generic;

namespace GCStudyBuddyAPI.Entities;

public partial class Qa
{
    public int Id { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }

    public virtual ICollection<UserFavorite> UserFavorites { get; set; } = new List<UserFavorite>();
}
