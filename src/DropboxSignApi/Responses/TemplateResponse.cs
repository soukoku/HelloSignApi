using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DropboxSignApi.Responses
{
    /// <summary>
    /// Represents a document template.
    /// </summary>
    public class TemplateResponse
    {
        /// <summary>
        /// The id of the Template.
        /// </summary>
        public string TemplateId { get; set; }
        
        /// <summary>
        /// The title of the Template. This will also be the default subject of the message sent to signers 
        /// when using this Template to send a SignatureRequest. This can be overriden when sending the SignatureRequest.
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// The default message that will be sent to signers when using this Template to send a SignatureRequest. 
        /// This can be overriden when sending the SignatureRequest.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Time the template was last updated.
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// True if this template was created using an embedded flow, false if it was created on our website.
        /// </summary>
        public bool IsEmbedded { get; set; }

        /// <summary>
        /// True if you are the owner of this template, false if it's been shared with you by a team member.
        /// </summary>
        public bool IsCreator { get; set; }

        /// <summary>
        /// Indicates whether edit rights have been granted to you by the owner (always true if that's you).
        /// </summary>
        public bool CanEdit { get; set; }

        /// <summary>
        /// Indicates whether the template is locked. If true, then the template was created outside 
        /// your quota and can only be used in test_mode. If false, then the template is within 
        /// your quota and can be used to create signature requests.
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// The metadata attached to the template.
        /// </summary>
        public IDictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// An array of the designated signer roles that must be specified when sending a SignatureRequest using this Template.
        /// </summary>
        public IList<TemplateResponseSignerRole> SignerRoles { get; set; }

        /// <summary>
        /// An array of the designated CC roles that must be specified when sending a SignatureRequest using this Template.
        /// </summary>
        public IList<TemplateResponseCCRole> CcRoles { get; set; }

        /// <summary>
        /// An array describing each document associated with this Template. Includes form field data for each document.
        /// </summary>
        public IList<TemplateResponseDocument> Documents { get; set; }

        /// <summary>
        /// An array of Custom Field objects containing the name and type of each custom field.
        /// </summary>
        public IList<TemplateResponseCustomField> CustomFields { get; set; }

        /// <summary>
        /// An array of the Accounts that can use this Template.
        /// </summary>
        public IList<TemplateResponseAccount> Accounts { get; set; }
    }
}
