using System;

namespace ConstructingACar {

    public class Car : ICar {
        private const double idleConsume = 0.0003;
        private IOnBoardComputer onBoardComputer;
        private IEngine engine;
        private IFuelTank fuelTank;
        private IDrivingProcessor drivingProcessor;
        public IDrivingInformationDisplay drivingInformationDisplay;
        public IFuelTankDisplay fuelTankDisplay;
        public IOnBoardComputerDisplay onBoardComputerDisplay; 

        public Car() : this(20, 10) { }

        public Car(double fuelLevel) : this(fuelLevel, 10) { }

        public Car(double fuelLevel, int maxAcceleration) {
            engine = new Engine();
            fuelTankDisplay = new FuelTankDisplay();
            fuelTank = new FuelTank(fuelLevel);
            drivingInformationDisplay = new DrivingInformationDisplay();
            drivingProcessor = new DrivingProcessor(maxAcceleration);
            onBoardComputer = new OnBoardComputer();
            onBoardComputerDisplay = new OnBoardComputerDisplay();

            ((Engine)engine).OnEngineConsume += ((FuelTank)fuelTank).HandleConsumeEvent;
            ((OnBoardComputer)onBoardComputer).OnBoardComputerData += ((OnBoardComputerDisplay)onBoardComputerDisplay).ComputerDataHandler;
            ((FuelTank)fuelTank).OnFuelTankChange += ((FuelTankDisplay)fuelTankDisplay).FillLevelStateHandler;
            ((FuelTank)fuelTank).OnFuelTankChange += ((Engine)engine).FuelTankHandler;
            ((FuelTank)fuelTank).OnFuelTankChange += ((OnBoardComputer)onBoardComputer).FuelTankHandler;
            ((DrivingProcessor)drivingProcessor).OnDrivingProcessorChange += ((OnBoardComputer)onBoardComputer).DrivingProcessorHandler;
            ((DrivingProcessor)drivingProcessor).OnDrivingProcessorChange += ((DrivingInformationDisplay)drivingInformationDisplay).ActualSpeedHandler;
            ((DrivingProcessor)drivingProcessor).OnDrivingProcessorChange += ((Engine)engine).DrivingProcessorHandler;
            ((OnBoardComputerDisplay)onBoardComputerDisplay).OnTripReset += ((OnBoardComputer)onBoardComputer).TripResetHandler;
            ((OnBoardComputerDisplay)onBoardComputerDisplay).OnTotalReset += ((OnBoardComputer)onBoardComputer).TotalResetHandler;
            ((FuelTank)fuelTank).SendState();
        }

        public bool EngineIsRunning => engine.IsRunning;

        public void Accelerate(int speed) {

            if (engine.IsRunning) {
                drivingProcessor.IncreaseSpeedTo(speed);
                onBoardComputer.ElapseSecond();
            }
        }

        public void BrakeBy(int speed) {

            if (engine.IsRunning) {
                drivingProcessor.ReduceSpeed(speed);
                onBoardComputer.ElapseSecond();
            }
        }

        public void EngineStart() {

            if ((!engine.IsRunning) && (fuelTank.FillLevel > 0)) {
                engine.Start();
                onBoardComputer.TripReset();
                drivingProcessor.EngineStart();
                onBoardComputer.ElapseSecond();
            }
        }

        public void EngineStop() {

            if (engine.IsRunning) {
                onBoardComputer.TripReset();
                drivingProcessor.EngineStop();
                onBoardComputer.ElapseSecond();
                engine.Stop();
            }
        }

        public void FreeWheel() {

            if (engine.IsRunning) {
                drivingProcessor.ReduceSpeed(1);
                onBoardComputer.ElapseSecond();
            }
        }

        public void Refuel(double liters) => fuelTank.Refuel(liters);

        public void RunningIdle() {

            if (engine.IsRunning) {
                drivingProcessor.ReduceSpeed(0);
                onBoardComputer.ElapseSecond();
            }
        }
    }
}
