using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech;
using System.Threading.Tasks;
using System;

namespace EchoBot.Services
{
    public class SpeechService
    {

        private string SpeechSubscriptionKey = "";
        private string SpeechRegion = "eastus";

        private SpeechConfig _speechConfig;
        
        public SpeechService()
        {
            //_speechConfig = SpeechConfig.FromSubscription(SpeechSubscriptionKey, SpeechRegion);
        }
        public async Task ConvertTextToSpeechAsync(string text, string outputFile)
        {
            var _audioConfig = AudioConfig.FromWavFileOutput(outputFile);
            using (var synthesizer = new SpeechSynthesizer(_speechConfig, _audioConfig))
            {
                var result = await synthesizer.SpeakTextAsync(text);

                if (result.Reason == ResultReason.SynthesizingAudioCompleted)
                {
                    Console.WriteLine($"Speech synthesis passed: {result}");
                    // You can now send this "output.wav" to Teams meeting using the Calling SDK
                    //await SendAudioToTeamsMeetingAsync("output.wav");
                }
                else
                {
                    Console.WriteLine($"Speech synthesis failed: {result.Reason}");
                }
            }
        }
    }
}
