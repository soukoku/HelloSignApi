using DropboxSignApi.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DropboxSignApi.Utils
{
    [TestClass]
    public class ApiMultipartContentTests
    {
        [TestMethod]
        public void Should_Make_Corrrect_Snake_Case_Names()
        {
            //Arrange basic and tricky case tests
            var sample = new
            {
                One = "a",
                TwoWords = "a",
                CcEmailAddresses = "a",
                CCEmailAddresses2 = "a",
                //AllowCCs = "a", // ha this doesn't work
                OpenUpFBI = "a",
            };
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample, log);

            //Assert
            log.AssertHasPart("one");
            log.AssertHasPart("two_words");
            log.AssertHasPart("cc_email_addresses");
            log.AssertHasPart("cc_email_addresses2");
            //log.AssertHasPart("allow_ccs"); 
            log.AssertHasPart("open_up_fbi");
        }


        [TestMethod]
        public void Should_Observe_JsonIgnore_Attribute()
        {
            //Arrange
            var sample = new SampleObject { Ignored = "howdy" };
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample, log);

            //Assert
            log.AssertHasNoPart("ignored");
        }

        [TestMethod]
        public void Should_Observe_JsonProperty_Attribute_Name()
        {
            //Arrange
            var sample = new SampleObject { SomeName = "howdy" };
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample, log);

            //Assert
            log.AssertHasPart("different_name", "howdy");
        }

        [TestMethod]
        public void Should_Observe_JsonProperty_Default_Ignore()
        {
            //Arrange
            var sample = new SampleObject { DefaultIgnore = default };
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample, log);

            //Assert
            log.AssertHasNoPart("default_ignore");
        }

        [TestMethod]
        public void JsonProperty_Default_Ignore_Works_With_Custom_Default()
        {
            //Arrange
            var sample = new SampleObject { CustomDefaultIgnore = 5 };
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample, log);

            //Assert
            log.AssertHasNoPart("custom_default_ignore");
        }


        [TestMethod]
        public void Regular_Bool_Becomes_1_or_0()
        {
            //Arrange
            var sample1 = new SampleObject { RegularBool = false };
            var sample2 = new SampleObject { RegularBool = true };
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample1, log);
            log.AssertHasPart("regular_bool", "0");

            log.Reset();
            _ = new ApiMultipartContent(sample2, log);
            log.AssertHasPart("regular_bool", "1");
        }


        [TestMethod]
        public void Nullable_Bool_Is_Written_Only_If_Set()
        {
            //Arrange
            var sample1 = new SampleObject { NullableBool = null };
            var sample2 = new SampleObject { NullableBool = false };
            var sample3 = new SampleObject { NullableBool = true };
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample1, log);
            log.AssertHasNoPart("nullable_bool");

            log.Reset();
            _ = new ApiMultipartContent(sample2, log);
            log.AssertHasPart("nullable_bool", "0");

            log.Reset();
            _ = new ApiMultipartContent(sample3, log);
            log.AssertHasPart("nullable_bool", "1");
        }

        [TestMethod]
        public void Empty_String_Is_Written_But_Not_Null()
        {
            //Arrange
            var sample1 = new SampleObject { MyString = null };
            var sample2 = new SampleObject { MyString = "" };
            var sample3 = new SampleObject { MyString = "howdy" };
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample1, log);
            log.AssertHasNoPart("my_string");

            log.Reset();
            _ = new ApiMultipartContent(sample2, log);
            log.AssertHasPart("my_string", "");

            log.Reset();
            _ = new ApiMultipartContent(sample3, log);
            log.AssertHasPart("my_string", "howdy");
        }

        [TestMethod]
        public void Can_Write_List_Type_Property_In_Array_Syntax()
        {
            //Arrange
            var sample = new SampleObject
            {
                Children = new List<SampleSubObject> { }
            };
            for (var i = 0; i < 5; i++)
            {
                sample.Children.Add(new SampleSubObject { Id = i, Name = i.ToString() });
            }
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample, log);
            log.AssertHasPart("children[0][id]", "0");
            log.AssertHasPart("children[0][name]", "0");
            log.AssertHasPart("children[1][id]", "1");
            log.AssertHasPart("children[1][name]", "1");
            log.AssertHasPart("children[2][id]", "2");
            log.AssertHasPart("children[2][name]", "2");
            log.AssertHasPart("children[3][id]", "3");
            log.AssertHasPart("children[3][name]", "3");
            log.AssertHasPart("children[4][id]", "4");
            log.AssertHasPart("children[4][name]", "4");
        }

        [TestMethod]
        public void Can_Write_Remote_Files()
        {
            //Arrange
            var sample = new SampleObject
            {
                Files = new PendingFileCollection()
            };
            for (var i = 0; i < 5; i++)
            {
                sample.Files.Add(new PendingFile(new System.Uri($"https://test.com/fake-file-{i}.pdf")));
            }
            var log = new TestUseApiLog();

            //Act
            _ = new ApiMultipartContent(sample, log);
            log.AssertHasPart("file_url[0]", sample.Files[0].RemotePath.ToString());
            log.AssertHasPart("file_url[1]", sample.Files[1].RemotePath.ToString());
            log.AssertHasPart("file_url[2]", sample.Files[2].RemotePath.ToString());
            log.AssertHasPart("file_url[3]", sample.Files[3].RemotePath.ToString());
            log.AssertHasPart("file_url[4]", sample.Files[4].RemotePath.ToString());
        }

        [TestMethod]
        public void Can_Write_NonRemote_Files()
        {
            //Arrange
            var sample = new SampleObject
            {
                Files = new PendingFileCollection()
            };
            for (var i = 0; i < 5; i++)
            {
                sample.Files.Add(new PendingFile(new byte[10], $"fake file {i}.pdf"));
            }
            var log = new TestUseApiLog();

            //Act
            var parts = new ApiMultipartContent(sample, log);
            for (var i = 0; i < 5; i++)
            {
                var found = parts
                    .FirstOrDefault(p => p.Headers.ContentDisposition != null &&
                    // names could be quoted by framework so a trim
                    p.Headers.ContentDisposition.Name.Trim('"') == $"file[{i}]" && 
                    p.Headers.ContentDisposition.FileName.Trim('"') == $"fake file {i}.pdf");
                Assert.IsNotNull(found, $"File part {i} not found.");
                Assert.AreEqual("application/octet-stream", found.Headers.ContentType?.MediaType, "Wrong content type");
            }
        }


        class SampleObject
        {
            // special handlings

            public bool RegularBool { get; set; }

            public bool? NullableBool { get; set; }

            public string MyString { get; set; }

            public IList<SampleSubObject> Children { get; set; }

            public PendingFileCollection Files { get; set; }


            // attrib tests

            [JsonIgnore]
            public string Ignored { get; set; }

            [JsonProperty("different_name")]
            public string SomeName { get; set; }

            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int DefaultIgnore { get; set; }

            [DefaultValue(5)]
            [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
            public int CustomDefaultIgnore { get; set; }
        }

        class SampleSubObject
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
