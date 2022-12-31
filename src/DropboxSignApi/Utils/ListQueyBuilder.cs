using System;
using System.Text;

namespace DropboxSignApi.Utils
{
    /// <summary>
    /// Can be used to generate the search query when listing signatures or templates.
    /// Call <see cref="ToString"/> to get the final query.
    /// </summary>
    public sealed class ListQueyBuilder
    {
        internal StringBuilder _sb = new StringBuilder();
        /// <summary>
        /// Gets the chain object.
        /// </summary>
        /// <returns></returns>
        public QueryChain Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListQueyBuilder"/> class.
        /// </summary>
        public ListQueyBuilder()
        {
            Chain = new QueryChain(this);
        }

        void RequireString(string name, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Parameter {name} has no value.", nameof(value));
            }
        }

        static string Escape(string value)
        {
            return Uri.EscapeDataString(value).Replace("%20", "+");
        }

        /// <summary>
        /// Handles the any previously specified chain.
        /// </summary>
        /// <returns></returns>
        public StringBuilder HandleChain()
        {
            if (Chain.UseAnd.HasValue)
            {
                if (_sb.Length > 0)
                {
                    _sb.Append(Chain.UseAnd.Value ? "+AND+" : "+OR+");
                }
                Chain.UseAnd = null;
            }
            return _sb;
        }


        /// <summary>
        /// With the specified terms against 
        /// to, from, title, subject, message, metadata, and filename.
        /// </summary>
        /// <param name="terms">The terms.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain With(string terms)
        {
            RequireString(nameof(terms), terms);

            HandleChain().Append(Escape(terms));
            return Chain;
        }

        /// <summary>
        /// Searches the "to" field with the email address or name of the signer 
        /// (can use "me" to refer to yourself).
        /// </summary>
        /// <param name="signer">The signer.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain SentTo(string signer)
        {
            RequireString(nameof(signer), signer);

            HandleChain().Append("to:").Append(Escape(signer));
            return Chain;
        }

        /// <summary>
        /// Searches the "from" field with the email address or name of the sender 
        /// (can use "me" to refer to yourself).
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain IsFrom(string sender)
        {
            RequireString(nameof(sender), sender);

            HandleChain().Append("from:").Append(Escape(sender));
            return Chain;
        }

        /// <summary>
        /// Searches the title of the signature request or template.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain HasTitle(string title)
        {
            RequireString(nameof(title), title);

            HandleChain().Append("title:").Append(Escape(title));
            return Chain;
        }

        /// <summary>
        /// Searches the subject of the email that is sent to the signers.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain HasSubject(string subject)
        {
            RequireString(nameof(subject), subject);

            HandleChain().Append("subject:").Append(Escape(subject));
            return Chain;
        }

        /// <summary>
        /// Searches the message of the email that is sent to the signers.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain HasMessage(string message)
        {
            RequireString(nameof(message), message);

            HandleChain().Append("message:").Append(Escape(message));
            return Chain;
        }

        /// <summary>
        /// Searches the metadata attached to the signature request or template.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain HasMetadata(string metadata)
        {
            RequireString(nameof(metadata), metadata);

            HandleChain().Append("metadata:").Append(Escape(metadata));
            return Chain;
        }

        /// <summary>
        /// Searches the creation date of the signature request or template.
        /// </summary>
        /// <param name="from">The from value.</param>
        /// <param name="to">The to value.</param>
        /// <param name="inclusive">Whether the range value is inclusive or exclusive.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">'From' value cannot be greater than 'To'.</exception>
        public QueryChain CreatedBetween(DateTime from, DateTime to, bool inclusive = true)
        {
            if (from > to) { throw new ArgumentException("'From' value cannot be greater than 'To'."); }

            // TODO: find out time format
            HandleChain().Append("created:").Append(inclusive ? '[' : '{')
                .Append(from.ToString("yyyy-MM-dd"))
                .Append("+TO+")
                .Append(to.ToString("yyyy-MM-dd"))
                .Append(inclusive ? ']' : '}');
            return Chain;
        }

        /// <summary>
        /// Searches for signature requests that all signers have signed.
        /// </summary>
        /// <param name="flag">the search value.</param>
        /// <returns></returns>
        public QueryChain IsComplete(bool flag = true)
        {
            HandleChain().Append("complete:").Append(flag ? "true" : "false");
            return Chain;
        }
        /// <summary>
        /// Searches for signature requests that have been declined.
        /// </summary>
        /// <param name="flag">the search value.</param>
        /// <returns></returns>
        public QueryChain IsDeclined(bool flag = true)
        {
            HandleChain().Append("declined:").Append(flag ? "true" : "false");
            return Chain;
        }
        /// <summary>
        /// Searches for signature requests that requires your signature.
        /// </summary>
        /// <param name="flag">the search value.</param>
        /// <returns></returns>
        public QueryChain IsAwaitingMySignature(bool flag = true)
        {
            HandleChain().Append("awaiting_my_signature:").Append(flag ? "true" : "false");
            return Chain;
        }
        /// <summary>
        /// Searches for signature requests or templates created with test flag and not legally binding.
        /// </summary>
        /// <param name="flag">the search value.</param>
        /// <returns></returns>
        public QueryChain IsTest(bool flag = true)
        {
            HandleChain().Append("test_mode:").Append(flag ? "true" : "false");
            return Chain;
        }

        /// <summary>
        /// Searches for signature requests or templates created with specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain HasFileName(string fileName)
        {
            RequireString(nameof(fileName), fileName);

            HandleChain().Append("filename:").Append(Escape(fileName));
            return Chain;
        }

        /// <summary>
        /// Searches using The email address or name of the template owner 
        /// (can use "me" to refer to yourself).
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public QueryChain HasOwner(string owner)
        {
            RequireString(nameof(owner), owner);

            HandleChain().Append("owner:").Append(Escape(owner));
            return Chain;
        }

        /// <summary>
        /// Gets the final search query string.
        /// </summary>
        /// <returns>
        /// The final query string.
        /// </returns>
        public override string ToString()
        {
            return _sb.ToString();
        }
    }

    /// <summary>
    /// Intermediate result of the <see cref="ListQueyBuilder"/>.
    /// Call <see cref="ToString"/> to get the final query.
    /// </summary>
    public sealed class QueryChain
    {
        private ListQueyBuilder _builder;
        internal bool? UseAnd;

        internal QueryChain(ListQueyBuilder builder)
        {
            _builder = builder;
        }

        /// <summary>
        /// Chains another query parameter with "AND" logic.
        /// </summary>
        /// <returns></returns>
        public ListQueyBuilder And()
        {
            UseAnd = true;
            return _builder;
        }
        /// <summary>
        /// Chains another query parameter with "OR" logic.
        /// </summary>
        /// <returns></returns>
        public ListQueyBuilder Or()
        {
            UseAnd = false;
            return _builder;
        }

        /// <summary>
        /// Gets the final search query string.
        /// </summary>
        /// <returns>
        /// The final query string.
        /// </returns>
        public override string ToString()
        {
            return _builder._sb.ToString();
        }
    }
}
