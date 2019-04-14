using System;

namespace ConstructingACar {

    public class Engine : IEngine {
        public bool IsRunning { get; private set; } = false;

        public event EventHandler OnEngineConsume;

        private void EngineConsume(double liters) => OnEngineConsume?.Invoke(liters, EventArgs.Empty);

        public void FuelTankHandler(object sender, EventArgs eventArgs) => IsRunning = ((FuelTank)sender).FillLevel > 0 && IsRunning == true ? true : false;

        public void DrivingProcessorHandler(object sender, EventArgs eventArgs) => Consume(((DrivingProcessor)sender).ActualConsumption);

        public void Consume(double liters) => EngineConsume(liters);

        public void Start() => IsRunning = true;

        public void Stop() => IsRunning = false;
    }
}
