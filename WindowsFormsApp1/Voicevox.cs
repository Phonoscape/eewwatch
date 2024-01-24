using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Media;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Windows.Media.Protection.PlayReady;

namespace Voicevox
{
    internal class Voicevox
    {
        string gobi = "なのだ";

        private int speaker = 3;
        private int presetID = 0;

        private string URL = "http://127.0.0.1:50021/";
        //private string URL = "http://127.0.0.1:50020/";
        private HttpClient web;

        protected bool isReady { get; set; } = false;

        public Voicevox()
        {
            web = new HttpClient();
            //Initは使用側で呼ぶ。
            //Init();
        }

        public void Init()
        {
            isReady = ServiceCheckAsync();
            var list = ListSpeaker();
            speaker = list["ずんだもん_ノーマル"];
            //isReady = SelectSpeakerAsync("ずんだもん", "ノーマル", speaker);
            SettingPreset();
        }

        private bool ServiceCheckAsync()
        {
            var _isReady = false;
            //            web.Timeout = TimeSpan.FromMilliseconds(100);
            string opt = "version";
            try
            {
                var res = web.GetStringAsync(URL + opt);
                res.Wait();

                _isReady = true;
            }
            catch (TaskCanceledException ex)
            {
                _isReady = false;
            }
            catch (HttpRequestException ex)
            {
                _isReady = true;
            }
            catch (Exception ex)
            {
                _isReady = false;
            }

            return _isReady;
        }

        public void Talk(string message)
        {
            if (isReady)
            {
                //var query = QueryAsync(message);
                
                var query = AudioQueryFromPresetAsync(message + gobi, presetID);

                Synthesis(query);
            }
        }

        private string QueryAsync(string message)
        {
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");

            string text = "text=" + HttpUtility.UrlEncode(message);
            string speak = "speaker=" + speaker;
            string opt = "audio_query?" + speak + "&" + text;

            try
            {
                var res1 = web.PostAsync(URL + opt, content);
                res1.Wait();
                var result = res1.Result;
                var res2 = result.Content.ReadAsStringAsync();
                res2.Wait();
                var query = res2.Result;
                content.Dispose();

                return query;
            }
            catch {
                return "";
            }
        }

        private string AudioQueryFromPresetAsync(string message,int presetid)
        {
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");

            string text = "text=" + HttpUtility.UrlEncode(message);
            string preset_id = "preset_id=" + presetid;
            string opt = "audio_query_from_preset?" + text + "&" + preset_id;

            try
            {
                var res1 = web.PostAsync(URL + opt, content);
                res1.Wait();
                var result = res1.Result;
                var res2 = result.Content.ReadAsStringAsync();
                res2.Wait();
                var query = res2.Result;
                content.Dispose();

                return query;
            }
            catch
            {
                return "";
            }
        }

        private void Synthesis(string query)
        {
            string speak = "speaker=" + speaker;
            string opt = "synthesis?" + speak;
            var content = new StringContent(query, Encoding.UTF8, "application/json");

            try
            {
                var res1 = web.PostAsync(URL + opt, content);
                res1.Wait();
                var result = res1.Result;
                var res2 = result.Content.ReadAsStreamAsync();
                res2.Wait();
                var wavStream = res2.Result;

                var player = new SoundPlayer(wavStream);
                player.Play();
            }
            catch { }
        }

        private class supported_features
        {
            public string permitted_synthesis_morphing { get; set; }
        }

        private class styles
        {
            public string name { get; set; }
            public string id { get; set; }
        }

        private class Speaker
        {
            public supported_features supported_features { get; set; }
            public string name { get; set; }
            public string speaker_uuid { get; set; }
            public IList<styles> styles { get; set; }
        }

        private class Speakers
        {
            public IList<Speaker> Speaker { get; set; }
        }

        public Dictionary<string, int> ListSpeaker()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            if (isReady)
            {
                string opt = "speakers";

                var res1 = web.GetStringAsync(URL + opt);
                res1.Wait();
                var res2 = res1.Result;

                //res = res.Substring(1, res.Length - 1);
                Debug.Write(res2);

                //var json = JsonConvert.DeserializeObject<Speakers>(res);

                var j1 = JArray.Parse(res2);

                foreach (var j2 in j1)
                {
                    var j3 = j2.ToObject<Speaker>();
                    foreach (var j4 in j3.styles)
                    {
                        result.Add(j3.name + "_" + j4.name, int.Parse(j4.id));
                    }
                }
            }

            return result;
        }

        public bool SelectSpeakerAsync(string name, string style,int id)
        {
            if (isReady)
            {
                bool fCheck = false;
                string opt = "speakers";

                var res1 = web.GetStringAsync(URL + opt);
                res1.Wait();
                var res2 = res1.Result;

                //res = res.Substring(1, res.Length - 1);
                Debug.Write(res2);

                //var json = JsonConvert.DeserializeObject<Speakers>(res);

                var j1 = JArray.Parse(res2);

                foreach (var j2 in j1)
                {
                    var j3 = j2.ToObject<Speaker>();

                    if ( j3.name == name)
                    {
                        foreach (var j4 in j3.styles)
                        {
                            if (j4.name == style)
                            {
                                id = int.Parse(j4.id);
                                fCheck = true;
                                return true;
                            }
                        }
                    }
                }
                
            }
            return false;
        }

        public class Preset
        {
            public int id {  get; set; } = 0;
            public string name { get; set; } = string.Empty;
            public string speaker_uuid { get; set; } = string.Empty;
            public int style_id { get; set; } = 1;
            public double speedScale { get; set; } = 1.0;
            public double pitchScale { get; set; } = 0.0;
            public double intonationScale { get; set; } = 1.0;
            public double volumeScale { get; set; } = 1.0;
            public double prePhonemeLength { get; set; } = 0.1;
            public double postPhonemeLength { get; set; } = 0.1;
        }

        public class Presets
        {
            IList<Preset> presets;
        }

        public async void SettingPreset()
        {
            int id = 0;
            const string presetName = "緊急用";

            Preset preset = new Preset();

            var res = SearchPreset(presetName, id);

            if (!res)
            {
                //preset.name = HttpUtility.UrlEncode(presetName);
                preset.name = presetName;
                preset.style_id = speaker;
                preset.speaker_uuid = Guid.NewGuid().ToString();
                preset.speedScale = 1.25;

                SetPreset(preset, presetID);
            }
            else
            {
                presetID = id;
            }
        }

        public void SetPreset(Preset preset,int id)
        {
            if (isReady)
            {
                var json = JsonConvert.SerializeObject(preset);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                string opt = "add_preset";
                var res1 = web.PostAsync(URL + opt, content);
                res1.Wait();
                var res2 = res1.Result;
                if (res2.StatusCode != System.Net.HttpStatusCode.InternalServerError)
                {
                    var res3 = res2.Content.ReadAsStringAsync();
                    res3.Wait();

                    id = int.Parse(res3.Result);
                }
                content.Dispose();
            }
        }

        public bool SearchPreset(string name, int id)
        {
            id = 1;

            if (isReady)
            {
                string opt = "presets";
                var res1 = web.GetStringAsync(URL + opt);
                res1.Wait();
                var res2 = res1.Result;

                Debug.Write(res2);

                var j1 = JArray.Parse(res2);

                foreach (var j2 in j1)
                {
                    var j3 = j2.ToObject<Preset>();

                    if (j3.name == name)
                    {
                        id = j3.style_id;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
