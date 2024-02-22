using Newtonsoft.Json;

namespace Jastech.Battery.Structure.Parameters
{
    public class LineParam
    {
        [JsonProperty]
        public bool EnableCheckLine { get; set; } = false;

        [JsonProperty]
        public int LineLevel { get; set; } = 0;

        [JsonProperty]
        public double LineSizeX { get; set; } = 0.1;

        [JsonProperty]
        public double LineSizeY { get; set; } = 5;
    }

    public class PinHoleParam
    {
        [JsonProperty]
        public bool EnablePinHole { get; set; } = false;

        [JsonProperty]
        public int PinHoleLevel { get; set; } = 0;

        [JsonProperty]
        public double PinHoleSize { get; set; } = 0.2;
    }

    public class CraterParam
    {
        [JsonProperty]
        public bool EnableCrater { get; set; } = false;

        [JsonProperty]
        public int CraterLevel { get; set; } = 0;

        [JsonProperty]
        public double CraterLargeSize { get; set; } = 2.0;

        [JsonProperty]
        public double CraterLargeCount { get; set; } = 1;

        [JsonProperty]
        public double CraterSmallSize { get; set; } = 2.0;

        [JsonProperty]
        public double CraterSmallCount { get; set; } = 3;
    }

    public class DentParam
    {
        [JsonProperty]
        public bool EnableDent { get; set; } = false;

        [JsonProperty]
        public int DentLevel { get; set; } = 0;

        [JsonProperty]
        public double DentSize { get; set; } = 0.5;
    }

    public class ScratchParam
    {
        [JsonProperty]
        public bool EnableScratchBlack { get; set; } = false;

        [JsonProperty]
        public int ScratchBlackLevel { get; set; } = 0;

        [JsonProperty]
        public double ScratchBlackSize { get; set; } = 10.0;

        [JsonProperty]
        public double ScratchBlackWidth { get; set; } = 2.0;
    }

    public class TapeParam
    {
        [JsonProperty]
        public bool EnableConnectionTape { get; set; } = false;

        [JsonProperty]
        public int ConnectionTapeLevel { get; set; } = 0;
    }
}
