using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloSignApi.Requests
{
    /// <summary>
    /// Represents a signature request recipient.
    /// </summary>
    public class Signer
    {
        /// <summary>
        /// The name of the signer.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email address of the signer. This is required.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The role name of the signer for template purposes.
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// The order the signer is required to sign.
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// The 4- to 12-character access code that will secure this signer's signature page.
        /// </summary>
        public string Pin { get; set; }
    }
}
