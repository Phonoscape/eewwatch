using System.Collections.Generic;

namespace AivisSpeech
{
    class AivisSpeech : VoiceBase.VoiceBase
    {
        public readonly string defaultVoice = "Anneli_ノーマル";

        public override void Init(string sp,int vvTalkSpeed)
        {
            gobiList = new Dictionary<string, string>();

            intnationList = new Dictionary<string, double>();
            
            URL = "http://127.0.0.1:10101/";

            IsReady = ServiceCheckAsync();
            if (IsReady)
            {
                speakerList = ListSpeaker();

                if (speakerList.Count > 0)
                {
                    if (speakerList.ContainsKey(sp))
                    {
                        speaker = sp;
                    }
                    else
                    {
                        speaker = defaultVoice;
                    }

                    speakerID = speakerList[speaker];

                    vvTalkSpeed = vvTalkSpeed < talkSpeedList.Length ? vvTalkSpeed: 0;

                    intonation = 1.0;
                    foreach (var item in intnationList)
                    {
                        if (speaker.Contains(item.Key))
                        {
                            intonation = item.Value;
                            break;
                        }
                    }

                    SetPreset(speakerID, talkSpeedList[vvTalkSpeed]);

                    gobi = string.Empty;
                    foreach (var item in gobiList)
                    {
                        if (speaker.Contains(item.Key))
                        {
                            gobi = item.Value;
                            break;
                        }
                    }
                }
                else
                {
                    IsReady = false;
                }
            }
        }
    }
}
