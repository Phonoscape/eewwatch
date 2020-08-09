using System;
using Newtonsoft.Json;

/*

    {"result": {"status": "success", "message": "データがありません", "is_auth": true}, "report_time": "", "region_code": "", "request_time": "20181103222400", "region_name": "", "longitude": "", "is_cancel": "", "depth": "", "calcintensity": "", "is_final": "", "is_training": "", "latitude": "", "origin_time": "", "security": {"realm": "/webservice/hypo/eew/", "hash": "5ca8b8104e01ceef0f061ad597606cbd87b492db"}, "magunitude": "", "report_num": "", "request_hypo_type": "eew", "report_id": ""}

    {"result":{"status":"success","message": "","is_auth":true},"report_time":"2018/10/26 03:36:42","region_code":"","request_time":"20181026033646","region_name":"宮城県沖","longitude":"142","is_cancel":false,"depth":"40km","calcintensity":"4","is_final":false,"is_training":false,"latitude":"38.2","origin_time":"20181026033608","security":{"realm":"/kyoshin_monitor/static/jsondata/eew_est/","hash":"b61e4d95a8c42e004665825c098a6de4"},"magunitude":"5.8","report_num":"11","request_hypo_type":"eew","report_id":"20181026033619","alertflg":"警報"}
 */

    public class Result
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("is_auth")]
        public string Is_auth { get; set; }
    }

    public class Security
    {
        [JsonProperty("realm")]
        public string Realm { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }

    public class Eew
    {
        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("report_time")]
        public string Report_time { get; set; }

        [JsonProperty("region_code")]
        public string Region_code { get; set; }

        [JsonProperty("request_time")]
        public string Request_time { get; set; }

        [JsonProperty("region_name")]
        public string Region_name { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("is_cancel")]
        public string Is_cancel { get; set; }

        [JsonProperty("depth")]
        public string Depth { get; set; }

        [JsonProperty("calcintensity")]
        public string Calcintensity { get; set; }

        [JsonProperty("is_final")]
        public string Is_final { get; set; }

        [JsonProperty("is_training")]
        public string Is_training { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("origin_time")]
        public string Origin_time { get; set; }

        [JsonProperty("security")]
        public Security Security { get; set; }

        [JsonProperty("magunitude")]
        public string Magunitude { get; set; }

        [JsonProperty("report_num")]
        public string Report_num { get; set; }

        [JsonProperty("request_hypo_type")]
        public string Request_hypo_type { get; set; }

        [JsonProperty("report_id")]
        public string Report_id { get; set; }

        [JsonProperty("alertflg")]
        public string Alertflg { get; set; }
    }
