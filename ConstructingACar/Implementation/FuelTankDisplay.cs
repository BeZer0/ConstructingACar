using System;

namespace ConstructingACar {

    public class FuelTankDisplay : IFuelTankDisplay {
        public double FillLevel { get; private set; }
        public bool IsOnReserve { get; private set; }
        public bool IsComplete { get; private set; }

        public void FillLevelStateHandler(object sender, EventArgs eventArgs) {
            FillLevel = Math.Round(((FuelTank)sender).FillLevel, 2);
            IsOnReserve = ((FuelTank)sender).IsOnReserve;
            IsComplete = ((FuelTank)sender).IsComplete;
        }
    }
}
