namespace DropboxSignApi
{
    /// <summary>
    /// Contains rules for field grouping.
    /// </summary>
    public static class FieldGroupRules
    {
        /// <summary>
        /// Requires at most one checkbox within the group to be checked (radio button functionality)
        /// </summary>
        public const string RequireUpTo1 = "require_0-1";
        /// <summary>
        /// Requires only one checkbox within the group to be checked
        /// </summary>
        public const string Require1 = "require_1";
        /// <summary>
        /// Requires at least one checkbox within the group to be checked
        /// </summary>
        public const string Require1OrMore = "require_1-ormore";
    }
}
