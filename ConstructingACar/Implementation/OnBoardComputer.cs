using System;
using System.Collections.Generic;
using System.Linq;

namespace ConstructingACar
{
    public class OnBoardComputer : IOnBoardComputer {
        private List<double> consumptionLast100Sec = new List<double>();
        private int currentTripDistance;
        private double actualConsumptionByTime;
        private double totalAvgConsumptionByTime;
        private double tripAverageConsumptionByDistance;
        public int TripRealTime { get; private set; }
        public int TripDrivingTime { get; private set; }
        public int TripDrivenDistance { get; private set; }
        public int TotalRealTime { get; private set; }
        public int TotalDrivingTime { get; private set; }
        public int TotalDrivenDistance { get; private set; }
        public double TripAverageSpeed { get; private set; }
        public double TotalAverageSpeed { get; private set; }
        public int ActualSpeed { get; private set; }
        public double TotalAverageConsumptionByDistance { get; private set; }
        public int EstimatedRange { get; private set; }
        public double TripAverageConsumptionByTime { get; private set; }

        public double ActualConsumptionByTime {
            get {
                if (TripRealTime == 0) {
                    return 0;
                }
                return actualConsumptionByTime;
            }
            private set {
                actualConsumptionByTime = value;
            }
        }

        public double ActualConsumptionByDistance {
            get {
                if (TripDrivenDistance == 0) {
                    return double.NaN;
                } else if (ActualSpeed == 0) {
                    return 0;
                }
                return ActualConsumptionByTime * 100000 / ActualSpeed * 3.6; }
        }

        public double TotalAverageConsumptionByTime {
            get {
                if (TotalRealTime == 0) {
                    return 0;
                }
                return totalAvgConsumptionByTime;
            }
            private set {
                totalAvgConsumptionByTime = value;
            }
        }

        public double TripAverageConsumptionByDistance {
            get {
                if (TripDrivingTime == 0) {
                    return 0;
                }
                return tripAverageConsumptionByDistance;
            }
            private set {
                tripAverageConsumptionByDistance = value;
            }
        }

        public event EventHandler OnBoardComputerData;

        public void SendBoardData() => OnBoardComputerData?.Invoke(this, EventArgs.Empty);

        public void DrivingProcessorHandler(object sender, EventArgs args) {
            TripRealTime++;
            ActualConsumptionByTime = ((DrivingProcessor)sender).ActualConsumption;
            ActualSpeed = ((DrivingProcessor)sender).ActualSpeed;

            if (ActualSpeed != 0) {
                consumptionLast100Sec.RemoveAt(0);
                consumptionLast100Sec.Add(ActualConsumptionByTime / ActualSpeed * 3600);
            }
        }

        public void FuelTankHandler(object sender, EventArgs args) => EstimatedRange = (int)Math.Round((((FuelTank)sender).FillLevel / consumptionLast100Sec.Average()));

        public OnBoardComputer() {
            Enumerable.Range(0, 100).ToList().ForEach(c => consumptionLast100Sec.Add(0.048));
        }

        public void SpeedHandler(object sender, EventArgs args) => ActualSpeed = (int)sender;

        public void ElapseSecond() {
            TripAverageSpeed += ActualSpeed;
            TotalAverageSpeed += ActualSpeed;
            currentTripDistance += ActualSpeed;
            TotalRealTime++;

            if (ActualSpeed != 0) {
                TotalDrivingTime++;
                TripDrivingTime++;
                TripAverageConsumptionByDistance += ActualConsumptionByTime * 100000 / ActualSpeed * 3.6;
                TotalAverageConsumptionByDistance += ActualConsumptionByTime * 100000 / ActualSpeed * 3.6;
            }
            TripAverageConsumptionByTime += ActualConsumptionByTime;
            TotalAverageConsumptionByTime += ActualConsumptionByTime;
            TotalDrivenDistance += ActualSpeed;
            TripDrivenDistance += ActualSpeed;
            SendBoardData();
        }

        public void TotalResetHandler(object sender, EventArgs args) => TotalReset();

        public void TotalReset() {
            TotalRealTime = 0;
            TotalDrivingTime = 0;
            TotalDrivenDistance = 0;
            TotalAverageSpeed = 0;
            TotalAverageConsumptionByDistance = 0;
            TotalAverageConsumptionByTime = 0;
            SendBoardData();
        }

        public void TripResetHandler(object sender, EventArgs args) => TripReset();

        public void TripReset() {
            TripAverageConsumptionByDistance = 0;
            TripAverageConsumptionByTime = 0;
            TripAverageSpeed = 0;
            TripDrivenDistance = 0;
            TripDrivingTime = 0;
            TripRealTime = 0;
            SendBoardData();
        }
    }
}
