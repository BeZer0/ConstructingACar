using System;

namespace ConstructingACar {

    public class DrivingProcessor : IDrivingProcessor {
        private int actualSpeed;
        private int acceleration = 10;
        private int reduceSpeed = 10;

        public double ActualConsumption { get; private set; }

        public int ActualSpeed {
            get {
                return actualSpeed;
            }
            private set {
                if (actualSpeed != value && (value >= 0)) {
                    actualSpeed = value;
                }
            }
        }

        public event EventHandler OnDrivingProcessorChange;

        private void DrivingProcessorChange() => OnDrivingProcessorChange?.Invoke(this, EventArgs.Empty);

        public DrivingProcessor(int maxAcceleration) {

            if (maxAcceleration < 5) {
                acceleration = 5;
            } else if (maxAcceleration > 20) {
                acceleration = 20;
            } else {
                acceleration = maxAcceleration;
            }
        }

        public void IncreaseSpeedTo(int speed) {

            if (ActualSpeed != speed) {
                ActualSpeed += speed - ActualSpeed > acceleration ? acceleration : speed - ActualSpeed < 0 ? -1 : speed - ActualSpeed;

                if (ActualSpeed > 250) {
                    ActualSpeed = 250;
                }
            }
            SpeedConsume();
            DrivingProcessorChange();
        }

        public void ReduceSpeed(int speed) {
            ActualSpeed -= Math.Min(speed, reduceSpeed);
            ActualConsumption = 0;

            if (ActualSpeed == 0) {
                ActualConsumption = 0.0003;
            }
            DrivingProcessorChange();
        }

        public void EngineStart() {
            ActualConsumption = 0;
            ActualSpeed = 0;
            DrivingProcessorChange();
        }

        public void EngineStop() {
            ActualConsumption = 0;
            ActualSpeed = 0;
            DrivingProcessorChange();
        }

        private void SpeedConsume() {

            if (ActualSpeed >= 1 && ActualSpeed <= 60) {
                ActualConsumption = 0.0020;
            } else if (ActualSpeed >= 61 && ActualSpeed <= 100) {
                ActualConsumption = 0.0014;
            } else if (ActualSpeed >= 101 && ActualSpeed <= 140) {
                ActualConsumption = 0.0020;
            } else if (ActualSpeed >= 141 && ActualSpeed <= 200) {
                ActualConsumption = 0.0025;
            } else if (ActualSpeed >= 201 && ActualSpeed <= 250) {
                ActualConsumption = 0.0030;
            }
        }
    }
}
