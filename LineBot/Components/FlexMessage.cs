using System;
namespace LineBot.Components
{
    public class Contents
    {
        public string type, layout, text, color, size;
        public Contents(string type, string text, string color)
        {
            this.type = type;
            this.text = text;
            this.color = color;
        }
        public Contents(string type, string text, string color, string size)
        {
            this.type = type;
            this.text = text;
            this.color = color;
            this.size = size;
        }
    }

    public class FlexMessage
    {
        public FlexMessage()
        {

        }

        static string flexTemplate = @"{
  ""type"": ""carousel"",
  ""contents"": [
    {
      ""type"": ""bubble"",
      ""header"": {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""contents"": [
          {
            ""type"": ""box"",
            ""layout"": ""vertical"",
            ""contents"": [
              {
                ""type"": ""text"",
                ""text"": ""106上升高一強化課程"",
                ""color"": ""#FFFFFF""
              }
            ]
          },
          {
            ""type"": ""box"",
            ""layout"": ""vertical"",
            ""contents"": [
              {
                ""type"": ""text"",
                ""text"": ""MATH"",
                ""color"": ""#FFFFFF"",
                ""size"": ""3xl""
              }
            ]
          }
        ],
        ""backgroundColor"": ""#005AB5""
      },
      ""body"": {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""contents"": [
          {
            ""type"": ""box"",
            ""layout"": ""vertical"",
            ""contents"": [
              {
                ""type"": ""box"",
                ""layout"": ""horizontal"",
                ""contents"": [
                  {
                    ""type"": ""text"",
                    ""text"": ""學生:""
                  },
                  {
                    ""type"": ""text"",
                    ""text"": ""管中閔"",
                    ""align"": ""end""
                  }
                ]
              }
            ]
          },
          {
            ""type"": ""filler""
          },
          {
            ""type"": ""separator"",
            ""margin"": ""md""
          },
          {
            ""type"": ""filler""
          },
          {
            ""type"": ""box"",
            ""layout"": ""vertical"",
            ""contents"": [
              {
                ""type"": ""box"",
                ""layout"": ""horizontal"",
                ""contents"": [
                  {
                    ""type"": ""text"",
                    ""text"": ""詳細數據"",
                    ""margin"": ""none"",
                    ""size"": ""xl""
                  }
                ],
                ""margin"": ""lg"",
                ""spacing"": ""xl""
              },
              {
                ""type"": ""box"",
                ""layout"": ""vertical"",
                ""contents"": [
                  {
                    ""type"": ""box"",
                    ""layout"": ""horizontal"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""單元"",
                            ""align"": ""center""
                          }
                        ]
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""horizontal"",
                        ""contents"": [
                          {
                            ""type"": ""filler""
                          },
                          {
                            ""type"": ""separator"",
                            ""margin"": ""sm""
                          },
                          {
                            ""type"": ""filler""
                          }
                        ],
                        ""borderWidth"": ""normal"",
                        ""width"": ""1px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""成績"",
                            ""align"": ""center""
                          }
                        ]
                      }
                    ]
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [
                      {
                        ""type"": ""filler""
                      },
                      {
                        ""type"": ""separator"",
                        ""margin"": ""xs""
                      },
                      {
                        ""type"": ""filler""
                      }
                    ],
                    ""backgroundColor"": ""#000000"",
                    ""spacing"": ""xl"",
                    ""margin"": ""sm""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""horizontal"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""1-1"",
                            ""align"": ""start""
                          }
                        ]
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""horizontal"",
                        ""contents"": [
                          {
                            ""type"": ""filler""
                          },
                          {
                            ""type"": ""separator"",
                            ""color"": ""#000000"",
                            ""margin"": ""none""
                          },
                          {
                            ""type"": ""filler""
                          }
                        ],
                        ""borderWidth"": ""normal"",
                        ""width"": ""10px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""60"",
                            ""align"": ""end""
                          }
                        ]
                      }
                    ],
                    ""margin"": ""md""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [
                      {
                        ""type"": ""filler""
                      },
                      {
                        ""type"": ""separator"",
                        ""margin"": ""xs""
                      },
                      {
                        ""type"": ""filler""
                      }
                    ],
                    ""spacing"": ""xl"",
                    ""margin"": ""sm"",
                    ""backgroundColor"": ""#C0C0C0""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""horizontal"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""1-2"",
                            ""align"": ""start""
                          }
                        ]
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""horizontal"",
                        ""contents"": [
                          {
                            ""type"": ""filler""
                          },
                          {
                            ""type"": ""separator"",
                            ""color"": ""#000000"",
                            ""margin"": ""none""
                          },
                          {
                            ""type"": ""filler""
                          }
                        ],
                        ""borderWidth"": ""normal"",
                        ""width"": ""10px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""86"",
                            ""align"": ""end""
                          }
                        ]
                      }
                    ],
                    ""margin"": ""md""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [
                      {
                        ""type"": ""filler""
                      },
                      {
                        ""type"": ""separator"",
                        ""margin"": ""xs""
                      },
                      {
                        ""type"": ""filler""
                      }
                    ],
                    ""spacing"": ""xl"",
                    ""margin"": ""sm"",
                    ""backgroundColor"": ""#C0C0C0""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""horizontal"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""1-3"",
                            ""align"": ""start""
                          }
                        ]
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""horizontal"",
                        ""contents"": [
                          {
                            ""type"": ""filler""
                          },
                          {
                            ""type"": ""separator"",
                            ""color"": ""#000000"",
                            ""margin"": ""none""
                          },
                          {
                            ""type"": ""filler""
                          }
                        ],
                        ""borderWidth"": ""normal"",
                        ""width"": ""10px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""68"",
                            ""align"": ""end""
                          }
                        ]
                      }
                    ],
                    ""margin"": ""md""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [
                      {
                        ""type"": ""filler""
                      },
                      {
                        ""type"": ""separator"",
                        ""margin"": ""xs""
                      },
                      {
                        ""type"": ""filler""
                      }
                    ],
                    ""spacing"": ""xl"",
                    ""margin"": ""sm"",
                    ""backgroundColor"": ""#C0C0C0""
                  }
                ]
              }
            ]
          },
          {
            ""type"": ""filler""
          },
          {
            ""type"": ""separator"",
            ""margin"": ""lg""
          },
          {
            ""type"": ""filler""
          },
          {
            ""type"": ""box"",
            ""layout"": ""vertical"",
            ""contents"": [
              {
                ""type"": ""box"",
                ""layout"": ""horizontal"",
                ""contents"": [
                  {
                    ""type"": ""text"",
                    ""text"": ""統計圖表"",
                    ""size"": ""xl""
                  }
                ]
              },
              {
                ""type"": ""box"",
                ""layout"": ""horizontal"",
                ""contents"": [
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""100-90"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""80-90"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""70-80"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""60-70"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""50-60"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""40-50"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""30-40"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""20-30"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""10-20"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""0-10"",
                            ""align"": ""end"",
                            ""size"": ""xxs"",
                            ""color"": ""#888888""
                          }
                        ],
                        ""height"": ""20px""
                      }
                    ],
                    ""width"": ""40px""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""horizontal"",
                        ""contents"": [
                          {
                            ""type"": ""filler""
                          },
                          {
                            ""type"": ""box"",
                            ""layout"": ""vertical"",
                            ""contents"": [],
                            ""backgroundColor"": ""#B7B7B7"",
                            ""width"": ""1px"",
                            ""margin"": ""none"",
                            ""spacing"": ""none""
                          },
                          {
                            ""type"": ""filler""
                          }
                        ],
                        ""borderWidth"": ""normal"",
                        ""width"": ""12px"",
                        ""flex"": 1,
                        ""spacing"": ""none"",
                        ""margin"": ""none""
                      }
                    ],
                    ""width"": ""10px"",
                    ""spacing"": ""none"",
                    ""margin"": ""none""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""horizontal"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""box"",
                            ""layout"": ""vertical"",
                            ""contents"": [],
                            ""height"": ""40px""
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
                                ""contents"": [],
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
                            ""contents"": []
                          }
                        ]
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""box"",
                            ""layout"": ""vertical"",
                            ""contents"": [],
                            ""height"": ""14px""
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
                                ""contents"": [],
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
                            ""contents"": []
                          }
                        ]
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""box"",
                            ""layout"": ""vertical"",
                            ""contents"": [],
                            ""height"": ""32px""
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
                                ""contents"": [],
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
                            ""contents"": []
                          }
                        ]
                      }
                    ]
                  }
                ],
                ""margin"": ""md""
              },
              {
                ""type"": ""box"",
                ""layout"": ""horizontal"",
                ""contents"": [
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [],
                    ""width"": ""45px""
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
                        ""layout"": ""vertical"",
                        ""contents"": [],
                        ""height"": ""1px"",
                        ""backgroundColor"": ""#B7B7B7"",
                        ""margin"": ""none"",
                        ""spacing"": ""none""
                      },
                      {
                        ""type"": ""filler""
                      }
                    ],
                    ""width"": ""200px""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": []
                  }
                ]
              },
              {
                ""type"": ""box"",
                ""layout"": ""horizontal"",
                ""contents"": [
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [],
                    ""width"": ""40px""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""vertical"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""horizontal"",
                        ""contents"": [
                          {
                            ""type"": ""filler""
                          },
                          {
                            ""type"": ""box"",
                            ""layout"": ""vertical"",
                            ""contents"": [],
                            ""backgroundColor"": ""#FFFFFF"",
                            ""width"": ""10px""
                          },
                          {
                            ""type"": ""filler""
                          }
                        ],
                        ""borderWidth"": ""normal"",
                        ""width"": ""12px"",
                        ""flex"": 1
                      }
                    ],
                    ""width"": ""5px"",
                    ""backgroundColor"": ""#FFFFFF"",
                    ""height"": ""20px""
                  },
                  {
                    ""type"": ""box"",
                    ""layout"": ""horizontal"",
                    ""contents"": [
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""1-1"",
                            ""color"": ""#FFA500"",
                            ""align"": ""center""
                          }
                        ]
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""1-2"",
                            ""color"": ""#FFA500"",
                            ""align"": ""center""
                          }
                        ]
                      },
                      {
                        ""type"": ""box"",
                        ""layout"": ""vertical"",
                        ""contents"": [
                          {
                            ""type"": ""text"",
                            ""text"": ""1-3"",
                            ""color"": ""#FFA500"",
                            ""align"": ""center""
                          }
                        ]
                      }
                    ]
                  }
                ],
                ""margin"": ""md""
              }
            ],
            ""margin"": ""lg""
          }
        ]
      }
    }
  ]
}";


        public string changeStudentName(string strName)
        {
            dynamic flexObj = Newtonsoft.Json.JsonConvert.DeserializeObject(flexTemplate);
            string body_user = flexObj.contents[0].body.contents[0].contents[0].contents[0].text;
            flexObj.contents[0].body.contents[0].contents[0].contents[0].text = "學生：XXX";

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(flexObj);
            //Console.WriteLine(output);
            return output;
        }

        static public string getHeader()
        {
            dynamic testObj = Newtonsoft.Json.JsonConvert.DeserializeObject(flexTemplate);

            dynamic header_contents = testObj.contents[0].header.contents;
            //Class title 小字
            //dynamic header_title_caption = header_contents[0].contents[0].text;
            dynamic header_title_caption = testObj.contents[0].header.contents[0].contents[0].text;

            //Class title 大字
            //dynamic header_title = header_contents[1].contents[0].text;
            dynamic header_title = testObj.contents[0].header.contents[1].contents[0].text;


            

            //名字
            dynamic body_contents = testObj.contents[0].body.contents[0].contents[0].contents;
            //string body_user = body_contents[0].text;
            string body_user = testObj.contents[0].body.contents[0].contents[0].contents[0].text;

            //string body_teacher = body_contents[1].text;
            string body_teacher = testObj.contents[0].body.contents[0].contents[0].contents[1].text;

            Console.WriteLine(body_user);
            Console.WriteLine(body_teacher);

            dynamic data_contents = testObj.contents[0].body.contents[4].contents[1].contents;
            //Row of data
            //Console.WriteLine(data_contents[2]);
            //data name
            Console.WriteLine(data_contents[2].contents[0].contents[0].text);
            Console.WriteLine(data_contents[4].contents[0].contents[0].text);

            dynamic chart_contents = testObj.contents[0].body.contents[8];
            string chart_name = chart_contents.contents[0].contents[0].text; //統計圖表
            dynamic chart_graph = chart_contents.contents[1].contents[2];
            //point, chnage the height according to the point
            dynamic chart_bar1_point = chart_graph.contents[0].contents[0];
            dynamic chart_bar2_point = chart_graph.contents[1].contents[0];
            dynamic chart_bar3_point = chart_graph.contents[2].contents[0];


            //Console.WriteLine(chart_bar2_point);


            //var test = new[]
            //{
            //     new {
            //         type = "flex",
            //         altText = "This is a Flex Message",
            //         contents = testObj ,
            //     }
            // };

            //string output = Newtonsoft.Json.JsonConvert.SerializeObject(test);
            return "";
        }

        static public string getFlex()
        {

            
            dynamic testObj = Newtonsoft.Json.JsonConvert.DeserializeObject(flexTemplate);
            testObj.contents[0].body.contents[0].contents[0].contents[0].text = "學生：1234";

            var test = new[]
            {
                 new {
                     type = "flex",
                     altText = "This is a Flex Message",
                     contents = testObj ,
                 }
             };

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(test);
            Console.WriteLine(output);

            return output;
        }
    }
}
