using System;

namespace DesignPattern.StructurePatterns.Adapter
{
    public class DriveAudiAdapter : DriveACarTarget
    {
        private readonly AudiCar _audiCar;
        public DriveAudiAdapter() => _audiCar = new AudiCar();
        public override void Run()
        {
                _audiCar.Run();
        }
    }
    
    public class DriveLuckyAdapter : DriveACarTarget
    {
        private readonly luckyCar _luckyCar;
        public DriveLuckyAdapter() => _luckyCar = new luckyCar();
        public override void Run()
        {
            _luckyCar.Run();
        }
    }
    
    public class DriveWLHGAdapter : DriveACarTarget
    {
        private readonly WulingHongguangCar _wuling;
        public DriveWLHGAdapter() => _wuling = new WulingHongguangCar();
        public override void Run()
        {
            _wuling.Run();
        }
    }
}