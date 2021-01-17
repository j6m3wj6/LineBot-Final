using System;
using System.Collections.Generic;
using System.Text;

namespace LineBot.Components
{
    class JsonTemplate
    {
        public string Json= @"
        [       
            {
          ""type"": ""flex"",
          ""altText"": ""This is a Flex Message"",
          ""contents"":[
                       
                ]
            }
        ]";

    //    [
    //        {
    //        ""type"": ""flex"",
    //        ""altText"": ""This is a Flex Message"",
    //        ""contents"": [
    //                {

    //                }
    //            ]
    //        }
    //    ]
        public string Jsonstartgraph= @"{
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""box"",
                            ""layout"": ""vertical"",
                            ""contents"": [
                            ],
                            ""height"": """;
        public string Jsonendgraph=@"px""
                },
                {
                ""type"": ""box"",
                ""layout"": ""vertical"",
                ""contents"": [
                    {
                    ""type"": ""filler""
                    },
                    {
                    ""type"": ""box"",
                    ""layout"": ""horizontal"",
                    ""contents"": [
                    ],
                    ""width"": ""12px"",
                    ""height"": ""12px"",
                    ""borderColor"": ""#EF454D"",
                    ""borderWidth"": ""2px"",
                    ""cornerRadius"": ""30px""
                    },
                    {
                    ""type"": ""filler""
                    }
                ],
                ""alignItems"": ""center""
                },
                {
                ""type"": ""box"",
                ""layout"": ""vertical"",
                ""contents"": [
                ]
                }
            ]
        }";

        public string Jsonstartgraphfoot= @"{
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""
                          }
                          ]
                        }";
        public string Jsonendgraphfoot = @""",
                            ""color"": ""#FFA500"",
                            ""align"": ""center""
                          }]}";
        public string Test = @"{
  ""type"": ""bubble"",
  ""body"": {
    ""type"": ""box"",
    ""layout"": ""vertical"",
    ""contents"": [
      {
        ""type"": ""button"",
        ""action"": {
          ""type"": ""uri"",
          ""label"": ""action"",
          ""uri"": ""http://linecorp.com/""
        }
        }
    ]
  }
}";



        public string GraphTemplate(int grade)
        {
            return Jsonstartgraph+(100-grade).ToString()+Jsonendgraph;
        }

        public string GraphfootTemplate(int lesson)
        {
            return Jsonstartgraphfoot + (lesson) + Jsonendgraphfoot;
        }
    }
}
