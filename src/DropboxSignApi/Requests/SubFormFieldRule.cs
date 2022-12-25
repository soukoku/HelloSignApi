using System.Collections.Generic;

namespace DropboxSignApi.Requests
{
    public class SubFormFieldRule
    {
        /// <summary>
        /// Must be unique across all defined rules.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Currently only AND is supported. Support for OR is being worked on.
        /// </summary>
        public string TriggerOperator { get; set; } = "AND";

        /// <summary>
        /// An array of trigger definitions, the "if this" part of "if this, 
        /// then that". Currently only a single trigger per rule is allowed.
        /// </summary>
        public IList<SubFormFieldRuleTrigger> Triggers { get; set; } = new List<SubFormFieldRuleTrigger>();

        /// <summary>
        /// An array of action definitions, the "then that" part of "if this, then that". 
        /// Any number of actions may be attached to a single rule.
        /// </summary>
        public IList<SubFormFieldRuleAction> Actions { get; set; } = new List<SubFormFieldRuleAction>();
    }
}