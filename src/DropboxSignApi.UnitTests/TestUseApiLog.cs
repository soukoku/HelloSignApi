using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DropboxSignApi
{
    /// <summary>
    /// A logger that keeps logged parts for assert tests.
    /// </summary>
    class TestUseApiLog : IApiLog
    {
        void IApiLog.JsonSerialized<TReq>(string json) => SerializedJson = json;
        void IApiLog.MultipartAdded(string key, string value) => _parts.Add((key, value));
        void IApiLog.Requesting(string httpMethod, string apiUrl) => RequestedApi = (httpMethod, apiUrl);
        void IApiLog.ResponseRead<TResp>(string content) => Response = content;

        // logged data

        public string SerializedJson { get; private set; }

        List<(string Key, string Value)> _parts = new();
        public IReadOnlyList<(string Key, string Value)> AddedMultiparts { get => _parts; }

        public (string Method, string Url) RequestedApi { get; private set; }

        public string Response { get; private set; }

        // assert utils

        public void AssertHasPart(string keyName)
        {
            Assert.AreEqual(1, _parts.Count(p => p.Key == keyName), $"Didn't find {keyName}");
        }
        public void AssertHasPart(string keyName, string value)
        {
            var found = _parts.FirstOrDefault(p => p.Key == keyName);
            if (string.IsNullOrEmpty(found.Key))
            {
                Assert.Fail($"Didn't find {keyName}");
            }
            else
            {
                Assert.AreEqual(value, found.Value, $"{keyName} has incorrect value.");
            }
        }
        public void AssertHasNoPart(string keyName)
        {
            var found = _parts.FirstOrDefault(p => p.Key == keyName);
            if (!string.IsNullOrEmpty(found.Key))
            {
                Assert.Fail($"Found {keyName}={found.Value}");
            }
        }

        public void Reset()
        {
            SerializedJson = default;
            _parts.Clear();
            RequestedApi = default;
            Response = default;
        }
    }
}
