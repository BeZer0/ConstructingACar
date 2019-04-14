using System;

namespace ConstructingACar {

    public class DrivingInformationDisplay : IDrivingInformationDisplay {
        public int ActualSpeed { get; private set; }
        public void ActualSpeedHandler(object sender, EventArgs eventArgs) => ActualSpeed = ((DrivingProcessor)sender).ActualSpeed;
    }
}
