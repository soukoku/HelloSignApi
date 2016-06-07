using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloSignApi.Requests
{
    /// <summary>
    /// A merge field in a template.
    /// </summary>
    public class MergeField
    {
        /// <summary>
        /// Name of merge field.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Type of merge field. Can only be <see cref="FieldTypes.Text"/> or <see cref="FieldTypes.CheckBox"/>.
        /// </summary>
        public string Type { get; set; }
    }
}
