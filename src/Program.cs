using AudioSwitcher.AudioApi.CoreAudio;

namespace AudioSwitcher
{
    static class Program
    {
        static void EnumerateAudioDevices()
        {
            var devices = new CoreAudioController().GetPlaybackDevices();
            foreach (var device in devices)
            {
                Console.WriteLine(device.FullName);
            }
        }

        static bool IsDefault(string deviceName)
        {
            var devices = new CoreAudioController().GetPlaybackDevices();
            var device = devices.FirstOrDefault(d => d.IsDefaultDevice && d.FullName == deviceName);
            return device != null;
        }

        static void SetDevice(string deviceName)
        {
            var devices = new CoreAudioController().GetPlaybackDevices();
            var device = devices.FirstOrDefault(d => d.FullName == deviceName);
            if (device != null)
            {
                device.SetAsDefault();
            }
        }

        static void Main()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length < 3)
            {
                EnumerateAudioDevices();
                return;
            }

            var beforeDevice = args[1];
            var afterDevice = args[2];

            if (IsDefault(beforeDevice))
            {
                SetDevice(afterDevice);
            }
            else
            {
                SetDevice(beforeDevice);
            }
        }
    }
}
