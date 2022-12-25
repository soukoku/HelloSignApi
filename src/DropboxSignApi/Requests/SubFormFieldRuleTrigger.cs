using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    public class SubFormFieldRuleTrigger
    {
        /// <summary>
        /// Must reference the api_id of an existing field defined within form_fields_per_document. 
        /// Trigger and action fields and groups must belong to the same signer.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// "any" "is" "match" "none" "not".
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// value or values is required, but not both.
        /// The value to match against operator.
        /// When operator is one of the following, value must be String:
        /// is, not, match.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// values or value is required, but not both.
        /// The values to match against operator when it is one of the following:
        /// any, none.
        /// </summary>
        public IList<string> Values { get; set; }
    }
}