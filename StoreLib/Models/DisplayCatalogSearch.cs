﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

/*
 * Copyright 2018 HexDecimal

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
   */

namespace StoreLib.Models
{
    public partial class DCatSearch
    {
        [JsonProperty("Results")]
        public List<Result> Results { get; set; }

        [JsonProperty("TotalResultCount")]
        public long TotalResultCount { get; set; }
    }

    public partial class Result
    {
        [JsonProperty("ProductFamilyName")]
        public string ProductFamilyName { get; set; }

        [JsonProperty("Products")]
        public List<Product> Products { get; set; }
    }

    public partial class Product
    {
        [JsonProperty("Height")]
        public long Height { get; set; }

        [JsonProperty("ImageType")]
        public string ImageType { get; set; }

        [JsonProperty("Width")]
        public long Width { get; set; }

        [JsonProperty("PlatformProperties")]
        public List<object> PlatformProperties { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("ProductId")]
        public string ProductId { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("BackgroundColor", NullValueHandling = NullValueHandling.Ignore)]
        public string BackgroundColor { get; set; }
    }

    public partial class DCatSearch
    {
        public static DCatSearch FromJson(string json) => JsonConvert.DeserializeObject<DCatSearch>(json, Converter1.Settings);
    }

    public static class Serialize1
    {
        public static string ToJson(this DCatSearch self) => JsonConvert.SerializeObject(self, Converter1.Settings);
    }

    internal static class Converter1
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
