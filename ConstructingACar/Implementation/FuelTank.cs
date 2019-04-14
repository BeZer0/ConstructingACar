using System;

namespace ConstructingACar {

    public class FuelTank : IFuelTank {
        private double _fillLevel;
        private double _maxLevel = 60;
        private double _reserveLevel = 5;
        public bool IsOnReserve { get; private set; }
        public bool IsComplete { get; private set; }
        public event EventHandler OnFuelTankChange;

        public double FillLevel {
            get {
                return _fillLevel;
            }
            private set {
                _fillLevel = value;

                if (_fillLevel >= _maxLevel) {
                    _fillLevel = _maxLevel;
                    IsComplete = true;
                } else if (_fillLevel < _reserveLevel) {
                    IsOnReserve = true;
                }
                SendState();
            }
        }

        public void SendState() => OnFuelTankChange?.Invoke(this, EventArgs.Empty);

        public void HandleConsumeEvent(object sender, EventArgs eventArgs) => Consume((double)sender);

        public FuelTank(double level) {
            if (level <= 0) {
                FillLevel = 0;
            } else {
                FillLevel = level;
            }
        }

        public void Consume(double liters) => FillLevel -= liters;

        public void Refuel(double liters) => FillLevel += liters;
    }
}
