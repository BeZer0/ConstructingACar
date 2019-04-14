using System;

namespace ConstructingACar {

    class OnBoardComputerDisplay : IOnBoardComputerDisplay {
        public int TripRealTime { get; private set; }
        public int TripDrivingTime { get; private set; }
        public double TripDrivenDistance { get; private set; }
        public int TotalRealTime { get; private set; }
        public int TotalDrivingTime { get; private set; }
        public double TotalDrivenDistance { get; private set; }
        public int ActualSpeed { get; private set; }
        public double TripAverageSpeed { get; private set; }
        public double TotalAverageSpeed { get; private set; }
        public double ActualConsumptionByTime { get; private set; }
        public double ActualConsumptionByDistance { get; private set; }
        public double TripAverageConsumptionByTime { get; private set; }
        public double TotalAverageConsumptionByTime { get; private set; }
        public double TripAverageConsumptionByDistance { get; private set; }
        public double TotalAverageConsumptionByDistance { get; private set; }
        public int EstimatedRange { get; private set; }

        public event EventHandler OnTotalReset;
        public event EventHandler OnTripReset;

        public void ComputerDataHandler(object sender, EventArgs args) {
            OnBoardComputer data = (OnBoardComputer)sender;
            TripRealTime = data.TripRealTime;
            TripDrivingTime = data.TripDrivingTime;
            TripDrivenDistance = Math.Round((double)data.TripDrivenDistance / 1000 / 3.6, 2);
            TotalRealTime = data.TotalRealTime;
            TotalDrivingTime = data.TotalDrivingTime;
            TotalDrivenDistance = Math.Round((double)data.TotalDrivenDistance / 1000 / 3.6, 2);
            ActualSpeed = data.ActualSpeed;
            TripAverageSpeed = Math.Round(data.TripAverageSpeed / data.TripDrivingTime, 1);
            TotalAverageSpeed = Math.Round(data.TotalAverageSpeed / data.TotalDrivingTime, 1);
            ActualConsumptionByTime = data.ActualConsumptionByTime;
            ActualConsumptionByDistance = Math.Round(data.ActualConsumptionByDistance, 1);

            if (data.TripRealTime == 0) {
                TripAverageConsumptionByTime = 0;
            } else {
                TripAverageConsumptionByTime = Math.Round(data.TripAverageConsumptionByTime / data.TripRealTime, 5);
            }

            if (data.TotalRealTime == 0) {
                TotalAverageConsumptionByTime = 0;
            } else {
                TotalAverageConsumptionByTime = Math.Round(data.TotalAverageConsumptionByTime / data.TotalRealTime, 5);
            }

            if (data.TripDrivingTime == 0) {
                TripAverageConsumptionByDistance = 0;
            } else {
                TripAverageConsumptionByDistance = Math.Round(data.TripAverageConsumptionByDistance / data.TripDrivingTime, 1);
            }

            if (data.TotalDrivingTime == 0) {
                TotalAverageConsumptionByDistance = 0;
            } else {
                TotalAverageConsumptionByDistance = Math.Round(data.TotalAverageConsumptionByDistance / data.TotalDrivingTime, 1);
            }
            EstimatedRange = data.EstimatedRange;
        }

        public void TotalReset() => OnTotalReset?.Invoke(this, EventArgs.Empty);

        public void TripReset() => OnTripReset?.Invoke(this, EventArgs.Empty);
    }
}
